using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace celiacBakehila.BLL
{
    class buyDB:GeneralDB
    {
        List<buy> listbuy = new List<buy>();
        public buyDB() : base("tbl_buy") { }
        public List<buy> GetList()
        {
            listbuy.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                listbuy.Add(new buy(dr));
            }
            return listbuy;
        }
        public void AddNew(buy b)
        {
            b.Dr = dt.NewRow();
            b.PutInto();
            this.dt.Rows.Add(b.Dr);
            this.Update();
        }
        public buy SearchId(string tz)
        {
            return GetList().Find(x => x.TelClient == tz);
        }
        public buy SearchKodSale(int kod)
        {
            return GetList().Find(x => x.KodSale == kod);
        }
        public void ApdateRow(buy buy)
        {
            buy.PutInto();
            this.Update();
        }
    }
}
