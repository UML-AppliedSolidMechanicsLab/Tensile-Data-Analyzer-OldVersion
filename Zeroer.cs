/*
 * Created by SharpDevelop.
 * User: e46221
 * Date: 7/12/2007
 * Time: 8:49 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Windows.Forms;
using System.IO;

namespace StressStrainData
{
	/// <summary>
	///This class takes in the averaged data, desired polynomial order, and loess interval, and puts it through
	///the loess program to get a set of mean points (x and y), and then it fits a polynomial to these mean points.
	///After that, the root is found to shift all of the data in the x (strainOffset) direction so that if the data continued
	///to zero load, zero strain would be measured.  The root is found by evaluating the polynomial starting at 0,
	///and working in the negative x direction until there is a sign change.  This might be just a numerical solution,
	///and not exact, but it should be pretty close.  The data is then shifted by this offset, cut off at the max
	///strain, and returned. x and y are the column #'s of the x in the data and the y in the data
	/// </summary>
	public class Zeroer
	{
		private double [,] zeroedData;
		//private double strainOffset;
		private double [,] meanData;
		private double [] secantSlope;
		private double [] seSecantSlope;
		private double [] sigma;
		private double [] n;
		private double [,] coefficients;
		private double [,] seCoefficients;
		private double [,] Cout;
		private Offset offsetData;
		
		public Zeroer(double [,] inData, int locPolyOrder, int globPolyOrder, double interval, double cutoff, int x, int y, double [] offsetArray){
			
			
			
			int i,j;
			double [] inX = new double[inData.GetUpperBound(0)+1];
			double [] inY = new double[inData.GetUpperBound(0)+1];
			for (i = 0; i < inData.GetUpperBound(0)+1; i++){
				inY[i] = inData[i,y];
				inX[i] = inData[i,x];
			}
			
			CutoffStrain(i, ref inX, ref inY, cutoff);
			
			#region Calculate Offset
			//Now find the offset 
			offsetData = new Offset(inX, inY, offsetArray);
			for (i = 0; i < inX.Length; i++){
				inX[i] = inX[i] - offsetData.StrainOffset;
			}
			#endregion
			
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
			
			//Now fit mean x and y to a polynomial
			Polynomial myPoly = new Polynomial();
			double [] SEi= new double[globPolyOrder+1];
			double residualSumSquared=0;
			double Rsquared=0;
			Cout = new double[globPolyOrder+1,1];
			
			myPoly.PolynomialFit(globPolyOrder,Xbar,Ybar, ref Cout,ref SEi,ref Rsquared,ref residualSumSquared);
			
			#region Now run through from the first Xbar back and evaluate the poly until the y is negative to zero it
			/*
			double tempX = Xbar[0];
			double tempY;
			int flag = 0;
			int noRootFlag = 0;
			int rootToTheRight = 0;
			double stepsize = cutoff/4.0;  //starting out stepsize
			double acceptablePrecision = .1; //make this smaller for a more precise root estimation.
			
			while (flag == 0){
				if (noRootFlag == 1000){ //returns FileNotFoundException if it doesn't find the root, so that it can be identified at a higher level
					File.OpenRead("purposefulException");
				}
				tempY = myPoly.EvaluatePolynomial(tempX, Cout);
				if (tempY <= 0){
					if ((Math.Abs(tempY)) <= acceptablePrecision){
						flag = 1;
						break;
					}
					else {
						if (rootToTheRight == 1000)
							Convert.ToInt32("purposefulException");
						tempX = tempX + stepsize;
						stepsize = stepsize/2;
						rootToTheRight = rootToTheRight + 1;
						//resets tempX to before the sign change, and decreases the step size to hone in on the root
					}
				}
				else
					noRootFlag = noRootFlag + 1;
				tempX = tempX - stepsize;
			}
			strainOffset = tempX;
			for (i = 0; i < inX.Length; i++){
				inX[i] = inX[i] - strainOffset;
			}
			*/
			#endregion 
			
			//find the secant modulus for each point
			secantSlope = new double [Xbar.Length];
			seSecantSlope = new double [Xbar.Length];
			meanData = new double [Xbar.Length,2];
			for (i = 0; i < Xbar.Length; i++){
				secantSlope[i] = Ybar[i]/(Xbar[i]);//-strainOffset);
				meanData[i,0] = Ybar[i];
				meanData[i,1] = Xbar[i];
				seSecantSlope[i] = seCoefficients[i,0]/(Xbar[i]);//-strainOffset);
			}

			//And save it to the zeroedData
			zeroedData = new double [inX.Length,2];
			for (j = 0; j < inX.Length; j++){
				zeroedData[j,0] = inY[j];
				zeroedData[j,1] = inX[j];
			}
		}

		#region private methods

		private void CutoffStrain(int i, ref double[] inX, ref double[] inY, double cutoff)
		{
			int flag = 0;
			i = 0;
			while (flag == 0) {
				if (inX[i] > cutoff) {
					Array.Clear(inX, i, inX.Length - i);
					Array.Clear(inY, i, inX.Length - i);
					flag = 1;
					i = i - 2;
				}
				i = i + 1;
				if (i > inX.Length - 1) {
					flag = 1;
					i = i - 1;
				}
			}
			
			LOESS.ReDim(ref inX, i + 1);
			LOESS.ReDim(ref inY, i + 1);
			Array.Sort(inX, inY);
		}
		#endregion
		
		//Accessors (so that I can get to them from Analyze and MainForm
		public double[,] ZeroedData{
			get{return zeroedData;}
		}
		/*public double StrainOffset{
			get{return strainOffset;}
		}*/
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
		public double[,] TotalCout{
			get{return Cout;}
		}
		public Offset OffsetData{
			get{return offsetData;}
		}
	}
}
