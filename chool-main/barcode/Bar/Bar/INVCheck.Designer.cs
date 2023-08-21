namespace Bar
{
    partial class INVCheck
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            ComponentCombo = new ComboBox();
            EnterButton = new Button();
            helpProvider1 = new HelpProvider();
            InverterCategory = new ComboBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(841, 743);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(78, 20);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(1236, 479);
            button2.Margin = new Padding(2);
            button2.Name = "button2";
            button2.Size = new Size(78, 20);
            button2.TabIndex = 2;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // ComponentCombo
            // 
            ComponentCombo.FormattingEnabled = true;
            ComponentCombo.Location = new Point(519, 269);
            ComponentCombo.Name = "ComponentCombo";
            ComponentCombo.Size = new Size(420, 23);
            ComponentCombo.TabIndex = 4;
            ComponentCombo.Text = "선택하세요";
            // 
            // EnterButton
            // 
            EnterButton.Location = new Point(963, 269);
            EnterButton.Name = "EnterButton";
            EnterButton.Size = new Size(75, 23);
            EnterButton.TabIndex = 5;
            EnterButton.Text = "확인";
            EnterButton.UseVisualStyleBackColor = true;
            EnterButton.Click += EnterButton_Click;
            // 
            // InverterCategory
            // 
            InverterCategory.FormattingEnabled = true;
            InverterCategory.Location = new Point(303, 269);
            InverterCategory.Name = "InverterCategory";
            InverterCategory.Size = new Size(153, 23);
            InverterCategory.TabIndex = 6;
            InverterCategory.Text = "선택하세요";
            InverterCategory.SelectedIndexChanged += InverterCategory_SelectedIndexChanged;
            // 
            // INVCheck
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1724, 861);
            Controls.Add(InverterCategory);
            Controls.Add(EnterButton);
            Controls.Add(ComponentCombo);
            Controls.Add(button2);
            Controls.Add(button1);
            Margin = new Padding(2);
            Name = "INVCheck";
            Text = "Form1";
            Load += INVCheck_Load;
            ResumeLayout(false);
        }

        #endregion
        private Button button1;
        private Button button2;
        private ComboBox ComponentCombo;
        private Button EnterButton;
        private HelpProvider helpProvider1;
        private ComboBox InverterCategory;
    }
}