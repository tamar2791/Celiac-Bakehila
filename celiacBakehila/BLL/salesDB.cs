using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace celiacBakehila.BLL
{
    internal class salesDB:GeneralDB
    {
        List<sales> listsales = new List<sales>();
        public salesDB() : base("tbl_sales") { }
        public List<sales> GetList()
        {
            listsales.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                listsales.Add(new sales(dr));
            }
            return listsales;
        }
        public void AddNew(sales s)
        {
            s.Dr = dt.NewRow();
            s.PutInto();
            this.dt.Rows.Add(s.Dr);
            this.Update();
        }
        public sales SearchId(int kod)
        {
            return GetList().Find(x => x.Kod == kod);
        }
        public void ApdateRow(sales s)
        {
            s.PutInto();
            this.Update();
        }
        //מספור אוטומטי
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
