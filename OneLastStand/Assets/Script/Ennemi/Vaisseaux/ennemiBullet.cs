using UnityEngine;
using System.Collections;

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
			Object.Destroy(this.gameObject);
			return;
		}
		
		if (_cityTarget == null) {
			this.transform.position = _LastDirection * (Time.deltaTime * _speed);
		} else {
			Vector3 origin = this.transform.position;
			//float dist = Vector3.Distance (_cityTarget.transform.position, this.transform.position);
			Vector3 vectorMove=(Time.deltaTime * _speed)*_LastDirection;
			//Vector3 vec = Vector3.MoveTowards (transform.position, _cityTarget.transform.position, Time.deltaTime * _speed);
			transform.position =  origin + vectorMove;
			Vector3 target = _cityTarget.transform.position;
			_LastDirection = Vector3.Normalize(target - origin);
			//_LastDirection = Vector3.Normalize(vec);
		}
		
		
	}
	
	public void Initialize(GameObject city, Enum_ShipType type, int damage, float speed){
		Debug.Log ("Ennemi bullet INIT" + this.transform.position );
		_cityTarget = city;
		_enumBulletType = type;
		_pvDamage = damage;
		_speed = speed;
		Vector3 target = _cityTarget.transform.position;
		Vector3 origin = this.transform.position;
		_LastDirection = Vector3.Normalize(target - origin);
	//	_LastDirection = Vector3.Normalize(new Vector3(target.x - target.x,
		                                             /*  target.y - target.y,
		                                               target.z - target.z));*/
		
	}
	
	void OnTriggerEnter2D(Collider2D coll){
		City element = coll.gameObject.GetComponent<City> ();
		if (element == null) 
			return;
		
		Destroy (this.gameObject);
	}
}
