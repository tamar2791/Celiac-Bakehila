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
    public partial class UCRemoveVolenteer : UserControl
    {
        volunteers v;
        volunteersDB tblVolunteer;
        bool b;
        public UCRemoveVolenteer()
        {
            InitializeComponent();
            v = new volunteers();
            tblVolunteer = new volunteersDB();
            dataGridView1.DataSource = tblVolunteer.GetList().Where(x => x.Status == false).Select(x => new { טלפון = x.Tel, שם_פרטי = x.FirstName, שם_משפחה = x.LastName, רחוב = x.Street, מספר_בית = x.HouseNumber, עיר = x.CitiesOfVolunteers().NameCity, פלאפון = x.Pel, מייל = x.Mail, סניף = x.BranchesOfVolunteers().NameBranch }).ToList();
        }
        public UCRemoveVolenteer(bool b) : this()
        {
            this.b = b;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (tblVolunteer.GetList().Where(x => x.Status == false).ToList().Count != 0)
            {
                string tz = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                v = tblVolunteer.SearchId(tz);
                v.Status = true;
                tblVolunteer.ApdateRow(v);
                dataGridView1.DataSource = tblVolunteer.GetList().Where(x => x.Status == false).Select(x => new { טלפון = x.Tel, שם_פרטי = x.FirstName, שם_משפחה = x.LastName, רחוב = x.Street, מספר_בית = x.HouseNumber, עיר = x.CitiesOfVolunteers().NameCity, פלאפון = x.Pel, מייל = x.Mail, סניף = x.BranchesOfVolunteers().NameBranch }).ToList();
                MessageBox.Show("המתנדב שוחזר בהצלחה");
            }
            else
            {
                MessageBox.Show("רשימת המתנדבים המחוקים ריקה");
                if (!b)
                {
                    this.ParentForm.Text = "צליאק בקהילה-מנהל-מתנדבים";
                    panelMain.Controls.Clear();
                    UCVolenteers uc = new UCVolenteers();
                    panelMain.Controls.Add(uc);
                    panelMain.Dock = DockStyle.Fill;
                }
                else
                {
                    Control c = this.Parent;
                    while (!(c is UCBranchManager))
                        c = c.Parent;
                    (c as UCBranchManager).panelMain.Controls.Clear();
                    UCBMVolanteer uc = new UCBMVolanteer();
                    (c as UCBranchManager).panelMain.Controls.Add(uc);
                    uc.Dock = DockStyle.Fill;
                }
            }
        }

        private void btnRet_Click(object sender, EventArgs e)
        {
            if (!b)
            {
                this.ParentForm.Text = "צליאק בקהילה-מנהל-מתנדבים";
                panelMain.Controls.Clear();
                UCVolenteers uc = new UCVolenteers();
                panelMain.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
            }
            else
            {
                Control c = this.Parent;
                while (!(c is UCBranchManager))
                    c = c.Parent;
                (c as UCBranchManager).panelMain.Controls.Clear();
                UCBMVolanteer uc = new UCBMVolanteer();
                (c as UCBranchManager).panelMain.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
            }
        }
    }
}
