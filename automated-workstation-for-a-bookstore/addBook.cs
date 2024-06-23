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
using System.Xml.Linq;

namespace automated_workstation_for_a_bookstore
{
    public partial class addBook : Form
    {
        bool preview_active = false; // Флаг активности режима предпросмотра изображения (по умолчанию выключен)

        private string book_img = "ico\\jpg.png"; // Путь к изображению

        private string[] genres = new string[0]; // Пустой массив жанров для жанров

        private readonly IConnectionProvider connectionProvider; // Провайдер подключения к базе данных
        private NpgsqlConnection connection; // Подключение к базе данных Npgsql


        public addBook(IConnectionProvider connectionProvider)
        {
            InitializeComponent(); // Инициализация компонентов формы
            this.connectionProvider = connectionProvider; // Получение провайдера подключения
            connection = connectionProvider.GetConnection(); // Получение подключения к базе данных

            if (connection.State != ConnectionState.Open) // Проверка открытия подключения
            {
                connection.Open(); // Открытие подключения, если оно закрыто
            }
        }

        private void addBook_Load(object sender, EventArgs e)
        {
            BookID_textBox.Text = GetLastBookId(connection).ToString(); // Установить ID последней книги
            Image backgroundImage = Image.FromFile("ico\\background.jpg"); // Путь до изображения (фон)
            openFileDialog_button.ImageLocation = "ico\\path.png"; // Путь до изображения (кнопка "Путь до файла")
            hidePreview_button.ImageLocation = "ico\\deletebutton.png"; // Путь до изображения (кнопка "Скрыть предпросмотр")
            this.BackgroundImage = backgroundImage;


            // Создание столбца для изображения
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn.Name = "ImageColumn"; // Имя столбца - "ImageColumn"
            imageColumn.HeaderText = "Изображение"; // Заголовок столбца - "Изображение"
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Режим отображения изображения - масштабирование


            // Добавление столбца изображения в dataGridView
            dataGridView1.Columns.Add(imageColumn);

            // Создание остальных столбцов
            dataGridView1.ColumnCount = 12;
            dataGridView1.Columns[1].Name = "id";
            dataGridView1.Columns[2].Name = "name";
            dataGridView1.Columns[3].Name = "cost";
            dataGridView1.Columns[4].Name = "author";
            dataGridView1.Columns[5].Name = "pubhouse";
            dataGridView1.Columns[6].Name = "category";
            dataGridView1.Columns[7].Name = "genre";
            dataGridView1.Columns[8].Name = "pubyear";
            dataGridView1.Columns[9].Name = "type";
            dataGridView1.Columns[10].Name = "lang";
            dataGridView1.Columns[11].Name = "agelimit";
        }


        private void BookIDchecbox_CheckedChanged(object sender, EventArgs e)
        {
            // Обработчик изменения состояния флажка "ID книги"

            if (BookID_checkBox.Checked) // Если флажок установлен
            {
                BookID_textBox.Enabled = true; // Разблокировать поле ввода ID книги
            }
            else // Если флажок не установлен
            {
                BookID_textBox.Enabled = false; // Заблокировать поле ввода ID книги
            }
        }

