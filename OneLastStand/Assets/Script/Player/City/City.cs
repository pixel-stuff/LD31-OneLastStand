using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class City : MonoBehaviour{
	
	public int _pv;
	public int _pvMax;
	List<Turret> _listTurret;
	
	public GameObject _prefabTurret;
	
	public GameObject _labelEphemerePrefab;
	
	public int _nombreTurret = 4; 
	
	public Enum_StateCity _enumStateCity;
	
	public GameObject _truckPrefab;
	public Truck _truck;
	
	public int _quantiteFrag;
	
	public float _timeMinInShootState=4f;
	float _timeStartShootState;
	
	bool _lock=false;
	
	
	void Start(){
		_quantiteFrag = 600;
		_timeMinInShootState = ConstantesManager.TIME_MIN_IN_SHOOT_STATE;
		
		
		GameObject truck = (GameObject)Instantiate (_truckPrefab, this.transform.position, Quaternion.identity);
		
		_truck = truck.GetComponent<Truck> ();
		_truck.transform.parent = this.transform;
		_listTurret = new List<Turret>();
		
		for (int i=0; i<_nombreTurret; i++) {
			GameObject turret = (GameObject)Instantiate (_prefabTurret, this.transform.position, Quaternion.identity);
			turret.name += i;
			turret.transform.parent = this.transform;
			_listTurret.Add (turret.GetComponent<Turret>());
		}
		
		
		_quantiteFrag = 600;
		_pv = ConstantesManager.CITY_PV_MAX;
		_pvMax = ConstantesManager.CITY_PV_MAX;
		_enumStateCity = Enum_StateCity.Fighting;
		
		_listTurret [0].transform.localPosition = ConstantesManager.TURRET_1_LOCAL_POSITION;
		_listTurret [1].transform.localPosition = ConstantesManager.TURRET_2_LOCAL_POSITION;
		_listTurret [2].transform.localPosition = ConstantesManager.TURRET_3_LOCAL_POSITION;
		_listTurret [3].transform.localPosition = ConstantesManager.TURRET_4_LOCAL_POSITION;
		
		_listTurret [0]._enumIdTurret = Enum_IdTurret.Turret1;
		_listTurret [1]._enumIdTurret = Enum_IdTurret.Turret2;
		_listTurret [2]._enumIdTurret = Enum_IdTurret.Turret3;
		_listTurret [3]._enumIdTurret = Enum_IdTurret.Turret4;
		
		_listTurret[3].Upgrade();
		
		ConstantesManager.IS_TURRET_INITIALIZE = true;
		
	}
	
	public void Initialize ()
	{
		Debug.Log ("INITIALIZE CITY");
		_quantiteFrag = 600;
		_pv = ConstantesManager.CITY_PV_MAX;
		_pvMax = ConstantesManager.CITY_PV_MAX;
		_enumStateCity = Enum_StateCity.Fighting;
		
		_listTurret [0].transform.localPosition = ConstantesManager.TURRET_1_LOCAL_POSITION;
		_listTurret [1].transform.localPosition = ConstantesManager.TURRET_2_LOCAL_POSITION;
		_listTurret [2].transform.localPosition = ConstantesManager.TURRET_3_LOCAL_POSITION;
		_listTurret [3].transform.localPosition = ConstantesManager.TURRET_4_LOCAL_POSITION;
		
		_listTurret [0]._enumIdTurret = Enum_IdTurret.Turret1;
		_listTurret [1]._enumIdTurret = Enum_IdTurret.Turret2;
		_listTurret [2]._enumIdTurret = Enum_IdTurret.Turret3;
		_listTurret [3]._enumIdTurret = Enum_IdTurret.Turret4;
		
		ConstantesManager.IS_TURRET_INITIALIZE = true;
		
		_truck.Initialize ();
		for (int i=0; i<_nombreTurret; i++) {
			_listTurret[i].Initialize();
		}
	}
	
	public void StartShoot(){
		_enumStateCity = Enum_StateCity.Fighting;
		_lock=false;
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
		int degatRest = degat;
		
		for (int i=0;i<_listTurret.Count;i++) {
			if(_listTurret[i]._pv > 0 && _listTurret[i]._enumCurrentTurretType != Enum_TurretType.None){
				Debug.Log("turret i"+i+" turret count"+_listTurret.Count);
				_listTurret[i].getHit(degat/_nombreTurret);
				float sub = degat/_nombreTurret;
				if(sub%10 >= 0.5){
					sub = sub+1;
				}
				degatRest -= (int)sub;
				//Debug.Log ("Rest : " + degatRest);
			}
		}
		if (degatRest < degat / _nombreTurret) {
			degatRest = 0;
		}
		
		_pv -= degatRest;
		if (_pv <= 0) {
			_pv =0;
			_enumStateCity = Enum_StateCity.Destroy;
		}
		//Debug.Log ("City take Damage -" + degat);
		SubLifeLabel (degatRest);
	}
	
	public void Repare(int lifeAdding){
		_pv += lifeAdding;
		
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
		
		if (!_lock) {
			_timeStartShootState = Time.time;
			_lock=true;
		}
		
		float var = Time.time - _timeStartShootState;
		
		if (var >= _timeMinInShootState && _lock) {
			
			CheckVictoryCondition ();
			
		}
		
		for (int i=0;i<_listTurret.Count;i++) {
			_listTurret[i].UpdateShoot();
		}
		
		
	}
	
	private void CheckDefeateCondition (){
		if (_pv <= 0) {
			_enumStateCity = Enum_StateCity.Destroy;
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
	
	
	
	
	public void AddLifeLabel(int life){
		GameObject label = (GameObject)Instantiate (_labelEphemerePrefab, this.transform.position , Quaternion.identity);
		label.transform.parent = this.transform;
		label.transform.localPosition = new Vector2 (30, 100);
		label.GetComponent<UILabel> ().color = ConstantesManager.LIFE_LABEL_COLOR;
		label.GetComponent<UILabel> ().text = "+" + life;
	}
	
	public void SubLifeLabel(int life){
		if (life <= 0) {
			return;
		}
		
		GameObject label = (GameObject)Instantiate (_labelEphemerePrefab, this.transform.position , Quaternion.identity);
		label.transform.parent = this.transform;
		label.transform.localPosition = new Vector2 (30, 100);
		label.GetComponent<UILabel> ().color = ConstantesManager.LIFE_LABEL_COLOR;
		label.GetComponent<UILabel> ().text = "-" + life;
	}
	
	public void AddToFragmentPlayer(int frag){
		_quantiteFrag += frag;
		GameObject label = (GameObject)Instantiate (_labelEphemerePrefab, this.transform.position , Quaternion.identity);
		label.transform.parent = this.transform;
		label.transform.localPosition = new Vector2 (30, 100);
		label.GetComponent<UILabel> ().color = ConstantesManager.FRAGMENT_LABEL_COLOR;
		label.GetComponent<UILabel> ().text = "+" + frag;
	}
	
	public void SubToFragmentPlayer(int frag){
		_quantiteFrag -= frag;
		GameObject label = (GameObject)Instantiate (_labelEphemerePrefab, this.transform.position , Quaternion.identity);
		label.transform.parent = this.transform;
		label.transform.localPosition = new Vector2 (30, 100);
		label.GetComponent<UILabel> ().color = ConstantesManager.FRAGMENT_LABEL_COLOR;
		label.GetComponent<UILabel> ().text = "-" + frag;
	}
	
	
	public void CheckVictoryCondition (){
		if (_enumStateCity == Enum_StateCity.Destroy)
			return;
		
		int numberTurretWithNoTarget = 0;
		
		foreach (Turret tur in _listTurret) {
			if( tur.getTarget() == null){//_enumTurretAim == Enum_TurretAim.NoEnnemiFound){
				numberTurretWithNoTarget++;
			}
		}
		
		
		if (numberTurretWithNoTarget >= _nombreTurret) {
			_enumStateCity = Enum_StateCity.Winning;
			//Debug.Log ("City REPERE WIN");
		}/*else{
			int _nombreNull = 0;
			foreach (Turret tur in _listTurret) {
				if( tur.getTarget() == null){
					_nombreNull++;
				}
			}
			
			if(_nombreNull >= _nombreTurret){
				_enumStateCity = Enum_StateCity.Winning;
			}
			
		}*/
		
	}
	
	public Turret GetTurretById(Enum_IdTurret enumId){
		foreach (Turret tur in _listTurret) {
			if(tur._enumIdTurret == enumId){
				return tur;
			}
		}
		return null;
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















