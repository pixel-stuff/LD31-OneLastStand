using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Turret : MonoBehaviour{
	
	
	public int _pv;
	public int _pvMax;
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

	
	public Enum_IdTurret _enumIdTurret = Enum_IdTurret.Turret1; //TODO utiliser cette enum/id pour choisir des cibles différentes
	
	
	
	float _timeLastShoot = Time.time;
	
	
	void Start(){
		_enumCurrentStateTurret = Enum_StateTurret.TurretLevel1;
		_enumCurrentTurretType = Enum_TurretType.EMP;
		_enumOldStateTurret = _enumCurrentStateTurret;
		_pv = ConstantesManager.EMP_LVL1_PV_MAX;
		_pvMax = ConstantesManager.EMP_LVL1_PV_MAX;
		_enumTurretAim = Enum_TurretAim.None;
		_ennemiManager = (GameObject.FindGameObjectWithTag (_tagEnnemiManager)).GetComponent<EnnemiManager>();
		//Debug.Log ("PLOP " + _ennemiManager);
		_bulletSpeed = ConstantesManager.BULLET_TURRET_SPEED;
		_pv = ConstantesManager.STANDARD_LVL1_PV_MAX;
		_rateOfFire = ConstantesManager.STANDARD_LVL1_RATE_OF_FIRE + RandOn10Percent(ConstantesManager.STANDARD_LVL1_RATE_OF_FIRE/10); //shooting/sec
		_shootDamage = ConstantesManager.STANDARD_LVL1_PV_MAX;
		
	}
	
	public void Initialize(Enum_IdTurret enumid){
		_enumIdTurret = enumid;
	}
	
	public void UpdateShoot (){
		
		if (_enumCurrentTurretType == Enum_TurretType.None)
			return;
		
		if (_enumCurrentStateTurret == Enum_StateTurret.TurretNone)
			return;
		
		if (!isAllowedToShoot ()) {
			//Debug.Log ("IS NOT ALLOWED TO SHOOT");
			return;
		}
		
		
		//Debug.Log ("Turret Update Shoot");
		GameObject ship = getTarget();
		
		
		
		
		
		
		if (ship == null) {
			//Debug.Log ("All Ligne null");
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
	
	private GameObject getTarget(){
		
		GameObject ship = getFirstChoice();
		//Debug.Log ("SHIP " + ship);
		_enumTurretAim = Enum_TurretAim.FirstChoice;
		if (ship == null) {
			//Debug.Log ("getCloserShipLigne1 is null");
			ship = getSecondChoice();
			_enumTurretAim = Enum_TurretAim.SecondChoice;
			if (ship == null) {
				//Debug.Log ("getCloserShipLigne2 is null");
				ship = getThirdChoice();
				_enumTurretAim = Enum_TurretAim.ThirdChoice;
			}
		}
		return ship;
	}
	
	private GameObject getFirstChoice(){
		
		switch(_enumIdTurret){
		case Enum_IdTurret.Turret1:
			return _ennemiManager.getCloserShipLigne1 (this.transform);
		case Enum_IdTurret.Turret2:
			return _ennemiManager.getCloserShipLigne2 (this.transform);
		case Enum_IdTurret.Turret3:
			return _ennemiManager.getCloserShipLigne3 (this.transform);
		case Enum_IdTurret.Turret4:
			return _ennemiManager.getCloserShipLigne2 (this.transform);
		default:
			Debug.Log("Wrong _enumId First choice");
			return null;
		}
	}
	
	private GameObject getSecondChoice(){
		switch(_enumIdTurret){
		case Enum_IdTurret.Turret1:
			return _ennemiManager.getCloserShipLigne2 (this.transform);
		case Enum_IdTurret.Turret2:
			return _ennemiManager.getCloserShipLigne3 (this.transform);
		case Enum_IdTurret.Turret3:
			return _ennemiManager.getCloserShipLigne1 (this.transform);
		case Enum_IdTurret.Turret4:
			return _ennemiManager.getCloserShipLigne1 (this.transform);
		default:
			Debug.Log("Wrong _enumId Second choice");
			return null;
		}
	}
	
	private GameObject getThirdChoice(){
		switch(_enumIdTurret){
		case Enum_IdTurret.Turret1:
			return _ennemiManager.getCloserShipLigne3 (this.transform);
		case Enum_IdTurret.Turret2:
			return _ennemiManager.getCloserShipLigne1 (this.transform);
		case Enum_IdTurret.Turret3:
			return _ennemiManager.getCloserShipLigne2 (this.transform);
		case Enum_IdTurret.Turret4:
			return _ennemiManager.getCloserShipLigne3 (this.transform);
		default:
			Debug.Log("Wrong _enumId Third choice");
			return null;
		}
	}
	
	public void UpdateConstruction (){
		
	}
	
	public void StartShoot(){
		_enumTurretAim = Enum_TurretAim.None;

	}

	public int getLevel(){
		switch (_enumCurrentStateTurret) {
			case Enum_StateTurret.TurretLevel1:
				return 1;
			case Enum_StateTurret.TurretLevel2:
				return 2;
			case Enum_StateTurret.TurretLevel3:
				return 3;
			default:
				Debug.Log("Type is not a level");
				return 0;
		}
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
		//Debug.Log ("ShootAt");
		GameObject bull = (GameObject)Instantiate (_prefabBulletTurret, this.transform.position, Quaternion.identity);
		bull.GetComponent<BulletTurret> ().Initialize(ship.GetComponent<Ship>(), _enumCurrentTurretType, _shootDamage,_bulletSpeed);
		bull.transform.parent = this.transform;
		_timeLastShoot = Time.time;
		
	}
	
	
	public void Repare(int lifeAdding){
		_pv += lifeAdding;
		
		/*Enum_StateTurret tempState = _enumOldStateTurret;
		_enumOldStateTurret = _enumCurrentStateTurret;
		_enumCurrentStateTurret = tempState;
		_turretTextureManager.changeStateTurret (_enumCurrentStateTurret);*/
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
				_pvMax = ConstantesManager.DISINTEGRATOR_LVL1_PV_MAX;
				_rateOfFire = ConstantesManager.DISINTEGRATOR_LVL1_RATE_OF_FIRE + RandOn10Percent(ConstantesManager.DISINTEGRATOR_LVL1_RATE_OF_FIRE/10); //shooting/sec
				_shootDamage = ConstantesManager.DISINTEGRATOR_LVL1_SHOOT_DAMAGE;
				break;
			case Enum_TurretType.EMP:
			_pvMax = ConstantesManager.EMP_LVL1_PV_MAX;
				_rateOfFire = ConstantesManager.EMP_LVL1_RATE_OF_FIRE+ RandOn10Percent(ConstantesManager.EMP_LVL1_RATE_OF_FIRE/10); //shooting/sec
				_shootDamage = ConstantesManager.EMP_LVL1_SHOOT_DAMAGE;
				break;
			case Enum_TurretType.None:
			case Enum_TurretType.Standard:
			default:
			_pvMax = ConstantesManager.STANDARD_LVL1_PV_MAX;
				_rateOfFire = ConstantesManager.STANDARD_LVL1_RATE_OF_FIRE+ RandOn10Percent(ConstantesManager.STANDARD_LVL1_RATE_OF_FIRE/10); //shooting/sec
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

	public void Upgrade(){
		switch (_enumCurrentStateTurret) {
		case Enum_StateTurret.TurretLevel1:
			ChangeStateTurret(Enum_StateTurret.TurretLevel2);
			break;
		case Enum_StateTurret.TurretLevel2:
			ChangeStateTurret(Enum_StateTurret.TurretLevel2);
			break;
		case Enum_StateTurret.TurretLevel3:
			Debug.Log("Impossible to go Further");
			break;
		default:
			Debug.Log("Type is not a level");
			break;
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
	
	private float RandOn10Percent(float flo){
		return Random.Range(-flo,flo);
	}
	
	private void  SetDisintegratorlv1(){
		_pvMax = ConstantesManager.DISINTEGRATOR_LVL1_PV_MAX;
		_rateOfFire = ConstantesManager.DISINTEGRATOR_LVL1_RATE_OF_FIRE +RandOn10Percent(ConstantesManager.DISINTEGRATOR_LVL1_RATE_OF_FIRE/10); //shooting/sec
		_shootDamage = ConstantesManager.DISINTEGRATOR_LVL1_SHOOT_DAMAGE;
	}
	
	private void  SetDisintegratorlv2(){
		_pvMax = ConstantesManager.DISINTEGRATOR_LVL2_PV_MAX;
		_rateOfFire = ConstantesManager.DISINTEGRATOR_LVL2_RATE_OF_FIRE+RandOn10Percent(ConstantesManager.DISINTEGRATOR_LVL2_RATE_OF_FIRE/10); //shooting/sec
		_shootDamage = ConstantesManager.DISINTEGRATOR_LVL2_SHOOT_DAMAGE;
	}
	
	private void  SetDisintegratorlv3(){
		_pvMax = ConstantesManager.DISINTEGRATOR_LVL3_PV_MAX;
		_rateOfFire = ConstantesManager.DISINTEGRATOR_LVL3_RATE_OF_FIRE + RandOn10Percent(ConstantesManager.DISINTEGRATOR_LVL3_RATE_OF_FIRE/10); //shooting/sec
		_shootDamage = ConstantesManager.DISINTEGRATOR_LVL3_SHOOT_DAMAGE;
	}
	
	private void  SetEMPlv1(){
		_pvMax = ConstantesManager.EMP_LVL1_PV_MAX;
		_rateOfFire = ConstantesManager.EMP_LVL1_RATE_OF_FIRE + RandOn10Percent(ConstantesManager.EMP_LVL1_RATE_OF_FIRE/10); //shooting/sec
		_shootDamage = ConstantesManager.EMP_LVL1_SHOOT_DAMAGE;
	}
	
	private void  SetEMPlv2(){
		_pvMax = ConstantesManager.EMP_LVL2_PV_MAX;
		_rateOfFire = ConstantesManager.EMP_LVL2_RATE_OF_FIRE + RandOn10Percent(ConstantesManager.EMP_LVL2_RATE_OF_FIRE/10); //shooting/sec
		_shootDamage = ConstantesManager.EMP_LVL2_SHOOT_DAMAGE;
	}
	
	private void  SetEMPlv3(){
		_pvMax = ConstantesManager.EMP_LVL3_PV_MAX;
		_rateOfFire = ConstantesManager.EMP_LVL3_RATE_OF_FIRE + RandOn10Percent(ConstantesManager.EMP_LVL3_RATE_OF_FIRE/10); //shooting/sec
		_shootDamage = ConstantesManager.EMP_LVL3_SHOOT_DAMAGE;
	}
	
	private void  SetStandardlv1(){
		_pvMax = ConstantesManager.STANDARD_LVL1_PV_MAX;
		_rateOfFire = ConstantesManager.STANDARD_LVL1_RATE_OF_FIRE + RandOn10Percent(ConstantesManager.STANDARD_LVL1_RATE_OF_FIRE/10); //shooting/sec
		_shootDamage = ConstantesManager.STANDARD_LVL1_SHOOT_DAMAGE;
	}
	
	private void  SetStandardlv2(){
		_pvMax = ConstantesManager.STANDARD_LVL2_PV_MAX;
		_rateOfFire = ConstantesManager.STANDARD_LVL2_RATE_OF_FIRE + RandOn10Percent(ConstantesManager.STANDARD_LVL2_RATE_OF_FIRE/10); //shooting/sec
		_shootDamage = ConstantesManager.STANDARD_LVL2_SHOOT_DAMAGE;
	}
	
	private void  SetStandardlv3(){
		_pvMax = ConstantesManager.STANDARD_LVL3_PV_MAX;
		_rateOfFire = ConstantesManager.STANDARD_LVL3_RATE_OF_FIRE + RandOn10Percent(ConstantesManager.STANDARD_LVL3_RATE_OF_FIRE/10); //shooting/sec
		_shootDamage = ConstantesManager.STANDARD_LVL3_SHOOT_DAMAGE;
	}
}

