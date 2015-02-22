using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]
public class DisasterData{
	public double pos = 0.0;
	public int disasterType = 0; 
}
		
/***** RAW DATA

	OCCURRENT TYPES
	1: collision involving track unit
	2: crossing (e.g., car at crossing)
	3: dangerous goods leakage
	4: fire
	5: trespasser
	
	PROVINCES/TERRITORIES
	1: AB
	2: BC
	3: MB
	4: NB
	5: NF
	6: NS
	7: ON
	8: QC
	9: SK
				1			2			3			4			5
	1/AB	0.037878788	0.550865801	0.237012987	0.058441558	0.115800866
	2/BC	0.107923497	0.355191257	0.290983607	0.062841530 0.183060109
	3/MB	0.037151703	0.603715170	0.191950464	0.055727554	0.111455108
	4/NB	0.052631579	0.473684211	0.250000000	0.000000000	0.223684211
	5/NF	0.454545455	0.363636364	0.000000000	0.090909091	0.090909091
	6/NS	0.000000000	0.656250000	0.093750000	0.000000000	0.250000000
	7/ON	0.047425474	0.413279133	0.213414634	0.050813008	0.275067751
	8/QC	0.038142620	0.588723051	0.154228856	0.016583748	0.202321725
	9/SK	0.030927835	0.734536082	0.097938144	0.067010309	0.069587629

 *****/

public class DisasterSpawner : MonoBehaviour {
	// Matrix of disaster probabilities.  
	double[][] probAll = new double[][]
		{	
			new double[] {0.037878788,0.550865801,0.237012987,0.058441558,0.115800866}, // AB
			new double[] {0.107923497,0.355191257,0.290983607,0.062841530,0.183060109}, // BC
			new double[] {0.037151703,0.603715170,0.191950464,0.055727554,0.111455108}, // MB
			new double[] {0.052631579,0.473684211,0.250000000,0.000000000,0.223684211}, // NB
			new double[] {0.454545455,0.363636364,0.000000000,0.090909091,0.090909091}, // NF
			new double[] {0.000000000,0.656250000,0.093750000,0.000000000,0.250000000}, // NS
			new double[] {0.047425474,0.413279133,0.213414634,0.050813008,0.275067751}, // ON
			new double[] {0.038142620,0.588723051,0.154228856,0.016583748,0.202321725}, // QC
			new double[] {0.030927835,0.734536082,0.097938144,0.067010309,0.069587629}  // SK
		};
	
	int nProv, nAcc;				// number of provinces, number of accidents/occurrences.
	double accProb = .05; 			// gain control for overall probabilities
	static int nMaxAcc = 1000;  	// maximum possible number of accidents.
	static double maxJitter = .03;	// maximum amount of position jitter, in proportion of step size.
	
	/***** DISASTER DATA
		Let the departure location be 0, and the train destination be 1. Each item in the
		disasterData List contains an x-position in (0,1) and a disaster type in [1 5].
	*****/
	public List<DisasterData> disasterData;
	// Use this for initialization
	void Start () {
	
		nProv = probAll.GetLength (0);
		nAcc  = probAll[0].GetLength (0);
		
		int provID  = 0; // The province for this run of the game. Needs to be passed in somehow.
		
		double[] prob = copyArray(probAll[provID]); // disaster probabilities associated with this province.
		double[] cProb = cumProb (prob);			// cumulative probabilities for this province. It's easier to determine 

		// disaster data.
		disasterData = new List<DisasterData>();
		
		for(int i=0; i < nMaxAcc; i++){
			if (Random.Range (0f,1f) < accProb){
				DisasterData d = new DisasterData();
				
				// Where does this disaster occur?
				d.pos = ((double)i)/((double)nMaxAcc) + (Random.Range (-.5f,.5f)*.03 * (1/(double)nMaxAcc));
				d.pos = Mathf.Min (Mathf.Max (0,(float)d.pos),1);
				
				// What type of disaster is it?
				d.disasterType = findMaxInd (Random.Range (0f,1f),cProb);
			
				// Add this disaster to the list. 
				disasterData.Add(d);
			}
		}
		Debug.Log (disasterData.Count);
		Debug.Log (dlist2str (disasterData));
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	// Find the index of an array that maximally contains a value in [0,1].
	int findMaxInd(double x, double[] arr){
		int i;
		for(i=0; i < arr.GetLength (0); i++){
			if (x < arr[i]){
				break;
			}
		}
		return i;
	}
	
	
	// Turn a table of probabilities into cumulative probabilities.
	double[] cumProb(double[] prob){
		double[] cProb = new double[prob.GetLength (0)];
		double c = 0;
		for (int i=0; i < prob.GetLength (0); i++){
			c = c + prob[i];
			cProb[i] = c;
		} 
		
		return cProb;
	}
	
	/* Helper method to print out arrays */
	string double2str(double[,] arr){
		string str = "";
		for (int i=0; i < arr.GetLength(0); i++){
			for(int j=0; j < arr.GetLength(1); j++){
				str = str + arr[i,j];
				if(j==(arr.GetLength (1)-1)){
					str = str + "\n" ; 
				}else{
					str = str + " "; 
				}
			}
		}
		
		return str; 
	}
	
	string double2str(double[] arr){
		string str = "";
		for (int i=0; i < arr.GetLength(0); i++){
			str = str + arr[i];
			if(i!=(arr.GetLength (0)-1)){
				str = str + " " ; 
			}
		}
		return str; 
	}

	double[] copyArray(double[] src){
		double[] dst = new double[src.GetLength (0)];
		for (int i=0; i < src.GetLength(0); i++){
			dst[i] = src[i];
		}
		return dst;
	}
	
	string dlist2str(List<DisasterData> d){
		string str = "";
		for(int i=0; i < d.Count; i++){
			str = str + i + ": " + d[i].pos + ", " + d[i].disasterType;
			if (i != d.Count-1){
				str = str + "\n";
			}
		}
		return str;
	}
	
}

