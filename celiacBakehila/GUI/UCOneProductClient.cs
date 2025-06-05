using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using celiacBakehila.BLL;
using Microsoft.Office.Interop.Excel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace celiacBakehila.GUI
{
    public partial class UCOneProductClient : UserControl
    {
        products p;
        productsDB lstProducts;
        saleProducts sp;
        saleProductsDB lstSaleProdeuct;
        public UCOneProductClient(products p)
        {
            InitializeComponent();
            lstProducts = new productsDB();
            lstSaleProdeuct = new saleProductsDB();
            this.p = p;
            string a = Directory.GetParent(Directory.GetCurrentDirectory()).ToString();
            string c = Directory.GetParent(a).ToString();//שמירת נתיב ללא debug                                                   
            c = c + @"\pictures\";//שרשור שם התיקיה המקומית של התמונות
            c = c + p.Picture;//שרשור שם התמונה המבוקשת באמצעות שימוש בעצם ובתכונות המחלקה
            pictureBox1.Image = Image.FromFile(c);
            pictureBox1.BackgroundImageLayout = ImageLayout.Center;
            lblName.Text = p.NameProduct;
            lblPrice.Text = p.CellingPrice.ToString();
            label2.Text=p.Kod.ToString();
            //בדיקה אם קיים במלאי
            CheckAmount();
            //בדיקה אם הזמין מוצר זה
            if (CheckOrder())
                lblOrder.Visible = true;
        }
        buyingDetailsDB bt = new buyingDetailsDB();
        private bool CheckOrder()
        {
            bool b = false;
            if (Validation.lstSAL.Count > 0)
            {
                if (Validation.lstSAL.FirstOrDefault(x => x.KodProduct == p.Kod )!=null)//&& x.TelClient == Validation.telUser && x.SaleKodProductsOfBuyingDetails().SalesOfSaleProduct().Distribution) != null)//new buyingDetailsDB().GetList().FirstOrDefault(x=>x.KodProduct==p.Kod&&x.TelClient==Validation.telUser&&x.SaleKodProductsOfBuyingDetails().SalesOfSaleProduct().Distribution)!=null)
                {
                    b = true;
                    lblOrder.Text = "הזמנת " + Validation.lstSAL.FirstOrDefault(x => x.KodProduct == p.Kod ).OrderedAmount.ToString();//new buyingDetailsDB().GetList().FirstOrDefault(x => x.KodProduct == p.Kod && x.TelClient == Validation.telUser && x.SaleKodProductsOfBuyingDetails().SalesOfSaleProduct().Distribution).OrderedAmount.ToString();
                }
                return b;
            }
            else
            {
                if (bt.GetList().FirstOrDefault(x => x.KodProduct == p.Kod && x.TelClient == Validation.telUser && x.SaleProductOfBuyingDetails().SalesOfSaleProduct().Distribution) != null)
                {
                    b = true;
                    lblOrder.Text = "הזמנת " + new buyingDetailsDB().GetList().FirstOrDefault(x => x.KodProduct == p.Kod && x.TelClient == Validation.telUser && x.SaleProductOfBuyingDetails().SalesOfSaleProduct().Distribution).OrderedAmount.ToString();
                }
                return b;
            }
        }

        private void CheckAmount()
        {
            sp = lstSaleProdeuct.GetList().FirstOrDefault(x => x.kodProduct == p.Kod && x.SalesOfSaleProduct().Distribution);
            if (sp != null)
            {
                int sucAll = new buyingDetailsDB().GetList().Where(x => x.KodProduct == p.Kod && x.KodSale == sp.KodSale).Sum(x => x.OrderedAmount);
                if (sucAll >= sp.MaximumAmount)
                {
                    //הודעה אזל מהמלאי
                    lblAzal.Visible = true;
                }
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Control c = this.Parent;
            while (!(c is UCNowSale))
                c = c.Parent;
            (c as UCNowSale).panelDetails.Visible = true;
            (c as UCNowSale).panelDetails.Controls.Clear();
            UCProductDetail uc = new UCProductDetail(this.p,this);
            (c as UCNowSale).panelDetails.Controls.Add(uc);
            (c as UCNowSale).flowLayoutPanel1.SendToBack();
            uc.Dock = DockStyle.Fill;
        }
    }
}
