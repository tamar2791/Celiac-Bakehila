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
    public partial class UCAddCity : UserControl
    {
        bool flagApdate = false;
        public UCAddCity(int kod):this()
        {
            c = lstCity.SearchId(kod);
            FillTxt();
            flagApdate = true;
            btnAdd.Text = "עדכן";
            groupBox1.Text = "עדכון עיר";
        }

        private void FillTxt()
        {
            txtkod.Text=c.Kod.ToString();
            txtName.Text = c.NameCity;
        }

        public UCAddCity()
        {
            InitializeComponent();
            c = new cities();
            lstCity=new citiesDB();
            txtkod.Text = lstCity.GetNextKey().ToString();
            c.Kod = lstCity.GetNextKey();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (CreateCity())
            {
                if (!flagApdate)
                {
                    lstCity.AddNew(c);
                    MessageBox.Show("העיר נוספה בהצלחה");
                }
                else
                { 
                    lstCity.ApdateRow(c);
                    MessageBox.Show("העיר עודכנה בהצלחה");
                }
                txtkod.Text = "";
                txtName.Text = "";
                txtkod.Text = lstCity.GetNextKey().ToString();
                c.Kod = lstCity.GetNextKey();
                Control co = this.Parent;
                while (!(co is UCManager))
                    co = co.Parent;
                (co as UCManager).panelMain.Controls.Clear();
                UCNihul uc = new UCNihul();
                (co as UCManager).panelMain.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
            }
        }
        citiesDB lstCity;
        cities c;
        private bool CreateCity()
        {
            bool flag=true;
            try
            {
                if (txtkod.Text == "")
                    throw new Exception("שדה חובה");
                c.Kod = Convert.ToInt32(txtkod.Text);
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
                c.NameCity = txtName.Text;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtName, ex.Message);
                flag = false;
            }
            c.Status = true;
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
            (uc as UCNihul).panelMainCity.Visible = true;
        }
    }
}
