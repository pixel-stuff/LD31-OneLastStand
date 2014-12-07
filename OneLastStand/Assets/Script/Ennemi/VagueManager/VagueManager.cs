using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VagueManager {

	public List<Vague> tabVague;

	public int _fp;
	public int _numVague;
	public int _nbPrecalculateVag;

	public float _minPercentHunter;
	public float _maxPercentCruiser;

	public int _costHunter;
	public int _costFrigate;
	public int _costCruiser;

	public VagueManager(){

		_numVague = 1;
		_fp = ConstantesManager.FP_INITIAL;

		_nbPrecalculateVag = ConstantesManager.NB_PRECALCULATE_VAGUE;

		_minPercentHunter = ConstantesManager.MIN_PERCENT_HUNTER;
		_maxPercentCruiser = ConstantesManager.MAX_PERCENT_CRUISER;

		_costHunter = ConstantesManager.COST_HUNTER;
		_costFrigate = ConstantesManager.COST_FRIGATE;
		_costCruiser = ConstantesManager.COST_CRUISER;

		for (int i =0; i< _nbPrecalculateVag; i++) {

				}
		}

	public void createNextVague(){

		int fp = _fp;
		int nbH = 0;
		int nbF = 0;
		int nbC = 0;

		//init with 20% of Hunter

		int fpInitHunter = (int)(fp * _minPercentHunter);
		do {
			nbH++;
			fpInitHunter-=_costHunter;
			
		} while(fpInitHunter > 0);

		do {


				} while(fp > 0);

		}



}
