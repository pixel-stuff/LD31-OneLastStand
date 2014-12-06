using UnityEngine;
using System.Collections;

public class ContainerCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Camera camera = this.gameObject.camera;
		this.GetComponent<UIAnchor> ().uiCamera = camera;

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
