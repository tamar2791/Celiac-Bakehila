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
    public partial class UCSaleProduct : UserControl
    {
        categoryDB tblCategory;
        public UCSaleProduct()
        {

            InitializeComponent();
            lstSales = new salesDB();
            tblCategory = new categoryDB();
            lstSaleProducts = new saleProductsDB();
            s = new sales();
            sp = new saleProducts();
            CreateButtton();
            CreateUCProduct();
            Validation.lstP.Clear();
            bool b = false;
            foreach (Control item in flowLayoutPanel2.Controls)
            {
                if (item is UCOneProduct)
                    b = true;
            }
            if (b)
                label5.Visible = false;
            else
                label5.Visible = true;
        }
        bool b;
        bool bb;
        public UCSaleProduct(int kodSale, bool b, bool bb)
        {
            this.b = b;
            this.bb = bb;
            InitializeComponent();
            lstSales = new salesDB();
            tblCategory = new categoryDB();
            lstSaleProducts = new saleProductsDB();
            sp = new saleProducts();
            Validation.lstP.Clear();
            s = lstSales.SearchId(kodSale);
            FillProduct();
            CreateButtton();
            CreateUCProduct();
        }

        private void FillProduct()
        {
            List<saleProducts> lst = lstSaleProducts.GetList().Where(x => x.Status == true && x.KodSale == s.Kod).ToList();
            foreach (saleProducts item in lst)
            {
                UCOneProduct up = new UCOneProduct(item);
                this.flowLayoutPanel2.Controls.Add(up);
                Validation.lstP.Add(item);
                up.numericUpDown1.Value = item.MaximumAmount;
                up.btnAdd.Text = "הסר";
                up.btnAdd.Width = 50;
                up.numericUpDown1.Width = 50;
                up.Width = 380;
            }

        }

        private void CreateUCProduct()
        {
            UCOneProduct ucop;
            foreach (products item in new productsDB().GetList().Where(x => x.Status == true).ToList())
            {
                sp = lstSaleProducts.GetList().FirstOrDefault(x => x.KodProduct == item.Kod && x.KodSale == s.Kod);
                if (sp == null)
                {
                    ucop = new UCOneProduct(item);
                    flowLayoutPanel1.Controls.Add(ucop);
                }
            }
        }
        private void CreateUCProduct(category c)
        {
            UCOneProduct ucop;
            foreach (products item in new productsDB().GetList().Where(x => x.Status == true).Where(x => x.Category == c.KodCategory).ToList())
            {
                ucop = new UCOneProduct(item);
                flowLayoutPanel1.Controls.Add(ucop);
            }
        }
        private void CreateUCProduct(string st)
        {
            flowLayoutPanel1.Controls.Clear();
            UCOneProduct ucop;
            foreach (products item in new productsDB().GetList().Where(x => x.Status == true).Where(x => x.NameProduct.StartsWith(st)).ToList())
            {
                ucop = new UCOneProduct(item);
                flowLayoutPanel1.Controls.Add(ucop);
            }
        }

        private void CreateButtton()
        {
            CategoryBtn btn;
            foreach (Button item in panelCategory.Controls)
            {
                if (item is CategoryBtn)
                    panelCategory.Controls.Remove(item);
            }

            foreach (category item in tblCategory.GetList().Where(x => x.Status == true))
            {
                btn = new CategoryBtn(item);
                btn.Height = 30;
                btn.Dock = DockStyle.Top;
                panelCategory.Controls.Add(btn);
                btn.Text = item.DescribeCategory;
                btn.Click += Btn_Click;
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            CreateUCProduct((sender as CategoryBtn).c);
        }

        private void bntAll_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            CreateUCProduct();
        }
        saleProductsDB lstSP = new saleProductsDB();
        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (!b)
            {
                this.ParentForm.Text = "צליאק בקהילה-מנהל-מכירות-מכירה חדשה";
                Control c = this.Parent;
                while (!(c is UCManager))
                    c = c.Parent;
                (c as UCManager).panelMain.Controls.Clear();
                UCAddSale uc = new UCAddSale();
                (c as UCManager).panelMain.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
            }
            else
            {
                this.ParentForm.Text = "צליאק בקהילה-מנהל-מכירות";
                Control c = this.Parent;
                while (!(c is UCManager))
                    c = c.Parent;
                (c as UCManager).panelMain.Controls.Clear();
                UCManagerSales uc = new UCManagerSales();
                (c as UCManager).panelMain.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                int kod = Convert.ToInt32(uc.dataGridView1.SelectedRows[0].Cells[0].Value);
                uc.dataGridView2.DataSource = lstSP.GetList().Where(x => x.KodSale == kod).Select(x => new { קוד_מוצר = x.KodProduct, שם_מוצר = x.ProductsOfSaleProduct().NameProduct, קטגוריה = x.ProductsOfSaleProduct().CategoryOfProduct().DescribeCategory, מחיר_קניה = x.ProductsOfSaleProduct().BuyingPrice, מחיר_מכירה = x.ProductsOfSaleProduct().CellingPrice, חדש = x.ProductsOfSaleProduct().IfNew, ספק = x.ProductsOfSaleProduct().SuppliersOfProduct().NameSupplier }).ToList();
                uc.panelproduct.Visible = true;
                if (bb)
                    uc.panelApdate.Visible = true;
            }
        }
        sales s;
        salesDB lstSales;
        saleProducts sp;
        saleProductsDB lstSaleProducts;

        private void button1_Click(object sender, EventArgs e)
        {
            if (!label5.Visible)
            {
                //הוספת מכירה חדשה
                if (!b)
                {
                    this.ParentForm.Text = "צליאק בקהילה-מנהל-מכירות";
                    s = new sales();
                    CreateSale();
                    lstSales.AddNew(s);
                    MessageBox.Show("המכירה נוספה בהצלחה");
                    Control c = this.Parent;
                    while (!(c is UCManager))
                        c = c.Parent;
                    (c as UCManager).panelMain.Controls.Clear();
                    UCManagerSales uc = new UCManagerSales();
                    (c as UCManager).panelMain.Controls.Add(uc);
                    uc.Dock = DockStyle.Fill;
                }
                //הוספה לטבלת מוצרים במכירה
                CreateProductSale();
                if (b)
                {
                    this.ParentForm.Text = "צליאק בקהילה-מנהל-מכירות";
                    MessageBox.Show("המכירה עודכנה בהצלחה");
                    Control c = this.Parent;
                    while (!(c is UCManager))
                        c = c.Parent;
                    (c as UCManager).panelMain.Controls.Clear();
                    UCManagerSales uc = new UCManagerSales();
                    (c as UCManager).panelMain.Controls.Add(uc);
                    uc.Dock = DockStyle.Fill;
                    int kod = Convert.ToInt32(uc.dataGridView1.SelectedRows[0].Cells[0].Value);
                    uc.dataGridView2.DataSource = lstSP.GetList().Where(x => x.KodSale == kod).Select(x => new { קוד_מוצר = x.KodProduct, שם_מוצר = x.ProductsOfSaleProduct().NameProduct, קטגוריה = x.ProductsOfSaleProduct().CategoryOfProduct().DescribeCategory, מחיר_קניה = x.ProductsOfSaleProduct().BuyingPrice, מחיר_מכירה = x.ProductsOfSaleProduct().CellingPrice, חדש = x.ProductsOfSaleProduct().IfNew, ספק = x.ProductsOfSaleProduct().SuppliersOfProduct().NameSupplier }).ToList();
                    uc.panelproduct.Visible = true;
                    if (bb)
                        uc.panelApdate.Visible = true;
                }
            }
            else
                MessageBox.Show("יש לבחור מוצרים");
        }

        private void CreateProductSale()
        {

            int i = -1;
            if (b)
            {
                DeleteAll();
            }
            foreach (saleProducts item in Validation.lstP)
            {
                i++;
                if (!b)
                {
                    Control c = this.Parent;
                    while (!(c is UCAddSale))
                        c = c.Parent;
                    item.KodSale = Convert.ToInt32((c as UCAddSale).txtkod.Text);
                    lstSaleProducts.AddNew(item);
                }
                //מחיקה מהאקסס של על המוצרים במכירה
                else
                {
                    //הוספה מחדש
                    Control c = this.Parent;
                    while (!(c is UCManagerSales))
                        c = c.Parent;
                    item.KodSale = Convert.ToInt32((c as UCManagerSales).dataGridView1.SelectedRows[0].Cells[0].Value);
                    lstSaleProducts.AddNew(item);
                }

            }
        }

        private void DeleteAll()
        {
            List<saleProducts> lst = lstSaleProducts.GetList().Where(x => x.KodSale == s.Kod).ToList();
            //מחיקת המוצרים בלולאה
            foreach (saleProducts item in lst)
            {
                lstSaleProducts.DeleetRow(item);
            }
        }

        private void CreateSale()
        {
            Control c = this.Parent;
            while (!(c is UCAddSale))
                c = c.Parent;
            s.Kod = Convert.ToInt32((c as UCAddSale).txtkod.Text);
            s.DateSale = (c as UCAddSale).dateTimePicker1.Value;
            s.Status = "";
            if ((c as UCAddSale).checkBox1.Checked)
            {
                sales sss = lstSales.GetList().FirstOrDefault(x => x.Distribution);
                if (sss!=null)
                {
                    sss.Distribution = false;
                    lstSales.ApdateRow(sss);
                }
            }
            s.Distribution = (c as UCAddSale).checkBox1.Checked;
            s.Place = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
                CreateUCProduct(textBox1.Text);
            else
                CreateUCProduct();
        }
    }
}
