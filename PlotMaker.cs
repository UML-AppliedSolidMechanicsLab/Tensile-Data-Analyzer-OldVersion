/*
 * Created by SharpDevelop.
 * User: e46221
 * Date: 7/18/2007
 * Time: 10:19 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using ZedGraph;
using System.Windows.Forms;

namespace StressStrainData
	
{
	/// <summary>
	/// Description of PlotMaker.
	/// </summary>
	public class PlotMaker
	{
		private int i,j,k;
		private Analyze analyze;
		private int numberofFiles, fileNumber;
		private string temperature, material;
		private double temp;
		
		public PlotMaker(Analyze Analyze, int NumberofFiles, string Temperature, string Material, int FileNumber){
			analyze = Analyze;
			numberofFiles = NumberofFiles;
			material = Material;
			temperature = Temperature;
			fileNumber = FileNumber;
		}
			
		public void PlotMaker1(){
			//Plot 1:  all specimens, stress vs strain, raw, ave, and zeroed
						PointPairList list1 = new PointPairList();
						PointPairList list2 = new PointPairList();
						PointPairList list3 = new PointPairList();
						for (i = 0; i < numberofFiles; i++){
							for (k = 0; k < analyze.RawData[i].AxChan; k ++){
								for (j = 0; j < analyze.RawData[i].RawData.GetUpperBound(0)+1; j++){
									list1.Add(analyze.RawData[i].RawData[j,1+k], analyze.RawData[i].RawData[j,0]);
								}
							}
							for (j = 0; j < analyze.AveData[i].AveragedData.GetUpperBound(0)+1; j++){
								list2.Add(analyze.AveData[i].AveragedData[j,1], analyze.AveData[i].AveragedData[j,0]);
							} 
							for (j = 0; j < analyze.ZeroData[i].ZeroedData.GetUpperBound(0)+1; j++){
								list3.Add(analyze.ZeroData[i].ZeroedData[j,1], analyze.ZeroData[i].ZeroedData[j,0]);
							} 
						}
						Plot3 pl3 = new Plot3(list1, list2, list3, "All Specimens: " + material + ": " + temperature + "K ", "Strain",
						                      "Stress",  "Raw Data","Average", "Zeroed");
			
		}
		public void PlotMaker2(){
		//Plot 2:  selected specimen, stress vs strain, raw, ave, and zeroed
			i = fileNumber-1;
			PointPairList list4 = new PointPairList();
			PointPairList list5 = new PointPairList();
			PointPairList list6 = new PointPairList();
			for (k = 0; k < analyze.RawData[i].AxChan; k ++){
				for (j = 0; j < analyze.RawData[i].RawData.GetUpperBound(0)+1; j++){
					list4.Add(analyze.RawData[i].RawData[j,1+k], analyze.RawData[i].RawData[j,0]);
				}
			}
			for (j = 0; j < analyze.AveData[i].AveragedData.GetUpperBound(0)+1; j++){
				list5.Add(analyze.AveData[i].AveragedData[j,1], analyze.AveData[i].AveragedData[j,0]);
			} 
			for (j = 0; j < analyze.ZeroData[i].ZeroedData.GetUpperBound(0)+1; j++){
				list6.Add(analyze.ZeroData[i].ZeroedData[j,1], analyze.ZeroData[i].ZeroedData[j,0]);
			} 
					
			Plot3 pl3a = new Plot3(list4, list5, list6, "Specimen "+ fileNumber + ": " + material + ": " + temperature + "K ", "Strain",
						                      "Stress",  "Raw Data","Average", "Zeroed");
		}
		public void PlotMaker3(){
			//Plot 3:  all specimens, strain vs strain, raw, ave, and zeroed (actually, it plots the raw tran strain against the averaged axial strain)
						PointPairList list7 = new PointPairList();
						PointPairList list8 = new PointPairList();
						PointPairList list9 = new PointPairList();
						for (i = 0; i < numberofFiles; i++){
							if (analyze.RawData[i].TranChan != 0){
								for (k = 0; k < analyze.RawData[i].TranChan; k ++){
									for (j = 0; j < analyze.RawData[i].RawData.GetUpperBound(0)+1; j++){
										list7.Add(analyze.AveData[i].AveragedData[j,1], analyze.RawData[i].RawData[j,1+analyze.RawData[i].AxChan+k]);
									}
								}
								for (j = 0; j < analyze.AveData[i].AveragedData.GetUpperBound(0)+1; j++){
									list8.Add(analyze.AveData[i].AveragedData[j,1], analyze.AveData[i].AveragedData[j,2]);
								} 
								for (j = 0; j < analyze.ZeroNUData[i].ZeroedData.GetUpperBound(0)+1; j++){
									list9.Add(analyze.ZeroNUData[i].ZeroedData[j,1], analyze.ZeroNUData[i].ZeroedData[j,0]);
								} 
							}
						}
						Plot3 pl3b = new Plot3(list7, list8, list9, "All Specimens: " + material + ": " + temperature + "K ", "Axial Strain",
						                      "Transverse Strain",  "Raw Data","Average", "Zeroed");
		}
		public void PlotMaker4(){
			//Plot 4: selected specimen, strain vs strain, raw, ave, and zeroed
						i = fileNumber-1;
						PointPairList list10 = new PointPairList();
						PointPairList list11 = new PointPairList();
						PointPairList list12 = new PointPairList();
						if (analyze.RawData[i].TranChan == 0){
							MessageBox.Show("file has no Transverse Strain data");
						}
						else{
							for (k = 0; k < analyze.RawData[i].TranChan; k ++){
								for (j = 0; j < analyze.RawData[i].RawData.GetUpperBound(0)+1; j++){
									list10.Add(analyze.AveData[i].AveragedData[j,1], analyze.RawData[i].RawData[j,1+analyze.RawData[i].AxChan+k]);
								}
							}
							for (j = 0; j < analyze.AveData[i].AveragedData.GetUpperBound(0)+1; j++){
								list11.Add(analyze.AveData[i].AveragedData[j,1], analyze.AveData[i].AveragedData[j,2]);
							} 
							for (j = 0; j < analyze.ZeroData[i].ZeroedData.GetUpperBound(0)+1; j++){
								list12.Add(analyze.ZeroNUData[i].ZeroedData[j,1], analyze.ZeroNUData[i].ZeroedData[j,0]);
							} 
					
							Plot3 pl3c = new Plot3(list10, list11, list12, "Specimen "+ fileNumber + ": " + material + ": " + temperature + "K "
							                       , "Strain", "Stress",  "Raw Data","Average", "Zeroed");
						}
		}
		public void PlotMaker5(){
			//Plot 5:  all specimens, stress vs strain, Zeroed vs LOESS
						PointPairList list13 = new PointPairList();
						PointPairList list14 = new PointPairList();
						PointPairList list15 = new PointPairList();
						PointPairList list16 = new PointPairList();
						for (j = 0; j < analyze.CombinedData.GetUpperBound(0)+1; j++){
							list13.Add(analyze.CombinedData[j,1], analyze.CombinedData[j,0]);
						}
						for (j = 0; j < analyze.Total.MeanData.GetUpperBound(0)+1; j++){
								list14.Add(analyze.Total.MeanData[j,1], analyze.Total.MeanData[j,0]);
								list15.Add(analyze.Total.MeanData[j,1], analyze.Total.MeanData[j,0]+ analyze.Total.SECoefficients[j,0],
							          analyze.Total.MeanData[j,0]- analyze.Total.SECoefficients[j,0]);
						} 
						double tempx;
						for (j = 0; j < 500; j++){
								Polynomial poly = new Polynomial();
								tempx = 0 + (analyze.Cutoff/500)*j;
								list16.Add(tempx, poly.EvaluatePolynomial(tempx,analyze.Total.FinalCout));
							}
						Plot3e pl3a = new Plot3e(list13, list14, list15, list16, "All Specimens: " + material + ": " 
						                         + temperature + "K ", "Strain", "Stress",  
						                         "Zeroed Data","Mean Points", "error", "Polynomial Fit");
		}
		public void PlotMaker6(){
			//Plot 6:  selected specimen, stress vs strain, Zeroed vs LOESS
						i = fileNumber-1;
						PointPairList list16 = new PointPairList();
						PointPairList list17 = new PointPairList();
						PointPairList list18 = new PointPairList();
						PointPairList list19 = new PointPairList();
						for (j = 0; j < analyze.AveData[i].AveragedData.GetUpperBound(0)+1; j++){
							list16.Add(analyze.AveData[i].AveragedData[j,1], analyze.AveData[i].AveragedData[j,0]);
						}
						for (j = 0; j < analyze.ZeroData[i].MeanData.GetUpperBound(0)+1; j++){
							list17.Add(analyze.ZeroData[i].MeanData[j,1], analyze.ZeroData[i].MeanData[j,0]);
							list18.Add(analyze.ZeroData[i].MeanData[j,1], analyze.ZeroData[i].MeanData[j,0]+ analyze.ZeroData[i].SECoefficients[j,0],
							          analyze.ZeroData[i].MeanData[j,0]- analyze.ZeroData[i].SECoefficients[j,0]);
						}
						double tempx;
						for (j = 0; j < 500; j++){
								Polynomial poly = new Polynomial();
								tempx = analyze.ZeroData[i].OffsetData.StrainOffset + (analyze.Cutoff/500)*j;
								list19.Add(tempx, poly.EvaluatePolynomial(tempx,analyze.ZeroData[i].TotalCout));
							}
						
					Plot3e pl2b = new Plot3e(list16, list17, list18, list19, "Specimen "+ fileNumber + ": " + material + ": " + temperature + "K ", "Strain",
						                      "Stress",  "Averaged Data","Mean Points", "error", "Polynomial fit");
		}
		public void PlotMaker7(){
			//Plot 7:  all specimens, strain vs strain, Zeroed vs LOESS
						PointPairList list19 = new PointPairList();
						PointPairList list20 = new PointPairList();
						PointPairList list21 = new PointPairList();
						PointPairList list22 = new PointPairList();
						for (i = 0; i < numberofFiles; i++){
							if (analyze.RawData[i].TranChan != 0){
								for (k = 0; k < analyze.RawData[i].TranChan; k ++){
									for (j = 0; j < analyze.CombinedNUData.GetUpperBound(0)+1; j++){
										list19.Add(analyze.CombinedNUData[j,1], analyze.CombinedNUData[j,0]);
									}
								}
								for (j = 0; j < analyze.NU.MeanData.GetUpperBound(0)+1; j++){
									list20.Add(analyze.NU.MeanData[j,1], analyze.NU.MeanData[j,0]);
									list21.Add(analyze.NU.MeanData[j,1],
									           analyze.NU.MeanData[j,0]+analyze.NU.SECoefficients[j,0],
									           analyze.NU.MeanData[j,0]-analyze.NU.SECoefficients[j,0]);
								} 
							}
						}
						double tempx;
						for (j = 0; j < 500; j++){
								Polynomial poly = new Polynomial();
								tempx = 0 + (analyze.Cutoff/500)*j;
									list22.Add(tempx, poly.EvaluatePolynomial(tempx,analyze.NU.FinalCout));
							}
		
						Plot3e pl2c = new Plot3e(list19, list20, list21, list22, "All Specimens: " + material + ": " 
						                         + temperature + "K ", "Axial Strain",
						                      "Transverse Strain",  "Zeroed Data","Mean Points", 
						                      "error", "Polynomial fit");
		}
		public void PlotMaker8(){
			//Plot 8: selected specimen, strain vs strain, Zeroed vs LOESS
						i = fileNumber-1;
						PointPairList list22 = new PointPairList();
						PointPairList list23 = new PointPairList();
						PointPairList list24 = new PointPairList();
						PointPairList list25 = new PointPairList();
						if (analyze.RawData[i].TranChan == 0){
							MessageBox.Show("file has no Transverse Strain data");
						}
						else{
							for (k = 0; k < analyze.RawData[i].TranChan; k ++){
								for (j = 0; j < analyze.AveData[i].AveragedData.GetUpperBound(0)+1; j++){
								list22.Add(analyze.AveData[i].AveragedData[j,1], analyze.AveData[i].AveragedData[j,2]);
								}
							}
							for (j = 0; j < analyze.ZeroNUData[i].MeanData.GetUpperBound(0)+1; j++){
								list23.Add(analyze.ZeroNUData[i].MeanData[j,1], analyze.ZeroNUData[i].MeanData[j,0]);
								list24.Add(analyze.ZeroNUData[i].MeanData[j,1], 
								           analyze.ZeroNUData[i].MeanData[j,0] + analyze.ZeroNUData[i].SECoefficients[j,0],
								          analyze.ZeroNUData[i].MeanData[j,0] - analyze.ZeroNUData[i].SECoefficients[j,0]);
							} 
							double tempx;
							for (j = 0; j < 500; j++){
								Polynomial poly = new Polynomial();
								tempx = 0 + (analyze.Cutoff/500)*j;
									list25.Add(tempx, poly.EvaluatePolynomial(tempx,analyze.ZeroNUData[i].TotalCout));
							}
						
						Plot3e pl2c = new Plot3e(list22, list23, list24, list25, "Specimen "+ fileNumber + ": " 
							                         + material + ": " + temperature + "K ", 
							                         "Axial Strain", "Transverse Strain",
							                         "Averaged Data","Mean Points", "error", "Polynomial fit");
						}
		}
		public void PlotMaker9(){
			//Plot 9:  all specimens, stress vs strain,  Modulus
						PointPairList list25 = new PointPairList();
						PointPairList list26 = new PointPairList();
						PointPairList list25e = new PointPairList();
						PointPairList list26e = new PointPairList();
						PointPairList list27 = new PointPairList();
						
						for (j = 0; j < analyze.Total.Coefficients.GetUpperBound(0)+1; j++){
							temp = 0;
							for (k = 0; k < analyze.LocPolyOrder; k++){
								temp = temp + ((analyze.Total.Coefficients[j,k+1])*Math.Pow(analyze.Total.MeanData[j,1],k));
							}
							list25.Add(analyze.Total.MeanData[j,1], temp);
							if (analyze.LocPolyOrder > 0){
							list25e.Add(analyze.Total.MeanData[j,1], 
							            temp+analyze.Total.SECoefficients[j,1],
							           temp-analyze.Total.SECoefficients[j,1]);
							}
						}
						for (j = 0; j < analyze.Total.SecantSlope.GetUpperBound(0)+1; j++){
							list26.Add(analyze.Total.MeanData[j,1], analyze.Total.SecantSlope[j]);
							list26e.Add(analyze.Total.MeanData[j,1], 
								            analyze.Total.SecantSlope[j] + analyze.Total.SESecantSlope[j],
								           analyze.Total.SecantSlope[j] - analyze.Total.SESecantSlope[j]);
							temp = 0;
							for (k = 0; k < analyze.GlobPolyOrder; k++){
								temp = temp + ((analyze.Total.FinalCoefficients[k+1])*Math.Pow(analyze.Total.MeanData[j,1],k));
							}
							list27.Add(analyze.Total.MeanData[j,1],temp);
						} 
						
						Plot3e2 pl2a = new Plot3e2(list25, list25e, list26, list26e, list27,
						                           "All Specimens: " + material + ": " + temperature 
						                           + "K ", "Axial Strain", "Modulus", 
						                           "Local Tangent",  "error","Secant", "error", "Global Tangent");
		}
		public void PlotMaker10(){
			//Plot 10:  selected specimen, stress vs strain, Sec vs Tan Modulus
						i = fileNumber-1;
						PointPairList list25 = new PointPairList();
						PointPairList list26 = new PointPairList();
						PointPairList list25e = new PointPairList();
						PointPairList list26e = new PointPairList();
						PointPairList list27 = new PointPairList();
						for (j = 0; j < analyze.ZeroData[i].MeanData.GetUpperBound(0)+1; j++){
							temp = 0;
							for (k = 0; k < analyze.LocPolyOrder; k++){
								temp = temp + ((analyze.ZeroData[i].Coefficients[j,k+1])*Math.Pow(analyze.ZeroData[i].MeanData[j,1],k));
							}
							list25.Add(analyze.ZeroData[i].MeanData[j,1], temp);
							if (analyze.LocPolyOrder > 0){
								list25e.Add(analyze.ZeroData[i].MeanData[j,1], 
							            temp+analyze.ZeroData[i].SECoefficients[j,1],
							           temp-analyze.ZeroData[i].SECoefficients[j,1]);
							}
						}
						for (j = 0; j < analyze.ZeroData[i].SecantSlope.GetUpperBound(0)+1; j++){
							list26.Add(analyze.ZeroData[i].MeanData[j,1], analyze.ZeroData[i].SecantSlope[j]);
							list26e.Add(analyze.ZeroData[i].MeanData[j,1], 
								            analyze.ZeroData[i].SecantSlope[j] + analyze.ZeroData[i].SESecantSlope[j],
								           analyze.ZeroData[i].SecantSlope[j] - analyze.ZeroData[i].SESecantSlope[j]);
							temp = 0;
							for (k = 0; k < analyze.GlobPolyOrder; k++){
								temp = temp + ((analyze.ZeroData[i].TotalCout[k+1,0])*Math.Pow(analyze.ZeroData[i].MeanData[j,1],k));
							}
							list27.Add(analyze.ZeroData[i].MeanData[j,1],temp);
						} 
					
					Plot3e2 pl2b = new Plot3e2(list25, list25e, list26, list26e, list27, "Specimen "+ fileNumber + ": " 
						                         + material + ": " + temperature + 
						                         "K ", "Axial Strain",
						                      "Modulus (Msi)", "Local Tangent",  "error","Secant", "error", "Global Tangent");
		}
		public void PlotMaker11(){
			//Plot 11:  all specimens, strain vs strain, Sec vs Tan NU
						PointPairList list25 = new PointPairList();
						PointPairList list26 = new PointPairList();
						PointPairList list25e = new PointPairList();
						PointPairList list26e = new PointPairList();
						PointPairList list27 = new PointPairList();
						for (i = 0; i < numberofFiles; i++){
							for (j = 0; j < analyze.NU.Coefficients.GetUpperBound(0)+1; j++){
								temp = 0;
								for (k = 0; k < analyze.LocPolyOrder; k++){
									temp = temp + ((analyze.NU.Coefficients[j,k+1])*Math.Pow(analyze.NU.MeanData[j,1],k));
								}
								list25.Add(analyze.NU.MeanData[j,1], temp);
								if (analyze.LocPolyOrder > 0){
								list25e.Add(analyze.NU.MeanData[j,1], 
							            temp+analyze.NU.SECoefficients[j,1],
							           temp-analyze.NU.SECoefficients[j,1]);
								}
							}
							for (j = 0; j < analyze.NU.SecantSlope.GetUpperBound(0)+1; j++){
								list26.Add(analyze.NU.MeanData[j,1], analyze.NU.SecantSlope[j]);
								list26e.Add(analyze.NU.MeanData[j,1], 
								            analyze.NU.SecantSlope[j] + analyze.NU.SESecantSlope[j],
								           analyze.NU.SecantSlope[j] - analyze.NU.SESecantSlope[j]);
								temp = 0;
								for (k = 0; k < analyze.GlobPolyOrder; k++){
									temp = temp + ((analyze.NU.FinalCoefficients[k+1])*Math.Pow(analyze.NU.MeanData[j,1],k));
								}
								list27.Add(analyze.NU.MeanData[j,1],temp);
							} 
						}
						Plot3e2 pl2c = new Plot3e2(list25, list25e, list26, list26e, list27, "All Specimens: " + material + ": " 
						                         + temperature + "K ", "Axial Strain",
						                         "Poisson's Ratio", "Local Tangent",  "error","Secant", "error", "Global Tangent");
		}
		public void PlotMaker12(){
			//Plot 12: selected specimen, strain vs strain, Sec vs Tan NU
						i = fileNumber-1;
						PointPairList list25 = new PointPairList();
						PointPairList list26 = new PointPairList();
						PointPairList list25e = new PointPairList();
						PointPairList list26e = new PointPairList();
						PointPairList list27 = new PointPairList();
						if (analyze.RawData[i].TranChan == 0){
							MessageBox.Show("file has no Transverse Strain data");
						}
						else{
							for (j = 0; j < analyze.ZeroNUData[i].MeanData.GetUpperBound(0)+1; j++){
								temp = 0;
								for (k = 0; k < analyze.LocPolyOrder; k++){
									temp = temp + ((analyze.ZeroNUData[i].Coefficients[j,k+1])*Math.Pow(analyze.ZeroNUData[i].MeanData[j,1],k));
								}
								list25.Add(analyze.ZeroNUData[i].MeanData[j,1], analyze.ZeroNUData[i].Coefficients[j,1]);
								if (analyze.LocPolyOrder > 0){
								list25e.Add(analyze.ZeroNUData[i].MeanData[j,1], 
							            temp+analyze.ZeroNUData[i].SECoefficients[j,1],
							           temp-analyze.ZeroNUData[i].SECoefficients[j,1]);
								}
							}
							for (j = 0; j < analyze.ZeroNUData[i].SecantSlope.GetUpperBound(0)+1; j++){
								list26.Add(analyze.ZeroNUData[i].MeanData[j,1], analyze.ZeroNUData[i].SecantSlope[j]);
								list26e.Add(analyze.ZeroNUData[i].MeanData[j,1], 
								            analyze.ZeroNUData[i].SecantSlope[j] + analyze.ZeroNUData[i].SESecantSlope[j],
								           analyze.ZeroNUData[i].SecantSlope[j] - analyze.ZeroNUData[i].SESecantSlope[j]);
								temp = 0;
								for (k = 0; k < analyze.GlobPolyOrder; k++){
									temp = temp + ((analyze.ZeroNUData[i].TotalCout[k+1,0])*Math.Pow(analyze.ZeroNUData[i].MeanData[j,1],k));
								}
							list27.Add(analyze.ZeroNUData[i].MeanData[j,1],temp);
							} 
							Plot3e2 pl2a = new Plot3e2(list25, list25e, list26, list26e, list27, "Specimen "+ fileNumber 
							                         + ": " + material + ": " + temperature + "K ",
							                       "Axial Strain","Poisson's Ratio", "Local Tangent", 
							                       "error","Secant", "error", "Global Tangent");
						}
		}
		public void PlotMaker13(){
			//Plot 13:  all specimens, stress vs strain,  LOESS
						PointPairList list14 = new PointPairList();
						PointPairList list15 = new PointPairList();
						
						for (j = 0; j < analyze.Total.MeanData.GetUpperBound(0)+1; j++){
								list14.Add(analyze.Total.MeanData[j,1], analyze.Total.MeanData[j,0]);
								list15.Add(analyze.Total.MeanData[j,1], analyze.Total.MeanData[j,0]+ analyze.Total.SECoefficients[j,0],
							          analyze.Total.MeanData[j,0]- analyze.Total.SECoefficients[j,0]);
						} 
						
						Plot1e pl3a = new Plot1e(list14, list15, "All Specimens: " + material + ": " + temperature + "K ", "Strain ",
						                      "Stress",  "Mean Points", "error");
		}
		public void PlotMaker14(){
			//Plot 14:  all specimens, strain vs strain,  LOESS
						PointPairList list20 = new PointPairList();
						PointPairList list21 = new PointPairList();
						for (i = 0; i < numberofFiles; i++){
							if (analyze.RawData[i].TranChan != 0){
								for (j = 0; j < analyze.NU.MeanData.GetUpperBound(0)+1; j++){
									list20.Add(analyze.NU.MeanData[j,1], analyze.NU.MeanData[j,0]);
									list21.Add(analyze.NU.MeanData[j,1],
									           analyze.NU.MeanData[j,0]+analyze.NU.SECoefficients[j,0],
									           analyze.NU.MeanData[j,0]-analyze.NU.SECoefficients[j,0]);
								} 
							}
						}
						Plot1e pl4c = new Plot1e(list20, list21, "All Specimens: " + material + ": " 
						                         + temperature + "K ", "Axial Strain ",
						                      "Transverse Strain","Mean Points", "error");
		}
		public void PlotMaker15(){
			//Plot 15:  offset yield stress/strain
						PointPairList list13 = new PointPairList();
						PointPairList list14 = new PointPairList();
						PointPairList list15 = new PointPairList();
						PointPairList list16 = new PointPairList();
						Polynomial poly = new Polynomial();
						
						for (j = 0; j < analyze.Total.MeanData.GetUpperBound(0)+1; j++){
								list14.Add(analyze.Total.MeanData[j,1], analyze.Total.MeanData[j,0]);
								list15.Add(analyze.Total.MeanData[j,1], analyze.Total.MeanData[j,0]+ analyze.Total.SECoefficients[j,0],
							          analyze.Total.MeanData[j,0]- analyze.Total.SECoefficients[j,0]);
						} 
						//list16.Add(0, poly.EvaluatePolynomial(0,analyze.OffsetData.COut));
						//list16.Add(analyze.OffsetData.YieldStrain+1000, 
						//           poly.EvaluatePolynomial(analyze.OffsetData.YieldStrain+1000,analyze.OffsetData.COut));
						//list13.Add(analyze.OffsetData.YieldStrain, analyze.OffsetData.YieldStress);
						//Plot3e pl3a = new Plot3e(list13, list14, list15, list16, "All Specimens: " + material + ": "
						//                         + temperature + "K ", "Strain (microstrain)", "Stress (psi)",  
						//                         " " +analyze.OffsetData.PercentOffset+ " % Offset Yield Stress","Mean Points", "error", "Offset");
						Plot3e pl3a = new Plot3e(list13, list14, list15, list16, "All Specimens: " + material + ": "
						                         + temperature + "K ", "Strain ", "Stress",  
						                         " ","Mean Points", "error", "Offset");
		}
	}
}
