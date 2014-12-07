using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Turret : MonoBehaviour{


	public int _pv;
	public float _rateOfFire;
	public int _shootDamage;
	public float _bulletSpeed;

	public TurretTextureManager _turretTextureManager;
	public Enum_StateTurret _enumOldStateTurret;
	public Enum_StateTurret _enumCurrentStateTurret;
	public Enum_TurretType _enumCurrentTurretType;

	public EnnemiManager _ennemiManager;
	public GameObject _prefabBulletTurret;

	public Enum_TurretAim _enumTurretAim;
	public string _tagEnnemiManager = "Ennemi";



	float _timeLastShoot = Time.time;


	void Start(){
		_enumCurrentStateTurret = Enum_StateTurret.TurretLevel1;
		_enumCurrentTurretType = Enum_TurretType.EMP;
		_enumOldStateTurret = _enumCurrentStateTurret;
		_pv = ConstantesManager.CITY_PV_MAX;
		_enumTurretAim = Enum_TurretAim.None;
		_ennemiManager = (GameObject.FindGameObjectWithTag (_tagEnnemiManager)).GetComponent<EnnemiManager>();
		Debug.Log ("PLOP " + _ennemiManager);
		_bulletSpeed = ConstantesManager.BULLET_TURRET_SPEED;
		_pv = ConstantesManager.STANDARD_LVL1_PV_MAX;
		_rateOfFire = ConstantesManager.STANDARD_LVL1_RATE_OF_FIRE; //shooting/sec
		_shootDamage = ConstantesManager.STANDARD_LVL1_PV_MAX;


	}
	
	public void UpdateShoot (){

		if (_enumCurrentTurretType == Enum_TurretType.None)
				return;

		if (_enumCurrentStateTurret == Enum_StateTurret.TurretNone)
				return;

		if (!isAllowedToShoot ()) {
			Debug.Log ("IS NOT ALLOWED TO SHOOT");
			return;
		}


		//Debug.Log ("Turret Update Shoot");
		GameObject ship = null;

		ship = _ennemiManager.getCloserShipLigne1 (this.transform);
		//Debug.Log ("SHIP " + ship);
		_enumTurretAim = Enum_TurretAim.FirstChoice;
		if (ship == null) {
			Debug.Log ("getCloserShipLigne1 is null");
			ship = _ennemiManager.getCloserShipLigne2 (this.transform);
			_enumTurretAim = Enum_TurretAim.SecondChoice;
			if (ship == null) {
				Debug.Log ("getCloserShipLigne2 is null");
				ship = _ennemiManager.getCloserShipLigne3 (this.transform);
				_enumTurretAim = Enum_TurretAim.ThirdChoice;
			}
		}


		if (ship == null) {
			Debug.Log ("All Ligne null");
			_enumTurretAim = Enum_TurretAim.NoEnnemiFound;
		} else {
			float distance = Vector3.Distance(this.transform.position, ship.transform.position);
			if(distance >= ConstantesManager.DISTANCE_OF_VUE_SHOOT){
				_enumTurretAim = Enum_TurretAim.TooFar;
				
				//Debug.Log ("Cible Too Far " + distance);
			}else{
				ShootAt(ship); //Tire si ship != null et distance suffisante
			}
		}
	}

	public void UpdateConstruction (){

	}

	public void StartShoot(){
		_enumTurretAim = Enum_TurretAim.None;
	}

	private bool isAllowedToShoot(){
		if (Time.time - _timeLastShoot >= 1/_rateOfFire) {
			return true;
		} else {
			return false;
		}
	}

	public void StartConstruction(){
		
	}

	public void ShootAt(GameObject ship){
		Debug.Log ("ShootAt");
		GameObject bull = (GameObject)Instantiate (_prefabBulletTurret, this.transform.position, Quaternion.identity);
		bull.GetComponent<BulletTurret> ().Initialize(ship.GetComponent<Ship>(), _enumCurrentTurretType, _shootDamage,_bulletSpeed);
		bull.transform.parent = this.transform;
		_timeLastShoot = Time.time;

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

	void OnTriggerEnter2D(Collider2D coll){
		Ship ship = coll.gameObject.GetComponent<Ship>();
		ennemiBullet bullet = coll.gameObject.GetComponent<ennemiBullet> ();
		
		if (ship != null) {
			getHit(ship._degatKamikaze);
			return;
		}
		
		if (bullet != null) {
			getHit((int)bullet._pvDamage);
			return;
		}
		
	}

	public void ChangeTypeTurret(Enum_TurretType newType){
		_enumCurrentTurretType = newType;
		_turretTextureManager.changeTypeTurret (_enumCurrentTurretType);

		switch(_enumCurrentTurretType){
			case Enum_TurretType.Disintegrator:
				_pv = ConstantesManager.DISINTEGRATOR_LVL1_PV_MAX;
				_rateOfFire = ConstantesManager.DISINTEGRATOR_LVL1_RATE_OF_FIRE; //shooting/sec
				_shootDamage = ConstantesManager.DISINTEGRATOR_LVL1_SHOOT_DAMAGE;
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
		_rateOfFire = ConstantesManager.DISINTEGRATOR_LVL1_RATE_OF_FIRE; //shooting/sec
		_shootDamage = ConstantesManager.DISINTEGRATOR_LVL1_SHOOT_DAMAGE;
	}

	private void  SetDisintegratorlv2(){
		_pv = ConstantesManager.DISINTEGRATOR_LVL2_PV_MAX;
		_rateOfFire = ConstantesManager.DISINTEGRATOR_LVL2_RATE_OF_FIRE; //shooting/sec
		_shootDamage = ConstantesManager.DISINTEGRATOR_LVL2_SHOOT_DAMAGE;
	}

	private void  SetDisintegratorlv3(){
		_pv = ConstantesManager.DISINTEGRATOR_LVL3_PV_MAX;
		_rateOfFire = ConstantesManager.DISINTEGRATOR_LVL3_RATE_OF_FIRE; //shooting/sec
		_shootDamage = ConstantesManager.DISINTEGRATOR_LVL3_SHOOT_DAMAGE;
	}

	private void  SetEMPlv1(){
		_pv = ConstantesManager.EMP_LVL1_PV_MAX;
		_rateOfFire = ConstantesManager.EMP_LVL1_RATE_OF_FIRE; //shooting/sec
		_shootDamage = ConstantesManager.EMP_LVL1_SHOOT_DAMAGE;
	}
	
	private void  SetEMPlv2(){
		_pv = ConstantesManager.EMP_LVL2_PV_MAX;
		_rateOfFire = ConstantesManager.EMP_LVL2_RATE_OF_FIRE; //shooting/sec
		_shootDamage = ConstantesManager.EMP_LVL2_SHOOT_DAMAGE;
	}
	
	private void  SetEMPlv3(){
		_pv = ConstantesManager.EMP_LVL3_PV_MAX;
		_rateOfFire = ConstantesManager.EMP_LVL3_RATE_OF_FIRE; //shooting/sec
		_shootDamage = ConstantesManager.EMP_LVL3_SHOOT_DAMAGE;
	}

	private void  SetStandardlv1(){
		_pv = ConstantesManager.STANDARD_LVL1_PV_MAX;
		_rateOfFire = ConstantesManager.STANDARD_LVL1_RATE_OF_FIRE; //shooting/sec
		_shootDamage = ConstantesManager.STANDARD_LVL1_SHOOT_DAMAGE;
	}
	
	private void  SetStandardlv2(){
		_pv = ConstantesManager.STANDARD_LVL2_PV_MAX;
		_rateOfFire = ConstantesManager.STANDARD_LVL2_RATE_OF_FIRE; //shooting/sec
		_shootDamage = ConstantesManager.STANDARD_LVL2_SHOOT_DAMAGE;
	}
	
	private void  SetStandardlv3(){
		_pv = ConstantesManager.STANDARD_LVL3_PV_MAX;
		_rateOfFire = ConstantesManager.STANDARD_LVL3_RATE_OF_FIRE; //shooting/sec
		_shootDamage = ConstantesManager.STANDARD_LVL3_SHOOT_DAMAGE;
	}
}

