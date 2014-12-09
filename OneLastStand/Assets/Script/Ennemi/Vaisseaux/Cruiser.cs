using UnityEngine;
using System.Collections;

public class Cruiser : Ship {

	public Cruiser() : base() {
		

	}
	public override void init(){
		_TYPE = Enum_ShipType.Cruiser;
		_pv = ConstantesManager.CRUISER_PV;
		_degatShot= ConstantesManager.CRUISER_SHOOT_DMG;
		_degatKamikaze = ConstantesManager.CRUISER_KAMIKAZE_DMG;
		_score=ConstantesManager.CRUISER_SCORE;
		_normalSpeed=ConstantesManager.CRUISER_NORME_SPEED;
		_timeBetweenAttack = ConstantesManager.CRUISER_TIME_BETWEEN_ATTACK;
		_variationTimeBetweenAttackPercent = ConstantesManager.VARIATION_TIME_BETWEEN_ATTACK_PERCENT;
		_bulletSpeed=ConstantesManager.CRUISER_SHOT_SPEED;
		_percentFragByStandard = ConstantesManager.CRUISER_FRAG_STANDARD_PERCENT;
		_percentFragByDisa = ConstantesManager.CRUISER_FRAG_DISINTEGRATOR_PERCENT;
		_percentFragByEMP = ConstantesManager.CRUISER_FRAG_EMP_PERCENT;
		_shootCooldown=Random.Range(0,2);
		_city=GameObject.FindGameObjectWithTag("City");
		_killYFragment=ConstantesManager.FRAGMENT_KILL_Y;
		UpdateDirection ();
		}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (_onDestroy) {
			Destroy(this.gameObject);
			return;
		}
	}
}
