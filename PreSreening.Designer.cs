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
            this.tbStartIndex = new System.Windows.Forms.TrackBar();
            this.tbEndIndex = new System.Windows.Forms.TrackBar();
            this.lMinStart = new System.Windows.Forms.Label();
            this.lMaxStart = new System.Windows.Forms.Label();
            this.lMinEnd = new System.Windows.Forms.Label();
            this.lMaxEnd = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tbStartIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbEndIndex)).BeginInit();
            this.SuspendLayout();
            // 
            // zg2
            // 
            this.zg2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zg2.Location = new System.Drawing.Point(2, 51);
            this.zg2.Name = "zg2";
            this.zg2.ScrollGrace = 0D;
            this.zg2.ScrollMaxX = 0D;
            this.zg2.ScrollMaxY = 0D;
            this.zg2.ScrollMaxY2 = 0D;
            this.zg2.ScrollMinX = 0D;
            this.zg2.ScrollMinY = 0D;
            this.zg2.ScrollMinY2 = 0D;
            this.zg2.Size = new System.Drawing.Size(605, 335);
            this.zg2.TabIndex = 0;
            this.zg2.UseExtendedPrintDialog = true;
            // 
            // tbStartIndex
            // 
            this.tbStartIndex.Location = new System.Drawing.Point(2, 0);
            this.tbStartIndex.Name = "tbStartIndex";
            this.tbStartIndex.Size = new System.Drawing.Size(302, 45);
            this.tbStartIndex.TabIndex = 1;
            this.tbStartIndex.Scroll += new System.EventHandler(this.tbStartIndex_Scroll);
            // 
            // tbEndIndex
            // 
            this.tbEndIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbEndIndex.Location = new System.Drawing.Point(305, 0);
            this.tbEndIndex.Name = "tbEndIndex";
            this.tbEndIndex.Size = new System.Drawing.Size(304, 45);
            this.tbEndIndex.TabIndex = 2;
            this.tbEndIndex.Scroll += new System.EventHandler(this.tbEndIndex_Scroll);
            // 
            // lMinStart
            // 
            this.lMinStart.AutoSize = true;
            this.lMinStart.Location = new System.Drawing.Point(12, 32);
            this.lMinStart.Name = "lMinStart";
            this.lMinStart.Size = new System.Drawing.Size(35, 13);
            this.lMinStart.TabIndex = 3;
            this.lMinStart.Text = "label1";
            // 
            // lMaxStart
            // 
            this.lMaxStart.AutoSize = true;
            this.lMaxStart.Location = new System.Drawing.Point(269, 32);
            this.lMaxStart.Name = "lMaxStart";
            this.lMaxStart.Size = new System.Drawing.Size(35, 13);
            this.lMaxStart.TabIndex = 4;
            this.lMaxStart.Text = "label1";
            // 
            // lMinEnd
            // 
            this.lMinEnd.AutoSize = true;
            this.lMinEnd.Location = new System.Drawing.Point(310, 32);
            this.lMinEnd.Name = "lMinEnd";
            this.lMinEnd.Size = new System.Drawing.Size(35, 13);
            this.lMinEnd.TabIndex = 5;
            this.lMinEnd.Text = "label1";
            // 
            // lMaxEnd
            // 
            this.lMaxEnd.AutoSize = true;
            this.lMaxEnd.Location = new System.Drawing.Point(572, 32);
            this.lMaxEnd.Name = "lMaxEnd";
            this.lMaxEnd.Size = new System.Drawing.Size(35, 13);
            this.lMaxEnd.TabIndex = 6;
            this.lMaxEnd.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(128, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Index of Start";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(421, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Index of End";
            // 
            // PreSreening
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 387);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lMaxEnd);
            this.Controls.Add(this.lMinEnd);
            this.Controls.Add(this.lMaxStart);
            this.Controls.Add(this.lMinStart);
            this.Controls.Add(this.tbEndIndex);
            this.Controls.Add(this.tbStartIndex);
            this.Controls.Add(this.zg2);
            this.Name = "PreSreening";
            this.Text = "Preview";
            this.Load += new System.EventHandler(this.Zg2Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbStartIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbEndIndex)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private ZedGraph.ZedGraphControl zg2;
        private System.Windows.Forms.TrackBar tbStartIndex;
        private System.Windows.Forms.TrackBar tbEndIndex;
        private System.Windows.Forms.Label lMinStart;
        private System.Windows.Forms.Label lMaxStart;
        private System.Windows.Forms.Label lMinEnd;
        private System.Windows.Forms.Label lMaxEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
