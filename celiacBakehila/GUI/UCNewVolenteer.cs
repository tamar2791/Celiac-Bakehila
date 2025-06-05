using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using celiacBakehila.BLL;

namespace celiacBakehila.GUI
{
    public partial class UCNewVolenteer : UserControl
    {
        public UCNewVolenteer()
        {
            InitializeComponent();
            lstClient = new clientDB();
            v = new volunteers();
            lstVolunteers = new volunteersDB();
            lstCity = new citiesDB();
            lstBranch = new branchesDB();
            comboBox2.DataSource = lstBranch.GetList();
            comboBox2.SelectedIndex = -1;

        }
        volunteers v;
        volunteersDB lstVolunteers;
        citiesDB lstCity;
        branchesDB lstBranch;
        private void button1_Click(object sender, EventArgs e)
        {
            volunteers vvv = lstVolunteers.SearchId(Validation.telUser);

            if ( vvv!= null)
            {
                if (CreateVolunteer())
                {
                    v.Dr = vvv.Dr;
                    vvv = v;
                    lstVolunteers.ApdateRow(v);
                }
            }
            else
                lstVolunteers.AddNew(v);
            MessageBox.Show("בוצע בהצלחה\nצליאק בקהילה מודה לך על התנדבותך");
            Control c = this.Parent;
            while (!(c is UCuser))
                c = c.Parent;
            (c as UCuser).panelMain.Controls.Clear();
            (c as UCuser).lblVpas.Visible = false;
        }
        clientDB lstClient;
        private bool CreateVolunteer()
        {
            bool flag = true;
            v.Tel = Validation.telUser;
            v.FirstName = txtFname.Text;
            v.LastName = lstClient.SearchId(Validation.telUser).LastName;
            v.City = lstClient.SearchId(Validation.telUser).City;
            v.Street = lstClient.SearchId(Validation.telUser).Street;
            v.HouseNumber = lstClient.SearchId(Validation.telUser).HouseNumber;
            v.Pel = lstClient.SearchId(Validation.telUser).Pel;
            v.Mail = lstClient.SearchId(Validation.telUser).Mail;
            v.Branch = ((branches)comboBox2.SelectedItem).Kod;
            v.Status = true;
            return flag;
        }
    }
}
