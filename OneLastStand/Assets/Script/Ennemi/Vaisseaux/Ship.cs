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

	public GameObject _prefabFragment;


	
	public void GetHit(int dmg,int fragment){
		_pv -= dmg;
		GameObject frag = (GameObject) Instantiate (_prefabFragment, this.transform.localPosition, Quaternion.identity);
		frag.GetComponent<Fragment> ()._quantite = fragment;



		if (_pv <= 0) {
			Object.Destroy(this);
		}

		}
	// Update is called once per frame
	void Update () {
	
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
