namespace PREINSPECTION
{
    partial class ItemAdd
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.itemSelectCombo = new System.Windows.Forms.ComboBox();
            this.itemTextBox = new System.Windows.Forms.TextBox();
            this.InsertButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.barcodeText = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // itemSelectCombo
            // 
            this.itemSelectCombo.FormattingEnabled = true;
            this.itemSelectCombo.Location = new System.Drawing.Point(16, 86);
            this.itemSelectCombo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemSelectCombo.Name = "itemSelectCombo";
            this.itemSelectCombo.Size = new System.Drawing.Size(106, 20);
            this.itemSelectCombo.TabIndex = 0;
            // 
            // itemTextBox
            // 
            this.itemTextBox.Location = new System.Drawing.Point(157, 86);
            this.itemTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemTextBox.Name = "itemTextBox";
            this.itemTextBox.Size = new System.Drawing.Size(88, 21);
            this.itemTextBox.TabIndex = 1;
            // 
            // InsertButton
            // 
            this.InsertButton.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.InsertButton.Location = new System.Drawing.Point(447, 82);
            this.InsertButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.InsertButton.Name = "InsertButton";
            this.InsertButton.Size = new System.Drawing.Size(72, 25);
            this.InsertButton.TabIndex = 2;
            this.InsertButton.Text = "제품추가";
            this.InsertButton.UseVisualStyleBackColor = true;
            this.InsertButton.Click += new System.EventHandler(this.insertButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.Image = global::PREINSPECTION.Properties.Resources.LS_ELECTRIC_시그니처_jpg;
            this.pictureBox1.Location = new System.Drawing.Point(1359, 835);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(387, 102);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(164, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "제품이름 쓰기";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(323, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "바코드";
            // 
            // barcodeText
            // 
            this.barcodeText.Location = new System.Drawing.Point(290, 86);
            this.barcodeText.Name = "barcodeText";
            this.barcodeText.Size = new System.Drawing.Size(109, 21);
            this.barcodeText.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CadetBlue;
            this.panel1.Controls.Add(this.itemSelectCombo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.InsertButton);
            this.panel1.Controls.Add(this.barcodeText);
            this.panel1.Controls.Add(this.itemTextBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(737, 313);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(569, 167);
            this.panel1.TabIndex = 12;
            // 
            // ItemAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(2237, 1138);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ItemAdd";
            this.Text = "itemAdd";
            this.Load += new System.EventHandler(this.ItemAdd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox itemSelectCombo;
        private System.Windows.Forms.TextBox itemTextBox;
        private System.Windows.Forms.Button InsertButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox barcodeText;
        private System.Windows.Forms.Panel panel1;
    }
}