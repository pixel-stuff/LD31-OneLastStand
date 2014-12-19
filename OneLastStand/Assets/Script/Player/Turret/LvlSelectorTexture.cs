using UnityEngine;
using System.Collections;

public class LvlSelectorTexture : MonoBehaviour {

	
	public GameObject _textureLvl1;
	public GameObject _textureLvl2;
	public GameObject _textureLvl3;
	public GameObject _textureDestroy;
	
	public GameObject _turretParentprefab;
	TurretTextureManager _turretParent;
	
	void Start(){
		_turretParent = _turretParentprefab.GetComponent<TurretTextureManager>();
	}
	
	void Update(){
		switch(_turretParent._lvl){
			case Enum_StateTurret.TurretLevel1:
				SetLvl1();
			break;
			case Enum_StateTurret.TurretLevel2:
				SetLvl2();
			break;
			case Enum_StateTurret.TurretLevel3:
				SetLvl3();
				break;
		case Enum_StateTurret.TurretDestroy:
				SetDestroy();
				break;
			default:
				Debug.Log (this.gameObject.name + " : this is not a lvl");
				break;
		
		}
	}
	
	
	public void SetLvl1(){
		_textureLvl1.SetActive(true);
		_textureLvl2.SetActive(false);
		_textureLvl3.SetActive(false);
		_textureDestroy.SetActive(false);
	}
	
	public void SetLvl2(){
		_textureLvl1.SetActive(false);
		_textureLvl2.SetActive(true);
		_textureLvl3.SetActive(false);
		_textureDestroy.SetActive(false);
	}

	public void SetLvl3(){
		_textureLvl1.SetActive(false);
		_textureLvl2.SetActive(false);
		_textureLvl3.SetActive(true);
		_textureDestroy.SetActive(false);
	}
	
	public void SetDestroy(){
		_textureLvl1.SetActive(false);
		_textureLvl2.SetActive(false);
		_textureLvl3.SetActive(false);
		_textureDestroy.SetActive(true);
	}
}
