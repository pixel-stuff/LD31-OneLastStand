using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class City : MonoBehaviour{

	public int _pv;

	List<Turret> _listTurret;
	
	public GameObject _prefabTurret;

	public int _nombreTurret = 4; 

	void Start(){
		_listTurret = new List<Turret>();

		for (int i=0; i<_nombreTurret; i++) {
			GameObject turret = (GameObject)Instantiate (_prefabTurret, Vector2.zero, Quaternion.identity);
			turret.name += i;
			turret.transform.parent = this.transform;
			_listTurret.Add (turret.GetComponent<Turret>());
		}

	}
	
	public void UpdateShoot(){
		foreach (Turret tur in _listTurret) {
			tur.UpdateShoot();
		}
	}

	public void UpdateConstruction(){
		foreach (Turret tur in _listTurret) {
			tur.UpdateConstruction();
		}
	}



}

