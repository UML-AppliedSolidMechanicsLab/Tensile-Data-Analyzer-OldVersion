/*
 * Created by SharpDevelop.
 * User: e46221
 * Date: 7/19/2007
 * Time: 2:08 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace StressStrainData
{
	/// <summary>
	/// Description of ResultsWindow.
	/// </summary>
	public partial class ResultsWindow : Form
	{
		private Analyze analyze;
		private string temperature;
		private string material;		
				
		
		public ResultsWindow(Analyze inanalyze, string intemperature, string inmaterial)
		{
			analyze = inanalyze;
			material = inmaterial;
			temperature = intemperature;
			
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			Activate();
			Show();
			Setup();
			//
			
		}
		public void Setup(){
			double N1ave = 0;
			double N2ave = 0;
			string temp;
			int i,j;
			
			if (analyze.NumberofTranFiles  == 0){
				taLOESSCheckBox.Enabled = false;
			}
			
			//Writes the contents for the strain offset text box (stress vs strain)
			offsetStrainTxtBox.WordWrap = true;
			temp = "Offset Strain (microstrain): ";
			for (i = 0; i < analyze.RawData.Length; i++){
				j = i + 1;
				temp = temp + "File " + j + ": " + analyze.ZeroData[i].OffsetData.StrainOffset.ToString("N3") + "               ";
			}
			offsetStrainTxtBox.Text = temp;	
			
			//Writes the contents for the strain offset text box (strain vs strain)
			temp = "Offset Strain (microstrain): ";
			for (i = 0; i < analyze.RawData.Length; i++){
				if (analyze.RawData[i].TranChan != 0){
					j = i + 1;
				temp = temp + "File " + j + ": " + analyze.ZeroNUData[i].OffsetData.StrainOffset.ToString("N3") + "               ";
				}
			}
			taOffsetTxtBox.Text = temp;	
			
			//Writes the contents for the polynomial coefficients text box (stress vs strain)
			temp = "Polynomial Coefficients:";
			for (i = 0; i < analyze.GlobPolyOrder+1; i++){
				temp = temp + "  A" + i + ": " + analyze.Total.FinalCoefficients[i].ToString("N4")
					+ "   SE: " + analyze.Total.FinalSECoefficients[i].ToString("N4") ;
			}
			for (j = 0; j < analyze.Total.N.Length; j++){
					N1ave = N1ave + analyze.Total.N[j];
				}
			N1ave = N1ave/j;
			temp = temp + "                                 Average points/interval:     " + N1ave.ToString("N0");
			temp = temp + "                                 R^2: " + analyze.Total.RSquared;
			/*if (analyze.OffsetData.OffsetFlag == 1){
				temp = temp + "                                     Offset Yield Stress: " + analyze.OffsetData.YieldStress
					+ "  Offset Yield Strain: " + analyze.OffsetData.YieldStrain;
			}*/
			polyTxtBox.Text = temp;
			
			//Writes the contents for the polynomial coefficients text box (strain vs strain)
			temp = "Polynomial Coefficients:";
			if  (analyze.NumberofTranFiles  != 0){
				for (i = 0; i < analyze.GlobPolyOrder+1; i++){
					temp = temp + "  A" + i + ": " + analyze.NU.FinalCoefficients[i].ToString("N4") + "   SE: " + analyze.NU.FinalSECoefficients[i].ToString("N4") ;
				}
				for (j = 0; j < analyze.NU.N.Length; j++){
					N2ave = N2ave + analyze.NU.N[j];
				}
				N2ave = N2ave/j;
				temp = temp + "                                 Average points/interval:     " + N2ave.ToString("N0");
				temp = temp + "                                 R^2: " + analyze.Total.RSquared;
			} 
			else
				temp = temp + " None";
			taPolyTxtBox.Text = temp;		
		}
		
		void SsLOESSCheckBoxCheckedChanged(object sender, EventArgs e)
		{
			PlotMaker pm = new PlotMaker(analyze,analyze.RawData.Length, temperature, material, 0);
			pm.PlotMaker13();
		}
		
		void TaLOESSCheckBoxCheckedChanged(object sender, EventArgs e)
		{
			PlotMaker pm = new PlotMaker(analyze,analyze.RawData.Length, temperature, material, 0);
			pm.PlotMaker14();
		}
	}
}
