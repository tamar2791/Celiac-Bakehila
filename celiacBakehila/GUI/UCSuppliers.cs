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
    public partial class UCSuppliers : UserControl
    {
        suppliersDB tblsuppliers;
        suppliers s;
        public UCSuppliers()
        {
            InitializeComponent();
            tblsuppliers = new suppliersDB();
            s = new suppliers();
            lstProducts=new productsDB();
            dataGridView1.DataSource = tblsuppliers.GetList().Where(x=>x.Status==true).Select(x => new {תעודת_זהות_ספק=x.TzSupplier,שם_ספק=x.NameSupplier,טלפון=x.Phone,פלאפון=x.CellPhone,מייל=x.Mail}).ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.ParentForm.Text = "צליאק בקהילה-מנהל-ספקים-הוספת ספק";
            panelMain.Visible = true;
            panelMain.Controls.Clear();
            UCAddSupplier uc = new UCAddSupplier();
            panelMain.Controls.Add(uc);
            panelMain.Dock = DockStyle.Fill;
        }

        private void btnApdate_Click(object sender, EventArgs e)
        {
            if (tblsuppliers.GetList().Where(x => x.Status == true).ToList().Count != 0)
            { 
                this.ParentForm.Text = "צליאק בקהילה-מנהל-ספקים-עדכון ספק";
                string tz = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                panelMain.Visible = true;
                panelMain.Controls.Clear();
                UCAddSupplier uc = new UCAddSupplier(tz);
                panelMain.Controls.Add(uc);
                panelMain.Dock = DockStyle.Fill;
            }
            else
                MessageBox.Show("רשימת הספקים ריקה");
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (tblsuppliers.GetList().Where(x => x.Status == true).ToList().Count != 0)
            {
                string tz = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                s = tblsuppliers.SearchId(tz);
                s.Status = false;
                tblsuppliers.ApdateRow(s);
                dataGridView1.DataSource = tblsuppliers.GetList().Where(x => x.Status == true).Select(x => new { תעודת_זהות_ספק = x.TzSupplier, שם_ספק = x.NameSupplier, טלפון = x.Phone, פלאפון = x.CellPhone, מייל = x.Mail }).ToList();
                MessageBox.Show("הספק נמחק בהצלחה");
            }
            else
            {
                MessageBox.Show("רשימת הספקים ריקה");
            }
        }

        private void btnOldSupplier_Click(object sender, EventArgs e)
        {
            if (tblsuppliers.GetList().Where(x => x.Status == false).ToList().Count != 0)
            {
                this.ParentForm.Text = "צליאק בקהילה-מנהל-ספקים-ספקים שנמחקו";
                panelMain.Visible = true;
                panelMain.Controls.Clear();
                UCRemoveSupplier uc = new UCRemoveSupplier();
                panelMain.Controls.Add(uc);
                panelMain.Dock = DockStyle.Fill;
            }
            else
            { 
                MessageBox.Show("אין ספקים מחוקים");               
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            panelproduct.Visible=false;
            flag=false;
        }
        productsDB lstProducts;
        private void btnHatzeg_Click(object sender, EventArgs e)
        {           
            string tz = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            s = tblsuppliers.SearchId(tz);
            dataGridView2.DataSource = lstProducts.GetList().Where(x => x.SuppliersOfProduct().TzSupplier == s.TzSupplier).Where(x => x.Status == true).Select(x => new { קוד_מוצר = x.Kod, קטגוריה = x.CategoryOfProduct().DescribeCategory, שם_מוצר = x.NameProduct, מחיר_קניה = x.BuyingPrice, מחיר_מכירה = x.CellingPrice, חדש = x.IfNew }).ToList();
            panelproduct.Visible = true;
        }
        bool flag=false;
        private void btnBig_Click(object sender, EventArgs e)
        {
            if (!flag)
            { 
                panelproduct.Dock = DockStyle.Fill;
                dataGridView2.Height = 360;
                flag =true;
            }
            else
            { 
                panelproduct.Dock = DockStyle.Bottom;
                dataGridView2.Height = 148;
                flag =false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                if(Validation.IsNum(textBox1.Text))
                    dataGridView1.DataSource = tblsuppliers.GetList().Where(x => x.Status == true&&x.TzSupplier.StartsWith(textBox1.Text)).Select(x => new { תעודת_זהות_ספק = x.TzSupplier, שם_ספק = x.NameSupplier, טלפון = x.Phone, פלאפון = x.CellPhone, מייל = x.Mail }).ToList();
                if(Validation.IsHebrew(textBox1.Text))
                    dataGridView1.DataSource = tblsuppliers.GetList().Where(x => x.Status == true && x.NameSupplier.StartsWith(textBox1.Text)).Select(x => new { תעודת_זהות_ספק = x.TzSupplier, שם_ספק = x.NameSupplier, טלפון = x.Phone, פלאפון = x.CellPhone, מייל = x.Mail }).ToList();
            }
            else
                dataGridView1.DataSource = tblsuppliers.GetList().Where(x => x.Status == true && x.TzSupplier.StartsWith(textBox1.Text)).Select(x => new { תעודת_זהות_ספק = x.TzSupplier, שם_ספק = x.NameSupplier, טלפון = x.Phone, פלאפון = x.CellPhone, מייל = x.Mail }).ToList();
        }
    }
}
