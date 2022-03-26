/*
 * Created by SharpDevelop.
 * User: e46221
 * Date: 6/18/2007
 * Time: 12:58 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using NUnit.Framework;
using System;

namespace StressStrainData
{
	[TestFixture]
	public class TestLOESS
	{
		
		[Test]
		public void TestLOESSAnalysis()
		{

			double [] inX = new double[] {1,2,3,4,5,6,7,8,9,10,11,12,13};
    		double [] inY = new double[] {1,4,6,7,8,9,9,8.5,8,7,6,4,2};
    		double acceptablePrecision = 1.0E-9;
    		int inPolynomialOrder = 1;
    		double LOESSSpan = 3;
    		double dNumberofIntervals = (Math.Floor(2*(inX[inX.Length-1] - inX[0])/(LOESSSpan))) - 1;
    		int NumberofIntervals = System.Convert.ToInt16(dNumberofIntervals);
    		double [] Ybar = new double [NumberofIntervals];
    		double [] Sigma = new double [NumberofIntervals];
    		double [] Xbar = new double [NumberofIntervals];
    		double [] N = new double [NumberofIntervals];
    		double [,] Coefficients = new double [NumberofIntervals, inPolynomialOrder+1];
    		double [,] SECoefficients = new double [NumberofIntervals, inPolynomialOrder+1];
    		
    		LOESS myLOESS = new LOESS();
			myLOESS.LOESSAnalysis(inPolynomialOrder, LOESSSpan, inX, inY, ref Ybar,
    		                      ref Xbar, ref N, ref Sigma, ref Coefficients, ref SECoefficients);
			
			Assert.AreEqual(4.916666666667, Ybar[0] ,acceptablePrecision);
			Assert.AreEqual(8.833333333333333, Ybar[3] ,acceptablePrecision);
		}
	}
}
