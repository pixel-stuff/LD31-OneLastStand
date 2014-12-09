using UnityEngine;
using System.Collections;

public class FullScreenOff : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(Screen.fullScreen){
			Screen.fullScreen = false;
		}
		Destroy(this);
	}
}
