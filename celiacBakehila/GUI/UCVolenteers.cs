using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using celiacBakehila.BLL;

namespace celiacBakehila.GUI
{
    public partial class UCVolenteers : UserControl
    {
        volunteersDB tblvolunteers;
        volunteers v;
        public UCVolenteers()
        {
            InitializeComponent();
            tblvolunteers = new volunteersDB();
            v = new volunteers();
            dataGridView1.DataSource = tblvolunteers.GetList().Where(x=>x.Status==true).Select(x => new { טלפון = x.Tel, שם_פרטי = x.FirstName, שם_משפחה = x.LastName, רחוב = x.Street, מספר_בית = x.HouseNumber, עיר = x.CitiesOfVolunteers().NameCity,  פלאפון = x.Pel, מייל = x.Mail, סניף = x.BranchesOfVolunteers().NameBranch }).ToList();
        }

        private void btnHatzeg_Click(object sender, EventArgs e)
        {
            if(tblvolunteers.GetList().Where(x=>x.Status==true).ToList().Count!=0)
            {
                errorProvider1.Clear();
                dataGridView1.Visible= false;
                panel1.Visible = true;
                label11.Visible = false;
                textBox1.Visible = false;
                btnHatzeg.Visible = false;
                btnRemove.Visible = false;
                btnOldVolenteer.Visible = false;
                string tzVolunteers = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                v = tblvolunteers.SearchId(tzVolunteers);
                FillTxt();
            }
            else
            {
                MessageBox.Show("רשימת המתנדבים ריקה");
            }
        }

        private void FillTxt()
        {
            txttel.Text = v.Tel;
            txtfName.Text = v.FirstName;
            txtlName.Text = v.LastName;
            comboBox1.Text = v.CitiesOfVolunteers().NameCity;
            txtstreet.Text = v.Street;
            txthouseNumber.Text = v.HouseNumber.ToString();
            txtpel.Text = v.Pel;
            txtmail.Text = v.Mail;
            txtstreet.Text = v.Street;
            comboBox2.Text = v.BranchesOfVolunteers().NameBranch;
            txttel.ReadOnly = true;
            txtfName.ReadOnly = true;
            txtlName.ReadOnly = true;
            txtstreet.ReadOnly = true;
            txthouseNumber.ReadOnly = true;
            txtpel.ReadOnly = true;
            txtmail.ReadOnly = true;
            txtstreet.ReadOnly = true;
        }

        private void bnReturn_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            panel1.Visible = false;
            btnHatzeg.Visible = true;
            btnRemove.Visible = true;
            btnOldVolenteer.Visible = true;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (tblvolunteers.GetList().Where(x => x.Status == true).ToList().Count != 0)
            {
                string tz = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                v = tblvolunteers.SearchId(tz);
                v.Status = false;
                tblvolunteers.ApdateRow(v);
                dataGridView1.DataSource = tblvolunteers.GetList().Where(x => x.Status == true).Select(x => new { טלפון=  x.Tel, שם_פרטי = x.FirstName, שם_משפחה = x.LastName, רחוב = x.Street, מספר_בית = x.HouseNumber, עיר = x.CitiesOfVolunteers().NameCity,  פלאפון = x.Pel, מייל = x.Mail, סניף = x.BranchesOfVolunteers().NameBranch }).ToList();
                MessageBox.Show("המתנדב נמחק בהצלחה");
            }
            else
            {
                MessageBox.Show("רשימת המתנדבים ריקה");
            }
        }

        private void btnOldVolenteer_Click(object sender, EventArgs e)
        {
            if (tblvolunteers.GetList().Where(x => x.Status == false).ToList().Count != 0)
            {
                this.ParentForm.Text = "צליאק בקהילה-מנהל-מתנדבים-מתנדבים שנמחקו";
                panelMain.Visible = true;
                panelMain.Controls.Clear();
                UCRemoveVolenteer uc = new UCRemoveVolenteer();
                panelMain.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
            }
            else
                MessageBox.Show("אין מתנדבים שנמחקו");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                if(Validation.IsNum(textBox1.Text))
                    dataGridView1.DataSource = tblvolunteers.GetList().Where(x => x.Status == true&&x.Tel.StartsWith(textBox1.Text)|| x.Pel.StartsWith(textBox1.Text)).Select(x => new { טלפון = x.Tel, שם_פרטי = x.FirstName, שם_משפחה = x.LastName, רחוב = x.Street, מספר_בית = x.HouseNumber, עיר = x.CitiesOfVolunteers().NameCity, פלאפון = x.Pel, מייל = x.Mail, סניף = x.BranchesOfVolunteers().NameBranch }).ToList();
                if(Validation.IsHebrew(textBox1.Text))
                    dataGridView1.DataSource = tblvolunteers.GetList().Where(x => x.Status == true&&x.FirstName.StartsWith(textBox1.Text)|| x.LastName.StartsWith(textBox1.Text)).Select(x => new { טלפון = x.Tel, שם_פרטי = x.FirstName, שם_משפחה = x.LastName, רחוב = x.Street, מספר_בית = x.HouseNumber, עיר = x.CitiesOfVolunteers().NameCity, פלאפון = x.Pel, מייל = x.Mail, סניף = x.BranchesOfVolunteers().NameBranch }).ToList();
            }
            else
                dataGridView1.DataSource = tblvolunteers.GetList().Where(x => x.Status == true).Select(x => new { טלפון = x.Tel, שם_פרטי = x.FirstName, שם_משפחה = x.LastName, רחוב = x.Street, מספר_בית = x.HouseNumber, עיר = x.CitiesOfVolunteers().NameCity, פלאפון = x.Pel, מייל = x.Mail, סניף = x.BranchesOfVolunteers().NameBranch }).ToList();
        }
    }
}
