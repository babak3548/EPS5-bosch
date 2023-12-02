namespace EPS
{
    partial class UCCommonRailInjectorManual
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
            this.components = new System.ComponentModel.Container();
            this.drdActuationProfile = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtManufacturer = new System.Windows.Forms.TextBox();
            this.TxtSerialnumber = new System.Windows.Forms.TextBox();
            this.txtTypeNumber = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txt2ReturnQuantity = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txt1ReturnQuantity = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txt2InjectedFuelQuantity = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMeasurementTime = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtActutionTime = new System.Windows.Forms.TextBox();
            this.txtPressure = new System.Windows.Forms.TextBox();
            this.txt1InjectedFuelQuantity = new System.Windows.Forms.TextBox();
            this.txtTestStepName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.criPruefschritteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.LoadF3 = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.btnStartTest = new System.Windows.Forms.Button();
            this.label27 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.criPruefschritteBindingSource)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // drdActuationProfile
            // 
            this.drdActuationProfile.FormattingEnabled = true;
            this.drdActuationProfile.Items.AddRange(new object[] {
            "14V",
            "28V"});
            this.drdActuationProfile.Location = new System.Drawing.Point(681, 81);
            this.drdActuationProfile.Name = "drdActuationProfile";
            this.drdActuationProfile.Size = new System.Drawing.Size(305, 33);
            this.drdActuationProfile.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtManufacturer);
            this.groupBox1.Controls.Add(this.drdActuationProfile);
            this.groupBox1.Controls.Add(this.TxtSerialnumber);
            this.groupBox1.Controls.Add(this.txtTypeNumber);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox1.Size = new System.Drawing.Size(1274, 130);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Identification";
            // 
            // txtManufacturer
            // 
            this.txtManufacturer.Location = new System.Drawing.Point(359, 83);
            this.txtManufacturer.Name = "txtManufacturer";
            this.txtManufacturer.Size = new System.Drawing.Size(293, 31);
            this.txtManufacturer.TabIndex = 9;
            // 
            // TxtSerialnumber
            // 
            this.TxtSerialnumber.Location = new System.Drawing.Point(1003, 81);
            this.TxtSerialnumber.Name = "TxtSerialnumber";
            this.TxtSerialnumber.Size = new System.Drawing.Size(245, 31);
            this.TxtSerialnumber.TabIndex = 6;
            // 
            // txtTypeNumber
            // 
            this.txtTypeNumber.Location = new System.Drawing.Point(52, 83);
            this.txtTypeNumber.Name = "txtTypeNumber";
            this.txtTypeNumber.Size = new System.Drawing.Size(293, 31);
            this.txtTypeNumber.TabIndex = 4;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(998, 41);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(145, 25);
            this.label22.TabIndex = 3;
            this.label22.Text = "Serial number";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(676, 41);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(169, 25);
            this.label21.TabIndex = 2;
            this.label21.Text = "Actuation Profile";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(354, 41);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(139, 25);
            this.label20.TabIndex = 1;
            this.label20.Text = "Manufacturer";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(47, 41);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(138, 25);
            this.label19.TabIndex = 0;
            this.label19.Text = "Type number";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(555, 245);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(27, 25);
            this.label13.TabIndex = 26;
            this.label13.Text = "H";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Location = new System.Drawing.Point(542, 246);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(18, 25);
            this.label14.TabIndex = 25;
            this.label14.Text = "/";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label15.Location = new System.Drawing.Point(532, 244);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(15, 16);
            this.label15.TabIndex = 24;
            this.label15.Text = "3";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(494, 244);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(46, 25);
            this.label16.TabIndex = 23;
            this.label16.Text = "mm";
            // 
            // txt2ReturnQuantity
            // 
            this.txt2ReturnQuantity.Location = new System.Drawing.Point(399, 241);
            this.txt2ReturnQuantity.Name = "txt2ReturnQuantity";
            this.txt2ReturnQuantity.Size = new System.Drawing.Size(94, 31);
            this.txt2ReturnQuantity.TabIndex = 22;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(374, 251);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(19, 25);
            this.label17.TabIndex = 21;
            this.label17.Text = "-";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(372, 232);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(24, 25);
            this.label18.TabIndex = 20;
            this.label18.Text = "+";
            // 
            // txt1ReturnQuantity
            // 
            this.txt1ReturnQuantity.Location = new System.Drawing.Point(267, 241);
            this.txt1ReturnQuantity.Name = "txt1ReturnQuantity";
            this.txt1ReturnQuantity.Size = new System.Drawing.Size(101, 31);
            this.txt1ReturnQuantity.TabIndex = 19;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(557, 197);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(27, 25);
            this.label12.TabIndex = 18;
            this.label12.Text = "H";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(544, 198);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(18, 25);
            this.label11.TabIndex = 17;
            this.label11.Text = "/";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label10.Location = new System.Drawing.Point(534, 196);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 16);
            this.label10.TabIndex = 16;
            this.label10.Text = "3";
            // 
            // txt2InjectedFuelQuantity
            // 
            this.txt2InjectedFuelQuantity.Location = new System.Drawing.Point(399, 193);
            this.txt2InjectedFuelQuantity.Name = "txt2InjectedFuelQuantity";
            this.txt2InjectedFuelQuantity.Size = new System.Drawing.Size(94, 31);
            this.txt2InjectedFuelQuantity.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(374, 203);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(19, 25);
            this.label8.TabIndex = 13;
            this.label8.Text = "-";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(372, 184);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 25);
            this.label7.TabIndex = 12;
            this.label7.Text = "+";
            // 
            // txtMeasurementTime
            // 
            this.txtMeasurementTime.Location = new System.Drawing.Point(267, 288);
            this.txtMeasurementTime.Name = "txtMeasurementTime";
            this.txtMeasurementTime.Size = new System.Drawing.Size(386, 31);
            this.txtMeasurementTime.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(496, 196);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 25);
            this.label9.TabIndex = 15;
            this.label9.Text = "mm";
            // 
            // txtActutionTime
            // 
            this.txtActutionTime.Location = new System.Drawing.Point(267, 97);
            this.txtActutionTime.Name = "txtActutionTime";
            this.txtActutionTime.Size = new System.Drawing.Size(386, 31);
            this.txtActutionTime.TabIndex = 9;
            // 
            // txtPressure
            // 
            this.txtPressure.Location = new System.Drawing.Point(267, 147);
            this.txtPressure.Name = "txtPressure";
            this.txtPressure.Size = new System.Drawing.Size(386, 31);
            this.txtPressure.TabIndex = 8;
            // 
            // txt1InjectedFuelQuantity
            // 
            this.txt1InjectedFuelQuantity.Location = new System.Drawing.Point(267, 193);
            this.txt1InjectedFuelQuantity.Name = "txt1InjectedFuelQuantity";
            this.txt1InjectedFuelQuantity.Size = new System.Drawing.Size(101, 31);
            this.txt1InjectedFuelQuantity.TabIndex = 7;
            // 
            // txtTestStepName
            // 
            this.txtTestStepName.Location = new System.Drawing.Point(267, 50);
            this.txtTestStepName.Name = "txtTestStepName";
            this.txtTestStepName.Size = new System.Drawing.Size(386, 31);
            this.txtTestStepName.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 294);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(196, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "Measurement Time";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 241);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Return Quantity";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Pressure";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Actuation time";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Test step name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.txt2ReturnQuantity);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.txt1ReturnQuantity);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txt2InjectedFuelQuantity);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtMeasurementTime);
            this.groupBox2.Controls.Add(this.txtActutionTime);
            this.groupBox2.Controls.Add(this.txtPressure);
            this.groupBox2.Controls.Add(this.txt1InjectedFuelQuantity);
            this.groupBox2.Controls.Add(this.txtTestStepName);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(-12, 190);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(923, 359);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Test spcifictions";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(654, 147);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(56, 25);
            this.label25.TabIndex = 29;
            this.label25.Text = "MPa";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(654, 98);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(35, 25);
            this.label24.TabIndex = 28;
            this.label24.Text = "µs";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(655, 290);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(23, 25);
            this.label23.TabIndex = 27;
            this.label23.Text = "s";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(210, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Injected fuel quantity";
            // 
            // listBox1
            // 
            this.listBox1.DataSource = this.criPruefschritteBindingSource;
            this.listBox1.DisplayMember = "Pruefschrittname";
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 25;
            this.listBox1.Location = new System.Drawing.Point(3, 27);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(327, 329);
            this.listBox1.TabIndex = 0;
            this.listBox1.ValueMember = "Pruefschrittname";
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // criPruefschritteBindingSource
            // 
            this.criPruefschritteBindingSource.DataSource = typeof(EPS.CriPruefschritte);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listBox1);
            this.groupBox3.Location = new System.Drawing.Point(932, 190);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(333, 359);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Test step list";
            // 
            // LoadF3
            // 
            this.LoadF3.BackgroundImage = global::EPS.Properties.Resources.Load;
            this.LoadF3.Location = new System.Drawing.Point(3, 24);
            this.LoadF3.Name = "LoadF3";
            this.LoadF3.Size = new System.Drawing.Size(110, 85);
            this.LoadF3.TabIndex = 0;
            this.LoadF3.UseVisualStyleBackColor = true;
            this.LoadF3.Click += new System.EventHandler(this.LoadF3_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label26.Location = new System.Drawing.Point(46, 5);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(39, 16);
            this.label26.TabIndex = 30;
            this.label26.Text = "Load";
            // 
            // btnStartTest
            // 
            this.btnStartTest.BackgroundImage = global::EPS.Properties.Resources.Continue;
            this.btnStartTest.Location = new System.Drawing.Point(138, 24);
            this.btnStartTest.Name = "btnStartTest";
            this.btnStartTest.Size = new System.Drawing.Size(111, 85);
            this.btnStartTest.TabIndex = 31;
            this.btnStartTest.UseVisualStyleBackColor = true;
            this.btnStartTest.Click += new System.EventHandler(this.btnStartTest_Click);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label27.Location = new System.Drawing.Point(161, 5);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(60, 16);
            this.label27.TabIndex = 32;
            this.label27.Text = "Continue";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label27);
            this.panel1.Controls.Add(this.btnStartTest);
            this.panel1.Controls.Add(this.label26);
            this.panel1.Controls.Add(this.LoadF3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 555);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1274, 120);
            this.panel1.TabIndex = 9;
            // 
            // UCCommonRailInjectorManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "UCCommonRailInjectorManual";
            this.Size = new System.Drawing.Size(1274, 675);
            this.Load += new System.EventHandler(this.UCCommonRailInjector_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.criPruefschritteBindingSource)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox drdActuationProfile;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TxtSerialnumber;
        private System.Windows.Forms.TextBox txtTypeNumber;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txt2ReturnQuantity;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txt1ReturnQuantity;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt2InjectedFuelQuantity;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMeasurementTime;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtActutionTime;
        private System.Windows.Forms.TextBox txtPressure;
        private System.Windows.Forms.TextBox txt1InjectedFuelQuantity;
        private System.Windows.Forms.TextBox txtTestStepName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.BindingSource criPruefschritteBindingSource;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button LoadF3;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button btnStartTest;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtManufacturer;
    }
}
