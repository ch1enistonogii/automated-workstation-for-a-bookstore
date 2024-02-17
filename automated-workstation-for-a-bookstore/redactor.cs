using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace automated_workstation_for_a_bookstore
{
    public partial class redactor : Form
    {
        string table;
        private readonly IConnectionProvider connectionProvider;
        private NpgsqlDataAdapter dataAdapter;
        NpgsqlConnection connection;
        private DataTable dataTable;


        public redactor(IConnectionProvider connectionProvider)
        {
            InitializeComponent();
            this.connectionProvider = connectionProvider;
            connection = connectionProvider.GetConnection();
            dataAdapter = new NpgsqlDataAdapter();
            dataTable = new DataTable();
        }

        private void redactor_Load(object sender, EventArgs e)
        {
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView(table);
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        // Функция изменяет столбцы под изображения
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("book_img") && e.RowIndex >= 0)
            {
                byte[] byteArray = e.Value as byte[];

                if (byteArray != null && byteArray.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(byteArray))
                    {
                        Image image = Image.FromStream(ms);

                        int targetWidth = 100;
                        int targetHeight = 100;

                        Image scaledImage = new Bitmap(image, targetWidth, targetHeight);
                        e.Value = scaledImage;

                        dataGridView1.Rows[e.RowIndex].Height = scaledImage.Height;
                    }
                }
            }
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

        private void SelectTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectTable.SelectedIndex == 0)
            {
                table = "books";
            }
            else
            {
                table = "orders";
            }
            LoadDataToDataGridView(table);
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cashbox cashboxForm = new cashbox(connectionProvider);
            this.Hide();
            cashboxForm.FormClosed += (s, args) => this.Close();
            cashboxForm.Show();
        }

        private void открытьВНовойВкладкеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cashbox cashboxForm = new cashbox(connectionProvider);
            cashboxForm.Show();
        }

        private void addBookbutton_Click(object sender, EventArgs e)
        {
            addBook addBookForm = new addBook(connectionProvider);
            addBookForm.Show();
        }
    }
}
