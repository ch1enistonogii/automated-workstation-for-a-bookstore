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
    public partial class login : Form, IConnectionProvider
    {
        private NpgsqlConnection connection; // Переменная для хранения подключения к базе данных Npgsql

        public login()
        {
            InitializeComponent(); // Инициализация компонентов формы авторизации
            LoadConfig(); // Загрузка конфигурации подключения из файла
        }

        private void login_Load(object sender, EventArgs e)
        {
            Image backgroundImage = Image.FromFile("ico\\background.jpg");
            this.BackgroundImage = backgroundImage;
        }

        public NpgsqlConnection GetConnection() => connection; // Реализация метода интерфейса IConnectionProvider для получения существующего подключения

        private void OpenMenu()
        {
            // **Открытие формы кассы**

            cashbox cashboxForm = new cashbox(this); // Создание экземпляра формы кассы, передавая ссылку на текущий объект login
            this.Hide(); // Скрыть форму авторизации
            cashboxForm.FormClosed += (s, args) => this.Close(); // Подписаться на событие закрытия формы кассы, чтобы закрыть форму авторизации при закрытии кассы
            cashboxForm.Show(); // Отобразить форму кассы
        }

        private NpgsqlConnection CreateConnection()
        {
            // **Функция создания подключения к базе данных**

            try
            {
                string configFilePath = "cfg\\config.txt"; // Путь к файлу конфигурации
                string[] lines = File.ReadAllLines(configFilePath); // Чтение строк из файла конфигурации
                string connectionString = $"Server={textBoxIP.Text};Port={textBoxPort.Text};Database={textBoxDatabase.Text};User Id={textBoxUser.Text};Password={textBoxPassword.Text}"; // Формирование строки подключения на основе данных из формы
                return new NpgsqlConnection(connectionString); // Создание подключения к базе данных
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании подключения из файла: {ex.Message}"); // Отображение сообщения об ошибке
                return null; // Вернуть null в случае ошибки
            }
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoadConfig()
        {
            // **Функция загрузки конфигурации из файла**

            string configFilePath = "cfg\\config.txt"; // Путь к файлу конфигурации

            if (File.Exists(configFilePath) && File.ReadAllLines(configFilePath).Length > 0) // Проверка существования и непустоты файла
            {
                try
                {
                    string[] lines = File.ReadAllLines(configFilePath); // Чтение строк из файла
                    textBoxIP.Text = lines[0]; // Загрузка данных в textBoxIP
                    textBoxPort.Text = lines[1]; // Загрузка данных в textBoxPort
                    textBoxDatabase.Text = lines[2]; // Загрузка данных в textBoxDatabase
                    textBoxUser.Text = lines[3]; // Загрузка данных в textBoxUser
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при чтении данных из файла: {ex.Message}"); // Отображение сообщения об ошибке
                }
            }
        }

        private void SaveConfigData()
        {
            // **Функция сохранения конфигурации в файл**

            string configFilePath = "cfg\\config.txt"; // Путь к файлу конфигурации

            try
            {
                File.WriteAllText(configFilePath, $"{textBoxIP.Text}\n{textBoxPort.Text}\n{textBoxDatabase.Text}\n{textBoxUser.Text}"); // Запись данных в файл
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных в файле конфигурации: {ex.Message}"); // Отображение сообщения об ошибке
            }
        }

        private void CheckConnectionButton_Click(object sender, EventArgs e)
        {
            // **Обработчик нажатия кнопки "Проверка подключения"**

            connection = CreateConnection(); // Создание подключения к базе данных
            try
            {
                if (connection.State != ConnectionState.Open) // Проверка открытия подключения
                {
                    connection.Open(); // Открытие подключения
                }

                if (connection.State == ConnectionState.Open) // Проверка успешного открытия
                {
                    SaveConfigData(); // Сохранение конфигурации
                    MessageBox.Show("Подключение установлено!"); // Отображение сообщения об успехе
                    OpenMenu(); // Открытие формы кассы
                }
                else
                {
                    MessageBox.Show("Не удалось установить подключение к базе данных."); // Отображение сообщения об ошибке
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}"); // Отображение сообщения об ошибке
            }
            finally
            {
                if (connection.State == ConnectionState.Open) // Закрытие подключения в любом случае
                {
                    connection.Close();
                }
            }
        }
    }
}
