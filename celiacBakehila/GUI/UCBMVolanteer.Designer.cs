namespace celiacBakehila.GUI
{
    partial class UCBMVolanteer
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panelMain = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.panelDetails = new System.Windows.Forms.Panel();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtpel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txthouseNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtstreet = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtlName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtfName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txttel = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelMain.SuspendLayout();
            this.panelDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Location = new System.Drawing.Point(149, 17);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1082, 341);
            this.dataGridView1.TabIndex = 0;
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.button3);
            this.panelMain.Controls.Add(this.panelDetails);
            this.panelMain.Controls.Add(this.button2);
            this.panelMain.Controls.Add(this.button1);
            this.panelMain.Controls.Add(this.dataGridView1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1293, 470);
            this.panelMain.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(428, 384);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(155, 54);
            this.button3.TabIndex = 4;
            this.button3.Text = "מתנדבים שנמחקו";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panelDetails
            // 
            this.panelDetails.BackColor = System.Drawing.Color.White;
            this.panelDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDetails.Controls.Add(this.txtCity);
            this.panelDetails.Controls.Add(this.btnClose);
            this.panelDetails.Controls.Add(this.txtpel);
            this.panelDetails.Controls.Add(this.label1);
            this.panelDetails.Controls.Add(this.txtmail);
            this.panelDetails.Controls.Add(this.label2);
            this.panelDetails.Controls.Add(this.label3);
            this.panelDetails.Controls.Add(this.label4);
            this.panelDetails.Controls.Add(this.txthouseNumber);
            this.panelDetails.Controls.Add(this.label5);
            this.panelDetails.Controls.Add(this.txtstreet);
            this.panelDetails.Controls.Add(this.label6);
            this.panelDetails.Controls.Add(this.txtlName);
            this.panelDetails.Controls.Add(this.label8);
            this.panelDetails.Controls.Add(this.txtfName);
            this.panelDetails.Controls.Add(this.label9);
            this.panelDetails.Controls.Add(this.txttel);
            this.panelDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panelDetails.Location = new System.Drawing.Point(975, 16);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panelDetails.Size = new System.Drawing.Size(268, 411);
            this.panelDetails.TabIndex = 3;
            this.panelDetails.Visible = false;
            // 
            // txtCity
            // 
            this.txtCity.BackColor = System.Drawing.Color.White;
            this.txtCity.Location = new System.Drawing.Point(27, 192);
            this.txtCity.Margin = new System.Windows.Forms.Padding(4);
            this.txtCity.Name = "txtCity";
            this.txtCity.ReadOnly = true;
            this.txtCity.Size = new System.Drawing.Size(132, 25);
            this.txtCity.TabIndex = 61;
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(82, 356);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(107, 37);
            this.btnClose.TabIndex = 60;
            this.btnClose.Text = "סגור";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtpel
            // 
            this.txtpel.BackColor = System.Drawing.Color.White;
            this.txtpel.Location = new System.Drawing.Point(27, 78);
            this.txtpel.Margin = new System.Windows.Forms.Padding(4);
            this.txtpel.Name = "txtpel";
            this.txtpel.ReadOnly = true;
            this.txtpel.Size = new System.Drawing.Size(132, 25);
            this.txtpel.TabIndex = 57;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(174, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 17);
            this.label1.TabIndex = 43;
            this.label1.Text = "טלפון:";
            // 
            // txtmail
            // 
            this.txtmail.BackColor = System.Drawing.Color.White;
            this.txtmail.Location = new System.Drawing.Point(27, 308);
            this.txtmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtmail.Name = "txtmail";
            this.txtmail.ReadOnly = true;
            this.txtmail.Size = new System.Drawing.Size(132, 25);
            this.txtmail.TabIndex = 58;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(164, 119);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 44;
            this.label2.Text = "שם פרטי:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(155, 157);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 17);
            this.label3.TabIndex = 45;
            this.label3.Text = "שם משפחה:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(180, 195);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 17);
            this.label4.TabIndex = 46;
            this.label4.Text = "עיר:";
            // 
            // txthouseNumber
            // 
            this.txthouseNumber.BackColor = System.Drawing.Color.White;
            this.txthouseNumber.Location = new System.Drawing.Point(27, 270);
            this.txthouseNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txthouseNumber.Name = "txthouseNumber";
            this.txthouseNumber.ReadOnly = true;
            this.txthouseNumber.Size = new System.Drawing.Size(132, 25);
            this.txthouseNumber.TabIndex = 56;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(176, 235);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 17);
            this.label5.TabIndex = 47;
            this.label5.Text = "רחוב:";
            // 
            // txtstreet
            // 
            this.txtstreet.BackColor = System.Drawing.Color.White;
            this.txtstreet.Location = new System.Drawing.Point(27, 232);
            this.txtstreet.Margin = new System.Windows.Forms.Padding(4);
            this.txtstreet.Name = "txtstreet";
            this.txtstreet.ReadOnly = true;
            this.txtstreet.Size = new System.Drawing.Size(132, 25);
            this.txtstreet.TabIndex = 55;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(161, 273);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 17);
            this.label6.TabIndex = 48;
            this.label6.Text = "מספר בית:";
            // 
            // txtlName
            // 
            this.txtlName.BackColor = System.Drawing.Color.White;
            this.txtlName.Location = new System.Drawing.Point(27, 154);
            this.txtlName.Margin = new System.Windows.Forms.Padding(4);
            this.txtlName.Name = "txtlName";
            this.txtlName.ReadOnly = true;
            this.txtlName.Size = new System.Drawing.Size(132, 25);
            this.txtlName.TabIndex = 54;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(170, 81);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 17);
            this.label8.TabIndex = 49;
            this.label8.Text = "פלאפון:";
            // 
            // txtfName
            // 
            this.txtfName.BackColor = System.Drawing.Color.White;
            this.txtfName.Location = new System.Drawing.Point(27, 116);
            this.txtfName.Margin = new System.Windows.Forms.Padding(4);
            this.txtfName.Name = "txtfName";
            this.txtfName.ReadOnly = true;
            this.txtfName.Size = new System.Drawing.Size(132, 25);
            this.txtfName.TabIndex = 53;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(178, 311);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 17);
            this.label9.TabIndex = 50;
            this.label9.Text = "מייל:";
            // 
            // txttel
            // 
            this.txttel.BackColor = System.Drawing.Color.White;
            this.txttel.Location = new System.Drawing.Point(27, 40);
            this.txttel.Margin = new System.Windows.Forms.Padding(4);
            this.txttel.Name = "txttel";
            this.txttel.ReadOnly = true;
            this.txttel.Size = new System.Drawing.Size(132, 25);
            this.txttel.TabIndex = 52;
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(814, 384);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(155, 54);
            this.button2.TabIndex = 2;
            this.button2.Text = "הצגת פרטי מתנדב";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(621, 384);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 54);
            this.button1.TabIndex = 1;
            this.button1.Text = "מחיקת מתנדב";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // UCBMVolanteer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UCBMVolanteer";
            this.Size = new System.Drawing.Size(1293, 470);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.panelDetails.ResumeLayout(false);
            this.panelDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel panelDetails;
        private System.Windows.Forms.TextBox txtpel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txthouseNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtstreet;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtlName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtfName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txttel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button button3;
        public System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.TextBox txtCity;
    }
}
