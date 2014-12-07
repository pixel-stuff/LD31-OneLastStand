using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Turret : MonoBehaviour{

	static public int _idStatic = 0;

	public int _id;
	public int _pv;
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
		_pv = ConstantesManager.CITY_PV;

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
		//TODO setvariable memebre de bullet
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
	}

	public void ChangeStateTurret(Enum_StateTurret newState){
		_enumOldStateTurret = _enumCurrentStateTurret;
		_enumCurrentStateTurret = newState;
		_turretTextureManager.changeStateTurret (_enumCurrentStateTurret);
	}
}

