using Npgsql;
using System;
using System.Collections;
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
        // **Поля класса**

        private readonly IConnectionProvider connectionProvider; // Провайдер подключения к базе данных
        private NpgsqlConnection connection; // Подключение к базе данных Npgsql
        private NpgsqlDataAdapter dataAdapter; // Адаптер данных Npgsql
        private DataTable dataTable; // Таблица данных

        // **Конструктор класса**

        public redactor(IConnectionProvider connectionProvider)
        {
            InitializeComponent(); // Инициализация компонентов формы
            this.connectionProvider = connectionProvider; // Получение провайдера подключения
            connection = connectionProvider.GetConnection(); // Получение подключения к базе данных

            dataAdapter = new NpgsqlDataAdapter(); // Создать новый адаптер данных Npgsql
            dataTable = new DataTable(); // Создать новую таблицу данных

            if (connection.State != ConnectionState.Open) // Проверка открытия подключения
            {
                connection.Open(); // Открытие подключения, если оно закрыто
            }
        }

        // **Обработчик загрузки формы**

        private void redactor_Load(object sender, EventArgs e)
        {
            Image backgroundImage = Image.FromFile("ico\\background.jpg");
            this.BackgroundImage = backgroundImage;


            dataGridView1.CellFormatting += dataGridView1_CellFormatting; // Подписать обработчик события форматирования ячейки
            LoadDataToDataGridView("Books"); // Загрузить данные в dataGridView из таблицы "Books"
        }

        // **Обработчик форматирования ячеек dataGridView**

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // **Функция изменяет отображение столбца "img" для отображения изображений**

            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("img") && e.RowIndex >= 0)
            {
                byte[] byteArray = e.Value as byte[]; // Получить массив байт из ячейки

                if (byteArray != null && byteArray.Length > 0) // Проверка наличия данных
                {
                    using (MemoryStream ms = new MemoryStream(byteArray)) // Создать поток памяти из массива байт
                    {
                        Image image = Image.FromStream(ms); // Создать изображение из потока памяти

                        int targetWidth = 75; // Целевая ширина изображения
                        int targetHeight = 75; // Целевая высота изображения

                        Image scaledImage = new Bitmap(image, targetWidth, targetHeight); // Создать масштабированное изображение
                        e.Value = scaledImage; // Установить масштабированное изображение в ячейку

                        dataGridView1.Rows[e.RowIndex].Height = scaledImage.Height; // Установить высоту строки в соответствии с высотой изображения
                    }
                }
            }
        }


        private void LoadDataToDataGridView(string table)
        {
            // **Функция заполняет dataGrid данными из SQL**

            if (connection.State != ConnectionState.Open) // Проверка открытия подключения
            {
                connection.Open(); // Открытие подключения, если оно закрыто
            }

            try
            {
                DataTable newDataTable = new DataTable(); // Создание новой таблицы данных

                // **Запрос для получения данных из выбранной таблицы**

                string query = $"SELECT * FROM {table}"; // Формирование SQL-запроса для выборки всех данных из указанной таблицы
                dataAdapter.SelectCommand = new NpgsqlCommand(query, connection); // Назначение запроса адаптеру данных

                dataAdapter.Fill(newDataTable); // Заполнение новой таблицы данными из запроса

                // **Привязываем данные к DataGridView**

                dataGridView1.DataSource = newDataTable; // Привязка таблицы данных к DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}"); // Отображение сообщения об ошибке
            }
        }


        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // **Обработчик нажатия пункта меню "Открыть кассу"**

            cashbox cashboxForm = new cashbox(connectionProvider); // Создать новую форму кассы
            this.Hide(); // Скрыть текущую форму
            cashboxForm.FormClosed += (s, args) => this.Close(); // Подписать на событие закрытия формы кассы, чтобы закрыть текущую форму по закрытии кассы
            cashboxForm.Show(); // Показать форму кассы
        }

        private void открытьВНовойВкладкеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // **Обработчик нажатия пункта меню "Открыть кассу в новой вкладке"**

            cashbox cashboxForm = new cashbox(connectionProvider); // Создать новую форму кассы
            cashboxForm.Show(); // Показать форму кассы
        }

        private void addBookbutton_Click(object sender, EventArgs e)
        {
            // **Обработчик нажатия кнопки "Добавить книгу"**

            addBook addBookForm = new addBook(connectionProvider); // Создать новую форму добавления книги
            addBookForm.Show(); // Показать форму добавления книги
        }

        private void открытьToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            // **Обработчик нажатия пункта меню "Открыть заказы"**

            orders ordersForm = new orders(connectionProvider); // Создать новую форму заказов
            this.Hide(); // Скрыть текущую форму
            ordersForm.FormClosed += (s, args) => this.Close(); // Подписать на событие закрытия формы заказов, чтобы закрыть текущую форму по закрытии заказов
            ordersForm.Show(); // Показать форму заказов
        }

        private void открытьВНовойВкладкеToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            // **Обработчик нажатия пункта меню "Открыть заказы в новой вкладке"**

            orders ordersForm = new orders(connectionProvider); // Создать новую форму заказов
            ordersForm.Show(); // Показать форму заказов
        }


        private void DeleteButton_Click(object sender, EventArgs e)
        {
            // **Обработчик нажатия кнопки "Удалить"**

            // **Получить выбранную строку**

            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0]; // Получить первую выбранную строку

            // **Проверить, есть ли выбранная строка**

            if (selectedRow != null) // Проверка наличия выбранной строки
            {
                // **Получить значение первичного ключа из выбранной строки**

                int id = (int)selectedRow.Cells["id"].Value; // Предполагается, что столбец "id" содержит первичный ключ

                // **Удалить строку из базы данных**

                using (NpgsqlCommand command = new NpgsqlCommand("DELETE FROM Books WHERE id = @id", connection)) // Создание SQL-запроса для удаления
                {
                    command.Parameters.AddWithValue("@id", id); // Добавление параметра в запрос с значением первичного ключа
                    command.ExecuteNonQuery(); // Выполнение запроса
                }

                // **Обновить DataGridView**

                dataGridView1.Rows.Remove(selectedRow); // Удаление выбранной строки из DataGridView
            }
            else
            {
                // **Вывести сообщение об ошибке, если строка не выбрана**

                MessageBox.Show("Пожалуйста, выберите строку для удаления."); // Отображение сообщения об ошибке
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            // **Обработчик нажатия кнопки "Обновить"**

            LoadDataToDataGridView("Books"); // Загрузка данных из таблицы "Books" в DataGridView
        }
    }
}