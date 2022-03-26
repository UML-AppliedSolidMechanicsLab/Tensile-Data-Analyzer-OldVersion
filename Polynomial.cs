/*
 * Created by SharpDevelop.
 * User: e15564
 * Date: 6/13/2007
 * Time: 12:31 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;


namespace StressStrainData
{
	/// <summary>
	/// Description of Polynomial.
	/// </summary>
	public class Polynomial
	{
		public double EvaluatePolynomial(double inX, double[,] inC){
    		int I;
    		int PolynomialOrder;
    		double evaluatePolynomial = 0;
    		PolynomialOrder = inC.GetUpperBound(0);
    		for (I = 0; I < PolynomialOrder+1; I++){
    			evaluatePolynomial = evaluatePolynomial + inC[I, 0] * Math.Pow(inX,I);
    		}
    		return evaluatePolynomial;
		}
        
        ///<summary>
        ///Fits the data to a polynomial of a given order
        /// </summary>
        /// <param name="inPolynomialOrder">can be any integer (best to keep it under 10, get bad stuff after).</param>
        /// <param name="inX">arrays containing the data points</param>
        /// <param name="inY">arrays containing the data points</param>
        /// <param name="Cout">contains polynomial coefficients</param>
        /// <param name="SEi">standard errors on coefficients</param>
        /// <param name="Rsquared">correlation coefficient</param>
        /// <param name="residualSumSquared">residuals and Residual Sum of Squares</param>
        /// <exception cref="AccessViolationException">If the order is higher than the amount of data</exception>
        public void PolynomialFit(int inPolynomialOrder, double[] inX, double[] inY, 
		                          ref double[,] Cout,  ref double[] SEi,
		                          ref double Rsquared, ref double residualSumSquared){
				
    		int I;
    		int j;
    		int k;
    		long inCount = inX.Length;
    		double residual;
    		double Ybar = 0;
    		double SEySquared; 
    		double VarYaboutMean;
    		double SSyy = 0;      //Total Sum of Squares
    		double[,] a = new double[inPolynomialOrder+1, inPolynomialOrder+1];
    		double[,] b = new double[inPolynomialOrder+1, 1];
    		double[,] Aout = new double[inPolynomialOrder+1, inPolynomialOrder+1];
    		
    		if (inX.Length <= inPolynomialOrder){
				//Checks to see if the interval is larger than the actual interval of the data
				throw new AccessViolationException();
			}
    		
    		for (I = 0; I < inPolynomialOrder+1; I++){
    			for (j = 0; j < inPolynomialOrder+1; j++){
    				a[I, j] = 0;
    			}
    			b[I, 0] = 0;
    		}
    		//build coefficient matricies:
    		for (I = 0; I < inPolynomialOrder+1; I++){
    			for (j = 0; j < inPolynomialOrder+1; j++){
    				for (k = 0; k < inCount; k++){
    					a[I, j] = a[I, j] + Math.Pow(inX[k], (j + I ));
    				}
    			}
    			for (k = 0; k < inCount; k++){
    				b[I, 0] = b[I, 0] + inY[k] * Math.Pow(inX[k], (I));
    			}
    		}
    		//invert coefficient matrix:
    		MatrixMath mymath = new MatrixMath();
    		Aout = mymath.InvertMatrix(a, Aout, inPolynomialOrder + 1, inPolynomialOrder + 1);
    		//multiply by input vector to get polynomial coefficients:
    		Cout = mymath.MatrixMultiply(Cout, Aout, b, inPolynomialOrder + 1, 
    		                           inPolynomialOrder + 1, inPolynomialOrder + 1, 1);
    		
    		//calculate residuals and Residual Sum of Squares    		
    		for (I = 0; I < inCount; I++){
    			residual = EvaluatePolynomial(inX[I], Cout) - inY[I]; 
    			residualSumSquared = residualSumSquared + Math.Pow(residual, 2);
        		Ybar = Ybar + inY[I];
    		}  		
    		Ybar = Ybar / inCount; 
    		// calculate standard errors on coefficients: 
    		SEySquared = residualSumSquared / ((inX.Length) - (inPolynomialOrder + 1));
    		for (I = 0; I < inPolynomialOrder+1; I++ ){
    			double temp = Math.Abs(Aout[I, I]);
    			SEi[I] = Math.Pow(SEySquared *temp , 0.5); //absolute value required for negative Aout...???
			}
    		//calculate the total sum of squares:
    		for (I = 0; I <inCount; I++){
    			VarYaboutMean = inY[I] - Ybar;
    			SSyy = SSyy + Math.Pow(VarYaboutMean, 2);
    		}
    		//calculate correlation coefficient:
    		Rsquared = 1 - residualSumSquared / SSyy;
    		
		}
		
	}
}
