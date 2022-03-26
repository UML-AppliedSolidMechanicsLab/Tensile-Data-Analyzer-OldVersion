/*
 * Created by SharpDevelop.
 * User: e15564
 * Date: 6/13/2007
 * Time: 12:31 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using NUnit.Framework;
using System;

namespace StressStrainData
{
	[TestFixture]
	public class TestPolynomial{
		private double demoDouble;
		[Test]
		public void TestFirstOrder(){
			Polynomial myPoly = new Polynomial();
			demoDouble = 4.5;
			int myinPolynomialOrder = 1;
			double [] SEi= new double[myinPolynomialOrder+1];
			double Rsquared=0;
			double residualSumSquared = 0;
			double [] myX = new double[] {1,2,3,4,5,6,7,8,9,10,11,12,13};
    		double [] myY = new double[] {1,4,6,7,8,9,9,8.5,8,7,6,4,2};
    		double [,] Cout = new double[myinPolynomialOrder+1,1];
			double acceptablePrecision = 1.0E-8;
					
    		myPoly.PolynomialFit(myinPolynomialOrder,myX,myY, ref Cout,ref SEi,ref Rsquared,ref residualSumSquared);
    		
    		Console.WriteLine("Inside TestFirstOrder, double = " + Cout);
    		Console.ReadLine();
    		
    		Assert.AreEqual(5.903846154,Cout[0,0],acceptablePrecision);
    		Assert.AreEqual(.03021978,Cout[1,0],acceptablePrecision);
			Assert.AreEqual(0.20350416,SEi[1],acceptablePrecision);
			Assert.AreEqual(.00200066138,Rsquared,acceptablePrecision);

			Console.WriteLine("Inside TestFirstOrder, double = " + demoDouble);
		}
		[Test]
		public void TestSixthOrder(){
			Polynomial myPoly = new Polynomial();
			demoDouble = 4.5;
			int myinPolynomialOrder = 6;
			double [] SEi= new double[myinPolynomialOrder+1];
			double Rsquared=0;
			double residualSumSquared = 0;
			double [] myX = new double[] {1,2,3,4,5,6,7,8,9,10,11,12,13};
    		double [] myY = new double[] {1,4,6,7,8,9,9,8.5,8,7,6,4,2};
    		double [,] Cout = new double[myinPolynomialOrder+1,1];
			double acceptablePrecision = 1.0E-7;
					
    		myPoly.PolynomialFit(myinPolynomialOrder,myX,myY, ref Cout,ref SEi,ref Rsquared,ref residualSumSquared);
    		
    		Console.WriteLine("Inside TestFirstOrder, double = " + Cout);
    		Console.ReadLine();
    		
    		Assert.AreEqual(-4.437062937,Cout[0,0],acceptablePrecision);
    		Assert.AreEqual(7.306886921,Cout[1,0],acceptablePrecision);
			Assert.AreEqual(.996792617,Rsquared,acceptablePrecision);
			Assert.AreEqual(0.00227394457177355,SEi[5],acceptablePrecision);
			Console.WriteLine("Inside TestSixthOrder");
		}
		
		[Test]
		public void TestFifthOrder(){
			// Tested using JWST Material model output data
			// Exx vs Temperature data for November, 2006 1002 laminate
			Polynomial myPoly = new Polynomial();
			int myinPolynomialOrder = 5;
			double [] SEi= new double[myinPolynomialOrder+1];
			double Rsquared=0;
    		double residualSumSquared = 0;
			double [] myX = new double[] {260.33,251.33,242.33,233.33,224.33,
					215.33,206.33,197.33,188.33,179.33,170.33,
					161.33,152.33,143.33,134.33,125.33,116.33,107.33,98.33};
    		double [] myY = new double[] {15.24638966,15.2688002,15.29196488,15.31503065,15.3379856,
					15.36081747,15.38351362,15.40605765,15.4284222,15.45058239,15.47251696,
					15.49422714,15.51578589,15.53726162,15.55870406,15.58013682,15.60152629,
					15.62283219,15.64402044};
    		double [,] Cout = new double[myinPolynomialOrder+1,1];
			double acceptablePrecision = 1.0E-6;
					
    		myPoly.PolynomialFit(myinPolynomialOrder,myX,myY, ref Cout,ref SEi,ref Rsquared,ref residualSumSquared);
    		
    		Assert.AreEqual(15.8325392082099,Cout[0,0],acceptablePrecision);
    		Assert.AreEqual(-0.000829009595370651,Cout[1,0],acceptablePrecision);
    		Assert.AreEqual(-0.0000211178893158273,Cout[2,0],acceptablePrecision);
    		Assert.AreEqual(1.42960409957493E-07,Cout[3,0],acceptablePrecision);
    		Assert.AreEqual(-4.72303023886292E-10,Cout[4,0],acceptablePrecision);
    		Assert.AreEqual(5.91985333719542E-13,Cout[5,0],acceptablePrecision);
			Assert.AreEqual(1,Rsquared,acceptablePrecision);
			Assert.AreEqual(0.0159080954177883,SEi[0],acceptablePrecision);
			Assert.AreEqual(0.000489802409584621,SEi[1],acceptablePrecision/100.0);
			Assert.AreEqual(5.87043859202147E-06,SEi[2],acceptablePrecision/1000.0);
			Assert.AreEqual(3.42784450196364E-08,SEi[3],acceptablePrecision/1000.0);
			Assert.AreEqual(9.76660955366963E-11,SEi[4],acceptablePrecision/1000.0);
			Assert.AreEqual(1.08807117377148E-13,SEi[5],acceptablePrecision/1000.0);
		}
	}
}
