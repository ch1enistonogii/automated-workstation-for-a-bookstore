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
    public partial class addBook : Form
    {
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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
    }
}
