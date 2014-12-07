using UnityEngine;
using System.Collections;

public class GameMain : MonoBehaviour {

	EnnemiManager _ennemiManager;
	PlayerManager _playerManager;
	UIManager _uiManager;

	public GameObject _playerPrefab;
	public GameObject _ennemiPrefab;

	Enum_StateGame _enumStateGame;

	// Use this for initialization
	void Start () {
		_ennemiManager = new EnnemiManager ();
		_playerManager = new PlayerManager ();
		_uiManager = new UIManager ();
		_enumStateGame = Enum_StateGame.Shoot;
		StartShoot ();


		_playerManager = ((GameObject)Instantiate(_playerPrefab, Vector2.zero,Quaternion.identity)).GetComponent<PlayerManager>();
		_playerManager.transform.parent = this.transform;

		_ennemiManager = ((GameObject)Instantiate(_ennemiPrefab, Vector2.zero,Quaternion.identity)).GetComponent<EnnemiManager>();
		_ennemiManager.transform.parent = this.transform;
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
		
	}
	
	public void StartConstruction(){
		
	}

	void UpdateConstruction () {
		_ennemiManager.UpdateConstruction ();
		_playerManager.UpdateConstruction ();
		_uiManager.UpdateConstruction ();
	}

	void UpdateShoot () {
		_ennemiManager.UpdateShoot ();
		_playerManager.UpdateShoot ();
		_uiManager.UpdateShoot ();
	}
}
