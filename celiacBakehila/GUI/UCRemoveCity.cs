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
    public partial class UCRemoveCity : UserControl
    {
        cities c;
        citiesDB tblCities;
        public UCRemoveCity()
        {
            InitializeComponent();
            c= new cities();
            tblCities=new citiesDB();
            dataGridView1.DataSource= tblCities.GetList().Where(x=>x.Status==false).Select(x=>new { קוד = x.Kod, שם_עיר = x.NameCity }).ToList() ;
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
            (uc as UCNihul).panelMainCity.Visible = true;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (tblCities.GetList().Where(x => x.Status == false).ToList().Count != 0)
            {
                int kod = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                c = tblCities.SearchId(kod);
                c.Status = true;
                tblCities.ApdateRow(c);
                dataGridView1.DataSource = tblCities.GetList().Where(x => x.Status == false).Select(x => new { קוד = x.Kod, שם_עיר = x.NameCity }).ToList();
                if(tblCities.GetList().FirstOrDefault(x => x.Status == false)!=null)
                    dataGridView1.DataSource = tblCities.GetList().Where(x => x.Status == false).Select(x => new { קוד = x.Kod, שם_עיר = x.NameCity }).ToList();
                else
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
    }
}
