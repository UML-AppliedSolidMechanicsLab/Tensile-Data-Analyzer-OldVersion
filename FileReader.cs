/*
 * Created by SharpDevelop.
 * User: e46221
 * Date: 7/10/2007
 * Time: 12:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using System.Xml;
using System.IO;
	
namespace StressStrainData
{
	
	public class FileReader
	{
		private string root;
		private double [,] dataArray;
		private int tranChan, axChan, rowStart, rowEnd, stressCol, strainCol, dispflag;
		private double length, xSecArea;
		
 		public FileReader(string inroot, int inaxChan, int intranChan,	 
		                  double inlength, double inxSecArea, int inrowStart, int inrowEnd, int inStrainCol, int inStressCol, int indispflag){
			/*FileReader takes in user input data and writes it to a large array.
			 * inroot is the root directory of the file being considered, intranChan and inaxTran are the number
			 * of axial and transverse strain channels, inlength and inxSecArea are the specimen length and 
			 * cross-sectional area, inrowStart is the starting row to read from, and indispflag is 1 if the axial
			 * is reported in displacement rather than strain.  The program reads the file from root, and puts 
			 * the data in an array.  just in case the data is in force and displacement, these terms are 
			 * divided by the length and area to get stress and strain.  The length and area are set at 1 
			 * if the values are already in stress and strain, thereby not changing the values.  The array 
			 * returns has columns containing: 1; stress, 2 to 2 + axChan of axial strain, and 3+axChan to
			 *  3+axChan+tranChan of transverse strain.*/
			
			root = inroot;
			tranChan = intranChan;
			axChan = inaxChan;
			length = inlength;
			xSecArea = inxSecArea;
			rowStart = inrowStart;
			dispflag = indispflag;
			rowEnd = inrowEnd;
			stressCol = inStressCol;
			strainCol = inStrainCol;
			
			int columnCount = 1 + tranChan + axChan;
			int i,j, counter;
            string line = "Initiate";
            string[] temp = new string[columnCount];
            int rowCount = 0;
            
            List<double> list = new List<double>();

            // Read the file line by line. (3 to initialize because there are 2 rows of labels)
           	System.IO.StreamReader file = new System.IO.StreamReader(root + ".csv");
          
            //this section just reads the lines prior to the start of the data
            for (i = 0; i < rowStart; i++){
            	line = file.ReadLine();
            }
            
            counter = 0;
            while ((line != "" && line != null) && (counter <= (rowEnd-rowStart))) {
                temp = line.Split(new char[] { ',' });
                counter++;
                list.Add(Convert.ToDouble(temp[stressCol-1]));
                
                for(i = 0;i < (columnCount-1); i++){
                	list.Add(Convert.ToDouble(temp[i + (strainCol-1)]));
                }
                rowCount++;
                line = file.ReadLine();
            }
            
            //object[] arrayListChange = list.ToArray();
            dataArray = new double[rowCount,columnCount];
            
            for(i = 0;i < rowCount; i++){
            	for(j = 0; j < columnCount; j++){
                	dataArray[i,j] = list[columnCount*i+j];
                }
            }
           
            //divides to get stress and strain
            for(i = 0;i < rowCount; i++){
            	dataArray[i,0] = dataArray[i,0]/xSecArea;
            	
            	for (j = 0; j < axChan; j++){
            		dataArray[i,1 + j] = (dataArray[i,1 + j])/length;
            		if (dispflag == 1)  //Convert to microstrain if displacement rather than strain
            			dataArray[i,1 + j] = (dataArray[i,1 + j])*1000000; 
				}
            	//make transverse strain positive
            	if (tranChan != 0){
            		for (j = 0; j < tranChan; j++){
            			dataArray[i,1+axChan+j] = -1*dataArray[i,1+axChan+j];
            		}
            	}
            }
        }
		//Accessors (so that I can get to them from Analyze and MainForm
		public double[,] RawData{
			get{return dataArray;}
		}
		public string Root{
			get{return root;}
		}
		public int TranChan{
			get{return tranChan;}
		}
		public int AxChan{
			get{return axChan;}
		}
		public double Length{
			get{return length;}
		}
		public double XSecArea{
			get{return xSecArea;}
		}
		
	}
}

