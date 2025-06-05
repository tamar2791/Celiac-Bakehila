using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace celiacBakehila.BLL
{
    internal class productsDB:GeneralDB
    {
        List<products> listproducts = new List<products>();
        public productsDB() : base("tbl_products") { }
        public List<products> GetList()
        {
            listproducts.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                listproducts.Add(new products(dr));
            }
            return listproducts;
        }
        public void AddNew(products p)
        {
            p.Dr = dt.NewRow();
            p.PutInto();
            this.dt.Rows.Add(p.Dr);
            this.Update();
        }
        public products SearchId(int kod)
        {
            return GetList().Find(x => x.Kod == kod);
        }
        public void ApdateRow(products p)
        {
            p.PutInto();
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
