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
    public partial class UCRemoveCategory : UserControl
    {
        category c;
        categoryDB tblCategory;
        public UCRemoveCategory()
        {
            InitializeComponent();
            c = new category();
            tblCategory = new categoryDB();
            dataGridView1.DataSource = tblCategory.GetList().Where(x => x.Status == false).Select(x => new { קוד = x.KodCategory, שם_קטגוריה = x.DescribeCategory }).ToList();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (tblCategory.GetList().Where(x => x.Status == false).ToList().Count != 0)
            {
                int kod = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                c = tblCategory.SearchId(kod);
                c.Status = true;
                tblCategory.ApdateRow(c);
                dataGridView1.DataSource = tblCategory.GetList().Where(x => x.Status == false).Select(x => new { קוד = x.KodCategory, שם_קטגוריה = x.DescribeCategory }).ToList();
                if(tblCategory.GetList().FirstOrDefault(x => x.Status == false)!=null)
                    dataGridView1.DataSource = tblCategory.GetList().Where(x => x.Status == false).Select(x => new { קוד = x.KodCategory, שם_קטגוריה = x.DescribeCategory }).ToList();
                else
                {
                    Control c = this.Parent;
                    while (!(c is UCManager))
                        c = c.Parent;
                    (c as UCManager).panelMain.Controls.Clear();
                    UCNihul uc = new UCNihul();
                    (c as UCManager).panelMain.Controls.Add(uc);
                    uc.Dock = DockStyle.Fill;
                    (uc as UCNihul).panelMainCategory.Visible = true;

                }
            }
        }

        private void btnRet_Click(object sender, EventArgs e)
        {
            Control c = this.Parent;
            while (!(c is UCManager))
                c = c.Parent;
            (c as UCManager).panelMain.Controls.Clear();
            UCNihul uc = new UCNihul();
            (c as UCManager).panelMain.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            (uc as UCNihul).panelMainCategory.Visible = true;
        }
    }
}
