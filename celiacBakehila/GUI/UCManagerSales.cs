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
    public partial class UCManagerSales : UserControl
    {
        salesDB tblSale;
        public UCManagerSales()
        {
            InitializeComponent();
            tblSale = new salesDB();
            dataGridView1.DataSource = tblSale.GetList().Select(x => new { קוד_מכירה = x.Kod, תאריך_מכירה = x.DateSale, ניתן_להזמין = x.Distribution }).ToList();
            sale = new sales();
        }

        private void btnNewSale_Click(object sender, EventArgs e)
        {
            if (tblSale.GetList().FirstOrDefault(x => x.Distribution == true) != null)
            {
                DialogResult d = MessageBox.Show("קיימת במערכת מכירה פעילה,\nהאם ברצונך לפתוח מכירה חדשה ולסגור את המכירה הפעילה הקודמת?", "קיימת מכירה פעילה", MessageBoxButtons.YesNo);//,MessageBoxDefaultButton.Button1,MessageBoxIcon.Warning,MessageBoxOptions.RtlReading);
                if (d == DialogResult.Yes)
                {
                    //sales st = tblSale.GetList().FirstOrDefault(x => x.Distribution == true);
                    //st.Distribution = false;
                    //tblSale.ApdateRow(st);
                    //dataGridView1.DataSource = tblSale.GetList().Select(x => new { קוד_מכירה = x.Kod, תאריך_מכירה = x.DateSale, ניתן_להזמין = x.Distribution }).ToList();
                    this.ParentForm.Text = "צליאק בקהילה-מנהל-מכירות-מכירה חדשה";
                    panelMain.Controls.Clear();
                    UCAddSale uc = new UCAddSale(true);
                    panelMain.Controls.Add(uc);
                    uc.Dock = DockStyle.Fill;
                }
                else
                {
                    this.ParentForm.Text = "צליאק בקהילה-מנהל-מכירות-מכירה חדשה";
                    panelMain.Controls.Clear();
                    UCAddSale uc = new UCAddSale();
                    panelMain.Controls.Add(uc);
                    uc.Dock = DockStyle.Fill;
                }
            }
            else
            {
                this.ParentForm.Text = "צליאק בקהילה-מנהל-מכירות-מכירה חדשה";
                panelMain.Controls.Clear();
                UCAddSale uc = new UCAddSale();
                panelMain.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
            }
        }
        bool b = false;
        private void btnApdate_Click(object sender, EventArgs e)
        {
            FillText();
            panelApdate.Visible = true;
            b = true;
        }
        sales sale;
        private void FillText()
        {
            int kod = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            sales s = new salesDB().GetList().FirstOrDefault(x => x.Kod == kod);
            textBox1.Text = s.Kod.ToString();
            dateTimePicker1.Value = s.DateSale;
            dateTimePicker1.Text = s.DateSale.ToString();
            checkBox1.Checked = s.Distribution;
            sale = s;
        }

        private void btnHatzeg_Click(object sender, EventArgs e)
        {

        }

        saleProductsDB lstSP = new saleProductsDB();
        private void btnProduct_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            dataGridView2.DataSource = lstSP.GetList().Where(x => x.KodSale == kod).Select(x => new { קוד_מוצר = x.KodProduct, שם_מוצר = x.ProductsOfSaleProduct().NameProduct, קטגוריה = x.ProductsOfSaleProduct().CategoryOfProduct().DescribeCategory, מחיר_קניה = x.ProductsOfSaleProduct().BuyingPrice, מחיר_מכירה = x.ProductsOfSaleProduct().CellingPrice, חדש = x.ProductsOfSaleProduct().IfNew, ספק = x.ProductsOfSaleProduct().SuppliersOfProduct().NameSupplier }).ToList();
            panelproduct.Visible = true;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            panelproduct.Visible = false;
            flag = false;
        }
        bool flag = false;
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("המכירה עודכנה בהצלחה");
            sale.Distribution = checkBox1.Checked;
            sale.DateSale = dateTimePicker1.Value;
            tblSale.ApdateRow(sale);
            dataGridView1.DataSource = tblSale.GetList().Select(x => new { קוד_מכירה = x.Kod, תאריך_מכירה = x.DateSale, ניתן_להזמין = x.Distribution }).ToList();
            panelApdate.Visible = false;
        }
        saleProductsDB lstSaleProducts = new saleProductsDB();
        private void btnRemove_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[0].Value);
            saleProducts sp = new saleProductsDB().GetList().First(x => x.KodProduct == kod);
            lstSaleProducts.GetList().FirstOrDefault(x => x == sp);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            sales s = tblSale.SearchId(kod);
            if (new buyingDetailsDB().GetList().Where(x => x.KodSale == s.Kod).Count() > 0)
                MessageBox.Show("לא ניתן לעדכן מוצרים למכירה שבוצעו בה הזמנות לקוחות");
            else
            {
                if (s.DateSale > DateTime.Now && !s.Distribution)
                {
                    this.ParentForm.Text = "צליאק בקהילה-מנהל-מכירות-עדכון מוצרים במכירה";
                    panelMain.Controls.Clear();
                    UCSaleProduct uc = new UCSaleProduct(kod, true, b);
                    panelMain.Controls.Add(uc);
                    uc.Dock = DockStyle.Fill;
                }
                else
                {
                    if (s.Distribution)
                        MessageBox.Show("אין אפשרות לעדכן המכירה פתוחה להזמנות .");
                    else
                        MessageBox.Show("אין אפשרות לעדכן ,תאריך המכירה עבר .");
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            panelApdate.Visible = false;
            b = false;
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            sales sk = tblSale.SearchId(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
            if (!tblSale.SearchId(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value)).Distribution)
            {
                if (tblSale.GetList().FirstOrDefault(x => x.Distribution == true) != null)
                {
                    checkBox1.Checked = false;
                    MessageBox.Show("במערכת קיימת מכירה פעילה, אין באפשרותך להפעיל מכירה זו.");
                }
            }
            if (sk.DateSale < DateTime.Now && !tblSale.SearchId(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value)).Distribution)
            {
                checkBox1.Checked = false;
                MessageBox.Show("תאריך המכירה עבר, אין באפשרותך להפעיל מכירה זו.");
            }
        }
    }
}
