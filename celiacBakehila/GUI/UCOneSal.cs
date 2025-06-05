using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using celiacBakehila.BLL;

namespace celiacBakehila.GUI
{
    public partial class UCOneSal : UserControl
    {
        buyingDetails b;
        UCOneProductClient up1;
        public UCOneSal(buyingDetails b,UCOneProductClient up=null)
        {
            InitializeComponent();
            lblName.Text = b.ProductsOfBuyingDetails().NameProduct;
            lblAmount.Text = b.OrderedAmount.ToString();
            lblPrice.Text = (b.ProductsOfBuyingDetails().CellingPrice* b.OrderedAmount).ToString();
            string a = Directory.GetParent(Directory.GetCurrentDirectory()).ToString();
            string c = Directory.GetParent(a).ToString();//שמירת נתיב ללא debug                                                   
            c = c + @"\pictures\";//שרשור שם התיקיה המקומית של התמונות
            c = c + b.ProductsOfBuyingDetails().Picture;//שרשור שם התמונה המבוקשת באמצעות שימוש בעצם ובתכונות המחלקה
            pictureBox1.Image = Image.FromFile(c);
            pictureBox1.BackgroundImageLayout = ImageLayout.Center;
            this.b = b;
            up1 = up;

        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (new buyingDetailsDB().GetList().FirstOrDefault(x => x.TelClient == b.TelClient && x.KodSale == b.KodSale && x.KodProduct == b.KodProduct) == null)
            {
                Control c = this.Parent;
                while (!(c is UCSal))
                    c = c.Parent;
                (c as UCSal).flowLayoutPanel1.Controls.Remove(this);
                MessageBox.Show("המוצר הוסר מהסל בהצלחה");
                if ((c as UCSal).flowLayoutPanel1.Controls.Count <= 0)
                {
                    (c as UCSal).lblEmpty2.Visible = true;
                    (c as UCSal).lblEmpty.Visible = true;
                    (c as UCSal).btnClose.Visible = false;
                }
                else
                {
                    (c as UCSal).lblEmpty2.Visible = false;
                    (c as UCSal).lblEmpty.Visible = false;
                    (c as UCSal).btnClose.Visible = true;
                }
                Validation.lstSAL.Remove(b);//מוחק מהרשימה הזמנית
                if (up1 != null)
                    up1.lblOrder.Visible = false;
                while (!(c is UCNowSale))
                    c = c.Parent;
                foreach (UCOneProductClient item in (c as UCNowSale).flowLayoutPanel1.Controls)
                {
                    if (Convert.ToInt32((item as UCOneProductClient).label2.Text) == b.KodProduct)
                    {
                        (item as UCOneProductClient).lblOrder.Visible = false;
                        break;
                    }
                }
            }
            else
                MessageBox.Show("לא ניתן למחוק מוצר ששילמו עליו");
        }
    }
}
