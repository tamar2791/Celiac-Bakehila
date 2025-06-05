using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace celiacBakehila.BLL
{
    internal class clientDB: GeneralDB
    {
        List<client> listClient = new List<client>();
        public clientDB() : base("tbl_client") { }
        public List<client> GetList()
        {
            listClient.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                listClient.Add(new client(dr));
            }
            return listClient;
        }
        public void AddNew(client c)
        {
            c.Dr = dt.NewRow();
            c.PutInto();
            this.dt.Rows.Add(c.Dr);
            this.Update();
        }
        public client SearchId(string tel)
        {
            return GetList().Find(x => x.Tel == tel);
        }
        public void ApdateRow(client client)
        {
            client.PutInto();
            this.Update();
        }
        public void UpdateRow(client c)
        {
            c.PutInto();
            this.Update();
        }
    }
}
