using UnityEngine;
using System.Collections;

public class TurretTextureManager : MonoBehaviour{

	public string _pathFolderRoot = "Turret";
	
	public Enum_StateTurret _enumStateTurret;
	public Enum_TurretType _enumTurretType;
	
	private UITexture _currentTurretTexture;
	private UITexture _currentBaseTexture;

	public GameObject _TurretTexturePrefab;
	public GameObject _TurretBasePrefab;

	// Use this for initialization
	void Start (){
		_currentTurretTexture = ((GameObject)Instantiate(_TurretTexturePrefab, Vector2.zero,Quaternion.identity)).GetComponent<UITexture>();

		_currentBaseTexture = ((GameObject)Instantiate(_TurretBasePrefab, Vector2.zero,Quaternion.identity)).GetComponent<UITexture>();

		_enumTurretType = Enum_TurretType.None;
		_enumStateTurret = Enum_StateTurret.TurretNone;
	}
	// Update is called once per frame
	void Update (){
		string pathTextureTurret = "";
		string pathTextureBase = "";


		if (_enumStateTurret == Enum_StateTurret.TurretDestroy) {
			pathTextureBase = _pathFolderRoot + "/" + _enumTurretType.ToString() + "/" + "TurrentDestroy";
			pathTextureTurret = "";
		} else {
			pathTextureBase = _pathFolderRoot + "/" + _enumTurretType.ToString() + "/" + "TurrentBase";
			pathTextureTurret = _pathFolderRoot + "/" + _enumTurretType.ToString () + "/" + _enumStateTurret.ToString ();
		}

		_currentTurretTexture.mainTexture = Resources.Load<Texture2D> (pathTextureTurret);
	}
	

	public void changeStateTurret(Enum_StateTurret state){
		_enumStateTurret = state;
	}

	public void changeTypeTurret(Enum_TurretType type){
		_enumTurretType = type;
	}
}

