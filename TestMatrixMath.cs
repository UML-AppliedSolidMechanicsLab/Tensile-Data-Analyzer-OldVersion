/*
 * Created by SharpDevelop.
 * User: e46221
 * Date: 6/13/2007
 * Time: 2:42 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using NUnit.Framework;
using System;

namespace StressStrainData
{
	    [TestFixture]
    public class testMath{
    	MatrixMath myMath = new MatrixMath();
    	double[,] coeffs = new double[3,3];
    	double[] multMatrix = new double[3];
    	
    	double[,] myA = new double[3,3];
    	double[,] myB = new double[3,1];
    	int myn;
    	int myC;
    	[Test] public void testGauss(){
    		myn = 3;
    		myC = 0;
    		myA[0,0] = 1.0;
    		myA[0,1] = 5.0;
    		myA[0,2] = 2.0; 
    		myA[1,0] = 5.0;
    		myA[1,1] = 2.0;
    		myA[1,2] = 4.0;
    		myA[2,0] = 3.0;
    		myA[2,1] = 2.0;
    		myA[2,2] = 3.0;
    		
    		myB[0,0] = 5.0;
    		myB[1,0] = 4.0;
    		myB[2,0] = 7.0;
    		myMath.gauss(myA, myB, myn, myC);
    		double acceptablePrecision = 0.000000000001;
    		Assert.AreEqual( -6.44444444444444,myB[0,0], acceptablePrecision);
    		Assert.AreEqual( -1.66666666666667,myB[1,0], acceptablePrecision);
    		Assert.AreEqual( 9.88888888888889,myB[2,0], acceptablePrecision);
    	}
    	[Test] public void testMatrixMultiplication(){
    		double [,] myA = new double[2,2];
    		double [,] myB = new double[2,2];
    		double [,] myC = new double[2,2];
			double acceptablePrecision = 1.0E-9;
			
    		myA[0,0] = 0.5;
    		myA[0,1] = 0.25;
    		myA[1,0] = 0.75;
    		myA[1,1] = 0.5;
    		
    		myB[0,0] = 0.25;
    		myB[0,1] = 0.75;
    		myB[1,0] = 0.5;
    		myB[1,1] = 0.5;
    		
    		myC = myMath.MatrixMultiply(myC,myA,myB,2,2,2,2);
    		
    		Assert.AreEqual(0.25,myC[0,0],acceptablePrecision);
      		Assert.AreEqual(0.5,myC[0,1],acceptablePrecision);
    		Assert.AreEqual(0.4375,myC[1,0],acceptablePrecision);
    		Assert.AreEqual(0.8125,myC[1,1],acceptablePrecision);
    	}
    	
    	[Test] public void testInvertMatrix(){
    		double [,] myA = new double[3,3];
    		double [,] myC = new double[3,3];
			double acceptablePrecision = 1.0E-9;
			
			myA[0,0] = 0.5;
    		myA[0,1] = 0.25;
    		myA[0,2] = 2.0; 
    		myA[1,0] = 5.0;
    		myA[1,1] = 2.0;
    		myA[1,2] = 4.0;
    		myA[2,0] = 3.0;
    		myA[2,1] = 2.0;
    		myA[2,2] = 3.0;
    		
    		myC = myMath.InvertMatrix(myA,myC,3,3);
    		
			Assert.AreEqual(-0.32,myC[0,0],acceptablePrecision);
      		Assert.AreEqual(0.52,myC[0,1],acceptablePrecision);
    		Assert.AreEqual(-0.48,myC[0,2],acceptablePrecision);
    		Assert.AreEqual(-0.48,myC[1,0],acceptablePrecision);
    		Assert.AreEqual(-0.72,myC[1,1],acceptablePrecision);
      		Assert.AreEqual(1.28,myC[1,2],acceptablePrecision);
    		Assert.AreEqual(0.64,myC[2,0],acceptablePrecision);
    		Assert.AreEqual(-0.04,myC[2,1],acceptablePrecision);
    		Assert.AreEqual(-0.04,myC[2,2],acceptablePrecision);
    	}
	}
}
