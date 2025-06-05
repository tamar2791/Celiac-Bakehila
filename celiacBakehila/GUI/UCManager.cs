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
    public partial class UCManager : UserControl
    {
        public UCManager()
        {
            InitializeComponent();
            panelMain.Visible = true;
            panelMain.Dock = DockStyle.Fill;            
            tblClient=new clientDB();
            tblProduct=new productsDB();
            tblvolunteers =new volunteersDB();
            tblSale = new salesDB();
            
        }
        
       

        
        clientDB tblClient;
        productsDB tblProduct;
        volunteersDB tblvolunteers;
        salesDB tblSale;
        private void btnClient_Click(object sender, EventArgs e)
        {
            this.ParentForm.Text = "צליאק בקהילה-מנהל-לקוחות" ;
            panelMain.Visible = true;
            panelMain.Controls.Clear();
            UCClient uc = new UCClient();
            panelMain.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            panelMain.Dock = DockStyle.Fill;
            lblSalePas.Visible = false;
            lblProductPas.Visible = false;
            lblSuplierPas.Visible = false;
            lblClienPas.Visible = true;
            lblVPas.Visible = false;
            lblNiulPas.Visible = false;
            //dataGridView1.Visible = true;
            //dataGridView1.DataSource = tblClient.GetList().Select(x => new { תעודת_זהות = x.TzClient, שם_פרטי = x.FirstName, שם_משפחה = x.LastName, רחוב = x.Street, מספר_בית = x.HouseNumber, עיר = x.CitiesOfClient().NameCity, טלפון = x.Phon, פאפון = x.CellPhon, מייל = x.Mail, סטטוס = x.Status, סניף = x.BranchesOfClient().NameBranch }).ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ParentForm.Text ="צליאק בקהילה-מנהל-מוצרים";
            panelMain.Visible = true;
            panelMain.Controls.Clear();
            UCProduct uc = new UCProduct();
            panelMain.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            lblSalePas.Visible = false;
            lblProductPas.Visible = true;
            lblSuplierPas.Visible = false;
            lblClienPas.Visible = false;
            lblVPas.Visible = false;
            lblNiulPas.Visible = false;
            //dataGridView1.Visible = true;
            //dataGridView1.DataSource = tblProduct.GetList().Select(x => new {קוד_מוצר=x.Kod,קטגוריה=x.CategoryOfProduct().DescribeCategory,שם_מוצר=x.NameProduct,מחיר_קניה=x.BuyingPrice,מחיר_מכירה=x.CellingPrice,סטטוס=x.Status,חדש=x.IfNew,חברה=x.CompaniesOfProduct().NameSociety}).ToList();
        }

        private void btnVolunteers_Click(object sender, EventArgs e)
        {
            this.ParentForm.Text = "צליאק בקהילה-מנהל-מתנדבים";
            panelMain.Visible = true;
            panelMain.Controls.Clear();
            UCVolenteers uc = new UCVolenteers();
            panelMain.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            lblSalePas.Visible = false;
            lblProductPas.Visible = false;
            lblSuplierPas.Visible = false;
            lblClienPas.Visible = false;
            lblVPas.Visible = true;
            lblNiulPas.Visible = false;
            //dataGridView1.Visible = true;
            //dataGridView1.DataSource = tblvolunteers.GetList().Select(x=>new { תעודת_זהות =x.TzVolunteers, שם_פרטי =x.FirstName, שם_משפחה =x.LastName, רחוב =x.Street, מספר_בית =x.HouseNumber, עיר =x.CitiesOfVolunteers().NameCity, טלפון =x.Phon, פאפון =x.CellPhon, מייל =x.Mail, סטטוס =x.Status, סניף =x.Branch}).ToList();
        }

        private void btnNihul_Click(object sender, EventArgs e)
        {
            
        }

        private void btnNihul_Click_1(object sender, EventArgs e)
        {
            this.ParentForm.Text = "צליאק בקהילה-מנהל-דף ניהול";
            panelMain.Visible = true;
            panelMain.Controls.Clear();
            UCNihul uc = new UCNihul();
            panelMain.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            lblSalePas.Visible = false;
            lblProductPas.Visible = false;
            lblSuplierPas.Visible = false;
            lblClienPas.Visible = false;
            lblVPas.Visible = false;
            lblNiulPas.Visible = true;
        }

        private void btnDonate_Click(object sender, EventArgs e)
        {
            this.ParentForm.Text = "צליאק בקהילה-מנהל-תורמים";
            panelMain.Visible = true;
            panelMain.Controls.Clear();
            UCLstDonate uc = new UCLstDonate();
            panelMain.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            lblSalePas.Visible = false;
            lblProductPas.Visible = false;
            lblSuplierPas.Visible = false;
            lblClienPas.Visible = false;
            lblVPas.Visible = false;
            lblNiulPas.Visible = false;
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            this.ParentForm.Text = "צליאק בקהילה-מנהל-מכירות";
            panelMain.Visible = true;
            panelMain.Controls.Clear();
            UCManagerSales uc = new UCManagerSales();
            panelMain.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            lblSalePas.Visible = true;
            lblProductPas.Visible = false;
            lblSuplierPas.Visible = false;
            lblClienPas.Visible = false;
            lblVPas.Visible = false;
            lblNiulPas.Visible = false;
            //dataGridView1.Visible = true;
            //dataGridView1.DataSource = tblSale.GetList().Select(x => new {קוד_מכירה=x.Kod,תאריך_תכירה=x.DateSale,סטטוס=x.Status,מקום=x.Place,מתנדבים=x.Volunteers}).ToList();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.ParentForm.Text = "צליאק בקהילה-מנהל-ספקים";
            panelMain.Visible = true;
            panelMain.Controls.Clear();
            UCSuppliers uc = new UCSuppliers();
            panelMain.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            lblSalePas.Visible = false;
            lblProductPas.Visible = false;
            lblSuplierPas.Visible = true;
            lblClienPas.Visible = false;
            lblVPas.Visible = false;
            lblNiulPas.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.ParentForm.Hide();
        }
    }
}
