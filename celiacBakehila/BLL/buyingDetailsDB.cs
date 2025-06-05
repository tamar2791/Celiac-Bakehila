using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace celiacBakehila.BLL
{
    class buyingDetailsDB:GeneralDB
    {
        List<buyingDetails> listbuyingDetails = new List<buyingDetails>();
        public buyingDetailsDB() : base("tbl_buyingDetails") { }
        public List<buyingDetails> GetList()
        {
            listbuyingDetails.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                listbuyingDetails.Add(new buyingDetails(dr));
            }
            return listbuyingDetails;
        }
        public void AddNew(buyingDetails bd)
        {
            bd.Dr = dt.NewRow();
            bd  .PutInto();
            this.dt.Rows.Add(bd.Dr);
            this.Update();
        }
        public buyingDetails SearchKodSale(int kod)
        {
            return GetList().Find(x => x.KodSale == kod);
        }
        public buyingDetails SearchId(string tz)
        {
            return GetList().Find(x => x.TelClient == tz);
        }
        public buyingDetails SearchKodProduct(int kod)
        {
            return GetList().Find(x => x.KodProduct == kod);
        }

        public void ApdateRow(buyingDetails bd)
        {
            bd.PutInto();
            this.Update();
        }
        public void DeleetRow(buyingDetails bd)
        {
            DataColumn[] primaryKeys = { dt.Columns["KodSale"], dt.Columns["TelClient"], dt.Columns["KodProduct"] };
            dt.PrimaryKey = primaryKeys;
            DataRow rowToDelete = dt.Rows.Find(new object[] { bd.KodSale, bd.TelClient, bd.KodProduct });
            // מחיקת השורה
            if (rowToDelete != null)
            {
                rowToDelete?.Delete();
                this.Update();
            }
        }
    }
}
