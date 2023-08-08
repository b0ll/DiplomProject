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
    public partial class Message : Form
    {
        public Message()
        {
            InitializeComponent();
        }

        MySqlConnection conndb = ConnDB.connection;

        private void button1_Click(object sender, EventArgs e)
        {


            if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Введите все данные");
            }
            else
            {
                conndb.Open();
                {
                    try
                    {
                        string fromm = textBox1.Text;
                        string too = textBox2.Text;
                        string text = textBox3.Text;
                        string category = textBox4.Text;
                        string time = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                        string update = $"INSERT INTO messages (fromm, too, text, category, data)" +
                        $" VALUES ('{fromm}','{too}', '{text}', '{category}', '{time}')";
                        MySqlCommand command = new MySqlCommand(update, conndb);
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{ex}");
                    }
                    finally
                    {
                        MessageBox.Show("Сообщение успешно отправлено");
                        conndb.Close();
                    }
                }
            }
        }

        private void Message_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        //MySqlCommand fromm = new MySqlCommand("SELECT fromm from sotrudniki WHERE fromm =@fromm", conndb);
        //fromm.Parameters.AddWithValue("@fromm", int.Parse(textBox1.Text));
        //MySqlDataReader da = fromm.ExecuteReader();
    }
}
