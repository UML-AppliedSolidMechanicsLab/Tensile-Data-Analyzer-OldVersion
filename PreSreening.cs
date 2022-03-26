/*
 * Created by SharpDevelop.
 * User: e46221
 * Date: 7/23/2007
 * Time: 7:54 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;

namespace StressStrainData
{
	/// <summary>
	/// Description of Form1.
	/// </summary>
	public partial class PreSreening : Form
	{
		string root;
		int axChan, tranChan, rowStart, dispflag, rowEnd, stressCol, strainCol;
		double length, xSecArea;
		
		public PreSreening(string inroot, int inaxChan, int intranChan,	 
		                  double inlength, double inxSecArea, int inrowStart, int inrowEnd, int inStrainCol, int inStressCol, int indispflag)
		{
			root = inroot;
			axChan = inaxChan;
			tranChan = intranChan;
			length = inlength;
			xSecArea = inxSecArea;
			rowStart = inrowStart;
			dispflag = indispflag;
			rowEnd = inrowEnd;
			stressCol = inStressCol;
			strainCol = inStrainCol;
			
			InitializeComponent();
			Activate();
			Show();
			
		}
		
		void Zg2Load(object sender, EventArgs e)
		{
			CreateChart( zg2 );
   			SetSize();
		}
		
		// Call this method from the Form_Load method, passing your ZedGraphControl
		public void CreateChart( ZedGraphControl zgc ){
			
			int i,j;
			//Read in the Data first
			FileReader tempread = new FileReader(root, axChan, tranChan, length, xSecArea, rowStart, rowEnd, strainCol, stressCol, dispflag);
			
			GraphPane myPane = zgc.GraphPane;

   			// Set the title and axis labels
   			myPane.Title.Text = "Raw Data";
   			myPane.XAxis.Title.Text = "Strain (microstrain)";
   			myPane.YAxis.Title.Text = "Stress (psi)";

   			PointPairList list1 = new PointPairList();
   			PointPairList list2 = new PointPairList();
   			
   			for (i =0; i < tempread.RawData.GetUpperBound(0)+1; i++){ 
   				for (j =0; j < tempread.AxChan; j++){
   					list1.Add(tempread.RawData[i,1+j], tempread.RawData[i,0]);
   				}
   			}
   			if (tempread.TranChan != 0){
   				for (i =0; i < tempread.RawData.GetUpperBound(0)+1; i++){
   					for (j =0; j < tempread.TranChan; j++){
   						list2.Add(tempread.RawData[i,1+tempread.AxChan+j], tempread.RawData[i,0]);
   					}
   				}
   			}
   			else 
   				list2.Add(0,0);
   			
   			LineItem myCurve1 = myPane.AddCurve( "Axial Strain", list1, Color.Blue, SymbolType.Diamond );
   			LineItem myCurve2 = myPane.AddCurve( "Transverse Strain", list2, Color.Red, SymbolType.Circle );
   			   			   			  			
   			// Don't display the line (This makes a scatter plot)
    		myCurve1.Line.IsVisible = false;
    		myCurve2.Line.IsVisible = false;
    		// Hide the symbol outline
    		myCurve1.Symbol.Border.IsVisible = false;
    		myCurve2.Symbol.Border.IsVisible = false;
    		// Fill the symbol interior with color
    		myCurve1.Symbol.Fill = new Fill( Color.Blue );
    		myCurve2.Symbol.Fill = new Fill( Color.Red );
    		
    		// Fill the background of the chart rect and pane
    		//myPane.Chart.Fill = new Fill( Color.White, Color.LightGoldenrodYellow, 45.0f );
    		myPane.Chart.Fill = new Fill( Color.LightGoldenrodYellow);
    		//myPane.Fill = new Fill( Color.SlateGray,Color.BlueViolet);
			// Hide the legend
    		myPane.Legend.IsVisible = true;
    		
   			// Display the Y2 axis grid lines
   			myPane.YAxis.MajorGrid.IsVisible = true;
   			myPane.XAxis.MajorGrid.IsVisible = true;
   		
   			// Calculate the Axis Scale Ranges
   			zgc.AxisChange();
		}
		
		private void SetSize(){
   			zg2.Location = new Point( 10, 10 );
   			// Leave a small margin around the outside of the control
   			zg2.Size = new Size( this.ClientRectangle.Width - 20, this.ClientRectangle.Height - 20 );
		}
		
		void PreSreeningResize(object sender, EventArgs e)
		{
			SetSize();
		}
	}
}
