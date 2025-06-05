using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using celiacBakehila.BLL;

namespace celiacBakehila.GUI
{
    public partial class UCLstDonate : UserControl
    {
        volunteersDB tblvolunteers;
        public UCLstDonate()
        {
            InitializeComponent();
            tblvolunteers = new volunteersDB();
            dataGridView1.DataSource = tblvolunteers.GetList().Select(x => new { טלפון = x.Tel, שם_פרטי = x.FirstName, שם_משפחה = x.LastName, רחוב = x.Street, מספר_בית = x.HouseNumber, עיר = x.CitiesOfVolunteers().NameCity,פלאפון = x.Pel, מייל = x.Mail, סטטוס = x.Status, סניף = x.Branch }).ToList();
        }
    }
}
