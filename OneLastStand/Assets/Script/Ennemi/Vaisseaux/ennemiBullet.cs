using UnityEngine;
using System.Collections;
using System;

public class ennemiBullet : MonoBehaviour {

	GameObject _cityTarget;
	public float _speed; //px/sec
	public float _pvDamage;
	public Enum_ShipType _enumBulletType;
	public Vector2 _LastDirection;
	
	
	public float _lifeTime;
	private float _timeCreation;
	
	// Use this for initialization
	void Start ()
	{
		_lifeTime = ConstantesManager.BULLET_TURRET_LIFE_TIME;
		_timeCreation = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Time.time - _timeCreation >= _lifeTime) {
			Destroy(this.gameObject);
			return;
		}
		
		if (_cityTarget == null) {
			this.transform.position = _LastDirection * (Time.deltaTime * _speed);
		} else {
			Vector3 origin = this.transform.position;
			Vector3 vectorMove=(Time.deltaTime * _speed)*_LastDirection;
			transform.position =  origin + vectorMove;
			Vector3 target = _cityTarget.transform.position;
			_LastDirection = Vector3.Normalize(target - origin);

		}
		
		
	}
	
	public void Initialize(GameObject city, Enum_ShipType type, int damage, float speed,Vector3 initialePos){
		//Debug.Log ("Ennemi bullet INIT" + this.transform.position );
		this.transform.position = initialePos;
		_cityTarget = city;
		_enumBulletType = type;
		_pvDamage = damage;
		_speed = speed;
		Vector3 target = _cityTarget.transform.position;
		Vector3 origin = this.transform.position;
		_LastDirection = Vector3.Normalize(target - origin);
		float orientation = 90-  (360f/(2*3.141592654f))*(float)(Math.Atan(_LastDirection.x/ _LastDirection.y));
		this.transform.Rotate(new Vector3(0, 0, orientation));

	//	_LastDirection = Vector3.Normalize(new Vector3(target.x - target.x,
		                                             /*  target.y - target.y,
		                                               target.z - target.z));*/
		
	}
	/*
	void OnTriggerEnter2D(Collider2D coll){

		Debug.Log("collider EnnemiBullet");
		City element = coll.gameObject.GetComponent<City> ();
		if (element == null) 
			return;
		
		Destroy (this.gameObject);
	}*/
}
