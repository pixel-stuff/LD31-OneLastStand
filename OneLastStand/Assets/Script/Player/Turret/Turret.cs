using UnityEngine;
using System.Collections;

public abstract class Turret : MonoBehaviour{

	public int _pv;
	public TurretTextureManager _turretTextureManager;
	public Enum_StateTurret _enumStateTurret;
	public Enum_TurretType _enumTypeTurret;

	void Start(){
		_enumStateTurret = Enum_StateTurret.TurretNone;
		_enumTypeTurret = Enum_TurretType.None;
	}
	
	public abstract void UpdateShoot ();
	public abstract void UpdateConstruction ();

	public void Repare(int lifeAdding){
		_pv += lifeAdding;
	}

	public void getHit(int degat){
		_pv -= degat;
		if (_pv <= 0) {
			_pv =0;
			_enumStateTurret = Enum_StateTurret.TurretDestroy;
			_turretTextureManager.changeLvl(_enumStateTurret);
		}
	}

	//public void ChangeState(

}

