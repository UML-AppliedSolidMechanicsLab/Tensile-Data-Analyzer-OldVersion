/*
 * Created by SharpDevelop.
 * User: e46221
 * Date: 7/12/2007
 * Time: 10:53 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace StressStrainData
{
	/// <summary>
	/// Description of Combiner.
	/// </summary>
	public class Combination
	{
		
		private double [,] meanData;
		private double [] secantSlope;
		private double [] seSecantSlope;
		private double [] sigma;
		private double [] n;
		private double [,] coefficients;
		private double [,] seCoefficients;
		private double [] finalCoefficients;
		private double [] finalSECoefficients;
		private double [,] Cout;
		private double rSquared;
		
		public Combination(double [,] inData, int locPolyOrder, int globPolyOrder, double interval)
		{
			//This class takes in the combined data, desired polynomial order (local and global), 
			//and loess interval, and puts it through the loess program to get a set of mean
			// points (x and y), along with errors for the coefficentof the polynomial for for each interval
			
			int i;
			double [] inX = new double[inData.GetUpperBound(0)+1];
    		double [] inY = new double[inData.GetUpperBound(0)+1];
    		for (i = 0; i < inData.GetUpperBound(0)+1; i++){
				inY[i] = inData[i,0];
				inX[i] = inData[i,1];
    		}
    		Array.Sort(inX, inY);
    		double dNumberofIntervals = (Math.Floor(2*(inX[inX.Length-1] - inX[0])/(interval))) - 1;
    		int NumberofIntervals = System.Convert.ToInt16(dNumberofIntervals);
    		double [] Ybar = new double [NumberofIntervals];
    		sigma = new double [NumberofIntervals];
    		double [] Xbar = new double [NumberofIntervals];
    		n = new double [NumberofIntervals];
    		coefficients = new double [NumberofIntervals, locPolyOrder+1];
    		seCoefficients = new double [NumberofIntervals, locPolyOrder+1];
    		
    		LOESS myLOESS = new LOESS();
			myLOESS.LOESSAnalysis(locPolyOrder, interval, inX, inY, ref Ybar,
    		                      ref Xbar, ref n, ref sigma, ref coefficients, ref seCoefficients);
    		
    		//find the secant modulus for each point
    		secantSlope = new double [Xbar.Length];
    		seSecantSlope = new double [Xbar.Length];
    		meanData = new double [Xbar.Length,2];
    		for (i = 0; i < Xbar.Length; i++){
    			secantSlope[i] = Ybar[i]/Xbar[i];
    			meanData[i,0] = Ybar[i];
    			meanData[i,1] = Xbar[i];
    			seSecantSlope[i] = seCoefficients[i,0]/Xbar[i];
    		}
    		
    		//Now fit a polynomial to all of the LOESS points
    		Polynomial myPoly = new Polynomial();
    		double [] SEi= new double[globPolyOrder+1];
			rSquared=0;
			double residualSumSquared = 0;
			Cout = new double[globPolyOrder+1,1];
					
    		myPoly.PolynomialFit(globPolyOrder,Xbar,Ybar, ref Cout,ref SEi,ref rSquared, ref residualSumSquared);
			finalCoefficients = new double [globPolyOrder+1];
			finalSECoefficients = new double [globPolyOrder+1];
			finalSECoefficients = SEi;
			for (i = 0; i < globPolyOrder + 1; i++){
				finalCoefficients[i] = Cout[i,0];
			}
		}
		public double[,] MeanData{
			get{return meanData;}
		}
		public double [] SecantSlope{
			get{return secantSlope;}
		}
		public double [] SESecantSlope{
			get{return seSecantSlope;}
		}
		public double [] Sigma{
			get{return sigma;}
		}
		public double [] N{
			get{return n;}
		}
		public double[,] Coefficients{
			get{return coefficients;}
		}
		public double[,] SECoefficients{
			get{return seCoefficients;}
		}
		public double[] FinalCoefficients{
			get{return finalCoefficients;}
		}
		public double[] FinalSECoefficients{
			get{return finalSECoefficients;}
		}
		public double[,] FinalCout{
			get{return Cout;}
		}
		public double RSquared{
			get{return rSquared;}
		}
	}
}
