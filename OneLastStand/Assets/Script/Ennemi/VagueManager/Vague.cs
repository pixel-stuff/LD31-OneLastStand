using UnityEngine;
using System.Collections;

public class Vague {

	public Vague(int fp,int hN,int fN, int cN,int num){
		_FP=fp;
		_hunterNumber = hN;
		_frigateNumber = fN;
		_cruiserNumber = cN;
		_number = num;
	
	}

	public int _FP;
	public int _number;

	public int _hunterNumber;
	public int _frigateNumber;
	public int _cruiserNumber;

}
