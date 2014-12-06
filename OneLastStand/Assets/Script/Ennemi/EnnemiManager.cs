using UnityEngine;
using System.Collections;

public class EnnemiManager : MonoBehaviour {


	public GameObject _prefabContainerLineAttack;

	public GameObject _ContainerLineAttack;

	void Start () 
	{
			_ContainerLineAttack= (GameObject) Instantiate(_prefabContainerLineAttack,Vector3.zero,Quaternion.identity);
	}
	
		// Update is called once per frame
		void Update () {
			
		}
}
