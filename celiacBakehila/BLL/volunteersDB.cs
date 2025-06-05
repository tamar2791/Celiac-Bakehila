using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace celiacBakehila.BLL
{
    internal class volunteersDB:GeneralDB
    {
        List<volunteers> listvolunteers = new List<volunteers>();
        public volunteersDB() : base("tbl_volunteers") { }
        public List<volunteers> GetList()
        {
            listvolunteers.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                listvolunteers.Add(new volunteers(dr));
            }
            return listvolunteers;
        }
        public void AddNew(volunteers v)
        {
            v.Dr = dt.NewRow();
            v.PutInto();
            this.dt.Rows.Add(v.Dr);
            this.Update();
        }
        public volunteers SearchId(string tel)
        {
            return GetList().Find(x => x.Tel == tel);
        }
        public void ApdateRow(volunteers v)
        {
            v.PutInto();
            this.Update();
        }
    }
}
