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
	public _zonePop1; 
	public _errorMargePop;


	private float spawnCooldown;
	public LineAttack(){
	}


	public void setShips(int nbHunter,int nbFrigate, int nbCruiser){

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

	}

	Vector3 getPositionSpawn(){
		//TODO rendre ça plus modulable
		float margeX = Random.Range (-_errorMargePop, _errorMargePop);
		float margeY = Random.Range (-_errorMargePop, _errorMargePop);
		int pointPop = Random.Range (0, 2);
		Vector2 vecBase;
		if (pointPop == 0) {
			vecBase=_zonePop1;
		} else if (pointPop == 1) {
			vecBase=_zonePop2;
		} else {
			vecBase=_zonePop3;
		}
		return new Vector3 (vecBase.x + margeX, vecBase.y + margeY, 0);


		}
	// Use this for initialization
	void Start () {
		_zonePop1 = ConstantesManager.POP_POINT_1;
		_zonePop2 = ConstantesManager.POP_POINT_2;
		_zonePop3 = ConstantesManager.POP_POINT_3;
		_errorMargePop = ConstantesManager.ERROR_MARGE_POP;
		spawnCooldown = 0f;


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void UpdateShoot(){
		if (spawnCooldown > 0) {
			spawnCooldown -= Time.deltaTime;
				}
		}
	void UpdateConstruction(){
		}
}
