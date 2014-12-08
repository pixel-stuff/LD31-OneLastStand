using UnityEngine;
using System.Collections;

public class SelectorButtonClick : MonoBehaviour {

	public GameObject UIManager;
	public int position;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick(){
		UIManager.gameObject.GetComponent<UIManager2> ().SelectorInput(position);
		
		
	}
}
