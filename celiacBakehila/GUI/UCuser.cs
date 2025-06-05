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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace celiacBakehila.GUI
{
    public partial class UCuser : UserControl
    {
        public UCuser()
        {
            InitializeComponent();
            c = new client();
            lstClient = new clientDB();
            c = lstClient.SearchId(Validation.telUser);
            labelName.Text = "משפחת " + lstClient.SearchId(Validation.telUser).LastName;
            FillTxt();
            lstBranches = new branchesDB();
            lstCities = new citiesDB();
            comboBox1.DataSource = lstCities.GetList().Where(x => x.Status == true).ToList();
            comboBox1.SelectedIndex = c.City - 1;
            comboBox2.DataSource = lstBranches.GetList().Where(x => x.Status == true).ToList();
            comboBox2.SelectedIndex = c.Branch - 1;
            listBox1.DataSource = lstBranches.GetList().Where(x => x.Status == true).Select(x => x.NameBranch + "-" + x.citiesOfBranches().NameCity).ToList();
            object[] years = new object[6];
            for (int i = 0; i < 6; i++)
            {
                years[i] = DateTime.Now.Year + i;
            }
            comboBoxY.Items.AddRange(years);
        }
        client c;
        clientDB lstClient;
        citiesDB lstCities;
        branchesDB lstBranches;
        private void btnSales_Click(object sender, EventArgs e)
        {
            this.ParentForm.Text = "צליאק בקהילה-משתמש-מכירות";
            panelMain.Visible = true;
            panelMain.Controls.Clear();
            UCSales uc = new UCSales();
            panelMain.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            lblSalePas.Visible = true;
            lblVpas.Visible = false;
            lblInfPas.Visible = false;
            lblApdatePas.Visible = false;
        }

        private void btnVolenteer_Click(object sender, EventArgs e)
        {
            this.ParentForm.Text = "צליאק בקהילה-משתמש-התנדבות";
            panelMain.Visible = true;
            panelMain.Controls.Clear();
            volunteersDB lstV = new volunteersDB();
            if (lstV.SearchId(Validation.telUser) == null || lstV.SearchId(Validation.telUser).Status == false)
            {
                UCNewVolenteer uc = new UCNewVolenteer();
                panelMain.Controls.Add(uc);
            }
            else
            {
                UCOldVolenteer uc = new UCOldVolenteer();
                panelMain.Controls.Add(uc);
            }
            lblSalePas.Visible = false;
            lblVpas.Visible = true;
            lblInfPas.Visible = false;
            lblApdatePas.Visible = false;
        }

        private void btndonate_Click(object sender, EventArgs e)
        {
            this.ParentForm.Text = "צליאק בקהילה-משתמש-תרומות";
            panelMain.Visible = true;
            panelMain.Controls.Clear();
            UCDonate uc = new UCDonate();
            panelMain.Controls.Add(uc);
            lblSalePas.Visible = false;
            lblVpas.Visible = false;
            lblInfPas.Visible = false;
            lblApdatePas.Visible = false;
        }

        private void btnInf_Click(object sender, EventArgs e)
        {
            this.ParentForm.Text = "צליאק בקהילה-משתמש-מידע על העמותה";
            lblSalePas.Visible = false;
            lblVpas.Visible = false;
            lblInfPas.Visible = true;
            lblApdatePas.Visible = false;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(groupBox2);
            groupBox2.Visible = true;
            groupBox1.Visible = false;
        }

        private void btnApdate_Click(object sender, EventArgs e)
        {
            this.ParentForm.Text = "צליאק בקהילה-משתמש-עדכון פרטים אישיים";
            panelMain.Visible = true;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(groupBox1);
            panelMain.Controls.Add(panelCreditCardEtail);
            string tz = Validation.telUser;
            groupBox1.Visible = true;
            groupBox2.Visible = false;
            lblSalePas.Visible = false;
            lblVpas.Visible = false;
            lblInfPas.Visible = false;
            lblApdatePas.Visible = true;
        }
        private void FillTxt()
        {
            txttel.Text = c.Tel;
            txtpel.Text = c.Pel;
            txtNameFather.Text = c.NameFather;
            txtNameMother.Text = c.NameMother;
            txtlName.Text = c.LastName;
            numericUpDown1.Value = c.Child;
            comboBox1.Text = c.CitiesOfClient().NameCity;
            txtstreet.Text = c.Street;
            txthouseNumber.Text = c.HouseNumber.ToString();
            txtmail.Text = c.Mail;
            comboBox2.Text = c.BranchesOfClient().NameBranch;
            txtCreditNumber.Text = c.CreditCardDetailsNumber.ToString();
            txtCreditCvv.Text = c.CreditCardDetailsCvv.ToString();
            txtCreditTz.Text = c.CreditCardDetailsTz.ToString();
            comboBoxY.SelectedItem = c.CreditCardDetailsValidityY;//comboBoxY.Items.IndexOf(c.CreditCardDetailsValidityY);
            comboBoxM.SelectedItem = c.CreditCardDetailsValidityM;
            comboBoxY.Text = c.CreditCardDetailsValidityY;
        }
        private void btnHerashem_Click(object sender, EventArgs e)
        {
            if (UpdateClient())
            {
                lstClient.UpdateRow(c);
                labelName.Text = "משפחת " + c.LastName;
                MessageBox.Show("הפרטים עודכנו בהצלחה");
                groupBox1.Visible = false;
                btnApdate.FlatAppearance.BorderSize = 0;
                this.ParentForm.Text = "צליאק בקהילה-משתמש";
                lblApdatePas.Visible = false;
            }
        }

        private bool UpdateClient()
        {
            bool flag = true;
            errorProvider1.Clear();
            try
            {
                if (txttel.Text == "")
                    throw new Exception("שדה חובה");
                c.Tel = txttel.Text;

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
                c.Pel = txtpel.Text;

            }
            catch (Exception ex)
            {

                errorProvider1.SetError(txtpel, ex.Message);
                flag = false;
            }
            try
            {
                if (txtNameFather.Text == "")
                    throw new Exception("שדה חובה");
                c.NameFather = txtNameFather.Text;

            }
            catch (Exception ex)
            {

                errorProvider1.SetError(txtNameFather, ex.Message);
                flag = false;
            }
            try
            {
                if (txtNameMother.Text == "")
                    throw new Exception("שדה חובה");
                c.NameMother = txtNameMother.Text;

            }
            catch (Exception ex)
            {

                errorProvider1.SetError(txtNameMother, ex.Message);
                flag = false;
            }
            try
            {
                if (txtlName.Text == "")
                    throw new Exception("שדה חובה");
                c.LastName = txtlName.Text;

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
                c.Street = txtstreet.Text;

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
                c.HouseNumber = txthouseNumber.Text;

            }
            catch (Exception ex)
            {

                errorProvider1.SetError(txthouseNumber, ex.Message);
                flag = false;
            }
            try
            {
                if (txtmail.Text == "")
                    c.Mail = "";
                else
                {
                    if (!Validation.IsMail(txtmail.Text))
                        throw new Exception("מייל לא תקין");
                    c.Mail = txtmail.Text;
                }


            }
            catch (Exception ex)
            {

                errorProvider1.SetError(txtmail, ex.Message);
                flag = false;
            }
            c.Status = true;
            if (comboBox1.SelectedIndex != -1)
                c.City = ((cities)comboBox1.SelectedItem).Kod;
            if (comboBox2.SelectedIndex != -1)
                c.Branch = ((branches)comboBox2.SelectedItem).Kod;
            c.Child = Convert.ToInt32(numericUpDown1.Value);
            return flag;
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            button1.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Validation.lstSAL.Clear();
            Form1 f = new Form1();
            f.Show();
            this.ParentForm.Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            button1.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            groupBox2.Visible = false;
            this.ParentForm.Text = "צליאק בקהילה-משתמש";
            lblInfPas.Visible = false;
        }

        private void lblCreditCardEtail_Click(object sender, EventArgs e)
        {
            panelCreditCardEtail.Visible = true;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxY.SelectedItem != null && comboBoxY.SelectedItem.ToString() == DateTime.Now.Year.ToString())
            {
                comboBoxM.Items.Clear();
                for (int i = DateTime.Now.Month + 1; i <= 12; i++)
                {
                    comboBoxM.Items.Add(i);
                }
            }
            else
            {
                comboBoxM.Items.Clear();
                comboBoxM.Items.AddRange(new[] { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" });
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (CreditCard())
            {
                MessageBox.Show("הפרטים נקלטו בהצלחה");
                panelCreditCardEtail.Visible = false;
            }
        }

        private bool CreditCard()
        {
            bool flag = true;
            errorProvider1.Clear();
            try
            {
                string creditCardNumber = txtCreditNumber.Text.Replace(" ", "");
                if (txtCreditNumber.Text == "")
                    throw new Exception("שדה חובה");
                if (!c.IsValidCreditCardNumber(creditCardNumber))
                    throw new Exception("מספר כרטיס אשראי לא תקין");
                c.CreditCardDetailsNumber = txtCreditNumber.Text;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtCreditNumber, ex.Message);
                flag = false;
            }
            try
            {
                if (comboBoxM.SelectedItem == null || comboBoxY.SelectedItem == null)
                    throw new Exception("בחר תאריך");
                c.CreditCardDetailsValidityM = comboBoxM.SelectedItem.ToString();
                c.CreditCardDetailsValidityY = comboBoxY.SelectedItem.ToString();
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(label15, ex.Message);
                flag = false;
            }
            try
            {
                if (txtCreditCvv.Text == "")
                    throw new Exception("שדה חובה");
                c.CreditCardDetailsCvv = txtCreditCvv.Text;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtCreditCvv, ex.Message);
                flag = false;
            }
            try
            {
                if (txtCreditTz.Text == "")
                    throw new Exception("שדה חובה");
                c.CreditCardDetailsCvv = txtCreditTz.Text;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtCreditTz, ex.Message);
                flag = false;
            }
            return flag;
        }
    }
}
