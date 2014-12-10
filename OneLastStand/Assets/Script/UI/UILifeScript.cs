using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UILifeScript : MonoBehaviour{

 private Vector3 _scaleInitiale;
private Vector3 _positionInitiale;
 
 void Start(){
  _scaleInitiale = this.transform.localScale;
		_positionInitiale= this.transform.localPosition;
 }
 
 public void SetUILife(float flo){
  Vector3 vec = _scaleInitiale;
  vec.y *= flo;
  this.transform.localScale = vec;
		//this.transform.position.y=

 }
}