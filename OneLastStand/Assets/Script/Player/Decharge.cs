using UnityEngine;
using System.Collections;

public class Decharge : MonoBehaviour{

	public int _quantiteFragment;

	public GameObject _labelPrefab;



	void Start(){
		_quantiteFragment = 0;
	}

	public void StartShoot ()
	{
	}

	public void StartConstruction ()
	{
	}
	
	public void UpdateShoot (){
	
	}

	public void UpdateConstruction (){
		
	}

	public void addFragment(int frag){
		_quantiteFragment += frag;
		GameObject label = (GameObject)Instantiate (_labelPrefab,this.transform.position, Quaternion.identity);
		label.transform.parent = this.transform;
		label.transform.localPosition =  new Vector3 (30, 30, 0);
		label.GetComponent<UILabel> ().color = ConstantesManager.FRAGMENT_LABEL_COLOR;
		label.GetComponent<UILabel> ().text = "" + frag;
	}

	public void subFragment(int frag){
		_quantiteFragment -= frag;
		GameObject label = (GameObject)Instantiate (_labelPrefab, this.transform.position, Quaternion.identity);
		label.transform.parent = this.transform;
		label.transform.localPosition =  new Vector3 (30, 30, 0);
		label.GetComponent<UILabel> ().color = ConstantesManager.FRAGMENT_LABEL_COLOR;
		label.GetComponent<UILabel> ().text = "" + frag;
	}
}

