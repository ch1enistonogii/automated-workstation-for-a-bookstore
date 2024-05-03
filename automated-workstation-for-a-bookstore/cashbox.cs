﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace automated_workstation_for_a_bookstore
{
    public partial class cashbox : Form
    {
        private readonly IConnectionProvider connectionProvider;
        NpgsqlConnection connection;
        private NpgsqlDataAdapter dataAdapter;
        private DataTable dataTable;

        double totalcost = 0.0;
        public cashbox(IConnectionProvider connectionProvider)
        {
            InitializeComponent();
            this.connectionProvider = connectionProvider;
            connection = connectionProvider.GetConnection();
            dataAdapter = new NpgsqlDataAdapter();
            dataTable = new DataTable();
        }

        private void cashbox_Load(object sender, EventArgs e)
        {
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            LoadDataToDataGridView("Books");

            dataGridView2.ColumnCount = 11;
            dataGridView2.Columns[0].Name = "id";
            dataGridView2.Columns[1].Name = "name";
            dataGridView2.Columns[2].Name = "cost";
            dataGridView2.Columns[3].Name = "author";
            dataGridView2.Columns[4].Name = "pubhouse";
            dataGridView2.Columns[5].Name = "category";
            dataGridView2.Columns[6].Name = "genre";
            dataGridView2.Columns[7].Name = "pubyear";
            dataGridView2.Columns[8].Name = "type";
            dataGridView2.Columns[9].Name = "lang";
            dataGridView2.Columns[10].Name = "agelimit";
        }

        private void LoadDataToDataGridView(string table)
        //  Функция заполняет dataGrid данными из SQL
        {
            try
            {
                DataTable newDataTable = new DataTable();

                // Запрос для получения данных из выбранной таблицы
                string query = $"SELECT * FROM {table}";
                dataAdapter.SelectCommand = new NpgsqlCommand(query, connection);
                dataAdapter.Fill(newDataTable);

                // Привязываем данные к DataGridView
                dataGridView1.DataSource = newDataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (SearchTextBox.Text.Length != 0)
            {
                try
                {
                    DataTable newDataTable = new DataTable();

                    // Запрос для получения данных из выбранной таблицы
                    string query = $"SELECT * FROM books WHERE {SearchComboBox.Text} = '{SearchTextBox.Text}';";
                    dataAdapter.SelectCommand = new NpgsqlCommand(query, connection);
                    dataAdapter.Fill(newDataTable);

                    // Привязываем данные к DataGridView
                    dataGridView1.DataSource = newDataTable;
                }
                catch
                {
                    LoadDataToDataGridView("Books");
                }
            }
            else
            {
                LoadDataToDataGridView("Books");
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        // Функция изменяет столбцы под изображения
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("img") && e.RowIndex >= 0)
            {
                byte[] byteArray = e.Value as byte[];

                if (byteArray != null && byteArray.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(byteArray))
                    {
                        Image image = Image.FromStream(ms);

                        int targetWidth = 75;
                        int targetHeight = 75;

                        Image scaledImage = new Bitmap(image, targetWidth, targetHeight);
                        e.Value = scaledImage;

                        dataGridView1.Rows[e.RowIndex].Height = scaledImage.Height;
                    }
                }
            }
        }
        private void dataGridView1_SelectionChanged_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                object[] rowData = new object[11];
                int dataIndex = 0;
                for (int i = 0; i < selectedRow.Cells.Count; i++)
                {
                    if (i != 3)
                    {
                        rowData[dataIndex] = selectedRow.Cells[i].Value;
                        dataIndex++;
                    }
                }

                // Добавляем данные в новую строку в dataGridView2
                dataGridView2.Rows.Add(rowData);
                CalculateCost();
            }
        }
        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                // Получаем выделенную строку
                DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];

                // Проверяем, все ли ячейки пустые
                bool isEmpty = true;
                foreach (DataGridViewCell cell in selectedRow.Cells)
                {
                    if (cell.Value != null && !string.IsNullOrWhiteSpace(cell.Value.ToString()))
                    {
                        isEmpty = false;
                        break;
                    }
                }

                // Если строка не пустая, удаляем её
                if (!isEmpty)
                {
                    dataGridView2.Rows.RemoveAt(selectedRow.Index);
                    CalculateCost();
                }
            }
        }

        private void открытьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            redactor redactorForm = new redactor(connectionProvider);
            this.Hide();
            redactorForm.FormClosed += (s, args) => this.Close();
            redactorForm.Show();
        }

        private void открытьВНовойВкладкеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            redactor redactorForm = new redactor(connectionProvider);
            redactorForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void CalculateCost()
        {
            double sum = 0.0;

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (!row.IsNewRow && row.Cells[2].Value != null && double.TryParse(row.Cells[2].Value.ToString(), out double cellValue))
                {
                    sum += cellValue;
                }
            }

            totalcost = sum;
            label5.Text = totalcost.ToString();

            if (totalcost != 0)
            {
                label5.Text += " тенге";
            }
        }

        private void orderButton_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                string query =
                "INSERT INTO orders (id, time, checklist, sum)" +
                $"VALUES ('{GetLastOrder(connection)}', )";

                NpgsqlCommand command = new NpgsqlCommand(query, connection);

                // Выполнение запроса
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private static int GetLastOrder(NpgsqlConnection connection)
        {
            string query = "SELECT MAX(id) FROM orders";
            NpgsqlCommand command = new NpgsqlCommand(query, connection);

            object result = command.ExecuteScalar();

            if (result == null || result == DBNull.Value)
            {
                return 0;
            }
            int lastOrderId = Convert.ToInt32(result) + 1;
            return lastOrderId;
        }
    }
}