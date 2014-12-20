using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {

	public GameMain _gameMain;

	// Use this for initialization
	void Onclick () {

		//Déplacer caméra puis
		_gameMain.enabled = true;
	}
}
