using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Turret : MonoBehaviour{

	static public int _idStatic = 0;

	public int _id;
	public int _pv;
	public int _rateOfFire;
	public int _shootDamage;

	public TurretTextureManager _turretTextureManager;
	public Enum_StateTurret _enumOldStateTurret;
	public Enum_StateTurret _enumCurrentStateTurret;
	public Enum_TurretType _enumCurrentTurretType;

	public List<LineAttack> _lineAttackAiming;

	public GameObject _prefabBulletTurret;

	void Start(){
		_enumCurrentStateTurret = Enum_StateTurret.TurretNone;
		_enumCurrentTurretType = Enum_TurretType.None;
		_enumOldStateTurret = _enumCurrentStateTurret;
		_pv = ConstantesManager.CITY_PV_MAX;

		_lineAttackAiming = new List<LineAttack> ();
		//TODO
		/* Arranger lineAttack par ordre de préférence*/


		_id = _idStatic;
		_idStatic++;
	}
	
	public void UpdateShoot (){
		//TODO 
		/*Ship ship = null;
		 *foreach(LineAttack lineAtt in _lineAttackAiming){
		 *		Ship ship = lineAtt.getCloser();
		 *		if(ship != null){
		 *			break;
		 *		}
		 *
		 * }
		 *ShootAt(ship);
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 */
	}

	public void UpdateConstruction (){
	}


	public void ShootAt(Ship ship){
		GameObject bullet = (GameObject)Instantiate(_prefabBulletTurret,Vector3.zero,Quaternion.identity);
		bullet.name += this.gameObject.name;
		bullet.GetComponent<BulletTurret> ().SetTarget (ship);
		bullet.GetComponent<BulletTurret> ()._enumBulletType = _enumCurrentTurretType;
		//TODO setvariable membre de bullet
	}


	public void Repare(int lifeAdding){
		_pv += lifeAdding;
		Enum_StateTurret tempState = _enumOldStateTurret;
		_enumOldStateTurret = _enumCurrentStateTurret;
		_enumCurrentStateTurret = tempState;
		_turretTextureManager.changeStateTurret (_enumCurrentStateTurret);
	}

	public void getHit(int degat){
		_pv -= degat;
		if (_pv <= 0) {
			_pv =0;
			_enumCurrentStateTurret = Enum_StateTurret.TurretDestroy;
			_turretTextureManager.changeStateTurret(_enumCurrentStateTurret);
		}
	}

	public void ChangeTypeTurret(Enum_TurretType newType){
		_enumCurrentTurretType = newType;
		_turretTextureManager.changeTypeTurret (_enumCurrentTurretType);

		switch(_enumCurrentTurretType){
			case Enum_TurretType.Disintegrator:
				_pv = ConstantesManager.DISINTEGRATOR_LVL1_PV_MAX;
				_rateOfFire = ConstantesManager.DISINTEGRATOR_LVL1_PV_MAX; //shooting/sec
				_shootDamage = ConstantesManager.DISINTEGRATOR_LVL1_PV_MAX;
				break;
			case Enum_TurretType.EMP:
				_pv = ConstantesManager.EMP_LVL1_PV_MAX;
				_rateOfFire = ConstantesManager.EMP_LVL1_RATE_OF_FIRE; //shooting/sec
				_shootDamage = ConstantesManager.EMP_LVL1_SHOOT_DAMAGE;
				break;
			case Enum_TurretType.None:
			case Enum_TurretType.Standard:
			default:
				_pv = ConstantesManager.STANDARD_LVL1_PV_MAX;
				_rateOfFire = ConstantesManager.STANDARD_LVL1_RATE_OF_FIRE; //shooting/sec
				_shootDamage = ConstantesManager.STANDARD_LVL1_SHOOT_DAMAGE;
				break;
		}
	}

	public void ChangeStateTurret(Enum_StateTurret newState){
		_enumOldStateTurret = _enumCurrentStateTurret;
		_enumCurrentStateTurret = newState;
		_turretTextureManager.changeStateTurret (_enumCurrentStateTurret);

		if (_enumCurrentStateTurret != Enum_StateTurret.TurretDestroy && _enumCurrentStateTurret != Enum_StateTurret.TurretNone) {
			ChangeLevel();
		}
	}

	private void ChangeLevel(){
		switch (_enumCurrentTurretType) {
			case Enum_TurretType.Disintegrator:
				switch(_enumCurrentStateTurret){
					case Enum_StateTurret.TurretLevel1:
						SetDisintegratorlv1();
						break;
					case Enum_StateTurret.TurretLevel2:
						SetDisintegratorlv2();
						break;
					case Enum_StateTurret.TurretLevel3:
						SetDisintegratorlv3();
						break;
				}
				break;
			case Enum_TurretType.EMP:
				switch(_enumCurrentStateTurret){
				case Enum_StateTurret.TurretLevel1:
					SetEMPlv1();
					break;
				case Enum_StateTurret.TurretLevel2:
					SetEMPlv2();
					break;
				case Enum_StateTurret.TurretLevel3:
					SetEMPlv3();
					break;
				}
				break;
			case Enum_TurretType.Standard:
				switch(_enumCurrentStateTurret){
				case Enum_StateTurret.TurretLevel1:
					SetStandardlv1();
					break;
				case Enum_StateTurret.TurretLevel2:
					SetStandardlv2();
					break;
				case Enum_StateTurret.TurretLevel3:
					SetStandardlv3();
					break;
				}
				break;
			default:
				break;
		}
	}

	private void  SetDisintegratorlv1(){
		_pv = ConstantesManager.DISINTEGRATOR_LVL1_PV_MAX;
		_rateOfFire = ConstantesManager.DISINTEGRATOR_LVL1_PV_MAX; //shooting/sec
		_shootDamage = ConstantesManager.DISINTEGRATOR_LVL1_PV_MAX;
	}

	private void  SetDisintegratorlv2(){
		_pv = ConstantesManager.DISINTEGRATOR_LVL2_PV_MAX;
		_rateOfFire = ConstantesManager.DISINTEGRATOR_LVL2_PV_MAX; //shooting/sec
		_shootDamage = ConstantesManager.DISINTEGRATOR_LVL2_PV_MAX;
	}

	private void  SetDisintegratorlv3(){
		_pv = ConstantesManager.DISINTEGRATOR_LVL3_PV_MAX;
		_rateOfFire = ConstantesManager.DISINTEGRATOR_LVL3_PV_MAX; //shooting/sec
		_shootDamage = ConstantesManager.DISINTEGRATOR_LVL3_PV_MAX;
	}

	private void  SetEMPlv1(){
		_pv = ConstantesManager.EMP_LVL1_PV_MAX;
		_rateOfFire = ConstantesManager.EMP_LVL1_PV_MAX; //shooting/sec
		_shootDamage = ConstantesManager.EMP_LVL1_PV_MAX;
	}
	
	private void  SetEMPlv2(){
		_pv = ConstantesManager.EMP_LVL2_PV_MAX;
		_rateOfFire = ConstantesManager.EMP_LVL2_PV_MAX; //shooting/sec
		_shootDamage = ConstantesManager.EMP_LVL2_PV_MAX;
	}
	
	private void  SetEMPlv3(){
		_pv = ConstantesManager.EMP_LVL3_PV_MAX;
		_rateOfFire = ConstantesManager.EMP_LVL3_PV_MAX; //shooting/sec
		_shootDamage = ConstantesManager.EMP_LVL3_PV_MAX;
	}

	private void  SetStandardlv1(){
		_pv = ConstantesManager.STANDARD_LVL1_PV_MAX;
		_rateOfFire = ConstantesManager.STANDARD_LVL1_PV_MAX; //shooting/sec
		_shootDamage = ConstantesManager.STANDARD_LVL1_PV_MAX;
	}
	
	private void  SetStandardlv2(){
		_pv = ConstantesManager.STANDARD_LVL2_PV_MAX;
		_rateOfFire = ConstantesManager.STANDARD_LVL2_PV_MAX; //shooting/sec
		_shootDamage = ConstantesManager.STANDARD_LVL2_PV_MAX;
	}
	
	private void  SetStandardlv3(){
		_pv = ConstantesManager.STANDARD_LVL3_PV_MAX;
		_rateOfFire = ConstantesManager.STANDARD_LVL3_PV_MAX; //shooting/sec
		_shootDamage = ConstantesManager.STANDARD_LVL3_PV_MAX;
	}
}

