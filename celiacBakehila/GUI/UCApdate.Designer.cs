namespace celiacBakehila.GUI
{
    partial class UCApdate
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
            this.TPKategory = new System.Windows.Forms.TabPage();
            this.TPCity = new System.Windows.Forms.TabPage();
            this.TPBranch = new System.Windows.Forms.TabPage();
            this.TPSisma = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridViewBranch = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.TPBranch.SuspendLayout();
            this.TPSisma.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBranch)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // TPKategory
            // 
            this.TPKategory.Location = new System.Drawing.Point(4, 25);
            this.TPKategory.Name = "TPKategory";
            this.TPKategory.Padding = new System.Windows.Forms.Padding(3);
            this.TPKategory.Size = new System.Drawing.Size(864, 340);
            this.TPKategory.TabIndex = 3;
            this.TPKategory.Text = "קטגוריות";
            this.TPKategory.UseVisualStyleBackColor = true;
            // 
            // TPCity
            // 
            this.TPCity.Location = new System.Drawing.Point(4, 25);
            this.TPCity.Name = "TPCity";
            this.TPCity.Padding = new System.Windows.Forms.Padding(3);
            this.TPCity.Size = new System.Drawing.Size(864, 340);
            this.TPCity.TabIndex = 2;
            this.TPCity.Text = "ערים";
            this.TPCity.UseVisualStyleBackColor = true;
            // 
            // TPBranch
            // 
            this.TPBranch.Controls.Add(this.panel2);
            this.TPBranch.Controls.Add(this.panel1);
            this.TPBranch.Location = new System.Drawing.Point(4, 25);
            this.TPBranch.Name = "TPBranch";
            this.TPBranch.Padding = new System.Windows.Forms.Padding(3);
            this.TPBranch.Size = new System.Drawing.Size(864, 340);
            this.TPBranch.TabIndex = 1;
            this.TPBranch.Text = "סניפים";
            this.TPBranch.UseVisualStyleBackColor = true;
            this.TPBranch.Click += new System.EventHandler(this.TPBranch_Click);
            // 
            // TPSisma
            // 
            this.TPSisma.Controls.Add(this.panel3);
            this.TPSisma.Location = new System.Drawing.Point(4, 25);
            this.TPSisma.Name = "TPSisma";
            this.TPSisma.Padding = new System.Windows.Forms.Padding(3);
            this.TPSisma.Size = new System.Drawing.Size(864, 340);
            this.TPSisma.TabIndex = 0;
            this.TPSisma.Text = "שינוי סיסמא";
            this.TPSisma.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TPSisma);
            this.tabControl1.Controls.Add(this.TPBranch);
            this.tabControl1.Controls.Add(this.TPCity);
            this.tabControl1.Controls.Add(this.TPKategory);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(872, 369);
            this.tabControl1.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 70);
            this.button1.TabIndex = 1;
            this.button1.Text = "הוספת סניף";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 99);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 70);
            this.button2.TabIndex = 2;
            this.button2.Text = "עדכון סניף";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 169);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(129, 70);
            this.button3.TabIndex = 3;
            this.button3.Text = "מחיקת סניף";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(541, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 334);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridViewBranch);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(538, 334);
            this.panel2.TabIndex = 5;
            // 
            // dataGridViewBranch
            // 
            this.dataGridViewBranch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBranch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewBranch.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewBranch.Name = "dataGridViewBranch";
            this.dataGridViewBranch.RowHeadersWidth = 51;
            this.dataGridViewBranch.RowTemplate.Height = 24;
            this.dataGridViewBranch.Size = new System.Drawing.Size(538, 334);
            this.dataGridViewBranch.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(172, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "הקש סיסמא נוכחית:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(172, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "הקש סיסמא חדשה:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(172, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "אימות סיסמא:";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(113, 145);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 22);
            this.button4.TabIndex = 3;
            this.button4.Text = "שמור שינויים";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(55, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(55, 59);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 5;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(55, 87);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 22);
            this.textBox3.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.textBox3);
            this.panel3.Controls.Add(this.textBox2);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.textBox1);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.button4);
            this.panel3.Location = new System.Drawing.Point(34, 19);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(332, 227);
            this.panel3.TabIndex = 7;
            // 
            // UCApdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "UCApdate";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(872, 369);
            this.TPBranch.ResumeLayout(false);
            this.TPSisma.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBranch)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage TPKategory;
        private System.Windows.Forms.TabPage TPCity;
        private System.Windows.Forms.TabPage TPBranch;
        private System.Windows.Forms.TabPage TPSisma;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridViewBranch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button4;
    }
}
