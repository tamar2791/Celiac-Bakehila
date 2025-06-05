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
    public partial class UCApdate : UserControl
    {
        public UCApdate()
        {
            InitializeComponent();
            tblBranch = new branchesDB();
        }
        branchesDB tblBranch;
        private void TPBranch_Click(object sender, EventArgs e)
        {
            
            dataGridViewBranch.DataSource=tblBranch.GetList().Select(x => new {קוד=x.Kod,שם_סניף=x.NameBranch,עיר=x.citiesOfBranches(),מנהל_סניף=x.BranchManager}).ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(creatBranch())
        }

        private bool creatBranch()
        {
            
        }
    }
}
