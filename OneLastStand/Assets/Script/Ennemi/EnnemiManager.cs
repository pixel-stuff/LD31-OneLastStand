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

	void Start () 
	{
		_containerLineAttack = (GameObject)Instantiate (_prefabContainerLineAttack, Vector3.zero, Quaternion.identity);
	
		_ligneAttackManager = _containerLineAttack.GetComponents<LineAttackManager> ();
		_lineAttack1 = _ligneAttackManager.getLineAttack (0);
		_lineAttack2 = _ligneAttackManager.getLineAttack (1);
		_lineAttack3 = _ligneAttackManager.getLineAttack (2);

		}
	
		// Update is called once per frame
		void Update () {
			
		}

	public Ship getCloserShipLigne1(Transform refe){
		return _lineAttack1.getCloserShip (refe);
	}

	public Ship getCloserShipLigne2(Transform refe){
		return _lineAttack2.getCloserShip (refe);
	}

	public Ship getCloserShipLigne3(Transform refe){
		return _lineAttack3.getCloserShip (refe);
	}
}
