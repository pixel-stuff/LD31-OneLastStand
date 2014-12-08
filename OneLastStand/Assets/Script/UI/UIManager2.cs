using UnityEngine;
using System.Collections;

public class UIManager2 : MonoBehaviour {

	public int _costRepair;

	City _City;
	PlayerManager _Player;

	public GameObject _ScoreLabel;
	public GameObject _WaveLabel;
	public GameObject _CreditLabel;

	public int _cityLife;
	public int _credit;
	public int _score;

	public int _nbVague;

	public bool _wasInit=false;

	public Enum_IdTurret _Stat;

	public float _percentCity;
	public float _percentTower1;
	public float _percentTower2;
	public float _percentTower3;
	public float _percentTower4;

	// Use this for initialization
	void Start () {
	
	}
	
	void init(){
		GameObject tempo = GameObject.FindGameObjectWithTag ("City");
		_City = tempo.gameObject.GetComponent<City>(); 
			tempo = GameObject.FindGameObjectWithTag ("Player");
		_Player = tempo.gameObject.GetComponent<PlayerManager> ();
			_costRepair=ConstantesManager.PRICE_REPAIR;


		}

	public void setTurretState(int stat){
		switch (stat) {
				case 1:
						_Stat = Enum_IdTurret.Turret1;
						break;
				case 2:
						_Stat = Enum_IdTurret.Turret2;
						break;
				case 3:
						_Stat = Enum_IdTurret.Turret3;
						break;
				case 4:
						_Stat = Enum_IdTurret.Turret4;
						break;
				}
		Debug.Log ("SELECT turret "+_Stat);

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
		if (!_wasInit) {
			Debug.Log ("INIT ");
						init ();
			if(_City._pv != null){
						_wasInit = true;
			}
				} else {

	
						refreshRessource ();
				}
	}

	void updateLabel (){
		_ScoreLabel.GetComponent<UILabel> ().text = _score.ToString();
		Debug.Log ("Score Set BIATCH");
		_CreditLabel.GetComponent<UILabel> ().text=_credit.ToString();
		_WaveLabel.GetComponent<UILabel> ().text=_nbVague.ToString();
		}

	void refreshRessource(){

		_cityLife = _City._pv;
		_credit = _City._quantiteFrag;
		_score = _Player._score;
		_nbVague=_Player._nbVague;
		Debug.Log ("COUCOU "+_score);
		updateLabel ();
		Turret turret = _City.GetTurretById (Enum_IdTurret.Turret1);
		



		}
	
	
	
	
	
	
	


}
