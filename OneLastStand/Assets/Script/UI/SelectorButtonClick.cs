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
	
	void OnHover(bool isoVER) {
		if(isoVER){
		
			UIManager.gameObject.GetComponent<UIManager2> ().SelectorOver(position,true,0);
		}else{
			UIManager.gameObject.GetComponent<UIManager2> ().SelectorOver(position,false,0);
		}
	}

	void OnClick(){
		UIManager.gameObject.GetComponent<UIManager2> ().SelectorInput(position);
		
		
	}
}
