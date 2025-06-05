using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using celiacBakehila.GUI;
using celiacBakehila.BLL;

namespace celiacBakehila
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            panelSisma.Visible = true;
            panel1.Visible = false;
            
        }

        private void lblSisma_Click(object sender, EventArgs e)
        {

        }

        private void txtSisma_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            if (txtSisma.Text=="")
                errorProvider1.SetError(txtSisma, "לא הוקשה סיסמא");
            if (txtSisma.Text != "123")
                errorProvider1.SetError(txtSisma, "סיסמא שגויה");
            else
            {
                panelManager.Visible = true;
                panelManager.Controls.Clear();
                UCManager uc=new UCManager();              
                panelManager.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                this.Text = "צליאק בקהילה-מנהל";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panelSisma.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panelManager.Visible = true;
            panelManager.Controls.Clear();
            UCnewUser uc = new UCnewUser();
            panelManager.Controls.Add(uc);
            this.Text = "צליאק בקהילה-משתמש חדש";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UCBranchManager uc1;
            errorProvider1.Clear();
            clientDB lstClient=new clientDB();
            branchManagerDB lstBranchManager = new branchManagerDB();
            if (!Validation.IsTel(textBox1.Text))
                errorProvider1.SetError(textBox1, "מספר טלפון לא תקין");
            else
            {
                if(lstBranchManager.SearchId(textBox1.Text)!=null)
                {
                    DialogResult d = MessageBox.Show("הנך רשום במערכת כמנהל סניף,\nהאם ברצונך להכנס כמנהל סניף?", "מנהל סניף", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    if (d == DialogResult.Yes)
                    {
                        Validation.telBranchManager = textBox1.Text;
                        panelManager.Visible = true;
                        panelManager.Controls.Clear();
                         uc1 = new UCBranchManager();
                        panelManager.Controls.Add(uc1);
                        uc1.Dock = DockStyle.Fill;
                        this.Text = "צליאק בקהילה-מנהל סניף";
                    }
                    else
                    { 
                        if (lstClient.SearchId(textBox1.Text) == null)
                        {
                            DialogResult di = MessageBox.Show("הטלפון לא קיים במאגר\nהאם ברצונך להרשם לעמותה?", "לקוח לא מזוהה", MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1,MessageBoxOptions.RtlReading);
                            if (di == DialogResult.Yes)
                            {
                                Validation.telUser = textBox1.Text;
                                Validation.id = true;
                                panelManager.Visible = true;
                                panelManager.Controls.Clear();
                                UCnewUser uc = new UCnewUser();
                                panelManager.Controls.Add(uc);
                                uc.Dock = DockStyle.Fill;
                                this.Text = "צליאק בקהילה-משתמש חדש";
                            }
                            else
                                textBox1.Text = "";
                        }
                        else
                        {
                            Validation.telUser = textBox1.Text;
                            panelManager.Visible = true;
                            panelManager.Controls.Clear();
                            UCuser uc = new UCuser();
                            panelManager.Controls.Add(uc);
                            uc.Dock= DockStyle.Fill;
                            this.Text = "צליאק בקהילה-משתמש";
                        }
                    }
                }
                else
                {

                    if (lstClient.SearchId(textBox1.Text) == null)
                    {
                        DialogResult di = MessageBox.Show("הטלפון לא קיים במאגר\nהאם ברצונך להרשם לעמותה?", "לקוח לא מזוהה", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                        if (di == DialogResult.Yes)
                        {
                            Validation.telUser = textBox1.Text;
                            Validation.id = true;
                            panelManager.Visible = true;
                            panelManager.Controls.Clear();
                            UCnewUser uc = new UCnewUser();
                            panelManager.Controls.Add(uc);
                            this.Text = "צליאק בקהילה-משתמש חדש";
                        }
                        else
                            textBox1.Text = "";
                    }
                    else
                    {
                        Validation.telUser = textBox1.Text;
                        panelManager.Visible = true;
                        panelManager.Controls.Clear();
                        UCuser uc = new UCuser();
                        panelManager.Controls.Add(uc);
                        this.Text = "צליאק בקהילה-משתמש";
                    }
                }
            }
        }
    }
}
