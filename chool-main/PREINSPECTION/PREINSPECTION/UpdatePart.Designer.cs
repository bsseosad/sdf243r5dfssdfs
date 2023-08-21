namespace PREINSPECTION
{
    partial class UpdatePart
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
            this.barcodeText = new System.Windows.Forms.TextBox();
            this.updateButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.partCombo = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // partGroupSelect
            // 
            this.partGroupSelect.FormattingEnabled = true;
            this.partGroupSelect.Location = new System.Drawing.Point(23, 35);
            this.partGroupSelect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.partGroupSelect.Name = "partGroupSelect";
            this.partGroupSelect.Size = new System.Drawing.Size(106, 23);
            this.partGroupSelect.TabIndex = 0;
            this.partGroupSelect.SelectedIndexChanged += new System.EventHandler(this.partGroupSelect_SelectedIndexChanged);
            // 
            // barcodeText
            // 
            this.barcodeText.Location = new System.Drawing.Point(322, 35);
            this.barcodeText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barcodeText.Name = "barcodeText";
            this.barcodeText.Size = new System.Drawing.Size(88, 23);
            this.barcodeText.TabIndex = 2;
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(455, 34);
            this.updateButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(66, 22);
            this.updateButton.TabIndex = 4;
            this.updateButton.Text = "저장";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(202, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "부품이름";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(354, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "바코드";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PREINSPECTION.Properties.Resources.LS_ELECTRIC_시그니처_jpg;
            this.pictureBox1.Location = new System.Drawing.Point(1359, 1044);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(387, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // partCombo
            // 
            this.partCombo.FormattingEnabled = true;
            this.partCombo.Location = new System.Drawing.Point(167, 35);
            this.partCombo.Name = "partCombo";
            this.partCombo.Size = new System.Drawing.Size(121, 23);
            this.partCombo.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel1.Controls.Add(this.partGroupSelect);
            this.panel1.Controls.Add(this.partCombo);
            this.panel1.Controls.Add(this.updateButton);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.barcodeText);
            this.panel1.Location = new System.Drawing.Point(603, 390);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(567, 76);
            this.panel1.TabIndex = 11;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::PREINSPECTION.Properties.Resources.LS_ELECTRIC_시그니처_jpg;
            this.pictureBox2.Location = new System.Drawing.Point(1359, 835);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(387, 102);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // UpdatePart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1846, 1138);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UpdatePart";
            this.Text = "UpdateFormcs";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox partGroupSelect;
        private System.Windows.Forms.TextBox barcodeText;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox partCombo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}