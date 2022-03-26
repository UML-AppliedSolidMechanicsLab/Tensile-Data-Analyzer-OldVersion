/*
 * Created by SharpDevelop.
 * User: e46221
 * Date: 7/10/2007
 * Time: 8:05 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace StressStrainData
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.Browse = new System.Windows.Forms.Button();
            this.openFileTxt = new System.Windows.Forms.TextBox();
            this.inputGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.rowEndTxtBox = new System.Windows.Forms.TextBox();
            this.previewBttn = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.rowStartTxtBox = new System.Windows.Forms.TextBox();
            this.addCurrentBttn = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.addBttn = new System.Windows.Forms.Button();
            this.doneBttn = new System.Windows.Forms.Button();
            this.lengthGroupBox = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lengthTxtBox = new System.Windows.Forms.TextBox();
            this.tranChanGroupBox = new System.Windows.Forms.GroupBox();
            this.tranChan = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.areaGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.xSecAreaTxtBox = new System.Windows.Forms.TextBox();
            this.tranStrainGroupBox = new System.Windows.Forms.GroupBox();
            this.noStrainRadioButton = new System.Windows.Forms.RadioButton();
            this.tranStrainRadioButton = new System.Windows.Forms.RadioButton();
            this.axChanGroupBox = new System.Windows.Forms.GroupBox();
            this.axChan = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.axStrainGroupBox = new System.Windows.Forms.GroupBox();
            this.tbStrainCol = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.dispRadioBttn = new System.Windows.Forms.RadioButton();
            this.strainRadioBttn = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbStressCol = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.loadRadioBttn = new System.Windows.Forms.RadioButton();
            this.stressRadioBttn1 = new System.Windows.Forms.RadioButton();
            this.temperatureTxtBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.intervalTxtBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.analyzeBttn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.axStrainCutoffTxtBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupInputsGroupBox = new System.Windows.Forms.GroupBox();
            this.locPolyOrderTxtBx = new System.Windows.Forms.TextBox();
            this.globPolyOrderTxtBx = new System.Windows.Forms.TextBox();
            this.offsetGroupBx = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.offsetPercentTxtBx = new System.Windows.Forms.TextBox();
            this.rMinTxtBx = new System.Windows.Forms.TextBox();
            this.offsetCheckBx = new System.Windows.Forms.CheckBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.materialTxtBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.plotGroupBox = new System.Windows.Forms.GroupBox();
            this.YieldStressBttn = new System.Windows.Forms.Button();
            this.plotBttn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.stressStrainRadioBttn = new System.Windows.Forms.RadioButton();
            this.tranAxRadioBttn = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.fileNumRadioBttn = new System.Windows.Forms.RadioButton();
            this.allRadioBttn = new System.Windows.Forms.RadioButton();
            this.fileNumberBox = new System.Windows.Forms.NumericUpDown();
            this.typeGroupBox = new System.Windows.Forms.GroupBox();
            this.SlopeRadioBttn = new System.Windows.Forms.RadioButton();
            this.combinedRadioBttn = new System.Windows.Forms.RadioButton();
            this.rawRadioBttn = new System.Windows.Forms.RadioButton();
            this.dataFilesGroupBox = new System.Windows.Forms.GroupBox();
            this.resultsBttn = new System.Windows.Forms.Button();
            this.fileWriteBttn = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.taTotalCheckBox = new System.Windows.Forms.CheckBox();
            this.ssTotalCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.taLoessCheckBox = new System.Windows.Forms.CheckBox();
            this.ssLoessCheckBox = new System.Windows.Forms.CheckBox();
            this.tadhCheckBox = new System.Windows.Forms.CheckBox();
            this.ssdhCheckBox = new System.Windows.Forms.CheckBox();
            this.inputGroupBox.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.lengthGroupBox.SuspendLayout();
            this.tranChanGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tranChan)).BeginInit();
            this.areaGroupBox.SuspendLayout();
            this.tranStrainGroupBox.SuspendLayout();
            this.axChanGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axChan)).BeginInit();
            this.axStrainGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupInputsGroupBox.SuspendLayout();
            this.offsetGroupBx.SuspendLayout();
            this.plotGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileNumberBox)).BeginInit();
            this.typeGroupBox.SuspendLayout();
            this.dataFilesGroupBox.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // Browse
            // 
            this.Browse.Location = new System.Drawing.Point(330, 12);
            this.Browse.Name = "Browse";
            this.Browse.Size = new System.Drawing.Size(62, 23);
            this.Browse.TabIndex = 0;
            this.Browse.Text = "Browse";
            this.Browse.UseVisualStyleBackColor = true;
            this.Browse.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BrowseMouseClick);
            // 
            // openFileTxt
            // 
            this.openFileTxt.Location = new System.Drawing.Point(12, 12);
            this.openFileTxt.Name = "openFileTxt";
            this.openFileTxt.ReadOnly = true;
            this.openFileTxt.Size = new System.Drawing.Size(309, 20);
            this.openFileTxt.TabIndex = 1;
            // 
            // inputGroupBox
            // 
            this.inputGroupBox.BackColor = System.Drawing.SystemColors.Control;
            this.inputGroupBox.Controls.Add(this.groupBox7);
            this.inputGroupBox.Controls.Add(this.previewBttn);
            this.inputGroupBox.Controls.Add(this.groupBox6);
            this.inputGroupBox.Controls.Add(this.addCurrentBttn);
            this.inputGroupBox.Controls.Add(this.label10);
            this.inputGroupBox.Controls.Add(this.addBttn);
            this.inputGroupBox.Controls.Add(this.doneBttn);
            this.inputGroupBox.Controls.Add(this.lengthGroupBox);
            this.inputGroupBox.Controls.Add(this.tranChanGroupBox);
            this.inputGroupBox.Controls.Add(this.areaGroupBox);
            this.inputGroupBox.Controls.Add(this.tranStrainGroupBox);
            this.inputGroupBox.Controls.Add(this.axChanGroupBox);
            this.inputGroupBox.Controls.Add(this.axStrainGroupBox);
            this.inputGroupBox.Controls.Add(this.groupBox1);
            this.inputGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputGroupBox.Location = new System.Drawing.Point(11, 50);
            this.inputGroupBox.Name = "inputGroupBox";
            this.inputGroupBox.Size = new System.Drawing.Size(667, 176);
            this.inputGroupBox.TabIndex = 2;
            this.inputGroupBox.TabStop = false;
            this.inputGroupBox.Text = "Individual File Inputs";
            this.inputGroupBox.Visible = false;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label19);
            this.groupBox7.Controls.Add(this.rowEndTxtBox);
            this.groupBox7.Location = new System.Drawing.Point(361, 49);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(190, 33);
            this.groupBox7.TabIndex = 20;
            this.groupBox7.TabStop = false;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(7, 12);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(123, 15);
            this.label19.TabIndex = 1;
            this.label19.Text = "Data ends on row:";
            // 
            // rowEndTxtBox
            // 
            this.rowEndTxtBox.Location = new System.Drawing.Point(130, 9);
            this.rowEndTxtBox.Name = "rowEndTxtBox";
            this.rowEndTxtBox.Size = new System.Drawing.Size(51, 20);
            this.rowEndTxtBox.TabIndex = 0;
            this.rowEndTxtBox.Text = "100";
            // 
            // previewBttn
            // 
            this.previewBttn.Location = new System.Drawing.Point(18, 120);
            this.previewBttn.Name = "previewBttn";
            this.previewBttn.Size = new System.Drawing.Size(75, 23);
            this.previewBttn.TabIndex = 36;
            this.previewBttn.Text = "Preview";
            this.previewBttn.UseVisualStyleBackColor = true;
            this.previewBttn.Click += new System.EventHandler(this.PreviewBttnClick);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label16);
            this.groupBox6.Controls.Add(this.rowStartTxtBox);
            this.groupBox6.Location = new System.Drawing.Point(361, 16);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(190, 33);
            this.groupBox6.TabIndex = 19;
            this.groupBox6.TabStop = false;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(7, 12);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(123, 15);
            this.label16.TabIndex = 1;
            this.label16.Text = "Data starts on row:";
            // 
            // rowStartTxtBox
            // 
            this.rowStartTxtBox.Location = new System.Drawing.Point(130, 9);
            this.rowStartTxtBox.Name = "rowStartTxtBox";
            this.rowStartTxtBox.Size = new System.Drawing.Size(51, 20);
            this.rowStartTxtBox.TabIndex = 0;
            this.rowStartTxtBox.Text = "12";
            // 
            // addCurrentBttn
            // 
            this.addCurrentBttn.Location = new System.Drawing.Point(560, 16);
            this.addCurrentBttn.Name = "addCurrentBttn";
            this.addCurrentBttn.Size = new System.Drawing.Size(75, 23);
            this.addCurrentBttn.TabIndex = 35;
            this.addCurrentBttn.Text = "Add Current";
            this.addCurrentBttn.UseVisualStyleBackColor = true;
            this.addCurrentBttn.Click += new System.EventHandler(this.AddCurrentBttnClick);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(560, 100);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 17);
            this.label10.TabIndex = 34;
            this.label10.Text = "0 file(s) scanned";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // addBttn
            // 
            this.addBttn.Enabled = false;
            this.addBttn.Location = new System.Drawing.Point(560, 45);
            this.addBttn.Name = "addBttn";
            this.addBttn.Size = new System.Drawing.Size(75, 23);
            this.addBttn.TabIndex = 33;
            this.addBttn.Text = "Add More";
            this.addBttn.UseVisualStyleBackColor = true;
            this.addBttn.Click += new System.EventHandler(this.AddBttnClick);
            // 
            // doneBttn
            // 
            this.doneBttn.Enabled = false;
            this.doneBttn.Location = new System.Drawing.Point(560, 74);
            this.doneBttn.Name = "doneBttn";
            this.doneBttn.Size = new System.Drawing.Size(75, 23);
            this.doneBttn.TabIndex = 32;
            this.doneBttn.Text = "Done";
            this.doneBttn.UseVisualStyleBackColor = true;
            this.doneBttn.Click += new System.EventHandler(this.DoneBttnClick);
            // 
            // lengthGroupBox
            // 
            this.lengthGroupBox.Controls.Add(this.label3);
            this.lengthGroupBox.Controls.Add(this.lengthTxtBox);
            this.lengthGroupBox.Location = new System.Drawing.Point(361, 108);
            this.lengthGroupBox.Name = "lengthGroupBox";
            this.lengthGroupBox.Size = new System.Drawing.Size(190, 31);
            this.lengthGroupBox.TabIndex = 19;
            this.lengthGroupBox.TabStop = false;
            this.lengthGroupBox.Visible = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 14);
            this.label3.TabIndex = 1;
            this.label3.Text = "Specimen Length";
            // 
            // lengthTxtBox
            // 
            this.lengthTxtBox.Location = new System.Drawing.Point(130, 8);
            this.lengthTxtBox.Name = "lengthTxtBox";
            this.lengthTxtBox.Size = new System.Drawing.Size(51, 20);
            this.lengthTxtBox.TabIndex = 0;
            this.lengthTxtBox.Text = "1";
            // 
            // tranChanGroupBox
            // 
            this.tranChanGroupBox.Controls.Add(this.tranChan);
            this.tranChanGroupBox.Controls.Add(this.label5);
            this.tranChanGroupBox.Location = new System.Drawing.Point(247, 113);
            this.tranChanGroupBox.Name = "tranChanGroupBox";
            this.tranChanGroupBox.Size = new System.Drawing.Size(108, 33);
            this.tranChanGroupBox.TabIndex = 31;
            this.tranChanGroupBox.TabStop = false;
            // 
            // tranChan
            // 
            this.tranChan.AllowDrop = true;
            this.tranChan.Location = new System.Drawing.Point(59, 10);
            this.tranChan.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.tranChan.Name = "tranChan";
            this.tranChan.Size = new System.Drawing.Size(43, 20);
            this.tranChan.TabIndex = 32;
            this.tranChan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 15);
            this.label5.TabIndex = 29;
            this.label5.Text = "Channels:";
            // 
            // areaGroupBox
            // 
            this.areaGroupBox.Controls.Add(this.label1);
            this.areaGroupBox.Controls.Add(this.xSecAreaTxtBox);
            this.areaGroupBox.Location = new System.Drawing.Point(361, 77);
            this.areaGroupBox.Name = "areaGroupBox";
            this.areaGroupBox.Size = new System.Drawing.Size(190, 33);
            this.areaGroupBox.TabIndex = 18;
            this.areaGroupBox.TabStop = false;
            this.areaGroupBox.Visible = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "X-Sectional Area";
            // 
            // xSecAreaTxtBox
            // 
            this.xSecAreaTxtBox.Location = new System.Drawing.Point(130, 9);
            this.xSecAreaTxtBox.Name = "xSecAreaTxtBox";
            this.xSecAreaTxtBox.Size = new System.Drawing.Size(51, 20);
            this.xSecAreaTxtBox.TabIndex = 0;
            this.xSecAreaTxtBox.Text = "1";
            // 
            // tranStrainGroupBox
            // 
            this.tranStrainGroupBox.Controls.Add(this.noStrainRadioButton);
            this.tranStrainGroupBox.Controls.Add(this.tranStrainRadioButton);
            this.tranStrainGroupBox.Location = new System.Drawing.Point(231, 19);
            this.tranStrainGroupBox.Name = "tranStrainGroupBox";
            this.tranStrainGroupBox.Size = new System.Drawing.Size(124, 91);
            this.tranStrainGroupBox.TabIndex = 26;
            this.tranStrainGroupBox.TabStop = false;
            this.tranStrainGroupBox.Text = "Transverse";
            // 
            // noStrainRadioButton
            // 
            this.noStrainRadioButton.Checked = true;
            this.noStrainRadioButton.Location = new System.Drawing.Point(6, 30);
            this.noStrainRadioButton.Name = "noStrainRadioButton";
            this.noStrainRadioButton.Size = new System.Drawing.Size(112, 24);
            this.noStrainRadioButton.TabIndex = 1;
            this.noStrainRadioButton.TabStop = true;
            this.noStrainRadioButton.Text = "None";
            this.noStrainRadioButton.UseVisualStyleBackColor = true;
            this.noStrainRadioButton.CheckedChanged += new System.EventHandler(this.NoStrainRadioButtonCheckedChanged);
            // 
            // tranStrainRadioButton
            // 
            this.tranStrainRadioButton.Location = new System.Drawing.Point(6, 13);
            this.tranStrainRadioButton.Name = "tranStrainRadioButton";
            this.tranStrainRadioButton.Size = new System.Drawing.Size(112, 21);
            this.tranStrainRadioButton.TabIndex = 0;
            this.tranStrainRadioButton.Text = "Strain";
            this.tranStrainRadioButton.UseVisualStyleBackColor = true;
            this.tranStrainRadioButton.CheckedChanged += new System.EventHandler(this.tranStrainRadioButtonCheckedChanged);
            // 
            // axChanGroupBox
            // 
            this.axChanGroupBox.Controls.Add(this.axChan);
            this.axChanGroupBox.Controls.Add(this.label4);
            this.axChanGroupBox.Location = new System.Drawing.Point(117, 113);
            this.axChanGroupBox.Name = "axChanGroupBox";
            this.axChanGroupBox.Size = new System.Drawing.Size(108, 33);
            this.axChanGroupBox.TabIndex = 30;
            this.axChanGroupBox.TabStop = false;
            // 
            // axChan
            // 
            this.axChan.AllowDrop = true;
            this.axChan.Location = new System.Drawing.Point(59, 10);
            this.axChan.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.axChan.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.axChan.Name = "axChan";
            this.axChan.Size = new System.Drawing.Size(43, 20);
            this.axChan.TabIndex = 31;
            this.axChan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.axChan.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 15);
            this.label4.TabIndex = 27;
            this.label4.Text = "Channels:";
            // 
            // axStrainGroupBox
            // 
            this.axStrainGroupBox.Controls.Add(this.tbStrainCol);
            this.axStrainGroupBox.Controls.Add(this.label22);
            this.axStrainGroupBox.Controls.Add(this.dispRadioBttn);
            this.axStrainGroupBox.Controls.Add(this.strainRadioBttn);
            this.axStrainGroupBox.Location = new System.Drawing.Point(101, 19);
            this.axStrainGroupBox.Name = "axStrainGroupBox";
            this.axStrainGroupBox.Size = new System.Drawing.Size(124, 91);
            this.axStrainGroupBox.TabIndex = 25;
            this.axStrainGroupBox.TabStop = false;
            this.axStrainGroupBox.Text = "Axial";
            // 
            // tbStrainCol
            // 
            this.tbStrainCol.Location = new System.Drawing.Point(9, 70);
            this.tbStrainCol.Name = "tbStrainCol";
            this.tbStrainCol.Size = new System.Drawing.Size(75, 20);
            this.tbStrainCol.TabIndex = 5;
            this.tbStrainCol.Text = "1";
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(6, 55);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(84, 23);
            this.label22.TabIndex = 2;
            this.label22.Text = "Column";
            // 
            // dispRadioBttn
            // 
            this.dispRadioBttn.Location = new System.Drawing.Point(6, 30);
            this.dispRadioBttn.Name = "dispRadioBttn";
            this.dispRadioBttn.Size = new System.Drawing.Size(112, 24);
            this.dispRadioBttn.TabIndex = 1;
            this.dispRadioBttn.Text = "Displacement ";
            this.dispRadioBttn.UseVisualStyleBackColor = true;
            this.dispRadioBttn.CheckedChanged += new System.EventHandler(this.DispRadioBttnCheckedChanged);
            // 
            // strainRadioBttn
            // 
            this.strainRadioBttn.Checked = true;
            this.strainRadioBttn.Location = new System.Drawing.Point(6, 13);
            this.strainRadioBttn.Name = "strainRadioBttn";
            this.strainRadioBttn.Size = new System.Drawing.Size(112, 21);
            this.strainRadioBttn.TabIndex = 0;
            this.strainRadioBttn.TabStop = true;
            this.strainRadioBttn.Text = "Strain";
            this.strainRadioBttn.UseVisualStyleBackColor = true;
            this.strainRadioBttn.CheckedChanged += new System.EventHandler(this.StrainRadioBttnCheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbStressCol);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.loadRadioBttn);
            this.groupBox1.Controls.Add(this.stressRadioBttn1);
            this.groupBox1.Location = new System.Drawing.Point(7, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(88, 91);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            // 
            // tbStressCol
            // 
            this.tbStressCol.Location = new System.Drawing.Point(6, 70);
            this.tbStressCol.Name = "tbStressCol";
            this.tbStressCol.Size = new System.Drawing.Size(75, 20);
            this.tbStressCol.TabIndex = 4;
            this.tbStressCol.Text = "2";
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(4, 55);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(84, 23);
            this.label23.TabIndex = 3;
            this.label23.Text = "Column";
            // 
            // loadRadioBttn
            // 
            this.loadRadioBttn.Location = new System.Drawing.Point(4, 30);
            this.loadRadioBttn.Name = "loadRadioBttn";
            this.loadRadioBttn.Size = new System.Drawing.Size(77, 24);
            this.loadRadioBttn.TabIndex = 1;
            this.loadRadioBttn.Text = "Load ";
            this.loadRadioBttn.UseVisualStyleBackColor = true;
            this.loadRadioBttn.CheckedChanged += new System.EventHandler(this.LoadRadioBttnCheckedChanged);
            // 
            // stressRadioBttn1
            // 
            this.stressRadioBttn1.Checked = true;
            this.stressRadioBttn1.Location = new System.Drawing.Point(5, 10);
            this.stressRadioBttn1.Name = "stressRadioBttn1";
            this.stressRadioBttn1.Size = new System.Drawing.Size(76, 24);
            this.stressRadioBttn1.TabIndex = 0;
            this.stressRadioBttn1.TabStop = true;
            this.stressRadioBttn1.Text = "Stress ";
            this.stressRadioBttn1.UseVisualStyleBackColor = true;
            this.stressRadioBttn1.CheckedChanged += new System.EventHandler(this.StressRadioBttn1CheckedChanged);
            // 
            // temperatureTxtBox
            // 
            this.temperatureTxtBox.Location = new System.Drawing.Point(117, 67);
            this.temperatureTxtBox.Name = "temperatureTxtBox";
            this.temperatureTxtBox.Size = new System.Drawing.Size(32, 20);
            this.temperatureTxtBox.TabIndex = 20;
            this.temperatureTxtBox.Text = "30";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(7, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 17);
            this.label9.TabIndex = 19;
            this.label9.Text = "Temperature (K)";
            // 
            // intervalTxtBox
            // 
            this.intervalTxtBox.Location = new System.Drawing.Point(117, 42);
            this.intervalTxtBox.Name = "intervalTxtBox";
            this.intervalTxtBox.Size = new System.Drawing.Size(32, 20);
            this.intervalTxtBox.TabIndex = 18;
            this.intervalTxtBox.Text = "0.001";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(7, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(127, 17);
            this.label8.TabIndex = 17;
            this.label8.Text = "Interval (strain)";
            // 
            // analyzeBttn
            // 
            this.analyzeBttn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.analyzeBttn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.analyzeBttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.analyzeBttn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.analyzeBttn.Location = new System.Drawing.Point(549, 15);
            this.analyzeBttn.Name = "analyzeBttn";
            this.analyzeBttn.Size = new System.Drawing.Size(111, 46);
            this.analyzeBttn.TabIndex = 16;
            this.analyzeBttn.Text = "Analyze";
            this.analyzeBttn.UseVisualStyleBackColor = false;
            this.analyzeBttn.Click += new System.EventHandler(this.AnalyzeBttnClick);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 26);
            this.label6.TabIndex = 13;
            this.label6.Text = "Axial Strain Cutoff \r\n   (strain)";
            // 
            // axStrainCutoffTxtBox
            // 
            this.axStrainCutoffTxtBox.Location = new System.Drawing.Point(117, 17);
            this.axStrainCutoffTxtBox.Name = "axStrainCutoffTxtBox";
            this.axStrainCutoffTxtBox.Size = new System.Drawing.Size(51, 20);
            this.axStrainCutoffTxtBox.TabIndex = 12;
            this.axStrainCutoffTxtBox.Text = "0.1";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(398, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(273, 35);
            this.label2.TabIndex = 3;
            this.label2.Text = "File Format:  .csv file        Order of Inputs: Force/Stress, Axial Strain/Displa" +
    "cement, Transverse Strain";
            // 
            // groupInputsGroupBox
            // 
            this.groupInputsGroupBox.BackColor = System.Drawing.SystemColors.Control;
            this.groupInputsGroupBox.Controls.Add(this.locPolyOrderTxtBx);
            this.groupInputsGroupBox.Controls.Add(this.label21);
            this.groupInputsGroupBox.Controls.Add(this.globPolyOrderTxtBx);
            this.groupInputsGroupBox.Controls.Add(this.offsetGroupBx);
            this.groupInputsGroupBox.Controls.Add(this.rMinTxtBx);
            this.groupInputsGroupBox.Controls.Add(this.offsetCheckBx);
            this.groupInputsGroupBox.Controls.Add(this.label18);
            this.groupInputsGroupBox.Controls.Add(this.label7);
            this.groupInputsGroupBox.Controls.Add(this.label17);
            this.groupInputsGroupBox.Controls.Add(this.materialTxtBox);
            this.groupInputsGroupBox.Controls.Add(this.label11);
            this.groupInputsGroupBox.Controls.Add(this.axStrainCutoffTxtBox);
            this.groupInputsGroupBox.Controls.Add(this.intervalTxtBox);
            this.groupInputsGroupBox.Controls.Add(this.temperatureTxtBox);
            this.groupInputsGroupBox.Controls.Add(this.label6);
            this.groupInputsGroupBox.Controls.Add(this.label9);
            this.groupInputsGroupBox.Controls.Add(this.analyzeBttn);
            this.groupInputsGroupBox.Controls.Add(this.label8);
            this.groupInputsGroupBox.Location = new System.Drawing.Point(12, 232);
            this.groupInputsGroupBox.Name = "groupInputsGroupBox";
            this.groupInputsGroupBox.Size = new System.Drawing.Size(667, 96);
            this.groupInputsGroupBox.TabIndex = 4;
            this.groupInputsGroupBox.TabStop = false;
            this.groupInputsGroupBox.Text = "Group Inputs";
            this.groupInputsGroupBox.Visible = false;
            // 
            // locPolyOrderTxtBx
            // 
            this.locPolyOrderTxtBx.Location = new System.Drawing.Point(264, 66);
            this.locPolyOrderTxtBx.Name = "locPolyOrderTxtBx";
            this.locPolyOrderTxtBx.Size = new System.Drawing.Size(21, 20);
            this.locPolyOrderTxtBx.TabIndex = 36;
            this.locPolyOrderTxtBx.Text = "1";
            this.locPolyOrderTxtBx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // globPolyOrderTxtBx
            // 
            this.globPolyOrderTxtBx.Location = new System.Drawing.Point(264, 40);
            this.globPolyOrderTxtBx.Name = "globPolyOrderTxtBx";
            this.globPolyOrderTxtBx.Size = new System.Drawing.Size(21, 20);
            this.globPolyOrderTxtBx.TabIndex = 35;
            this.globPolyOrderTxtBx.Text = "1";
            this.globPolyOrderTxtBx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.globPolyOrderTxtBx.TextChanged += new System.EventHandler(this.GlobPolyOrderTxtBxTextChanged);
            // 
            // offsetGroupBx
            // 
            this.offsetGroupBx.Controls.Add(this.label20);
            this.offsetGroupBx.Controls.Add(this.offsetPercentTxtBx);
            this.offsetGroupBx.Location = new System.Drawing.Point(318, 56);
            this.offsetGroupBx.Name = "offsetGroupBx";
            this.offsetGroupBx.Size = new System.Drawing.Size(163, 35);
            this.offsetGroupBx.TabIndex = 34;
            this.offsetGroupBx.TabStop = false;
            this.offsetGroupBx.Visible = false;
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(6, 13);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(48, 17);
            this.label20.TabIndex = 28;
            this.label20.Text = "% Offset";
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(324, 19);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(99, 18);
            this.label21.TabIndex = 29;
            this.label21.Text = "Zeroeing R^2 Min";
            // 
            // offsetPercentTxtBx
            // 
            this.offsetPercentTxtBx.Location = new System.Drawing.Point(107, 10);
            this.offsetPercentTxtBx.Name = "offsetPercentTxtBx";
            this.offsetPercentTxtBx.Size = new System.Drawing.Size(32, 20);
            this.offsetPercentTxtBx.TabIndex = 31;
            this.offsetPercentTxtBx.Text = ".02";
            // 
            // rMinTxtBx
            // 
            this.rMinTxtBx.Location = new System.Drawing.Point(425, 17);
            this.rMinTxtBx.Name = "rMinTxtBx";
            this.rMinTxtBx.Size = new System.Drawing.Size(53, 20);
            this.rMinTxtBx.TabIndex = 32;
            this.rMinTxtBx.Text = ".9999";
            // 
            // offsetCheckBx
            // 
            this.offsetCheckBx.Enabled = false;
            this.offsetCheckBx.Location = new System.Drawing.Point(327, 37);
            this.offsetCheckBx.Name = "offsetCheckBx";
            this.offsetCheckBx.Size = new System.Drawing.Size(115, 24);
            this.offsetCheckBx.TabIndex = 33;
            this.offsetCheckBx.Text = "Offset Yield Stress";
            this.offsetCheckBx.UseVisualStyleBackColor = true;
            this.offsetCheckBx.CheckedChanged += new System.EventHandler(this.OffsetCheckBxCheckedChanged);
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(183, 47);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(82, 20);
            this.label18.TabIndex = 25;
            this.label18.Text = "Global";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(183, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 20);
            this.label7.TabIndex = 24;
            this.label7.Text = "Local (LOESS)";
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(183, 20);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(127, 17);
            this.label17.TabIndex = 23;
            this.label17.Text = "Order of Polynomial Fit";
            // 
            // materialTxtBox
            // 
            this.materialTxtBox.Location = new System.Drawing.Point(492, 66);
            this.materialTxtBox.Name = "materialTxtBox";
            this.materialTxtBox.Size = new System.Drawing.Size(166, 20);
            this.materialTxtBox.TabIndex = 22;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(487, 46);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 17);
            this.label11.TabIndex = 21;
            this.label11.Text = "Material:";
            // 
            // plotGroupBox
            // 
            this.plotGroupBox.BackColor = System.Drawing.SystemColors.Control;
            this.plotGroupBox.Controls.Add(this.YieldStressBttn);
            this.plotGroupBox.Controls.Add(this.plotBttn);
            this.plotGroupBox.Controls.Add(this.groupBox2);
            this.plotGroupBox.Controls.Add(this.groupBox3);
            this.plotGroupBox.Controls.Add(this.typeGroupBox);
            this.plotGroupBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.plotGroupBox.Location = new System.Drawing.Point(11, 334);
            this.plotGroupBox.Name = "plotGroupBox";
            this.plotGroupBox.Size = new System.Drawing.Size(319, 176);
            this.plotGroupBox.TabIndex = 5;
            this.plotGroupBox.TabStop = false;
            this.plotGroupBox.Text = "Plotting Options";
            this.plotGroupBox.Visible = false;
            // 
            // YieldStressBttn
            // 
            this.YieldStressBttn.Enabled = false;
            this.YieldStressBttn.Location = new System.Drawing.Point(221, 145);
            this.YieldStressBttn.Name = "YieldStressBttn";
            this.YieldStressBttn.Size = new System.Drawing.Size(75, 23);
            this.YieldStressBttn.TabIndex = 6;
            this.YieldStressBttn.Text = "Yield Stress";
            this.YieldStressBttn.UseVisualStyleBackColor = true;
            this.YieldStressBttn.Click += new System.EventHandler(this.YieldStressBttnClick);
            // 
            // plotBttn
            // 
            this.plotBttn.Location = new System.Drawing.Point(221, 94);
            this.plotBttn.Name = "plotBttn";
            this.plotBttn.Size = new System.Drawing.Size(75, 29);
            this.plotBttn.TabIndex = 3;
            this.plotBttn.Text = "Plot";
            this.plotBttn.UseVisualStyleBackColor = true;
            this.plotBttn.Click += new System.EventHandler(this.PlotBttnClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.stressStrainRadioBttn);
            this.groupBox2.Controls.Add(this.tranAxRadioBttn);
            this.groupBox2.Location = new System.Drawing.Point(14, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(156, 59);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data Type";
            // 
            // stressStrainRadioBttn
            // 
            this.stressStrainRadioBttn.Checked = true;
            this.stressStrainRadioBttn.Location = new System.Drawing.Point(6, 13);
            this.stressStrainRadioBttn.Name = "stressStrainRadioBttn";
            this.stressStrainRadioBttn.Size = new System.Drawing.Size(104, 24);
            this.stressStrainRadioBttn.TabIndex = 0;
            this.stressStrainRadioBttn.TabStop = true;
            this.stressStrainRadioBttn.Text = "Stress vs Strain";
            this.stressStrainRadioBttn.UseVisualStyleBackColor = true;
            this.stressStrainRadioBttn.CheckedChanged += new System.EventHandler(this.StressStrainRadioBttnCheckedChanged);
            // 
            // tranAxRadioBttn
            // 
            this.tranAxRadioBttn.Location = new System.Drawing.Point(5, 34);
            this.tranAxRadioBttn.Name = "tranAxRadioBttn";
            this.tranAxRadioBttn.Size = new System.Drawing.Size(150, 24);
            this.tranAxRadioBttn.TabIndex = 1;
            this.tranAxRadioBttn.Text = "Transverse vs Axial Strain";
            this.tranAxRadioBttn.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.fileNumRadioBttn);
            this.groupBox3.Controls.Add(this.allRadioBttn);
            this.groupBox3.Controls.Add(this.fileNumberBox);
            this.groupBox3.Location = new System.Drawing.Point(205, 20);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(105, 59);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Files";
            // 
            // fileNumRadioBttn
            // 
            this.fileNumRadioBttn.Location = new System.Drawing.Point(5, 34);
            this.fileNumRadioBttn.Name = "fileNumRadioBttn";
            this.fileNumRadioBttn.Size = new System.Drawing.Size(51, 24);
            this.fileNumRadioBttn.TabIndex = 6;
            this.fileNumRadioBttn.TabStop = true;
            this.fileNumRadioBttn.Text = "File #";
            this.fileNumRadioBttn.UseVisualStyleBackColor = true;
            this.fileNumRadioBttn.CheckedChanged += new System.EventHandler(this.FileNumRadioBttn1CheckedChanged);
            // 
            // allRadioBttn
            // 
            this.allRadioBttn.Checked = true;
            this.allRadioBttn.Location = new System.Drawing.Point(5, 18);
            this.allRadioBttn.Name = "allRadioBttn";
            this.allRadioBttn.Size = new System.Drawing.Size(43, 19);
            this.allRadioBttn.TabIndex = 5;
            this.allRadioBttn.TabStop = true;
            this.allRadioBttn.Text = "All";
            this.allRadioBttn.UseVisualStyleBackColor = true;
            this.allRadioBttn.CheckedChanged += new System.EventHandler(this.AllRadioBttnCheckedChanged);
            // 
            // fileNumberBox
            // 
            this.fileNumberBox.AllowDrop = true;
            this.fileNumberBox.Enabled = false;
            this.fileNumberBox.Location = new System.Drawing.Point(59, 38);
            this.fileNumberBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.fileNumberBox.Name = "fileNumberBox";
            this.fileNumberBox.Size = new System.Drawing.Size(43, 20);
            this.fileNumberBox.TabIndex = 3;
            this.fileNumberBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fileNumberBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // typeGroupBox
            // 
            this.typeGroupBox.Controls.Add(this.SlopeRadioBttn);
            this.typeGroupBox.Controls.Add(this.combinedRadioBttn);
            this.typeGroupBox.Controls.Add(this.rawRadioBttn);
            this.typeGroupBox.Location = new System.Drawing.Point(14, 84);
            this.typeGroupBox.Name = "typeGroupBox";
            this.typeGroupBox.Size = new System.Drawing.Size(189, 84);
            this.typeGroupBox.TabIndex = 2;
            this.typeGroupBox.TabStop = false;
            this.typeGroupBox.Text = "Plot Type";
            // 
            // SlopeRadioBttn
            // 
            this.SlopeRadioBttn.Location = new System.Drawing.Point(6, 53);
            this.SlopeRadioBttn.Name = "SlopeRadioBttn";
            this.SlopeRadioBttn.Size = new System.Drawing.Size(164, 23);
            this.SlopeRadioBttn.TabIndex = 2;
            this.SlopeRadioBttn.Text = "Tangent and Secant Slope";
            this.SlopeRadioBttn.UseVisualStyleBackColor = true;
            // 
            // combinedRadioBttn
            // 
            this.combinedRadioBttn.Location = new System.Drawing.Point(6, 36);
            this.combinedRadioBttn.Name = "combinedRadioBttn";
            this.combinedRadioBttn.Size = new System.Drawing.Size(177, 20);
            this.combinedRadioBttn.TabIndex = 1;
            this.combinedRadioBttn.Text = "Zeroed Data and Mean Points";
            this.combinedRadioBttn.UseVisualStyleBackColor = true;
            // 
            // rawRadioBttn
            // 
            this.rawRadioBttn.Checked = true;
            this.rawRadioBttn.Location = new System.Drawing.Point(6, 15);
            this.rawRadioBttn.Name = "rawRadioBttn";
            this.rawRadioBttn.Size = new System.Drawing.Size(165, 24);
            this.rawRadioBttn.TabIndex = 0;
            this.rawRadioBttn.TabStop = true;
            this.rawRadioBttn.Text = "Raw, Averaged, Zeroed Data";
            this.rawRadioBttn.UseVisualStyleBackColor = true;
            // 
            // dataFilesGroupBox
            // 
            this.dataFilesGroupBox.BackColor = System.Drawing.SystemColors.Control;
            this.dataFilesGroupBox.Controls.Add(this.resultsBttn);
            this.dataFilesGroupBox.Controls.Add(this.fileWriteBttn);
            this.dataFilesGroupBox.Controls.Add(this.groupBox5);
            this.dataFilesGroupBox.Controls.Add(this.groupBox4);
            this.dataFilesGroupBox.Location = new System.Drawing.Point(343, 334);
            this.dataFilesGroupBox.Name = "dataFilesGroupBox";
            this.dataFilesGroupBox.Size = new System.Drawing.Size(335, 176);
            this.dataFilesGroupBox.TabIndex = 6;
            this.dataFilesGroupBox.TabStop = false;
            this.dataFilesGroupBox.Text = "Data Files";
            this.dataFilesGroupBox.Visible = false;
            // 
            // resultsBttn
            // 
            this.resultsBttn.Location = new System.Drawing.Point(249, 140);
            this.resultsBttn.Name = "resultsBttn";
            this.resultsBttn.Size = new System.Drawing.Size(81, 29);
            this.resultsBttn.TabIndex = 5;
            this.resultsBttn.Text = "Show Results";
            this.resultsBttn.UseVisualStyleBackColor = true;
            this.resultsBttn.Click += new System.EventHandler(this.ResultsBttnClick);
            // 
            // fileWriteBttn
            // 
            this.fileWriteBttn.Location = new System.Drawing.Point(252, 58);
            this.fileWriteBttn.Name = "fileWriteBttn";
            this.fileWriteBttn.Size = new System.Drawing.Size(75, 29);
            this.fileWriteBttn.TabIndex = 4;
            this.fileWriteBttn.Text = "Write to File";
            this.fileWriteBttn.UseVisualStyleBackColor = true;
            this.fileWriteBttn.Click += new System.EventHandler(this.FileWriteBttnClick);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.taTotalCheckBox);
            this.groupBox5.Controls.Add(this.ssTotalCheckBox);
            this.groupBox5.Location = new System.Drawing.Point(7, 106);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(239, 62);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Group Files";
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(102, 14);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(137, 20);
            this.label15.TabIndex = 6;
            this.label15.Text = "Transverse vs Axial Strain";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(6, 14);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(100, 20);
            this.label14.TabIndex = 6;
            this.label14.Text = "Stress vs Strain";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // taTotalCheckBox
            // 
            this.taTotalCheckBox.Location = new System.Drawing.Point(123, 37);
            this.taTotalCheckBox.Name = "taTotalCheckBox";
            this.taTotalCheckBox.Size = new System.Drawing.Size(104, 24);
            this.taTotalCheckBox.TabIndex = 4;
            this.taTotalCheckBox.Text = "LOESS Details";
            this.taTotalCheckBox.UseVisualStyleBackColor = true;
            // 
            // ssTotalCheckBox
            // 
            this.ssTotalCheckBox.Location = new System.Drawing.Point(6, 37);
            this.ssTotalCheckBox.Name = "ssTotalCheckBox";
            this.ssTotalCheckBox.Size = new System.Drawing.Size(104, 24);
            this.ssTotalCheckBox.TabIndex = 3;
            this.ssTotalCheckBox.Text = "LOESS Details";
            this.ssTotalCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.taLoessCheckBox);
            this.groupBox4.Controls.Add(this.ssLoessCheckBox);
            this.groupBox4.Controls.Add(this.tadhCheckBox);
            this.groupBox4.Controls.Add(this.ssdhCheckBox);
            this.groupBox4.Location = new System.Drawing.Point(7, 20);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(239, 86);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Individual Files";
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(102, 14);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(137, 20);
            this.label13.TabIndex = 5;
            this.label13.Text = "Transverse vs Axial Strain";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(6, 14);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 20);
            this.label12.TabIndex = 4;
            this.label12.Text = "Stress vs Strain";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // taLoessCheckBox
            // 
            this.taLoessCheckBox.Location = new System.Drawing.Point(123, 56);
            this.taLoessCheckBox.Name = "taLoessCheckBox";
            this.taLoessCheckBox.Size = new System.Drawing.Size(104, 24);
            this.taLoessCheckBox.TabIndex = 3;
            this.taLoessCheckBox.Text = "LOESS Details";
            this.taLoessCheckBox.UseVisualStyleBackColor = true;
            // 
            // ssLoessCheckBox
            // 
            this.ssLoessCheckBox.Location = new System.Drawing.Point(6, 56);
            this.ssLoessCheckBox.Name = "ssLoessCheckBox";
            this.ssLoessCheckBox.Size = new System.Drawing.Size(104, 24);
            this.ssLoessCheckBox.TabIndex = 2;
            this.ssLoessCheckBox.Text = "LOESS Details";
            this.ssLoessCheckBox.UseVisualStyleBackColor = true;
            // 
            // tadhCheckBox
            // 
            this.tadhCheckBox.Location = new System.Drawing.Point(123, 33);
            this.tadhCheckBox.Name = "tadhCheckBox";
            this.tadhCheckBox.Size = new System.Drawing.Size(104, 24);
            this.tadhCheckBox.TabIndex = 1;
            this.tadhCheckBox.Text = "Data Handling";
            this.tadhCheckBox.UseVisualStyleBackColor = true;
            // 
            // ssdhCheckBox
            // 
            this.ssdhCheckBox.Location = new System.Drawing.Point(6, 33);
            this.ssdhCheckBox.Name = "ssdhCheckBox";
            this.ssdhCheckBox.Size = new System.Drawing.Size(104, 24);
            this.ssdhCheckBox.TabIndex = 0;
            this.ssdhCheckBox.Text = "Data Handling";
            this.ssdhCheckBox.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(693, 522);
            this.Controls.Add(this.dataFilesGroupBox);
            this.Controls.Add(this.plotGroupBox);
            this.Controls.Add(this.groupInputsGroupBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.inputGroupBox);
            this.Controls.Add(this.openFileTxt);
            this.Controls.Add(this.Browse);
            this.Name = "MainForm";
            this.Text = "StressStrainData";
            this.inputGroupBox.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.lengthGroupBox.ResumeLayout(false);
            this.lengthGroupBox.PerformLayout();
            this.tranChanGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tranChan)).EndInit();
            this.areaGroupBox.ResumeLayout(false);
            this.areaGroupBox.PerformLayout();
            this.tranStrainGroupBox.ResumeLayout(false);
            this.axChanGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axChan)).EndInit();
            this.axStrainGroupBox.ResumeLayout(false);
            this.axStrainGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupInputsGroupBox.ResumeLayout(false);
            this.groupInputsGroupBox.PerformLayout();
            this.offsetGroupBx.ResumeLayout(false);
            this.offsetGroupBx.PerformLayout();
            this.plotGroupBox.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fileNumberBox)).EndInit();
            this.typeGroupBox.ResumeLayout(false);
            this.dataFilesGroupBox.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.TextBox tbStressCol;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.TextBox tbStrainCol;
		private System.Windows.Forms.TextBox rowEndTxtBox;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.Button YieldStressBttn;
		private System.Windows.Forms.TextBox locPolyOrderTxtBx;
		private System.Windows.Forms.TextBox globPolyOrderTxtBx;
		private System.Windows.Forms.GroupBox offsetGroupBx;
		private System.Windows.Forms.CheckBox offsetCheckBx;
		private System.Windows.Forms.TextBox rMinTxtBx;
		private System.Windows.Forms.TextBox offsetPercentTxtBx;
		private System.Windows.Forms.NumericUpDown axChan;
		private System.Windows.Forms.NumericUpDown tranChan;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Button previewBttn;
		private System.Windows.Forms.TextBox rowStartTxtBox;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.Button resultsBttn;
		private System.Windows.Forms.CheckBox taLoessCheckBox;
		private System.Windows.Forms.CheckBox ssLoessCheckBox;
		private System.Windows.Forms.CheckBox tadhCheckBox;
		private System.Windows.Forms.CheckBox ssdhCheckBox;
		private System.Windows.Forms.Button fileWriteBttn;
		private System.Windows.Forms.CheckBox taTotalCheckBox;
		private System.Windows.Forms.CheckBox ssTotalCheckBox;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.GroupBox dataFilesGroupBox;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox materialTxtBox;
		private System.Windows.Forms.RadioButton fileNumRadioBttn;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton allRadioBttn;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.NumericUpDown fileNumberBox;
		private System.Windows.Forms.Button plotBttn;
		private System.Windows.Forms.RadioButton stressStrainRadioBttn;
		private System.Windows.Forms.RadioButton tranAxRadioBttn;
		private System.Windows.Forms.RadioButton rawRadioBttn;
		private System.Windows.Forms.RadioButton combinedRadioBttn;
		private System.Windows.Forms.RadioButton SlopeRadioBttn;
		private System.Windows.Forms.GroupBox typeGroupBox;
		private System.Windows.Forms.GroupBox plotGroupBox;
		private System.Windows.Forms.Button addCurrentBttn;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.GroupBox groupInputsGroupBox;
		private System.Windows.Forms.Button doneBttn;
		private System.Windows.Forms.Button addBttn;
		private System.Windows.Forms.RadioButton tranStrainRadioButton;
		private System.Windows.Forms.GroupBox axStrainGroupBox;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox intervalTxtBox;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox temperatureTxtBox;
		private System.Windows.Forms.RadioButton noStrainRadioButton;
		private System.Windows.Forms.GroupBox tranStrainGroupBox;
		private System.Windows.Forms.GroupBox tranChanGroupBox;
		private System.Windows.Forms.GroupBox axChanGroupBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.RadioButton strainRadioBttn;
		private System.Windows.Forms.RadioButton dispRadioBttn;
		private System.Windows.Forms.RadioButton stressRadioBttn1;
		private System.Windows.Forms.RadioButton loadRadioBttn;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox lengthTxtBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox lengthGroupBox;
		private System.Windows.Forms.TextBox xSecAreaTxtBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox areaGroupBox;
		private System.Windows.Forms.Button analyzeBttn;
		private System.Windows.Forms.TextBox axStrainCutoffTxtBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.GroupBox inputGroupBox;
		private System.Windows.Forms.TextBox openFileTxt;
		private System.Windows.Forms.Button Browse;
		
		
		
		
	}
}
