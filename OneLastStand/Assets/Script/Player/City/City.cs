using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class City : MonoBehaviour{

	public int _pv;

	List<Turret> _listTurret;
	
	public GameObject _prefabTurret;

	public GameObject _labelEphemerePrefab;

	public int _nombreTurret = 4; 

	public Enum_StateCity _enumStateCity;


	void Start(){
		_pv = ConstantesManager.CITY_PV_MAX;
		_enumStateCity = Enum_StateCity.Fighting;

		_listTurret = new List<Turret>();

		for (int i=0; i<_nombreTurret; i++) {
			GameObject turret = (GameObject)Instantiate (_prefabTurret, this.transform.position, Quaternion.identity);
			turret.name += i;
			turret.transform.parent = this.transform;
			_listTurret.Add (turret.GetComponent<Turret>());
		}

		_listTurret [0].transform.localPosition = ConstantesManager.TURRET_1_LOCAL_POSITION;
		_listTurret [1].transform.localPosition = ConstantesManager.TURRET_2_LOCAL_POSITION;
		_listTurret [2].transform.localPosition = ConstantesManager.TURRET_3_LOCAL_POSITION;
		_listTurret [3].transform.localPosition = ConstantesManager.TURRET_4_LOCAL_POSITION;

	}

	public void StartShoot(){
		for (int i=0;i<_listTurret.Count;i++) {
			_listTurret[i].StartShoot();
		}
	}
	
	public void StartConstruction(){
		for (int i=0;i<_listTurret.Count;i++) {
			_listTurret[i].StartConstruction();
		}
	}


	public void getHit(int degat){
		_pv -= degat;
		if (_pv <= 0) {
			_pv =0;
			_enumStateCity = Enum_StateCity.Destroy;
		}
		Debug.Log ("City take Damage -" + degat);
	}
	
	public void UpdateShoot(){
		switch (_enumStateCity) {
		case Enum_StateCity.Fighting:
			
			break;
		case Enum_StateCity.Winning:
			Debug.Log ("CITY WIN");
			break;
		case Enum_StateCity.Destroy:
			Debug.Log ("CITY DESTROY");
			break;
		default:
			Debug.Log ("Wrong _enumStatePlayer in " + this.gameObject.name);
			break;
		}

		if (_enumStateCity != Enum_StateCity.Fighting) 
					return;
		
		CheckVictoryCondition ();
	
		for (int i=0;i<_listTurret.Count;i++) {
			_listTurret[i].UpdateShoot();
		}


	}

	public void UpdateConstruction(){
		/*foreach (Turret tur in _listTurret) {
			tur.UpdateConstruction();
		}
		foreach (Truck tur in _listTruck) {
			tur.UpdateConstruction();
		}
		_resourcesManager.UpdateConstruction ();*/
	}

	public void ShowLifeChange(int life){
		GameObject label = (GameObject)Instantiate (_labelEphemerePrefab, new Vector2 (30, 30), Quaternion.identity);
		label.transform.parent = this.transform;
		label.GetComponent<UILabel> ().color = ConstantesManager.LIFE_LABEL_COLOR;
		label.GetComponent<UILabel> ().text = "" + life;
	}

	
	public void CheckVictoryCondition (){
		if (_enumStateCity == Enum_StateCity.Destroy)
						return;

		int numberTurretWithNoTarget = 0;

		foreach (Turret tur in _listTurret) {
			if( tur._enumTurretAim == Enum_TurretAim.NoEnnemiFound){
				numberTurretWithNoTarget++;
			}
		}

		if (numberTurretWithNoTarget >= _nombreTurret) {
			_enumStateCity = Enum_StateCity.Winning;
		}
	}


	void OnTriggerEnter2D(Collider2D coll){
		Ship ship = coll.gameObject.GetComponent<Ship>();
		ennemiBullet bullet = coll.gameObject.GetComponent<ennemiBullet> ();

		if (ship != null) {
			getHit(ship._degatKamikaze);
			ship._onDestroy=true;
			return;
		}

		if (bullet != null) {
			getHit((int)bullet._pvDamage);
			Destroy(bullet.gameObject);
			return;
		}

	}

}















