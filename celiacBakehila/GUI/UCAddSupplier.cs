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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace celiacBakehila.GUI
{
    public partial class UCAddSupplier : UserControl
    {
        bool flagApdate=false;
        public UCAddSupplier(string tz):this()
        {
            s = lstSuppliers.SearchId(tz);
            FillTxt();
            flagApdate = true;
            btnAdd.Text = "עדכן";
            groupBox1.Text = "עדכון ספק";
        }

        private void FillTxt()
        {
            txttz.Text = s.TzSupplier;
            txtName.Text = s.NameSupplier;
            txtTel.Text = s.Phone;
            txtPel.Text = s.CellPhone;          
            txtMail.Text = s.Mail;          
        }

        public UCAddSupplier()
        {
            InitializeComponent();
            s=new suppliers();
            lstSuppliers= new suppliersDB();
        }
        suppliers s;
        suppliersDB lstSuppliers;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(CreateSupplier())
            {
                if(!flagApdate)
                {
                    lstSuppliers.AddNew(s);
                    MessageBox.Show("הספק נוסף בהצלחה");                    
                }
                else
                {
                    lstSuppliers.ApdateRow(s);
                    MessageBox.Show("הספק עודכן בהצלחה");
                }
                Control c = this.Parent;
                while (!(c is UCManager))
                    c = c.Parent;
                (c as UCManager).panelMain.Controls.Clear();
                UCSuppliers uc = new UCSuppliers();
                (c as UCManager).panelMain.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
            }
        }

        private bool CreateSupplier()
        {
            errorProvider1.Clear();
            bool flag=true;
            try
            {
                if (txttz.Text == "")
                    throw new Exception("שדה חובה");
                if (!flagApdate)
                {

                    if (lstSuppliers.SearchId(txttz.Text) != null)
                        throw new Exception("ת.ז. זאת קיימת במאגר הספקים");
                }
                s.TzSupplier = txttz.Text;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txttz, ex.Message);
                flag = false;
            }
            try
            {
                if (txtName.Text == "")
                    throw new Exception("שדה חובה");
                s.NameSupplier = txtName.Text;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtName, ex.Message);
                flag = false;
            }
            try
            {
                if (txtTel.Text == "")
                    throw new Exception("שדה חובה");
                s.Phone = txtTel.Text;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtTel, ex.Message);
                flag = false;
            }
            try
            {
                if (txtPel.Text == "")
                    throw new Exception("שדה חובה");
                s.CellPhone = txtPel.Text;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtPel, ex.Message);
                flag = false;
            }
            try
            {
                if (txtMail.Text == "")
                    throw new Exception("שדה חובה");
                s.Mail = txtMail.Text;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtMail, ex.Message);
                flag = false;
            }
            s.Status = true;
            return flag;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.ParentForm.Text = "צליאק בקהילה-מנהל-ספקים";
            Control c = this.Parent;
            while (!(c is UCManager))
                c = c.Parent;
            (c as UCManager).panelMain.Controls.Clear();
            UCSuppliers uc = new UCSuppliers();
            (c as UCManager).panelMain.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
        }
    }
}
