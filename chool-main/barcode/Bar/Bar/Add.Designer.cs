using System.Windows.Forms;

namespace Bar
{
    partial class Add
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
            richTextBox1 = new RichTextBox();
            richTextBox2 = new RichTextBox();
            richTextBox3 = new RichTextBox();
            richTextBox4 = new RichTextBox();
            richTextBox5 = new RichTextBox();
            richTextBox6 = new RichTextBox();
            richTextBox7 = new RichTextBox();
            richTextBox8 = new RichTextBox();
            richTextBox9 = new RichTextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label11 = new Label();
            label12 = new Label();
            CONTROL = new ComboBox();
            IGBT = new ComboBox();
            DIODE = new ComboBox();
            FUSE = new ComboBox();
            CT = new ComboBox();
            MAINCAP = new ComboBox();
            DRIVE = new ComboBox();
            POWER = new ComboBox();
            DMCT = new ComboBox();
            button1 = new Button();
            InverterBarcode = new TextBox();
            Search = new Button();
            InverterName = new TextBox();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(708, 274);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(478, 63);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(709, 352);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(478, 63);
            richTextBox2.TabIndex = 2;
            richTextBox2.Text = "";
            // 
            // richTextBox3
            // 
            richTextBox3.Location = new Point(709, 432);
            richTextBox3.Name = "richTextBox3";
            richTextBox3.Size = new Size(478, 63);
            richTextBox3.TabIndex = 3;
            richTextBox3.Text = "";
            // 
            // richTextBox4
            // 
            richTextBox4.Location = new Point(709, 512);
            richTextBox4.Name = "richTextBox4";
            richTextBox4.Size = new Size(478, 63);
            richTextBox4.TabIndex = 4;
            richTextBox4.Text = "";
            // 
            // richTextBox5
            // 
            richTextBox5.Location = new Point(709, 592);
            richTextBox5.Name = "richTextBox5";
            richTextBox5.Size = new Size(478, 63);
            richTextBox5.TabIndex = 5;
            richTextBox5.Text = "";
            // 
            // richTextBox6
            // 
            richTextBox6.Location = new Point(709, 672);
            richTextBox6.Name = "richTextBox6";
            richTextBox6.Size = new Size(478, 63);
            richTextBox6.TabIndex = 6;
            richTextBox6.Text = "";
            // 
            // richTextBox7
            // 
            richTextBox7.Location = new Point(709, 752);
            richTextBox7.Name = "richTextBox7";
            richTextBox7.Size = new Size(478, 63);
            richTextBox7.TabIndex = 7;
            richTextBox7.Text = "";
            // 
            // richTextBox8
            // 
            richTextBox8.Location = new Point(709, 832);
            richTextBox8.Name = "richTextBox8";
            richTextBox8.Size = new Size(478, 63);
            richTextBox8.TabIndex = 8;
            richTextBox8.Text = "";
            // 
            // richTextBox9
            // 
            richTextBox9.Location = new Point(709, 912);
            richTextBox9.Name = "richTextBox9";
            richTextBox9.Size = new Size(478, 63);
            richTextBox9.TabIndex = 9;
            richTextBox9.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(357, 278);
            label1.Name = "label1";
            label1.Size = new Size(131, 37);
            label1.TabIndex = 10;
            label1.Text = "IGBT/PIM";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("맑은 고딕", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(357, 358);
            label2.Name = "label2";
            label2.Size = new Size(97, 37);
            label2.TabIndex = 11;
            label2.Text = "DIODE";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("맑은 고딕", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(358, 436);
            label3.Name = "label3";
            label3.Size = new Size(202, 37);
            label3.TabIndex = 12;
            label3.Text = "FUSE(분압저항)";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("맑은 고딕", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(358, 516);
            label4.Name = "label4";
            label4.Size = new Size(127, 37);
            label4.TabIndex = 13;
            label4.Text = "C/T(NTC)";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("맑은 고딕", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(358, 596);
            label5.Name = "label5";
            label5.Size = new Size(244, 37);
            label5.TabIndex = 14;
            label5.Text = "MainCap/SUB PCB";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("맑은 고딕", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(358, 676);
            label6.Name = "label6";
            label6.Size = new Size(223, 37);
            label6.TabIndex = 15;
            label6.Text = "Drive(SMPS) PCB";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("맑은 고딕", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(358, 756);
            label7.Name = "label7";
            label7.Size = new Size(149, 37);
            label7.TabIndex = 16;
            label7.Text = "Power PCB";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("맑은 고딕", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(358, 836);
            label8.Name = "label8";
            label8.Size = new Size(168, 37);
            label8.TabIndex = 17;
            label8.Text = "DM+CT PCB";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("맑은 고딕", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(358, 916);
            label9.Name = "label9";
            label9.Size = new Size(262, 37);
            label9.TabIndex = 18;
            label9.Text = "Control/Main Board";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("맑은 고딕", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(1368, 209);
            label11.Name = "label11";
            label11.Size = new Size(224, 37);
            label11.TabIndex = 29;
            label11.Text = "변경할 부품 선택";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("맑은 고딕", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(858, 209);
            label12.Name = "label12";
            label12.Size = new Size(134, 37);
            label12.TabIndex = 30;
            label12.Text = "기존 부품";
            // 
            // CONTROL
            // 
            CONTROL.Font = new Font("맑은 고딕", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            CONTROL.FormattingEnabled = true;
            CONTROL.Location = new Point(1326, 920);
            CONTROL.Margin = new Padding(4);
            CONTROL.Name = "CONTROL";
            CONTROL.Size = new Size(323, 48);
            CONTROL.TabIndex = 40;
            CONTROL.Text = "선택하세요";
            // 
            // IGBT
            // 
            IGBT.Font = new Font("맑은 고딕", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            IGBT.FormattingEnabled = true;
            IGBT.Location = new Point(1325, 282);
            IGBT.Margin = new Padding(4);
            IGBT.Name = "IGBT";
            IGBT.Size = new Size(323, 48);
            IGBT.TabIndex = 32;
            IGBT.Text = "선택하세요";
            // 
            // DIODE
            // 
            DIODE.Font = new Font("맑은 고딕", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            DIODE.FormattingEnabled = true;
            DIODE.Location = new Point(1326, 360);
            DIODE.Margin = new Padding(4);
            DIODE.Name = "DIODE";
            DIODE.Size = new Size(323, 48);
            DIODE.TabIndex = 33;
            DIODE.Text = "선택하세요";
            // 
            // FUSE
            // 
            FUSE.Font = new Font("맑은 고딕", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            FUSE.FormattingEnabled = true;
            FUSE.Location = new Point(1326, 440);
            FUSE.Margin = new Padding(4);
            FUSE.Name = "FUSE";
            FUSE.Size = new Size(323, 48);
            FUSE.TabIndex = 34;
            FUSE.Text = "선택하세요";
            // 
            // CT
            // 
            CT.Font = new Font("맑은 고딕", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            CT.FormattingEnabled = true;
            CT.Location = new Point(1326, 520);
            CT.Margin = new Padding(4);
            CT.Name = "CT";
            CT.Size = new Size(323, 48);
            CT.TabIndex = 35;
            CT.Text = "선택하세요";
            // 
            // MAINCAP
            // 
            MAINCAP.Font = new Font("맑은 고딕", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            MAINCAP.FormattingEnabled = true;
            MAINCAP.Location = new Point(1326, 600);
            MAINCAP.Margin = new Padding(4);
            MAINCAP.Name = "MAINCAP";
            MAINCAP.Size = new Size(323, 48);
            MAINCAP.TabIndex = 36;
            MAINCAP.Text = "선택하세요";
            // 
            // DRIVE
            // 
            DRIVE.Font = new Font("맑은 고딕", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            DRIVE.FormattingEnabled = true;
            DRIVE.Location = new Point(1326, 680);
            DRIVE.Margin = new Padding(4);
            DRIVE.Name = "DRIVE";
            DRIVE.Size = new Size(323, 48);
            DRIVE.TabIndex = 37;
            DRIVE.Text = "선택하세요";
            // 
            // POWER
            // 
            POWER.Font = new Font("맑은 고딕", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            POWER.FormattingEnabled = true;
            POWER.Location = new Point(1326, 760);
            POWER.Margin = new Padding(4);
            POWER.Name = "POWER";
            POWER.Size = new Size(323, 48);
            POWER.TabIndex = 38;
            POWER.Text = "선택하세요";
            // 
            // DMCT
            // 
            DMCT.Font = new Font("맑은 고딕", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            DMCT.FormattingEnabled = true;
            DMCT.Location = new Point(1326, 840);
            DMCT.Margin = new Padding(4);
            DMCT.Name = "DMCT";
            DMCT.Size = new Size(323, 48);
            DMCT.TabIndex = 39;
            DMCT.Text = "선택하세요";
            // 
            // button1
            // 
            button1.Location = new Point(1083, 1011);
            button1.Name = "button1";
            button1.Size = new Size(124, 38);
            button1.TabIndex = 41;
            button1.Text = "적용";
            button1.UseVisualStyleBackColor = true;
            // 
            // InverterBarcode
            // 
            InverterBarcode.Location = new Point(718, 153);
            InverterBarcode.Name = "InverterBarcode";
            InverterBarcode.Size = new Size(395, 27);
            InverterBarcode.TabIndex = 42;
            // 
            // Search
            // 
            Search.Location = new Point(1147, 141);
            Search.Name = "Search";
            Search.Size = new Size(133, 51);
            Search.TabIndex = 43;
            Search.Text = "조회";
            Search.UseVisualStyleBackColor = true;
            Search.Click += Search_Click;
            // 
            // InverterName
            // 
            InverterName.Font = new Font("맑은 고딕", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            InverterName.Location = new Point(801, 53);
            InverterName.Name = "InverterName";
            InverterName.Size = new Size(395, 46);
            InverterName.TabIndex = 44;
            // 
            // Add
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1682, 643);
            Controls.Add(InverterName);
            Controls.Add(Search);
            Controls.Add(InverterBarcode);
            Controls.Add(button1);
            Controls.Add(CONTROL);
            Controls.Add(DMCT);
            Controls.Add(POWER);
            Controls.Add(DRIVE);
            Controls.Add(MAINCAP);
            Controls.Add(CT);
            Controls.Add(FUSE);
            Controls.Add(DIODE);
            Controls.Add(IGBT);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(richTextBox9);
            Controls.Add(richTextBox8);
            Controls.Add(richTextBox7);
            Controls.Add(richTextBox6);
            Controls.Add(richTextBox5);
            Controls.Add(richTextBox4);
            Controls.Add(richTextBox3);
            Controls.Add(richTextBox2);
            Controls.Add(richTextBox1);
            Font = new Font("맑은 고딕", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "Add";
            Text = "Add";
            ResumeLayout(false);
            PerformLayout();
        }

        private RichTextBox richTextBox1;
        private RichTextBox richTextBox2;
        private RichTextBox richTextBox3;
        private RichTextBox richTextBox4;
        private RichTextBox richTextBox5;
        private RichTextBox richTextBox6;
        private RichTextBox richTextBox7;
        private RichTextBox richTextBox8;
        private RichTextBox richTextBox9;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;

        #endregion
        private Label label11;
        private Label label12;
        private ComboBox CONTROL;
        private ComboBox IGBT;
        private ComboBox DIODE;
        private ComboBox FUSE;
        private ComboBox CT;
        private ComboBox MAINCAP;
        private ComboBox DRIVE;
        private ComboBox POWER;
        private ComboBox DMCT;
        private Button button1;
        private TextBox InverterBarcode;
        private Button Search;
        private TextBox InverterName;
    }
}