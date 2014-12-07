using UnityEngine;
using System.Collections;

public class BulletTurret : MonoBehaviour
{
	Ship _shipTarget;
	public float _speed; //px/sec
	public int _pvDamage;
	public int _fragmentDamage;

	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{
		//float dist = Vector3.Distance(_shipTarget.transform.position,this.transform.position);
		//TODO Déplacer la bullet
	}

	public void SetTarget(Ship ship){
		_shipTarget = ship;
	}

	void OnTriggerEnter2D(Collider2D coll){
		Ship element = coll.gameObject.GetComponent<Ship> ();
		if (element == null) 
			return;

		Destroy (this.gameObject);
	
	}
}

