/*
 * Created by SharpDevelop.
 * User: e46221
 * Date: 7/18/2007
 * Time: 4:16 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.IO;

namespace StressStrainData
{
	/// <summary>
	/// Description of FileWriter.
	/// </summary>
	public class FileWriter
	{
		StreamWriter dataWrite;
		private int i,j,k;
		private Analyze analyze;
		private int numberofFiles;
		private string temperature, material, folder;
		
		public FileWriter(Analyze Analyze, int NumberofFiles, string Temperature, string Material, string Folder){
			analyze = Analyze;
			numberofFiles = NumberofFiles;
			material = Material;
			temperature = Temperature;
			folder = Folder;
		}
			
		public void FileWriter1(){
			/*FileWriter 1:  one file for each specimen, writes the raw data, averaged Data, Zeroed and Cut Data
			 * for the stress/strain data*/
			
			for (i = 0; i < numberofFiles; i++){
				dataWrite = new StreamWriter(analyze.RawData[i].Root + "DataHandlingE.csv");
				dataWrite.WriteLine("Created: " + DateTime.Now + "\n Material:," + material + "\n Temperature:,"
				                   + temperature + "\n (ms = microstrain)");
				dataWrite.WriteLine(" ");
				dataWrite.WriteLine("Cutoff Strain (ms)," + analyze.Cutoff + ",Local Polynomial Order," + analyze.LocPolyOrder
				                    + ",Global Polynomial Order," + analyze.GlobPolyOrder
				                    + ",Interval," + analyze.Interval + ",Strain Offset," + analyze.ZeroData[i].OffsetData.StrainOffset);
				dataWrite.WriteLine(" ");
				
				dataWrite.Write("Raw Data (converted to stress and strain),");
				for (j = 0; j < analyze.RawData[i].AxChan; j++){
					dataWrite.Write(",");
				}
				dataWrite.WriteLine("Averaged Data,,Zeroed then Sorted and Cut");
				
				dataWrite.Write("Stress (psi),");
				for (j = 0; j < analyze.RawData[i].AxChan; j++){
					dataWrite.Write("Strain (ms),");
				}
				dataWrite.Write("Stress (psi),Strain (ms), Stress (psi), Strain (ms)");
				
				for (j = 0; j < analyze.GlobPolyOrder+1; j++){
					dataWrite.Write(",global A" + j);
				}
				
				for (j = 0; j < analyze.RawData[i].RawData.GetUpperBound(0)+1; j++){
					dataWrite.Write("\n" + analyze.RawData[i].RawData[j,0]);
					for (k = 0; k < analyze.RawData[i].AxChan; k++){
						dataWrite.Write("," + analyze.RawData[i].RawData[j,k+1]);
					}
					dataWrite.Write("," + analyze.AveData[i].AveragedData[j,0]);
					dataWrite.Write("," + analyze.AveData[i].AveragedData[j,1]);
					if (j < analyze.ZeroData[i].ZeroedData.GetUpperBound(0)+1){
						dataWrite.Write("," + analyze.ZeroData[i].ZeroedData[j,0]);
						dataWrite.Write("," + analyze.ZeroData[i].ZeroedData[j,1]);
					}
					if (j == 0){
						for (k = 0; k < analyze.GlobPolyOrder+1; k++){
							dataWrite.Write("," + analyze.ZeroData[i].TotalCout[k,0]);
						}	
					}
				}
				dataWrite.Close();	
			}
		}
		public void FileWriter2(){
		/*FileWriter 2:  one file for each specimen, writes all of the data used to break up the individual data
		 * files and fit a curve to them*/
			
			for (i = 0; i < numberofFiles; i++){
				dataWrite = new StreamWriter(analyze.RawData[i].Root + "LoessDataE.csv");
				dataWrite.WriteLine("Created: " + DateTime.Now + "\n Material:," + material + "\n Temperature:,"
				                   + temperature + "\n (ms = microstrain)");
				dataWrite.WriteLine(" ");
				dataWrite.WriteLine("Polynomial Order," + ",Local Polynomial Order," + analyze.LocPolyOrder
				                    + ",Global Polynomial Order," + analyze.GlobPolyOrder
				                    + ",Interval," + analyze.Interval);
				dataWrite.WriteLine(" ");
				
				dataWrite.Write("Mean Stress (psi),Mean Strain (ms), # of Points, Secant Modulus, error ");
				for (j = 0; j < analyze.LocPolyOrder+1; j++){
					dataWrite.Write(",A" + j + ", error");
				}
				dataWrite.Write(",Sigma");
				
				
				for (j = 0; j < analyze.ZeroData[i].MeanData.GetUpperBound(0)+1; j++){
					dataWrite.Write("\n" + analyze.ZeroData[i].MeanData[j,0]);
					dataWrite.Write("," + analyze.ZeroData[i].MeanData[j,1]);
					dataWrite.Write("," + analyze.ZeroData[i].N[j]);
					dataWrite.Write("," + analyze.ZeroData[i].SecantSlope[j]);
					dataWrite.Write("," + analyze.ZeroData[i].SESecantSlope[j]);
					for (k = 0; k < analyze.LocPolyOrder+1; k++){
						dataWrite.Write("," + analyze.ZeroData[i].Coefficients[j,k]);
						dataWrite.Write("," + analyze.ZeroData[i].SECoefficients[j,k]);
					}
					dataWrite.Write("," + analyze.ZeroData[i].Sigma[j]);
				}
				dataWrite.Close();	
			}
		}
		public void FileWriter3(){
			/*FileWriter 3:  one file for each specimen, writes the raw data, averaged Data, Zeroed and Cut Data
			 * for the strain/strain data (along with the poly. coefficients for the fit.*/
			
			for (i = 0; i < numberofFiles; i++){
				if (analyze.RawData[i].TranChan != 0){
					dataWrite = new StreamWriter(analyze.RawData[i].Root + "DataHandlingNU.csv");
					dataWrite.WriteLine("Created: " + DateTime.Now + "\n Material:," + material + "\n Temperature:,"
				                   + temperature + "\n (ms = microstrain)");
					dataWrite.WriteLine(" ");
					dataWrite.WriteLine("Cutoff Strain (ms)," + analyze.Cutoff + ",Local Polynomial Order," + analyze.LocPolyOrder
				                    + ",Global Polynomial Order," + analyze.GlobPolyOrder
				                    + ",Interval," + analyze.Interval + ",Strain Offset," + analyze.ZeroNUData[i].OffsetData.StrainOffset);
					dataWrite.WriteLine(" ");
				
					dataWrite.Write("Raw Data (converted to strains),");
					for (j = 0; j < analyze.RawData[i].AxChan+analyze.RawData[i].TranChan; j++){
						dataWrite.Write(",");
					}
					dataWrite.WriteLine("Averaged Data,,Zeroed then Sorted and Cut");
				
					for (j = 0; j < analyze.RawData[i].TranChan; j++){
						dataWrite.Write("Transverse Strain (ms),");
					}
					for (j = 0; j < analyze.RawData[i].AxChan; j++){
						dataWrite.Write("Axial Strain (ms),");
					}
					dataWrite.Write("Transverse Strain (ms),Axial Strain (ms), Transverse Strain (ms), Axial Strain (ms)");
					
					for (j = 0; j < analyze.GlobPolyOrder+1; j++){
						dataWrite.Write(",global A" + j);
					}
				
					for (j = 0; j < analyze.RawData[i].RawData.GetUpperBound(0)+1; j++){
						//Initialize: first column
						dataWrite.Write("\n" + analyze.RawData[i].RawData[j,analyze.RawData[i].AxChan+1]);
						for (k = 1; k < analyze.RawData[i].TranChan; k++){
							dataWrite.Write("," + analyze.RawData[i].RawData[j,analyze.RawData[i].AxChan+1+k]);
						}
						for (k = 0; k < analyze.RawData[i].AxChan; k++){
							dataWrite.Write("," + analyze.RawData[i].RawData[j,k+1]);
						}
						dataWrite.Write("," + analyze.AveData[i].AveragedData[j,2]);
						dataWrite.Write("," + analyze.AveData[i].AveragedData[j,1]);
						if (j < analyze.ZeroNUData[i].ZeroedData.GetUpperBound(0)+1){
							dataWrite.Write("," + analyze.ZeroNUData[i].ZeroedData[j,0]);
							dataWrite.Write("," + analyze.ZeroNUData[i].ZeroedData[j,1]);
						}
						if (j == 0){
							for (k = 0; k < analyze.GlobPolyOrder+1; k++){
								dataWrite.Write("," + analyze.ZeroNUData[i].TotalCout[k,0]);
							}	
						}
					}
					dataWrite.Close();	
				}
			}
		}
		public void FileWriter4(){
			/*FileWriter 4:  one file for each specimen, writes all of the data used to break up the individual data
		 * files and fit a curve to them for the strain-strain data*/
			
			for (i = 0; i < numberofFiles; i++){
				dataWrite = new StreamWriter(analyze.RawData[i].Root + "LoessDataNU.csv");
				dataWrite.WriteLine("Created: " + DateTime.Now + "\n Material:," + material + "\n Temperature:,"
				                   + temperature + "\n (ms = microstrain)");
				dataWrite.WriteLine(" ");
				dataWrite.WriteLine("Local Polynomial Order," + analyze.LocPolyOrder
				                    + ",Global Polynomial Order," + analyze.GlobPolyOrder 
				                    + ",Interval," + analyze.Interval);
				dataWrite.WriteLine(" ");
				
				if (analyze.ZeroData[i].OffsetData.OffsetFlag == 1){
					dataWrite.Write(",% Offset," + analyze.ZeroData[i].OffsetData.PercentOffset + ",R^2 Minimum," + analyze.ZeroData[i].OffsetData.RMin);
					dataWrite.Write("Yield Stress," + analyze.ZeroData[i].OffsetData.YieldStress + "Yield Strain," + analyze.ZeroData[i].OffsetData.YieldStrain + "Offset," + analyze.ZeroData[i].OffsetData.StrainOffset
							                + "C0," + analyze.ZeroData[i].OffsetData.COut_YieldOffset[0,0] + "C1," + analyze.ZeroData[i].OffsetData.COut_YieldOffset[1,0]);	
				}
				
				
				dataWrite.Write("Mean Transverse Strain (ms),Mean Axial Strain (ms), # of Points, Secant NU, error ");
				for (j = 0; j < analyze.LocPolyOrder; j++){
					dataWrite.Write(",A" + j + " Coeff., error");
				}
				dataWrite.Write(",Sigma");
				
				for (j = 0; j < analyze.ZeroData[i].MeanData.GetUpperBound(0)+1; j++){
					dataWrite.Write("\n" + analyze.ZeroNUData[i].MeanData[j,0]);
					dataWrite.Write("," + analyze.ZeroNUData[i].MeanData[j,1]);
					dataWrite.Write("," + analyze.ZeroNUData[i].N[j]);
					dataWrite.Write("," + analyze.ZeroNUData[i].SecantSlope[j]);
					dataWrite.Write("," + analyze.ZeroNUData[i].SESecantSlope[j]);
					for (k = 0; k < analyze.LocPolyOrder; k++){
						dataWrite.Write("," + analyze.ZeroNUData[i].Coefficients[j,k]);
						dataWrite.Write("," + analyze.ZeroNUData[i].SECoefficients[j,k]);
					}
					dataWrite.Write("," + analyze.ZeroNUData[i].Sigma[j]);
					
				}
				dataWrite.Close();	
			}
		}
		public void FileWriter5(){
			/*FileWriter 5:  one file for all of the specimens, writes all of the details of the LOESS and polynomial 
			 * curve fitting process, including secant and tangent moduli for stress vs strain*/
			
				dataWrite = new StreamWriter(folder + "TotalLoessDataE.csv");
				dataWrite.WriteLine("Created: " + DateTime.Now + "\n Material:," + material + "\n Temperature:,"
				                   + temperature + "\n (ms = microstrain)");
				dataWrite.WriteLine(" ");
				dataWrite.Write("Local Polynomial Order," + analyze.LocPolyOrder
				                    + ",Global Polynomial Order," + analyze.GlobPolyOrder 
				                    + ",Interval," + analyze.Interval);
				
				dataWrite.WriteLine(" ");
				
				dataWrite.Write("Mean Stress (psi),Mean Strain (ms), # of Points, Secant Modulus, error ");
				for (j = 0; j < analyze.LocPolyOrder+1; j++){
					dataWrite.Write(",A" + j + " Coeff., error");
				}
				dataWrite.Write(",Sigma");
				
				for (j = 0; j < analyze.GlobPolyOrder+1; j++){
					dataWrite.Write(",global A" + j);
					dataWrite.Write(",error");
				}
				
				for (j = 0; j < analyze.Total.MeanData.GetUpperBound(0)+1; j++){
					dataWrite.Write("\n" + analyze.Total.MeanData[j,0]);
					dataWrite.Write("," + analyze.Total.MeanData[j,1]);
					dataWrite.Write("," + analyze.Total.N[j]);
					dataWrite.Write("," + analyze.Total.SecantSlope[j]);
					dataWrite.Write("," + analyze.Total.SESecantSlope[j]);
					for (k = 0; k < analyze.LocPolyOrder+1; k++){
						dataWrite.Write("," + analyze.Total.Coefficients[j,k]);
						dataWrite.Write("," + analyze.Total.SECoefficients[j,k]);
					}
					dataWrite.Write("," + analyze.Total.Sigma[j]);
					if (j == 0){
						for (k = 0; k < analyze.GlobPolyOrder+1; k++){
							dataWrite.Write("," + analyze.Total.FinalCoefficients[k]);
							dataWrite.Write("," + analyze.Total.FinalSECoefficients[k]);
						}
					}
					if (j ==1)
						dataWrite.Write(", R^2");
					if (j == 2)
						dataWrite.Write("," + analyze.Total.RSquared);
				}
				dataWrite.Close();
		}
		public void FileWriter6(){
			/*FileWriter 6:  one file for all of the specimens, writes all of the details of the LOESS and polynomial 
			 * curve fitting process, including secant and tangent moduli for strain vs strain*/
			
				dataWrite = new StreamWriter(folder + "TotalLoessDataNU.csv");
				dataWrite.WriteLine("Created: " + DateTime.Now + "\n Material:," + material + "\n Temperature:,"
				                   + temperature + "\n (ms = microstrain)");
				dataWrite.WriteLine(" ");
				dataWrite.WriteLine("Local Polynomial Order," + analyze.LocPolyOrder
				                    + ",Global Polynomial Order," + analyze.GlobPolyOrder
				                    + ",Interval," + analyze.Interval);
				
				dataWrite.Write("\n Mean Transverse Strain (psi),Mean Axial Strain (ms), # of Points, Secant Modulus, error ");
				for (j = 0; j < analyze.LocPolyOrder+1; j++){
					dataWrite.Write(",A" + j + " Coeff., error");
				}
				dataWrite.Write(",Sigma");
				
				for (j = 0; j < analyze.GlobPolyOrder+1; j++){
					dataWrite.Write(",global A" + j);
				}
				
				for (j = 0; j < analyze.NU.MeanData.GetUpperBound(0)+1; j++){
					dataWrite.Write("\n" + analyze.NU.MeanData[j,0]);
					dataWrite.Write("," + analyze.NU.MeanData[j,1]);
					dataWrite.Write("," + analyze.NU.N[j]);
					dataWrite.Write("," + analyze.NU.SecantSlope[j]);
					dataWrite.Write("," + analyze.NU.SESecantSlope[j]);
					for (k = 0; k < analyze.LocPolyOrder+1; k++){
						dataWrite.Write("," + analyze.NU.Coefficients[j,k]);
						dataWrite.Write("," + analyze.NU.SECoefficients[j,k]);
					}
					dataWrite.Write("," + analyze.NU.Sigma[j]);
					if (j == 0){
						for (k = 0; k < analyze.GlobPolyOrder+1; k++){
							dataWrite.Write("," + analyze.NU.FinalCoefficients[k]);
							dataWrite.Write("," + analyze.NU.FinalSECoefficients[k]);
						}	
					}
				}
				dataWrite.Close();	
			}
		
	}
}
