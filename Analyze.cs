/*
 * Created by SharpDevelop.
 * User: e46221
 * Date: 7/11/2007
 * Time: 11:23 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace StressStrainData
{
	
	public class Analyze
	{
		private string [] root;
		private int [] tranChan, axChan, rowStart, rowEnd, chanStrain, chanStress, dispflag;
		private double [] length, xSecArea;
		private double cutoff, interval;
		private string temperature;
		private int locPolyOrder, globPolyOrder, numberofFiles, numberofTranFiles;
		private FileReader[] rawData;
		private Averager[] aveData;
		private Zeroer[] zeroData;
		private Zeroer[] zeroNUData;
		private double [,] combinedData;
		private double [,] combinedNUData;
		private Combination total;
		private Combination nu;
		
		/// <summary>
		/// takes in an inputArray where each column is the input data for each file scanned,
		/// with the 1st row being the root, 2nd the # of axial strain channels, 3rd the #
		/// of transverse strain channels, 4th the specimen length, and 5th the x-sec area.
		/// The last column is for the group inputs, with the 1st row being the cutoff strain,
		/// 2nd the polynomial order, 3rd the LOESS interval, 4th the temperature, and 5th the
		/// # of files scanned in.  Also, takes in the offest array: 1st element is 0 if not an option
		/// </summary>
		/// <param name="individualInputsList"></param>
		/// <param name="groupInputsList"></param>
		/// <param name="offsetArray"></param>
		public Analyze(List<string[]> individualInputsList, string[] groupInputsList, double [] offsetArray){
			

			numberofFiles = Convert.ToInt32(groupInputsList[5]);
			numberofTranFiles = Convert.ToInt32(groupInputsList[6]);
			
			int i,j, k, sum;
			rawData = new FileReader[numberofFiles];
			aveData = new Averager[numberofFiles];
			zeroData = new Zeroer[numberofFiles];
			zeroNUData = new Zeroer[numberofTranFiles];
			root = new string [numberofFiles];
			axChan = new int [numberofFiles];
			tranChan = new int [numberofFiles];
			length = new double [numberofFiles];
			xSecArea = new double [numberofFiles];
			rowStart = new int [numberofFiles];
			rowEnd = new int [numberofFiles];
			chanStrain = new int [numberofFiles];
			chanStress = new int [numberofFiles];
			dispflag = new int [numberofFiles];
			
			//split up the input array into seperate arrays and variables
			
			cutoff = Convert.ToDouble(groupInputsList[0]);
			locPolyOrder = Convert.ToInt32(groupInputsList[1]);
			globPolyOrder = Convert.ToInt32(groupInputsList[2]);
			interval = Convert.ToDouble(groupInputsList[3]);
			temperature = groupInputsList[4].ToString();
			
			for (i = 0; i < (numberofFiles); i++){
				root[i] = individualInputsList[i][0];
				axChan[i] = Convert.ToInt32(individualInputsList[i][1]);
				tranChan[i] = Convert.ToInt32(individualInputsList[i][2]);
				length[i] = Convert.ToDouble(individualInputsList[i][3]);
				xSecArea[i] = Convert.ToDouble(individualInputsList[i][4]);
				rowStart[i] = Convert.ToInt32(individualInputsList[i][5]);
				rowEnd[i] = Convert.ToInt32(individualInputsList[i][6]);
				chanStrain[i] = Convert.ToInt32(individualInputsList[i][7]);
				chanStress[i] = Convert.ToInt32(individualInputsList[i][8]);
				dispflag[i] = Convert.ToInt32(individualInputsList[i][9]);
			}
			
			
			sum = 0;
			for (i = 0; i < (numberofFiles); i++){
				//Average all of the channels if there are more than one
				rawData[i] =new FileReader(root[i], axChan[i], tranChan[i], length[i], xSecArea[i],
				                           rowStart[i], rowEnd[i], chanStrain[i], chanStress[i], dispflag[i]);
				aveData[i] =new Averager(rawData[i].RawData, rawData[i].AxChan, rawData[i].TranChan);
				//Now find the offset to zero the data
				//offsetData = new Offset(total,offsetArray);
				zeroData[i] = new Zeroer(aveData[i].AveragedData, locPolyOrder, globPolyOrder, interval, cutoff, 1, 0, offsetArray);
				sum = sum + zeroData[i].ZeroedData.GetUpperBound(0)+1;
			}
			
			j = 0;
			combinedData = new double [sum, 2];
			for (i = 0; i < (numberofFiles); i++){
				for (k = 0; k < (zeroData[i].ZeroedData.GetUpperBound(0)+1); k++){
					combinedData[j,0] = zeroData[i].ZeroedData[k,0];
					combinedData[j,1] = zeroData[i].ZeroedData[k,1];
					j++;
				}
			}
			
			total = new Combination(combinedData, locPolyOrder, globPolyOrder, interval);
			
			//now do the same thing for transverse strain data (to find NU)
			if (numberofTranFiles != 0){
				sum = 0;
				for (i = 0; i < (numberofFiles); i++){
					if (rawData[i].TranChan != 0){
						zeroNUData[i] = new Zeroer(aveData[i].AveragedData, locPolyOrder, globPolyOrder, interval, cutoff, 1, 2, offsetArray);
						sum = sum + zeroNUData[i].ZeroedData.GetUpperBound(0)+1;
					}
				}
				
				j = 0;
				//with combinedNUData, first comes transverse [0], then axial [1]
				combinedNUData = new double [sum, 2];
				for (i = 0; i < (numberofTranFiles); i++){
					for (k = 0; k < (zeroNUData[i].ZeroedData.GetUpperBound(0)+1); k++){
						combinedNUData[j,0] = zeroNUData[i].ZeroedData[k,0];
						combinedNUData[j,1] = zeroNUData[i].ZeroedData[k,1];
						j++;
					}
				}
				nu = new Combination(combinedNUData, locPolyOrder, globPolyOrder, interval);
				
			}
			//Now find the offset if it was checked in the input window
			//offsetData = new Offset(total,offsetArray);
			
		}
		
		//Accessors (so that I can get to them from MainForm
		public FileReader[] RawData{
			get{return rawData;}
		}
		public Averager[] AveData{
			get{return aveData;}
		}
		public Zeroer[] ZeroData{
			get{return zeroData;}
		}
		public double [,] CombinedData{
			get{return combinedData;}
		}
		public Combination Total{
			get{return total;}
		}
		public Combination NU{
			get{return nu;}
		}
		public double [,] CombinedNUData{
			get{return combinedNUData;}
		}
		public Zeroer[] ZeroNUData{
			get{return zeroNUData;}
		}
		public double Cutoff{
			get{return cutoff;}
		}
		public double Interval{
			get{return interval;}
		}
		public double GlobPolyOrder{
			get{return globPolyOrder;}
		}
		public double LocPolyOrder{
			get{return locPolyOrder;}
		}
		public int NumberofTranFiles{
			get{return numberofTranFiles;}
		}
	}
}
