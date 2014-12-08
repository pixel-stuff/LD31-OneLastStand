using UnityEngine;
using System.Collections;

public class UIManager2 : MonoBehaviour {

	public int _costRepair;

	City _City;
	PlayerManager _Player;

	public GameObject _ScoreLabel;
	public GameObject _WaveLabel;
	public GameObject _CreditLabel;

	public GameObject _Tower1Button;
	public GameObject _Tower2Button;
	public GameObject _Tower3Button;
	public GameObject _Tower4Button;


	public GameObject _StandardButton;
	public GameObject _DisinButton;
	public GameObject _EMPButton;

	public GameObject _repairLabel;

	public int _cityLifePercent;
	public int _credit;
	public int _score;

	public int _nbVague;

	public bool _wasInit=false;

	public int _Stat;

	public float _percentCity;
	public float _percentTower1;
	public float _percentTower2;
	public float _percentTower3;
	public float _percentTower4;

	public Enum_TurretType[] tabTypeTurret ;
	public float[] percentLifeTurret ;
	public int[] levelTurret ;
	public int[] degatTurret;

	// Use this for initialization
	void Start () {
	
	}
	
	void init(){
		GameObject tempo = GameObject.FindGameObjectWithTag ("City");
		_City = tempo.gameObject.GetComponent<City>(); 
			tempo = GameObject.FindGameObjectWithTag ("Player");
		_Player = tempo.gameObject.GetComponent<PlayerManager> ();
			_costRepair=ConstantesManager.PRICE_REPAIR;

		tabTypeTurret= new Enum_TurretType[4];
		percentLifeTurret= new float[4];
		levelTurret= new int[4];
		degatTurret= new int[4];

		tabTypeTurret[0] = Enum_TurretType.None;
		tabTypeTurret[1] = Enum_TurretType.None;
		tabTypeTurret[2] = Enum_TurretType.None;
		tabTypeTurret[3] = Enum_TurretType.None;


		}

	public void setTurretState(int stat){
		_Stat = stat;

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

		_cityLifePercent = _City._pv/_City._pvMax;
		_credit = _City._quantiteFrag;
		_score = _Player._score;
		_nbVague=_Player._nbVague;
		Debug.Log ("COUCOU "+_score);
		updateLabel ();


		Turret turret = _City.GetTurretById (Enum_IdTurret.Turret1);
		tabTypeTurret [0] = turret._enumCurrentTurretType;
		percentLifeTurret [0] = turret._pv / turret._pvMax;
		levelTurret[0]= turret.getLevel();
		degatTurret[0]=turret._pvMax - turret._pv;

		turret = _City.GetTurretById (Enum_IdTurret.Turret2);
		tabTypeTurret [1] = turret._enumCurrentTurretType;
		percentLifeTurret [1] = turret._pv / turret._pvMax;
		levelTurret[1]= turret.getLevel();
		degatTurret[1]=turret._pvMax - turret._pv;

		turret = _City.GetTurretById (Enum_IdTurret.Turret3);
		tabTypeTurret [2] = turret._enumCurrentTurretType;
		percentLifeTurret [2] = turret._pv / turret._pvMax;
		levelTurret[2]= turret.getLevel();
		degatTurret[2]=turret._pvMax - turret._pv;

		turret = _City.GetTurretById (Enum_IdTurret.Turret4);
		tabTypeTurret [3] = turret._enumCurrentTurretType;
		percentLifeTurret [3] = turret._pv / turret._pvMax;
		levelTurret[3]= turret.getLevel();
		degatTurret[3]=turret._pvMax - turret._pv;

		updateTower ();


		}
	void updateTower(){
		switch (_Stat) {
		case 1:
			//_Tower1Button.GetComponent< //ChangeButton(tabTypeTurret[_Stat-1]
			/*_StandardButton;
			 _DisinButton;
			_EMPButton*/
			break;

				}

		}
	
	
	
	
	
	


}
