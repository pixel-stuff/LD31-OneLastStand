using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UILifeScript : MonoBehaviour{

 private Vector3 _scaleInitiale;
 
 void Start(){
  _scaleInitiale = this.transform.localScale;
 }
 
 public void SetUILife(float flo){
  Vector3 vec = _scaleInitiale;
  vec.y *= flo;
  this.transform.localScale = vec;
 }
}