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

	public GameObject _Tower1Life;
	public GameObject _Tower2Life;
	public GameObject _Tower3Life;
	public GameObject _Tower4Life;

	public GameObject _CityLife;

	public GameObject _repairLabel;

	public GameObject _priceTruck;


	public GameObject _ExplainStandard1;
	public GameObject _ExplainStandard2;
	public GameObject _ExplainStandard3;

	public GameObject _ExplainDisin1;
	public GameObject _ExplainDisin2;
	public GameObject _ExplainDisin3;

	public GameObject _ExplainEMP1;
	public GameObject _ExplainEMP2;
	public GameObject _ExplainEMP3;


	public int _credit;
	public int _score;

	public int _nbVague;

	public bool _wasInit=false;

	public int _Stat;

	public float _percentCity;


	public Enum_TurretType[] tabTypeTurret ;
	public float[] percentLifeTurret ;
	public int[] levelTurret ;
	public int[] degatTurret;
	public bool[] _destroyTurret;

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
		_destroyTurret = new bool[4];

		tabTypeTurret[0] = Enum_TurretType.None;
		tabTypeTurret[1] = Enum_TurretType.None;
		tabTypeTurret[2] = Enum_TurretType.None;
		tabTypeTurret[3] = Enum_TurretType.None;
		_Stat = 4;

		_priceUpgradeTruck = ConstantesManager.PRICE_UPDATE_TRUCK;

		_City.GetTurretById (Enum_IdTurret.Turret4).ChangeTypeTurret (Enum_TurretType.Standard);
		}

	public void setTurretState(int stat){
		_Stat = stat;
		updateTowerButton ();

		}
	public void cleanExplication(){
		_ExplainStandard1.SetActive(false);
		_ExplainStandard2.SetActive(false);
		_ExplainStandard3.SetActive(false);

		_ExplainDisin1.SetActive(false);
		_ExplainDisin2.SetActive(false);
		_ExplainDisin3.SetActive(false);

		_ExplainEMP1.SetActive(false);
		_ExplainEMP2.SetActive(false);
		_ExplainEMP3.SetActive(false);
		}

	public void SelectorOver(int position,bool isOver,int level){
		switch (position) {
		case 0 :
			Debug.Log("Over Repair");
			if(isOver){
			}else{
			}

			break;
		case 1 :
			Debug.Log(" Over Stabdar");
			if(tabTypeTurret[_Stat -1]==Enum_TurretType.Standard){

				cleanExplication();
				switch (levelTurret[_Stat -1]){
				case 1 :

					_ExplainStandard2.SetActive(isOver);
					break;
				case 2 :

					_ExplainStandard3.SetActive(isOver);
					break;
				case 3 :

					_ExplainStandard3.SetActive(isOver);
					break;
				}
			}else{
				cleanExplication();
				switch (levelTurret[_Stat -1]+level){
				case 1 :
					
					_ExplainStandard1.SetActive(isOver);
					break;
				case 2 :
					
					_ExplainStandard2.SetActive(isOver);
					break;
				case 3 :
					
					_ExplainStandard3.SetActive(isOver);
					break;
				case 4 :
					
					_ExplainStandard3.SetActive(isOver);
					break;
				}
			
			}

			break;
		case 2 :
			Debug.Log(" Over  Disin");
			if(tabTypeTurret[_Stat -1]==Enum_TurretType.Disintegrator){
				
				cleanExplication();
				switch (levelTurret[_Stat -1]){
				case 1 :
					
					_ExplainDisin2.SetActive(isOver);
					break;
				case 2 :
					
					_ExplainDisin3.SetActive(isOver);
					break;
				case 3 :
					
					_ExplainDisin3.SetActive(isOver);
					break;
				}
			}else{
				cleanExplication();
				switch (levelTurret[_Stat -1]+level){
				case 1 :
					
					_ExplainDisin1.SetActive(isOver);
					break;
				case 2 :
					
					_ExplainDisin2.SetActive(isOver);
					break;
				case 3 :
					
					_ExplainDisin3.SetActive(isOver);
					break;
				case 4 :
					
					_ExplainDisin3.SetActive(isOver);
					break;
				}
			}
			break;
		case 3 :
			Debug.Log(" Over EMP");
			if(tabTypeTurret[_Stat -1]==Enum_TurretType.EMP){
				
				cleanExplication();
				switch (levelTurret[_Stat -1]){
				case 1 :
					
					_ExplainEMP2.SetActive(isOver);
					break;
				case 2 :
					
					_ExplainEMP3.SetActive(isOver);
					break;
				case 3 :
					
					_ExplainEMP3.SetActive(isOver);
					break;
				}
			}else{
				cleanExplication();
				switch (levelTurret[_Stat -1]+level){
				case 1 :
					
					_ExplainEMP1.SetActive(isOver);
					break;
				case 2 :
					
					_ExplainEMP2.SetActive(isOver);
					break;
				case 3 :
					
					_ExplainEMP3.SetActive(isOver);
					break;
				case 4 :
					
					_ExplainEMP3.SetActive(isOver);
					break;
				}
				
			}
			break;
			
		case 4 :
			if(isOver){
			}else{
			}

			break;
		}

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
				SelectorOver(position,true,1);
				_City.SubToFragmentPlayer (getPriceStandard(levelTurret[_Stat -1]));
			BuildTurretStandard(getEnumIDTurret());
				//SelectorOver(position,true,0);
				//RepareTurret(getEnumIDTurret());
			}
			break;
					case 2 :
			Debug.Log("Disin");
			if (_credit >=getPriceDisi(levelTurret[_Stat -1])){
				_City.SubToFragmentPlayer (getPriceDisi(levelTurret[_Stat -1]));
			BuildTurretDisi(getEnumIDTurret());
				//RepareTurret(getEnumIDTurret());
			}
			break;
						case 3 :
			Debug.Log("EMP");
			if (_credit >= getPriceEMP(levelTurret[_Stat -1])){
				_City.SubToFragmentPlayer (getPriceEMP(levelTurret[_Stat -1]));
			BuildTurretEMP(getEnumIDTurret());
				//RepareTurret(getEnumIDTurret());
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

		_percentCity = (float)(_City._pv)/(float)(_City._pvMax);
		//Debug.Log (_percentCity);
		_credit = _City._quantiteFrag;
		_score = _Player._score;
		_nbVague=_Player._nbVague;

		updateLabel ();


		Turret turret = _City.GetTurretById (Enum_IdTurret.Turret1);
		tabTypeTurret [0] = turret._enumCurrentTurretType;
		percentLifeTurret [0] = (float)(turret._pv) / (float)(turret._pvMax);
		levelTurret[0]= turret.getLevel();
		degatTurret[0]=turret._pvMax - turret._pv;
		_destroyTurret[0]=turret.isDestroy();

		turret = _City.GetTurretById (Enum_IdTurret.Turret2);
		tabTypeTurret [1] = turret._enumCurrentTurretType;
		percentLifeTurret [1] = (float)(turret._pv) / (float)(turret._pvMax);
		levelTurret[1]= turret.getLevel();
		degatTurret[1]=turret._pvMax - turret._pv;
		_destroyTurret[1]=turret.isDestroy();

		turret = _City.GetTurretById (Enum_IdTurret.Turret3);
		tabTypeTurret [2] = turret._enumCurrentTurretType;
		percentLifeTurret [2] = (float)(turret._pv) / (float)(turret._pvMax);
		levelTurret[2]= turret.getLevel();
		degatTurret[2]=turret._pvMax - turret._pv;
		_destroyTurret[2]=turret.isDestroy();

		turret = _City.GetTurretById (Enum_IdTurret.Turret4);
		tabTypeTurret [3] = turret._enumCurrentTurretType;
		
		percentLifeTurret [3] = (float)(turret._pv) / (float)(turret._pvMax);
		levelTurret[3]= turret.getLevel();
		degatTurret[3]=turret._pvMax - turret._pv;
		_destroyTurret[3]=turret.isDestroy();
		updateTower ();
		updateTowerButton ();
		updateLife ();

	}

		void updateLife (){
		
		_CityLife.GetComponent<UILifeScript> ().SetUILife( _percentCity);
		
		_Tower1Life.GetComponent<UILifeScript> ().SetUILife( percentLifeTurret[0]);
		
		_Tower2Life.GetComponent<UILifeScript> ().SetUILife( percentLifeTurret[1]);
		
		_Tower3Life.GetComponent<UILifeScript> ().SetUILife( percentLifeTurret[2]);
		
		_Tower4Life.GetComponent<UILifeScript> ().SetUILife( percentLifeTurret[3]);

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
						switch (tabTypeTurret [_Stat - 1]) {
						case Enum_TurretType.Standard:
								if (levelTurret [_Stat - 1] < 3) {
										_StandardButton.GetComponent<ChangeLevelTexture> ().ChangeLevel (levelTurret [_Stat - 1] + 1);
										_DisinButton.GetComponent<ChangeLevelTexture> ().ChangeLevel (1);
										_EMPButton.GetComponent<ChangeLevelTexture> ().ChangeLevel (1);

										_StandardButtonPrice.GetComponent<UILabel> ().text = (getPriceStandard (levelTurret [_Stat - 1]) + 1).ToString ();
										_DisinButtonPrice.GetComponent<UILabel> ().text = (getPriceDisi (1)).ToString ();
										_EMPButtonPrice.GetComponent<UILabel> ().text = (getPriceEMP (1)).ToString ();

								} else {
										_StandardButtonPrice.GetComponent<UILabel> ().color = Color.red;
								}
								break;

						case Enum_TurretType.EMP:
								if (levelTurret [_Stat - 1] < 3) {
										_EMPButton.GetComponent<ChangeLevelTexture> ().ChangeLevel (levelTurret [_Stat - 1] + 1);
										_DisinButton.GetComponent<ChangeLevelTexture> ().ChangeLevel (1);
										_StandardButton.GetComponent<ChangeLevelTexture> ().ChangeLevel (1);
					
										_StandardButtonPrice.GetComponent<UILabel> ().text = (getPriceStandard (1).ToString ());
										_DisinButtonPrice.GetComponent<UILabel> ().text = (getPriceDisi (1)).ToString ();
										_EMPButtonPrice.GetComponent<UILabel> ().text = (getPriceEMP (levelTurret [_Stat - 1]) + 1).ToString ();
					
								} else {
										_EMPButtonPrice.GetComponent<UILabel> ().color = Color.red;
								}
								break;


						case Enum_TurretType.Disintegrator:
								if (levelTurret [_Stat - 1] < 3) {
										_StandardButton.GetComponent<ChangeLevelTexture> ().ChangeLevel (1);
										_DisinButton.GetComponent<ChangeLevelTexture> ().ChangeLevel (levelTurret [_Stat - 1] + 1);
										_EMPButton.GetComponent<ChangeLevelTexture> ().ChangeLevel (1);
					
										_StandardButtonPrice.GetComponent<UILabel> ().text = (getPriceStandard (1)).ToString ();
										_DisinButtonPrice.GetComponent<UILabel> ().text = (getPriceDisi (levelTurret [_Stat - 1] + 1)).ToString ();
										_EMPButtonPrice.GetComponent<UILabel> ().text = (getPriceEMP (1)).ToString ();
					
								} else {
										_DisinButtonPrice.GetComponent<UILabel> ().color = Color.red;
								}
								break;
						}
			
			
				} else {

			_StandardButton.GetComponent<ChangeLevelTexture> ().ChangeLevel (1);
			_DisinButton.GetComponent<ChangeLevelTexture> ().ChangeLevel (1);
			_EMPButton.GetComponent<ChangeLevelTexture> ().ChangeLevel (1);
			
			_StandardButtonPrice.GetComponent<UILabel> ().text = (getPriceStandard (1)).ToString ();
			_DisinButtonPrice.GetComponent<UILabel> ().text = (getPriceDisi (1)).ToString ();
			_EMPButtonPrice.GetComponent<UILabel> ().text = (getPriceEMP (1)).ToString ();

				}

		}

	void updateTower(){
		for (int i =1; i<5; i++) {
			bool isSelect=false;
			if (i == _Stat){
				isSelect=true;
			}
						switch (i) {
						case 1:

				_Tower1Button.GetComponent<ChangeButton> ().ChangeButtonFonction (levelTurret [0], tabTypeTurret [0],isSelect,_destroyTurret[0]);//ChangeButton(tabTypeTurret[_Stat-1]
	
								break;
						case 2:
				_Tower2Button.GetComponent<ChangeButton> ().ChangeButtonFonction (levelTurret [1], tabTypeTurret [1],isSelect,_destroyTurret[1]);//ChangeButton(tabTypeTurret[_Stat-1]
								break;

			case 3:
				_Tower3Button.GetComponent<ChangeButton> ().ChangeButtonFonction (levelTurret [2], tabTypeTurret [2],isSelect,_destroyTurret[2]);//ChangeButton(tabTypeTurret[_Stat-1]
				break;
			case 4:
				_Tower4Button.GetComponent<ChangeButton> ().ChangeButtonFonction (levelTurret [3], tabTypeTurret [3],isSelect,_destroyTurret[3]);//ChangeButton(tabTypeTurret[_Stat-1]
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
