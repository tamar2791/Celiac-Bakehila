using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace celiacBakehila.BLL
{
    public class buy
    {
        private int kodSale;
        private string telClient;
        private DateTime dateSale;
        private double totalPrice;
        private bool status;
        private DataRow dr;
        public buy()
        {
        }
        public buy(DataRow dr) : this()
        {
            this.dr = dr;
            this.kodSale = Convert.ToInt32(dr["kodSale"]);
            this.telClient = dr["telClient"].ToString();
            this.dateSale = Convert.ToDateTime(dr["dateSale"]);
            this.totalPrice = Convert.ToDouble(dr["totalPrice"]);
            this.status = Convert.ToBoolean(dr["status"]);
        }
        public void PutInto()
        {
            dr["kodSale"] = kodSale;
            dr["telClient"] = telClient;
            dr["dateSale"] = dateSale;
            dr["totalPrice"] = totalPrice;
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
        public DateTime DateSale { get => dateSale; set => dateSale = value; }
        public double TotalPrice
        { get => totalPrice; set
            {
                if (!Validation.IsNum((value).ToString()))
                    throw new Exception("מספרים בלבד"); totalPrice = value;
            }
        }
        public bool Status { get => status; set => status = value; }
        public DataRow Dr { get => dr; set => dr = value; }
        public sales SalesOfBuy()
        {
            return new salesDB().SearchId(this.kodSale);
        }
        public client ClientOfBuy()
        {
            return new clientDB().SearchId(this.TelClient);
        }
    }
}
