using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Net.Sockets;

namespace celiacBakehila.BLL
{
    internal class companies
    {
        private int kod;
        private string nameSociety;
        private string supplier;
        private DataRow dr;
        public companies()
        {
        }
        public companies(DataRow dr) : this()
        {
            this.dr = dr;
            this.kod = Convert.ToInt32(dr["kod"]);
            this.nameSociety = dr["nameSociety"].ToString();
            this.supplier = dr["supplier"].ToString();
        }
        public void PutInto()
        {
            dr["kod"] = kod;
            dr["nameSociety"] = nameSociety;
            dr["supplier"] = supplier;
        }
        public int Kod
        { get => kod; set
            {
                if (!Validation.IsNum(value.ToString()))
                    throw new Exception("מספרים בלבד!"); kod = value;
            }
        }
        public string NameSociety
        { get => nameSociety; set
            {
                if (!Validation.IsHebrew(value))
                    throw new Exception("עברית בלבד!"); nameSociety = value;
            }
        }
        public string Supplier
        { get => supplier; set
            {
                if (!Validation.IsHebrew(value))
                    throw new Exception("עברית בלבד!"); supplier = value;
            }
        }
        public DataRow Dr { get => dr; set => dr = value; }
        public suppliers SuppliersOfCompany()
        {
            return new suppliersDB().SearchId(this.supplier);
        }
    }
}
