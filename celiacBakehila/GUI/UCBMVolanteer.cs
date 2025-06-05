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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace celiacBakehila.GUI
{
    public partial class UCBMVolanteer : UserControl
    {
        volunteersDB tblVolunteers;
        branchManagerDB tblBranchManager;
        branchManager bm;
        volunteers v;
        public UCBMVolanteer()
        {
            InitializeComponent();
            v = new volunteers();
            tblVolunteers = new volunteersDB();
            tblBranchManager = new branchManagerDB();
            bm = tblBranchManager.SearchId(Validation.telBranchManager);
            dataGridView1.DataSource=tblVolunteers.GetList().Where(x=>x.Status==true && x.BranchesOfVolunteers().BranchManager == bm.TelManager).Select(x => new {  שם_פרטי = x.FirstName, שם_משפחה = x.LastName, טלפון = x.Tel, פלאפון = x.Pel, רחוב = x.Street, מספר_בית = x.HouseNumber, עיר = x.CitiesOfVolunteers().NameCity, מייל = x.Mail}).ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FillText();
            panelDetails.Visible = true;
        }

        private void FillText()
        {
            string tz = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            volunteers v= tblVolunteers.SearchId(tz);
            txtpel.Text=v.Pel;
            txtfName.Text=v.FirstName;
            txtlName.Text=v.LastName;
            txtstreet.Text=v.Street;
            txthouseNumber.Text=v.HouseNumber;
            txtmail.Text=v.Mail;
            txttel.Text=v.Tel;
            txtCity.Text = v.BranchesOfVolunteers().NameBranch;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            panelDetails.Visible=false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tblVolunteers.GetList().Where(x => x.Status == false).ToList().Count != 0)
            {
                this.ParentForm.Text = "צליאק בקהילה-מנהל-מתנדבים-מתנדבים שנמחקו";
                panelMain.Visible = true;
                panelMain.Controls.Clear();
                UCRemoveVolenteer uc = new UCRemoveVolenteer(true);
                panelMain.Controls.Add(uc);
                panelMain.Dock = DockStyle.Fill;
            }
            else
                MessageBox.Show("אין מתנדבים שנמחקו");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tblVolunteers.GetList().Where(x => x.Status == true).ToList().Count != 0)
            {
                string tz = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                v = tblVolunteers.SearchId(tz);
                v.Status = false;
                tblVolunteers.ApdateRow(v);
                dataGridView1.DataSource = tblVolunteers.GetList().Where(x => x.Status == true && x.BranchesOfVolunteers().BranchManager == bm.TelManager).Select(x => new { שם_פרטי = x.FirstName, שם_משפחה = x.LastName, טלפון = x.Tel, פלאפון = x.Pel, רחוב = x.Street, מספר_בית = x.HouseNumber, עיר = x.CitiesOfVolunteers().NameCity, מייל = x.Mail }).ToList();
                MessageBox.Show("המתנדב נמחק בהצלחה");
            }
        }
    }
}

