using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace celiacBakehila.BLL
{
    internal class categoryDB:GeneralDB
    {
        List<category> listcategory = new List<category>();
        public categoryDB() : base("tbl_category") { }
        public List<category> GetList()
        {
            listcategory.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                listcategory.Add(new category(dr));
            }
            return listcategory;
        }
        public void AddNew(category c)
        {
            c.Dr = dt.NewRow();
            c.PutInto();
            this.dt.Rows.Add(c.Dr);
            this.Update();
        }
        public category SearchId(int kod)
        {
            return GetList().Find(x => x.KodCategory == kod);
        }
        public void ApdateRow(category c)
        {
            c.PutInto();
            this.Update();
        }
        public int GetNextKey()
        {
            int key;
            if (GetList().Count() == 0)
                return 1;
            key = GetList().Max(x => x.KodCategory);//מחזיר את הקוד המקסימלי
            key++;
            return key;
        }
    }
}
