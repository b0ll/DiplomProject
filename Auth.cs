using MySql.Data.MySqlClient;
using SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Diplom1
{
    public partial class Auth : Form
    {

        string connStr = "server=109.191.87.56;port=33333;user=DanilaKazakov;database=kazakoovdd;password=dan12345";
        MySqlConnection conndb = ConnDB.connection;
        static string sha256(string randomString)
        {
            //Тут происходит криптографическая магия. Смысл данного метода заключается в том, что строка залетает в метод
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }
        public Auth()
        {
            InitializeComponent();
        }
        public int Connection(string login, string password)
        {
            int a = 0;
            try
            {
                conndb.Open();
                //Выбор всех данных из таблицы sotrudniki и их фильтрование по подходящим логину и паролю
                string commandStr = $"SELECT count(*) FROM sotrudniki WHERE login = '{login}' AND password = '{password}'";
                MySqlCommand comm1 = new MySqlCommand(commandStr, conndb);
                int k = Convert.ToInt32(comm1.ExecuteScalar());
                if (k != 0)
                {
                    //Выбор столбца s_status в зависимости от логина и пароля
                    string commandStr2 = $"SELECT status FROM sotrudniki WHERE login = '{login}' AND password = '{password}'";
                    MySqlCommand comm2 = new MySqlCommand(commandStr2, conndb);
                    a = Convert.ToInt32(comm2.ExecuteScalar());
                }
            }
            //Обработка исключений
            catch
            {

            }
            //Закрытие соединения
            conndb.Close();
            return a;
        }

        private void Authorization_Load(object sender, EventArgs e)
        {
            conndb = new MySqlConnection(connStr);
        }
        public void Uroven()
        {
            //Если возвращаемое значение a равняется 1(уровень доступа, то есть столбец status в БД), открывается форма меню администратора,
            //если 2, то форма меню сотрудника
            if (Connection(textBox1.Text, textBox2.Text) == 1)
            {
                MessageBox.Show("Вы авторизированы как администратор");
                //Скрытие данной формы и запуск следующей в зависимости от введёных данных
                AdmMenu am = new AdmMenu();
                this.Hide();
                am.ShowDialog();
            }
            else if (Connection(textBox1.Text, textBox2.Text) == 2)
            {
                MessageBox.Show("Вы авторизированы как сотрудник");
                SotrMenu sm = new SotrMenu();
                this.Hide();
                sm.ShowDialog();

            }
            else
            {
                MessageBox.Show("Неверные данные");
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Uroven();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void Auth_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Tech thc = new Tech();
            thc.ShowDialog();
        }
    }
}
