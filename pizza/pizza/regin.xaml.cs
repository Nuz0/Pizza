using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pizza
{
    /// <summary>
    /// Логика взаимодействия для regin.xaml
    /// </summary>
    public partial class regin : Page
    {
        private Reg reg;

        public regin(Reg reg)
        {
            InitializeComponent();
            this.reg = reg;
        }


        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            reg.OpenPage(Reg.pages.login);
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            if (textBox_login.Text.Length > 0)
            {
                if (password.Password.Length > 0)
                {
                    if (password_Copy.Password.Length > 0)
                    {
                    }
                    else MessageBox.Show("Повторите пароль!");
                }
                else MessageBox.Show("Укажите пароль");
            }
            else MessageBox.Show("Укажите логин");

            if (password.Password.Length >= 6)
            {
                bool en = true;
                bool number = false;

                for (int i = 0; i < password.Password.Length; i++)
                {
                    if (password.Password[i] >= 'А' && password.Password[i] <= 'Я') en = false;
                    if (password.Password[i] >= '0' && password.Password[i] <= '9') number = true;


                    if (!en)
                        MessageBox.Show("Доступна только английская раскладка");
                    else if (!number)
                        MessageBox.Show("Добавьте хотя бы 1 цифру");
                    if (en && number)
                    {

                    }
                    else MessageBox.Show("пароль слишком короткий, минимум 6 символов");
                }

            }
            if (password.Password == password_Copy.Password)
            {
                MessageBox.Show("Пользователь зарегестрирован");
            }
            else MessageBox.Show("Пароли не совпадают");
            //
            //
            //
            //
            Select("INSERT INTO [dbo].[users] VALUES ('Nai', 'test3' , 'test2')");
            
        }
        public DataTable Select(string selectSQL) // функция подключения к базе данных и обработка запросов
        {
            DataTable dataTable = new DataTable("dataBase");                // создаём таблицу в приложении
                                                                            // подключаемся к базе данных
            SqlConnection sqlConnection = new SqlConnection("server=DESKTOP-HD8TQOV;Trusted_Connection=Yes;DataBase=Pizza;");
            sqlConnection.Open();                                           // открываем базу данных
            SqlCommand sqlCommand = sqlConnection.CreateCommand();          // создаём команду
            sqlCommand.CommandText = selectSQL;                             // присваиваем команде текст
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand); // создаём обработчик
            sqlDataAdapter.Fill(dataTable);                                 // возращаем таблицу с результатом
            return dataTable;

        }
    }
}
