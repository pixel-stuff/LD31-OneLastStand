using UnityEngine;
using System.Collections;

public class Fragment : MonoBehaviour
{
	public int _quantite=0;
	public float _killY=0;

	public void Initialize(Vector3 posInitial, float killY,int quantite){
		_quantite = quantite;
		this.transform.position = posInitial;
		_killY = killY;
		this.GetComponent<Rigidbody2D> ().gravityScale = Random.Range (3.5f, 5);
		}

		// Use this for initialization
		void Start ()
		{
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (this.transform.position.y <= _killY) {
			Decharge decharge = GameObject.FindGameObjectWithTag ("Decharge").GetComponent<Decharge>();
			decharge.addFragment (_quantite);

						Destroy (this.gameObject);
	
				}
		}
}

