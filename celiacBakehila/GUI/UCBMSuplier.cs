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
    public partial class UCBMSuplier : UserControl
    {
        suppliersDB tblSuppliers;
        productsDB tblProducts;
        buyingDetailsDB tblBuyingDetails;
        suppliers s;
        bool b = false;
        public UCBMSuplier()
        {
            InitializeComponent();
            tblProducts = new productsDB();
            tblSuppliers = new suppliersDB();
            tblBuyingDetails = new buyingDetailsDB();
            List<suppliers> suppliers = new List<suppliers>();
            foreach (buyingDetails item in tblBuyingDetails.GetList().Where(x => x.BuyTZOfBuyingDetails().ClientOfBuy().BranchesOfClient().branchManagerOfBranches().TelManager == Validation.telBranchManager).ToList())
            {
                s = tblSuppliers.SearchId(tblProducts.GetList().FirstOrDefault(x => x.Kod == item.KodProduct).Supplier);
                foreach (suppliers ss in suppliers)
                {
                    if (ss.TzSupplier == s.TzSupplier)
                        b = true;
                }
                if (!b)
                    suppliers.Add(s);
            }
            dataGridView1.DataSource = suppliers.Where(x => x.Status == true).Select(x => new { תעודת_זהות_ספק = x.TzSupplier, שם_ספק = x.NameSupplier, טלפון = x.Phone, פלאפון = x.CellPhone, מייל = x.Mail }).ToList();
        }
        bool f = false;
        private void btnProduct_Click(object sender, EventArgs e)
        {
            if (!f)
            {
                string tz = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                s = tblSuppliers.SearchId(tz);
                dataGridView2.DataSource = tblProducts.GetList().Where(x => x.SuppliersOfProduct().TzSupplier == s.TzSupplier&& x.Status == true&&tblBuyingDetails.SearchKodProduct(x.Kod)!=null).Select(x => new { קוד_מוצר = x.Kod, קטגוריה = x.CategoryOfProduct().DescribeCategory, שם_מוצר = x.NameProduct, מחיר_קניה = x.BuyingPrice, מחיר_מכירה = x.CellingPrice, חדש = x.IfNew }).ToList();
                dataGridView2.Visible = true;
                f = true;
                btnProduct.Text = "סגור";
                dataGridView1.Visible= false;
            }
            else
            {
                dataGridView2.Visible = false;
                f = false;
                dataGridView1.Visible = true;
                btnProduct.Text = "הצגת מוצרים לספק";
            }
        }

        
    }
}
