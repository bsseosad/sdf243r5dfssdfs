namespace PREINSPECTION
{
    partial class itemSelect
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.itemGroupBox = new System.Windows.Forms.ComboBox();
            this.itemBox = new System.Windows.Forms.ComboBox();
            this.partAdd = new System.Windows.Forms.Button();
            this.updatePart = new System.Windows.Forms.Button();
            this.itemAdd = new System.Windows.Forms.Button();
            this.Mapping = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // itemGroupBox
            // 
            this.itemGroupBox.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.itemGroupBox.FormattingEnabled = true;
            this.itemGroupBox.Location = new System.Drawing.Point(44, 28);
            this.itemGroupBox.Name = "itemGroupBox";
            this.itemGroupBox.Size = new System.Drawing.Size(106, 23);
            this.itemGroupBox.TabIndex = 0;
            this.itemGroupBox.SelectedIndexChanged += new System.EventHandler(this.itemGroupBox_SelectedIndexChanged);
            // 
            // itemBox
            // 
            this.itemBox.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.itemBox.FormattingEnabled = true;
            this.itemBox.Location = new System.Drawing.Point(204, 28);
            this.itemBox.Name = "itemBox";
            this.itemBox.Size = new System.Drawing.Size(106, 23);
            this.itemBox.TabIndex = 1;
            // 
            // partAdd
            // 
            this.partAdd.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.partAdd.Location = new System.Drawing.Point(14, 65);
            this.partAdd.Name = "partAdd";
            this.partAdd.Size = new System.Drawing.Size(102, 26);
            this.partAdd.TabIndex = 2;
            this.partAdd.Text = "부품추가하기";
            this.partAdd.UseVisualStyleBackColor = true;
            this.partAdd.Click += new System.EventHandler(this.partAdd_Click);
            // 
            // updatePart
            // 
            this.updatePart.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.updatePart.Location = new System.Drawing.Point(137, 65);
            this.updatePart.Name = "updatePart";
            this.updatePart.Size = new System.Drawing.Size(115, 26);
            this.updatePart.TabIndex = 0;
            this.updatePart.Text = "부품바코드수정";
            this.updatePart.UseVisualStyleBackColor = true;
            this.updatePart.Click += new System.EventHandler(this.updatePart_Click);
            // 
            // itemAdd
            // 
            this.itemAdd.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.itemAdd.Location = new System.Drawing.Point(278, 65);
            this.itemAdd.Name = "itemAdd";
            this.itemAdd.Size = new System.Drawing.Size(99, 26);
            this.itemAdd.TabIndex = 4;
            this.itemAdd.Text = "제품추가하기";
            this.itemAdd.UseVisualStyleBackColor = true;
            this.itemAdd.Click += new System.EventHandler(this.itemAdd_Click);
            // 
            // Mapping
            // 
            this.Mapping.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Mapping.Location = new System.Drawing.Point(335, 21);
            this.Mapping.Name = "Mapping";
            this.Mapping.Size = new System.Drawing.Size(125, 26);
            this.Mapping.TabIndex = 5;
            this.Mapping.Text = "제품에 부품넣기";
            this.Mapping.UseVisualStyleBackColor = true;
            this.Mapping.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PREINSPECTION.Properties.Resources.LS_ELECTRIC_시그니처_jpg;
            this.pictureBox1.Location = new System.Drawing.Point(1359, 835);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(387, 102);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Mapping);
            this.panel1.Controls.Add(this.itemGroupBox);
            this.panel1.Controls.Add(this.itemBox);
            this.panel1.Location = new System.Drawing.Point(403, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(497, 61);
            this.panel1.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(212, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Mapping";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(693, 293);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(638, 65);
            this.label3.TabIndex = 10;
            this.label3.Text = "제품의 바코드를 찍어주세요";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightPink;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.partAdd);
            this.panel2.Controls.Add(this.updatePart);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.itemAdd);
            this.panel2.Location = new System.Drawing.Point(12, 819);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(921, 105);
            this.panel2.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(368, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "부품 설정";
            // 
            // itemSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1855, 933);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Name = "itemSelect";
            this.Text = "Form1";
            this.Deactivate += new System.EventHandler(this.itemSelect_Deactivate);
            this.Load += new System.EventHandler(this.itemSelect_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox itemGroupBox;
        private System.Windows.Forms.ComboBox itemBox;
        private System.Windows.Forms.Button partAdd;
        private System.Windows.Forms.Button updatePart;
        private System.Windows.Forms.Button itemAdd;
        private System.Windows.Forms.Button Mapping;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
    }
}

