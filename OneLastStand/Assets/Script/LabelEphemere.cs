using UnityEngine;
using System.Collections;

public class LabelEphemere : MonoBehaviour {

	UILabel _label;
	float _timelife;
	float _timeCreate;
	int _decalage = 3;

	//public bool _directionUp;

	// Use this for initialization
	void Start () {
		_timelife = ConstantesManager.LABEL_LIFE_TIME;
		_label = this.gameObject.GetComponent<UILabel> ();
		_timeCreate = Time.time;
		//_directionUp = true;
		
	}
	public float delta;

	// Update is called once per frame
	void Update () {
		if (Time.time - delta > 0.05) {
			Vector3 vec = this.transform.localPosition;
			vec.y+=_decalage;
			this.transform.localPosition = vec;

			_label.alpha-=0.1f;
			delta = Time.time;
		}

		if (Time.time - _timeCreate >= _timelife) {
			Destroy(this.gameObject);
		}
	}
}
