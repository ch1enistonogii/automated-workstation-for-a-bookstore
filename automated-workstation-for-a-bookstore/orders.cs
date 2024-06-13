using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace automated_workstation_for_a_bookstore
{
    public partial class orders : Form
    {
        // Интерфейс для подключения к базе данных
        private readonly IConnectionProvider connectionProvider;

        // Подключение к базе данных PostgreSQL
        private NpgsqlConnection connection;

        // Адаптер данных для работы с PostgreSQL
        private NpgsqlDataAdapter dataAdapter;

        // Таблица данных для хранения результатов запроса
        private DataTable dataTable;

        // Строка для хранения результата (не используется в данном фрагменте)
        private string result = "";

        public orders(IConnectionProvider connectionProvider)
        {
            InitializeComponent();
            this.connectionProvider = connectionProvider;

            // Получение подключения к базе данных
            connection = connectionProvider.GetConnection();

            // Создание адаптера данных
            dataAdapter = new NpgsqlDataAdapter();

            // Создание пустой таблицы данных
            dataTable = new DataTable();

            // Открытие соединения, если оно закрыто
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
        }


        private void orders_Load(object sender, EventArgs e)
        {

            Image backgroundImage = Image.FromFile("ico\\background.jpg");
            this.BackgroundImage = backgroundImage;


            // Загрузка данных из таблицы "orders" в DataGridView
            LoadDataToDataGridView("orders");
        }


        private void LoadDataToDataGridView(string table)
        {

            if (connection.State != ConnectionState.Open) // Проверка открытия подключения
            {
                connection.Open(); // Открытие подключения, если оно закрыто
            }

            try
            {
                // Создание новой пустой таблицы данных
                DataTable newDataTable = new DataTable();

                // Формирование SQL-запроса для выборки всех данных из таблицы
                string query = $"SELECT * FROM {table}";

                // Назначение команды выборки данных для адаптера
                dataAdapter.SelectCommand = new NpgsqlCommand(query, connection);

                // Заполнение новой таблицы данными из базы данных
                dataAdapter.Fill(newDataTable);

                // Привязка данных к DataGridView
                dataGridView1.DataSource = newDataTable;
            }
            catch (Exception ex)
            {
                // Отображение сообщения об ошибке
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }


        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the first selected row
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Flag to indicate if the row is empty (all cells without values)
                bool isEmpty = true;

                // Loop through each cell in the selected row
                foreach (DataGridViewCell cell in selectedRow.Cells)
                {
                    // Check if the cell has a non-null value and is not whitespace
                    if (cell.Value != null && !string.IsNullOrWhiteSpace(cell.Value.ToString()))
                    {
                        // Row is not empty, set flag and exit loop
                        isEmpty = false;
                        break;
                    }
                }

                // Update labels if the row is not empty
                if (!isEmpty)
                {
                    // Make order information labels visible
                    orderid_label.Visible = true;
                    ordertime_label.Visible = true;
                    orderlist_label.Visible = true;
                    ordercost_label.Visible = true;

                    // Set order ID label text
                    orderid_label.Text = "Заказ №" + selectedRow.Cells[0].Value.ToString();

                    // Set order time label text from corresponding cell
                    ordertime_label.Text = selectedRow.Cells[1].Value.ToString();

                    // Convert comma/space-separated string of IDs to integer array
                    int[] bookIDs = StringToIntArray(selectedRow.Cells[2].Value.ToString());

                    // Clear order list label text
                    orderlist_label.Text = "";

                    // Variables for book processing
                    int id;
                    int index = 1;  // Counter for book numbering

                    // Loop through the array of book IDs
                    for (int i = 0; i < bookIDs.Length; i++)
                    {
                        // Get the current book ID
                        id = bookIDs[i];

                        // Get book name based on ID (assuming a GetNameOfBook function)
                        string bookName = GetNameOfBook(connection, id); // Replace with actual implementation

                        // Add book information to order list label with numbering and cost
                        orderlist_label.Text += $"{index++}) {bookName}\n\t + {GetCostOfBook(connection, id)} тенге\n"; // Replace with actual implementation
                    }

                    // Set order cost label text from corresponding cell
                    ordercost_label.Text = $"На сумму {selectedRow.Cells[3].Value.ToString()} тенге";
                }
            }
        }


        public static int[] StringToIntArray(string input)
        //Преобразует строку, разделенную запятыми и пробелами, в массив целых чисел.
        {
            // Разделяет строку по запятым и пробелам, удаляя пустые элементы
            string[] parts = input.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Создает массив для хранения преобразованных значений
            int[] array = new int[parts.Length];

            // Преобразовать каждую часть в int и добавить в массив
            for (int i = 0; i < parts.Length; i++)
            {
                // Преобразовать строковое значение в целое число
                array[i] = int.Parse(parts[i]);
            }

            // **Возвращает массив целых чисел.**
            return array;
        }


        private static string GetNameOfBook(NpgsqlConnection connection, int id)
        {
            // **Получает название книги по ее идентификатору.**

            // Формирование SQL-запроса для выборки имени книги по ID
            string query = $"SELECT name FROM public.books WHERE id = {id}";

            // Создание команды NpgsqlCommand для выполнения запроса
            NpgsqlCommand command = new NpgsqlCommand(query, connection);

            // Выполнение запроса и получение результата (скалярного значения)
            object result = command.ExecuteScalar();

            // Проверка наличия результата
            if (result != null)
            {
                // Преобразование результата в строку (имя книги)
                string name = result.ToString();
                return name;
            }
            else
            {
                // Книга не найдена, возвращается сообщение об ошибке
                return "Book not found.";
            }
        }


        private void refresh_button_Click(object sender, EventArgs e)
        // Кнопка Обновить
        {
            // Вызывает функцию заполнения таблицы DataGrid данными из БД
            LoadDataToDataGridView("orders");
        }


        private static string GetCostOfBook(NpgsqlConnection connection, int id)
        {
            // **Получает стоимость книги по ее идентификатору.**

            // Формирование SQL-запроса для выборки стоимости книги по ID
            string query = $"SELECT cost FROM public.books WHERE id = {id}";

            // Создание команды NpgsqlCommand для выполнения запроса
            NpgsqlCommand command = new NpgsqlCommand(query, connection);

            // Выполнение запроса и получение результата (скалярного значения)
            object result = command.ExecuteScalar();

            // Проверка наличия результата
            if (result != null)
            {
                // Преобразование результата в строку (стоимость книги)
                string cost = result.ToString();
                return cost;
            }
            else
            {
                // Книга не найдена, возвращается сообщение об ошибке
                return "Book not found.";
            }
        }

        
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        // Обработчик события для пункта меню "Открыть (Касса)"
        {
            // Создать новый экземпляр формы Cashbox
            cashbox cashboxForm = new cashbox(connectionProvider);

            // Скрыть текущую форму (предполагая, что это главная форма)
            this.Hide();

            // Добавить обработчик события для события `FormClosed` формы Cashbox
            cashboxForm.FormClosed += (s, args) => this.Close();
            // Это гарантирует, что главная форма закрывается при закрытии формы Cashbox.

            // Отобразить форму Cashbox
            cashboxForm.Show();
        }

        
        private void открытьВНовойВкладкеToolStripMenuItem_Click(object sender, EventArgs e)
        // Обработчик события для пункта меню "Открыть (Касса) в новой вкладке"
        {
            // Создать новый экземпляр формы Cashbox
            cashbox cashboxForm = new cashbox(connectionProvider);

            // Отобразить форму Cashbox без скрытия текущей формы
            cashboxForm.Show();
        }


        private void открытьToolStripMenuItem1_Click(object sender, EventArgs e)
        // Обработчик события для пункта меню "Открыть (Редактор)"
        {
            // Создать новый экземпляр формы Redactor
            redactor redactorForm = new redactor(connectionProvider);

            // Скрыть текущую форму (предполагая, что это главная форма)
            this.Hide();

            // Добавить обработчик события для события `FormClosed` формы Redactor
            redactorForm.FormClosed += (s, args) => this.Close();
            // Это гарантирует, что главная форма закрывается при закрытии формы Redactor.

            // Отобразить форму Redactor
            redactorForm.Show();
        }

        
        private void открытьВНовойВкладкеToolStripMenuItem1_Click(object sender, EventArgs e)
        // Обработчик события для пункта меню "Открыть (Редактор) в новой вкладке"
        {
            // Создать новый экземпляр формы Redactor
            redactor redactorForm = new redactor(connectionProvider);

            // Отобразить форму Redactor без скрытия текущей формы
            redactorForm.Show();
        }


        private void print_button_Click(object sender, EventArgs e)
        {
            // задаем текст для печати
            result = $"\n\n\t\t\t{orderid_label.Text}\n";
            result += $"\t\t\t{ordertime_label.Text}\n\n";
            result += $"{orderlist_label.Text}\n\n";
            result += $"\t{ordercost_label.Text}";

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


        void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            // Определяем величину отступа
            int marginLeft = 75; // Отступ в пикселях

            // Печать строки result с отступом
            e.Graphics.DrawString(result, new Font("Arial", 14), Brushes.Black, marginLeft, 0);
        }
    }
}