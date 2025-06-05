namespace celiacBakehila.GUI
{
    partial class UCNowSale
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
            this.panelCategory = new System.Windows.Forms.Panel();
            this.btnAllProduct = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSal = new System.Windows.Forms.Button();
            this.panelDetails = new System.Windows.Forms.Panel();
            this.btnX = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panelCategory.SuspendLayout();
            this.panelDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCategory
            // 
            this.panelCategory.AutoScroll = true;
            this.panelCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCategory.Controls.Add(this.btnAllProduct);
            this.panelCategory.Location = new System.Drawing.Point(945, 23);
            this.panelCategory.Name = "panelCategory";
            this.panelCategory.Size = new System.Drawing.Size(175, 285);
            this.panelCategory.TabIndex = 0;
            // 
            // btnAllProduct
            // 
            this.btnAllProduct.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAllProduct.FlatAppearance.BorderSize = 0;
            this.btnAllProduct.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAllProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAllProduct.Location = new System.Drawing.Point(0, 0);
            this.btnAllProduct.Name = "btnAllProduct";
            this.btnAllProduct.Size = new System.Drawing.Size(173, 42);
            this.btnAllProduct.TabIndex = 0;
            this.btnAllProduct.Text = "כל המוצרים ברצף";
            this.btnAllProduct.UseVisualStyleBackColor = true;
            this.btnAllProduct.Click += new System.EventHandler(this.btnAllProduct_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(987, 3);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "בחירת קטגוריה:";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(154, 23);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(750, 357);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // btnSal
            // 
            this.btnSal.FlatAppearance.BorderSize = 0;
            this.btnSal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSal.Location = new System.Drawing.Point(19, 93);
            this.btnSal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSal.Name = "btnSal";
            this.btnSal.Size = new System.Drawing.Size(129, 91);
            this.btnSal.TabIndex = 0;
            this.btnSal.Text = "למעבר לסל";
            this.btnSal.UseVisualStyleBackColor = true;
            this.btnSal.Click += new System.EventHandler(this.button1_Click);
            // 
            // panelDetails
            // 
            this.panelDetails.BackColor = System.Drawing.Color.White;
            this.panelDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDetails.Controls.Add(this.btnX);
            this.panelDetails.Location = new System.Drawing.Point(148, 3);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.Size = new System.Drawing.Size(776, 414);
            this.panelDetails.TabIndex = 3;
            this.panelDetails.Visible = false;
            // 
            // btnX
            // 
            this.btnX.BackColor = System.Drawing.Color.White;
            this.btnX.FlatAppearance.BorderSize = 0;
            this.btnX.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnX.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnX.Location = new System.Drawing.Point(-1, -1);
            this.btnX.Name = "btnX";
            this.btnX.Size = new System.Drawing.Size(47, 55);
            this.btnX.TabIndex = 2;
            this.btnX.Text = "x";
            this.btnX.UseVisualStyleBackColor = false;
            this.btnX.Click += new System.EventHandler(this.btnX_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.textBox1.Location = new System.Drawing.Point(961, 315);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(80, 26);
            this.textBox1.TabIndex = 11;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1047, 321);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "חיפוש מוצר";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "סנן לפי",
            "חדש",
            "הכל"});
            this.comboBox1.Location = new System.Drawing.Point(19, 272);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 25);
            this.comboBox1.TabIndex = 12;
            this.comboBox1.Visible = false;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // UCNowSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.panelDetails);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSal);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelCategory);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UCNowSale";
            this.Size = new System.Drawing.Size(1134, 420);
            this.panelCategory.ResumeLayout(false);
            this.panelDetails.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelCategory;
        private System.Windows.Forms.Button btnAllProduct;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Panel panelDetails;
        private System.Windows.Forms.Button btnSal;
        public System.Windows.Forms.Button btnX;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}
