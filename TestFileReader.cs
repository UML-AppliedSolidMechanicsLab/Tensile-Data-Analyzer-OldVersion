/*
 * Created by SharpDevelop.
 * User: e46221
 * Date: 7/11/2007
 * Time: 3:40 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
 
using System;
using NUnit.Framework;


namespace StressStrainData
{
	[TestFixture]
	public class TestFileReader
	{
		[Test]
		public void TestMethod()
		{
			//Test only works if the StressStrainData is in the D drive!!!
			string root = "D:\\C# Projects\\StressStrainData\\TestCases\\FileReaderTest";
			int tranChan = 2;
			int axChan = 2;
			double length = 1;
			double xSecArea = 1;
			int startRow = 3;
			double acceptablePrecision = 1.0E-9;
			FileReader myrawData = new FileReader(root, axChan, tranChan, length, xSecArea, startRow,  1000, 1, 0, 0);
			
			Assert.AreEqual( 303.933562, myrawData.RawData[0,0] ,acceptablePrecision);
			
			
			//Additional plotting function to visually see that data is being read properly
			/*double [] inX1 = new double [rawData[0].RawData.GetUpperBound(0)+1];
			double [] inY1 = new double [rawData[0].RawData.GetUpperBound(0)+1];
			double [] inX2 = new double [rawData[0].RawData.GetUpperBound(0)+1];
			double [] inX3 = new double [rawData[0].RawData.GetUpperBound(0)+1];
			double [] inX4 = new double [rawData[0].RawData.GetUpperBound(0)+1];
			double [] inY2 = new double [rawData[0].RawData.GetUpperBound(0)+1];
			double [] inY3 = new double [rawData[0].RawData.GetUpperBound(0)+1];
			double [] inY4 = new double [rawData[0].RawData.GetUpperBound(0)+1];
			
			 * for (i = 0; i < myrawData[0].RawData.GetUpperBound(0)+1; i++){
				inY1[i] = myrawData[0].RawData[i,0];
				inX1[i] = myrawData[0].RawData[i,1];
				inX2[i] = myrawData[0].RawData[i,2];
				inX3[i] = myrawData[0].RawData[i,3];
				inX4[i] = myrawData[0].RawData[i,4];
			}
			inY2 = inY1;
			inY3 = inY1;
			inY4 = inY1;
							
			Plot4 pl2= new Plot4(inX1, inY1, inX2, inY2, inX3, inY3, inX4, inY4,
			                     "test", "strain (microstrain)", "stress (psi)", "ax1","ax2","ax3","ax4");
		*/
		}
	}
}
