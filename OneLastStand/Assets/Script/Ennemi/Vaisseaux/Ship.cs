using UnityEngine;
using System.Collections;

public abstract class Ship : MonoBehaviour  {

	public Enum_ShipType _TYPE;
	public GameObject _city;
	public int _pv;
	public int _degatShot;
	public int _degatKamikaze;
	public int _score;
	public float _normalSpeed;
	public float _timeBetweenAttack;
	public float _variationTimeBetweenAttackPercent;
	public float _bulletSpeed;

	public float _percentFragByStandard;
	public float _percentFragByDisa;
	public float _percentFragByEMP;

	public bool alreadyInit=false;

	public float _shootCooldown=0.0f;

	public Vector3 _direction;


	public bool _onDestroy =false;
		public GameObject _prefabFragment;

	public GameObject _prefabEnnemiBullet;


	public float _killYFragment=-100f;

	
	public void GetHit(int dmg,Enum_TurretType turretType){
		_pv -= dmg;


		int fragment=0; 
		switch (turretType) {
				case Enum_TurretType.Standard:
					fragment = (int)(dmg * _percentFragByStandard);
						break;
				case Enum_TurretType.Disintegrator:
			fragment = (int)(dmg * _percentFragByDisa);
						break;
				case Enum_TurretType.EMP:
			fragment = (int)(dmg * _percentFragByEMP);
						break;
		}




		GameObject frag = (GameObject) Instantiate (_prefabFragment, this.transform.localPosition, Quaternion.identity);
		frag.GetComponent<Fragment> ().Initialize (this.transform.position, _killYFragment,fragment); 
		frag.transform.parent=this.transform.parent.transform;



		if (_pv <= 0) {
			_onDestroy=true;
			GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().AddToScore( _score);
			//this.gameObject.SetActive(false);
		}

		}

	public abstract void init ();

	public void UpdateDirection(){
		float decaX = UnityEngine.Random.Range (-40f, 0);
		float decaY = UnityEngine.Random.Range (-40f, 0);
		Vector3 target = _city.transform.position;
		target.x += decaX;
		target.y += decaY;
		Vector3 origin = this.transform.position;
		_direction = Vector3.Normalize(target - origin);

	}
	
	
	public void UpdateShoot(){
		 if (_onDestroy) {
			Destroy(this.gameObject);
			return;
		}
		//Debug.Log (this.gameObject.name + " Update");

		if (!alreadyInit) {
			init ();
			alreadyInit=true;
		}
		//systéme de tir 

		if (_shootCooldown > 0.0f) {
			
			_shootCooldown -= Time.deltaTime;
		}
		if (_shootCooldown <= 0.0f) {
			_shootCooldown =Random.Range(_timeBetweenAttack*(1-_variationTimeBetweenAttackPercent),_timeBetweenAttack*(1+_variationTimeBetweenAttackPercent));

			//shoot 
			GameObject bull = (GameObject)Instantiate (_prefabEnnemiBullet, this.transform.position, Quaternion.identity);
			bull.GetComponent<ennemiBullet> ().Initialize(_city, _TYPE, _degatShot,_bulletSpeed,this.transform.position);
			bull.transform.parent=this.transform.parent.transform;

				}
		Vector3 origin = this.transform.position;
		Vector3 vectorMove=(Time.deltaTime * _normalSpeed)*_direction;
		transform.position =  origin + vectorMove;
		UpdateDirection ();


	}
	
	public void UpdateConstruction(){
	}


	void OnTriggerEnter2D(Collider2D collider)
	{
		//Debug.Log ("on trigered ship");

		BulletTurret bulletElement = collider.gameObject.GetComponent<BulletTurret> ();
		if (bulletElement != null) {
			GetHit((int) bulletElement._pvDamage, bulletElement._enumBulletType);
			Destroy(bulletElement.gameObject);
		}

	}
}
