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




	Vector2 _zonePop2; 
	Vector2 _zonePop3; 
	Vector2 _zonePop1; 


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
			GameObject newHunt = (GameObject) Instantiate(_prefabHunter,Vector3.zero,Quaternion.identity);
			newHunt.transform.parent = this.transform;
			newHunt.gameObject.SetActive(false);
			_listHunter.Add(newHunt);
				}

		for (int i=0; i<nbFrigate; i++) {
			GameObject newFrigate = (GameObject) Instantiate(_prefabFrigate,Vector3.zero,Quaternion.identity);
			newFrigate.transform.parent = this.transform;
			newFrigate.gameObject.SetActive(false);
			_listFrigate.Add(newFrigate);
		}


		for (int i=0; i<nbCruiser; i++) {
			GameObject newCruiser = (GameObject) Instantiate(_prefabCruiser,Vector3.zero,Quaternion.identity);
			newCruiser.transform.parent = this.transform;
			newCruiser.gameObject.SetActive(false);
			_listCruiser.Add(newCruiser);
		}

	}
	// Use this for initialization
	void Start () {
		_zonePop1 = ConstantesManager.POP_POINT_1;
		_zonePop2 = ConstantesManager.POP_POINT_2;
		_zonePop3 = ConstantesManager.POP_POINT_3;


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
