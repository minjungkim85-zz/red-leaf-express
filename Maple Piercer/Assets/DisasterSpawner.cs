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
	1: crossing (two types)
	2: trespasser (two types)
	
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
 *****/

public class DisasterSpawner : MonoBehaviour {
	public GameManager gm;
	// Matrix of disaster probabilities.  
	double[][] probAll = new double[][]
		{	
		new double[]{0.826298701,0.173701299},
		new double[]{0.659898477,0.340101523},
		new double[]{0.844155844,0.155844156},
		new double[]{0.679245283,0.320754717},
		new double[]{0.8,	0.2},
		new double[]{0.724137931,0.275862069},
		new double[]{0.600393701,0.399606299},
		new double[]{0.744234801,0.255765199},
		new double[]{0.913461538,0.086538462}
		
		};
	
	int nProv, nAcc;				// number of provinces, number of accidents/occurrences.
	private double accProb = .1; 	// gain control for overall probabilities
	static int nMaxAcc = 1000;  	// maximum possible number of accidents.
	static double maxJitter = .03;	// maximum amount of position jitter, in proportion of step size.
	
	public int provID; 					// the province for this run of the game	
	double trackLength; 			// length of the track in world units.
	public double trackOrigin;				// origin of the track in world units. 
	
	public Transform[] prefab;
	int[][] prefabIDarray = {
		new int[]{0,1},
		new int[]{2,3}
	};
	int prefabID;

	
	/***** DISASTER DATA
		Let the departure location be 0, and the train destination be 1. Each item in the
		disasterData List contains an x-position in (0,1) and a disaster type in [1 5].
	*****/
	public List<DisasterData> disasterData;
	// Use this for initialization
	void Start () {
	
		nProv = probAll.GetLength (0);
		nAcc  = probAll[0].GetLength (0);

		if (gm.randomRoll > .5f) {
			provID = 2; // The province for this run of the game. Needs to be passed in somehow.
		} else {
			provID = 8;
		}
		
		trackOrigin = -600; 			// Origin of the track. We will translate our positions with this. 
		trackLength = 2250-trackOrigin; // Full length of the track. We will multiply our positions with this. 
		
		double[] prob = copyArray(probAll[provID]); // disaster probabilities associated with this province.
		double[] cProb = cumProb (prob);			// cumulative probabilities for this province. It's easier to determine 

		// disaster data.
		disasterData = new List<DisasterData>();
		
		for(int i=0; i < nMaxAcc; i++){
			if (Random.Range (0f,1f) <= accProb){
				DisasterData d = new DisasterData();
				
				// Where does this disaster occur?
				d.pos = ((double)i)/((double)nMaxAcc);// + (Random.Range (-.5f,.5f)*.03 * (1/(double)nMaxAcc)); 
				d.pos = Mathf.Min (Mathf.Max (0,(float)d.pos),1); // in [0 1]
				
				d.pos = d.pos * trackLength; // in [0 trackLength]
				d.pos = d.pos + trackOrigin; // in [trackOrigin trackLength-trackOrigin];
				
				// What type of disaster is it?
				d.disasterType = findMaxInd (Random.Range (0f,1f),cProb);
			
				// Add this disaster to the list. 
				disasterData.Add(d);
				
				// Instantiate.
				int id = Random.Range (0,prefabIDarray[d.disasterType].GetLength(0));
				prefabID = prefabIDarray[d.disasterType][id];
				
				Instantiate(prefab[prefabID], new Vector3((float)d.pos, 0, 0), Quaternion.identity);
				
			}
			
		}

		
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

