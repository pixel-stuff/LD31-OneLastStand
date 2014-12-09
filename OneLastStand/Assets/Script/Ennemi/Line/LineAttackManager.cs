using UnityEngine;
using System.Collections;

public class LineAttackManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Initialize ()
	{
	}

	public LineAttack getLineAttack(int valueLigne){
		return this.gameObject.GetComponentsInChildren<LineAttack> ()[valueLigne];
	}
}
