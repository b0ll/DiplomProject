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
    public partial class SotrMenu : Form
    {
        public SotrMenu()
        {
            InitializeComponent();
        }


        private void SotrMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Auth au = new Auth();
            this.Close();
            au.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Message ms = new Message();
            ms.ShowDialog();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            MyMessages mm = new MyMessages();
            mm.ShowDialog();
        }
    }
}
