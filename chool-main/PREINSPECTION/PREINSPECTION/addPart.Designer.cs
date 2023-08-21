namespace PREINSPECTION
{
    partial class addPart
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
            this.partGroupSelect = new System.Windows.Forms.ComboBox();
            this.nameText = new System.Windows.Forms.TextBox();
            this.barcodeText = new System.Windows.Forms.TextBox();
            this.insert = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // partGroupSelect
            // 
            this.partGroupSelect.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.partGroupSelect.FormattingEnabled = true;
            this.partGroupSelect.Location = new System.Drawing.Point(65, 57);
            this.partGroupSelect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.partGroupSelect.Name = "partGroupSelect";
            this.partGroupSelect.Size = new System.Drawing.Size(106, 23);
            this.partGroupSelect.TabIndex = 0;
            // 
            // nameText
            // 
            this.nameText.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.nameText.Location = new System.Drawing.Point(222, 57);
            this.nameText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(134, 23);
            this.nameText.TabIndex = 1;
            // 
            // barcodeText
            // 
            this.barcodeText.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.barcodeText.Location = new System.Drawing.Point(399, 57);
            this.barcodeText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barcodeText.Name = "barcodeText";
            this.barcodeText.Size = new System.Drawing.Size(134, 23);
            this.barcodeText.TabIndex = 2;
            // 
            // insert
            // 
            this.insert.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.insert.Location = new System.Drawing.Point(257, 100);
            this.insert.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.insert.Name = "insert";
            this.insert.Size = new System.Drawing.Size(66, 23);
            this.insert.TabIndex = 4;
            this.insert.Text = "저장하기";
            this.insert.UseVisualStyleBackColor = true;
            this.insert.Click += new System.EventHandler(this.insert_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(268, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "부품이름";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(434, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "바코드이름";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PREINSPECTION.Properties.Resources.LS_ELECTRIC_시그니처_jpg;
            this.pictureBox1.Location = new System.Drawing.Point(1359, 835);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(387, 102);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RosyBrown;
            this.panel1.Controls.Add(this.insert);
            this.panel1.Controls.Add(this.barcodeText);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.partGroupSelect);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.nameText);
            this.panel1.Location = new System.Drawing.Point(535, 215);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(624, 143);
            this.panel1.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(694, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(359, 47);
            this.label3.TabIndex = 18;
            this.label3.Text = "부품을 추가해 주세요";
            // 
            // addPart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(2480, 1138);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "addPart";
            this.Text = "addPart";
            this.Load += new System.EventHandler(this.addPart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox partGroupSelect;
        private System.Windows.Forms.TextBox nameText;
        private System.Windows.Forms.TextBox barcodeText;
        private System.Windows.Forms.Button insert;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
    }
}