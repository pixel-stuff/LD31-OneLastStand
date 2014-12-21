using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {

	public GameMain _gameMain;
	
	public GameObject _startObject;
	public GameObject _uiManager;
	public GameObject _centerAnchor;
	public GameObject _bottomAnchor;

	// Use this for initialization
	void OnClick () {
		Debug.Log ("coucou");

		//Déplacer caméra puis
		_uiManager.SetActive (true);
		_centerAnchor.SetActive (true);
		_bottomAnchor.SetActive (true);
		_gameMain.enabled = true;
		_startObject.SetActive (false);

	}
}
