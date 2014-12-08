using UnityEngine;
using System.Collections;

public class Truck : MonoBehaviour {
	
	int _currentQuantiteFragment;
	float _speed;
	float _quantiteTransportableMax;
	City _city;
	Decharge _decharge;
	Vector3 _LastDirectionNormalize = new Vector3(0,0,0);
	public Enum_TruckDirection _enumDirection;
	
	
	void Start(){
		_currentQuantiteFragment = 0;
		_speed = 100;
		_quantiteTransportableMax = ConstantesManager.TRUCK_QUANTITE_TRANSPADABLE_BASE;
		_enumDirection = Enum_TruckDirection.decharge;
	}
	
	public void Initialize(City city){
		_city = city;
		_decharge = GameObject.FindGameObjectWithTag ("Decharge").GetComponent<Decharge> ();
	}
	
	
	private void TakeFragment(){
		
		_decharge.subFragment ((int)_quantiteTransportableMax);
		_currentQuantiteFragment += (int)_quantiteTransportableMax;
		
	}
	
	private void GiveFragment(){
		_city.AddToFragmentPlayer ((int)_quantiteTransportableMax);
		_currentQuantiteFragment -= (int)_quantiteTransportableMax;
	}
	
	
	public void ChangeTexture(){
		
	}
	
	
	
	public void StartShoot (){
		
	}
	
	void Update (){
		//TODO Déplacement truck et appeler Give/Take quand il faut
		if(_city == null){
			Debug.Log("_city null");
			return;
		}
		
		if(_decharge == null){
			Debug.Log("_decharge null");
			return;
		}
		
		Vector3 origin = this.transform.position;
		Vector3 target = GetCurrentTarget();
		
		_LastDirectionNormalize = Vector3.Normalize(target - origin);
		
		Vector3 vectorMove = (Time.deltaTime * _speed)*_LastDirectionNormalize;
		transform.position =  origin + vectorMove;
		
		if(Vector3.Distance(origin, target) <= 3f){
			ActionArrive();
		}
	}
	
	private void ActionArrive(){
		switch(_enumDirection){
		case Enum_TruckDirection.city:
			GiveFragment();
			_enumDirection = Enum_TruckDirection.decharge;
			break;
		case Enum_TruckDirection.decharge:
			TakeFragment();
			_enumDirection = Enum_TruckDirection.city;
			break;
		default:
			Debug.Log("Wrong _enumDirection du truck");
			break;
		}
		
		
	}	
	
	public Vector3 GetCurrentTarget(){
		switch(_enumDirection){
		case Enum_TruckDirection.city:
			return _city.transform.position;
		case Enum_TruckDirection.decharge:
			return _decharge.transform.position;
		default:
			Debug.Log("Wrong Target Truck");
			return Vector3.zero;
		}
	}
	
	public void StartConstruction (){
		
	}
	
	
	
	public void UpdateShoot (){
		
	}
	
	public void UpdateConstruction (){
	}
}

