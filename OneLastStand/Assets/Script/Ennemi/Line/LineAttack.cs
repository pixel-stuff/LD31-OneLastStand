using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LineAttack : MonoBehaviour{

	List<GameObject> _listHunter=null;
	List<GameObject> _listFrigate=null;
	List<GameObject> _listCruiser=null;

	GameObject _ContainerLienAttack;

	public GameObject _prefabHunter;
	public GameObject _prefabFrigate;
	public GameObject _prefabCruiser;




	public Vector2 _zonePop2; 
	public Vector2 _zonePop3; 
	public Vector2 _zonePop1; 
	public float  _errorMargePop;


	private float _spawnCooldown=0.0f;
	public float _frequencePop;
	public float _errorFrequencePop;


	private bool _spawnPossible=false;

	public LineAttack(){
	}



	public void setShips(int nbHunter,int nbFrigate, int nbCruiser){
		Start ();
		if (_listHunter != null) { // if instancier
			_listHunter.Clear();
			_listFrigate.Clear();
			_listCruiser.Clear();
				}

		_listHunter = new List<GameObject>();
		_listFrigate = new List<GameObject>();
		_listCruiser = new List<GameObject>();

		for (int i=0; i<nbHunter; i++) {
			GameObject newHunt = (GameObject) Instantiate(_prefabHunter,getPositionSpawn(),Quaternion.identity);
			newHunt.transform.parent = this.transform;
			newHunt.gameObject.SetActive(false);
			_listHunter.Add(newHunt);
				}

		for (int i=0; i<nbFrigate; i++) {
			GameObject newFrigate = (GameObject) Instantiate(_prefabFrigate,getPositionSpawn(),Quaternion.identity);
			newFrigate.transform.parent = this.transform;
			newFrigate.gameObject.SetActive(false);
			_listFrigate.Add(newFrigate);
		}


		for (int i=0; i<nbCruiser; i++) {
			GameObject newCruiser = (GameObject) Instantiate(_prefabCruiser,getPositionSpawn(),Quaternion.identity);
			newCruiser.transform.parent = this.transform;
			newCruiser.gameObject.SetActive(false);
			_listCruiser.Add(newCruiser);
		}
		_spawnPossible = true;
	}

	Vector3 getPositionSpawn(){
		//TODO rendre ça plus modulable
		float margeX = Random.Range (-_errorMargePop, _errorMargePop);
		float margeY = Random.Range (-_errorMargePop, _errorMargePop);
		int pointPop = Random.Range (0, 3);
		//Debug.Log (pointPop);
		Vector2 vecBase;
		if (pointPop == 0) {
			vecBase=_zonePop1;
		} else if (pointPop == 1) {
			vecBase=_zonePop2;
		} else {
			vecBase=_zonePop3;
		}

		return new Vector3 (this.transform.position.x+vecBase.x + margeX,this.transform.position.y+ vecBase.y + margeY, 0);


		}
	// Use this for initialization
	void Start () {
		_zonePop1 = ConstantesManager.POP_POINT_1;
		_zonePop2 = ConstantesManager.POP_POINT_2;
		_zonePop3 = ConstantesManager.POP_POINT_3;
		_errorMargePop = ConstantesManager.ERROR_MARGE_POP;

		_frequencePop = ConstantesManager.FREQUENCE_POP;
	
		_errorFrequencePop = ConstantesManager.VARIANCE_FREQUENCE_POP_PERCENT;



	}

	public void Initialize ()
	{
		_zonePop1 = ConstantesManager.POP_POINT_1;
		_zonePop2 = ConstantesManager.POP_POINT_2;
		_zonePop3 = ConstantesManager.POP_POINT_3;
		_errorMargePop = ConstantesManager.ERROR_MARGE_POP;
		
		_frequencePop = ConstantesManager.FREQUENCE_POP;
		
		_errorFrequencePop = ConstantesManager.VARIANCE_FREQUENCE_POP_PERCENT;
		
		foreach(GameObject obj in _listHunter){
			if(obj != null){
				obj.GetComponent<Hunter>()._onDestroy = true;
			}
		}
		
		foreach(GameObject obj in _listFrigate){
			if(obj != null){
				obj.GetComponent<Frigate>()._onDestroy = true;
			}
		}
		
		foreach(GameObject obj in _listCruiser){
			if(obj != null){
				obj.GetComponent<Cruiser>()._onDestroy = true;
			}
		}
		
		_listHunter.Clear();
		_listFrigate.Clear();
		_listCruiser.Clear();
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UpdateShoot(){
		//Debug.Log (this.gameObject.name + " UpdateShoot ");

		if (_spawnCooldown > 0.0f) {

			_spawnCooldown -= Time.deltaTime;
				}
		if (_spawnCooldown <= 0.0f && _spawnPossible) {

			_spawnCooldown = Random.Range(_frequencePop*(1-_errorFrequencePop),_frequencePop*(1+_errorFrequencePop));


			int tabRand =Random.Range(0,2);
			if (SpawnPossible(tabRand)){
				SpawnFirst(tabRand);
			}else{
				int tabRand2 = RandomRangeExcept(0,2,tabRand);
				if (SpawnPossible(tabRand2)){
					SpawnFirst(tabRand2);
				}else{
					if (SpawnPossible(5-(tabRand+tabRand2))){
						SpawnFirst(5-(tabRand+tabRand2));
					}else{
						_spawnPossible=false;
					}

					}

			}
		}

		//Logique de passage des upadate shoot
		foreach (GameObject ship in _listHunter) {
			if (ship != null) {
				if (ship.gameObject.activeSelf) {
				ship.gameObject.GetComponent<Hunter>().UpdateShoot();

				}
			}
		}
		foreach (GameObject ship in _listFrigate) {
			if (ship != null) {
				if (ship.gameObject.activeSelf) {
					ship.gameObject.GetComponent<Frigate>().UpdateShoot();
				}
			}
		}
		foreach (GameObject ship in _listCruiser) {
			if (ship != null) {
				if (ship.gameObject.activeSelf) {
					ship.gameObject.GetComponent<Cruiser>().UpdateShoot();
				}
			}
		}

					}

	public void UpdateConstruction(){
		}

	public bool SpawnPossible(int selecttab){

		List<GameObject> select = null;
		if (selecttab == 0) {
			select=_listHunter;
		} else if (selecttab == 1) {
			select=_listFrigate;
		} else {
			select=_listCruiser;
		}

		foreach (GameObject ship in select) {
			if(ship!=null){

						if (!ship.gameObject.activeSelf) {
								return true;
						}
			}
				}
		return false;
		}

	public void SpawnFirst(int selecttab){
		
		List<GameObject> select = null;
		if (selecttab == 0) {
			select=_listHunter;
		} else if (selecttab == 1) {
			select=_listFrigate;
		} else {
			select=_listCruiser;
		}
		
		foreach (GameObject ship in select) {
			if(ship!=null){
			if (!ship.gameObject.activeSelf) {
				ship.gameObject.SetActive(true);
				return ;
			}
			}
		}

	}

	public GameObject getCloserShip(Transform refe){
		GameObject returnShip=null;
		float minDistance = float.MaxValue;
		float distance;
		foreach (GameObject ship in _listHunter) {
			if(ship!=null){
			if (ship.gameObject.activeSelf) {
			distance = Vector3.Distance(refe.position,ship.transform.position);
			if(distance < minDistance){
				minDistance=distance;
				returnShip=ship;
			}
			}
			}
		}

		foreach (GameObject ship in _listFrigate) {
			if(ship!=null){
			if (ship.gameObject.activeSelf) {
			distance = Vector3.Distance(refe.position,ship.transform.position);
			if(distance < minDistance){
				minDistance=distance;
				returnShip=ship;
			}
			}
			}
		}

		foreach (GameObject ship in _listCruiser) {
			if(ship!=null){
			if (ship.gameObject.activeSelf) {
			distance = Vector3.Distance(refe.position,ship.transform.position);
			if(distance < minDistance){
				minDistance=distance;
				returnShip=ship;
			}
			}
			}
			
		}

		return returnShip;

	}





	public int RandomRangeExcept (int min, int max, int except) {
		int number;
		do {
			number = Random.Range (min, max);
		} while (number == except);
		return number;
	}

	public bool didOneLeft(){
		foreach (GameObject ship in _listHunter) {
			if(ship!=null){
			return true;
			}
				}
		foreach (GameObject ship in _listFrigate) {
			if(ship!=null){
			return true;
			}
		}
		foreach (GameObject ship in _listCruiser) {
			if(ship!=null){
			return true;
			}
		}
		return false;

	}

}
