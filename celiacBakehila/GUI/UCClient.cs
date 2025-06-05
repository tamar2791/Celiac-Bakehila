using celiacBakehila.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using celiacBakehila.BLL;

namespace celiacBakehila.GUI
{
    public partial class UCClient : UserControl
    {
        clientDB tblClient;
        public UCClient()
        {
            InitializeComponent();
            c = new client();
            tblClient = new clientDB();
            dataGridView1.DataSource = tblClient.GetList().Select(x => new { טלפון = x.Tel, פלאפון = x.Pel, שם_האב = x.NameFather, שם_האם = x.NameMother, שם_משפחה = x.LastName, רחוב = x.Street, מספר_בית = x.HouseNumber, עיר = x.CitiesOfClient().NameCity, מייל = x.Mail, סניף = x.BranchesOfClient().NameBranch }).ToList();
        }

        private void btnHatzeg_Click(object sender, EventArgs e)
        {


        }
        client c;
        private void FillTxt()
        {
            txttel.Text = c.Tel;
            txtpel.Text = c.Pel;
            txtNameFather.Text = c.NameFather;
            txtNameMother.Text = c.NameMother;
            txtlName.Text = c.LastName;
            label23.Text = c.Child.ToString();
            txtStreet.Text = c.Street;
            txtHouseNumber.Text = c.HouseNumber;
            txtMail.Text = c.Mail;
            txttel.ReadOnly = true;
            txtpel.ReadOnly = true;
            txtNameFather.ReadOnly = true;
            txtNameMother.ReadOnly = true;
            txtlName.ReadOnly = true;
            txtStreet.ReadOnly = true;
            txtHouseNumber.ReadOnly = true;
            txtMail.ReadOnly = true;
            textBox2.Text = c.BranchesOfClient().NameBranch;
            textBox3.Text = c.CitiesOfClient().NameCity;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            panelDetails.Visible = false;
            btnHatzeg.Visible = true;
            btnProduct.Visible = true;
            textBox1.Visible = true;
            label22.Visible = true;
        }
        buyDB tblBuy = new buyDB();
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dataGridView2.Visible = true;
            string tzClient = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            c = tblClient.SearchId(tzClient);
            dataGridView2.DataSource = tblBuy.GetList().Where(x => x.TelClient == c.Tel).Select(x => new { קוד_מכירה = x.KodSale, תאריך_מכירה = x.DateSale, סך_הכל_לתשלום = x.TotalPrice }).ToList();

        }

        private void btnHatzeg_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            panelDetails.Visible = true;
            btnHatzeg.Visible = false;
            btnProduct.Visible = true;
            textBox1.Visible = true;
            label22.Visible = true;
            textBox1.Visible = false;
            label22.Visible = false;
            btnProduct.Visible=false;
            string tzClient = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            c = tblClient.SearchId(tzClient);
            FillTxt();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            string tzClient = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            if (new buyDB().GetList().FirstOrDefault(x => x.TelClient == tzClient) != null)
            {
                btnDedailBuy.Visible = true;
                c = tblClient.SearchId(tzClient);
                dataGridView2.DataSource = tblBuy.GetList().Where(x => x.TelClient == tzClient).Select(x => new { קוד_מכירה = x.KodSale, תאריך_מכירה = x.DateSale, סך_הכל_לתשלום = x.TotalPrice }).ToList();
                dataGridView2.Visible = true;
                panel1.Visible = true;
                dataGridView1.Visible = false;
                btnHatzeg.Visible = false;
                btnProduct.Visible = false;
                textBox1.Visible = false;
                label22.Visible = false;
            }
            else
            {
                MessageBox.Show("ללקוח זה אין הזמנות");
                dataGridView1.Visible = true;
            }

        }
        buyingDetailsDB tblBuyingDetails = new buyingDetailsDB();
        bool b = false;
        private void button2_Click(object sender, EventArgs e)
        {
            string tzClient = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            int kod = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[0].Value);
            if (!b)
            {
                dataGridView3.DataSource = tblBuyingDetails.GetList().Where(x => x.KodSale == kod && x.TelClient == tzClient).Select(x => new { שם_מוצר = x.ProductsOfBuyingDetails().NameProduct, קטגוריה = x.ProductsOfBuyingDetails().CategoryOfProduct().DescribeCategory, מחיר = x.ProductsOfBuyingDetails().CellingPrice, כמות = x.OrderedAmount, סך_הכל_למוצר = x.TotalForProduct }).ToList();
                dataGridView3.Visible = true;
                dataGridView2.Visible = false;
                b = true;
                btnDedailBuy.Text = "סגור פרטי הזמנה";
                lblSum.Text ="סך הכך להזמנה זו: " +tblBuyingDetails.GetList().Where(x => x.KodSale == kod && x.TelClient == tzClient).Sum(x=>x.TotalForProduct).ToString()+" שקלים";
                lblSum.Visible = true;

            }
            else
            {
                b = false;
                btnDedailBuy.Text = "הצגת פרטי הזמנה";
                dataGridView3.Visible = false;
                lblSum.Visible = false;
                dataGridView2.Visible = true;
            }

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            dataGridView3.Visible = false;
            dataGridView2.Visible = true;
            btnDedailBuy.Visible = true;
            //button3.Visible = true;
            //button1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView2.Visible = false;
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (Validation.IsNum(textBox1.Text))
                    dataGridView1.DataSource = tblClient.GetList().Where(x => x.Tel.StartsWith(textBox1.Text) || x.Pel.StartsWith(textBox1.Text)).Select(x => new { טלפון = x.Tel, פלאפון = x.Pel, שם_האב = x.NameFather, שם_האם = x.NameMother, שם_משפחה = x.LastName, רחוב = x.Street, מספר_בית = x.HouseNumber, עיר = x.CitiesOfClient().NameCity, מייל = x.Mail, סניף = x.BranchesOfClient().NameBranch }).ToList();
                if (Validation.IsHebrew(textBox1.Text))
                    dataGridView1.DataSource = tblClient.GetList().Where(x => x.NameFather.StartsWith(textBox1.Text) || x.NameMother.StartsWith(textBox1.Text) || x.LastName.StartsWith(textBox1.Text)).Select(x => new { טלפון = x.Tel, פלאפון = x.Pel, שם_האב = x.NameFather, שם_האם = x.NameMother, שם_משפחה = x.LastName, רחוב = x.Street, מספר_בית = x.HouseNumber, עיר = x.CitiesOfClient().NameCity, מייל = x.Mail, סניף = x.BranchesOfClient().NameBranch }).ToList();
            }
            else
                dataGridView1.DataSource = tblClient.GetList().Select(x => new { טלפון = x.Tel, פלאפון = x.Pel, שם_האב = x.NameFather, שם_האם = x.NameMother, שם_משפחה = x.LastName, רחוב = x.Street, מספר_בית = x.HouseNumber, עיר = x.CitiesOfClient().NameCity, מייל = x.Mail, סניף = x.BranchesOfClient().NameBranch }).ToList();

        }

        private void btnX_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            lblSum.Visible = false;
            btnDedailBuy.Text = "הצגת פרטי הזמנה";
            dataGridView1.Visible = true;
            btnProduct.Visible = true;
            btnHatzeg.Visible = true;
            textBox1.Visible = true;
            label22.Visible = true;
        }
    }
}
