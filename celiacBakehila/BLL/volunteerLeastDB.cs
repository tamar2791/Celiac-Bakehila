using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace celiacBakehila.BLL
{
    internal class volunteerLeastDB:GeneralDB
    {
        List<volunteerLeast> listvolunteerLeast = new List<volunteerLeast>();
        public volunteerLeastDB() : base("tbl_volunteerLeast") { }
        public List<volunteerLeast> GetList()
        {
            listvolunteerLeast.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                listvolunteerLeast.Add(new volunteerLeast(dr));
            }
            return listvolunteerLeast;
        }
        public void AddNew(volunteerLeast v)
        {
            v.Dr = dt.NewRow();
            v.PutInto();
            this.dt.Rows.Add(v.Dr);
            this.Update();
        }
        public volunteerLeast SearchId(int kod)
        {
            return GetList().Find(x => x.KodSale == kod);
        }
        public volunteerLeast SearchTzVolunteers(string tz)
        {
            return GetList().Find(x => x.TelVolunteers == tz);
        }
        public void ApdateRow(volunteerLeast v)
        {
            v.PutInto();
            this.Update();
        }
    }
}
