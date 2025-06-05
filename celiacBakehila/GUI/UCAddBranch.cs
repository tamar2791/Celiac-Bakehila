using celiacBakehila.BLL;
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
using System.Runtime.CompilerServices;

namespace celiacBakehila.GUI
{
    public partial class UCAddBranch : UserControl
    {
        bool flagApdate = false;
        public UCAddBranch(int kod) : this()
        {
            b = lstBranch.SearchId(kod);
            bm = lstBranchManager.SearchId(b.BranchManager);
            FillTxt();
            flagApdate = true;
            btnAdd.Text = "עדכן";
            groupBox1.Text = "עדכון סניף";
            btnManager.Text = "עדכן מנהל סניף";
        }

        private void FillTxt()
        {
            txtkod.Text = b.Kod.ToString();
            txtName.Text = b.NameBranch;
            comboBox1.Text = b.citiesOfBranches().NameCity;
            txtlName.Text = b.branchManagerOfBranches().LastName;
            comboBox3.Text = b.branchManagerOfBranches().citiesOfBranchesManager().NameCity;
            txtstreet.Text = b.branchManagerOfBranches().Street;
            txthouseNumber.Text = b.branchManagerOfBranches().HouseNumber.ToString();
            txttel.Text = b.branchManagerOfBranches().TelManager;
            txtpel.Text = b.branchManagerOfBranches().CellPhone;
            txtmail.Text = b.branchManagerOfBranches().Mail;
            txtfName.Text = b.branchManagerOfBranches().FirsrName;
        }

        public UCAddBranch()
        {
            InitializeComponent();
            b = new branches();
            bm = new branchManager();
            lstBranch = new branchesDB();
            lstCity = new citiesDB();
            comboBox1.DataSource = lstCity.GetList().Where(x => x.Status == true).ToList();
            comboBox1.SelectedIndex = -1;
            comboBox3.DataSource = lstCity.GetList().Where(x => x.Status == true).ToList();
            comboBox3.SelectedIndex = -1;
            lstBranchManager = new branchManagerDB();
            txtkod.Text = lstBranch.GetNextKey().ToString();
            b.Kod = lstBranch.GetNextKey();
        }
        branches b;
        branchesDB lstBranch;
        citiesDB lstCity;
        branchManagerDB lstBranchManager;

        private void btnReturn_Click_1(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (CreateBranch())
            {
                errorProvider1.Clear();
                if (!flagApdate)
                {
                    lstBranchManager.AddNew(bm);
                    b.BranchManager = bm.TelManager;
                    lblManager.Text ="מנהל הסניף: "+ bm.FirsrName + " " + bm.LastName;
                    lstBranch.AddNew(b);
                    MessageBox.Show("הסניף נוסף בהצלחה");
                }
                else
                {
                    lstBranch.ApdateRow(b);
                    MessageBox.Show("הסניף עודכן בהצלחה");
                    lstBranchManager.ApdateRow(bm);
                }
                txtName.Text = "";
                txtkod.Text = lstBranch.GetNextKey().ToString();
                b.Kod = lstBranch.GetNextKey();
                comboBox1.SelectedIndex = -1;
                Control c = this.Parent;
                while (!(c is UCManager))
                    c = c.Parent;
                (c as UCManager).panelMain.Controls.Clear();
                UCNihul uc = new UCNihul();
                (c as UCManager).panelMain.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                (uc as UCNihul).panelMainBranch.Visible = true;
            }
        }

        private bool CreateBranch()
        {
            errorProvider1.Clear();
            bool flag = true;
            try
            {
                if (txtkod.Text == "")
                    throw new Exception("שדה חובה");
                b.Kod = Convert.ToInt32(txtkod.Text);
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtkod, ex.Message);
                flag = false;
            }
            try
            {
                if (txtName.Text == "")
                    throw new Exception("שדה חובה");
                b.NameBranch = txtName.Text;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtName, ex.Message);
                flag = false;
            }
            try
            {
                if (!flagApdate)
                {
                    if (comboBox1.SelectedIndex == -1)
                        throw new Exception("לא נבחרה עיר");
                    b.City = ((cities)comboBox1.SelectedItem).Kod;
                }
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(comboBox1, ex.Message);
                flag = false;
            }
            try
            {
                if (bm.TelManager == null)
                    throw new Exception("לא נקלט מנהל סניף");
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(btnManager, ex.Message);
                flag = false;
            }
            b.Status = true;
            return flag;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Control c = this.Parent;
            while (!(c is UCManager))
                c = c.Parent;
            (c as UCManager).panelMain.Controls.Clear();
            UCNihul uc = new UCNihul();
            (c as UCManager).panelMain.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            (uc as UCNihul).panelMainBranch.Visible = true;
        }

        private void btnManager_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
        }

        branchManager bm;
        private void bntOKManager_Click(object sender, EventArgs e)
        {
            if (!flagApdate)
            {
                if (createBranchManager())
                {
                    errorProvider1.Clear();
                    MessageBox.Show("פרטי מנהל הסניף נקלטו בהצלחה");
                    groupBox2.Visible = false;
                }
            }
            else
            {
                if (createBranchManager())
                { 
                    MessageBox.Show("פרטי מנהל הסניף עודכנו בהצלחה");
                    groupBox2.Visible = false;
                }
                groupBox2.Visible = false;
            }
        }

        private bool createBranchManager()
        {
            bool flag = true;
            try
            {
                if (txtfName.Text == "")
                    throw new Exception("שדה חובה");
                bm.FirsrName = txtfName.Text;

            }
            catch (Exception ex)
            {

                errorProvider1.SetError(txtfName, ex.Message);
                flag = false;
            }
            try
            {
                if (txtlName.Text == "")
                    throw new Exception("שדה חובה");
                bm.LastName = txtlName.Text;

            }
            catch (Exception ex)
            {

                errorProvider1.SetError(txtlName, ex.Message);
                flag = false;
            }
            try
            {
                if (txtstreet.Text == "")
                    throw new Exception("שדה חובה");
                bm.Street = txtstreet.Text;

            }
            catch (Exception ex)
            {

                errorProvider1.SetError(txtstreet, ex.Message);
                flag = false;
            }
            try
            {
                if (txthouseNumber.Text == "")
                    throw new Exception("שדה חובה");
                bm.HouseNumber = Convert.ToInt32(txthouseNumber.Text);

            }
            catch (Exception ex)
            {

                errorProvider1.SetError(txthouseNumber, ex.Message);
                flag = false;
            }
            try
            {
                if (txttel.Text == "")
                    throw new Exception("שדה חובה");
                bm.Phone = txttel.Text;
                bm.TelManager = txttel.Text;

            }
            catch (Exception ex)
            {

                errorProvider1.SetError(txttel, ex.Message);
                flag = false;
            }
            try
            {
                if (txtpel.Text == "")
                    throw new Exception("שדה חובה");
                bm.CellPhone = txtpel.Text;

            }
            catch (Exception ex)
            {

                errorProvider1.SetError(txtpel, ex.Message);
                flag = false;
            }
            try
            {
                if (txtmail.Text == "")
                    throw new Exception("שדה חובה");
                bm.Mail = txtmail.Text;

            }
            catch (Exception ex)
            {

                errorProvider1.SetError(txtmail, ex.Message);
                flag = false;
            }
            if (comboBox3.SelectedIndex != -1)
                bm.City = ((cities)comboBox3.SelectedItem).Kod;
            else
                errorProvider1.SetError(comboBox3, "לא נבחרה עיר");
            return flag;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
        }
    }
}
