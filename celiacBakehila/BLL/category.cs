using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Net.Sockets;

namespace celiacBakehila.BLL
{
    public class category
    {
        private int kodCategory;
        private string describeCategory;
        private bool status;

        public category()
        {
        }
        public category(DataRow dr) : this()
        {
            this.Dr = dr;
            this.kodCategory = Convert.ToInt32(dr["kodCategory"]);
            this.describeCategory = dr["describeCategory"].ToString();
            this.status = Convert.ToBoolean(dr["status"]);
        }
        public void PutInto()
        {
            Dr["kodCategory"] = kodCategory;
            Dr["describeCategory"] = describeCategory;
            Dr["status"] = status;
        }
        public int KodCategory
        { get => kodCategory; set
            {
                if (!Validation.IsNum((value).ToString()))
                    throw new Exception("מספרים בלבד"); kodCategory = value;
            }
        }
        public string DescribeCategory
        { get => describeCategory; set
            {
                if (!Validation.IsHebrew(value))
                    throw new Exception("עברית בלבד!"); describeCategory = value;
            }
        }
        public DataRow Dr { get; set; }
        public bool Status { get => status; set => status = value; }
        public override string ToString()
        {
            return this.DescribeCategory;
        }
    }
}
