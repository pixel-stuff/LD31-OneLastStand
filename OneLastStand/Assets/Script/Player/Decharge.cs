using UnityEngine;
using System.Collections;

public class Decharge : MonoBehaviour{

	public int _quantiteFragment;

	public GameObject _labelPrefab;



	void Start(){
		_quantiteFragment = 0;
	}
	
	public void UpdateShoot (){
	
	}

	public void UpdateConstruction (){
		
	}

	public void addFragment(int frag){
		_quantiteFragment += frag;
		GameObject label = (GameObject)Instantiate (_labelPrefab, new Vector2 (30, 30), Quaternion.identity);
		label.transform.parent = this.transform;
		label.GetComponent<UILabel> ().color = ConstantesManager.FRAGMENT_LABEL_COLOR;
		label.GetComponent<UILabel> ().text = "" + frag;
	}

	public void subFragment(int frag){
		_quantiteFragment -= frag;
		GameObject label = (GameObject)Instantiate (_labelPrefab, new Vector2 (30, 30), Quaternion.identity);
		label.transform.parent = this.transform;
		label.GetComponent<UILabel> ().color = ConstantesManager.FRAGMENT_LABEL_COLOR;
		label.GetComponent<UILabel> ().text = "" + frag;
	}
}

