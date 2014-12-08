using UnityEngine;
using System.Collections;

public class UIManager2 : MonoBehaviour {

	public int _costRepair;

	City _City;
	PlayerManager _Player;

	public int _cityLife;
	public int _credit;


	public bool _wasInit=false;

	// Use this for initialization
	void Start () {
		toto ();
	}

	public void toto(){
		Debug.Log ("TTTTTTTTTTTTTTTTOOOOOOOOOOOOOOOOOOOTTTTTTTTTTTTTTTTTTT");
		}


	void init(){
		GameObject tempo = GameObject.FindGameObjectWithTag ("City");
		_City = tempo.gameObject.GetComponent<City>(); 
			tempo = GameObject.FindGameObjectWithTag ("PlayerManager");
		_Player = tempo.gameObject.GetComponent<PlayerManager> ();
			_costRepair=ConstantesManager.PRICE_REPAIR;
		_wasInit = true;

		}
	public void BuildTurretStandard(Enum_IdTurret tur){
		Turret turret = _City.GetTurretById (tur);
		if (turret._enumCurrentTurretType == Enum_TurretType.Standard) {
			//WTF turret.ChangeStateTurret
				}
		}

	public void RepareTurret(Enum_IdTurret tur){
		int val =getValuePvRepair(tur);
		_City.GetTurretById (tur).Repare (val);
		// show Val 
		//_Player.
		_City.SubToFragmentPlayer (val * _costRepair);


		//TODO disabled button repair on turret tur
	}
	public int getValuePvRepair(Enum_IdTurret tur){
		Turret cible =_City.GetTurretById(tur);
		return cible._pvMax - cible._pv;
		}


	// Update is called once per frame
	void Update () {
		if (_wasInit) {
						refreshRessource ();
				}
	}

	void refreshRessource(){
		_cityLife = _City._pv;
		_credit = _City._quantiteFrag;
		//TODO get tur life


		}
	
	
	
	
	
	
	


}
