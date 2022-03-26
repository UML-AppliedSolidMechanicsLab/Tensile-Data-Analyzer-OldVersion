/*
 * Created by SharpDevelop.
 * User: e46221
 * Date: 7/19/2007
 * Time: 2:08 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace StressStrainData
{
	partial class ResultsWindow
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
			this.ssLOESSCheckBox = new System.Windows.Forms.CheckBox();
			this.taLOESSCheckBox = new System.Windows.Forms.CheckBox();
			this.offsetStrainTxtBox = new System.Windows.Forms.TextBox();
			this.polyTxtBox = new System.Windows.Forms.TextBox();
			this.taOffsetTxtBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.taPolyTxtBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// ssLOESSCheckBox
			// 
			this.ssLOESSCheckBox.Location = new System.Drawing.Point(12, 211);
			this.ssLOESSCheckBox.Name = "ssLOESSCheckBox";
			this.ssLOESSCheckBox.Size = new System.Drawing.Size(155, 24);
			this.ssLOESSCheckBox.TabIndex = 1;
			this.ssLOESSCheckBox.Text = "Plot Final Mean Points";
			this.ssLOESSCheckBox.UseVisualStyleBackColor = true;
			this.ssLOESSCheckBox.CheckedChanged += new System.EventHandler(this.SsLOESSCheckBoxCheckedChanged);
			// 
			// taLOESSCheckBox
			// 
			this.taLOESSCheckBox.Location = new System.Drawing.Point(317, 209);
			this.taLOESSCheckBox.Name = "taLOESSCheckBox";
			this.taLOESSCheckBox.Size = new System.Drawing.Size(167, 24);
			this.taLOESSCheckBox.TabIndex = 2;
			this.taLOESSCheckBox.Text = "Plot Final Mean Points";
			this.taLOESSCheckBox.UseVisualStyleBackColor = true;
			this.taLOESSCheckBox.CheckedChanged += new System.EventHandler(this.TaLOESSCheckBoxCheckedChanged);
			// 
			// offsetStrainTxtBox
			// 
			this.offsetStrainTxtBox.Location = new System.Drawing.Point(12, 33);
			this.offsetStrainTxtBox.Multiline = true;
			this.offsetStrainTxtBox.Name = "offsetStrainTxtBox";
			this.offsetStrainTxtBox.Size = new System.Drawing.Size(127, 172);
			this.offsetStrainTxtBox.TabIndex = 3;
			this.offsetStrainTxtBox.Text = "Offset Strain (microstrain):     File 0: -231.584";
			// 
			// polyTxtBox
			// 
			this.polyTxtBox.Location = new System.Drawing.Point(145, 33);
			this.polyTxtBox.Multiline = true;
			this.polyTxtBox.Name = "polyTxtBox";
			this.polyTxtBox.Size = new System.Drawing.Size(131, 172);
			this.polyTxtBox.TabIndex = 4;
			this.polyTxtBox.Text = "Polynomial Coefficients:   A0: 9.8242 SE: 23.8458   A1: 1.1958 SE: 0.0175";
			// 
			// taOffsetTxtBox
			// 
			this.taOffsetTxtBox.Location = new System.Drawing.Point(317, 33);
			this.taOffsetTxtBox.Multiline = true;
			this.taOffsetTxtBox.Name = "taOffsetTxtBox";
			this.taOffsetTxtBox.Size = new System.Drawing.Size(127, 172);
			this.taOffsetTxtBox.TabIndex = 5;
			this.taOffsetTxtBox.Text = "Offset Strain (microstrain):     File 0: -231.584";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(15, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(261, 23);
			this.label1.TabIndex = 6;
			this.label1.Text = "Stress vs Strain";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(317, 7);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(263, 23);
			this.label2.TabIndex = 7;
			this.label2.Text = "Transverse vs Axial Strain";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// taPolyTxtBox
			// 
			this.taPolyTxtBox.Location = new System.Drawing.Point(450, 33);
			this.taPolyTxtBox.Multiline = true;
			this.taPolyTxtBox.Name = "taPolyTxtBox";
			this.taPolyTxtBox.Size = new System.Drawing.Size(130, 172);
			this.taPolyTxtBox.TabIndex = 8;
			this.taPolyTxtBox.Text = "Polynomial Coefficients:   A0: 9.8242 SE: 23.8458   A1: 1.1958 SE: 0.0175";
			// 
			// ResultsWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(592, 245);
			this.Controls.Add(this.taPolyTxtBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.taOffsetTxtBox);
			this.Controls.Add(this.polyTxtBox);
			this.Controls.Add(this.offsetStrainTxtBox);
			this.Controls.Add(this.taLOESSCheckBox);
			this.Controls.Add(this.ssLOESSCheckBox);
			this.Location = new System.Drawing.Point(300, 0);
			this.Name = "ResultsWindow";
			this.Text = "ResultsWindow";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.TextBox taPolyTxtBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox taOffsetTxtBox;
		private System.Windows.Forms.TextBox polyTxtBox;
		private System.Windows.Forms.TextBox offsetStrainTxtBox;
		private System.Windows.Forms.CheckBox ssLOESSCheckBox;
		private System.Windows.Forms.CheckBox taLOESSCheckBox;
	}
}
