using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using celiacBakehila.BLL;

namespace celiacBakehila.GUI
{
    public partial class UCAddSale : UserControl
    {
        sales s;
        salesDB lstSales;
        public UCAddSale()
        {
            InitializeComponent();
            s = new sales();
            lstSales = new salesDB();
            txtkod.Text = lstSales.GetNextKey().ToString();
            s.Kod = lstSales.GetNextKey();
        }

        bool b;
        bool flag = false;
        public UCAddSale(bool b) : this()
        {
            this.b = b;
            if (b)
                checkBox1.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.ParentForm.Text = "צליאק בקהילה-מנהל-מכירות-מכירה חדשה-בחירת מוצרים";
            panelMain.Controls.Clear();
            UCSaleProduct uc = new UCSaleProduct();
            panelMain.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            panelMain.Dock = DockStyle.Fill;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.ParentForm.Text = "צליאק בקהילה-מנהל-מכירות";
            Control c = this.Parent;
            while (!(c is UCManager))
                c = c.Parent;
            (c as UCManager).panelMain.Controls.Clear();
            UCManagerSales uc = new UCManagerSales();
            (c as UCManager).panelMain.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (new salesDB().GetList().FirstOrDefault(x=>x.Distribution)!=null)
            {
                if (!b)
                {
                    checkBox1.Checked = false;
                    MessageBox.Show("במערכת קיימת מכירה פעילה, אין באפשרותך להפעיל מכירה זו.");
                }
            }
        }
    }
}
