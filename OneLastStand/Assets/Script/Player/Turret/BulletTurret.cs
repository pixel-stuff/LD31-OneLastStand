using UnityEngine;
using System.Collections;

public class BulletTurret : MonoBehaviour
{
	Ship _shipTarget;
	public float _speed; //px/sec
	public float _pvDamage;
	public Enum_TurretType _enumBulletType;

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

		//float dist = Vector3.Distance(_shipTarget.transform.position,this.transform.position);
		//TODO Déplacer la bullet


	}

	public void Initialize(Ship ship, Enum_TurretType type, int damage, float speed){
		_shipTarget = ship;
		_enumBulletType = type;
		_pvDamage = damage;
		_speed = speed;
	}

	void OnTriggerEnter2D(Collider2D coll){
		Ship element = coll.gameObject.GetComponent<Ship> ();
		if (element == null) 
			return;

		Destroy (this.gameObject);
	}
}

