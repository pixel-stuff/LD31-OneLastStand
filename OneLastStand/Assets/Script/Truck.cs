using UnityEngine;
using System.Collections;

public class Truck : MonoBehaviour {
	
	float _speed;
	float _quantiteTransportable;
	Transform _positionCity;
	Transform _positionDecharge;
	
	void Start(){
		_speed = ConstantesManager.TRUCK_SPEED_BASE;
		_quantiteTransportable = ConstantesManager.TRUCK_QUANTITE_TRANSPADABLE_BASE;
	}
	
	public void Initialize(Transform city, Transform decharge){
		_positionCity = city;
		_positionDecharge = decharge;
	}
	
	public void StartShoot (){
		
	}
	
	void Update (){
		
	}
	
	public void StartConstruction (){
		
	}
	
	public void UpdateShoot (){
		
	}
	
	public void UpdateConstruction (){
		
	}
}

