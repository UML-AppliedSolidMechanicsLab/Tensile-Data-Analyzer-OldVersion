/*
 * Created by SharpDevelop.
 * User: e46221
 * Date: 6/18/2007
 * Time: 12:57 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;


namespace StressStrainData
{
	/// <summary>
	/// Description of LOESS ANALYSIS.
	/// </summary>
	public class LOESS
	{
		public static void ReDim(ref double[] inX, int length){
			/*(SES) method to redimension an array
			from http://www.dotnetspider.com/namespace/ShowClass.aspx?ClassId=7*/
			double[] inXTemp=new double[length];
			if (length > inX.Length){
				Array.Copy(inX, 0, inXTemp, 0, inX.Length);
				inX = inXTemp;
			}		
			else{
				Array.Copy(inX, 0, inXTemp, 0, length);
				inX = inXTemp;
			}
		}		
		
		public static void ReDimInt(ref int[] inX, int length){
			/*(SES) method to redimension an array
			from http://www.dotnetspider.com/namespace/ShowClass.aspx?ClassId=7*/
			int[] inXTemp=new int[length];
			if (length > inX.Length){
				Array.Copy(inX, 0, inXTemp, 0, inX.Length);
				inX = inXTemp;
			}		
			else{
				Array.Copy(inX, 0, inXTemp, 0, length);
				inX = inXTemp;
			}
		}	
	
		public void LOESSAnalysis(int inPolynomialOrder, double LOESSSpan, 
		                          double[] inX, double[] inY, ref double[] Ybar, 
		                          ref double[] Xbar, ref double[] N, ref double[] Sigma,
		                          ref double[,] Coefficients, ref double[,] SECoefficients){
			/* (SES) This program first calls the SortData program to sort the data. 
			 * Next, the data is broken up into intervals, and a polynomial fit is devised 
			 * of the order defined be inPolynomialOrder for the interval.
			 * The mean is identified, along with the slope at the mean, associated errors,
			 * along with all of the polynomial coefficients and their associated errors.
			 * inX and inY are the data input arrays.  
			 * LOESSSpan is the x width of the interval considered for the LOESS analysis.
			 * Note: This program can only handle 5000 points per interval.  to ramp that 
			 *  number up, change the 5000 value on lines 91 and 92.*/
			int i = 0;
			int j, k, l, Count;
			int Flag = 0;
			double Xstart, Xend;
			double Rsquared = 0;
			double residualSumSquared = 0;
			double[] TempX = new double[0];
			double[] TempY = new double[0];
			double [] SEi= new double[inPolynomialOrder+1];
			double [,] Cout = new double[inPolynomialOrder+1,1];
				
			Array.Sort(inX, inY);
			//Get the data sorted in x ascending order)
			Count = inX.Length;
			Xstart = inX[0];
			Xend = Xstart + LOESSSpan;
			while (Flag == 0){
				k = 0;
				if (i >= Xbar.Length){ 
					//Checks to see if the interval is larger than the actual interval of the data
					//throw new ArgumentNullException();
				}
				Xbar[i] = (Xend + Xstart)/2;
				
				//Redimension Temp arrays to 5000 (max interval points = 5000)
				ReDim(ref TempX, 5000);
    			ReDim(ref TempY, 5000);
				for (j = 0; j < Count; j++){
					//Cycles through all x to pick out those within the interval
					if (inX[j] > Xstart && inX[j] <= Xend){
						//assigns the x and y in the interval into temporary arrays, and 
						//causes xbar to be zero (apperantly, gets rid of error)
						TempX[k] = inX[j]-Xbar[i];
						TempY[k] = inY[j];
						k=k+1;
					}
				}
    			ReDim(ref TempX, k);
    			ReDim(ref TempY, k);
    			//Redimension arrays TempX and Y to get rid of zeros
    			
				Polynomial LOESSPoly = new Polynomial();
				LOESSPoly.PolynomialFit(inPolynomialOrder, TempX, TempY, ref Cout, 
				                        ref SEi, ref Rsquared, ref residualSumSquared);
				Ybar[i] = LOESSPoly.EvaluatePolynomial(0, Cout);
				//Should be the same as a0 because xbar is scaled to be zero
				N[i] = TempX.Length;
				double temp = (residualSumSquared/(N[i]-(inPolynomialOrder+1)));
				Sigma[i] = Math.Pow(temp,0.5);
				for (l=0; l < inPolynomialOrder + 1; l++){
					Coefficients[i,l] = Cout[l,0];
					SECoefficients[i,l] = SEi[l];
				}
				i=i+1;
				Xstart = Xstart+LOESSSpan/2;
				Xend = Xstart + LOESSSpan;
				if (Xend >= inX[Count-1]){
					Flag = 1;
					//This cuts off the last incomplete interval
				}
			}
			
			
		}
	}
}
