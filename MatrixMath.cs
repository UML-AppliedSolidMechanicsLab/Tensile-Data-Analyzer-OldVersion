/*
 * Created by SharpDevelop.
 * User: e46221
 * Date: 6/13/2007
 * Time: 2:42 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace StressStrainData
{
	/// <summary>
	/// Description of Math.
	/// </summary>
   
	public class MatrixMath
    {
      	public bool IsInt(string s)
        {
            try
            {
                int.Parse(s);
            }
            catch
            {
                return false;
            }
            return true;
        }
        
        public double[,] MatrixMultiply(double[,] c, double[,] a, double[,] b,
                                    int aRows, int aCols, int bRows, int bCols){
        	int i;
        	int j;
        	int k;
        	// assure c contains zeros:
        	for (i = 0; i < aRows; i++){
        		for(j = 0; j < bCols; j++) {
        			c[i,j] = 0.0;
        		}
        	}
        	for (i = 0; i < aRows; i++){
        		for (j = 0; j < bCols; j++){
        			for (k = 0; k < bRows; k++){
        				c[i, j] = c[i,j] + a[i,k] * b[k,j];
        			}
        		}
        	}
        	return c;
        }

        public void gauss(double[,] A, double[,] B, int n, int C){
//		L.A. Riddle 09/07/91
//		This function solves simultaneous linear equations using Gauss
//		Elimination with Scaled Partial Pivoting
//		(ref pg 139, "Numerical Methods, Software and Analysis" by John R. Rice.)
//		A (n,n) = the coefficient matrix (gets mangled)
//		B (n,c) = the right hand matrix
//		(A) X = B
//		X (1,n), is returned as pointer to B
//		c = 0 for a column vector, 0 - n for n x n matrix...use successive calls
//		//TODO: (LAR) fix error handling for guass subroutine
//		Return ERROR for singular matrix, consistent system
//		or singular matrix, inconsistent system

		int i; //Dim i As Integer
		int j; //Dim j As Integer
		int k; //Dim k As Integer
		int imax; //Dim imax As Integer
		double R; //Dim R As Double
		double S; //Dim S As Double
		double m; //Dim m As Double
		double buffer; //Dim buffer As Double
		double[,] scaleFactors = new double[n,1]; //Dim scaleFactors(6, 1) As Double: was 3 where n is  SES
		int errorFlag; //Dim errorFlag As Integer

		//initialize:
		//TODO: (LAR) get rid of magic numbers:
		errorFlag = 0;
		buffer = 0.000000001;
		imax = 0;
		// TODO:(LAR) determine what to do with optional arguement C:
		// initialize to zero for now...
		//C = 0; //This term limited the solution to a column matrix SES
		for (i = 0; i<n;i++){
			scaleFactors[i, 0] = 0.0;
				for (j = 0; j<n;j++){
					if(Math.Abs(A[i,j])>scaleFactors[i,0]){
						scaleFactors[i,0] = Math.Abs(A[i,j]);
				}
			}
		}
		for (k = 0; k<n-1; k++){	// loop over columns of A
			S = 0.0;	// reset check value     
			for (i= k; i<n; i++){	// loop over rows   '
				if(Math.Abs(A[i,k]/scaleFactors[i,0])>S){ 		// look for the
					S = Math.Abs(A[i,k]/scaleFactors[i,0]);		// maximum element
					imax = i;									// in column k                                        '
				}
			}
			if(Math.Abs(A[imax,k]) <= buffer){
				goto End_of_k_loop;
			}

			if(imax == k) {
				goto Calculate_m;// row does not need interchanged
			}
			for(j = 0; j<n; j++){ // interchange rows k and imax
				R = A[k,j];
				A[k,j] = A[imax,j];
				A[imax,j] = R;
			}
			R = B[k,C];				// interchange corresponding right hand sides
			B[k,C] = B[imax,C];
			B[imax,C] = R;

		Calculate_m:
				for(i = k + 1; i<n; i++){
				A[i,k] = A[i,k]/A[k,k];		// compute multiplier
				m = A[i,k];					// assign it to m
					for(j = k + 1; j<n; j++){ // loop over elements
						A[i,j] = A[i,j] - m*A[k,j];	// of row i
					}
					B[i,C] = B[i,C]-m*B[k,C];	// do the right hand side
				}
		End_of_k_loop:

			; // don't know why we need the ;...
		}
		// Back substitution
		i = n-1;

		while(i>=0){	// loop backwards over rows of A
        	R = 0.0;
        	for(j = i+1; j<n; j++){
				R = R + A[i,j] * B[j,C]; // sum up known values
        	}
        	R = B[i,C] - R;
			if(Math.Abs(A[i,i])>buffer){
				B[i,C] = R / A[i,i];
			}
			else if(Math.Abs(R) <=buffer) {	// A is singular
							// system is consistent
				errorFlag = 1;
				goto ErrorHandler;
			}
			else {
				errorFlag = 1;
				goto ErrorHandler;
			}
			i = i - 1;
		} //Wend
		ErrorHandler: ;
			if(errorFlag == 1){
				// zero out the result matrix
				for(i=0; i<n-1; i++){
					B[i,C] = 0.0;
				}
			}
		} // end gauss        
    
	
	
      	public double[,] InvertMatrix(double[,] inMatrix, double[,] outMatrix, int nRows,int nCols){
    		int I;
   			int j; 
    		int k;
 			double[,] callMatrix = new double[nRows,nCols];
    	 	// fill inverse matrix with the identity matrix...
    		for (j = 0; j < nCols; j++){                  // column loop...
    			for (k = 0; k < nRows; k++){              // row loop...
    				if (k == j){
            			outMatrix[k, j] = 1;
    				}
    				else{
            			outMatrix[k, j] = 0;
    				}
    			}
    		}
    		// loop over columns of the inverse matrix
    		for (I = 0; I < nCols; I++){  //column loop make the surrogate copy of ABD_inv:
        		for (j = 0; j < nCols; j++){
            		for (k = 0; k < nRows; k++){
    					callMatrix[k, j] = inMatrix[k, j];
    				}
    			}
    			MatrixMath math = new MatrixMath();
    			math.gauss(callMatrix, outMatrix, nCols, I); // calculate inverse column j
    		}
    		return outMatrix; //return outmatrix
		}
	}
}



