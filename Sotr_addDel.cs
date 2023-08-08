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

namespace Diplom1
{
    public partial class Sotr_addDel : Form
    {
        public Sotr_addDel()
        {
            InitializeComponent();
        }


        MySqlConnection conndb = ConnDB.connection;

        public void add_Sotrudnik()
        {

            //Проверка на пустоту
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Введите все данные");
            }
            else
            {
                conndb.Open();
                {
                    try
                    {
                        string id = textBox1.Text;
                        string fio = textBox2.Text;
                        string post = textBox3.Text;
                        string login = textBox4.Text;
                        string password = textBox5.Text;
                        string status = textBox7.Text;
                        string update = $"INSERT INTO sotrudniki (ID, fio, post, login, password, status)" +
                        $" VALUES ('{id}','{fio}', '{post}','{login}', '{password}', '{status}')";
                        MySqlCommand command = new MySqlCommand(update, conndb);
                        command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{ex}");
                    }
                    finally
                    {
                        MessageBox.Show("Сотрудник успешно добавлен");
                        conndb.Close();
                    }
                }
            }
        }

        public void del_Sotrudnik()
        {
            //Проверка на пустоту
            if (textBox6.Text == "")
            {
                MessageBox.Show("Введите данные");
            }
            else
            {
                conndb.Open();
                {
                    try
                    {
                        string id = textBox6.Text;
                        string update = $"DELETE FROM sotrudniki WHERE ID = '{id}'";
                        MySqlCommand command = new MySqlCommand(update, conndb);
                        command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{ex}");
                    }
                    finally
                    {
                        MessageBox.Show("Сотрудник успешно удалён");
                        conndb.Close();
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Введите все данные");
            }
            else
            {
                conndb.Open();
                {
                    try
                    {
                        string id = textBox1.Text;
                        string fio = textBox2.Text;
                        string post = textBox3.Text;
                        string login = textBox4.Text;
                        string password = textBox5.Text;
                        string status = textBox7.Text;
                        string update = $"INSERT INTO sotrudniki (ID, fio, post, login, password, status)" +
                        $" VALUES ('{id}','{fio}', '{post}','{login}', '{password}', '{status}')";
                        MySqlCommand command = new MySqlCommand(update, conndb);
                        command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{ex}");
                    }
                    finally
                    {
                        MessageBox.Show("Сотрудник успешно добавлен");
                        conndb.Close();
                    }
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            del_Sotrudnik();
        }

        private void Sotr_addDel_Load(object sender, EventArgs e)
        {

        }
    }
}
