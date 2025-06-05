using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace celiacBakehila.BLL
{
    class branchManagerDB:GeneralDB
    {
        List<branchManager> listBranchManager = new List<branchManager>();
        public branchManagerDB() : base("tbl_branchManager") { }
        public List<branchManager> GetList()
        {
            listBranchManager.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                listBranchManager.Add(new branchManager(dr));
            }
            return listBranchManager;
        }
        public void AddNew(branchManager bm)
        {
            bm.Dr = dt.NewRow();
            bm.PutInto();
            this.dt.Rows.Add(bm.Dr);
            this.Update();
        }
        public branchManager SearchId(string tz)
        {
            return GetList().Find(x => x.TelManager == tz);
        }
        public void ApdateRow(branchManager bm)
        {
            bm.PutInto();
            this.Update();
        }
    }
}
