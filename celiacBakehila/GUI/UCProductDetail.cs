using celiacBakehila.BLL;
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

namespace celiacBakehila.GUI
{
    public partial class UCProductDetail : UserControl
    {
        products pp;
        saleProducts sp;
        saleProductsDB lstSaleProdeuct;
        UCOneProductClient up1;
        public UCProductDetail(products p, UCOneProductClient up = null)
        {
            InitializeComponent();
            lblName.Text = p.NameProduct;
            lstSaleProdeuct = new saleProductsDB();
            lblPrice.Text = p.CellingPrice.ToString();
            lblCategory.Text = p.CategoryOfProduct().DescribeCategory;
            lblNew.Visible = p.IfNew;
            string a = Directory.GetParent(Directory.GetCurrentDirectory()).ToString();
            string c = Directory.GetParent(a).ToString();//שמירת נתיב ללא debug                                                   
            c = c + @"\pictures\";//שרשור שם התיקיה המקומית של התמונות
            c = c + p.Picture;//שרשור שם התמונה המבוקשת באמצעות שימוש בעצם ובתכונות המחלקה
            pictureBox1.Image = Image.FromFile(c);
            pictureBox1.BackgroundImageLayout = ImageLayout.Center;
            pp = p;
            CheckAmount();
            //בדיקה אם הזמין מוצר זה
            if (CheckOrder())
            {
                lblOrder.Visible = true;
                btnAdd.Text = "עדכן כמות";
            }
            up1 = up;
        }

        private bool CheckOrder()
        {
            bool b = false;
            if (Validation.lstSAL.FirstOrDefault(x => x.KodProduct == pp.Kod) != null)//new buyingDetailsDB().GetList().FirstOrDefault(x => x.KodProduct == pp.Kod && x.TelClient == Validation.telUser && x.SaleKodProductsOfBuyingDetails().SalesOfSaleProduct().Distribution) != null)/
            {
                b = true;
                lblOrder.Text = "הזמנת " + Validation.lstSAL.FirstOrDefault(x => x.KodProduct == pp.Kod).OrderedAmount.ToString();//new buyingDetailsDB().GetList().FirstOrDefault(x => x.KodProduct == pp.Kod && x.TelClient == Validation.telUser && x.SaleKodProductsOfBuyingDetails().SalesOfSaleProduct().Distribution).OrderedAmount.ToString(); // //new buyingDetailsDB().GetList().FirstOrDefault(x => x.KodProduct == pp.Kod && x.TelClient == Validation.telUser && x.SaleKodProductsOfBuyingDetails().SalesOfSaleProduct().Distribution)//
                lblAmount.Text = Validation.lstSAL.FirstOrDefault(x => x.KodProduct == pp.Kod).OrderedAmount.ToString();//new buyingDetailsDB().GetList().FirstOrDefault(x => x.KodProduct == pp.Kod && x.TelClient == Validation.telUser && x.SaleKodProductsOfBuyingDetails().SalesOfSaleProduct().Distribution).OrderedAmount.ToString(); //Validation.lstSAL.FirstOrDefault(x => x.KodProduct == pp.Kod && x.TelClient ==  //Validation.telUser && x.SaleKodProductsOfBuyingDetails().SalesOfSaleProduct().Distribution).OrderedAmount.ToString(); 
            }
            else
                lblOrder.Visible = false;
            return b;
        }

        private int CheckAmount()
        {
            sp = lstSaleProdeuct.GetList().FirstOrDefault(x => x.kodProduct == pp.Kod && x.SalesOfSaleProduct().Distribution);

            int sucAll = new buyingDetailsDB().GetList().Where(x => x.KodProduct == pp.Kod && x.KodSale == sp.KodSale).Sum(x => x.OrderedAmount);
            if (sucAll >= sp.MaximumAmount)
            {
                //הודעה אזל מהמלאי
                lblAzal.Visible = true;
                btnAdd.Visible = false;
            }
            return sp.maximumAmount - sucAll;

        }

