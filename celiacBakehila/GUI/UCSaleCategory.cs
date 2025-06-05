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
    public partial class UCSaleCategory : UserControl
    {
        //categoryDB lstCategory;
        //category c;
        //public UCSaleCategory()
        //{
        //    InitializeComponent();
        //    c = new category();
        //    lstCategory = new categoryDB();
        //    FillCheckedList();
        //}

        //private void FillCheckedList()
        //{
        //    foreach (category item in lstCategory.GetList())
        //    {
        //        checkedListBox1.Items.Add(item);
        //    }
        //}

        //private void btnReurn_Click(object sender, EventArgs e)
        //{
        //    Control c = this.Parent;
        //    while (!(c is UCManager))
        //        c = c.Parent;
        //    (c as UCManager).panelMain.Controls.Clear();
        //    UCAddSale uc = new UCAddSale();
        //    (c as UCManager).panelMain.Controls.Add(uc);
        //    uc.Dock = DockStyle.Fill;
        //    uc.button1.Visible = true;
        //    uc.checkBox1.Visible= true;
        //}

        //private void btnAdd_Click(object sender, EventArgs e)
        //{
        //    category c;
        //    foreach (category item in checkedListBox1.CheckedItems)
        //    {
        //       // c = lstCategory.GetList().FirstOrDefault(x=>x.ToString() == item);
        //        Validation.lstC.Add(item);
        //        MessageBox.Show("בוצע בהצלחה");
        //    }
        //}
    }
}
