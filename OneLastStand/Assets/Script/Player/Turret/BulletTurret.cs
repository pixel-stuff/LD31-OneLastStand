using UnityEngine;
using System.Collections;

public class BulletTurret : MonoBehaviour
{
	Ship _shipTarget;
	public float _speed; //px/sec
	public float _pvDamage;
	public Enum_TurretType _enumBulletType;
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

		if (_shipTarget == null) {
			this.transform.position = _LastDirection * (Time.deltaTime * _speed);
		} else {

			float dist = Vector3.Distance (_shipTarget.transform.position, this.transform.position);
			Vector3 vec = Vector3.MoveTowards (transform.position, _shipTarget.transform.position, Time.deltaTime * _speed);
			transform.position = vec;
			_LastDirection = Vector3.Normalize(vec);
		}


	}

	public void Initialize(Ship ship, Enum_TurretType type, int damage, float speed){
		_shipTarget = ship;
		_enumBulletType = type;
		_pvDamage = damage;
		_speed = speed;
		_LastDirection = Vector3.Normalize(Vector3.MoveTowards(transform.position, _shipTarget.transform.position, 1f));
		
	}

	void OnTriggerEnter2D(Collider2D coll){
		Ship element = coll.gameObject.GetComponent<Ship> ();
		if (element == null) 
			return;

		Destroy (this.gameObject);
	}
}

