using UnityEngine;
using System.Collections;

public class Hunter : Ship {
	public Hunter(){
		}

	// Use this for initialization
	void Start(){
	

	}
	public override void init(){
		_TYPE = Enum_ShipType.Hunter;
		_pv = ConstantesManager.HUNTER_PV;
		_degatShot= ConstantesManager.HUNTER_SHOOT_DMG;
		_degatKamikaze = ConstantesManager.HUNTER_KAMIKAZE_DMG;
		_score=ConstantesManager.HUNTER_SCORE;
		_normalSpeed=ConstantesManager.HUNTER_NORME_SPEED;
		_timeBetweenAttack = ConstantesManager.HUNTER_TIME_BETWEEN_ATTACK;
		_variationTimeBetweenAttackPercent = ConstantesManager.VARIATION_TIME_BETWEEN_ATTACK_PERCENT;
		_bulletSpeed=ConstantesManager.HUNTER_SHOT_SPEED;
		
		_percentFragByStandard = ConstantesManager.HUNTER_FRAG_STANDARD_PERCENT;
		_percentFragByDisa = ConstantesManager.HUNTER_FRAG_DISINTEGRATOR_PERCENT;
		_percentFragByEMP = ConstantesManager.HUNTER_FRAG_EMP_PERCENT;
		_shootCooldown=Random.Range(0,2);
		_killYFragment=ConstantesManager.FRAGMENT_KILL_Y;
		_city=GameObject.FindGameObjectWithTag("City");

		UpdateDirection ();
		}
	
	// Update is called once per frame
	void Update () {
		if (_onDestroy) {
			Destroy(this.gameObject);
			return;
		}
	}
}
