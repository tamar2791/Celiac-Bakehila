using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace celiacBakehila.BLL
{
    public class buyingDetails
    {
        private int kodSale;
        private string telClient;
        private int kodProduct;
        private int orderedAmount;
        private int getAmount;
        private int totalForProduct;
        private bool status;
        private DataRow dr;
        public buyingDetails()
        {
        }
        public buyingDetails(DataRow dr) : this()
        {
            this.dr = dr;
            this.kodSale = Convert.ToInt32(dr["kodSale"]);
            this.telClient = dr["telClient"].ToString();
            this.kodProduct = Convert.ToInt32(dr["kodProduct"]);
            this.orderedAmount = Convert.ToInt32(dr["orderedAmount"]);
            this.getAmount = Convert.ToInt32(dr["getAmount"]);
            this.totalForProduct = Convert.ToInt32(dr["totalForProduct"]);
            this.status = Convert.ToBoolean(dr["status"]);

        }
        public void PutInto()
        {
            dr["kodSale"] = kodSale;
            dr["telClient"] = telClient;
            dr["kodProduct"] = kodProduct;
            dr["orderedAmount"] = orderedAmount;
            dr["getAmount"] = getAmount;
            dr["totalForProduct"] = totalForProduct;
            dr["status"] = status;
        }
        public int KodSale
        { get => kodSale; set
            {
                if (!Validation.IsNum((value).ToString()))
                    throw new Exception("מספרים בלבד"); kodSale = value;
            }
        }
        public string TelClient
        { get => telClient; set
            {
                if (!Validation.IsTel(value))
                    throw new Exception("טלפון לא תקין!"); telClient = value;
            }
        }
        public int KodProduct
        { get => kodProduct; set
            {
                if (!Validation.IsNum((value).ToString()))
                    throw new Exception("מספרים בלבד"); kodProduct = value;
            }
        }
        public int OrderedAmount
        { get => orderedAmount; set
            {
                if (!Validation.IsNum((value).ToString()))
                    throw new Exception("מספרים בלבד"); orderedAmount = value;
            }
        }
        public int GetAmount
        { get => getAmount; set
            {
                if (!Validation.IsNum((value).ToString()))
                    throw new Exception("מספרים בלבד"); getAmount = value;
            }
        }
        public int TotalForProduct
        { get => totalForProduct; set
            {
                if (!Validation.IsNum((value).ToString()))
                    throw new Exception("מספרים בלבד"); totalForProduct = value;
            }
        }
        public bool Status { get => status; set => status = value; }
        public DataRow Dr { get => dr; set => dr = value; }
        public products ProductsOfBuyingDetails()
        {
            return new productsDB().SearchId(this.kodProduct);
        }
        public saleProducts SaleKodProductsOfBuyingDetails()
        {
            return new saleProductsDB().SearchKodProduct(this.kodProduct);
        }
        public saleProducts SaleProductOfBuyingDetails()
        {
            return new saleProductsDB().SearchKodSale(this.kodSale);
        }
        public buy buyKodOfBuyingDetails()
        {
            return new buyDB().SearchKodSale(this.kodSale);
        }
        public buy BuyTZOfBuyingDetails()
        {
            return new buyDB().SearchId(this.telClient);
        }
        
    }
}
