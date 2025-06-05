using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;
using System.Net.Sockets;

namespace celiacBakehila.BLL
{
    public class saleProducts
    {
        public int kodProduct;
        public int kodSale;
        public int maximumAmount;
        private bool status;
        private int familyRestriction;
        private double SellingPrice;
        private double buyingPrice;
        private DataRow dr;
        public saleProducts()
        {
        }
        public saleProducts(DataRow dr) : this()
        {
            this.dr = dr;
            this.kodProduct = Convert.ToInt32(dr["kodProduct"]);
            this.kodSale = Convert.ToInt32(dr["kodSale"]);
            this.maximumAmount = Convert.ToInt32(dr["maximumAmount"]);
            this.status = Convert.ToBoolean(dr["status"]);
            this.familyRestriction = Convert.ToInt32(dr["familyRestriction"]);
            this.SellingPrice = Convert.ToInt32(dr["SellingPrice"]);
            this.buyingPrice = Convert.ToInt32(dr["buyingPrice"]);

        }
        public void PutInto()
        {
            dr["kodProduct"] = kodProduct;
            dr["kodSale"] = kodSale;
            dr["maximumAmount"] = maximumAmount;
            dr["status"] = status;
            dr["familyRestriction"] = familyRestriction;
            dr["SellingPrice"] = SellingPrice;
            dr["buyingPrice"] = buyingPrice;
        }
        public int KodProduct
        { get => kodProduct; set
            {
                if (!Validation.IsNum(value.ToString()))
                    throw new Exception("מספרים בלבד!"); kodProduct = value;
            }
        }
        public int KodSale
        { get => kodSale; set
            {
                if (!Validation.IsNum(value.ToString()))
                    throw new Exception("מספרים בלבד!"); kodSale = value;
            }
        }
        public int MaximumAmount
        { get => maximumAmount; set
            {
                if (!Validation.IsNum(value.ToString()))
                    throw new Exception("מספרים בלבד!"); maximumAmount = value;
            }
        }
        public bool Status { get => status; set => status = value; }
        public int FamilyRestriction
        { get => familyRestriction; set
            {
                if (!Validation.IsNum(value.ToString()))
                    throw new Exception("מספרים בלבד!"); familyRestriction = value;
            }
        }
        public double SellingPrice1
        { get => SellingPrice; set
            {
                if (!Validation.IsNum(value.ToString()))
                    throw new Exception("מספרים בלבד!"); SellingPrice = value;
            }
        }
        public double BuyingPrice
        { get => buyingPrice; set
            {
                if (!Validation.IsNum(value.ToString()))
                    throw new Exception("מספרים בלבד!"); buyingPrice = value;
            }
        }
        public DataRow Dr { get => dr; set => dr = value; }
        public products ProductsOfSaleProduct()
        {
            return new productsDB().SearchId(this.kodProduct);
        }
        public sales SalesOfSaleProduct()
        {
            return new salesDB().SearchId(this.kodSale);
        }
    }
}
