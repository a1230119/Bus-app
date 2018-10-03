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
    
    public partial class Form2 : Form
    {
        public Form5 f5;

        string str = "";
        public Label[] label = new Label[14];
        public bool[] lbstar = new bool[14];
        int[] list = new int[14];
        public Form2()
        {
            InitializeComponent();
            button4.Click += new System.EventHandler(button3_Click);
            button5.Click += new System.EventHandler(button3_Click);
            button8.Click += new System.EventHandler(button3_Click);
            button9.Click += new System.EventHandler(button3_Click);
            button10.Click += new System.EventHandler(button3_Click);
            button13.Click += new System.EventHandler(button3_Click);
            button14.Click += new System.EventHandler(button3_Click);
            button15.Click += new System.EventHandler(button3_Click);
            button17.Click += new System.EventHandler(button3_Click);
            label[0] = createLabel(1, "台南火車站", "茄萣");
            label[1] = createLabel(2, "崑山科大", "安平");
            label[2] = createLabel(3, "東海國小", "竹篙厝");
            label[3] = createLabel(0, "", "");
            label[3].Enabled = false;
            label[4] = createLabel(5, "桂田酒店", "市立醫院");
            label[5] = createLabel(6, "仁德轉運站", "新興國宅");
            label[6] = createLabel(7, "台南火車站", "台糖安南學苑");
            label[7] = createLabel(0, "", "");
            label[7].Enabled = false;
            label[8] = createLabel(9, "台南火車站", "公親里");
            label[9] = createLabel(10, "台南火車站", "鹿耳門");
            label[10] = createLabel(11, "大成路口", "城西里");
            label[11] = createLabel(0, "", "");
            label[11].Enabled = false;
            label[12] = createLabel(0, "", "");
            label[12].Enabled = false;
            label[13] = createLabel(14, "台南火車站", "億載金城");
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            f5 = new Form5();
            f5.Owner = this;

        }

        public void clean()
        {
            if (str.Length > 0 && int.Parse(label4.Text) <= 14 && label[int.Parse(str) - 1].Enabled)
                Controls.Remove(label[int.Parse(str) - 1]);
            str = "";
            label4.Text = str;
        }

        private Label createLabel(int i, string start, string goal)
        {
            Label lb = new Label();
            lb.Text = i.ToString() + "  " + start + "-" + goal;
            lb.Font = new Font("新細明體", 14);
            lb.BorderStyle = BorderStyle.FixedSingle;
            lb.TextAlign = ContentAlignment.MiddleCenter;
            lb.Width = 360;
            lb.Height = 80;
            lb.Name = i.ToString();
            lb.Click += new System.EventHandler(lb_Click);
            return lb;
        }

        private void lb_Click(object sender, EventArgs e)
        {
            Label lb = (Label)sender;
            if (!lbstar[int.Parse(lb.Name) - 1])
            {
                lb.BackColor = Color.Red;
                lbstar[int.Parse(lb.Name) - 1] = true;
            }

            else
            {
                lb.BackColor = SystemColors.Control;
                lbstar[int.Parse(lb.Name) - 1] = false;
            }

            
            f5.Show();

            //label1.Text = lb.Name;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (str.Length > 0)
            {
                if (int.Parse(label4.Text) <= 14 && label[int.Parse(str) - 1].Enabled)
                    Controls.Remove(label[int.Parse(str) - 1]);
            }
            str += btn.Text;
            label4.Text = str;
            if (int.Parse(label4.Text) <= 14 && label[int.Parse(str) - 1].Enabled)
            {
                label[int.Parse(str) - 1].Left = 1;
                label[int.Parse(str) - 1].Top = 50;
                Controls.Add(label[int.Parse(str) - 1]);
            }
        }

        private void button18_Click(object sender, EventArgs e)//clear
        {
            if (str.Length > 0 && int.Parse(label4.Text) <= 14 && label[int.Parse(str) - 1].Enabled)
                Controls.Remove(label[int.Parse(str) - 1]);
            str = "";
            label4.Text = str;
        }

        private void button16_Click(object sender, EventArgs e)//back
        {
            if (str.Length > 0 && int.Parse(label4.Text) <= 14 && label[int.Parse(str) - 1].Enabled)
                Controls.Remove(label[int.Parse(str) - 1]);
            str = str.Substring(0, str.Length - 1);

            label4.Text = str;
            if (str.Length > 0 && int.Parse(label4.Text) <= 14 && label[int.Parse(str) - 1].Enabled)
            {
                label[int.Parse(str) - 1].Left = 1;
                label[int.Parse(str) - 1].Top = 50;
                Controls.Add(label[int.Parse(str) - 1]);
            }
        }

        private void label4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                ((Form)sender).Hide(); //用隱藏取代關閉, 資源不會釋放, 下次要用直接 Show 就好了 
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
