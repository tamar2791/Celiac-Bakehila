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
    public partial class UCNowSale : UserControl
    {
        categoryDB tblCategory;
        buy b;
        bool flagUpdate = false;
        
        int k;
        public UCNowSale(int k)
        {
            this.k = k;
            InitializeComponent();
            flagCategory = true;
            flowLayoutPanel1.Controls.Clear();
            CreateUCProduct();
            tblCategory = new categoryDB();
            CreateButtton();
            IsUpdate();
        }

        private void IsUpdate()
        {
            b = new buyDB().GetList().FirstOrDefault(x => x.SalesOfBuy().Distribution && x.TelClient == Validation.telUser);
            if(b!=null)
            {
                flagUpdate = true;

                //מילוי הסל
                Validation.lstSAL.Clear();
                foreach (buyingDetails item in new buyingDetailsDB().GetList().Where(x=>x.buyKodOfBuyingDetails().KodSale==b.KodSale&& x.TelClient==b.TelClient))
                {
                    Validation.lstSAL.Add(item);
                }
               //DeleteAll();
            }
        }
        buyingDetailsDB tblBuyingDetails= new buyingDetailsDB();
        private void DeleteAll()
        {
            List<buyingDetails> lst = tblBuyingDetails.GetList().Where(x => x.buyKodOfBuyingDetails().KodSale==b.KodSale&&x.TelClient==b.TelClient).ToList();
            //מחיקת המוצרים בלולאה
            foreach (buyingDetails item in lst)
            {
                tblBuyingDetails.DeleetRow(item);
            }
        }
        private void CreateUCProduct()
        {
            UCOneProductClient ucop;
            foreach (saleProducts item in new saleProductsDB().GetList().Where(x => x.Status == true && x.KodSale == k).ToList())
            {
                ucop = new UCOneProductClient(item.ProductsOfSaleProduct());
                flowLayoutPanel1.Controls.Add(ucop);
            }
        }
        private void CreateUCProduct(int kod)
        {
            UCOneProductClient ucop;
            foreach (saleProducts item in new saleProductsDB().GetList().Where(x => x.Status == true && x.KodSale == k&&x.ProductsOfSaleProduct().Category==kod).ToList())
            {
                ucop = new UCOneProductClient(item.ProductsOfSaleProduct());
                flowLayoutPanel1.Controls.Add(ucop);
            }
        }
        int kodCategory;
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
            flagCategory = true;
            kodCategory = (sender as CategoryBtn).c.KodCategory;
        }

        private void CreateUCProduct(category c)
        {
            UCOneProductClient ucop;
            foreach (saleProducts item in new saleProductsDB().GetList().Where(x =>x.SalesOfSaleProduct().Distribution && x.ProductsOfSaleProduct().Category==c.KodCategory))
            {
                ucop = new UCOneProductClient(item.ProductsOfSaleProduct());
                flowLayoutPanel1.Controls.Add(ucop);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.SendToBack();
            UCSal ucs = new UCSal(flagUpdate);
            panelDetails.Controls.Clear();
            panelDetails.Visible = true;
            panelDetails.Controls.Add(btnX);
            panelDetails.Controls.Add(ucs);
            ucs.Dock = DockStyle.Fill;
            this.ParentForm.Text = "צליאק בקהילה-משתמש-מכירות-מכירה נוכחית-סל קניות";

        }

        private void btnX_Click(object sender, EventArgs e)
        {
            panelDetails.Visible = false;
            this.ParentForm.Text = "צליאק בקהילה-משתמש-מכירות-מכירה נוכחית";
        }
        bool flagCategory = true;
        private void btnAllProduct_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            CreateUCProduct();
            flagCategory = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (flagCategory)
                    CreateUCProduct(textBox1.Text,kodCategory);
                else
                    CreateUCProduct(textBox1.Text);
            }
            else
            {
                flowLayoutPanel1.Controls.Clear();
                if (flagCategory)
                    CreateUCProduct(kodCategory);
                else
                    CreateUCProduct();
            }
        }
        private void CreateUCProduct(string st)
        {
            flowLayoutPanel1.Controls.Clear();
            UCOneProductClient ucop;
            foreach (saleProducts item in new saleProductsDB().GetList().Where(x => x.SalesOfSaleProduct().Distribution && x.ProductsOfSaleProduct().Status && x.ProductsOfSaleProduct().NameProduct.StartsWith(st)))
            {
                ucop = new UCOneProductClient(item.ProductsOfSaleProduct());
                flowLayoutPanel1.Controls.Add(ucop);
            }
            
        }
        private void CreateUCProduct(string st,int kod)
        {
            flowLayoutPanel1.Controls.Clear();
            UCOneProductClient ucop;
            foreach (saleProducts item in new saleProductsDB().GetList().Where(x => x.SalesOfSaleProduct().Distribution && x.ProductsOfSaleProduct().Status && x.ProductsOfSaleProduct().NameProduct.StartsWith(st)&&x.ProductsOfSaleProduct().CategoryOfProduct().KodCategory==kod))
            {
                ucop = new UCOneProductClient(item.ProductsOfSaleProduct());
                flowLayoutPanel1.Controls.Add(ucop);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var list=tbl.....switch (comboBox1.SelectedIndex) { case 0: }
            //break;
        }
    }
}
