using UnityEngine;
using System.Collections;

public class Frigate : Ship {

	public Frigate() : base() {

	}
	public override void init(){
		_TYPE = Enum_ShipType.Frigate;
		_pv = ConstantesManager.FRIGATE_PV;
		_degatShot= ConstantesManager.FRIGATE_SHOOT_DMG;
		_degatKamikaze = ConstantesManager.FRIGATE_KAMIKAZE_DMG;
		_score=ConstantesManager.FRIGATE_SCORE;
		_normalSpeed=ConstantesManager.FRIGATE_NORME_SPEED;
		_timeBetweenAttack = ConstantesManager.FRIGATE_TIME_BETWEEN_ATTACK;
		_variationTimeBetweenAttackPercent = ConstantesManager.VARIATION_TIME_BETWEEN_ATTACK_PERCENT;
		_bulletSpeed=ConstantesManager.FRIGATE_SHOT_SPEED;
		
		_percentFragByStandard = ConstantesManager.FRIGATE_FRAG_STANDARD_PERCENT;
		_percentFragByDisa = ConstantesManager.FRIGATE_FRAG_DISINTEGRATOR_PERCENT;
		_percentFragByEMP = ConstantesManager.FRIGATE_FRAG_EMP_PERCENT;
		_shootCooldown=Random.Range(0,2);
		_city=GameObject.FindGameObjectWithTag("City");
		_killYFragment=ConstantesManager.FRAGMENT_KILL_Y;

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
