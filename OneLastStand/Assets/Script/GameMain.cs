using UnityEngine;
using System.Collections;

public class GameMain : MonoBehaviour {

	EnnemiManager _ennemiManager;
	PlayerManager _playerManager;

	public GameObject _playerPrefab;
	public GameObject _ennemiPrefab;
	public GameObject _BottomLeftAnchorPrefab;
	public GameObject _BottomAnchorPrefab;

	public GameObject _GameOverLabel;
	public GameObject _ConstructionPhaseLabel;
	public GameObject _TutoLabel;

	Enum_StateGame _enumStateGame;

	bool _StartShootCalled = false;

	private float _timeGameOverStart;
	public float _timeInGameOver = 5;//sec
	
	private float _timeConstructionStart;
	public float _timeInConstruction = 2;//sec

	private float _timeTutoStart;
	public float _timeInTuto = 8;//sec

	// Use this for initialization
	void Start () {
		_ennemiManager = new EnnemiManager ();
		_playerManager = new PlayerManager ();
		_enumStateGame = Enum_StateGame.Tuto;
		StartTuto ();


		_playerManager = ((GameObject)Instantiate(_playerPrefab, _BottomLeftAnchorPrefab.transform.position,Quaternion.identity)).GetComponent<PlayerManager>();
		_playerManager.transform.parent = _BottomLeftAnchorPrefab.transform;

		_ennemiManager = ((GameObject)Instantiate(_ennemiPrefab, this.transform.position,Quaternion.identity)).GetComponent<EnnemiManager>();
		_ennemiManager.transform.parent = this.transform;

		//StartShoot ();
	}
	
	void RestartGame(){
		_enumStateGame = Enum_StateGame.Shoot;
		_StartShootCalled = false;
		_playerManager.Initialize();
		_ennemiManager.Initialize();
		
	}
	
	// Update is called once per frame
	void Update () {
		switch (_enumStateGame) {
			case Enum_StateGame.Construction:
				UpdateConstruction();
			break;
		case Enum_StateGame.Tuto:
				UpdateTuto();
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

	void StartTuto(){
		_timeTutoStart = Time.time;
		_GameOverLabel.SetActive(false);
		_ConstructionPhaseLabel.SetActive(false);
		_TutoLabel.SetActive (true);
	}

	void UpdateTuto ()
	{
		if (Time.time - _timeInTuto >= _timeInTuto) {
			_enumStateGame = Enum_StateGame.Shoot;
		}
	}

	public void StartShoot(){
		//Debug.Log ("STARTSHOOT GAMEMAIN");
		_GameOverLabel.SetActive(false);
		_ConstructionPhaseLabel.SetActive(false);
		_TutoLabel.SetActive (false);
		
		_enumStateGame = Enum_StateGame.Shoot;
		_ennemiManager.StartShoot ();
		_playerManager.StartShoot ();
		_StartShootCalled = true;
	}
	
	public void StartConstruction(){
		//Debug.Log ("STARTCONSTRUCTION GAMEMAIN");
		_GameOverLabel.SetActive(false);
		_ConstructionPhaseLabel.SetActive(true);
		_ConstructionPhaseLabel.GetComponent<UILabel> ().text = "Wave " +  _playerManager._nbVague + " Clear";
		_TutoLabel.SetActive (false);
		
		_enumStateGame = Enum_StateGame.Construction;
		_ennemiManager.StartConstruction ();
		_playerManager.StartConstruction ();
		
		_StartShootCalled = false;
		
	}

	void UpdateConstruction () {
		if(Time.time - _timeConstructionStart >= _timeInConstruction){
			StartShoot();
		}
		
		_ennemiManager.UpdateConstruction ();
		_playerManager.UpdateConstruction ();
		
	}

	void UpdateDead(){
		if(Time.time - _timeGameOverStart >= _timeInGameOver){
			RestartGame();
		}
	}

	void UpdateShoot () {
		if (!_StartShootCalled) {
			StartShoot();
			return;
		}

		if (!ConstantesManager.IS_TURRET_INITIALIZE) {
			return;
		}

		if (IsPlayerDead ()) {
			_enumStateGame = Enum_StateGame.Dead;
			DisplayDead();
			return;
		}

		if (IsPlayerWin ()) {
			DisplayConstruction();
			StartConstruction();
		}


		_ennemiManager.UpdateShoot ();
		_playerManager.UpdateShoot ();
	}
	
	void DisplayConstruction(){
		//Debug.Log ("GAMEOVER");
		
		_GameOverLabel.SetActive(false);
		_ConstructionPhaseLabel.SetActive(true);
		_TutoLabel.SetActive (false);
		
		_timeConstructionStart = Time.time;
	}

	void DisplayDead(){
		//Debug.Log ("GAMEOVER");
		
		_GameOverLabel.SetActive(true);
		_ConstructionPhaseLabel.SetActive(false);
		_TutoLabel.SetActive (false);
		_timeGameOverStart = Time.time;
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
