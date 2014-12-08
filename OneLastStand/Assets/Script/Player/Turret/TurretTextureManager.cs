using UnityEngine;
using System.Collections;

public class TurretTextureManager : MonoBehaviour{


	public GameObject _EMP;
	public GameObject _Standard;
	public GameObject _Disintegrator;

	public GameObject _TurretPrefab;
	Turret _turretParent;

	City _city;

	void Start(){
		_turretParent = _TurretPrefab.GetComponent<Turret> ();
	}

	void Update(){
		switch (_turretParent._enumCurrentTurretType) {
			case Enum_TurretType.Disintegrator:
				_EMP.SetActive(false);
				_Standard.SetActive(false);
				_Disintegrator.SetActive(true);

				break;
			case Enum_TurretType.EMP:
				_EMP.SetActive(true);
				_Standard.SetActive(false);
				_Disintegrator.SetActive(false);

				break;
			case Enum_TurretType.Standard:
				_EMP.SetActive(false);
				_Standard.SetActive(true);
				_Disintegrator.SetActive(false);
				
				break;
			default: 
				_EMP.SetActive(false);
				_Standard.SetActive(false);
				_Disintegrator.SetActive(false);
			
			break;
				}
	}

}

