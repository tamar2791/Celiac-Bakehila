using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Net.Sockets;

namespace celiacBakehila.BLL
{
    public class cities
    {
        private int kod;
        private string nameCity;
        private bool status;
        private DataRow dr;
        public cities()
        {
        }
        public cities(DataRow dr) : this()
        {
            this.dr = dr;
            this.kod = Convert.ToInt32(dr["kod"]);
            this.nameCity = dr["nameCity"].ToString();
            this.status = Convert.ToBoolean(dr["status"]);
        }
        public void PutInto()
        {
            dr["kod"] = kod;
            dr["nameCity"] = nameCity;
            dr["status"] = status;
        }
        public int Kod
        { get => kod; set
            {
                if (!Validation.IsNum((value).ToString()))
                    throw new Exception("מספרים בלבד"); kod = value;
            }
        }
        public string NameCity
        { get => nameCity; set
            {
                if (!Validation.IsHebrew(value))
                    throw new Exception("עברית בלבד!"); nameCity = value;
            }
        }
        public DataRow Dr { get => dr; set => dr = value; }
        public bool Status { get => status; set => status = value; }

        public override string ToString()
        {
            return this.nameCity;
        }
    }
}
