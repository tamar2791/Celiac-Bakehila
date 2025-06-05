using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using celiacBakehila.BLL;

namespace celiacBakehila.GUI
{
    public partial class UCSales : UserControl
    {
        public UCSales()
        {
            InitializeComponent();
            tblProducts = new productsDB();
            tblBuy = new buyDB();
            tblSales = new salesDB();
            dataGridView1.DataSource = tblBuy.GetList().Where(x => x.TelClient == Validation.telUser).Select(x => new {קוד_מכירה=x.KodSale,תאריך_מכירה=x.DateSale,סך_הכל_לתשלום=x.TotalPrice}).ToList();
        }
        productsDB tblProducts;
        buyDB tblBuy;
        salesDB tblSales;
        bool b=false;
        private void btnSaleNow_Click(object sender, EventArgs e)
        {
            lblNowPas.Visible = true;
            lblOldPas.Visible = false;
            this.ParentForm.Text = "צליאק בקהילה-משתמש-מכירות-מכירה נוכחית";
            if (new buyingDetailsDB().GetList().FirstOrDefault(x => x.BuyTZOfBuyingDetails().TelClient == Validation.telUser && x.SaleProductOfBuyingDetails().SalesOfSaleProduct().Distribution) != null)
                label1.Visible = true;
            else
                label1.Visible = false;
            foreach (sales item in tblSales.GetList())
            {
                if(item.Distribution==true)
                {
                    b = true;
                    panelMain.Visible = true;
                    panel1.Visible = false;
                    UCNowSale uc = new UCNowSale(item.Kod);
                    panelMain.Controls.Add(uc);
                    uc.Dock = DockStyle.Fill;
                    break;
                }
            }
            if (!b)
            { 
                dataGridView1.Visible = false;
                MessageBox.Show("אין כרגע מכירה פעילה במערכת");
            }
        }
        private void btnOldSales_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            lblNowPas.Visible = false;
            lblOldPas.Visible = true;
            this.ParentForm.Text = "צליאק בקהילה-משתמש-מכירות-מכירות קודמות";
            foreach(Control item in panelMain.Controls)
            {
                if(item is UCNowSale)
                    panelMain.Controls.Remove(item);
            }
            panel1.Visible = true;
        }
        buyingDetailsDB tblBuyingDetails = new buyingDetailsDB();
        bool bbbb = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if(!bbbb)
            { 
                int kod = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                dataGridView2.DataSource = tblBuyingDetails.GetList().Where(x => x.KodSale == kod && x.TelClient == Validation.telUser).Select(x => new {קוד_מכירה=x.KodSale,מוצר=x.ProductsOfBuyingDetails().NameProduct,כמות=x.OrderedAmount,סך_הכל_למוצר=x.TotalForProduct}).ToList();
                dataGridView2.Visible = true;
                dataGridView1.Visible = false;
                button1.Text = "סגור";
                bbbb = true;
            }
            else
            {
                button1.Text = "הצגת פרטי הזמנה";
                dataGridView1.Visible = true;
                dataGridView2.Visible = false;
                bbbb = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView2.Visible=false;
            dataGridView1.Visible=true;
            button2.Visible = true;
            button1.Visible = true;
        }
    }
}
