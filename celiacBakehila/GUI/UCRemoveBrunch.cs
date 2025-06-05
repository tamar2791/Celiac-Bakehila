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
    public partial class UCRemoveBrunch : UserControl
    {
        branches b;
        branchesDB tblBranches;
        public UCRemoveBrunch()
        {
            InitializeComponent();
            b = new branches();
            tblBranches = new branchesDB();
            if (tblBranches.GetList().Where(x => x.Status == false).ToList().Count == 0)
            {
                MessageBox.Show("אין סניפים מחוקים");
                Control c = this.Parent;
                while (!(c is UCManager))
                    c = c.Parent;
                (c as UCManager).panelMain.Controls.Clear();
                UCNihul uc = new UCNihul();
                (c as UCManager).panelMain.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
            }
            dataGridView1.DataSource = tblBranches.GetList().Where(x => x.Status == false).Select(x => new { קוד = x.Kod, שם_סניף = x.NameBranch, עיר = x.citiesOfBranches().NameCity, מנהל_סניף = x.branchManagerOfBranches().FirsrName + " " + x.branchManagerOfBranches().LastName }).ToList();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (tblBranches.GetList().Where(x => x.Status == false).ToList().Count != 0)
            {
                int kod = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                b = tblBranches.SearchId(kod);
                b.Status = true;
                tblBranches.ApdateRow(b);
                MessageBox.Show("הסניף שוחזר בהצלחה");
                dataGridView1.DataSource = tblBranches.GetList().Where(x => x.Status == false).Select(x => new { קוד = x.Kod, שם_סניף = x.NameBranch, עיר = x.citiesOfBranches().NameCity, מנהל_סניף = x.branchManagerOfBranches().FirsrName + " " + x.branchManagerOfBranches().LastName }).ToList();
                if (tblBranches.GetList().FirstOrDefault(x => x.Status == false)!=null)
                    dataGridView1.DataSource = tblBranches.GetList().Where(x => x.Status == false).Select(x => new { קוד = x.Kod, שם_סניף = x.NameBranch, עיר = x.citiesOfBranches().NameCity, מנהל_סניף = x.branchManagerOfBranches().FirsrName +" "+ x.branchManagerOfBranches().LastName }).ToList();
                else
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
            }
        }

        private void btnRet_Click(object sender, EventArgs e)
        {
            Control c = this.Parent;
            while(!(c is UCManager))
                c=c.Parent;
            (c as UCManager).panelMain.Controls.Clear();
            UCNihul uc = new UCNihul();
            (c as UCManager). panelMain.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            (uc as UCNihul).panelMainBranch.Visible = true;
        }
    }
}
