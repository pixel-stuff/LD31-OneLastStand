using UnityEngine;
using System.Collections;

public class EnnemiManager : MonoBehaviour {


	public GameObject _prefabContainerLineAttack;

	public GameObject _containerLineAttack;
	public LineAttackManager _ligneAttackManager;

	public LineAttack _lineAttack1;
	public LineAttack _lineAttack2;
	public LineAttack _lineAttack3;

	public VagueManager _vagueManager;

	public bool _alreadyInit = false;

	public int _fpNow;
	public int _vagueNumberNow;

	void Start () 
	{
		_containerLineAttack = (GameObject)Instantiate (_prefabContainerLineAttack, Vector3.zero, Quaternion.identity);
	
		_ligneAttackManager = _containerLineAttack.GetComponent<LineAttackManager> ();


		_lineAttack1 = _ligneAttackManager.getLineAttack (0);
		_lineAttack2 = _ligneAttackManager.getLineAttack (1);
		_lineAttack3 = _ligneAttackManager.getLineAttack (2);



	}

	public void Initialize ()
	{
		_vagueManager.Initialize();
		
		_ligneAttackManager.Initialize();
		_lineAttack1.Initialize();
		_lineAttack2.Initialize();
		_lineAttack3.Initialize();
	}
	
		// Update is called once per frame
		void Update () {
			
		}


	public void StartShoot(){
		//Debug.Log ("EnnemiManager STARTSHOOT");
		_alreadyInit = false;
	}
	
	public void StartConstruction(){
		
	}

	public void UpdateShoot(){
	
		//Debug.Log ("EnnemiManager UpdateShoot");

		if (!_alreadyInit) {
			if(_vagueManager ==null){
				_vagueManager = new VagueManager ();
			}
			dispatchVague(_vagueManager.getIncomingVague());
			_alreadyInit = true;
		}

		_lineAttack1.UpdateShoot ();
		_lineAttack2.UpdateShoot ();
		_lineAttack3.UpdateShoot ();
				

	}

	private void dispatchVague(Vague vague){

				int h1 = 0;
				int f1 = 0;
				int c1 = 0;

				int h2 = 0;
				int f2 = 0;
				int c2 = 0;

				int h3 = 0;
				int f3 = 0;
				int c3 = 0;

		//Debug.Log (vague._hunterNumber);
				int modH = vague._hunterNumber % 4;
				h1 = vague._hunterNumber / 4;
				h3 = vague._hunterNumber / 4;
				h2 = vague._hunterNumber / 2 + modH;

		int modF = vague._frigateNumber % 4;
				f1 = vague._frigateNumber / 4;
		f3 = vague._frigateNumber / 4;
		f2 = vague._frigateNumber / 2 + modF;

		int modC = vague._cruiserNumber % 4;
				c1 = vague._cruiserNumber / 4;
		c3 = vague._cruiserNumber / 4;
		c2 = vague._cruiserNumber / 2 + modC;

		_lineAttack1.setShips (h1, f1, c1);
		_lineAttack2.setShips (h2, f2, c2);
		_lineAttack3.setShips (h3, f3, c3);

		_fpNow=vague._FP;
		_vagueNumberNow=vague._number;

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

	public bool didOneLeft(){
		return (_lineAttack1.didOneLeft() || _lineAttack2.didOneLeft() || _lineAttack3.didOneLeft() );
		}
}
