/*
 * Created by SharpDevelop.
 * User: e46221
 * Date: 6/28/2007
 * Time: 4:01 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace StressStrainData
{
	partial class Plot1e
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
			this.zg1 = new ZedGraph.ZedGraphControl();
			this.SuspendLayout();
			// 
			// zg1
			// 
			this.zg1.Location = new System.Drawing.Point(2, 3);
			this.zg1.Name = "zg1";
			this.zg1.ScrollGrace = 0;
			this.zg1.ScrollMaxX = 0;
			this.zg1.ScrollMaxY = 0;
			this.zg1.ScrollMaxY2 = 0;
			this.zg1.ScrollMinX = 0;
			this.zg1.ScrollMinY = 0;
			this.zg1.ScrollMinY2 = 0;
			this.zg1.Size = new System.Drawing.Size(738, 505);
			this.zg1.TabIndex = 0;
			// 
			// Plot
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(742, 510);
			this.Controls.Add(this.zg1);
			this.Name = "Plot";
			this.Text = Title;
			this.Resize += new System.EventHandler(this.PlotResize);
			this.Load += new System.EventHandler(this.PlotLoad);
			this.ResumeLayout(false);
		}
		private ZedGraph.ZedGraphControl zg1;
	}
}
