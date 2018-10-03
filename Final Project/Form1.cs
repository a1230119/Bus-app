using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project
{
    public partial class Form1 : Form
    {
        public Form2 f2;
        Form3 f3;
        Form4 f4;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            f2.clean();
            f2.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            f2 = new Form2();
            f2.Owner = this;
            f3 = new Form3();
            f3.Owner = this;
            f4 = new Form4();
            f4.Owner = this;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            f4.Show();
        }
    }
}
