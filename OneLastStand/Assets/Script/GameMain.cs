using UnityEngine;
using System.Collections;

public class GameMain : MonoBehaviour {

	EnnemiManager _ennemiManager;
	PlayerManager _playerManager;

	public GameObject _playerPrefab;
	public GameObject _ennemiPrefab;
	public GameObject _BottomLeftAnchorPrefab;
	public GameObject _BottomAnchorPrefab;

	public GameObject _prefabLabelEphemere;

	Enum_StateGame _enumStateGame;

	bool _StartShootCalled = false;


	// Use this for initialization
	void Start () {
		_ennemiManager = new EnnemiManager ();
		_playerManager = new PlayerManager ();
		_enumStateGame = Enum_StateGame.Shoot;


		_playerManager = ((GameObject)Instantiate(_playerPrefab, _BottomLeftAnchorPrefab.transform.position,Quaternion.identity)).GetComponent<PlayerManager>();
		_playerManager.transform.parent = _BottomLeftAnchorPrefab.transform;

		_ennemiManager = ((GameObject)Instantiate(_ennemiPrefab, this.transform.position,Quaternion.identity)).GetComponent<EnnemiManager>();
		_ennemiManager.transform.parent = this.transform;

		//StartShoot ();
	}
	
	// Update is called once per frame
	void Update () {
		switch (_enumStateGame) {
			case Enum_StateGame.Construction:
				UpdateConstruction();
				break;
			case Enum_StateGame.Shoot:
				UpdateShoot();
				break;
			case Enum_StateGame.Stop:
				Debug.Log("Pause");
				break;
			case Enum_StateGame.Dead:
				UpdateDead();
				break;
			default:
				Debug.Log("Wrong StateGame in GameMain");
				break;
		}
	}

	public void StartShoot(){
		//Debug.Log ("STARTSHOOT GAMEMAIN");
		_enumStateGame = Enum_StateGame.Shoot;
		_ennemiManager.StartShoot ();
		_playerManager.StartShoot ();
	}
	
	public void StartConstruction(){
		//Debug.Log ("STARTCONSTRUCTION GAMEMAIN");
		_enumStateGame = Enum_StateGame.Construction;
		_ennemiManager.StartConstruction ();
		_playerManager.StartConstruction ();
		
	}

	void UpdateConstruction () {

		StartShoot ();
		/*_ennemiManager.UpdateConstruction ();
		_playerManager.UpdateConstruction ();
		_uiManager.UpdateConstruction ();*/
	}

	void UpdateShoot () {
		if (!_StartShootCalled) {
			StartShoot();
			_StartShootCalled = true;
			return;
		}

		if (!ConstantesManager.IS_TURRET_INITIALIZE) {
			return;
		}

		if (IsPlayerDead ()) {

		}

		if (IsPlayerWin ()) {
			StartConstruction();
		}


		_ennemiManager.UpdateShoot ();
		_playerManager.UpdateShoot ();
	}

	void UpdateDead(){

	}

	bool IsPlayerDead(){
		if (_playerManager._enumStatePlayer == Enum_StatePlayer.Dead) {
			//Debug.Log ("GAMEMAIN REPERE DEAD");
			return true;
			
		} else {
			return false;
		}
	}


	bool IsPlayerWin (){
		if (_playerManager._enumStatePlayer == Enum_StatePlayer.Winning) {
			//Debug.Log ("GAMEMAIN REPERE WIN");
			return true;

		} else {
			return false;
		}
	}
}