        private static int GetLastBookId(NpgsqlConnection connection)
        {
            // Функция получения последнего ID книги

            string query = "SELECT MAX(id) FROM books"; // SQL-запрос для получения максимального ID книги
            NpgsqlCommand command = new NpgsqlCommand(query, connection); // Создание команды NpgsqlCommand

            object result = command.ExecuteScalar(); // Выполнение запроса и получение результата

            if (result == null || result == DBNull.Value) // Проверка результата
            {
                return 0; // Если результат пустой или null, вернуть 0
            }
            else
            {
                int lastOrderId = Convert.ToInt32(result) + 1; // Преобразует результат в int и добавить 1
                return lastOrderId; // Вернуть последний ID книги
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Обработчик изменения выбранного элемента в комбобоксе "Категория книги"

            BookGenre_comboBox.Items.Clear(); // Очистить список жанров

            switch (BookCategory_comboBox.Text) // В зависимости от выбранной категории
            {
                case "Художественная литература":
                    BookGenre_comboBox.Items.AddRange(new string[] { "Фэнтези", "Роман", "Детективы", "Фантастика", "Поэзия", "Приключения", "Ужасы", "Триллеры", "Проза" });
                    break;
                case "Психологическая литература":
                    BookGenre_comboBox.Items.AddRange(new string[] { "Популярная психология", "Психология практическая", "Философия", "Психологический триллер", "Психологические ужасы", "Психологическая драма", "Психологическая научная фантастика" });
                    break;
                case "Детская литература":
                    BookGenre_comboBox.Items.AddRange(new string[] { "Головоломки и кроссворды", "Творчество", "Книжка-игрушка", "Развивающая литература", "Детская литература" });
                    break;
                case "Учебники и пособия":
                    BookGenre_comboBox.Items.AddRange(new string[] { "Школьная литература", "Изучение языка", "Учебники для студентов", "Математика", "Логопедия", "Мифология", "Электроника", "Биолония", "Астрономия", "География", "История", "Политология", "Химия", "Энциклопедия" });
                    break;
                case "Эзотерика":
                    BookGenre_comboBox.Items.AddRange(new string[] { "Астрология", "Гадание", "Духовно-мистические учения", "Йога", "Магия и колдовство" });
                    break;
                case "Комиксы и графическая литература":
                    BookGenre_comboBox.Items.AddRange(new string[] { "Комикс", "Манга", "Манхва", "Маньхуа", "Ранобэ", "Артбуки" });
                    break;
                case "Искусство и культура":
                    BookGenre_comboBox.Items.AddRange(new string[] { "Дизайн", "Живопись", "Кино", "Музыка", "Театр", "Музеи", "Архитектура" });
                    break;
                case "Дом, досуг, хобби":
                    BookGenre_comboBox.Items.AddRange(new string[] { "Рукоделие", "Садоводство", "Дизайн", "Автолитература", "Домоводство", "Красота", "Кулинария", "Ремонт и строительство", "Спорт", "Мода и стиль" });
                    break;
            }
        }

        private void preview_button_Click(object sender, EventArgs e)
        {
            // Обработчик нажатия кнопки "Предпросмотр"

            ActiveForm.Height = 417; // Изменить высоту главной формы (для отображения панели предпросмотра)
            groupBox2.Visible = true; // Сделать панель предпросмотра видимой
            hidePreview_button.Visible = true; // Сделать кнопку скрытия предпросмотра видимой

            PopulateDataGrid(); // Заполнить таблицу данными из формы
        }

        private void PopulateDataGrid()
        {
            // Функция заполнения таблицы данными

            dataGridView1.Rows.Clear(); // Очистить таблицу

            Image image = Image.FromFile(book_img); // Загрузить изображение книги из поля book_img

            // Заполнение строки таблицы данными о книге
            dataGridView1.Rows.Add(image, BookID_textBox.Text, BookName_textBox.Text, BookCost_textBox.Text, BookAuthor_textBox.Text, BookPubhouse_textBox.Text,
                BookCategory_comboBox.Text, BookGenre_comboBox.Text, BookPubyear_textBox.Text, BookType_comboBox.Text, BookLang_comboBox.Text, BookAgelimit_comboBox.Text);
        }

        private void openFileDialog_button_Click_1(object sender, EventArgs e)
        {
            // Обработчик нажатия кнопки 

            var filePath = string.Empty; // Пустая строка для хранения пути к файлу

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\"; // Исходная директория
                openFileDialog.Filter = "jpeg files (*.jpg)|*.jpg|All files (*.*)|*.*"; // Фильтр файлов (отображает только JPEG и все файлы)
                openFileDialog.FilterIndex = 2; // Выбранный по умолчанию фильтр (второй - JPEG)
                openFileDialog.RestoreDirectory = true; // Восстанавливает исходную директорию после выбора файла

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Получение выбранного файла

                    filePath = openFileDialog.FileName; // Путь к выбранному файлу
                }
            }

            book_img = filePath; // Сохранить путь к выбранному файлу изображения
            ImgPath_textBox.Text = filePath; // Отобразить путь к выбранному файлу в текстовом поле
        }


        private void addbook_button_Click(object sender, EventArgs e)
        {
            // Обработчик нажатия кнопки "Добавить книгу"

            try // Блок обработки исключений
            {
                // Формирование SQL-запроса для добавления книги в базу данных

                string query =
                    "INSERT INTO books (id, name, cost, img, quantity, author, pubhouse, category, genre, pubyear, type, lang, agelimit)" +
                    $"VALUES ({BookID_textBox.Text}, '{BookName_textBox.Text}', '{BookCost_textBox.Text}', pg_read_binary_file('{book_img}')::bytea,{quantity_textBox.Text} ,'{BookAuthor_textBox.Text}', '{BookPubhouse_textBox.Text}', '{BookCategory_comboBox.Text}', '{BookGenre_comboBox.Text}', '{BookPubyear_textBox.Text}', '{BookType_comboBox.Text}', '{BookLang_comboBox.Text}', '{BookAgelimit_comboBox.Text}')";

                // Создание команды NpgsqlCommand для выполнения запроса

                NpgsqlCommand command = new NpgsqlCommand(query, connection);

                // Выполнение запроса

                command.ExecuteNonQuery();

                // Сообщение об успешном добавлении книги

                MessageBox.Show("Книга успешно добавлена!");
            }
            catch (Exception ex) // Обработка исключений
            {
                // Сообщение об ошибке добавления книги

                MessageBox.Show($"Ошибка при добавлении данных: {ex.Message}\n\n" +
                                "Проверьте заполненные данные, они должны соответвовать названиям колонок а также не быть пустыми");
            }
        }

        private void hidePreview_button_Click(object sender, EventArgs e)
        {
            // Обработчик нажатия кнопки "Скрыть предпросмотр"

            ActiveForm.Height = 232; // Изменяет высоту главной формы (свернуть панель предпросмотра)
            groupBox2.Visible = false; // Скрывает панель предпросмотра
            hidePreview_button.Visible = false; // Скрывает кнопку "Скрыть предпросмотр"
        }
    }
}