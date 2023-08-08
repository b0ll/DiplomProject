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
    public partial class Sotr_List : Form
    {
        public Sotr_List()
        {
            InitializeComponent();
        }

        private DataTable table = new DataTable();

        public void GetSotrList()
        {
            using (MySqlConnection conndb = ConnDB.connection)
            {
                conndb.Open();
                BindingSource bSource = new BindingSource();
                new MySqlDataAdapter(new MySqlCommand($"SELECT ID AS ID, fio AS 'ФИО', post AS 'Должность', login AS 'Логин', password AS 'Пароль', status AS 'Статус' FROM sotrudniki ", conndb)
                    ).Fill(table);

                dataGridView1.DataSource = bSource.DataSource = table;
                conndb.Close();




                dataGridView1.Columns[0].Visible = true;
                dataGridView1.Columns[1].Visible = true;
                dataGridView1.Columns[2].Visible = true;
                dataGridView1.Columns[3].Visible = true;
                dataGridView1.Columns[4].Visible = true;
                dataGridView1.Columns[5].Visible = true;

                dataGridView1.Columns[0].ReadOnly = true;
                dataGridView1.Columns[1].ReadOnly = true;
                dataGridView1.Columns[2].ReadOnly = true;
                dataGridView1.Columns[3].ReadOnly = true;
                dataGridView1.Columns[4].ReadOnly = true;
                dataGridView1.Columns[5].ReadOnly = true;

                dataGridView1.RowHeadersVisible = false;
                dataGridView1.ColumnHeadersVisible = true;

                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;



                int count_rows = dataGridView1.RowCount;
                toolStripLabel2.Text = (count_rows).ToString();
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            table.Clear();
            GetSotrList();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {

        }
    }
}
