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
    public partial class UCNihul : UserControl
    {       
        public UCNihul()
        {
            InitializeComponent();
            b = new branches();
            tblBranch = new branchesDB();
            tblCity = new citiesDB();
            c = new cities();
            cg=new category();
            tabControl1.SelectTab(Validation.numTab);
            tblCategory = new categoryDB();
            dataGridViewBranch.DataSource = tblBranch.GetList().Where(x=>x.Status==true).Select(x => new { קוד = x.Kod, שם_סניף = x.NameBranch, עיר = x.citiesOfBranches().NameCity, מנהל_סניף = x.branchManagerOfBranches().FirsrName+ " "+x.branchManagerOfBranches().LastName }).ToList();
            dataGridViewCity.DataSource = tblCity.GetList().Where(x => x.Status == true).Select(x => new { קוד = x.Kod, שם_עיר = x.NameCity}).ToList();
            dataGridViewKategory.DataSource = tblCategory.GetList().Where(x => x.Status == true).Select(x => new { קוד = x.KodCategory, שם_קטגוריה = x.DescribeCategory}).ToList();
        }
        branches b;
        branchesDB tblBranch;
        citiesDB tblCity;
        cities c;
        categoryDB tblCategory;
        category cg;

        private void button1_Click(object sender, EventArgs e)
        {
            this.ParentForm.Text = "צליאק בקהילה-מנהל-דף ניהול-סניפים-הוספת סניף";
            panelMainBranch.Visible = true;
            panelMainBranch.Controls.Clear();
            UCAddBranch uc=new UCAddBranch();          
            panelMainBranch.Controls.Add(uc);
            panelMainBranch.Controls.Remove(this);
            uc.Dock = DockStyle.Fill;
        }

        private void btnApdateBranch_Click(object sender, EventArgs e)
        {
            
        }

        private void btnApdateBranch_Click_1(object sender, EventArgs e)
        {
            if (tblBranch.GetList().Where(x => x.Status == true).ToList().Count != 0)
            {
                this.ParentForm.Text = "צליאק בקהילה-מנהל-דף ניהול-סניפים-עדכון סניף";
                int kod = Convert.ToInt32(dataGridViewBranch.SelectedRows[0].Cells[0].Value.ToString());
                panelMainBranch.Visible = true;
                panelMainBranch.Controls.Clear();
                UCAddBranch uc = new UCAddBranch(kod);
                panelMainBranch.Controls.Add(uc);
                panelMainBranch.Controls.Remove(this);
                uc.Dock = DockStyle.Fill;
            }
            else
            {
                MessageBox.Show("רשימת הסניפים ריקה");
            }
        }

        private void btnAddCity_Click(object sender, EventArgs e)
        {
            panelMainCity.Visible = true;
            panelMainCity.Controls.Clear();
            UCAddCity uc = new UCAddCity();
            panelMainCity.Controls.Add(uc);
            panelMainCity.Controls.Remove(this);
            uc.Dock = DockStyle.Fill;
        }

        private void btnApdateCategory_Click(object sender, EventArgs e)
        {
            if (tblCategory.GetList().Where(x => x.Status == true).ToList().Count != 0)
            { 
                int kod = Convert.ToInt32(dataGridViewKategory.SelectedRows[0].Cells[0].Value.ToString());
                panelMainCategory.Visible = true;
                panelMainCategory.Controls.Clear();
                UCAddCategory uc = new UCAddCategory(kod);
                panelMainCategory.Controls.Add(uc);
                panelMainCategory.Controls.Remove(this);
                uc.Dock = DockStyle.Fill;
            }
            else
            {
                MessageBox.Show("רשימת הקטגוריות ריקה");
            }
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            panelMainCategory.Visible = true;
            panelMainCategory.Controls.Clear();
            UCAddCategory uc = new UCAddCategory();
            panelMainCategory.Controls.Add(uc);
            panelMainCategory.Controls.Remove(this);
            uc.Dock = DockStyle.Fill;
        }

        private void btnApdateCity_Click(object sender, EventArgs e)
        {
            if (tblCity.GetList().Where(x => x.Status == true).ToList().Count != 0)
            { 
                int kod = Convert.ToInt32(dataGridViewCity.SelectedRows[0].Cells[0].Value.ToString());
                panelMainCity.Visible = true;
                panelMainCity.Controls.Clear();
                UCAddCity uc = new UCAddCity(kod);
                panelMainCity.Controls.Add(uc);
                panelMainCity.Controls.Remove(this);
                uc.Dock = DockStyle.Fill;
            }
            else
            {
                MessageBox.Show("רשימת הערים ריקה");
            }
        }

        private void TPBranch_Enter(object sender, EventArgs e)
        {
            dataGridViewBranch.Visible = true;
            Validation.numTab = 1;
            this.ParentForm.Text = "צליאק בקהילה-מנהל-דף ניהול-סניפים";
        }

        private void btnRemoveBranch_Click(object sender, EventArgs e)
        {
            if (tblBranch.GetList().Where(x => x.Status == true).ToList().Count != 0)
            {
                int kod = Convert.ToInt32(dataGridViewBranch.SelectedRows[0].Cells[0].Value.ToString());
                b = tblBranch.SearchId(kod);
                b.Status = false;
                tblBranch.ApdateRow(b);
                dataGridViewBranch.DataSource = tblBranch.GetList().Where(x => x.Status == true).Select(x => new { קוד = x.Kod, שם_סניף = x.NameBranch, עיר = x.citiesOfBranches().NameCity, מנהל_סניף = x.branchManagerOfBranches().FirsrName + x.branchManagerOfBranches().LastName }).ToList();
                MessageBox.Show("הסניף נמחק בהצלחה");
            }
            else
            {
                MessageBox.Show("רשימת הסניפים ריקה");
            }
        }

        private void btnSisma_Click(object sender, EventArgs e)
        {
            if (txtNowSisma.Text == "")
                errorProvider1.SetError(txtNowSisma, "שדה חובה");
            else
            {
                errorProvider1.Clear();
                if (txtnewsisma.Text == "")               
                    errorProvider1.SetError(txtnewsisma, "שדה חובה");
                else
                {
                    errorProvider1.Clear();
                    if (txtEmutSisma.Text == "")
                        errorProvider1.SetError(txtEmutSisma, "שדה חובה");
                    else
                    {
                        errorProvider1.Clear();
                        if (txtEmutSisma.Text != txtnewsisma.Text)
                            errorProvider1.SetError(txtEmutSisma, "אימות שגוי");
                        else
                        { 
                            errorProvider1.Clear();
                            MessageBox.Show("הסיסמא שונתה בהצלחה\n:הסיסמא החדשה היא\n" + txtnewsisma.Text);
                            txtnewsisma.Text = "";
                            txtNowSisma.Text = "";
                            txtEmutSisma.Text = "";
                        }
                    }
                }
            }           
        }

        private void btnRemoveCity_Click(object sender, EventArgs e)
        {
            if (tblCity.GetList().Where(x => x.Status == true).ToList().Count != 0)
            {
                int kod = Convert.ToInt32(dataGridViewCity.SelectedRows[0].Cells[0].Value.ToString());
                c = tblCity.SearchId(kod);
                c.Status = false;
                tblCity.ApdateRow(c);
                dataGridViewCity.DataSource = tblCity.GetList().Where(x => x.Status == true).Select(x => new { קוד = x.Kod, שם_עיר = x.NameCity }).ToList();
                MessageBox.Show("העיר נמחקה בהצלחה");
            }
            else
            {
                MessageBox.Show("רשימת הערים ריקה");
            }
        }

        private void btnRenoveCategory_Click(object sender, EventArgs e)
        {
            if (tblCategory.GetList().Where(x => x.Status == true).ToList().Count != 0)
            {
                int kod = Convert.ToInt32(dataGridViewKategory.SelectedRows[0].Cells[0].Value.ToString());
                cg = tblCategory.SearchId(kod);
                cg.Status = false;
                tblCategory.ApdateRow(cg);
                dataGridViewKategory.DataSource = tblCategory.GetList().Where(x => x.Status == true).Select(x => new { קוד = x.KodCategory, שם_קטגוריה = x.DescribeCategory }).ToList();
                MessageBox.Show("הקטגוריה נמחקה בהצלחה");
            }
            else
            {
                MessageBox.Show("רשימת הקטגוריות ריקה");
            }
        }

        private void btnOldBrunch_Click(object sender, EventArgs e)
        {
            if (tblBranch.GetList().Where(x => x.Status == false).ToList().Count != 0)
            {
                this.ParentForm.Text = "צליאק בקהילה-מנהל-דף ניהול-סניפים-סניפים שנמחקו";
                panelMainBranch.Visible = true;
                panelMainBranch.Controls.Clear();
                UCRemoveBrunch uc = new UCRemoveBrunch();
                panelMainBranch.Controls.Add(uc);
                panelMainBranch.Controls.Remove(this);
                uc.Dock = DockStyle.Fill;
            }
            else
                MessageBox.Show("אין סניפים מחוקים");
        }

        private void btnOldCities_Click(object sender, EventArgs e)
        {
            if (tblCategory.GetList().Where(x => x.Status == false).ToList().Count != 0)
            {
                panelMainCategory.Visible = true;
                panelMainCategory.Controls.Clear();
                UCRemoveCategory uc = new UCRemoveCategory();
                panelMainCategory.Controls.Add(uc);
                panelMainCategory.Controls.Remove(this);
                uc.Dock = DockStyle.Fill;
            }
            else
                MessageBox.Show("אין קטגוריות מחוקות");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (tblCity.GetList().Where(x => x.Status == false).ToList().Count != 0)
            {
                panelMainCity.Visible = true;
                panelMainCity.Controls.Clear();
                UCRemoveCity uc = new UCRemoveCity();
                panelMainCity.Controls.Add(uc);
                panelMainCity.Controls.Remove(this);
                uc.Dock = DockStyle.Fill;
            }
            else
                MessageBox.Show("אין ערים מחוקות");
        }

        private void TPCity_Enter(object sender, EventArgs e)
        {
            dataGridViewCity.Visible = true;
            Validation.numTab = 2;
            this.ParentForm.Text = "צליאק בקהילה-מנהל-דף ניהול-ערים";
        }

        private void TPKategory_Enter(object sender, EventArgs e)
        {
            dataGridViewKategory.Visible = true;
            Validation.numTab = 3;
            this.ParentForm.Text = "צליאק בקהילה-מנהל-דף ניהול-קטגוריות";
        }

        private void TPSisma_Enter(object sender, EventArgs e)
        {
            Validation.numTab = 0;
            this.ParentForm.Text = "צליאק בקהילה-מנהל-דף ניהול-שינוי סיסמא";
        }

        private void btnNewSisma_Click(object sender, EventArgs e)
        {
            this.ParentForm.Text = "צליאק בקהילה-מנהל-דף ניהול-שינוי סיסמא";
            panelMainBranch.Visible = false;
            panelMainCity.Visible = false;
            panelMainCategory.Visible = false;
            panelSisma.Visible = true;
        }

        private void btnBrunch_Click(object sender, EventArgs e)
        {
            this.ParentForm.Text = "צליאק בקהילה-מנהל-דף ניהול-סניפים";
            panelMainBranch.Visible = true;
            panelMainCity.Visible = false;
            panelMainCategory.Visible = false;
            panelSisma.Visible = false;
        }

        private void btnCity_Click(object sender, EventArgs e)
        {
            this.ParentForm.Text = "צליאק בקהילה-מנהל-דף ניהול-ערים";
            panelMainBranch.Visible = false;
            panelMainCity.Visible = true;
            panelMainCategory.Visible = false;
            panelSisma.Visible = false;
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            this.ParentForm.Text = "צליאק בקהילה-מנהל-דף ניהול-קטגוריות";
            panelMainBranch.Visible = false;
            panelMainCity.Visible = false;
            panelMainCategory.Visible = true;
            panelSisma.Visible = false;
        }
    }
}
