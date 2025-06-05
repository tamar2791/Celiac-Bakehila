using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace celiacBakehila.BLL
{
    internal class citiesDB:GeneralDB
    {
        List<cities> listcities = new List<cities>();
        public citiesDB() : base("tbl_cities") { }
        public List<cities> GetList()
        {
            listcities.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                listcities.Add(new cities(dr));
            }
            return listcities;
        }
        public void AddNew(cities c)
        {
            c.Dr = dt.NewRow();
            c.PutInto();
            this.dt.Rows.Add(c.Dr);
            this.Update();
        }
        public cities SearchId(int kod)
        {
            return GetList().Find(x => x.Kod == kod);
        }
        public void ApdateRow(cities c)
        {
            c.PutInto();
            this.Update();
        }
        public int GetNextKey()
        {
            int key;
            if (GetList().Count() == 0)
                return 1;
            key = GetList().Max(x => x.Kod);//מחזיר את הקוד המקסימלי
            key++;
            return key;
        }
    }
}
