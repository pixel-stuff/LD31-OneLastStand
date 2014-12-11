using UnityEngine;
using System.Collections;

public class BasicTurretClickScipt : MonoBehaviour {
	public int NTurret;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnClick(){
		GameObject.FindGameObjectWithTag("UI").GetComponent<UIManager2> ().setTurretState(NTurret);
		
		
	}
}
