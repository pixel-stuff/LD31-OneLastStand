using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour{

	ResourcesManager _resourcesManager;
	City _city;
	List<Truck> _listTruck;
	Decharge _decharge;
	Score _score;


	public PlayerManager () {
		_resourcesManager = new ResourcesManager ();
		_listTruck = new List<Truck>();
		_decharge = new Decharge ();
		_score = new Score ();
	}
	
	public void UpdateShoot(){
		_resourcesManager.UpdateShoot ();
		_decharge.UpdateShoot ();
		_score.UpdateShoot ();
		foreach (Truck tur in _listTruck) {
			tur.UpdateShoot();
		}
	}
	
	public void UpdateConstruction(){
		_resourcesManager.UpdateConstruction ();
		_decharge.UpdateConstruction ();
		_score.UpdateConstruction ();
		foreach (Truck tur in _listTruck) {
			tur.UpdateConstruction();
		}
	}

	static public void AddToScore(){
		Debug.Log ("AddToScore en cours de construction");
	}

}
