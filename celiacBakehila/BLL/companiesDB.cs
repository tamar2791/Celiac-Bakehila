using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace celiacBakehila.BLL
{
    internal class companiesDB:GeneralDB
    {
        List<companies> listcompanies = new List<companies>();
        public companiesDB() : base("tbl_companies") { }
        public List<companies> GetList()
        {
            listcompanies.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                listcompanies.Add(new companies(dr));
            }
            return listcompanies;
        }
        public void AddNew(companies c)
        {
            c.Dr = dt.NewRow();
            c.PutInto();
            this.dt.Rows.Add(c.Dr);
            this.Update();
        }
        public companies SearchId(int kod)
        {
            return GetList().Find(x => x.Kod == kod);
        }
        public void ApdateRow(companies c)
        {
            c.PutInto();
            this.Update();
        }
    }
}
