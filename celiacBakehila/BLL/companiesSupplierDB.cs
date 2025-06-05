using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace celiacBakehila.BLL
{
    internal class companiesSupplierDB:GeneralDB
    {
        List<companiesSupplier> listcompaniesSupplier = new List<companiesSupplier>();
        public companiesSupplierDB() : base("tbl_companiesSupplier") { }
        public List<companiesSupplier> GetList()
        {
            listcompaniesSupplier.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                listcompaniesSupplier.Add(new companiesSupplier(dr));
            }
            return listcompaniesSupplier;
        }
        public void AddNew(companiesSupplier c)
        {
            c.Dr = dt.NewRow();
            c.PutInto();
            this.dt.Rows.Add(c.Dr);
            this.Update();
        }
        public companiesSupplier SearchId(string tz)
        {
            return GetList().Find(x => x.TzSupplier == tz);
        }
        public void ApdateRow(companiesSupplier c)
        {
            c.PutInto();
            this.Update();
        }
    }
}
