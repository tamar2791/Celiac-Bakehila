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
    public partial class UCProduct : UserControl
    {
        productsDB tblProduct;
        public UCProduct()
        {
            InitializeComponent();
            tblProduct = new productsDB();
            p = new products();
            dataGridView1.DataSource = tblProduct.GetList().Where(x=>x.Status==true).Select(x => new { קוד_מוצר = x.Kod, קטגוריה = x.CategoryOfProduct().DescribeCategory, שם_מוצר = x.NameProduct, מחיר_קניה = x.BuyingPrice, מחיר_מכירה = x.CellingPrice, חדש = x.IfNew, ספק = x.SuppliersOfProduct().NameSupplier }).ToList();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            this.ParentForm.Text = "צליאק בקהילה-מנהל-מוצרים-הוספת מוצר";
            panelMain.Visible = true;
            panelMain.Controls.Clear();
            UCAddProduct uc = new UCAddProduct();
            panelMain.Controls.Add(uc);
            panelMain.Dock = DockStyle.Fill;
        }

        private void btnApdate_Click(object sender, EventArgs e)
        {
            if (tblProduct .GetList().Where(x => x.Status == true).ToList().Count!=0)
            {
                errorProvider1.Clear();
                this.ParentForm.Text = "צליאק בקהילה-מנהל-מוצרים-עדכון מוצר";
                int kod = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                panelMain.Visible = true;
                panelMain.Controls.Clear();
                UCAddProduct uc = new UCAddProduct(kod);
                panelMain.Controls.Add(uc);
                panelMain.Dock = DockStyle.Fill;
            }
            else
            {
                MessageBox.Show("רשימת המוצרים ריקה");
            }
        }
        products p;
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (tblProduct.GetList().Where(x => x.Status == true).ToList().Count != 0)
            {
                int kod = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                p = tblProduct.SearchId(kod);
                p.Status = false;
                tblProduct.ApdateRow(p);
                dataGridView1.DataSource = tblProduct.GetList().Where(x => x.Status == true).Select(x => new { קוד_מוצר = x.Kod, קטגוריה = x.CategoryOfProduct().DescribeCategory, שם_מוצר = x.NameProduct, מחיר_קניה = x.BuyingPrice, מחיר_מכירה = x.CellingPrice, חדש = x.IfNew, ספק = x.SuppliersOfProduct().NameSupplier }).ToList();
                MessageBox.Show("המוצר נמחק בהצלחה");

            }
            else
            {
                MessageBox.Show("רשימת המוצרים ריקה");
            }
        }

        private void btnOldProduct_Click(object sender, EventArgs e)
        {
            if (tblProduct.GetList().Where(x => x.Status == false).ToList().Count != 0)
            {
                this.ParentForm.Text = "צליאק בקהילה-מנהל-מוצרים-מוצרים שנמחקו";
                panelMain.Visible = true;
                panelMain.Controls.Clear();
                UCRemoveProduct uc = new UCRemoveProduct();
                panelMain.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
            }
            else
                MessageBox.Show("אין מוצרים מחוקים");
        }

        private void panelButton_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text!="")
                dataGridView1.DataSource = tblProduct.GetList().Where(x => x.Status == true&&x.NameProduct.StartsWith(textBox1.Text)).Select(x => new { קוד_מוצר = x.Kod, קטגוריה = x.CategoryOfProduct().DescribeCategory, שם_מוצר = x.NameProduct, מחיר_קניה = x.BuyingPrice, מחיר_מכירה = x.CellingPrice, חדש = x.IfNew, ספק = x.SuppliersOfProduct().NameSupplier }).ToList();
            else
                dataGridView1.DataSource = tblProduct.GetList().Where(x => x.Status == true).Select(x => new { קוד_מוצר = x.Kod, קטגוריה = x.CategoryOfProduct().DescribeCategory, שם_מוצר = x.NameProduct, מחיר_קניה = x.BuyingPrice, מחיר_מכירה = x.CellingPrice, חדש = x.IfNew, ספק = x.SuppliersOfProduct().NameSupplier }).ToList();
        }
    }
}
