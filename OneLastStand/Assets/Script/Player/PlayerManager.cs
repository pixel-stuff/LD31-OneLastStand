﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour{


	City _city;
	Decharge _decharge;
	int _score;
	int _quantiteFrag;

	public GameObject _cityPrefab;
	public GameObject _dechargePrefab;
	public GameObject _labelEphemerePrefab;
	public Enum_StatePlayer _enumStatePlayer;


	void Start () {
		_quantiteFrag = 50;
		_city = ((GameObject)Instantiate (_cityPrefab, this.transform.position, Quaternion.identity)).GetComponent<City>();
		_city.transform.parent = this.transform;
		_city.transform.localPosition = ConstantesManager.CITY_LOCAL_POSITION;

		_decharge = ((GameObject)Instantiate (_dechargePrefab, Vector2.zero, Quaternion.identity)).GetComponent<Decharge>();
		_decharge.transform.parent = this.transform;

		_enumStatePlayer = Enum_StatePlayer.Playing;
	}

	public void StartShoot(){
		
	}
	
	public void StartConstruction(){
		
	}
	
	public void UpdateShoot(){
		Debug.Log ("PlayerManager UpdateShoot");

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
				break;

		case Enum_StateCity.Destroy:
				_enumStatePlayer = Enum_StatePlayer.Dead;
				break;
			
		}
	}

	public void AddToScore(int score){
		_score += score;
		GameObject label = (GameObject)Instantiate (_labelEphemerePrefab, new Vector2 (30, 30), Quaternion.identity);
		label.transform.parent = this.transform;
		label.GetComponent<UILabel> ().color = ConstantesManager.SCORE_LABEL_COLOR;
		label.GetComponent<UILabel> ().text = "" + score;
	}

	public void SubToScore(int score){
		_score += score;
		GameObject label = (GameObject)Instantiate (_labelEphemerePrefab, new Vector2 (30, 30), Quaternion.identity);
		label.transform.parent = this.transform;
		label.GetComponent<UILabel> ().color = ConstantesManager.SCORE_LABEL_COLOR;
		label.GetComponent<UILabel> ().text = "" + score;
	}

	public void AddToFragment(int frag){
		_quantiteFrag += frag;
		GameObject label = (GameObject)Instantiate (_labelEphemerePrefab, new Vector2 (-30, 30), Quaternion.identity);
		label.transform.parent = this.transform;
		label.GetComponent<UILabel> ().color = ConstantesManager.FRAGMENT_LABEL_COLOR;
		label.GetComponent<UILabel> ().text = "" + frag;
	}

	public void SubToFragment(int frag){
		_quantiteFrag += frag;
		GameObject label = (GameObject)Instantiate (_labelEphemerePrefab, new Vector2 (-30, 30), Quaternion.identity);
		label.transform.parent = this.transform;
		label.GetComponent<UILabel> ().color = ConstantesManager.FRAGMENT_LABEL_COLOR;
		label.GetComponent<UILabel> ().text = "" + frag;
	}

}
