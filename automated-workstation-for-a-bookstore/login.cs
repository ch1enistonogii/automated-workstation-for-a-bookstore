using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace automated_workstation_for_a_bookstore
{
    public partial class login : Form
    {
        NpgsqlConnection connection = new NpgsqlConnection();
        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void OpenMenu()
        //  Закрытие текущей формы и открытие новой
        {
            menu menuForm = new menu(connection);
            this.Hide();
            menuForm.FormClosed += (s, args) => this.Close();
            menuForm.Show();
        }

        private NpgsqlConnection CreateConnection()
        // Функция создает подключение к базе данных
        {
            try
            {
                string configFilePath = "config.txt";
                string[] lines = File.ReadAllLines(configFilePath);
                string connectionString = $"Server={textBoxIP.Text};Port={textBoxPort.Text};Database={textBoxDatabase.Text};User Id={textBoxUser.Text};Password={textBoxPassword.Text}";
                return new NpgsqlConnection(connectionString);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании подключения из файла: {ex.Message}");
                return null;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoadConfig()
        //  Функция загружает данные прердыдущего успешного подключения из config.txt, и использует их при подключении
        {
            string configFilePath = "config.txt";

            if (File.Exists(configFilePath) && File.ReadAllLines(configFilePath).Length > 0)
            {
                try
                {
                    string[] lines = File.ReadAllLines(configFilePath);
                    textBoxIP.Text = lines[0];
                    textBoxPort.Text = lines[1];
                    textBoxDatabase.Text = lines[2];
                    textBoxUser.Text = lines[3];
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при чтении данных из файла: {ex.Message}");
                }
            }
        }

        private void SaveConfigData()
        //  Функция обновляет данные дял подключение в файле config.txt
        {
            string configFilePath = "config.txt";

            try
            {
                File.WriteAllText(configFilePath, $"{textBoxIP.Text}\n{textBoxPort.Text}\n{textBoxDatabase.Text}\n{textBoxUser.Text}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных в файле конфигурации: {ex.Message}");
            }
        }

        private void CheckConnectionButton_Click(object sender, EventArgs e)
        //  Кнопка создает подключение, после чего открывает его и выводит статус
        {
            {
                connection = CreateConnection();
                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    if (connection.State == ConnectionState.Open)
                    {
                        SaveConfigData();
                        MessageBox.Show("Подключение установлено!");
                    }
                    else
                    {
                        MessageBox.Show("Не удалось установить подключение к базе данных.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}");
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                        OpenMenu();
                    }
                }
            }
        }
    }
}
