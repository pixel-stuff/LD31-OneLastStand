using UnityEngine;
using System.Collections;

public class TurretTextureManager : MonoBehaviour{

	public string _pathFolderRoot = "Turret";
	
	public Enum_StateTurret _enumStateTurret;
	public Enum_TurretType _enumTurretType;
	
	public UITexture _currentTexture;
	
	// Use this for initialization
	void Start (){
		_enumTurretType = Enum_TurretType.None;
		_enumStateTurret = Enum_StateTurret.TurretNone;
	}
	// Update is called once per frame
	void Update (){
		string pathTexture = "";


		if (_enumStateTurret == Enum_StateTurret.TurretDestroy || _enumStateTurret == Enum_StateTurret.TurretNone) {
						pathTexture = _pathFolderRoot + "/None/" + _enumStateTurret;
		} else {
				pathTexture = _pathFolderRoot + "/" + _enumTurretType.ToString () + "/" + _enumStateTurret.ToString ();
		}

		_currentTexture.mainTexture = Resources.Load<Texture2D> (pathTexture);
	}
	

	public void changeStateTurret(Enum_StateTurret state){
		_enumStateTurret = state;
	}

	public void changeTypeTurret(Enum_TurretType type){
		_enumTurretType = type;
	}
}

