using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net.Sockets;

namespace celiacBakehila.BLL
{
    internal class volunteerLeast
    {
        private int kodSale;
        private string telVolunteers;
        private DataRow dr;
        public volunteerLeast()
        {
        }
        public volunteerLeast(DataRow dr) : this()
        {
            this.dr = dr;
            this.kodSale = Convert.ToInt32(dr["kodSale"]);
            this.telVolunteers = dr["telVolunteers"].ToString();
        }
        public void PutInto()
        {
            dr["kodSale"] = kodSale;
            dr["telVolunteers"] = telVolunteers;
        }
        public int KodSale
        { get => kodSale; set
            {
                if (!Validation.IsNum(value.ToString()))
                    throw new Exception("מספרים בלבד"); kodSale = value;
            }
        }
        public string TelVolunteers
        { get => telVolunteers; set
            {
                if (!Validation.CheckId(value))
                    throw new Exception("ת.ז. לא תקינה !"); telVolunteers = value;
            }
        }
        public DataRow Dr { get => dr; set => dr = value; }
        public volunteers VolunteersOfVolunteerLeast()
        {
            return new volunteersDB().SearchId(this.telVolunteers);
        }
    }
}
