using UnityEngine;
using System.Collections;

public class EnnemiManager : MonoBehaviour {


	public GameObject _prefabContainerLineAttack;

	public GameObject _containerLineAttack;
	public LineAttackManager _ligneAttackManager;

	public LineAttack _lineAttack1;
	public LineAttack _lineAttack2;
	public LineAttack _lineAttack3;

	public LineAttack _toto;

	public bool _alreadyInit = false;

	void Start () 
	{
		_containerLineAttack = (GameObject)Instantiate (_prefabContainerLineAttack, Vector3.zero, Quaternion.identity);
	
		_ligneAttackManager = _containerLineAttack.GetComponent<LineAttackManager> ();

		Debug.Log (_ligneAttackManager);
		_lineAttack1 = _ligneAttackManager.getLineAttack (0);
		_lineAttack2 = _ligneAttackManager.getLineAttack (1);
		_lineAttack3 = _ligneAttackManager.getLineAttack (2);

		}
	
		// Update is called once per frame
		void Update () {
			
		}


	public void StartShoot(){
		_alreadyInit = false;
	}
	
	public void StartConstruction(){
		
	}

	public void UpdateShoot(){
	
		Debug.Log ("EnnemiManager UpdateShoot");

		if (!_alreadyInit) {
			_lineAttack1.setShips(10,2,0);
			_lineAttack2.setShips(10,2,0);
			_lineAttack3.setShips(10,2,1);
			_alreadyInit = true;
		}

		_lineAttack1.UpdateShoot ();
		_lineAttack2.UpdateShoot ();
		_lineAttack3.UpdateShoot ();
				

	}
	
	public void UpdateConstruction(){
		_lineAttack1.UpdateConstruction();
		_lineAttack2.UpdateConstruction();
		_lineAttack3.UpdateConstruction ();
	}

	public GameObject getCloserShipLigne1(Transform refe){
		return _lineAttack1.getCloserShip (refe);
	}

	public GameObject getCloserShipLigne2(Transform refe){
		return _lineAttack2.getCloserShip (refe);
	}

	public GameObject getCloserShipLigne3(Transform refe){
		return _lineAttack3.getCloserShip (refe);
	}
}
