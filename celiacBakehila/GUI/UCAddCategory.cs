using celiacBakehila.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace celiacBakehila.GUI
{
    public partial class UCAddCategory : UserControl
    {
        bool flagApdate = false;
        public UCAddCategory(int kod) : this()
        {
            c = lstCategory.SearchId(kod);
            FillTxt();
            flagApdate = true;
            btnAdd.Text = "עדכן";
            groupBox1.Text = "עדכון קטגוריה";
        }

        private void FillTxt()
        {
            txtkod.Text = c.KodCategory.ToString();
            txtName.Text = c.DescribeCategory;
        }

        public UCAddCategory()
        {
            InitializeComponent();
            c = new category();
            lstCategory = new categoryDB();
            txtkod.Text = lstCategory.GetNextKey().ToString();
            c.KodCategory = lstCategory.GetNextKey();
        }
        category c;
        categoryDB lstCategory;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (CreateCategory())
            {
                if (!flagApdate)
                {
                    lstCategory.AddNew(c);
                    MessageBox.Show("הקטגוריה נוספה בהצלחה");
                }
                else
                {
                    lstCategory.ApdateRow(c);
                    MessageBox.Show("הקטגוריה עודכנה בהצלחה");
                }
                Control co = this.Parent;
                while (!(co is UCManager))
                    co = co.Parent;
                (co as UCManager).panelMain.Controls.Clear();
                UCNihul uc = new UCNihul();
                (co as UCManager).panelMain.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
            }
        }

        private bool CreateCategory()
        {
            errorProvider1.Clear();
            bool flag = true;
            try
            {
                if (txtkod.Text == "")
                    throw new Exception("שדה חובה");
                c.KodCategory = Convert.ToInt32(txtkod.Text);
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtkod, ex.Message);
                flag = false;
            }
            try
            {
                if (txtName.Text == "")
                    throw new Exception("שדה חובה");
                c.DescribeCategory = txtName.Text;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtName, ex.Message);
                flag = false;
            }
            c.Status = true;
            return flag;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Control c = this.Parent;
            while (!(c is UCManager))
                c = c.Parent;
            (c as UCManager).panelMain.Controls.Clear();
            UCNihul uc = new UCNihul();
            (c as UCManager).panelMain.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            (uc as UCNihul).panelMainCategory.Visible = true;
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            if (CreateCategory())
            {
                if (!flagApdate)
                {
                    lstCategory.AddNew(c);
                    MessageBox.Show("הקטגוריה נוספה בהצלחה");
                }
                else
                {
                    lstCategory.ApdateRow(c);
                    MessageBox.Show("הקטגוריה עודכנה בהצלחה");
                }
                txtkod.Text = "";
                txtName.Text = "";
                txtkod.Text = lstCategory.GetNextKey().ToString();
                c.KodCategory = lstCategory.GetNextKey();
                Control co = this.Parent;
                while (!(co is UCManager))
                    co = co.Parent;
                (co as UCManager).panelMain.Controls.Clear();
                UCNihul uc = new UCNihul();
                (co as UCManager).panelMain.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
            }
        }
    }
}
