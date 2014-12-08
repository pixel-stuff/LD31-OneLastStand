using UnityEngine;
using System.Collections;

public class GameMain : MonoBehaviour {

	EnnemiManager _ennemiManager;
	PlayerManager _playerManager;
	UIManager _uiManager;

	public GameObject _playerPrefab;
	public GameObject _ennemiPrefab;
	public GameObject _uiManagerPrefab;
	public GameObject _BottomLeftAnchorPrefab;
	public GameObject _BottomAnchorPrefab;

	Enum_StateGame _enumStateGame;

	bool _StartShootCalled = false;


	// Use this for initialization
	void Start () {
		_ennemiManager = new EnnemiManager ();
		_playerManager = new PlayerManager ();
		_uiManager = new UIManager ();
		_enumStateGame = Enum_StateGame.Shoot;


		_playerManager = ((GameObject)Instantiate(_playerPrefab, _BottomLeftAnchorPrefab.transform.position,Quaternion.identity)).GetComponent<PlayerManager>();
		_playerManager.transform.parent = _BottomLeftAnchorPrefab.transform;

		_ennemiManager = ((GameObject)Instantiate(_ennemiPrefab, this.transform.position,Quaternion.identity)).GetComponent<EnnemiManager>();
		_ennemiManager.transform.parent = this.transform;

		
		_uiManager = ((GameObject)Instantiate(_uiManagerPrefab, _BottomAnchorPrefab.transform.position,Quaternion.identity)).GetComponent<UIManager>();
		_uiManager.transform.parent = _BottomAnchorPrefab.transform;

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
			default:
				Debug.Log("Wrong StateGame in GameMain");
				break;
		}
	}

	public void StartShoot(){
		Debug.Log ("STARTSHOOT GAMEMAIN");
		_enumStateGame = Enum_StateGame.Shoot;
		_ennemiManager.StartShoot ();
		_playerManager.StartShoot ();
		_uiManager.StartShoot ();
	}
	
	public void StartConstruction(){
		Debug.Log ("STARTCONSTRUCTION GAMEMAIN");
		_enumStateGame = Enum_StateGame.Construction;
		_ennemiManager.StartConstruction ();
		_playerManager.StartConstruction ();
		_uiManager.StartConstruction ();
		
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
		

		if (IsPlayerWin ()) {
			StartConstruction();
		}

		_ennemiManager.UpdateShoot ();
		_playerManager.UpdateShoot ();
		_uiManager.UpdateShoot ();
	}

	bool IsPlayerWin (){
		if (_playerManager._enumStatePlayer == Enum_StatePlayer.Winning) {
			//Debug.Log ("GAMEMAI REPERE WIN");
			return true;

		} else {
			return false;
		}
	}
}
