using UnityEngine;
using System.Collections;
using System;
public class BulletTurret : MonoBehaviour
{
	Ship _shipTarget;
	public float _speed; //px/sec
	public float _pvDamage;
	public Enum_TurretType _enumBulletType;
	public Vector2 _LastDirection;
	
	private float _scaleLvl1 = 1f;
	private float _scaleLvl2 = 1.2f;
	private float _scaleLvl3 = 1.45f;

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

		if (_shipTarget == null) {
			Vector3 origin = this.transform.position;
			Vector3 vectorMove=(Time.deltaTime * _speed)*_LastDirection;
			transform.position =  origin + vectorMove;
		} else {

			Vector3 origin = this.transform.position;
			Vector3 vectorMove=(Time.deltaTime * _speed)*_LastDirection;
			transform.position =  origin + vectorMove;
			Vector3 target = _shipTarget.transform.position;
			_LastDirection = Vector3.Normalize(target - origin);
		}


	}

	public void Initialize(Ship ship, Enum_TurretType type, int damage, float speed,Enum_StateTurret enumState){
		_shipTarget = ship;
		_enumBulletType = type;
		_pvDamage = damage;
		_speed = speed;
		SetLvlTexture (enumState);
		Vector3 target = _shipTarget.transform.position;
		Vector3 origin = this.transform.position;
		_LastDirection = Vector3.Normalize(target - origin);
		float orientation = 90-  (360f/(2*3.141592654f))*(float)(Math.Atan(_LastDirection.x/ _LastDirection.y));
		this.transform.Rotate(new Vector3(0, 0, orientation));
		
	}

	public void SetLvlTexture(Enum_StateTurret enumState){


		Vector3 vec;
		switch (enumState) {

			case Enum_StateTurret.TurretLevel1:
				vec = this.transform.localScale;
				vec *= _scaleLvl1;
				this.transform.localScale = vec;
				break;
			case Enum_StateTurret.TurretLevel2:
				vec = this.transform.localScale;
				vec *= _scaleLvl2;
				this.transform.localScale = vec;
				
				break;
			case Enum_StateTurret.TurretLevel3:
				vec = this.transform.localScale;
				vec *= _scaleLvl3;
				this.transform.localScale = vec;
				
				break;


				}
	}

	void OnTriggerEnter2D(Collider2D coll){
	/*	Ship element = coll.gameObject.GetComponent<Ship> ();
		if (element == null) 
			return;

		Destroy (this.gameObject);*/
	}
}

