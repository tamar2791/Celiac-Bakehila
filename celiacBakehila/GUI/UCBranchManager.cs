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
    public partial class UCBranchManager : UserControl
    {
        branchesDB lstBranch;
        branchManagerDB lstBranchManager;
        public UCBranchManager()
        {
            InitializeComponent();
            MessageBox.Show("לתשומת לבך: כל הנתונים המופיעים תחת 'מנהל סניף', הנם אך ורק נתונים הנוגעים לסניף זה.");
            lstBranch= new branchesDB();
            lstBranchManager= new branchManagerDB();
            branchManager bm = lstBranchManager.GetList().FirstOrDefault(x => x.TelManager == Validation.telBranchManager);
            lblNameBrunch.Text = "סניף " + lstBranch.GetList().FirstOrDefault(x => x.branchManagerOfBranches().TelManager == bm.TelManager).NameBranch;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.ParentForm.Hide();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            panelMain.Visible = true;
            panelMain.Controls.Clear();
            UCBMClient uc = new UCBMClient();
            panelMain.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            this.Text = "צליאק בקהילה-מנהל סניף-לקוחות";
            lblClienPass.Visible = true;
            lblVPass.Visible = false;
            lblSuplierPass.Visible = false;
            lblProductPass.Visible = false;
        }

        private void btnV_Click(object sender, EventArgs e)
        {
            panelMain.Visible = true;
            panelMain.Controls.Clear();
            UCBMVolanteer uc = new UCBMVolanteer();
            panelMain.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            this.Text = "צליאק בקהילה-מנהל סניף-מתנדבים";
            lblClienPass.Visible = false;
            lblVPass.Visible = true;
            lblSuplierPass.Visible = false;
            lblProductPass.Visible = false;
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            panelMain.Visible = true;
            panelMain.Controls.Clear();
            UCBMProduct uc = new UCBMProduct();
            panelMain.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            this.Text = "צליאק בקהילה-מנהל סניף-מוצרים";
            lblClienPass.Visible = false;
            lblVPass.Visible = false;
            lblSuplierPass.Visible = false;
            lblProductPass.Visible = true;
        }

        private void btnSuplier_Click(object sender, EventArgs e)
        {
            panelMain.Visible = true;
            panelMain.Controls.Clear();
            UCBMSuplier uc = new UCBMSuplier();
            panelMain.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            this.Text = "צליאק בקהילה-מנהל סניף-ספקים";
            lblClienPass.Visible = false;
            lblVPass.Visible = false;
            lblSuplierPass.Visible = true;
            lblProductPass.Visible = false;
        }
    }
}
