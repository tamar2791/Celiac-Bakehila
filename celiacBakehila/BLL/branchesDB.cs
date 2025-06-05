using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace celiacBakehila.BLL
{
    class branchesDB:GeneralDB
    {
        List<branches> listbranches = new List<branches>();
        public branchesDB() : base("tbl_branches") { }
        public List<branches> GetList()
        {
            listbranches.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                listbranches.Add(new branches(dr));
            }
            return listbranches;
        }
        public void AddNew(branches b)
        {
            b.Dr = dt.NewRow();
            b.PutInto();
            this.dt.Rows.Add(b.Dr);
            this.Update();
        }
        public branches SearchId(int kod)
        {
            return GetList().Find(x => x.Kod == kod);
        }
        public void ApdateRow(branches b)
        {
            b.PutInto();
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
