namespace CarAI
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.comboBoxNumberCars = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.comboBoxSteps = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.comboBoxTime = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelProgress = new System.Windows.Forms.Label();
            this.buttonNextStep = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(6, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(939, 308);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(236, 109);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(62, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.comboBoxNumberCars);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(395, 138);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(316, 109);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(62, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Reset";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(230, 51);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(97, 17);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "Can cars crash";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // comboBoxNumberCars
            // 
            this.comboBoxNumberCars.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNumberCars.FormattingEnabled = true;
            this.comboBoxNumberCars.Items.AddRange(new object[] {
            "1",
            "5",
            "10",
            "20",
            "50"});
            this.comboBoxNumberCars.Location = new System.Drawing.Point(316, 20);
            this.comboBoxNumberCars.Name = "comboBoxNumberCars";
            this.comboBoxNumberCars.Size = new System.Drawing.Size(54, 21);
            this.comboBoxNumberCars.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(227, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Number of cars:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(6, 19);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(215, 100);
            this.tabControl1.TabIndex = 4;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.comboBoxSteps);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage1.Size = new System.Drawing.Size(207, 74);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Maximal Steps";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // comboBoxSteps
            // 
            this.comboBoxSteps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSteps.FormattingEnabled = true;
            this.comboBoxSteps.Items.AddRange(new object[] {
            "100",
            "500",
            "1000",
            "5000",
            "10000"});
            this.comboBoxSteps.Location = new System.Drawing.Point(49, 6);
            this.comboBoxSteps.Name = "comboBoxSteps";
            this.comboBoxSteps.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSteps.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Steps:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.comboBoxTime);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage2.Size = new System.Drawing.Size(207, 74);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Maximal Time";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // comboBoxTime
            // 
            this.comboBoxTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTime.FormattingEnabled = true;
            this.comboBoxTime.Items.AddRange(new object[] {
            "5sek",
            "20sek",
            "1min",
            "2min"});
            this.comboBoxTime.Location = new System.Drawing.Point(51, 6);
            this.comboBoxTime.Name = "comboBoxTime";
            this.comboBoxTime.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTime.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Time:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Location = new System.Drawing.Point(12, 156);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(951, 333);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Simulation:";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressBar1.Location = new System.Drawing.Point(18, 495);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(939, 23);
            this.progressBar1.TabIndex = 3;
            // 
            // labelProgress
            // 
            this.labelProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelProgress.AutoSize = true;
            this.labelProgress.Location = new System.Drawing.Point(448, 505);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(35, 13);
            this.labelProgress.TabIndex = 4;
            this.labelProgress.Text = "label1";
            this.labelProgress.Visible = false;
            // 
            // buttonNextStep
            // 
            this.buttonNextStep.Location = new System.Drawing.Point(436, 121);
            this.buttonNextStep.Name = "buttonNextStep";
            this.buttonNextStep.Size = new System.Drawing.Size(75, 23);
            this.buttonNextStep.TabIndex = 5;
            this.buttonNextStep.Text = "Next Step";
            this.buttonNextStep.UseVisualStyleBackColor = true;
            this.buttonNextStep.Click += new System.EventHandler(this.buttonNextStep_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 544);
            this.Controls.Add(this.buttonNextStep);
            this.Controls.Add(this.labelProgress);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Car AI";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBoxSteps;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label labelProgress;
        private System.Windows.Forms.ComboBox comboBoxNumberCars;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonNextStep;
    }
}

