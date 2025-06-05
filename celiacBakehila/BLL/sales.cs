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
    public class sales
    {
        private int kod;
        private DateTime dateSale;
        private string status;
        private bool distribution;
        private string place;
        private DataRow dr;

        public sales()
        {
        }
        public sales(DataRow dr) : this()
        {
            this.dr = dr;
            this.kod = Convert.ToInt32(dr["kod"]);
            this.dateSale = Convert.ToDateTime(dr["dateSale"]);
            this.status = dr["status"].ToString();
            this.distribution = Convert.ToBoolean(dr["distribution"]);
            this.place = dr["place"].ToString();
        }
        public void PutInto()
        {
            dr["kod"] = kod;
            dr["dateSale"] = dateSale;
            dr["status"] = status;
            dr["distribution"] = distribution;
            dr["place"] = place;
        }
        public int Kod
        {
            get => kod; set
            {
                if (!Validation.IsNum(value.ToString()))
                    throw new Exception("מספרים בלבד!"); kod = value;
            }
        }
        public DateTime DateSale { get => dateSale; set => dateSale = value; }
        public string Status
        {
            get => status; set
            {
                if (!Validation.IsHebrew(value))
                    throw new Exception("עברית בלבד!"); status = value;
            }
        }
        public bool Distribution { get => distribution; set => distribution = value; }
        public string Place
        {
            get => place; set
            {
                if (!Validation.IsHebrew(value))
                    throw new Exception("עברית בלבד!"); place = value;
            }
        }      
                    
                
        public DataRow Dr { get => dr; set => dr = value; }
    }
}
