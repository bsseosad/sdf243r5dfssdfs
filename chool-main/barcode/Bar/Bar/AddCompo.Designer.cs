namespace Bar
{
    partial class AddCompo
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
            ComponentName = new RichTextBox();
            ComponentBarcode = new RichTextBox();
            comboBox1 = new ComboBox();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // ComponentName
            // 
            ComponentName.Location = new Point(478, 366);
            ComponentName.Name = "ComponentName";
            ComponentName.Size = new Size(790, 89);
            ComponentName.TabIndex = 1;
            ComponentName.Text = "";
            // 
            // ComponentBarcode
            // 
            ComponentBarcode.Location = new Point(1317, 366);
            ComponentBarcode.Name = "ComponentBarcode";
            ComponentBarcode.Size = new Size(925, 89);
            ComponentBarcode.TabIndex = 2;
            ComponentBarcode.Text = "";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "IGBT/PIM", "DIODE", "FUSE(분압저항)", "C/T(NTC)", "Main Capacitor / SUB PCB", "Drive(SMPS) PCB", "Power PCB", "DM + CT PCB", "Control S/W ver / Main Board" });
            comboBox1.Location = new Point(63, 401);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(387, 33);
            comboBox1.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(2315, 401);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 4;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(2440, 399);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 5;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // AddCompo
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2564, 1570);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Controls.Add(ComponentBarcode);
            Controls.Add(ComponentName);
            Name = "AddCompo";
            Text = "AddCompo";
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox ComponentName;
        private RichTextBox ComponentBarcode;
        private ComboBox comboBox1;
        private Button button1;
        private Button button2;
    }
}