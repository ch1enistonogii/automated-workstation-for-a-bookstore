using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Printing;
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
        private string result = "";

        double totalcost = 0.0;
        public cashbox(IConnectionProvider connectionProvider)
        {
            InitializeComponent();
            this.connectionProvider = connectionProvider;
            connection = connectionProvider.GetConnection();
            dataAdapter = new NpgsqlDataAdapter();
            dataTable = new DataTable();

            connection.Open();
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
                    string query = $"SELECT * FROM books WHERE {SearchComboBox.Text} ILIKE '%{SearchTextBox.Text}%';";
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

        private void открытьToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            orders ordersForm = new orders(connectionProvider);
            this.Hide();
            ordersForm.FormClosed += (s, args) => this.Close();
            ordersForm.Show();
        }

        private void открытьВНовойВкладкеToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            orders ordersForm = new orders(connectionProvider);
            ordersForm.Show();
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
                string query =
                "INSERT INTO orders (id, checklist, sum)" +
                $"VALUES ('{GetLastOrder(connection)}', '{GetChecklist(connection)}', '{totalcost}')";

                NpgsqlCommand command = new NpgsqlCommand(query, connection);

                command.ExecuteNonQuery();

                MessageBox.Show("Заказ оформлен");



                // задаем текст для печати
                result = GetDocument(connection);

                // объект для печати
                PrintDocument printDocument = new PrintDocument();

                // обработчик события печати
                printDocument.PrintPage += PrintPageHandler;

                // диалог настройки печати
                PrintDialog printDialog = new PrintDialog();

                // установка объекта печати для его настройки
                printDialog.Document = printDocument;

                // если в диалоге было нажато ОК
                if (printDialog.ShowDialog() == DialogResult.OK)
                    printDialog.Document.Print(); // печатаем
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private int GetLastOrder(NpgsqlConnection connection)
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

        private string GetChecklist(NpgsqlConnection connection)
        {
            string checklist = "";

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (!row.IsNewRow && row.Cells[0].Value != null)
                {
                    double cellValue;
                    if (double.TryParse(row.Cells[0].Value.ToString(), out cellValue))
                    {
                        checklist += cellValue.ToString() + ",";
                    }
                }
            }

            return checklist.TrimEnd(',');
        }

        void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            // печать строки result
            e.Graphics.DrawString(result, new Font("Arial", 14), Brushes.Black, 0, 0);
        }

        private string GetDocument(NpgsqlConnection connection)
        {
            result = "";
            int id = 0;
            int[] array = StringToIntArray(GetChecklist(connection));

            result += $"\n\n\n\t\t\t\tЗаказ №{GetOrderId(connection)}\n";

            result += "\t\t\t\t" + GetOrderTime(connection) + "\n";

            for (int i = 0; i < array.Length; i++)
            {
                id = array[i];
                result += $"\t\t{i}) {GetNameOfBook(connection, id)}\t{ GetCostOfBook(connection, id)} тенге\n";
            }
            result += $"Чек на сумму{totalcost}";
            return result;
        }
        public static int[] StringToIntArray(string input)
        {
            string[] parts = input.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int[] array = new int[parts.Length];

            for (int i = 0; i < parts.Length; i++)
            {
                array[i] = int.Parse(parts[i]);
            }
            return array;
        }
        private static string GetNameOfBook(NpgsqlConnection connection, int id)
        {
            string query = $"SELECT name FROM public.books WHERE id = {id}";

            NpgsqlCommand command = new NpgsqlCommand(query, connection);

            object result = command.ExecuteScalar();

            if (result != null)
            {
                string name = result.ToString();
                return name;
            }
            else
            {
                return "Book not found.";
            }
        }

        private static string GetCostOfBook(NpgsqlConnection connection, int id)
        {
            string query = $"SELECT cost FROM public.books WHERE id = {id}";

            NpgsqlCommand command = new NpgsqlCommand(query, connection);

            object result = command.ExecuteScalar();

            if (result != null)
            {
                string cost = result.ToString();
                return cost;
            }
            else
            {
                return "Book not found.";
            }
        }
        private static int GetOrderId(NpgsqlConnection connection)
        {
            string query = $"SELECT MAX(id) FROM orders";
            NpgsqlCommand command = new NpgsqlCommand(query, connection);


            object result = command.ExecuteScalar();

            int lastId = (int)result;
            return lastId;
        }
        private static string GetOrderTime(NpgsqlConnection connection)
        {
            string query = $"SELECT time FROM orders ORDER BY time DESC LIMIT 1";
            NpgsqlCommand command = new NpgsqlCommand(query, connection);

            object result = command.ExecuteScalar();

            string lastTimestampString = result.ToString();
            return lastTimestampString;
        }
    }
}