/*
 * Created by SharpDevelop.
 * User: e46221
 * Date: 7/11/2007
 * Time: 4:40 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace StressStrainData
{
	/// <summary>
	///This little guy just averages out the strain data in the case that there are multiple channels.
	///If there are not multiple channels, it does nothing.  It just spits out an array with either 2
	///or three columns of averaged data.  Good place for more error finding.  Also, change transverse
	///strain to positive
	/// </summary>
	public class Averager
	{
		private double [,] averagedData;
		
		public Averager(double [,] inInputData, int inAxChan, int inTranChan){
			//This little guy just averages out the strain data in the case that there are multiple channels.
			//If there are not multiple channels, it does nothing.  It just spits out an array with either 2
			//or three columns of averaged data.  Good place for more error finding.  Also, change transverse
			//strain to positive.
			int flag = 1;
			int i,j;
			double sum;
			if (inTranChan == 0)
				flag = 0;
			averagedData = new double [inInputData.GetUpperBound(0)+1, 2+flag];
			for (i = 0; i < inInputData.GetUpperBound(0)+1; i++){
					averagedData[i,0] = inInputData[i,0];
					sum = 0;
					for (j=0; j < inAxChan; j++){
						sum = sum + inInputData[i,j+1];
					}
					averagedData[i,1] = sum/inAxChan;
					if (inTranChan != 0){
						sum = 0;
						for (j=0; j < inTranChan; j++){
							sum = sum + inInputData[i,j+1+inAxChan];
						}
						averagedData[i,2] = sum/inTranChan;
					}
			}
			
						
		}
		//Accessors (so that I can get to them from Analyze and MainForm
		public double[,] AveragedData{
			get{return averagedData;}
		}
	}
}
