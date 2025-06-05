namespace celiacBakehila.GUI
{
    partial class UCVolenteers
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
            this.panelDataGridView = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txttele = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bnReturn = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
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
            this.label10 = new System.Windows.Forms.Label();
            this.btnOldVolenteer = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnHatzeg = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelMain = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panelDataGridView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDataGridView
            // 
            this.panelDataGridView.Controls.Add(this.dataGridView1);
            this.panelDataGridView.Controls.Add(this.txttele);
            this.panelDataGridView.Controls.Add(this.label7);
            this.panelDataGridView.Location = new System.Drawing.Point(114, 13);
            this.panelDataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelDataGridView.Name = "panelDataGridView";
            this.panelDataGridView.Size = new System.Drawing.Size(1307, 260);
            this.panelDataGridView.TabIndex = 0;
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
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1307, 260);
            this.dataGridView1.TabIndex = 0;
            // 
            // txttele
            // 
            this.txttele.Location = new System.Drawing.Point(111, 247);
            this.txttele.Margin = new System.Windows.Forms.Padding(4);
            this.txttele.Name = "txttele";
            this.txttele.Size = new System.Drawing.Size(132, 25);
            this.txttele.TabIndex = 38;
            this.txttele.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(254, 253);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 17);
            this.label7.TabIndex = 29;
            this.label7.Text = "טלפון:";
            this.label7.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bnReturn);
            this.panel1.Controls.Add(this.comboBox2);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.txtpel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtmail);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txthouseNumber);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtstreet);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtlName);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtfName);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txttel);
            this.panel1.Controls.Add(this.label10);
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel1.Location = new System.Drawing.Point(509, 32);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel1.Size = new System.Drawing.Size(372, 436);
            this.panel1.TabIndex = 1;
            this.panel1.Visible = false;
            // 
            // bnReturn
            // 
            this.bnReturn.FlatAppearance.BorderSize = 0;
            this.bnReturn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.bnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bnReturn.ForeColor = System.Drawing.Color.Black;
            this.bnReturn.Location = new System.Drawing.Point(78, 378);
            this.bnReturn.Margin = new System.Windows.Forms.Padding(4);
            this.bnReturn.Name = "bnReturn";
            this.bnReturn.Size = new System.Drawing.Size(112, 54);
            this.bnReturn.TabIndex = 43;
            this.bnReturn.Text = "סגור";
            this.bnReturn.UseVisualStyleBackColor = true;
            this.bnReturn.Click += new System.EventHandler(this.bnReturn_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.BackColor = System.Drawing.Color.White;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(33, 330);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(132, 25);
            this.comboBox2.TabIndex = 42;
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.White;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(29, 176);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(132, 25);
            this.comboBox1.TabIndex = 41;
            // 
            // txtpel
            // 
            this.txtpel.BackColor = System.Drawing.Color.White;
            this.txtpel.Location = new System.Drawing.Point(29, 62);
            this.txtpel.Margin = new System.Windows.Forms.Padding(4);
            this.txtpel.Name = "txtpel";
            this.txtpel.Size = new System.Drawing.Size(132, 25);
            this.txtpel.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(188, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 17);
            this.label1.TabIndex = 23;
            this.label1.Text = "טלפון:";
            // 
            // txtmail
            // 
            this.txtmail.BackColor = System.Drawing.Color.White;
            this.txtmail.Location = new System.Drawing.Point(33, 292);
            this.txtmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtmail.Name = "txtmail";
            this.txtmail.Size = new System.Drawing.Size(132, 25);
            this.txtmail.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(178, 103);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 24;
            this.label2.Text = "שם פרטי:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(169, 141);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 17);
            this.label3.TabIndex = 25;
            this.label3.Text = "שם משפחה:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(194, 179);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 17);
            this.label4.TabIndex = 26;
            this.label4.Text = "עיר:";
            // 
            // txthouseNumber
            // 
            this.txthouseNumber.BackColor = System.Drawing.Color.White;
            this.txthouseNumber.Location = new System.Drawing.Point(29, 254);
            this.txthouseNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txthouseNumber.Name = "txthouseNumber";
            this.txthouseNumber.Size = new System.Drawing.Size(132, 25);
            this.txthouseNumber.TabIndex = 37;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(190, 219);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 17);
            this.label5.TabIndex = 27;
            this.label5.Text = "רחוב:";
            // 
            // txtstreet
            // 
            this.txtstreet.BackColor = System.Drawing.Color.White;
            this.txtstreet.Location = new System.Drawing.Point(29, 216);
            this.txtstreet.Margin = new System.Windows.Forms.Padding(4);
            this.txtstreet.Name = "txtstreet";
            this.txtstreet.Size = new System.Drawing.Size(132, 25);
            this.txtstreet.TabIndex = 36;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(175, 257);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 17);
            this.label6.TabIndex = 28;
            this.label6.Text = "מספר בית:";
            // 
            // txtlName
            // 
            this.txtlName.BackColor = System.Drawing.Color.White;
            this.txtlName.Location = new System.Drawing.Point(29, 138);
            this.txtlName.Margin = new System.Windows.Forms.Padding(4);
            this.txtlName.Name = "txtlName";
            this.txtlName.Size = new System.Drawing.Size(132, 25);
            this.txtlName.TabIndex = 35;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(184, 65);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 17);
            this.label8.TabIndex = 30;
            this.label8.Text = "פלאפון:";
            // 
            // txtfName
            // 
            this.txtfName.BackColor = System.Drawing.Color.White;
            this.txtfName.Location = new System.Drawing.Point(29, 100);
            this.txtfName.Margin = new System.Windows.Forms.Padding(4);
            this.txtfName.Name = "txtfName";
            this.txtfName.Size = new System.Drawing.Size(132, 25);
            this.txtfName.TabIndex = 34;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(192, 295);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 17);
            this.label9.TabIndex = 31;
            this.label9.Text = "מייל:";
            // 
            // txttel
            // 
            this.txttel.BackColor = System.Drawing.Color.White;
            this.txttel.Location = new System.Drawing.Point(33, 24);
            this.txttel.Margin = new System.Windows.Forms.Padding(4);
            this.txttel.Name = "txttel";
            this.txttel.Size = new System.Drawing.Size(132, 25);
            this.txttel.TabIndex = 33;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(190, 333);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 17);
            this.label10.TabIndex = 32;
            this.label10.Text = "סניף:";
            // 
            // btnOldVolenteer
            // 
            this.btnOldVolenteer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnOldVolenteer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnOldVolenteer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOldVolenteer.Location = new System.Drawing.Point(1017, 291);
            this.btnOldVolenteer.Name = "btnOldVolenteer";
            this.btnOldVolenteer.Size = new System.Drawing.Size(93, 89);
            this.btnOldVolenteer.TabIndex = 2;
            this.btnOldVolenteer.Text = "הצגת מתנדבים שנמחקו";
            this.btnOldVolenteer.UseVisualStyleBackColor = true;
            this.btnOldVolenteer.Click += new System.EventHandler(this.btnOldVolenteer_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnRemove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Location = new System.Drawing.Point(662, 287);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(93, 89);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.Text = "מחיקת מתנדב";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnHatzeg
            // 
            this.btnHatzeg.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnHatzeg.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnHatzeg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHatzeg.Location = new System.Drawing.Point(307, 287);
            this.btnHatzeg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHatzeg.Name = "btnHatzeg";
            this.btnHatzeg.Size = new System.Drawing.Size(93, 89);
            this.btnHatzeg.TabIndex = 0;
            this.btnHatzeg.Text = "הצגת פרטי מתנדב";
            this.btnHatzeg.UseVisualStyleBackColor = true;
            this.btnHatzeg.Click += new System.EventHandler(this.btnHatzeg_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.label11);
            this.panelMain.Controls.Add(this.textBox1);
            this.panelMain.Controls.Add(this.btnOldVolenteer);
            this.panelMain.Controls.Add(this.btnRemove);
            this.panelMain.Controls.Add(this.panel1);
            this.panelMain.Controls.Add(this.btnHatzeg);
            this.panelMain.Controls.Add(this.panelDataGridView);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1296, 563);
            this.panelMain.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1260, 322);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 17);
            this.label11.TabIndex = 4;
            this.label11.Text = "חיפוש";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1154, 319);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 25);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // UCVolenteers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UCVolenteers";
            this.Size = new System.Drawing.Size(1296, 563);
            this.panelDataGridView.ResumeLayout(false);
            this.panelDataGridView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDataGridView;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnHatzeg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox txtpel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txttele;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txthouseNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtstreet;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtlName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtfName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txttel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button bnReturn;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnOldVolenteer;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox1;
    }
}
