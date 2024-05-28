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
        private readonly IConnectionProvider connectionProvider; // Провайдер подключения к базе данных
        private NpgsqlConnection connection; // Подключение к базе данных Npgsql
        private NpgsqlDataAdapter dataAdapter; // Адаптер данных Npgsql
        private DataTable dataTable; // Таблица данных

        private string result = ""; // Строка для хранения результата (временная переменная)

        double totalcost = 0.0; // Общая стоимость заказа

        public cashbox(IConnectionProvider connectionProvider)
        {
            // **Конструктор формы**

            InitializeComponent();
            this.connectionProvider = connectionProvider; // Получение провайдера подключения
            connection = connectionProvider.GetConnection(); // Получение подключения к базе данных
            dataAdapter = new NpgsqlDataAdapter(); // Инициализация адаптера данных
            dataTable = new DataTable(); // Инициализация таблицы данных

            if (connection.State != ConnectionState.Open) // Проверка открытия подключения
            {
                connection.Open(); // Открытие подключения, если оно закрыто
            }
        }

        private void cashbox_Load(object sender, EventArgs e)
        {
            // **Обработчик загрузки формы**

            dataGridView1.CellFormatting += dataGridView1_CellFormatting; // Подписка на событие форматирования ячеек dataGridView1 (необязательный код, зависит от реализации)

            LoadDataToDataGridView("Books"); // Загрузка данных в dataGridView1 из таблицы "Books" (предполагается наличие функции LoadDataToDataGridView)

            dataGridView2.ColumnCount = 11; // Установка количества столбцов в dataGridView2 (для списка товаров в заказе и так далее)
            dataGridView2.Columns[0].Name = "id";
            dataGridView2.Columns[1].Name = "Название";
            dataGridView2.Columns[2].Name = "цена";
            dataGridView2.Columns[3].Name = "Автор";
            dataGridView2.Columns[4].Name = "Издательство";
            dataGridView2.Columns[5].Name = "Категория";
            dataGridView2.Columns[6].Name = "Жанр";
            dataGridView2.Columns[7].Name = "Год издания";
            dataGridView2.Columns[8].Name = "Тип обложки";
            dataGridView2.Columns[9].Name = "Язык";
            dataGridView2.Columns[10].Name = "Возраст";
        }
        private void LoadDataToDataGridView(string table)
        // Попытка загрузки данных из указанной таблицы**
        {
            try
            {
                // Создание нового DataTable для хранения загруженных данных
                DataTable newDataTable = new DataTable();

                // Формирование SQL-запроса для получения данных из выбранной таблицы
                string query = $"SELECT * FROM {table}"; // Заменяет `{table}` на имя указанной таблицы

                // Назначение запроса SelectCommand адаптеру данных
                dataAdapter.SelectCommand = new NpgsqlCommand(query, connection); // Использует NpgsqlCommand для выполнения запроса

                // Заполнение DataTable данными из базы данных**
                dataAdapter.Fill(newDataTable); // Заполняет newDataTable данными из запроса

                // Перевод названий столбцов на русский язык
                newDataTable.Columns["id"].ColumnName = "ID";
                newDataTable.Columns["name"].ColumnName = "Название";
                newDataTable.Columns["cost"].ColumnName = "Цена";
                newDataTable.Columns["img"].ColumnName = "Изображение";
                newDataTable.Columns["author"].ColumnName = "Автор";
                newDataTable.Columns["pubhouse"].ColumnName = "Издательство";
                newDataTable.Columns["category"].ColumnName = "Категория";
                newDataTable.Columns["genre"].ColumnName = "Жанр";
                newDataTable.Columns["pubyear"].ColumnName = "Год издания";
                newDataTable.Columns["type"].ColumnName = "Тип обложки";
                newDataTable.Columns["lang"].ColumnName = "Язык";
                newDataTable.Columns["agelimit"].ColumnName = "Возраст";

                // Привязка DataTable к DataGridView для отображения данных
                dataGridView1.DataSource = newDataTable; // Отображает данные из newDataTable в DataGridView

            }
            catch (Exception ex)
            {
                // Обработка исключений при загрузке данных
                MessageBox.Show($"Ошибка: {ex.Message}"); // Отображает сообщение об ошибке пользователю
            }
        }


        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Обработка форматирования ячейки в DataGridView
            // Эта функция изменяет размер и отображает изображения в столбце "Изображение"

            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("Изображение") && e.RowIndex >= 0)
            {
                // Проверка столбца и строки
                //   - Проверяет, является ли текущий столбец столбцом "Изображение"
                //   - Проверяет, что строка не является заголовком (e.RowIndex >= 0)

                byte[] byteArray = e.Value as byte[];

                if (byteArray != null && byteArray.Length > 0)
                {
                    // Проверка наличия данных изображения
                    //   - Проверяет, содержит ли ячейка массив байтов (e.Value as byte[])
                    //   - Проверяет, что массив байтов не пустой (byteArray.Length > 0)

                    using (MemoryStream ms = new MemoryStream(byteArray))
                    {
                        // Создание объекта изображения из массива байтов
                        Image image = Image.FromStream(ms);

                        // Задаем целевую ширину и высоту изображения
                        int targetWidth = 75;
                        int targetHeight = 75;

                        // Масштабирование изображения
                        Image scaledImage = new Bitmap(image, targetWidth, targetHeight);

                        // Установка изображения и высоты строки
                        e.Value = scaledImage;
                        dataGridView1.Rows[e.RowIndex].Height = scaledImage.Height;
                    }
                }
            }
        }


        private void SearchButton_Click(object sender, EventArgs e)
        {
            // Обработка нажатия кнопки "Поиск"

            if (SearchTextBox.Text.Length != 0)
            {
                // Проверка наличия текста в поле поиска

                try
                {
                    // Попытка выполнить поиск

                    DataTable newDataTable = new DataTable();

                    // Формирование SQL-запроса для поиска
                    string query = $"SELECT * FROM books WHERE name ILIKE '%{SearchTextBox.Text}%';";

                    // Назначение запроса SelectCommand адаптеру данных
                    dataAdapter.SelectCommand = new NpgsqlCommand(query, connection);

                    // Заполнение DataTable данными из результата поиска
                    dataAdapter.Fill(newDataTable);

                    // Привязка DataTable к DataGridView для отображения результатов
                    dataGridView1.DataSource = newDataTable;
                }
                catch
                {
                    // **Обработка ошибок**
                    //   - Если при поиске возникла ошибка, загружаются все книги

                    LoadDataToDataGridView("Books");
                }
            }
            else
            {
                // Если поле поиска пустое, загружаются все книги
                LoadDataToDataGridView("Books");
            }
        }


        private void dataGridView1_SelectionChanged_1(object sender, EventArgs e)
        {
            // Обработчик события выбора строки в dataGridView1

            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Проверка выбора строки
                //   - Проверяет, выбрана ли хотя бы одна строка в dataGridView1

                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                object[] rowData = new object[11];
                int dataIndex = 0;

                for (int i = 0; i < selectedRow.Cells.Count; i++)
                {
                    // Копирование данных из выбранной строки, исключая изображение
                    //   - Перебирает все ячейки выбранной строки
                    //   - Пропускает ячейку с изображением (индекс 3, условное предположение)
                    //   - Копирует значение ячейки в массив rowData
                    //   - dataIndex - индекс для заполнения массива

                    if (i != 3)
                    {
                        rowData[dataIndex] = selectedRow.Cells[i].Value;
                        dataIndex++;
                    }
                }

                // Добавление скопированных данных в новую строку dataGridView2
                dataGridView2.Rows.Add(rowData);

                // Расчет стоимости (предполагается отдельная функция)
                CalculateCost();
            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            // Обработчик события выбора строки в dataGridView2

            if (dataGridView2.SelectedRows.Count > 0)
            {
                // **Проверка выбора строки**
                //   - Проверяет, выбрана ли хотя бы одна строка в dataGridView2

                DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];

                // **Проверка пустоты строки**
                //   - Перебирает все ячейки выбранной строки
                //   - Если хотя бы одна ячейка не пустая, строка считается непустой
                //   - isEmpty - флаг пустоты строки

                bool isEmpty = true;
                foreach (DataGridViewCell cell in selectedRow.Cells)
                {
                    if (cell.Value != null && !string.IsNullOrWhiteSpace(cell.Value.ToString()))
                    {
                        isEmpty = false;
                        break;
                    }
                }

                // Удаление непустой строки
                //   - Если строка не пустая, она удаляется из dataGridView2
                //   - Расчет стоимости (предполагается отдельная функция)

                if (!isEmpty)
                {
                    dataGridView2.Rows.RemoveAt(selectedRow.Index);
                    CalculateCost();
                }
            }
        }


        private void открытьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Обработчик нажатия пункта меню "Открыть" (Редактор)

            // Создаем новую форму редактирования (redactor)
            redactor redactorForm = new redactor(connectionProvider);

            // Скрываем текущую форму
            this.Hide();

            // Подписываемся на событие закрытия формы редактирования
            redactorForm.FormClosed += (s, args) => this.Close();
            //   - После закрытия формы редактирования закрываем текущую форму

            // Отображаем форму редактирования
            redactorForm.Show();
        }

        private void открытьВНовойВкладкеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Обработчик нажатия пункта меню "Открыть в новой вкладке" (Редактор)

            // Создаем новую форму редактирования (redactor)
            redactor redactorForm = new redactor(connectionProvider);

            // Просто отображаем форму редактирования (без скрытия текущей)
            redactorForm.Show();
        }

        private void открытьToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            // Обработчик нажатия пункта меню "Открыть" (Заказы)

            // Создаем новую форму управления заказами (orders)
            orders ordersForm = new orders(connectionProvider);

            // Скрываем текущую форму
            this.Hide();

            // Подписываемся на событие закрытия формы заказов
            ordersForm.FormClosed += (s, args) => this.Close();
            //   - После закрытия формы заказов закрываем текущую форму

            // Отображаем форму заказов
            ordersForm.Show();
        }

        private void открытьВНовойВкладкеToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            // Обработчик нажатия пункта меню "Открыть в новой вкладке" (Заказы)

            // Создаем новую форму управления заказами (orders)
            orders ordersForm = new orders(connectionProvider);

            // Просто отображаем форму заказов (без скрытия текущей)
            ordersForm.Show();
        }

        private void CalculateCost()
        {
            // Функция расчета общей стоимости

            double sum = 0.0; // Инициализация переменной для суммы

            // Итерация по строкам dataGridView2
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                // Проверка строки (не новая строка и ячейка с ценой не пустая)
                if (!row.IsNewRow && row.Cells[2].Value != null && double.TryParse(row.Cells[2].Value.ToString(), out double cellValue))
                {
                    // Пытаемся преобразовать значение ячейки в double
                    //   - Если преобразование успешно, добавляем значение к сумме

                    sum += cellValue;
                }
            }

            // Обновление переменной totalcost и отображение суммы
            totalcost = sum;
            label5.Text = totalcost.ToString();

            // Добавление единицы измерения (тенге) при ненулевой стоимости
            if (totalcost != 0)
            {
                label5.Text += " тенге";
            }
        }


        private void orderButton_Click(object sender, EventArgs e)
        {
            // Обработчик нажатия кнопки "Заказ"

            try
            {
                // Формирование SQL-запроса для добавления нового заказа

                string query =
                    "INSERT INTO orders (id, checklist, sum)" +
                    $"VALUES ('{GetLastOrder(connection)}', '{GetChecklist(connection)}', '{totalcost}')";

                NpgsqlCommand command = new NpgsqlCommand(query, connection);

                // Выполнение запроса и добавление нового заказа
                command.ExecuteNonQuery();

                // Отображение сообщения об успешном оформлении заказа
                MessageBox.Show("Заказ оформлен");


                // Подготовка текста для печати
                string result = GetDocument(connection); // Предполагается, что функция GetDocument() возвращает текст для печати

                // Создание объекта для печати
                PrintDocument printDocument = new PrintDocument();

                // Обработчик события печати
                printDocument.PrintPage += PrintPageHandler;

                // Отображение диалогового окна настройки печати
                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = printDocument; // Установка объекта печати для его настройки

                // Печать документа, если пользователь нажал "ОК"
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDialog.Document.Print();
                }
            }
            catch (Exception ex)
            {
                // Обработка исключений
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }


        private int GetLastOrder(NpgsqlConnection connection)
        {
            // Получение идентификатора последнего заказа

            // Формирование SQL-запроса для получения максимального значения id из таблицы orders
            string query = "SELECT MAX(id) FROM orders";
            NpgsqlCommand command = new NpgsqlCommand(query, connection);

            // Выполнение запроса и получение результата
            object result = command.ExecuteScalar();

            // Проверка результата (null или DBNull)
            if (result == null || result == DBNull.Value)
            {
                // Если нет записей в таблице, возвращаем 0
                return 0;
            }

            // Преобразование результата к int и добавление 1 для нового заказа
            int lastOrderId = Convert.ToInt32(result) + 1;
            return lastOrderId;
        }

        private string GetChecklist(NpgsqlConnection connection)
        {
            // Получение списка товаров из dataGridView2

            string checklist = "";

            // Итерация по строкам dataGridView2
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                // Проверка строки (не новая строка и ячейка с ID товара не пустая)
                if (!row.IsNewRow && row.Cells[0].Value != null)
                {
                    double cellValue;

                    // Пытаемся преобразовать значение ячейки в double (предполагается ID товара)
                    if (double.TryParse(row.Cells[0].Value.ToString(), out cellValue))
                    {
                        // Добавление значения ячейки (ID товара) в список checklist с запятой
                        checklist += cellValue.ToString() + ",";
                    }
                }
            }

            // Удаление последней запятой из checklist (если список не пустой)
            return checklist.TrimEnd(',');
        }


        void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            // Определяем величину отступа
            int marginLeft = 75; // Отступ в пикселях

            // Печать строки result с отступом
            e.Graphics.DrawString(result, new Font("Arial", 14), Brushes.Black, marginLeft, 0);
        }

        private string GetDocument(NpgsqlConnection connection)
        {
            // Функция формирования текста для печати

            string result = ""; // Инициализация переменной для результата (текста документа)
            int id = 0; // Переменная для хранения ID товара
            int index = 1; // Индекс для нумерации товаров в чеке

            // Получение списка ID товаров из checklist
            int[] array = StringToIntArray(GetChecklist(connection));

            // Заголовок чека (номер и дата заказа)
            result += $"\n\n\t\t\tЗаказ №{GetOrderId(connection)}\n";  // Предполагается функция GetOrderId() для получения номера заказа
            result += $"\t\t\t{GetOrderTime(connection)}\n\n";          // Предполагается функция GetOrderTime() для получения времени заказа

            // Перебор списка ID товаров и формирование информации для чека
            for (int i = 0; i < array.Length; i++)
            {
                id = array[i];

                // Получение названия и цены товара по ID
                result += $"{index++}) {GetNameOfBook(connection, id)}\n\t+ {GetCostOfBook(connection, id)} тенге\n";
                // Предполагаются функции GetNameOfBook() и GetCostOfBook() для получения названия и цены товара по ID
            }

            // Итог чека (сумма заказа)
            result += $"\n\n\tЧек на сумму {totalcost}";

            return result;
        }

        public static int[] StringToIntArray(string input)
        {
            // Функция преобразования строки в массив целых чисел

            string[] parts = input.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries); // Разделение строки по запятым и пробелам
            int[] array = new int[parts.Length]; // Создание массива для чисел

            for (int i = 0; i < parts.Length; i++)
            {
                array[i] = int.Parse(  // Преобразование каждой части строки в int
                    parts[i]);
            }

            return array;
        }

        private static string GetNameOfBook(NpgsqlConnection connection, int id)
        {
            // Функция получения названия книги по ID

            string query = $"SELECT name FROM public.books WHERE id = {id}"; // SQL-запрос для получения названия книги по ID
            NpgsqlCommand command = new NpgsqlCommand(query, connection); // Создание команды для выполнения запроса

            object result = command.ExecuteScalar(); // Выполнение запроса и получение результата

            if (result != null)
            {
                string name = result.ToString();
                return name;
            }
            else
            {
                return "Книга не найдена."; // Возвращение сообщения об ошибке, если книга не найдена
            }
        }

        private static string GetCostOfBook(NpgsqlConnection connection, int id)
        {
            // Функция получения цены книги по ID

            string query = $"SELECT cost FROM public.books WHERE id = {id}"; // SQL-запрос для получения цены книги по ID
            NpgsqlCommand command = new NpgsqlCommand(query, connection); // Создание команды для выполнения запроса

            object result = command.ExecuteScalar(); // Выполнение запроса и получение результата

            if (result != null)
            {
                string cost = result.ToString();
                return cost;
            }
            else
            {
                return "Книга не найдена."; // Возвращение сообщения об ошибке, если книга не найдена
            }
        }

        private static int GetOrderId(NpgsqlConnection connection)
        {
            // Функция получения последнего ID заказа

            string query = $"SELECT MAX(id) FROM orders"; // SQL-запрос для получения максимального значения id из таблицы orders
            NpgsqlCommand command = new NpgsqlCommand(query, connection); // Создание команды для выполнения запроса

            object result = command.ExecuteScalar(); // Выполнение запроса и получение результата

            int lastId = (int)result; // Приведение результата к int (ожидается целочисленное значение)
            return lastId;
        }

        private static string GetOrderTime(NpgsqlConnection connection)
        {
            // Функция получения времени последнего заказа

            string query = $"SELECT time FROM orders ORDER BY time DESC LIMIT 1"; // SQL-запрос для получения самого последнего времени заказа
            NpgsqlCommand command = new NpgsqlCommand(query, connection); // Создание команды для выполнения запроса

            object result = command.ExecuteScalar(); // Выполнение запроса и получение результата

            string lastTimestampString = result.ToString(); // Преобразование результата в строку (ожидается временная метка)
            return lastTimestampString;
        }

        private void refresh_button_Click(object sender, EventArgs e)
        {
            // Обработчик нажатия кнопки "Обновить"

            LoadDataToDataGridView("Books"); // Предполагается, что функция LoadDataToDataGridView() загружает данные в dataGridView2 из таблицы "Books"
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            // Обработчик нажатия кнопки "Удалить"

            dataGridView2.Rows.Clear(); // Очистка всех строк из dataGridView2 
        }

    }
}