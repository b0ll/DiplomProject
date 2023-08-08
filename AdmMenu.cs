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
    public partial class AdmMenu : Form
    {
        public AdmMenu()
        {
            InitializeComponent();
        }

        private void AdmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sotrudniki st = new Sotrudniki();
            st.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Auth au = new Auth();
            this.Hide();
            au.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MyMessages mm = new MyMessages();
            mm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Message ms = new Message();
            ms.ShowDialog();
        }



    }
}
