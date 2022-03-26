/*
 * Created by SharpDevelop.
 * User: e46221
 * Date: 7/10/2007
 * Time: 8:05 AM
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
using ZedGraph;

namespace StressStrainData
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form 
	{
		private int dispflag = 0;
		private int offsetflag = 0;
		private int numberofFiles = 0;
		private int numberofTranFiles = 0;
		private int stringIndex1, stringIndex2, i, j;
		private List<string[]> individualInputsList= new List<string[]>();
		private string[] groupInputsList;
		private Analyze analyze;
		private string [,] inputArray;
		private int fileNumber = 0;
		private string material;
		private string folder;
		private string temperature;
				
		[STAThread]
		public static void Main(string[] args){
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
		
		public MainForm(){
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			//
			// start out with an open dialog box.
			//
			
		}
		//individual file inputs Group
		void BrowseMouseClick(object sender, MouseEventArgs e){
			openFileTxt.Text = "";
			OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Select File To Read From";
            fdlg.Filter = "CSV Files (*.csv*)|*.csv*";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                
               
            }
            try{
            	openFileTxt.Text = fdlg.FileName;
                //This next set of messy code isolates the folder of the LAST file opened, so that the group
                //files can be saved there
                string splitline = "\\";
                stringIndex1 = openFileTxt.Text.LastIndexOf(splitline);
            	stringIndex2 = openFileTxt.Text.LastIndexOf("v");
            	folder = openFileTxt.Text.Remove(stringIndex1+1,stringIndex2-stringIndex1);
            	stringIndex1 = openFileTxt.Text.IndexOf(".");
            	stringIndex2 = openFileTxt.Text.LastIndexOf("v");
            	openFileTxt.Text = openFileTxt.Text.Remove(stringIndex1,stringIndex2-stringIndex1+1);
            	
            }        
            catch{
            	MessageBox.Show("Error: Try Again!");
            	inputGroupBox.Enabled = false;
            	return;
            }
            inputGroupBox.Visible = true;
            inputGroupBox.Enabled = true;
            previewBttn.Enabled = true;
            if (numberofFiles >= 1)
            	doneBttn.Enabled = true;
            addBttn.Enabled = false;
		}
		void TransCheckBox1CheckedChanged(object sender, EventArgs e){
			tranChanGroupBox.Visible = true;
		}
		void StressRadioBttn1CheckedChanged(object sender, EventArgs e){
			areaGroupBox.Visible = false;
			xSecAreaTxtBox.Text = "1";
		}
		void LoadRadioBttnCheckedChanged(object sender, EventArgs e){
			areaGroupBox.Visible = true;
			lengthTxtBox.Text = "1.1";			
		}
		void StrainRadioBttnCheckedChanged(object sender, EventArgs e){
			lengthGroupBox.Visible = false;
			lengthTxtBox.Text = "1";
			axChanGroupBox.Visible = true;
			dispflag = 0;
		}
		void DispRadioBttnCheckedChanged(object sender, EventArgs e){
			lengthGroupBox.Visible = true;
			axChanGroupBox.Visible = false;
			axChan.Text = "1";
			dispflag = 1;
		}
		void tranStrainRadioButtonCheckedChanged(object sender, EventArgs e){
			tranChanGroupBox.Visible = true;
			tranChan.Text = "1";
		}
		void NoStrainRadioButtonCheckedChanged(object sender, EventArgs e){
			tranChanGroupBox.Visible = false;
			tranChan.Text = "0";
		}
		void PreviewBttnClick(object sender, EventArgs e){
			//first, check to make sure inputs are of the proper form:
			try{
				Convert.ToDouble(xSecAreaTxtBox.Text);
				Convert.ToDouble(lengthTxtBox.Text);
				Convert.ToInt32(rowStartTxtBox.Text);
				Convert.ToInt32(rowEndTxtBox.Text);
				Convert.ToInt32(tbStrainCol.Text);
				Convert.ToInt32(tbStressCol.Text);
			}
			catch{
				MessageBox.Show("Invalid User Input:  Verify Values Are Correct");
				return;
			}
			try{
				PreSreening ps1 = new PreSreening(openFileTxt.Text, Convert.ToInt32(axChan.Text),
			                                  Convert.ToInt32(tranChan.Text),
			                                  Convert.ToDouble(lengthTxtBox.Text), 
			                                  Convert.ToDouble(xSecAreaTxtBox.Text), 
			                                  Convert.ToInt32(rowStartTxtBox.Text), Convert.ToInt32(rowEndTxtBox.Text),
				                               Convert.ToInt32(tbStrainCol.Text), Convert.ToInt32(tbStressCol.Text), dispflag);
			}
			catch(FormatException){
            	MessageBox.Show("Invalid Data Set: Verify all Data is numerical and starting row is correct.");
            	return;
            }
			catch(IndexOutOfRangeException){
				MessageBox.Show("There are less columns in the data than specified: Verify channels and starting row are correct");
				return;
			}
			catch{
				MessageBox.Show("Error: Try Again!");
				return;
			}
		}
		void AddCurrentBttnClick(object sender, EventArgs e)
		{
			//first, check to make sure that the inputs are the proper format
			try{
				Convert.ToDouble(xSecAreaTxtBox.Text);
				Convert.ToDouble(lengthTxtBox.Text);
				Convert.ToInt32(rowStartTxtBox.Text);
				Convert.ToInt32(rowEndTxtBox.Text);
				Convert.ToInt32(tbStrainCol.Text);
				Convert.ToInt32(tbStressCol.Text);
			}
			catch{
				MessageBox.Show("Invalid User Input:  Verify Values Are Correct");
				return;
			}
			
			//Checks to make sure that all data is numberical, and columns are correct
			try{
				FileReader fr = new FileReader(openFileTxt.Text, Convert.ToInt32(axChan.Text), 
				                               Convert.ToInt32(tranChan.Text),
				                               Convert.ToDouble(lengthTxtBox.Text),
				                               Convert.ToDouble(xSecAreaTxtBox.Text),
				                               Convert.ToInt32(rowStartTxtBox.Text), Convert.ToInt32(rowEndTxtBox.Text),
				                               Convert.ToInt32(tbStrainCol.Text), Convert.ToInt32(tbStressCol.Text), dispflag);
			 }
            catch(FormatException){
            	MessageBox.Show("Invalid Data Set: Verify all Data is numerical and starting row is correct.");
            	return;
            }
			catch(IndexOutOfRangeException){
				MessageBox.Show("There are less columns in the data than specified: Verify channels and starting row are correct");
				return;
			}
			catch{
				MessageBox.Show("Error: Try Again!");
				return;
			}
			//put the input in list form so that elements can be added as we go.
			//there will be a group of 6 elements for each file, then after the analyze button
			//is clicked, 6 more inputs for the whole group are stuck on the back of the list
			string [] indiv = new string[10];
			indiv[0] = (openFileTxt.Text);
			indiv[1] = (axChan.Text);
			indiv[2] = (tranChan.Text);
			indiv[3] = (lengthTxtBox.Text);
			indiv[4] = (xSecAreaTxtBox.Text);
			indiv[5] = (rowStartTxtBox.Text);
			indiv[6] = (rowEndTxtBox.Text);
			indiv[7] = (tbStrainCol.Text);
			indiv[8] = (tbStressCol.Text);
			indiv[9] = (dispflag.ToString());
			individualInputsList.Add(indiv);
			
			numberofFiles++;
			if ((Convert.ToInt16(tranChan.Text)) != 0)
				numberofTranFiles++;
			label10.Text = numberofFiles + " file(s) scanned";
			addCurrentBttn.Enabled = false;
			Browse.Enabled = false;
			label2.Enabled = false;
			openFileTxt.Enabled = false;
			doneBttn.Enabled = true;
			addBttn.Enabled = true;
			previewBttn.Enabled = false;
		}
		void AddBttnClick(object sender, EventArgs e){	
			//reset the Browse and openFile text box
			openFileTxt.Text = "";
			inputGroupBox.Enabled = false;
			addCurrentBttn.Enabled = true;
			Browse.Enabled = true;
			label2.Enabled = true;
			openFileTxt.Enabled = true;
			
			openFileTxt.Text = "";
			OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Select File To Read From";
            fdlg.Filter = "CSV Files (*.csv*)|*.csv*";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                openFileTxt.Text = fdlg.FileName;
                
            }
            try{
            	stringIndex1 = openFileTxt.Text.IndexOf(".");
            	stringIndex2 = openFileTxt.Text.LastIndexOf("v");
            	openFileTxt.Text = openFileTxt.Text.Remove(stringIndex1,stringIndex2-stringIndex1+1);
            }
            catch{
            	MessageBox.Show("Error in file name format");
            	inputGroupBox.Enabled = false;
            	return;
            }
            inputGroupBox.Visible = true;
            inputGroupBox.Enabled = true;
            previewBttn.Enabled = true;
            if (numberofFiles >= 1)
            	doneBttn.Enabled = true;
            addBttn.Enabled = false;
		}
		
		void DoneBttnClick(object sender, EventArgs e){
			groupInputsGroupBox.Visible = true;
			addBttn.Enabled = false;
			doneBttn.Enabled = false;
			Browse.Enabled = false;
			addCurrentBttn.Enabled = false;	
			inputGroupBox.Enabled = false;
			
		}
		//All files input Group
		void GlobPolyOrderTxtBxTextChanged(object sender, EventArgs e)
		{
			try
			{Convert.ToInt32(globPolyOrderTxtBx.Text);}
			catch{
				return;
				}
			
			if ((Convert.ToInt32(globPolyOrderTxtBx.Text)) == 1){
				offsetCheckBx.Enabled = false;
				offsetCheckBx.Checked = false;
			offsetGroupBx.Visible = false;}
			else{
				offsetCheckBx.Enabled = true;
			}
		}
		void OffsetCheckBxCheckedChanged(object sender, EventArgs e)
		{
			if (offsetCheckBx.Checked == true){
			offsetGroupBx.Visible = true;
			offsetflag = 1;
			YieldStressBttn.Enabled = true;
			}
			else{
				offsetGroupBx.Visible = false;
				YieldStressBttn.Enabled = false;
				offsetflag = 0;
			}
		}
		void AnalyzeBttnClick(object sender, EventArgs e){
			//first, check to make sure inputs are of the proper format
			try{
				Convert.ToDouble(axStrainCutoffTxtBox.Text);
				Convert.ToDouble(intervalTxtBox.Text);
				Convert.ToDouble(globPolyOrderTxtBx.Text);
				Convert.ToDouble(locPolyOrderTxtBx.Text);
				Convert.ToDouble(rMinTxtBx.Text);
				if (offsetflag == 1){
					Convert.ToDouble(offsetPercentTxtBx.Text);
				}
			}
			catch{
				MessageBox.Show("Invalid User Input:  Verify Values Are Correct");
				return;
			}
			
			//finish off inputlist by adding group inputs!!!
			material = materialTxtBox.Text;
			groupInputsList = new string[7];
			temperature = temperatureTxtBox.Text;
			
			
			groupInputsList[0] = (axStrainCutoffTxtBox.Text);
			groupInputsList[1] = (locPolyOrderTxtBx.Text);
			groupInputsList[2] = (globPolyOrderTxtBx.Text);
			groupInputsList[3] = (intervalTxtBox.Text);
			groupInputsList[4] = (temperatureTxtBox.Text);
			groupInputsList[5] = (numberofFiles.ToString());
			groupInputsList[6] = (numberofTranFiles.ToString());
			
			
			double [] offsetArray = new double [3];
			offsetArray[0] = offsetflag;
			offsetArray[2] = (Convert.ToDouble(rMinTxtBx.Text));
			if (offsetflag == 1){
				offsetArray[1] =(Convert.ToDouble(offsetPercentTxtBx.Text));
			}
			
			try{
				analyze = new Analyze(individualInputsList, groupInputsList, offsetArray);
			}
			//Use many different catch terms to isolate exactly where the error is, because most errors appear as
			//IndexOutOfRange errors, so I threw different errors in order to distinguish between error locations
			catch(FileNotFoundException){
				MessageBox.Show("Could not find root of polynomial to zero the data: try reducing polynomial order, " +
				                "reducing strain cutoff, or checking data");
				plotGroupBox.Visible = false;
				dataFilesGroupBox.Visible = false;
				return;
			}
			catch(FormatException){
				MessageBox.Show("Could not find root of polynomial to zero the data: root was on the right of the " +
				                "last point or data is negative");
				plotGroupBox.Visible = false;
				dataFilesGroupBox.Visible = false;
				return;
			}
			catch(ArgumentNullException){
				MessageBox.Show("Invalid Interval, Please reduce and try again.");
				plotGroupBox.Visible = false;
				dataFilesGroupBox.Visible = false;
				return;
			}
			catch(AccessViolationException){
				MessageBox.Show("Warning: One or more intervals doesn't have enough points/interval to generate " +
				                "polynomial: reduce polynomial order or increasse interval size");
				plotGroupBox.Visible = false;
				dataFilesGroupBox.Visible = false;
				return;
			}
			catch(AppDomainUnloadedException){
				MessageBox.Show("Couldn't find offset intersection.  Try changing the offset or checking the input.");
				plotGroupBox.Visible = false;
				dataFilesGroupBox.Visible = false;
				return;
			}
			catch(Exception ex){
				MessageBox.Show("Something's not right: check your data/inputs and give it another try!" + ex.Message + ex.StackTrace);
				plotGroupBox.Visible = false;
				dataFilesGroupBox.Visible = false;
				return;
			}
			
			
			if (numberofTranFiles == 0){
				tranAxRadioBttn.Enabled = false;
				taLoessCheckBox.Enabled = false;
				tadhCheckBox.Enabled = false;
				taTotalCheckBox.Enabled = false;
				label13.Enabled = false;
				label15.Enabled = false;
			}
			fileNumberBox.Maximum = numberofFiles;
			analyzeBttn.Text = "Re-Analyze";
			plotGroupBox.Visible = true;
			dataFilesGroupBox.Visible = true;
			
			MessageBox.Show("Done Analyzing");
		}
		//Plotting Options group
		void StressStrainRadioBttnCheckedChanged(object sender, EventArgs e)
		{
			fileNumberBox.Maximum = numberofFiles;
		}
		void FileNumRadioBttn1CheckedChanged(object sender, EventArgs e)
		{
			fileNumberBox.Enabled = true;
			fileNumber = 1;
		}
		void AllRadioBttnCheckedChanged(object sender, EventArgs e)
		{
			fileNumberBox.Enabled = false;
			fileNumber = 0;
		}
		//Warning: this section is HUGE, so don't get into it unless you really have some time!!!
		//However, it isn't really meaty, and is based on the plotting buttons above.
		void PlotBttnClick(object sender, EventArgs e)
		{
			fileNumber = Convert.ToInt16(fileNumberBox.Text);
			PlotMaker pm = new PlotMaker(analyze,numberofFiles, temperature, material, fileNumber);
			if ((stressStrainRadioBttn.Checked == true) && (allRadioBttn.Checked == true)
			    && (rawRadioBttn.Checked == true)){
			    	pm.PlotMaker1();
			}
			if ((stressStrainRadioBttn.Checked == true) && (allRadioBttn.Checked == false)
			    && (rawRadioBttn.Checked == true)){
			    	pm.PlotMaker2();
			}    
			if ((stressStrainRadioBttn.Checked == false) && (allRadioBttn.Checked == true)
			    && (rawRadioBttn.Checked == true)){
			    	pm.PlotMaker3();
			}  
			if ((stressStrainRadioBttn.Checked == false) && (allRadioBttn.Checked == false)
			    && (rawRadioBttn.Checked == true)){
			    	pm.PlotMaker4();
			} 
			if ((stressStrainRadioBttn.Checked == true) && (allRadioBttn.Checked == true)
			    && (combinedRadioBttn.Checked == true)){
			    	pm.PlotMaker5();
			}
			if ((stressStrainRadioBttn.Checked == true) && (allRadioBttn.Checked == false)
			    && (combinedRadioBttn.Checked == true)){
			    	pm.PlotMaker6();
			}    
			if ((stressStrainRadioBttn.Checked == false) && (allRadioBttn.Checked == true)
			    && (combinedRadioBttn.Checked == true)){
			    	pm.PlotMaker7();
			}  
			if ((stressStrainRadioBttn.Checked == false) && (allRadioBttn.Checked == false)
			    && (combinedRadioBttn.Checked == true)){
			    	pm.PlotMaker8();
			} 
			if ((stressStrainRadioBttn.Checked == true) && (allRadioBttn.Checked == true)
			    && (SlopeRadioBttn.Checked == true)){
			    	pm.PlotMaker9();
			}
			if ((stressStrainRadioBttn.Checked == true) && (allRadioBttn.Checked == false)
			    && (SlopeRadioBttn.Checked == true)){
			    	pm.PlotMaker10();
			}    
			if ((stressStrainRadioBttn.Checked == false) && (allRadioBttn.Checked == true)
			    && (SlopeRadioBttn.Checked == true)){
			    	pm.PlotMaker11();
			}  
			if ((stressStrainRadioBttn.Checked == false) && (allRadioBttn.Checked == false)
			    && (SlopeRadioBttn.Checked == true)){
			    	pm.PlotMaker12();
			} 
		
		}


        //Data Files group
        void FileWriteBttnClick(object sender, EventArgs e)
		{ //writes a file for each checked box
			FileWriter fw = new FileWriter(analyze,numberofFiles, temperature, material, folder);
			if (ssdhCheckBox.Checked == true){
				fw.FileWriter1();
			}
			if (ssLoessCheckBox.Checked == true){
				fw.FileWriter2();
			}
			if (tadhCheckBox.Checked == true){
				fw.FileWriter3();
			}
			if (taLoessCheckBox.Checked == true){
				fw.FileWriter4();
			}
			if (ssTotalCheckBox.Checked == true){
				fw.FileWriter5();
			}
			if (taTotalCheckBox.Checked == true){
				fw.FileWriter6();
			}
			MessageBox.Show("File(s) Written");
			
			
		}
		void ResultsBttnClick(object sender, EventArgs e)
		{
			ResultsWindow rw = new ResultsWindow(analyze, temperature, material);
		}	
		void YieldStressBttnClick(object sender, EventArgs e)
		{
			fileNumber = Convert.ToInt16(fileNumberBox.Text);
			PlotMaker pm = new PlotMaker(analyze,numberofFiles, temperature, material, fileNumber);
			pm.PlotMaker15();
		}
	}
}
