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

namespace celiacBakehila.GUI
{
    public partial class UCBMClient : UserControl
    {
        clientDB tblClient;
        buyingDetailsDB tblBuyingDetails;
        salesDB tblSales;
        buyDB tblBuy;
        sales s;
        bool b;
        bool bbb;
        public UCBMClient()
        {
            InitializeComponent();
            tblClient = new clientDB();
            tblBuyingDetails = new buyingDetailsDB();
            tblSales = new salesDB();
            tblBuy = new buyDB();
            List<client> lst = new List<client>();
            s = tblSales.GetList().FirstOrDefault(x => x.Distribution == true);
            bool bbb = false;
            if (s != null)
            {
                if (tblBuyingDetails.GetList().FirstOrDefault(x => x.KodSale == s.Kod) != null)
                    b = true;
                else
                {
                    dataGridView1.DataSource = tblClient.GetList().Where(x => x.BranchesOfClient().branchManagerOfBranches().TelManager == Validation.telBranchManager).Select(x => new { טלפון = x.Tel, פלאפון = x.Pel, שם_האב = x.NameFather, שם_האם = x.NameMother, שם_משפחה = x.LastName, מספר_ילדים = x.Child, רחוב = x.Street, מספר_בית = x.HouseNumber, מייל = x.Mail }).ToList();
                    panelMessege.Visible = true;
                    lblSale.Visible = false;
                }
                foreach (client item in tblClient.GetList().Where(x => x.Status == true && x.BranchesOfClient().branchManagerOfBranches().TelManager == Validation.telBranchManager))
                {
                    if (tblBuy.GetList().FirstOrDefault(x => x.TelClient == item.Tel && x.KodSale == s.Kod) != null)//SearchId(item.Tel) != null&&)
                    {
                        lst.Add(item);
                        bbb = true;
                    }
                }
                if (!bbb)
                {
                    dataGridView1.DataSource = tblClient.GetList().Where(x => x.BranchesOfClient().branchManagerOfBranches().TelManager == Validation.telBranchManager).Select(x => new { טלפון = x.Tel, פלאפון = x.Pel, שם_האב = x.NameFather, שם_האם = x.NameMother, שם_משפחה = x.LastName, מספר_ילדים = x.Child, רחוב = x.Street, מספר_בית = x.HouseNumber, מייל = x.Mail }).ToList();
                    panelMessege.Visible = true;
                    lblSale.Visible = false;
                    button1.Visible = false;
                }
                else
                    dataGridView1.DataSource = lst.Select(x => new { טלפון = x.Tel, פלאפון = x.Pel, שם_האב = x.NameFather, שם_האם = x.NameMother, שם_משפחה = x.LastName, מספר_ילדים = x.Child, רחוב = x.Street, מספר_בית = x.HouseNumber, מייל = x.Mail }).ToList();



                if (b)
                {
                    if (bbb)
                        button1.Visible = true;
                }
                else
                    button1.Visible = false;
            }
            else
            {
                dataGridView1.DataSource = tblClient.GetList().Where(x => x.BranchesOfClient().branchManagerOfBranches().TelManager == Validation.telBranchManager).Select(x => new { טלפון = x.Tel, פלאפון = x.Pel, שם_האב = x.NameFather, שם_האם = x.NameMother, שם_משפחה = x.LastName, מספר_ילדים = x.Child, רחוב = x.Street, מספר_בית = x.HouseNumber, מייל = x.Mail }).ToList();
                panelMessege.Visible = true;
                lblClient.Visible = false;
                button1.Visible = false;
            }
        }
        bool bb = false;
        string tzClient;
        private void button1_Click(object sender, EventArgs e)
        {
            if (!bb)
            {
                tzClient = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                int kod = s.Kod;
                dataGridView2.DataSource = tblBuyingDetails.GetList().Where(x => x.KodSale == kod && x.TelClient == tzClient).Select(x => new { שם_מוצר = x.ProductsOfBuyingDetails().NameProduct, קטגוריה = x.ProductsOfBuyingDetails().CategoryOfProduct().DescribeCategory,  מחיר = x.ProductsOfBuyingDetails().CellingPrice, כמות = x.OrderedAmount, סך_הכל_למוצר = x.TotalForProduct }).ToList();
                label1.Text = tblBuy.GetList().FirstOrDefault(x => x.KodSale == kod && x.TelClient == tzClient).TotalPrice.ToString();
                dataGridView1.Visible = false;
                dataGridView2.Visible = true;
                button1.Text = "סגור";
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                btnExel.Visible = true;
                bb = true;
            }
            else
            {
                button1.Text = "הצגת פרטי הזמנה";
                bb = false;
                dataGridView1.Visible = true;
                dataGridView2.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                btnExel.Visible = false;
            }
        }

        private void btnExel_Click(object sender, EventArgs e)
        {
            SaveToExcel(dataGridView2);
        }
        private void SaveToExcel(DataGridView dataGridView)
        {
            
            try
            {
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "רשימת הזמנה";
                string lastName = new clientDB().SearchId(tzClient).LastName;
                string fileName = "משפחת " + lastName + ".xlsx";
                string projectPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                string filePath = System.IO.Path.Combine(projectPath, fileName);
                Microsoft.Office.Interop.Excel.Range projectRange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 5]];
                projectRange.Merge();
                projectRange.Value = "משפחת " + lastName;
                projectRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                projectRange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                int lastRow = dataGridView.Rows.Count + 4;
                worksheet.Cells[lastRow, 1] = "סך הכל לתשלום: " + label1.Text + " שקלים.";
                for (int i = 0; i < dataGridView.Columns.Count; i++)
                {
                    worksheet.Cells[2, i + 1] = dataGridView.Columns[i].HeaderText;
                }
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 3, j + 1] = dataGridView.Rows[i].Cells[j].Value.ToString();
                    }
                }
                Microsoft.Office.Interop.Excel.Range dataRange = worksheet.Range[worksheet.Cells[2, 1], worksheet.Cells[dataGridView.Rows.Count + 2, dataGridView.Columns.Count]];
                dataRange.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                dataRange.Columns.AutoFit(); // Adjust column width based on content
                dataRange.Rows.AutoFit(); // Adjust row height based on content
                workbook.SaveAs(filePath, Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook, Type.Missing, Type.Missing, false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Microsoft.Office.Interop.Excel.XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing, Type.Missing);
                workbook.Close();
                app.Visible = true;
                Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Open(filePath);
                wb.PrintOutEx(Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                wb.PrintPreview();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Export to Excel failed: " + ex.Message);
            }
        }
    }
}