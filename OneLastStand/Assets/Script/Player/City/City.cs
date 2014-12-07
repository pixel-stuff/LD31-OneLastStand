using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class City : MonoBehaviour{

	public int _pv;

	List<Turret> _listTurret;
	
	public GameObject _prefabTurret;

	public int _nombreTurret = 4; 

	ResourcesManager _resourcesManager;
	List<Truck> _listTruck;
	

	void Start(){
		_resourcesManager = new ResourcesManager ();
		_listTruck = new List<Truck>();
		_pv = ConstantesManager.CITY_PV_MAX;

		_listTurret = new List<Turret>();

		for (int i=0; i<_nombreTurret; i++) {
			GameObject turret = (GameObject)Instantiate (_prefabTurret, Vector2.zero, Quaternion.identity);
			turret.name += i;
			turret.transform.parent = this.transform;
			_listTurret.Add (turret.GetComponent<Turret>());
		}

	}
	
	public void UpdateShoot(){
		if (_listTurret == null) 
						return;

		Debug.Log ("City Update Shoot");
	
		for (int i=0;i<_listTurret.Count;i++) {
			_listTurret[i].UpdateShoot();
		}
		foreach (Truck tur in _listTruck) {
			tur.UpdateShoot();
		}
		_resourcesManager.UpdateShoot ();
	}

	public void UpdateConstruction(){
		foreach (Turret tur in _listTurret) {
			tur.UpdateConstruction();
		}
		foreach (Truck tur in _listTruck) {
			tur.UpdateConstruction();
		}
		_resourcesManager.UpdateConstruction ();
	}



}

