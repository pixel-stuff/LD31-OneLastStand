using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour{


	City _city;
	//Decharge _decharge;
	//Score _score;

	public GameObject _cityPrefab;



	void Start () {

		_city = ((GameObject)Instantiate (_cityPrefab, Vector2.zero, Quaternion.identity)).GetComponent<City>();
		_city.transform.parent = this.transform;
	}
	
	public void UpdateShoot(){
		Debug.Log ("PlayerManager UpdateShoot");
		//_decharge.UpdateShoot ();
		//_score.UpdateShoot ();
		_city.UpdateShoot ();
	}
	
	public void UpdateConstruction(){
		//_decharge.UpdateConstruction ();
		//_score.UpdateConstruction ();
		_city.UpdateConstruction ();
	}

	static public void AddToScore(){
		Debug.Log ("AddToScore en cours de construction");
	}

}
