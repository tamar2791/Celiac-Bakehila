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

namespace celiacBakehila.GUI
{
    public partial class UCOldVolenteer : UserControl
    {
        public UCOldVolenteer()
        {
            InitializeComponent();
            lstVolunteers=new volunteersDB();
            lstBranches = new branchesDB();
            comboBox1.DataSource = lstBranches.GetList();
            comboBox1.SelectedIndex = lstVolunteers.SearchId(Validation.telUser).Branch - 1;

        }
        branchesDB lstBranches;
        volunteersDB lstVolunteers;
        volunteers v;
        private void button1_Click(object sender, EventArgs e)
        {
            v = lstVolunteers.SearchId(Validation.telUser);
            if (checkBox1.Checked)
            {
                v.Status = false;
            }
            v.Branch = ((branches)comboBox1.SelectedItem).Kod; ;
            lstVolunteers.ApdateRow(v);
            MessageBox.Show("בוצע בהצלחה");
            Control c = this.Parent;
            while (!(c is UCuser))
                c = c.Parent;
            (c as UCuser).panelMain.Controls.Clear();
            (c as UCuser).lblVpas.Visible = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                label1.Visible = false;
                comboBox1.Visible = false;
            }
            else
            {
                label1.Visible = true;
                comboBox1.Visible = true;
            }
        }
    }
}
