using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Final_Project
{
    public partial class Form5 : Form
    {
        private const string FileName = "C:\\Users\\chinlun\\Desktop\\台南公車路線.xlsx";
        private const string ProviderName = "Microsoft.ACE.OLEDB.12.0;";
        private const string ExtendedString = "'Excel 8.0;";
        private const string Hdr = "Yes;";
        private const string IMEX = "0';";

        string cs = "Data Source=" + FileName + ";" +
            "Provider=" + ProviderName +
            "Extended Properties=" + ExtendedString +
            "HDR=" + Hdr +
            "IMEX=" + IMEX;
        string SheetName = "工作表1";

        public Form5()
        {
            InitializeComponent();
        }      

        private void Form5_Load(object sender, EventArgs e)
        {
            FileLoad();
        }

        private void FileLoad()
        {
            using (OleDbConnection cn = new OleDbConnection(cs))
            {
                cn.Open();
                string qs_left = "SELECT Zh_tw2 FROM[" + SheetName + "$] WHERE Direction = 0 AND Zh_tw = '1'";
                string qs_right = "SELECT Zh_tw2 FROM[" + SheetName + "$] WHERE Direction = 1 AND Zh_tw = '1'";
                try
                {
                    using (OleDbDataAdapter dr = new OleDbDataAdapter(qs_left, cn))
                    {
                        DataTable dt = new DataTable();
                        dr.Fill(dt);
                        this.dataGridView1.DataSource = dt;
                    }
                    using (OleDbDataAdapter dr = new OleDbDataAdapter(qs_right, cn))
                    {
                        DataTable dt = new DataTable();
                        dr.Fill(dt);
                        this.dataGridView2.DataSource = dt;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                ((Form)sender).Hide(); //用隱藏取代關閉, 資源不會釋放, 下次要用直接 Show 就好了 
            }
        }
    }
}
