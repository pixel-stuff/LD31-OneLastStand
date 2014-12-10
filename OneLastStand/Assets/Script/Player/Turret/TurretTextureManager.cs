using UnityEngine;
using System.Collections;

public class TurretTextureManager : MonoBehaviour{


	public GameObject _EMP;
	public GameObject _Standard;
	public GameObject _Disintegrator;

	public GameObject _TurretPrefab;
	Turret _turretParent;
	public Enum_StateTurret _lvl;

	float _scale1 = 1.0f;
	float _scale2 = 1.5f;
	float _scale3 = 1.8f;
	Vector3 _scaleOrigin = new Vector3 (50, 50, 1);

	City _city;

	void Start(){
		_turretParent = _TurretPrefab.GetComponent<Turret> ();
	}

	void Update(){
		_lvl = _turretParent._enumCurrentStateTurret;
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

		/*switch(_turretParent._enumCurrentStateTurret){
			case Enum_StateTurret.TurretLevel1:
				_EMP.transform.localScale = _scaleOrigin*_scale1;
				_Standard.transform.localScale = _scaleOrigin*_scale1;
				_Disintegrator.transform.localScale = _scaleOrigin*_scale1;
			break;
			case Enum_StateTurret.TurretLevel2:
				_EMP.transform.localScale = _scaleOrigin*_scale2;
				_Standard.transform.localScale = _scaleOrigin*_scale2;
				_Disintegrator.transform.localScale = _scaleOrigin*_scale2;
			
			break;
			case Enum_StateTurret.TurretLevel3:
				_EMP.transform.localScale = _scaleOrigin*_scale3;
				_Standard.transform.localScale = _scaleOrigin*_scale3;
				_Disintegrator.transform.localScale = _scaleOrigin*_scale3;
			
			break;
			default:
				_EMP.SetActive(false);
				_Standard.SetActive(false);
				_Disintegrator.SetActive(false);
			break;

		}*/
	}

}

