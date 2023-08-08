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
    public partial class MyMessages : Form
    {
        public MyMessages()
        {
            InitializeComponent();
            GetMessagesList();
        }


        private DataTable table = new DataTable();

        public void GetMessagesList()
        {
            using (MySqlConnection conndb = ConnDB.connection)
            {
                conndb.Open();
                BindingSource bSource = new BindingSource();
                new MySqlDataAdapter(new MySqlCommand($"SELECT ID AS ID, fromm AS 'От кого', too AS 'Кому', text AS 'Текст', data AS 'Дата', category AS 'Категория' FROM messages ", conndb)
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
                toolStripLabel2.Text = (count_rows - 1).ToString();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            table.Clear();
            GetMessagesList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
