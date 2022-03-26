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
		private double [,] Cout;
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
			Cout = new double[polyOrder+1,1];
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
					myPoly.PolynomialFit(polyOrder,inX,inY, ref Cout,ref SEi, ref Rsquared, ref residualSumSquared);
				}
			}

			strainOffset = Cout[0,0];

			//stops executing if the yield stress check box wasn't checked
			if (offsetArray[0] == 0)
			{
				return;
			}

			yieldStress = inY[inY.Length-1];
			Cout[0,0] = Cout[0,0] - Cout[1,0]*percentOffset/100;
			
			//Now run through the polynomial until the difference between the polyfit and the linear offset is negative
			double tempX = 0;
			double tempY = 0;
			int flag = 0;
			int noRootFlag = 0;
			int rootToTheRight = 0;
			double stepsize = inX[inX.Length-1] * 0.25;  //starting out stepsize
			double acceptablePrecision = .001; //make this smaller for a more precise intersect estimation.
			
			while (flag == 0){
				if (noRootFlag == 1000){ //returns AppDomainUnloadedException if it doesn't find the interception, so that it can be identified at a higher level
					throw new AppDomainUnloadedException();
				}
				tempY = myPoly.EvaluatePolynomial(tempX, Cout);
				if (tempY >= 0.0){
					if ((Math.Abs(tempY/yieldStress)) <= acceptablePrecision){
					    	flag = 1;
					}
					else {
						if (rootToTheRight == 1000)
							throw new AppDomainUnloadedException();
						tempX = tempX - stepsize;
						stepsize = stepsize/2;
						rootToTheRight = rootToTheRight + 1;
						//resets tempX to before the sign change, and decreases the step size to hone in on the root
					}
				}	
				else 
					noRootFlag = noRootFlag + 1;
				tempX = tempX + stepsize;
			}
			
			yieldStrain = inX[inX.Length-1] - tempX;
			
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
		public double [,] COut{
			get{return Cout;}
		}
		public double OffsetFlag{
			get{return offsetflag;}
		}
		public double StrainOffset {
			get { return strainOffset; }
		}
	}
}
