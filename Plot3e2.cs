/*
 * Created by SharpDevelop.
 * User: e46221
 * Date: 6/28/2007
 * Time: 4:01 PM
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
	/// Description of Plot.
	/// </summary>
	public partial class Plot3e2 : Form
	{
		PointPairList list1 = new PointPairList();
		PointPairList list2 = new PointPairList();
		PointPairList list3 = new PointPairList();
		PointPairList list2e = new PointPairList();
		PointPairList list1e = new PointPairList();
		string Title = "Titleless";
		string XTitle = "Titleless";
		string YTitle = "Titleless";
		string DataLabel1 = "No Label";
		string DataLabel1e = "No Label";
		string DataLabel2 = "No Label";
		string DataLabel2e = "No Label";
		string DataLabel3 = "No Label";
				
		public Plot3e2(PointPairList List1, PointPairList List1e, PointPairList List2, PointPairList List2e, 
		             PointPairList List3, string title, string Xtitle, string Ytitle, 
		             string datalabel1, string datalabel1e, string datalabel2, string datalabel2e,
		            string datalabel3)
		{
			
			list1 = List1;
			list1e = List1e;
			list2 = List2;
			list2e = List2e;
			list3 = List3;
			Title = title;
			XTitle = Xtitle;
			YTitle = Ytitle;
			DataLabel1 = datalabel1;
			DataLabel1e = datalabel1e;
			DataLabel2 = datalabel2;
			DataLabel2e = datalabel2e;
			DataLabel3 = datalabel3;
			
			InitializeComponent();
			Activate();
			Show();
		}
		
		void PlotLoad(object sender, EventArgs e)
		{
			CreateChart( zg1 );
   			SetSize();
		}
		// Call this method from the Form_Load method, passing your ZedGraphControl
		public void CreateChart( ZedGraphControl zgc ){
			GraphPane myPane = zgc.GraphPane;

   			// Set the title and axis labels
   			myPane.Title.Text = Title + " : " + DateTime.Now.ToString();
   			myPane.XAxis.Title.Text = XTitle;
   			myPane.YAxis.Title.Text = YTitle;
    
   			
   			LineItem myCurve2 = myPane.AddCurve( DataLabel2, list2, Color.Black, SymbolType.Diamond );
   			LineItem myCurve1 = myPane.AddCurve( DataLabel1,	list1, Color.Red, SymbolType.Circle );
   			LineItem myCurve3 = myPane.AddCurve( DataLabel3,	list3, Color.DodgerBlue, SymbolType.Star );
   			   			   			  			
   			// Don't display the line (This makes a scatter plot)
    		myCurve1.Line.IsVisible = false;
    		myCurve2.Line.IsVisible = false;
    		myCurve3.Line.IsVisible = false;
    		// Hide the symbol outline
    		myCurve1.Symbol.Border.IsVisible = false;
    		myCurve2.Symbol.Border.IsVisible = false;
    		// Fill the symbol interior with color
    		myCurve1.Symbol.Fill = new Fill( Color.Red );
    		myCurve2.Symbol.Fill = new Fill( Color.Black );
    		
    		// Generate a red bar with "Curve 1" in the legend
   			ErrorBarItem myCurve2e = myPane.AddErrorBar( DataLabel2e, list2e, Color.Black );
   			ErrorBarItem myCurve1e = myPane.AddErrorBar( DataLabel1e, list1e, Color.Red );
   			myCurve2e.Bar.PenWidth = 1f;
   			myCurve1e.Bar.PenWidth = 1f;
   			// Use the HDash symbol so that the error bars look like I-beams
   			myCurve2e.Bar.Symbol.Type = SymbolType.HDash;
  			myCurve2e.Bar.Symbol.IsVisible = true;
  			myCurve1e.Bar.Symbol.Type = SymbolType.HDash;
  			myCurve1e.Bar.Symbol.IsVisible = true;
  			
    		// Fill the background of the chart rect and pane
    		//myPane.Chart.Fill = new Fill( Color.White, Color.LightGoldenrodYellow, 45.0f );
    		myPane.Chart.Fill = new Fill( Color.LightGoldenrodYellow);
    		//myPane.Fill = new Fill( Color.SlateGray,Color.BlueViolet);
			// Hide the legend
    		myPane.Legend.IsVisible = true;
    		// turn off the opposite tics so the Y tics don't show up on the Y2 axis
   			myPane.YAxis.MajorTic.IsOpposite = false;
   			myPane.YAxis.MinorTic.IsOpposite = false;
   			myPane.XAxis.MajorTic.IsOpposite = false;
   			myPane.XAxis.MinorTic.IsOpposite = false;
   			// Display the Y2 axis grid lines
   			myPane.YAxis.MajorGrid.IsVisible = true;
   			myPane.XAxis.MajorGrid.IsVisible = true;
   		
   			// Calculate the Axis Scale Ranges
   			zgc.AxisChange();
		}
		
		void PlotResize(object sender, EventArgs e){
			SetSize();
		}
		private void SetSize(){
   			zg1.Location = new Point( 10, 10 );
   			// Leave a small margin around the outside of the control
   			zg1.Size = new Size( this.ClientRectangle.Width - 20, this.ClientRectangle.Height - 20 );
		}
	}
}
