/*
 * Created by SharpDevelop.
 * User: e46221
 * Date: 8/6/2007
 * Time: 1:37 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.IO;



namespace StressStrainData
{
	/// <summary>
	/// Description of Offset.
	/// </summary>
	public class Offset
	{
		private double percentOffset;
		private double rMin;
		private double yieldStress;
		private double yieldStrain;
		private double [,] Cout_Linear;
		private double[,] Cout_YieldOffset;
		private double offsetflag;
		private	double strainOffset;
		
		/// <summary>
		/// SES: This program executes whether the user has selected to calculate the offset or not, but it returns
		/// right off the bat if the user did not check the offset box.It takes all of the combined data 
		/// mean points, and fits a line to the points.It starts out with just the first point in the mean
		/// data set, and adds points one by one, checking to make sure that the R^2 value is above the specified
		/// value.  This is to isolate the data that is sufficiently linear.  Once all of the data points which
		/// give a linear fit with an R^2 value higher than the user input, rMin, this line is adjusted in the
		/// x-direction by the offset (note: had to convert the % offset to microstrain).  Then, the intersection
		/// is found between the global polynomial fit and the offset line.This intersection gives the offset
		/// yield stress and strain.  If the offset intersection cannot be found, an exception is thrown,
		/// and caught in the main section.
		/// </summary>
		/// <param name="inputX"></param>
		/// <param name="inputY"></param>
		/// <param name="offsetArray"></param>
		/// <exception cref="AppDomainUnloadedException"></exception>
		public Offset(double [] inputX, double [] inputY, double [] offsetArray)
		{
			
			percentOffset = offsetArray[1];
			rMin = offsetArray[2];
			offsetflag = offsetArray[0];
			
			//Initiate variables for the Polynomial Method
			int i,j;
			int polyOrder = 1;
    		Polynomial myPoly = new Polynomial();
    		double [] SEi= new double[polyOrder+1];
			double residualSumSquared=0;
			double Rsquared=1;
			Cout_Linear = new double[polyOrder+1,1];
			double [] Covariancediag = new double [polyOrder+1];
			double [] inX = new double[1];
			double [] inY = new double[1];
			
			//Check each mean point to see if the R2 value is high enough to be the linear region
			for (i = 1; i < inputX.Length; i++){
				if (Rsquared >= rMin){
					LOESS.ReDim(ref inX, i+1);
					LOESS.ReDim(ref inY, i+1);
					for (j = 0; j < i+1; j++){
						inX[j] = inputX[j];
						inY[j] = inputY[j];
					}
					myPoly.PolynomialFit(polyOrder,inX,inY, ref Cout_Linear, ref SEi, ref Rsquared, ref residualSumSquared);
				}
			}

			strainOffset = -1.0 * Cout_Linear[0,0] / Cout_Linear[1,0];

			//Copy the entire array
			Cout_YieldOffset = new double[Cout_Linear.GetLength(0), Cout_Linear.GetLength(1)];
            for (int i1 = 0; i1 < Cout_Linear.GetLength(0); i1++)
            {
                for (int j1 = 0; j1 < Cout_Linear.GetLength(1); j1++)
                {
					Cout_YieldOffset[i1,j1] = Cout_Linear[i1,j1];
                }
            }

			//Now, apply the offset to the Cout_linear
			Cout_Linear[0, 0] -= Cout_Linear[0, 0] * strainOffset;

			Cout_YieldOffset[0,0] = Cout_YieldOffset[0,0] - Cout_YieldOffset[1,0]*percentOffset/100;

			//stops executing if the yield stress check box wasn't checked
			if (offsetArray[0] == 0)
			{
				return;
			}

			//Now run through the polynomial until the difference between the polyfit and the linear offset is negative
			for (j = 0; j < inputX.Length; j++)
			{
				double tempY = myPoly.EvaluatePolynomial(inputX[j], Cout_YieldOffset);

				//If the polynomial line crosses the data line
                if (tempY > inputY[j] && j > 0)
                {
					yieldStress = inputY[j-1];
					yieldStrain = inputX[j-1] - strainOffset;
					return;
                }
				//If the polynomial starts below the data (if the fit is to the left of the data at the getgo)
				else if(tempY > inputY[j])
                {
					throw new AppDomainUnloadedException();
				}
			}
			//returns AppDomainUnloadedException if it doesn't find the interception, so that it can be identified at a higher level
			throw new AppDomainUnloadedException();
		}

	//Accessors (so that I can get to them from Analyze and MainForm
		public double YieldStrain{
			get{return yieldStrain;}
		}
		public double YieldStress{
			get{return yieldStress;}
		}
		public double PercentOffset{
			get{return percentOffset;}
		}
		public double RMin{
			get{return rMin;}
		}
		public double [,] COut_Linear{
			get{return Cout_Linear;}
		}
		public double[,] COut_YieldOffset
		{
			get { return Cout_YieldOffset; }
		}
		public double OffsetFlag{
			get{return offsetflag;}
		}
		public double StrainOffset {
			get { return strainOffset; }
		}
	}
}
