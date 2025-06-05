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
    public partial class UCOneProduct : UserControl
    {
        products p;
        productsDB lstProduct;
        saleProducts sp;
        public UCOneProduct(products p)
        {
            InitializeComponent();
            lstProduct = new productsDB();
            this.p = p;
            lblName.Text = p.NameProduct;
        }

        public UCOneProduct(saleProducts sp):this(sp.ProductsOfSaleProduct())
        {
            this.sp = sp;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            sp=new saleProducts();

            if (btnAdd.Text == "הוספת המוצר")
            {
                Control c = this.Parent;
                while (!(c is UCSaleProduct))
                    c = c.Parent;
                (c as UCSaleProduct).flowLayoutPanel2.Controls.Add(this);
                (c as UCSaleProduct).label5.Visible = false;
                sp.KodProduct = p.Kod;
                sp.maximumAmount =Convert.ToInt32( numericUpDown1.Value);
                sp.Status = true;
                Validation.lstP.Add(sp);
                btnAdd.Text = "הסר";
                this.btnAdd.Width = 50;
                this.numericUpDown1.Width = 50;
                this.Width = 380;
            }
            else
            {
                int count = 0;
                btnAdd.Text = "הוספת המוצר";
                (this.Parent.Parent as UCSaleProduct).flowLayoutPanel1.Controls.Add(this);
                if ((this.Parent.Parent as UCSaleProduct).flowLayoutPanel2.Controls.Count==0)
                    (this.Parent.Parent as UCSaleProduct).label5.Visible = true;
                this.Parent.Controls.Remove(this);
                Validation.lstP.Remove(Validation.lstP.FirstOrDefault(x=>x.kodProduct==p.Kod));
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

            if (btnAdd.Text == "הסר")
            {
                sp.MaximumAmount =Convert.ToInt32( numericUpDown1.Value);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
