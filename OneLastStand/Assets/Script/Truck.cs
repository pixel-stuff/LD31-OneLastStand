using UnityEngine;
using System.Collections;

public class Truck : MonoBehaviour {

	int _currentQuantiteFragment;
	float _speed;
	float _quantiteTransportableMax;
	City _city;
	Decharge _decharge;

	
	void Start(){
		_currentQuantiteFragment = 0;
		_speed = ConstantesManager.TRUCK_SPEED_BASE;
		_quantiteTransportableMax = ConstantesManager.TRUCK_QUANTITE_TRANSPADABLE_BASE;
	}
	
	public void Initialize(City city){
		_city = city;
		_decharge = GameObject.FindGameObjectWithTag ("Decharge").GetComponent<Decharge> ();
	}


	public void TakeFragment(){
		
		_decharge.subFragment ((int)_quantiteTransportableMax);
		_currentQuantiteFragment += (int)_quantiteTransportableMax;

	}
	
	public void GiveFragment(int frag){
		_city.AddToFragmentPlayer ((int)_quantiteTransportableMax);
		_currentQuantiteFragment -= (int)_quantiteTransportableMax;
	}


	public void ChangeTexture(){

	}



	public void StartShoot (){
		
	}
	
	void Update (){
		//TODO Déplacement truck et appeler Give/Take quand il faut
	}
	
	public void StartConstruction (){
		
	}



	public void UpdateShoot (){
		
	}
	
	public void UpdateConstruction (){
	}
}

