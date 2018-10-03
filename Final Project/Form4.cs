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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                ((Form)sender).Hide(); //用隱藏取代關閉, 資源不會釋放, 下次要用直接 Show 就好了 
            }
        }

        private void showFavorite()
        {
            int posy = 62;
            for (int i = 0; i < 14; ++i)
            {
                if (((Form1)this.Owner).f2.lbstar[i])
                {
                    ((Form1)this.Owner).f2.label[i].Left = 1;
                    ((Form1)this.Owner).f2.label[i].Top = posy;
                    Controls.Add(((Form1)this.Owner).f2.label[i]);
                    posy += 80;
                }

            }

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            showFavorite();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
