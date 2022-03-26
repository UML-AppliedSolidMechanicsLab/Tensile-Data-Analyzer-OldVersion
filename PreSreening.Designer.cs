/*
 * Created by SharpDevelop.
 * User: e46221
 * Date: 7/23/2007
 * Time: 7:54 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace StressStrainData
{
	partial class PreSreening
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
			this.components = new System.ComponentModel.Container();
			this.zg2 = new ZedGraph.ZedGraphControl();
			this.SuspendLayout();
			// 
			// zg2
			// 
			this.zg2.Location = new System.Drawing.Point(2, 2);
			this.zg2.Name = "zg2";
			this.zg2.ScrollGrace = 0;
			this.zg2.ScrollMaxX = 0;
			this.zg2.ScrollMaxY = 0;
			this.zg2.ScrollMaxY2 = 0;
			this.zg2.ScrollMinX = 0;
			this.zg2.ScrollMinY = 0;
			this.zg2.ScrollMinY2 = 0;
			this.zg2.Size = new System.Drawing.Size(605, 384);
			this.zg2.TabIndex = 0;
			// 
			// PreSreening
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(609, 387);
			this.Controls.Add(this.zg2);
			this.Name = "PreSreening";
			this.Text = "Preview";
			this.Resize += new System.EventHandler(this.PreSreeningResize);
			this.Load += new System.EventHandler(this.Zg2Load);
			this.ResumeLayout(false);
		}
		private ZedGraph.ZedGraphControl zg2;
	}
}
