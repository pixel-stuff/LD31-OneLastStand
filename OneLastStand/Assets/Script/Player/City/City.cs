using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class City : MonoBehaviour{

	public int _pv;

	List<Turret> _listTurret;
	
	public GameObject _prefabStandardTurret;
	public GameObject _prefabEMPTurret;
	public GameObject _prefabDisintegratorTurret;

	public City(){
		_listTurret = new List<Turret>();
		//_listTurret.Add

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



	static public Transform getTransform(){

	}
}

