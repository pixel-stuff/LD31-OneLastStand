using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VagueManager {
	public static int _plusVariationFP =5;
	public List<Vague> _tabVague;

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
			createNextVague();

				}
		}

	public void createNextVague(){

		int fp = _fp;
		int nbH = 0;
		int nbF = 0;
		int nbC = 0;



		//init with 20% of Hunter

		int fpInitHunter = (int)(fp * _minPercentHunter);
		fp = fp - fpInitHunter;
		do {
			nbH++;
			fpInitHunter-=_costHunter;
			if(fpInitHunter <0){
				nbH--;
				fpInitHunter=0;
			}
			
		} while(fpInitHunter > 0);
		int nbMaxCruiser = (int)((fp * _maxPercentCruiser) / _costCruiser);

		do {
			int possible = 2;
			if (fp < _costCruiser && nbC== nbMaxCruiser ) {
				possible=1;
			}
			if (fp < _costFrigate) {
				possible=0;
			}

			int selectShip = Random.Range(0,possible);

			if (selectShip == 0){
				nbH++;
				fp-=_costHunter;
				if(fp <0){
					nbH--;
					fp=0;
				}

			}else if (selectShip == 1){
				nbF++;
				fp-=_costFrigate;

			}else if (selectShip == 2){
				nbC++;
				fp-=_costCruiser;

			}


				} while(fp > 0);

		_tabVague.Add(new Vague(_fp,nbH,nbF,nbC,_numVague));

		updateVague ();
		
		}

	void updateVague(){
		_fp += _plusVariationFP;
		_numVague++;

		}
	public Vague getIncomingVague(){
		updateVague ();
		Vague ret = _tabVague [0];
		_tabVague.RemoveAt (0);
		return ret;

		}


}
