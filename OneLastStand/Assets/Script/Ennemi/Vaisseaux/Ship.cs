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

	public Ship(){
		}
	
	public void SubitAttack(int dmg,int fragment){
		_pv -= dmg;
		GameObject frag =  Instantiate (_prefabFragment, this.transform.localPosition, Quaternion.identity);



		if (_pv <= 0) {
			Object.Destroy(this);
		}

		}
	// Update is called once per frame
	void Update () {
	
	}
}
