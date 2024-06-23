using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace automated_workstation_for_a_bookstore
{
    public partial class redactor : Form
    {
        // Поля класса
        private readonly IConnectionProvider connectionProvider; // Провайдер подключения к базе данных
        private NpgsqlConnection connection; // Подключение к базе данных Npgsql
        private NpgsqlDataAdapter dataAdapter; // Адаптер данных Npgsql
        private DataTable dataTable; // Таблица данных

        // Конструктор класса
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

        // Обработчик загрузки формы
        private void redactor_Load(object sender, EventArgs e)
        {
            Image backgroundImage = Image.FromFile("ico\\background.jpg"); // Загрузка фонового изображения
            this.BackgroundImage = backgroundImage; // Установка фонового изображения

            // Подписка на события DataGridView
            dataGridView1.CellFormatting += dataGridView1_CellFormatting; // Событие форматирования ячейки
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged; // Событие изменения значения ячейки
            dataGridView1.UserDeletingRow += dataGridView1_UserDeletingRow; // Событие удаления строки

            LoadDataToDataGridView("Books"); // Загрузка данных в DataGridView из таблицы "Books"
        }

        // Обработчик форматирования ячеек DataGridView
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Изменение отображения столбца "img" для отображения изображений
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

        // Обработчик изменения значения ячейки DataGridView
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex]; // Получить измененную строку
                int id = Convert.ToInt32(row.Cells["id"].Value); // Получить значение ID
                string columnName = dataGridView1.Columns[e.ColumnIndex].Name; // Получить название столбца
                object newValue = row.Cells[e.ColumnIndex].Value; // Получить новое значение

                UpdateDatabase(id, columnName, newValue); // Обновить базу данных
            }
        }

        // Обработчик удаления строки DataGridView
        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int id = Convert.ToInt32(e.Row.Cells["id"].Value); // Получить значение ID удаляемой строки
            DeleteRowFromDatabase(id); // Удалить строку из базы данных
        }

        // Метод обновления базы данных
        private void UpdateDatabase(int id, string columnName, object newValue)
        {
            try
            {
                using (NpgsqlCommand command = new NpgsqlCommand($"UPDATE Books SET {columnName} = @value WHERE id = @id", connection))
                {
                    command.Parameters.AddWithValue("@value", newValue); // Добавить параметр значения
                    command.Parameters.AddWithValue("@id", id); // Добавить параметр ID
                    command.ExecuteNonQuery(); // Выполнить команду
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка обновления базы данных: {ex.Message}"); // Отобразить сообщение об ошибке
            }
        }

        // Метод удаления строки из базы данных
        private void DeleteRowFromDatabase(int id)
        {
            try
            {
                using (NpgsqlCommand command = new NpgsqlCommand("DELETE FROM Books WHERE id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id); // Добавить параметр ID
                    command.ExecuteNonQuery(); // Выполнить команду
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка удаления строки из базы данных: {ex.Message}"); // Отобразить сообщение об ошибке
            }
        }

        // Метод загрузки данных в DataGridView
        private void LoadDataToDataGridView(string table)
        {
            if (connection.State != ConnectionState.Open) // Проверка открытия подключения
            {
                connection.Open(); // Открытие подключения, если оно закрыто
            }

            try
            {
                DataTable newDataTable = new DataTable(); // Создание новой таблицы данных

                // Запрос для получения данных из выбранной таблицы
                string query = $"SELECT * FROM {table}"; // Формирование SQL-запроса для выборки всех данных из указанной таблицы
                dataAdapter.SelectCommand = new NpgsqlCommand(query, connection); // Назначение запроса адаптеру данных

                dataAdapter.Fill(newDataTable); // Заполнение новой таблицы данными из запроса

                // Привязка данных к DataGridView
                dataGridView1.DataSource = newDataTable; // Привязка таблицы данных к DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}"); // Отображение сообщения об ошибке
            }
        }

        // Обработчик нажатия пункта меню "Открыть кассу"
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cashbox cashboxForm = new cashbox(connectionProvider); // Создать новую форму кассы
            this.Hide(); // Скрыть текущую форму
            cashboxForm.FormClosed += (s, args) => this.Close(); // Подписка на событие закрытия формы кассы, чтобы закрыть текущую форму по закрытии кассы
            cashboxForm.Show(); // Показать форму кассы
        }

        // Обработчик нажатия пункта меню "Открыть кассу в новой вкладке"
        private void открытьВНовойВкладкеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cashbox cashboxForm = new cashbox(connectionProvider); // Создать новую форму кассы
            cashboxForm.Show(); // Показать форму кассы
        }

        // Обработчик нажатия кнопки "Добавить книгу"
        private void addBookbutton_Click(object sender, EventArgs e)
        {
            addBook addBookForm = new addBook(connectionProvider); // Создать новую форму добавления книги
            addBookForm.Show(); // Показать форму добавления книги
        }

        // Обработчик нажатия пункта меню "Открыть заказы"
        private void открытьToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            orders ordersForm = new orders(connectionProvider); // Создать новую форму заказов
            this.Hide(); // Скрыть текущую форму
            ordersForm.FormClosed += (s, args) => this.Close(); // Подписка на событие закрытия формы заказов, чтобы закрыть текущую форму по закрытии заказов
            ordersForm.Show(); // Показать форму заказов
        }

        // Обработчик нажатия пункта меню "Открыть заказы в новой вкладке"
        private void открытьВНовойВкладкеToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            orders ordersForm = new orders(connectionProvider); // Создать новую форму заказов
            ordersForm.Show(); // Показать форму заказов
        }

        // Обработчик нажатия кнопки "Удалить"
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            // Получить выбранную строку
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0]; // Получить первую выбранную строку

            // Проверяет, есть ли выбранная строка
            if (selectedRow != null) // Проверка наличия выбранной строки
            {
                // Получает значение первичного ключа из выбранной строки
                int id = (int)selectedRow.Cells["id"].Value; // Предполагается, что столбец "id" содержит первичный ключ

                // Удаляет строку из базы данных
                using (NpgsqlCommand command = new NpgsqlCommand("DELETE FROM Books WHERE id = @id", connection)) // Создание SQL-запроса для удаления
                {
                    command.Parameters.AddWithValue("@id", id); // Добавление параметра в запрос с значением первичного ключа
                    command.ExecuteNonQuery(); // Выполнение запроса
                }

                // Обновляет DataGridView
                dataGridView1.Rows.Remove(selectedRow); // Удаление выбранной строки из DataGridView
            }
            else
            {
                // Выводит сообщение об ошибке, если строка не выбрана
                MessageBox.Show("Пожалуйста, выберите строку для удаления."); // Отображение сообщения об ошибке
            }
        }

        // Обработчик нажатия кнопки "Обновить"
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView("Books"); // Загрузка данных из таблицы "Books" в DataGridView
        }
    }
}
