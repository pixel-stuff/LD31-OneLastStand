using UnityEngine;
using System.Collections;

public class Hunter : Ship {


	// Use this for initialization
	void Start(){
	
		_TYPE = Enum_ShipType.Hunter;
		_pv = ConstantesManager.HUNTER_PV;
		_degatShot= ConstantesManager.HUNTER_SHOOT_DMG;
		_degatKamikaze = ConstantesManager.HUNTER_KAMIKAZE_DMG;
		_score=ConstantesManager.HUNTER_SCORE;
		_normalSpeed=ConstantesManager.HUNTER_NORME_SPEED;
		_timeBetweenAttack = ConstantesManager.HUNTER_TIME_BETWEEN_ATTACK;
		_variationTimeBetweenAttackPercent = ConstantesManager.VARIATION_TIME_BETWEEN_ATTACK_PERCENT;
		

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
