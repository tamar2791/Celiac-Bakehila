using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using celiacBakehila.BLL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace celiacBakehila.GUI
{
    public partial class UCSal : UserControl
    {
        bool flagUpdate = false;
        public UCSal(bool flagUpdate)
        {
            InitializeComponent();
            CreateUCProduct();
            this.flagUpdate = flagUpdate;
            if (flowLayoutPanel1.Controls.Count<=0)
            {
                lblEmpty2.Visible = true;
                lblEmpty.Visible = true;
                btnClose.Visible = false;
            }
            else
            {
                lblEmpty2.Visible = false;
                lblEmpty.Visible = false;
                btnClose.Visible = true;
            }
            object[] years = new object[6];
            for (int i = 0; i < 6; i++)
            {
                years[i] = DateTime.Now.Year + i;
            }
            comboBoxY.Items.AddRange(years);
        }

        private void CreateUCProduct()
        {
            UCOneSal ucos;
            foreach (buyingDetails item in Validation.lstSAL)
            {
                ucos = new UCOneSal(item);
                flowLayoutPanel1.Controls.Add(ucos);
            }
        }
        buy b =new buy();
        buyDB lstBuy= new buyDB();
        buyingDetails bd = new buyingDetails();
        buyingDetailsDB lstBuyingDetails = new buyingDetailsDB();
        private void btnClose_Click(object sender, EventArgs e)
        {
            MessageBox.Show("שים לב! לאחר ביצוע הזמנה לא ניתן לבטל הזמנת מוצר");
            panelPay.Visible = true;
            FillText();
            btnClose.Visible=false;
            lblSum.Text = "סך הכל לתשלום: " + Validation.lstSAL.Sum(x=>x.TotalForProduct)+" שקלים";
        }

        private void FillText()
        {
            textBox4.Text = new clientDB().SearchId( Validation.telUser).CreditCardDetailsNumber;
            comboBoxY.Text = new clientDB().SearchId(Validation.telUser).CreditCardDetailsValidityY;
            comboBoxM.SelectedItem= new clientDB().SearchId(Validation.telUser).CreditCardDetailsValidityM;
            textBox2.Text = new clientDB().SearchId(Validation.telUser).CreditCardDetailsCvv;
            textBox1.Text = new clientDB().SearchId(Validation.telUser).CreditCardDetailsTz;
        }

        private void CreatebuyingDetails()
        {
            foreach (buyingDetails item in Validation.lstSAL)
            {
                if (flagUpdate)
                {
                    bd = new buyingDetailsDB().GetList().FirstOrDefault(x => x.KodSale == b.KodSale && x.TelClient == Validation.telUser && x.KodProduct == item.KodProduct);
                    if (bd != null)
                    {
                        bd.OrderedAmount = item.OrderedAmount;
                        bd.GetAmount = item.GetAmount;
                        bd.TotalForProduct = item.TotalForProduct;
                        bd.Status = item.Status;
                        lstBuyingDetails.ApdateRow(bd);
                    }
                    else
                    {
                        bd = new buyingDetails(); 
                        bd.KodSale = item.KodSale;
                        bd.TelClient = item.TelClient;
                        bd.KodProduct = item.KodProduct;
                        bd.OrderedAmount = item.OrderedAmount;
                        bd.GetAmount = item.GetAmount;
                        bd.TotalForProduct = item.TotalForProduct;
                        bd.Status = item.Status;
                        lstBuyingDetails.AddNew(bd);
                    }
                }
                else
                {
                    bd.KodSale = item.KodSale;
                    bd.TelClient = item.TelClient;
                    bd.KodProduct = item.KodProduct;
                    bd.OrderedAmount = item.OrderedAmount;
                    bd.GetAmount = item.GetAmount;
                    bd.TotalForProduct = item.TotalForProduct;
                    bd.Status = item.Status;
                    lstBuyingDetails.AddNew(bd);
                }
            }
        }
        private void CreateBuy()
        {
            b.TelClient = Validation.telUser;
            b.KodSale= new salesDB().GetList(). FirstOrDefault(x => x.Distribution == true).Kod;
            b.DateSale=DateTime.Now;
            b.TotalPrice = Validation.lstSAL.Sum(x => x.TotalForProduct);
            b.Status = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (CreditCard())
            {
                if (!flagUpdate)
                {
                    //הוספת הזמנה חדשה
                    b = new buy();
                    CreateBuy();
                    lstBuy.AddNew(b);
                }
                else
                {
                    b = new buyDB().SearchKodSale(new salesDB().GetList().FirstOrDefault(x => x.Distribution == true).Kod);
                }
                //הוספה לטבלת פרטי הזמנה
                CreatebuyingDetails();
                MessageBox.Show("ההזמנה נקלטה במערכת\nתודה ולהתראות");
                Control c = this.Parent;
                while (!(c is UCuser))
                    c = c.Parent;
                (c as UCuser).panelMain.Visible = false;
                (c as UCuser).lblSalePas.Visible = false;
                Validation.lstSAL.Clear();
                this.ParentForm.Text = "צליאק בקהילה-משתמש-מכירות";
            }
        }
        public bool IsValidCreditCardNumber(string creditCardNumber)
        {
            //הסרת רווחים או - ממספר כרטיס אשראי
            creditCardNumber = creditCardNumber.Replace(" ", "").Replace("-", "");
            //בדיקת אורך מספר כרטיס אשראי
            if (creditCardNumber.Length < 13 || creditCardNumber.Length > 16)
                return false;
            //בדיקה שהמספר מכיל רק מספרים
            foreach (char c in creditCardNumber)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            //בדיקה אם מספר האשראי תקף
            int sum = 0;
            bool alternate = false;
            for (int i = creditCardNumber.Length - 1; i >= 0; i--)
            {
                int digit = int.Parse(creditCardNumber[i].ToString());
                if (alternate)
                {
                    digit *= 2;
                    if (digit > 9)
                        digit -= 9;
                }
                sum += digit;
                alternate = !alternate;
            }
            return (sum % 10 == 0);
        }
        private bool CreditCard()
        {
            bool flag = true;
            errorProvider1.Clear();
            try
            {
                string creditCardNumber = textBox4.Text.Replace(" ", "");
                if (textBox4.Text == "")
                    throw new Exception("שדה חובה");
                if (!IsValidCreditCardNumber(creditCardNumber))
                    throw new Exception("מספר כרטיס אשראי לא תקין");
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(label2, ex.Message);
                flag = false;
            }
            try
            {
                if (comboBoxM.SelectedItem == null || comboBoxY.SelectedItem == null)
                    throw new Exception("בחר תאריך");
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(label3, ex.Message);
                flag = false;
            }
            try
            {
                if (textBox2.Text == "")
                    throw new Exception("שדה חובה");
                if(textBox2.Text.Length<3)
                    throw new Exception("ספרות בטיחות חייבות להכיל 3 ספרות");
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(label5, ex.Message);
                flag = false;
            }
            try
            {
                if (textBox1.Text == "")
                    throw new Exception("שדה חובה");
                if(!Validation.CheckId(textBox1.Text))
                    throw new Exception("ת.ז. לא תקינה");
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(label4, ex.Message);
                flag = false;
            }
            return flag;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            groupBox1.Text = "תשלום באמצעות כרטיס אשראי אחר";
            textBox1.Text = "";
            textBox2.Text = "";
            comboBoxM.SelectedItem= null;
            comboBoxY.SelectedItem= null;
            comboBoxY.Enabled= true;
            comboBoxM.Enabled= true;
            textBox4.Text = "";
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox4.ReadOnly = false;
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            groupBox1.Text = "תשלום באמצעות כרטיס האשראי השמור במערכת";
            comboBoxM.Enabled = true;
            comboBoxY.Enabled = true;
            FillText();
        }
        private void comboBoxY_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxY.SelectedItem != null && comboBoxY.SelectedItem.ToString() == DateTime.Now.Year.ToString())
            {
                comboBoxM.Items.Clear();
                for (int i = DateTime.Now.Month + 1; i <= 12; i++)
                {
                    comboBoxM.Items.Add(i);
                }
            }
            else
            {
                comboBoxM.Items.Clear();
                comboBoxM.Items.AddRange(new[] { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" });
            }
        }
    }
}
