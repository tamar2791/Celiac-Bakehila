namespace celiacBakehila.GUI
{
    partial class UCManager
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
            this.btnProduct = new System.Windows.Forms.Button();
            this.btnClient = new System.Windows.Forms.Button();
            this.btnVolunteers = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNiulPas = new System.Windows.Forms.Label();
            this.lblVPas = new System.Windows.Forms.Label();
            this.lblClienPas = new System.Windows.Forms.Label();
            this.lblSuplierPas = new System.Windows.Forms.Label();
            this.lblProductPas = new System.Windows.Forms.Label();
            this.lblSalePas = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSupplier = new System.Windows.Forms.Button();
            this.btnSales = new System.Windows.Forms.Button();
            this.btnNihul = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProduct
            // 
            this.btnProduct.FlatAppearance.BorderSize = 0;
            this.btnProduct.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProduct.Location = new System.Drawing.Point(202, 19);
            this.btnProduct.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(115, 67);
            this.btnProduct.TabIndex = 0;
            this.btnProduct.Text = "רשימת המוצרים";
            this.btnProduct.UseVisualStyleBackColor = true;
            this.btnProduct.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnClient
            // 
            this.btnClient.FlatAppearance.BorderSize = 0;
            this.btnClient.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClient.Location = new System.Drawing.Point(592, 19);
            this.btnClient.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClient.Name = "btnClient";
            this.btnClient.Size = new System.Drawing.Size(115, 67);
            this.btnClient.TabIndex = 1;
            this.btnClient.Text = "רשימת הלקוחות";
            this.btnClient.UseVisualStyleBackColor = true;
            this.btnClient.Click += new System.EventHandler(this.btnClient_Click);
            // 
            // btnVolunteers
            // 
            this.btnVolunteers.FlatAppearance.BorderSize = 0;
            this.btnVolunteers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnVolunteers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolunteers.Location = new System.Drawing.Point(787, 19);
            this.btnVolunteers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnVolunteers.Name = "btnVolunteers";
            this.btnVolunteers.Size = new System.Drawing.Size(115, 67);
            this.btnVolunteers.TabIndex = 2;
            this.btnVolunteers.Text = "רשימת המתנדבים";
            this.btnVolunteers.UseVisualStyleBackColor = true;
            this.btnVolunteers.Click += new System.EventHandler(this.btnVolunteers_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblNiulPas);
            this.panel1.Controls.Add(this.lblVPas);
            this.panel1.Controls.Add(this.lblClienPas);
            this.panel1.Controls.Add(this.lblSuplierPas);
            this.panel1.Controls.Add(this.lblProductPas);
            this.panel1.Controls.Add(this.lblSalePas);
            this.panel1.Controls.Add(this.btnClient);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnSupplier);
            this.panel1.Controls.Add(this.btnSales);
            this.panel1.Controls.Add(this.btnNihul);
            this.panel1.Controls.Add(this.btnVolunteers);
            this.panel1.Controls.Add(this.btnProduct);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1296, 106);
            this.panel1.TabIndex = 3;
            // 
            // lblNiulPas
            // 
            this.lblNiulPas.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblNiulPas.Location = new System.Drawing.Point(979, 73);
            this.lblNiulPas.Name = "lblNiulPas";
            this.lblNiulPas.Size = new System.Drawing.Size(118, 13);
            this.lblNiulPas.TabIndex = 15;
            this.lblNiulPas.Text = "___________________";
            this.lblNiulPas.Visible = false;
            // 
            // lblVPas
            // 
            this.lblVPas.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblVPas.Location = new System.Drawing.Point(784, 88);
            this.lblVPas.Name = "lblVPas";
            this.lblVPas.Size = new System.Drawing.Size(118, 13);
            this.lblVPas.TabIndex = 13;
            this.lblVPas.Text = "___________________";
            this.lblVPas.Visible = false;
            // 
            // lblClienPas
            // 
            this.lblClienPas.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblClienPas.Location = new System.Drawing.Point(589, 73);
            this.lblClienPas.Name = "lblClienPas";
            this.lblClienPas.Size = new System.Drawing.Size(118, 13);
            this.lblClienPas.TabIndex = 12;
            this.lblClienPas.Text = "___________________";
            this.lblClienPas.Visible = false;
            // 
            // lblSuplierPas
            // 
            this.lblSuplierPas.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblSuplierPas.Location = new System.Drawing.Point(394, 73);
            this.lblSuplierPas.Name = "lblSuplierPas";
            this.lblSuplierPas.Size = new System.Drawing.Size(118, 13);
            this.lblSuplierPas.TabIndex = 11;
            this.lblSuplierPas.Text = "___________________";
            this.lblSuplierPas.Visible = false;
            // 
            // lblProductPas
            // 
            this.lblProductPas.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblProductPas.Location = new System.Drawing.Point(199, 73);
            this.lblProductPas.Name = "lblProductPas";
            this.lblProductPas.Size = new System.Drawing.Size(118, 13);
            this.lblProductPas.TabIndex = 10;
            this.lblProductPas.Text = "___________________";
            this.lblProductPas.Visible = false;
            // 
            // lblSalePas
            // 
            this.lblSalePas.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblSalePas.Location = new System.Drawing.Point(7, 73);
            this.lblSalePas.Name = "lblSalePas";
            this.lblSalePas.Size = new System.Drawing.Size(115, 13);
            this.lblSalePas.TabIndex = 9;
            this.lblSalePas.Text = "___________________";
            this.lblSalePas.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = global::celiacBakehila.Properties.Resources._1לוגו_משופץ;
            this.pictureBox1.Location = new System.Drawing.Point(1121, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(175, 106);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnSupplier
            // 
            this.btnSupplier.FlatAppearance.BorderSize = 0;
            this.btnSupplier.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupplier.Location = new System.Drawing.Point(397, 19);
            this.btnSupplier.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.Size = new System.Drawing.Size(115, 67);
            this.btnSupplier.TabIndex = 7;
            this.btnSupplier.Text = "רשימת הספקים";
            this.btnSupplier.UseVisualStyleBackColor = true;
            this.btnSupplier.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnSales
            // 
            this.btnSales.FlatAppearance.BorderSize = 0;
            this.btnSales.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSales.Location = new System.Drawing.Point(7, 19);
            this.btnSales.Margin = new System.Windows.Forms.Padding(4);
            this.btnSales.Name = "btnSales";
            this.btnSales.Size = new System.Drawing.Size(115, 67);
            this.btnSales.TabIndex = 6;
            this.btnSales.Text = "רשימת המכירות";
            this.btnSales.UseVisualStyleBackColor = true;
            this.btnSales.Click += new System.EventHandler(this.btnSales_Click);
            // 
            // btnNihul
            // 
            this.btnNihul.FlatAppearance.BorderSize = 0;
            this.btnNihul.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnNihul.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNihul.Location = new System.Drawing.Point(982, 19);
            this.btnNihul.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNihul.Name = "btnNihul";
            this.btnNihul.Size = new System.Drawing.Size(115, 67);
            this.btnNihul.TabIndex = 4;
            this.btnNihul.Text = "דף ניהול";
            this.btnNihul.UseVisualStyleBackColor = true;
            this.btnNihul.Click += new System.EventHandler(this.btnNihul_Click_1);
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 106);
            this.panelMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1296, 563);
            this.panelMain.TabIndex = 6;
            // 
            // UCManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UCManager";
            this.Size = new System.Drawing.Size(1296, 669);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Button btnClient;
        private System.Windows.Forms.Button btnVolunteers;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnNihul;
        private System.Windows.Forms.Button btnSales;
        private System.Windows.Forms.Button btnSupplier;
        public System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblNiulPas;
        private System.Windows.Forms.Label lblVPas;
        private System.Windows.Forms.Label lblClienPas;
        private System.Windows.Forms.Label lblSuplierPas;
        private System.Windows.Forms.Label lblProductPas;
        private System.Windows.Forms.Label lblSalePas;
    }
}
