using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;
using System.Net.Sockets;
using celiacBakehila;

namespace celiacBakehila.BLL
{
    public class products
    {
        private int kod;
        private int category;
        private string nameProduct;
        private double cellingPrice;
        private double buyingPrice;
        private bool status;
        private bool ifNew;
        private string supplier;
        private string picture;
        private DataRow dr;
        public products()
        {
        }
        public products(DataRow dr) : this()
        {
            this.dr = dr;
            this.kod = Convert.ToInt32 (dr["kod"]);
            this.category = Convert.ToInt32(dr["category"]);
            this.nameProduct = dr["nameProduct"].ToString();
            this.cellingPrice = Convert.ToDouble(dr["cellingPrice"]);
            this.buyingPrice = Convert.ToDouble(dr["buyingPrice"]);
            this.status = Convert.ToBoolean(dr["status"]);
            this.ifNew = Convert.ToBoolean(dr["new"]);
            this.Supplier = dr["supplier"].ToString();
            this.Picture = dr["picture"].ToString();
        }
        public void PutInto()
        {
            dr["kod"] = kod;
            dr["category"] = category;
            dr["nameProduct"] = nameProduct;
            dr["cellingPrice"] = cellingPrice;
            dr["buyingPrice"] = buyingPrice;
            dr["status"] = status;
            dr["new"] = ifNew;
            dr["supplier"] = Supplier;
            dr["picture"] = Picture;
        }
        public int Kod
        { get => kod; set
            {
                if (!Validation.IsNum(value.ToString()))
                    throw new Exception("מספרים בלבד!");  kod = value;
            }
        }
        public int Category{ get => category; set => category = value;}

        public string NameProduct
        { get => nameProduct; set
            {
                if (!Validation.IsHebrew(value))
                    throw new Exception("עברית בלבד!"); nameProduct = value;
            }
        }
        public double CellingPrice
        { get => cellingPrice; set
            {
                if (!Validation.IsNumDouble(value.ToString()))
                    throw new Exception("מספרים בלבד!"); cellingPrice = value;
            }
        }
        public double BuyingPrice
        { get => buyingPrice; set
            {
                if (!Validation.IsNumDouble(value.ToString()))
                    throw new Exception("מספרים בלבד!"); buyingPrice = value;
            }
        }
        public bool Status { get => status; set=> status = value;}
        public bool IfNew { get => ifNew; set => ifNew = value; }

        public DataRow Dr { get => dr; set => dr = value; }
        public string Supplier { get => supplier; set => supplier = value; }
        public string Picture { get => picture; set => picture = value; }

        public suppliers SuppliersOfProduct()
        {
            return new suppliersDB().SearchId(this.Supplier);
        }
        public category CategoryOfProduct()
        {
            return new categoryDB().SearchId(this.category);
        }
        public override string ToString()
        {
            return this.nameProduct;
        }
    }
}
