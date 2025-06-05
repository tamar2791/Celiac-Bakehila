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
    public partial class UCBMProduct : UserControl
    {
        clientDB tblClient;
        productsDB tblProduct;
        buyingDetailsDB tblBuyingDetails;
        List<products> products = new List<products>();
        List<client> clients = new List<client>();
        bool b = false;
        public UCBMProduct()
        {
            InitializeComponent();
            tblProduct = new productsDB();
            tblBuyingDetails = new buyingDetailsDB();
            tblClient = new clientDB();
            foreach (products item in tblProduct.GetList().Where(x => x.Status == true))
            {
                foreach (buyingDetails bb in tblBuyingDetails.GetList().Where(x => x.BuyTZOfBuyingDetails().ClientOfBuy().BranchesOfClient().branchManagerOfBranches().TelManager == Validation.telBranchManager&&x.SaleProductOfBuyingDetails().SalesOfSaleProduct().Distribution))
                {
                    if (bb.KodProduct == item.Kod)
                        b = true;
                }
                if (b)
                    products.Add(item);
                b = false;
            }
            dataGridView1.DataSource = products.Select(x => new { קוד_מוצר = x.Kod, שם_מוצר = x.NameProduct, קטגוריה = x.CategoryOfProduct().DescribeCategory, מחיר_קניה = x.BuyingPrice, מחיר_מכירה = x.CellingPrice, ספק = x.SuppliersOfProduct().NameSupplier, חדש = x.IfNew }).ToList();

        }

        private void Amount(int kod)
        {
            int sum = 0;
            foreach (buyingDetails item in tblBuyingDetails.GetList())
            {
                if (item.KodProduct == kod)
                    sum += item.OrderedAmount;
            }
            lblAmount.Text = sum.ToString();
            lblAmount.Visible = true;
            label2.Visible = true;
        }

        bool bb = false;
        private void btnAllProduct_Click(object sender, EventArgs e)
        {
            if (!bb)
            {
                dataGridView1.DataSource = tblProduct.GetList().Where(x => x.Status == true).Select(x => new { קוד_מוצר = x.Kod, שם_מוצר = x.NameProduct, קטגוריה = x.CategoryOfProduct().DescribeCategory, מחיר_קניה = x.BuyingPrice, מחיר_מכירה = x.CellingPrice, ספק = x.SuppliersOfProduct().NameSupplier, חדש = x.IfNew }).ToList();
                label1.Text = "שים לב! זוהי רשימה של כל המוצרים, להצגת רשימת המוצרים שלקוחות בסניף זה הזמינו במכירה זו";
                bb = true;
                btnClient.Visible = false;
                label2.Visible = false;
                lblAmount.Visible = false;
            }
            else
            {
                dataGridView1.DataSource = products.Select(x => new { קוד_מוצר = x.Kod, שם_מוצר = x.NameProduct, קטגוריה = x.CategoryOfProduct().DescribeCategory, מחיר_קניה = x.BuyingPrice, מחיר_מכירה = x.CellingPrice, ספק = x.SuppliersOfProduct().NameSupplier, חדש = x.IfNew }).ToList();
                label1.Text = "שים לב! זוהי רשימת המוצרים שלקוחות בסניף זה הזמינו במכירה זו, להצגת רשימת כל המוצרים ";
                bb = false;
            }
        }


        bool bbb = false;
        private void btnClient_Click(object sender, EventArgs e)
        {
            if (!bbb)
            {
                int kod = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                Client(kod);
                btnClient.Text = "סגור";
                bbb = true;
                dataGridView1.Visible = false;
                label2.Visible = false;
                label1.Visible = false;
                lblAmount.Visible = false;
                btnAllProduct.Visible = false;
            }
            else
            {
                dataGridView2.Visible = false;
                btnClient.Text = "הצגת רשימת הלקוחות שהזמינו מוצר זה";
                bbb = false;
                dataGridView1.Visible = true;
                label2.Visible = true;
                label1.Visible = true;
                lblAmount.Visible = true;
                btnAllProduct.Visible = true;
                clients.Clear();
            }
        }

        private void Client(int kod)
        {
            clients.Clear();
            foreach (buyingDetails item in tblBuyingDetails.GetList().Where(x => x.KodProduct == kod && x.BuyTZOfBuyingDetails().ClientOfBuy().BranchesOfClient().branchManagerOfBranches().TelManager == Validation.telBranchManager))
            {
                clients.Add(tblClient.SearchId(item.TelClient));
            }
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = clients.Select(x => new {טלפון=x.Tel,פלאפון=x.Pel,שם_האב=x.NameFather,שם_האם=x.NameMother,שם_משפחה=x.LastName,מספר_ילדים=x.Child,עיר=x.CitiesOfClient().NameCity,רחוב=x.Street,מספר_בנין=x.HouseNumber,מייל=x.Mail}).ToList();
            dataGridView2.Visible = true;

        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            Amount(kod);
            btnClient.Visible = true;
        }
    }
}
