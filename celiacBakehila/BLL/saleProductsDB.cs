using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace celiacBakehila.BLL
{
    public class saleProductsDB:GeneralDB
    {
        List<saleProducts> listsaleProducts = new List<saleProducts>();
        public saleProductsDB() : base("tbl_saleProducts") { }
        public List<saleProducts> GetList()
        {
            listsaleProducts.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                listsaleProducts.Add(new saleProducts(dr));
            }
            return listsaleProducts;
        }
        public void AddNew(saleProducts s)
        {
            s.Dr = dt.NewRow();
            s.PutInto();
            this.dt.Rows.Add(s.Dr);
            this.Update();
        }
        public saleProducts SearchKodProduct(int kod)
        {
            return GetList().Find(x => x.KodProduct == kod);
        }
        public saleProducts SearchKodSale(int kod)
        {
            return GetList().Find(x => x.KodSale == kod);
        }
        public void ApdateRow(saleProducts s)
        {
            s.PutInto();
            this.Update();
        }
        public void DeleetRow(saleProducts s)
        {
            DataColumn[] primaryKeys = { dt.Columns["kodProduct"], dt.Columns["kodSale"] };
            dt.PrimaryKey = primaryKeys;
            DataRow rowToDelete = dt.Rows.Find(new object[] { s.kodProduct, s.kodSale });
            // מחיקת השורה
            if (rowToDelete != null)
            {
                rowToDelete?.Delete();
                this.Update();
            }
        }
    }
}
