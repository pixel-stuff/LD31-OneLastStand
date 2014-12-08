using UnityEngine;
using System.Collections;

public class BasicIconeScript : MonoBehaviour {
	public GameObject UIManager;
	public int NTurret;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick(){
		UIManager.gameObject.GetComponent<UIManager2> ().setTurretState(NTurret);

		
	}
}
