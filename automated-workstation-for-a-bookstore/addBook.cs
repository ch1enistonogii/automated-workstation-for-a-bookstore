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
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace automated_workstation_for_a_bookstore
{
    public partial class addBook : Form
    {
        bool preview_active = false;
        private string book_img = "ico\\jpg.png";
        private string[] genres = new string[0];
        private readonly IConnectionProvider connectionProvider;
        NpgsqlConnection connection;


        public addBook(IConnectionProvider connectionProvider)
        {
            InitializeComponent();
            this.connectionProvider = connectionProvider;
            connection = connectionProvider.GetConnection();
        }

        private void addBook_Load(object sender, EventArgs e)
        {
            connection.Open();
            BookID_textBox.Text = GetLastBookId(connection).ToString();

            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn.Name = "ImageColumn"; // Имя столбца
            imageColumn.HeaderText = "Изображение"; // Заголовок столбца
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Режим отображения изображения

            //
            Image deletebutton = Image.FromFile("ico\\deletebutton.png");
            hidePreview_button.Image = deletebutton;

            //
            Image pathbutton = Image.FromFile("ico\\path.png");
            openFileDialog_button.Image = pathbutton;



            // Добавить столбец в DataGridView
            dataGridView1.Columns.Add(imageColumn);

            // Создаем столбцы для DataGridView
            dataGridView1.ColumnCount = 12;
            dataGridView1.Columns[1].Name = "book_id";
            dataGridView1.Columns[2].Name = "book_name";
            dataGridView1.Columns[3].Name = "book_cost";
            dataGridView1.Columns[4].Name = "book_author";
            dataGridView1.Columns[5].Name = "book_pubhouse";
            dataGridView1.Columns[6].Name = "book_category";
            dataGridView1.Columns[7].Name = "book_genre";
            dataGridView1.Columns[8].Name = "book_pubyear";
            dataGridView1.Columns[9].Name = "book_type";
            dataGridView1.Columns[10].Name = "book_lang";
            dataGridView1.Columns[11].Name = "book_agelimit";
        }

        private void BookIDchecbox_CheckedChanged(object sender, EventArgs e)
        {
            if (BookID_checkBox.Checked)
            {
                BookID_textBox.Enabled = true;
            }
            else
            {
                BookID_textBox.Enabled = false;
            }
        }

        public static int GetLastBookId(NpgsqlConnection connection)
        {
            string query = "SELECT MAX(book_id) FROM books";
            NpgsqlCommand command = new NpgsqlCommand(query, connection);

            object result = command.ExecuteScalar();

            if (result == null || result == DBNull.Value)
            {
                return 0;
            }
            int lastOrderId = Convert.ToInt32(result) + 1;
            return lastOrderId;
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BookGenre_comboBox.Items.Clear();
            switch (BookCategory_comboBox.Text)
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

            ActiveForm.Height = 417;
            groupBox2.Visible = true;
            hidePreview_button.Visible = true;

            PopulateDataGrid();
        }

        private void PopulateDataGrid()
        {
            dataGridView1.Rows.Clear();
            Image image = Image.FromFile(book_img);
            // Заполняем DataGridView данными о книгах
            dataGridView1.Rows.Add(image, BookID_textBox.Text, BookName_textBox.Text, BookCost_textBox.Text, BookAuthor_textBox.Text, BookAuthor_textBox.Text,
            BookCategory_comboBox.Text, BookGenre_comboBox.Text, BookPubyear_textBox.Text, BookType_comboBox.Text, BookLang_comboBox.Text, BookAgelimit_comboBox.Text);
        }

        private void openFileDialog_button_Click_1(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "jpeg files (*.jpg)|*.jpg|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }
            book_img = filePath;
        }

        private void addbook_button_Click(object sender, EventArgs e)
        {
            try
            {
                string query =
                "INSERT INTO books (book_id, book_name, book_cost, book_img, book_author, book_pubhouse, book_category, book_genre, book_pubyear, book_type, book_lang, book_agelimit)" +
                $"VALUES ({BookID_textBox.Text}, '{BookName_textBox.Text}', '{BookCost_textBox.Text}', pg_read_binary_file('{book_img}')::bytea, '{BookAuthor_textBox.Text}', '{BookPubhouse_textBox.Text}', '{BookCategory_comboBox.Text}', '{BookGenre_comboBox.Text}', '{BookPubyear_textBox.Text}', '{BookType_comboBox.Text}', '{BookLang_comboBox.Text}', '{BookAgelimit_comboBox.Text}')";

                NpgsqlCommand command = new NpgsqlCommand(query, connection);

                // Выполнение запроса
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Ошибка при добавлении заказа
                MessageBox.Show($"Ошибка при добавлении данных: {ex.Message}");
            }
        }

        private void hidePreview_button_Click(object sender, EventArgs e)
        {
            ActiveForm.Height = 232;
            groupBox2.Visible = false;
            hidePreview_button.Visible = false;
        }
    }
}
