using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour  {

	public Enum_ShipType _TYPE;
	public City _city;
	public int _pv;
	public int _degatShot;
	public int _degatKamikaze;
	public int _score;
	public float _normalSpeed;
	public float _timeBetweenAttack;
	public float _variationTimeBetweenAttackPercent;

	public float _percentFragByStandard;
	public float _percentFragByDisa;
	public float _percentFragByEMP;



	public GameObject _prefabFragment;


	
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
		frag.GetComponent<Fragment> ()._quantite = fragment;



		if (_pv <= 0) {
			Object.Destroy(this);
		}

		}


	public void UpdateShoot(){
		Debug.Log (this.gameObject.name + " Update");
	}
	
	public void UpdateConstruction(){
	}


	void OnTriggerEnter2D(Collider2D collider)
	{
		//collider.gameObject.name ="City"

		//TODO if allyBullet 
		// GetHit(bulletValue)

		//else if city
		//Object.Destroy(this);
		}
}
