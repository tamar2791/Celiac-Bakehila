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
    public partial class UCRemoveProduct : UserControl
    {
        products p;
        productsDB tblProducts;
        public UCRemoveProduct()
        {
            InitializeComponent();
            p = new products();
            tblProducts = new productsDB();
            dataGridView1.DataSource = tblProducts.GetList().Where(x => x.Status == false).Select(x => new { קוד_מוצר = x.Kod, קטגוריה = x.CategoryOfProduct().DescribeCategory, שם_מוצר = x.NameProduct, מחיר_קניה = x.BuyingPrice, מחיר_מכירה = x.CellingPrice, חדש = x.IfNew, ספק = x.SuppliersOfProduct().NameSupplier }).ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tblProducts.GetList().Where(x => x.Status == false).ToList().Count != 0)
            {
                int kod = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                p = tblProducts.SearchId(kod);
                p.Status = true;
                tblProducts.ApdateRow(p);
                dataGridView1.DataSource = tblProducts.GetList().Where(x => x.Status == false).Select(x => new { קוד_מוצר = x.Kod, קטגוריה = x.CategoryOfProduct().DescribeCategory, שם_מוצר = x.NameProduct, מחיר_קניה = x.BuyingPrice, מחיר_מכירה = x.CellingPrice, חדש = x.IfNew, ספק = x.SuppliersOfProduct().NameSupplier }).ToList();
                MessageBox.Show("המוצר שוחזר בהצלחה");
            }
            else
            {
                MessageBox.Show("רשימת המוצרים המחוקים ריקה");
                this.ParentForm.Text = "צליאק בקהילה-מנהל-מוצרים";
                panelMain.Controls.Clear();
                UCProduct uc = new UCProduct();
                panelMain.Controls.Add(uc);
                panelMain.Dock = DockStyle.Fill;
            }
        }

        private void btnRet_Click(object sender, EventArgs e)
        {
            this.ParentForm.Text = "צליאק בקהילה-מנהל-מוצרים";
            panelMain.Controls.Clear();
            UCProduct uc = new UCProduct();
            panelMain.Controls.Add(uc);
            panelMain.Dock = DockStyle.Fill;
        }
    }
}
