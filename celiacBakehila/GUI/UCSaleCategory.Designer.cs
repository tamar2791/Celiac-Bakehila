namespace celiacBakehila.GUI
{
    partial class UCSaleCategory
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
            this.btnReurn = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // btnReurn
            // 
            this.btnReurn.Location = new System.Drawing.Point(260, 279);
            this.btnReurn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReurn.Name = "btnReurn";
            this.btnReurn.Size = new System.Drawing.Size(79, 28);
            this.btnReurn.TabIndex = 1;
            this.btnReurn.Text = "חזרה";
            this.btnReurn.UseVisualStyleBackColor = true;
            this.btnReurn.Visible = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(511, 279);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 28);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "הוסף";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Visible = false;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(476, 49);
            this.checkedListBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(180, 191);
            this.checkedListBox1.TabIndex = 3;
            this.checkedListBox1.Visible = false;
            // 
            // UCSaleCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnReurn);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "UCSaleCategory";
            this.Size = new System.Drawing.Size(777, 393);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnReurn;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}