        private void btnX_Click(object sender, EventArgs e)
        {
            Control c = this.Parent;
            while (!(c is UCNowSale))
                c = c.Parent;
            (c as UCNowSale).panelDetails.Visible = false;
        }
        buyingDetails bd;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            int am = CheckAmount();//הכמות שנותרה להזמנה
            //אם הכמות שנותרה
            if (Convert.ToInt32(lblAmount.Text) > am)
            {
                MessageBox.Show("אין מספיק במלאי,\nהמקסימום להזמנה הוא " + am.ToString());
                lblAmount.Text = am.ToString();
            }
            foreach (var item in Validation.lstSAL)
            {
                if (item.KodProduct == pp.Kod)
                    bd = item;
            }
            if (bd == null)
            {
                buyingDetails b = new buyingDetails();
                b.TelClient = Validation.telUser;
                b.KodProduct = pp.Kod;
                b.KodSale = new salesDB().GetList().First(x => x.Distribution == true).Kod;
                b.OrderedAmount = Convert.ToInt32(lblAmount.Text);
                b.TotalForProduct = Convert.ToInt32(lblAmount.Text) * Convert.ToInt32(lblPrice.Text);
                b.GetAmount = 0;
                Validation.lstSAL.Add(b);
                if (up1 != null)
                {
                    up1.lblOrder.Text = "הזמנת " + b.OrderedAmount;
                    up1.lblOrder.Visible = true;
                }
                MessageBox.Show("המוצר נוסף לסל בהצלחה!");
            }
            else
            {
                bd.OrderedAmount = Convert.ToInt32(lblAmount.Text);
                bd.TotalForProduct = Convert.ToInt32(lblAmount.Text) * Convert.ToInt32(lblPrice.Text);
                Validation.lstSAL.FirstOrDefault(x => x.KodProduct == pp.Kod).OrderedAmount = bd.OrderedAmount;
                Validation.lstSAL.FirstOrDefault(x => x.KodProduct == pp.Kod).TotalForProduct = bd.TotalForProduct;
                if (up1 != null)
                {
                    up1.lblOrder.Visible = true;
                    up1.lblOrder.Text = "הזמנת " + bd.OrderedAmount;
                }
                MessageBox.Show("הכמות עודכנה בהצלחה!");
            }

            Control c = this.Parent;
            while (!(c is UCNowSale))
                c = c.Parent;
            (c as UCNowSale).panelDetails.Visible = false;
        }
        int amount = 1;
        private void button2_Click(object sender, EventArgs e)
        {
            if (!lblAzal.Visible)
            {
                amount = Convert.ToInt32(lblAmount.Text);
                amount++;
                lblAmount.Text = amount.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (new buyingDetailsDB().GetList().FirstOrDefault(x => x.TelClient == Validation.telUser && (new salesDB().GetList().FirstOrDefault(a => a.Distribution) != null) && x.KodProduct == pp.Kod) == null)
            {
                if (Convert.ToInt32(lblAmount.Text) > 1 && !lblAzal.Visible)
                {
                    amount = Convert.ToInt32(lblAmount.Text);
                    amount--;
                    lblAmount.Text = amount.ToString();
                }
            }
            else
            {
                if(new buyingDetailsDB().GetList().FirstOrDefault(x => x.TelClient == Validation.telUser && (new salesDB().GetList().FirstOrDefault(a => a.Distribution) != null) && x.KodProduct == pp.Kod).OrderedAmount==Convert.ToInt32(lblAmount.Text))
                    MessageBox.Show("לא ניתן להוריד כמות הזמנה ממוצר שהוזמן ושולם");
                else
                {
                    if (Convert.ToInt32(lblAmount.Text) > 1 && !lblAzal.Visible)
                    {
                        amount = Convert.ToInt32(lblAmount.Text);
                        amount--;
                        lblAmount.Text = amount.ToString();
                    }
                }
            }
        }
        bool b = false;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (!b)
            {
                pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
                b = true;
            }
            else
            {
                pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                b = false;
            }
        }
    }
}
