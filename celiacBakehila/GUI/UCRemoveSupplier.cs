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
    public partial class UCRemoveSupplier : UserControl
    {
        suppliers s;
        suppliersDB tblSupplier;
        public UCRemoveSupplier()
        {
            InitializeComponent();
            s=new suppliers();
            tblSupplier=new suppliersDB();
            dataGridView1.DataSource = tblSupplier.GetList().Where(x => x.Status == false).Select(x => new { תעודת_זהות_ספק = x.TzSupplier, שם_ספק = x.NameSupplier, טלפון = x.Phone, פלאפון = x.CellPhone, מייל = x.Mail }).ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tblSupplier.GetList().Where(x => x.Status == false).ToList().Count != 0)
            {
                string tz = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                s = tblSupplier.SearchId(tz);
                s.Status = true;
                tblSupplier.ApdateRow(s);
                dataGridView1.DataSource = tblSupplier.GetList().Where(x => x.Status == false).Select(x => new { תעודת_זהות_ספק = x.TzSupplier, שם_ספק = x.NameSupplier, טלפון = x.Phone, פלאפון = x.CellPhone, מייל = x.Mail }).ToList();
                MessageBox.Show("הספק שוחזר בהצלחה");
            }
            else
            {
                MessageBox.Show("רשימת הספקים המחוקים ריקה");
                this.ParentForm.Text = "צליאק בקהילה-מנהל-ספקים";
                panelMain.Controls.Clear();
                UCSuppliers uc = new UCSuppliers();
                panelMain.Controls.Add(uc);
                panelMain.Dock = DockStyle.Fill;
            }
        }

        private void btnRet_Click(object sender, EventArgs e)
        {
            this.ParentForm.Text = "צליאק בקהילה-מנהל-ספקים";
            panelMain.Controls.Clear();
            UCSuppliers uc = new UCSuppliers();
            panelMain.Controls.Add(uc);
            panelMain.Dock = DockStyle.Fill;
        }
    }
}
