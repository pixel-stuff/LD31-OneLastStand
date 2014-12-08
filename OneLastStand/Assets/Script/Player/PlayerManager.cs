using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour{


	City _city;
	Decharge _decharge;
	int _score;

	public GameObject _cityPrefab;
	public GameObject _dechargePrefab;

	public GameObject _labelEphemerePrefab;
	public Enum_StatePlayer _enumStatePlayer;



	void Start () {
		_city = ((GameObject)Instantiate (_cityPrefab, this.transform.position, Quaternion.identity)).GetComponent<City>();
		_city.transform.parent = this.transform;

		_city.transform.localPosition = ConstantesManager.CITY_LOCAL_POSITION;

		_decharge = ((GameObject)Instantiate (_dechargePrefab, Vector2.zero, Quaternion.identity)).GetComponent<Decharge>();
		_decharge.transform.parent = this.transform;

		_enumStatePlayer = Enum_StatePlayer.Playing;


	}

	public void StartShoot(){

		_enumStatePlayer = Enum_StatePlayer.Playing;
		_city.StartShoot ();
		_decharge.StartShoot ();
	}
	
	public void StartConstruction(){
		AddToScore (ConstantesManager.POINT_SURVIVE_VAGUE);


		_city.StartConstruction ();
		_decharge.StartConstruction ();
		
	}
	
	public void UpdateShoot(){
		//Debug.Log ("PlayerManager UpdateShoot");

		CheckPlayerState ();


		if (_enumStatePlayer == Enum_StatePlayer.Playing) {
			_city.UpdateShoot ();
		}
		_decharge.UpdateShoot ();
	}
	
	public void UpdateConstruction(){
		_decharge.UpdateConstruction ();
		_city.UpdateConstruction ();
	}

	private void CheckPlayerState(){
		switch (_city._enumStateCity) {
			case Enum_StateCity.Fighting:
			_enumStatePlayer = Enum_StatePlayer.Playing;
			break;

		case Enum_StateCity.Winning:
			_enumStatePlayer = Enum_StatePlayer.Winning;
			Debug.Log ("PlayerManager REPERE WIN");
			break;

		case Enum_StateCity.Destroy:
			_enumStatePlayer = Enum_StatePlayer.Dead;
			break;
		}
	}

	public void AddToScore(int score){
		_score += score;
		GameObject label = (GameObject)Instantiate (_labelEphemerePrefab, _city.transform.position , Quaternion.identity);
		label.transform.parent = _city.transform;
		label.transform.localPosition = new Vector2 (30, 100);
		label.GetComponent<UILabel> ().color = ConstantesManager.SCORE_LABEL_COLOR;
		label.GetComponent<UILabel> ().text = "+" + score;
	}

	public void SubToScore(int score){
		_score += score;
		GameObject label = (GameObject)Instantiate (_labelEphemerePrefab, _city.transform.position , Quaternion.identity);
		label.transform.parent = _city.transform;
		label.transform.localPosition = new Vector2 (30, 100);
		label.GetComponent<UILabel> ().color = ConstantesManager.SCORE_LABEL_COLOR;
		label.GetComponent<UILabel> ().text = "-" + score;
	}



}
