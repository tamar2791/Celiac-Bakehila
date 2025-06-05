using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using celiacBakehila.BLL;

namespace celiacBakehila.BLL
{
    public class branches
    {
        private int kod;
        private string nameBranch;
        private int city;
        private string branchManager;
        private bool status;
        private DataRow dr;
        public branches()
        {
        }
        public branches(DataRow dr) : this()
        {
            this.dr = dr;
            this.kod = Convert.ToInt32(dr["kod"]);
            this.nameBranch = dr["nameBranch"].ToString();
            this.city = Convert.ToInt32(dr["city"]);
            this.branchManager = dr["branchManager"].ToString();
            this.status = Convert.ToBoolean(dr["status"]);
        }        
        public void PutInto()
        {
            dr["kod"] = kod;
            dr["nameBranch"] = nameBranch;
            dr["city"] = city;
            dr["branchManager"] = branchManager;
            dr["status"] = status;

        }
        public int Kod
        { get => kod; set
            {
                if (!Validation.IsNum(value.ToString()))
                    throw new Exception("מספרים בלבד"); kod = value;
            }
        }
        public string NameBranch
        { get => nameBranch; set
            {
                if (!Validation.IsHebrew(value))
                    throw new Exception("עברית בלבד!"); nameBranch = value;
            }
        }
        public int City
        { get => city; set => city = value; }
        public string BranchManager{ get => branchManager; set => branchManager = value;}
            
        public DataRow Dr { get => dr; set => dr = value; }
        public bool Status { get => status; set => status = value; }

        public branchManager branchManagerOfBranches()
        {
            return new branchManagerDB().SearchId(this.branchManager);
        }
        public cities citiesOfBranches()
        {
            return new citiesDB().SearchId(this.city);
        }
        public override string ToString()
        {
            return this.nameBranch;
        }
    }
}
