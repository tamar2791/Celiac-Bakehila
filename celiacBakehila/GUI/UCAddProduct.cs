using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using celiacBakehila.BLL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace celiacBakehila.GUI
{
    public partial class UCAddProduct : UserControl
    {
        bool flagApdate = false;
        string s, c;//משתנה לשמירת הנתיב של התיקיה המקומית
        public UCAddProduct(int kod):this()
        {
            p=lstProducts.SearchId(kod);
            FillTxt();
            string a = Directory.GetParent(Directory.GetCurrentDirectory()).ToString();
            string c = Directory.GetParent(a).ToString();//שמירת נתיב ללא debug
                                                         // c = Directory.GetParent(b).ToString();//bin שמירת נתיב ללא 
            c = c + @"\pictures\";//שרשור שם התיקיה המקומית של התמונות
            c = c + p.Picture;//שרשור שם התמונה המבוקשת באמצעות שימוש בעצם ובתכונות המחלקה
            pictureBox1.Image = Image.FromFile(c);
            flagApdate = true;
            btnAdd.Text = "עדכן";
            groupBox1.Text = "עדכון מוצר";
        }

        private void FillTxt()
        {
            txtKod.Text = p.Kod.ToString();
            txtDescribr.Text = p.NameProduct;
            txtCellingPrice.Text = p.CellingPrice.ToString();
            txtBuyingPrice.Text = p.BuyingPrice.ToString();
            cmbCategory.Text = p.CategoryOfProduct().DescribeCategory;
            cmbSupplier.Text = p.SuppliersOfProduct().NameSupplier;
            checkBox1.Checked = p.IfNew;
        }

        public UCAddProduct()
        {
            InitializeComponent();
            p = new products();
            lstProducts = new productsDB();
            lstCategory=new categoryDB();
            lstSuppliers = new suppliersDB();
            cmbCategory.DataSource = lstCategory.GetList().Where(x=>x.Status==true).ToList();
            cmbCategory.SelectedIndex = -1;
            cmbSupplier.DataSource = lstSuppliers.GetList().Where(x=>x.Status==true).ToList();
            cmbSupplier.SelectedIndex = -1;
            txtKod.Text = lstProducts.GetNextKey().ToString();
            p.Kod = lstProducts.GetNextKey();
        }
        products p;
        productsDB lstProducts;
        categoryDB lstCategory;
        suppliersDB lstSuppliers;
        private void button1_Click(object sender, EventArgs e)
        {
            if(CreateProduct())
            {
                if(!flagApdate)
                { 
                    lstProducts.AddNew(p);
                    MessageBox.Show("המוצר נוסף בהצלחה");                  
                }
                else
                {
                    lstProducts.ApdateRow(p);
                    MessageBox.Show("המוצר עודכן בהצלחה");
                }
                this.ParentForm.Text = "צליאק בקהילה-מנהל-מוצרים";
                Control c = this.Parent;
                while (!(c is UCManager))
                    c = c.Parent;
                (c as UCManager).panelMain.Controls.Clear();
                UCProduct uc = new UCProduct();
                (c as UCManager).panelMain.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
            }
        }

        private bool CreateProduct()
        {
            errorProvider1.Clear();
            bool flag=true;
            try
            {
                if (txtDescribr.Text == "")
                    throw new Exception("שדה חובה");
                p.NameProduct = txtDescribr.Text;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtDescribr, ex.Message);
                flag = false;
            }
            try
            {
                if (txtBuyingPrice.Text == "")
                    throw new Exception("שדה חובה");
                p.BuyingPrice = Convert.ToDouble(txtBuyingPrice.Text);
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtBuyingPrice, ex.Message);
                flag = false;
            }
            try
            {
                if (txtCellingPrice.Text == "")
                    throw new Exception("שדה חובה");
                p.CellingPrice = Convert.ToDouble(txtCellingPrice.Text);
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtCellingPrice, ex.Message);
                flag = false;
            }
            try
            {
                if (cmbCategory.SelectedIndex == -1)
                    throw new Exception("לא נבחרה קטגוריה");
                p.Category = ((category)cmbCategory.SelectedItem).KodCategory;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(cmbCategory, ex.Message);
                flag = false;
            }  
            try
            {
                if (cmbSupplier.SelectedIndex == -1)
                    throw new Exception("לא נבחר ספק");
                p.Supplier = ((suppliers)cmbSupplier.SelectedItem).TzSupplier;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(cmbSupplier, ex.Message);
                flag = false;
            }           
            p.Status = true;
            p.IfNew= checkBox1.Checked;
            return flag;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.ParentForm.Text = "צליאק בקהילה-מנהל-מוצרים";
            Control c = this.Parent;
            while (!(c is UCManager))//זה מחפש את היוזר שמכיל את היוזר שאליו את רוצה לחזור
                c = c.Parent;
            (c as UCManager).panelMain.Controls.Clear();
            UCProduct uc = new UCProduct();//היוזר שאותו את רוצה להוסיף
            (c as UCManager).panelMain.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
        }

        private void btnAddPicture_Click(object sender, EventArgs e)
        {
            //openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.bmp;*.gif;.wmf;*.png;*.tif";
            //openFileDialog1.ShowDialog();
            //string a = Directory.GetParent(Directory.GetCurrentDirectory()).ToString();
            //string b = Directory.GetParent(a).ToString();
            //b = b + @"\pictures\";
            //s = openFileDialog1.SafeFileName;
            //b += s;
            //File.Copy(openFileDialog1.FileName, b);
            //p.Picture = s;
            //pictureBox1.Image = Image.FromFile(b);
            openFileDialog1.Filter = "Image Files|*.jpg;.jpeg;.bmp;.gif;.wmf;.png;.tif";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string sourceFilePath = openFileDialog1.FileName;
                string targetDirectory = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).ToString(), "picture");

                if (!Directory.Exists(targetDirectory))
                {
                    Directory.CreateDirectory(targetDirectory);
                }

                string targetFilePath = Path.Combine(targetDirectory, openFileDialog1.SafeFileName);

                if (!File.Exists(targetFilePath))
                {
                    File.Copy(sourceFilePath, targetFilePath);
                }

                p.Picture = openFileDialog1.SafeFileName;
                pictureBox1.Image = Image.FromFile(targetFilePath);
            }

        }
    }
}
