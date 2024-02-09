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
        public redactor(NpgsqlConnection connection)
        {
            InitializeComponent();
            /*dataAdapter = new NpgsqlDataAdapter();
            dataTable = new DataTable();*/
        }

        private void redactor_Load(object sender, EventArgs e)
        {

        }

        /*private void LoadDataToDataGridView(string table)
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
            }*/
        }
    }
}
