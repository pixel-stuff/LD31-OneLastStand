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
	public GameObject _StandardButtonPrice;
	public GameObject _DisinButton;
	public GameObject _DisinButtonPrice;
	public GameObject _EMPButton;
	public GameObject _EMPButtonPrice;


	public GameObject _repairLabel;

	public GameObject _priceTruck;

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

	public int _priceUpgradeTruck;

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
		_Stat = 1;

		_priceUpgradeTruck = ConstantesManager.PRICE_UPDATE_TRUCK;

		_City.GetTurretById (Enum_IdTurret.Turret4).ChangeTypeTurret (Enum_TurretType.Standard);
		}

	public void setTurretState(int stat){
		_Stat = stat;
		updateTowerButton ();

		}
	public void SelectorInput(int position){

		switch (position) {
		case 0 :
			Debug.Log("Repair");
			if (_credit >=repairCost()){
				RepareTurret(getEnumIDTurret());
			}
			break;
				case 1 :
			Debug.Log("Stabdar");
			if (_credit >=getPriceStandard(levelTurret[_Stat -1])){
				_City.SubToFragmentPlayer (getPriceStandard(levelTurret[_Stat -1]));
			BuildTurretStandard(getEnumIDTurret());
				RepareTurret(getEnumIDTurret());
			}
			break;
					case 2 :
			Debug.Log("Disin");
			if (_credit >=getPriceDisi(levelTurret[_Stat -1])){
				_City.SubToFragmentPlayer (getPriceDisi(levelTurret[_Stat -1]));
			BuildTurretDisi(getEnumIDTurret());
				RepareTurret(getEnumIDTurret());
			}
			break;
						case 3 :
			Debug.Log("EMP");
			if (_credit >= getPriceEMP(levelTurret[_Stat -1])){
				_City.SubToFragmentPlayer (getPriceEMP(levelTurret[_Stat -1]));
			BuildTurretEMP(getEnumIDTurret());
				RepareTurret(getEnumIDTurret());
			}
			break;

				case 4 :
			Debug.Log("UP");
			if (_credit >=_priceUpgradeTruck){
			upGradeTruck();
			}
			break;
				}

		}
	int repairCost(){
		return degatTurret[_Stat - 1]*_costRepair;
	}
	void upGradeTruck(){
		//_City._truck.UpgradeSpeed ();
		_City._truck.UpgradeQuantiteTransportable ();
		_City.SubToFragmentPlayer (_priceUpgradeTruck);
		_priceUpgradeTruck = (int)(_priceUpgradeTruck *(1+ ConstantesManager.VARIATION_PRICE_TRUCK_PERCENT));

		}

	Enum_IdTurret getEnumIDTurret(){
		switch (_Stat) {
		case 1:
			return Enum_IdTurret.Turret1;
			break;
		case 2:
			return Enum_IdTurret.Turret2;
			break;
		case 3:
			return Enum_IdTurret.Turret3;
			break;
		case 4:
			return Enum_IdTurret.Turret4;
			break;
				}

		return Enum_IdTurret.Turret1;

		}



	public void BuildTurretDisi(Enum_IdTurret tur){
		Turret turret = _City.GetTurretById (tur);
		if (turret._enumCurrentTurretType == Enum_TurretType.Disintegrator) {
			turret.Upgrade ();
		} else {
			turret.ChangeTypeTurret(Enum_TurretType.Disintegrator);
		}
		
	}
	public void BuildTurretEMP(Enum_IdTurret tur){
		Turret turret = _City.GetTurretById (tur);
		if (turret._enumCurrentTurretType == Enum_TurretType.EMP) {
			turret.Upgrade ();
		} else {
			turret.ChangeTypeTurret(Enum_TurretType.EMP);
		}
		
	}



	public void BuildTurretStandard(Enum_IdTurret tur){
		Turret turret = _City.GetTurretById (tur);
		if (turret._enumCurrentTurretType == Enum_TurretType.Standard) {
						turret.Upgrade ();
				} else {
			turret.ChangeTypeTurret(Enum_TurretType.Standard);
				}
				
		}

	public void RepareTurret(Enum_IdTurret tur){
		int val =getValuePvRepair(tur);
		_City.GetTurretById (tur).Repare (val);
		// show Val 
		//_Player.
		_City.SubToFragmentPlayer (val * _costRepair);



	}
	public int getValuePvRepair(Enum_IdTurret tur){
		Turret cible =_City.GetTurretById(tur);
		return cible._pvMax - cible._pv;
		}


	// Update is called once per frame
	void Update () {
		if (!_wasInit) {
		
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

		_CreditLabel.GetComponent<UILabel> ().text=_credit.ToString();
		_WaveLabel.GetComponent<UILabel> ().text=_nbVague.ToString();
		_priceTruck.GetComponent<UILabel> ().text=_priceUpgradeTruck.ToString();
		}

	void refreshRessource(){

		_cityLifePercent = _City._pv/_City._pvMax;
		_credit = _City._quantiteFrag;
		_score = _Player._score;
		_nbVague=_Player._nbVague;

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
		updateTowerButton ();


		}

	void updateTowerButton(){

		/*
		_StandardButton.GetComponent<ChangeLevelTexture> ().ChangeLevel (levelTurret [_Stat - 1]);
		_DisinButton.GetComponent<ChangeLevelTexture> ().ChangeLevel (levelTurret [_Stat - 1]);
		_EMPButton.GetComponent<ChangeLevelTexture> ().ChangeLevel (levelTurret [_Stat - 1]);
*/
		_StandardButtonPrice.GetComponent<UILabel> ().color=Color.white;
		_DisinButtonPrice.GetComponent<UILabel> ().color=Color.white;
		_EMPButtonPrice.GetComponent<UILabel> ().color=Color.white;

		//repair label 
		_repairLabel.GetComponent<UILabel> ().text = repairCost ().ToString ();//(degatTurret[_Stat - 1]*_costRepair).ToString();

		if (tabTypeTurret [_Stat - 1] != Enum_TurretType.None) {
			switch(tabTypeTurret [_Stat - 1]){
			case Enum_TurretType.Standard:
				if (levelTurret [_Stat - 1] < 3){
					_StandardButton.GetComponent<ChangeLevelTexture> ().ChangeLevel (levelTurret [_Stat - 1]+1);
					_DisinButton.GetComponent<ChangeLevelTexture> ().ChangeLevel (1);
					_EMPButton.GetComponent<ChangeLevelTexture> ().ChangeLevel (1);

					_StandardButtonPrice.GetComponent<UILabel> ().text = (getPriceStandard (levelTurret [_Stat - 1])+1).ToString();
					_DisinButtonPrice.GetComponent<UILabel> ().text = (getPriceDisi (1)).ToString();
					_EMPButtonPrice.GetComponent<UILabel> ().text = (getPriceEMP (1)).ToString();

				}else{
					_StandardButtonPrice.GetComponent<UILabel> ().color=Color.red;
				}
				break;

			case Enum_TurretType.EMP:
				if (levelTurret [_Stat - 1] < 3){
					_EMPButton.GetComponent<ChangeLevelTexture> ().ChangeLevel (levelTurret [_Stat - 1]+1);
					_DisinButton.GetComponent<ChangeLevelTexture> ().ChangeLevel (1);
					_StandardButton.GetComponent<ChangeLevelTexture> ().ChangeLevel (1);
					
					_StandardButtonPrice.GetComponent<UILabel> ().text = (getPriceStandard (1).ToString());
					_DisinButtonPrice.GetComponent<UILabel> ().text = (getPriceDisi (1)).ToString();
					_EMPButtonPrice.GetComponent<UILabel> ().text = (getPriceEMP (levelTurret [_Stat - 1])+1).ToString();
					
				}else{
					_EMPButtonPrice.GetComponent<UILabel> ().color=Color.red;
				}
				break;


			case Enum_TurretType.Disintegrator:
				if (levelTurret [_Stat - 1] < 3){
					_StandardButton.GetComponent<ChangeLevelTexture> ().ChangeLevel (1);
					_DisinButton.GetComponent<ChangeLevelTexture> ().ChangeLevel (levelTurret [_Stat - 1]+1);
					_EMPButton.GetComponent<ChangeLevelTexture> ().ChangeLevel (1);
					
					_StandardButtonPrice.GetComponent<UILabel> ().text = (getPriceStandard (1)).ToString();
					_DisinButtonPrice.GetComponent<UILabel> ().text = (getPriceDisi (levelTurret [_Stat - 1]+1)).ToString();
					_EMPButtonPrice.GetComponent<UILabel> ().text = (getPriceEMP (1)).ToString();
					
				}else{
					_DisinButtonPrice.GetComponent<UILabel> ().color=Color.red;
				}
				break;
			}
			
			
		}

		}

	void updateTower(){
		for (int i =1; i<5; i++) {
						switch (i) {
						case 1:

								_Tower1Button.GetComponent<ChangeButton> ().ChangeButtonFonction (levelTurret [0], tabTypeTurret [0]);//ChangeButton(tabTypeTurret[_Stat-1]
	
								break;
						case 2:
								_Tower2Button.GetComponent<ChangeButton> ().ChangeButtonFonction (levelTurret [1], tabTypeTurret [1]);//ChangeButton(tabTypeTurret[_Stat-1]
								break;

			case 3:
				_Tower3Button.GetComponent<ChangeButton> ().ChangeButtonFonction (levelTurret [2], tabTypeTurret [2]);//ChangeButton(tabTypeTurret[_Stat-1]
				break;
			case 4:
				_Tower4Button.GetComponent<ChangeButton> ().ChangeButtonFonction (levelTurret [3], tabTypeTurret [3]);//ChangeButton(tabTypeTurret[_Stat-1]
				break;

						}
				}
		}

	int getPriceStandard(int level){
				switch (level) {
				case 1:
						return ConstantesManager.PRICE_STANDARD_1;
						break;
				case 2:
						return ConstantesManager.PRICE_STANDARD_2;
						break;
				case 3:
						return ConstantesManager.PRICE_STANDARD_3;
						break;

				}
		return ConstantesManager.PRICE_STANDARD_1;
		}

	int getPriceDisi(int level){
		switch (level) {
		case 1:
			return ConstantesManager.PRICE_DISIN_1;
			break;
		case 2:
			return ConstantesManager.PRICE_DISIN_2;
			break;
		case 3:
			return ConstantesManager.PRICE_DISIN_3;
			break;
			
		}
		return ConstantesManager.PRICE_DISIN_1;
	}

	int getPriceEMP(int level){
		switch (level) {
		case 1:
			return ConstantesManager.PRICE_EMP_1;
			break;
		case 2:
			return ConstantesManager.PRICE_EMP_2;
			break;
		case 3:
			return ConstantesManager.PRICE_EMP_3;
			break;
			
		}
		return ConstantesManager.PRICE_EMP_3;
	}

	
	
	
	
	
	


}
