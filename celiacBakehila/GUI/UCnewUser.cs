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
    public partial class UCnewUser : UserControl
    {
        public UCnewUser()
        {
            InitializeComponent();
            if (Validation.id)
            {
                txttel.Text = Validation.telUser;
                Validation.id = false;
            }
            c = new client();
            lstCity = new citiesDB();
            comboBox1.DataSource = lstCity.GetList();
            comboBox1.SelectedIndex = -1;
            lstBranch = new branchesDB();
            comboBox2.DataSource = lstBranch.GetList();
            comboBox2.SelectedIndex = -1;
            object[] years = new object[6];
            for (int i = 0; i < 6; i++)
            {
                years[i] = DateTime.Now.Year + i;
            }
            comboBox3.Items.AddRange(years);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        client c;
        clientDB lstClient = new clientDB();
        citiesDB lstCity;
        branchesDB lstBranch;
        private void btnHerashem_Click(object sender, EventArgs e)
        {
            if (CreateClient())
            {
                if (lstClient.SearchId(c.Tel) != null)
                    MessageBox.Show("טלפון זה כבר קיים במאגר");
                else
                {
                    lstClient.AddNew(c);
                    label11.Visible = true;
                    panel1.Visible = false;
                }
                btnEnter.Visible = true;
            }

        }

        private bool CreateClient()
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
                if(!CreditCard())
                    throw new Exception("יש להכניס פרטי כרטיס אשראי");
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(lblCreditCardEtail, ex.Message);
                flag = false;
            }

            if (txtmail.Text == "")
                c.Mail = "";
            else
            {
                try
                {
                    if (!Validation.IsMail(txthouseNumber.Text))
                        throw new Exception("מייל לא חוקי");
                    c.Mail = txtmail.Text;
                }
                catch (Exception ex)
                {
                    errorProvider1.SetError(txtmail, ex.Message);
                    flag = false;
                }
            }
            c.Status = true;

            if (comboBox1.SelectedIndex != -1)
                c.City = ((cities)comboBox1.SelectedItem).Kod;
            else
                errorProvider1.SetError(comboBox1, "לא נבחרה עיר");
            if (comboBox2.SelectedIndex != -1)
                c.Branch = ((branches)comboBox2.SelectedItem).Kod;
            else
                errorProvider1.SetError(comboBox2, "לא נבחר סניף");
            c.Child = Convert.ToInt32(numericUpDown1.Value);
            return flag;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.ParentForm.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.ParentForm.Hide();
        }

        private void lblCreditCardEtail_Click(object sender, EventArgs e)
        {
            panelCreditCardEtail.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (CreditCard())
                panelCreditCardEtail.Visible = false;
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
                if (comboBox3.SelectedItem == null || comboBox4.SelectedItem == null)
                    throw new Exception("בחר תאריך");
                c.CreditCardDetailsValidityM = comboBox4.SelectedItem.ToString();
                c.CreditCardDetailsValidityY = comboBox3.SelectedItem.ToString();
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(label15, ex.Message);
                flag = false;
            }
            try
            {
                if (txtCreditCvv.Text=="")
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

        private void btnEnter_Click(object sender, EventArgs e)
        {
            Validation.telUser = txttel.Text;
            UCuser user = new UCuser();
            Control c = this.Parent;
            while (!(c is Form1))
                c = c.Parent;
            (c as Form1).panelManager.Controls.Clear();
            UCuser uc = new UCuser();
            (c as Form1).panelManager.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem.ToString() == DateTime.Now.Year.ToString())
            {
                comboBox4.Items.Clear();
                for(int i= DateTime.Now.Month+1;i<=12;i++)
                {
                    comboBox4.Items.Add(i);
                }
            }
            else
            {
                comboBox4.Items.Clear();
                comboBox4.Items.AddRange(new[] { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" });
            }
        }
    }
}
