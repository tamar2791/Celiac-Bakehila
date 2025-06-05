using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Net.Sockets;

namespace celiacBakehila.BLL
{
    internal class companiesSupplier
    {
        private string tzSupplier;
        private int kodCompany;
        private DataRow dr;

        public companiesSupplier()
        {
        }
        public companiesSupplier(DataRow dr) : this()
        {
            this.dr = dr;
            this.tzSupplier = dr["tzSupplier"].ToString();
            this.kodCompany = Convert.ToInt32(dr["kodCompany"]);
        }
        public void PutInto()
        {
            dr["tzSupplier"] = tzSupplier;
            dr["kodCompany"] = kodCompany;
        }
        public string TzSupplier
        { get => tzSupplier; set
            {
                if (!Validation.CheckId(value))
                    throw new Exception("ת.ז. לא תקינה!"); tzSupplier = value;
            }
        }
        public int KodCompany
        { get => kodCompany; set
            {
                if (!Validation.IsNum(value.ToString()))
                    throw new Exception("מספרים בלבד!"); kodCompany = value;
            }
        }
        public DataRow Dr { get => dr; set => dr = value; }
    }
}
