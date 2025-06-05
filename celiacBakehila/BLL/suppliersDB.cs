using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace celiacBakehila.BLL
{
    internal class suppliersDB:GeneralDB
    {
        List<suppliers> listsuppliers = new List<suppliers>();
        public suppliersDB() : base("tbl_suppliers") { }
        public List<suppliers> GetList()
        {
            listsuppliers.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                listsuppliers.Add(new suppliers(dr));
            }
            return listsuppliers;
        }
        public void AddNew(suppliers s)
        {
            s.Dr = dt.NewRow();
            s.PutInto();
            this.dt.Rows.Add(s.Dr);
            this.Update();
        }
        public suppliers SearchId(string tz)
        {
            return GetList().Find(x => x.TzSupplier == tz);
        }
        public void ApdateRow(suppliers s)
        {
            s.PutInto();
            this.Update();
        }
    }
}
