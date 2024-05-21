using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace automated_workstation_for_a_bookstore
{
    public partial class orders : Form
    {
        private readonly IConnectionProvider connectionProvider;
        NpgsqlConnection connection;
        private NpgsqlDataAdapter dataAdapter;
        private DataTable dataTable;
        public orders(IConnectionProvider connectionProvider)
        {
            InitializeComponent();
            this.connectionProvider = connectionProvider;
            connection = connectionProvider.GetConnection();
            dataAdapter = new NpgsqlDataAdapter();
            dataTable = new DataTable();
        }

        private void orders_Load(object sender, EventArgs e)
        {
            LoadDataToDataGridView("orders");
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

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                bool isEmpty = true;

                foreach (DataGridViewCell cell in selectedRow.Cells)
                {
                    if (cell.Value != null && !string.IsNullOrWhiteSpace(cell.Value.ToString()))
                    {
                        isEmpty = false;
                        break;
                    }
                }

                // If row is not empty, update labels
                if (!isEmpty)
                {
                    orderid_label.Text = "Заказ №" + selectedRow.Cells[0].Value.ToString();
                    ordertime_label.Text = selectedRow.Cells[1].Value.ToString();
                    int[] array = StringToIntArray(selectedRow.Cells[2].Value.ToString());

                    orderlist_label.Text = "";
                    int id;
                    for (int i = 0; i < array.Length; i++)
                    {
                        id = array[i];
                        orderlist_label.Text += GetNameOfBook(connection, id) + "\n";
                    }
                    ordercost_label.Text = "На сумму " + selectedRow.Cells[3].Value.ToString();
                }
            }
        }

        public static int[] StringToIntArray(string input)
        {
            // Разделить строку по запятым и пробелам
            string[] parts = input.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Создать массив для хранения преобразованных значений
            int[] array = new int[parts.Length];

            // Преобразовать каждую часть в int и добавить в массив
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
    }
}
