using UnityEngine;
using System.Collections;

public class ChangeButton : MonoBehaviour
{
	public GameObject _prefabLvl1Standard;
	public GameObject _prefabLvl2Standard;
	public GameObject _prefabLvl3Standard;
	public GameObject _prefabLvl1EMP;
	public GameObject _prefabLvl2EMP;
	public GameObject _prefabLvl3EMP;
	public GameObject _prefabLvl1Disintegrator;
	public GameObject _prefabLvl2Disintegrator;
	public GameObject _prefabLvl3Disintegrator;
	
	public GameObject _prefabLvl1StandardSelect;
	public GameObject _prefabLvl2StandardSelect;
	public GameObject _prefabLvl3StandardSelect;
	public GameObject _prefabLvl1EMPSelect;
	public GameObject _prefabLvl2EMPSelect;
	public GameObject _prefabLvl3EMPSelect;
	public GameObject _prefabLvl1DisintegratorSelect;
	public GameObject _prefabLvl2DisintegratorSelect;
	public GameObject _prefabLvl3DisintegratorSelect;

	public GameObject _noneButton;
	public GameObject _noneButtonSelect;

	public GameObject _destroyTurret;
	
	public void ChangeButtonFonction(int lvl, Enum_TurretType typeTur,bool isSelect,bool isDestroy){
		if (isDestroy) {
			_destroyTurret.SetActive(true);
				} else {
			_destroyTurret.SetActive(false);
				}
		switch (typeTur) {
		case Enum_TurretType.Disintegrator:
			DisintegratorLvl(lvl,isSelect);
			_noneButtonSelect.SetActive (false);
			_noneButton.SetActive (false);
			break;
		case Enum_TurretType.EMP:
			EMPLvl(lvl,isSelect);
			_noneButtonSelect.SetActive (false);
			_noneButton.SetActive (false);
			
			break;
		case Enum_TurretType.Standard:
			StandardLvl( lvl,isSelect);
			_noneButtonSelect.SetActive (false);
			_noneButton.SetActive (false);
			break;
		case Enum_TurretType.None:
			if (!isSelect) {
				_noneButton.SetActive (true);
				_noneButtonSelect.SetActive (false);
			} else {
				_noneButtonSelect.SetActive (true);
				_noneButton.SetActive (false);
			}
			break;
		}
	}
	
	private void StandardLvl(int lvl,bool isSelect){
		if (!isSelect) {
			switch (lvl) {
			case 1:
				_prefabLvl1Standard.SetActive (true);
				_prefabLvl2Standard.SetActive (false);
				_prefabLvl3Standard.SetActive (false);
				_prefabLvl1Disintegrator.SetActive (false);
				_prefabLvl2Disintegrator.SetActive (false);
				_prefabLvl3Disintegrator.SetActive (false);
				_prefabLvl1EMP.SetActive (false);
				_prefabLvl2EMP.SetActive (false);
				_prefabLvl3EMP.SetActive (false);
				_prefabLvl1StandardSelect.SetActive (false);
				_prefabLvl2StandardSelect.SetActive (false);
				_prefabLvl3StandardSelect.SetActive (false);
				_prefabLvl1DisintegratorSelect.SetActive (false);
				_prefabLvl2DisintegratorSelect.SetActive (false);
				_prefabLvl3DisintegratorSelect.SetActive (false);
				_prefabLvl1EMPSelect.SetActive (false);
				_prefabLvl2EMPSelect.SetActive (false);
				_prefabLvl3EMPSelect.SetActive (false);
				break;
			case 2:
				_prefabLvl1Standard.SetActive (false);
				_prefabLvl2Standard.SetActive (true);
				_prefabLvl3Standard.SetActive (false);
				_prefabLvl1Disintegrator.SetActive (false);
				_prefabLvl2Disintegrator.SetActive (false);
				_prefabLvl3Disintegrator.SetActive (false);
				_prefabLvl1EMP.SetActive (false);
				_prefabLvl2EMP.SetActive (false);
				_prefabLvl3EMP.SetActive (false);
				_prefabLvl1StandardSelect.SetActive (false);
				_prefabLvl2StandardSelect.SetActive (false);
				_prefabLvl3StandardSelect.SetActive (false);
				_prefabLvl1DisintegratorSelect.SetActive (false);
				_prefabLvl2DisintegratorSelect.SetActive (false);
				_prefabLvl3DisintegratorSelect.SetActive (false);
				_prefabLvl1EMPSelect.SetActive (false);
				_prefabLvl2EMPSelect.SetActive (false);
				_prefabLvl3EMPSelect.SetActive (false);
				break;
			case 3:
				_prefabLvl1Standard.SetActive (false);
				_prefabLvl2Standard.SetActive (false);
				_prefabLvl3Standard.SetActive (true);
				_prefabLvl1Disintegrator.SetActive (false);
				_prefabLvl2Disintegrator.SetActive (false);
				_prefabLvl3Disintegrator.SetActive (false);
				_prefabLvl1EMP.SetActive (false);
				_prefabLvl2EMP.SetActive (false);
				_prefabLvl3EMP.SetActive (false);
				_prefabLvl1StandardSelect.SetActive (false);
				_prefabLvl2StandardSelect.SetActive (false);
				_prefabLvl3StandardSelect.SetActive (false);
				_prefabLvl1DisintegratorSelect.SetActive (false);
				_prefabLvl2DisintegratorSelect.SetActive (false);
				_prefabLvl3DisintegratorSelect.SetActive (false);
				_prefabLvl1EMPSelect.SetActive (false);
				_prefabLvl2EMPSelect.SetActive (false);
				_prefabLvl3EMPSelect.SetActive (false);
				break;
				
			}
		} else {
			switch (lvl) {
			case 1:
				_prefabLvl1StandardSelect.SetActive (true);
				_prefabLvl2StandardSelect.SetActive (false);
				_prefabLvl3StandardSelect.SetActive (false);
				_prefabLvl1DisintegratorSelect.SetActive (false);
				_prefabLvl2DisintegratorSelect.SetActive (false);
				_prefabLvl3DisintegratorSelect.SetActive (false);
				_prefabLvl1EMPSelect.SetActive (false);
				_prefabLvl2EMPSelect.SetActive (false);
				_prefabLvl3EMPSelect.SetActive (false);
				_prefabLvl1Standard.SetActive(false);
				_prefabLvl2Standard.SetActive(false);
				_prefabLvl3Standard.SetActive(false);
				_prefabLvl1Disintegrator.SetActive(false);
				_prefabLvl2Disintegrator.SetActive(false);
				_prefabLvl3Disintegrator.SetActive(false);
				_prefabLvl1EMP.SetActive(false);
				_prefabLvl2EMP.SetActive(false);
				_prefabLvl3EMP.SetActive(false);
				break;
			case 2:
				_prefabLvl1StandardSelect.SetActive (false);
				_prefabLvl2StandardSelect.SetActive (true);
				_prefabLvl3StandardSelect.SetActive (false);
				_prefabLvl1DisintegratorSelect.SetActive (false);
				_prefabLvl2DisintegratorSelect.SetActive (false);
				_prefabLvl3DisintegratorSelect.SetActive (false);
				_prefabLvl1EMPSelect.SetActive (false);
				_prefabLvl2EMPSelect.SetActive (false);
				_prefabLvl3EMPSelect.SetActive (false);
				_prefabLvl1Standard.SetActive(false);
				_prefabLvl2Standard.SetActive(false);
				_prefabLvl3Standard.SetActive(false);
				_prefabLvl1Disintegrator.SetActive(false);
				_prefabLvl2Disintegrator.SetActive(false);
				_prefabLvl3Disintegrator.SetActive(false);
				_prefabLvl1EMP.SetActive(false);
				_prefabLvl2EMP.SetActive(false);
				_prefabLvl3EMP.SetActive(false);

				break;
			case 3:
				_prefabLvl1StandardSelect.SetActive (false);
				_prefabLvl2StandardSelect.SetActive (false);
				_prefabLvl3StandardSelect.SetActive (true);
				_prefabLvl1DisintegratorSelect.SetActive (false);
				_prefabLvl2DisintegratorSelect.SetActive (false);
				_prefabLvl3DisintegratorSelect.SetActive (false);
				_prefabLvl1EMPSelect.SetActive (false);
				_prefabLvl2EMPSelect.SetActive (false);
				_prefabLvl3EMPSelect.SetActive (false);
				_prefabLvl1Standard.SetActive(false);
				_prefabLvl2Standard.SetActive(false);
				_prefabLvl3Standard.SetActive(false);
				_prefabLvl1Disintegrator.SetActive(false);
				_prefabLvl2Disintegrator.SetActive(false);
				_prefabLvl3Disintegrator.SetActive(false);
				_prefabLvl1EMP.SetActive(false);
				_prefabLvl2EMP.SetActive(false);
				_prefabLvl3EMP.SetActive(false);
				break;
				
			}
		}
	}
	
	private void DisintegratorLvl(int lvl,bool isSelect){
		if (!isSelect) {
			switch (lvl) {
			case 1:
				_prefabLvl1Standard.SetActive (false);
				_prefabLvl2Standard.SetActive (false);
				_prefabLvl3Standard.SetActive (false);
				_prefabLvl1Disintegrator.SetActive (true);
				_prefabLvl2Disintegrator.SetActive (false);
				_prefabLvl3Disintegrator.SetActive (false);
				_prefabLvl1EMP.SetActive (false);
				_prefabLvl2EMP.SetActive (false);
				_prefabLvl3EMP.SetActive (false);
				_prefabLvl1StandardSelect.SetActive (false);
				_prefabLvl2StandardSelect.SetActive (false);
				_prefabLvl3StandardSelect.SetActive (false);
				_prefabLvl1DisintegratorSelect.SetActive (false);
				_prefabLvl2DisintegratorSelect.SetActive (false);
				_prefabLvl3DisintegratorSelect.SetActive (false);
				_prefabLvl1EMPSelect.SetActive (false);
				_prefabLvl2EMPSelect.SetActive (false);
				_prefabLvl3EMPSelect.SetActive (false);
				break;
			case 2:
				_prefabLvl1Standard.SetActive (false);
				_prefabLvl2Standard.SetActive (false);
				_prefabLvl3Standard.SetActive (false);
				_prefabLvl1Disintegrator.SetActive (false);
				_prefabLvl2Disintegrator.SetActive (true);
				_prefabLvl3Disintegrator.SetActive (false);
				_prefabLvl1EMP.SetActive (false);
				_prefabLvl2EMP.SetActive (false);
				_prefabLvl3EMP.SetActive (false);
				_prefabLvl1StandardSelect.SetActive (false);
				_prefabLvl2StandardSelect.SetActive (false);
				_prefabLvl3StandardSelect.SetActive (false);
				_prefabLvl1DisintegratorSelect.SetActive (false);
				_prefabLvl2DisintegratorSelect.SetActive (false);
				_prefabLvl3DisintegratorSelect.SetActive (false);
				_prefabLvl1EMPSelect.SetActive (false);
				_prefabLvl2EMPSelect.SetActive (false);
				_prefabLvl3EMPSelect.SetActive (false);
				break;
			case 3:
				_prefabLvl1Standard.SetActive (false);
				_prefabLvl2Standard.SetActive (false);
				_prefabLvl3Standard.SetActive (false);
				_prefabLvl1Disintegrator.SetActive (false);
				_prefabLvl2Disintegrator.SetActive (false);
				_prefabLvl3Disintegrator.SetActive (true);
				_prefabLvl1EMP.SetActive (false);
				_prefabLvl2EMP.SetActive (false);
				_prefabLvl3EMP.SetActive (false);
				_prefabLvl1StandardSelect.SetActive (false);
				_prefabLvl2StandardSelect.SetActive (false);
				_prefabLvl3StandardSelect.SetActive (false);
				_prefabLvl1DisintegratorSelect.SetActive (false);
				_prefabLvl2DisintegratorSelect.SetActive (false);
				_prefabLvl3DisintegratorSelect.SetActive (false);
				_prefabLvl1EMPSelect.SetActive (false);
				_prefabLvl2EMPSelect.SetActive (false);
				_prefabLvl3EMPSelect.SetActive (false);
				break;
			}
		}else {
			switch (lvl) {
			case 1:
				_prefabLvl1StandardSelect.SetActive (false);
				_prefabLvl2StandardSelect.SetActive (false);
				_prefabLvl3StandardSelect.SetActive (false);
				_prefabLvl1DisintegratorSelect.SetActive (true);
				_prefabLvl2DisintegratorSelect.SetActive (false);
				_prefabLvl3DisintegratorSelect.SetActive (false);
				_prefabLvl1EMPSelect.SetActive (false);
				_prefabLvl2EMPSelect.SetActive (false);
				_prefabLvl3EMPSelect.SetActive (false);
				_prefabLvl1Standard.SetActive(false);
				_prefabLvl2Standard.SetActive(false);
				_prefabLvl3Standard.SetActive(false);
				_prefabLvl1Disintegrator.SetActive(false);
				_prefabLvl2Disintegrator.SetActive(false);
				_prefabLvl3Disintegrator.SetActive(false);
				_prefabLvl1EMP.SetActive(false);
				_prefabLvl2EMP.SetActive(false);
				_prefabLvl3EMP.SetActive(false);
				break;
			case 2:
				_prefabLvl1StandardSelect.SetActive (false);
				_prefabLvl2StandardSelect.SetActive (false);
				_prefabLvl3StandardSelect.SetActive (false);
				_prefabLvl1DisintegratorSelect.SetActive (false);
				_prefabLvl2DisintegratorSelect.SetActive (true);
				_prefabLvl3DisintegratorSelect.SetActive (false);
				_prefabLvl1EMPSelect.SetActive (false);
				_prefabLvl2EMPSelect.SetActive (false);
				_prefabLvl3EMPSelect.SetActive (false);
				_prefabLvl1Standard.SetActive(false);
				_prefabLvl2Standard.SetActive(false);
				_prefabLvl3Standard.SetActive(false);
				_prefabLvl1Disintegrator.SetActive(false);
				_prefabLvl2Disintegrator.SetActive(false);
				_prefabLvl3Disintegrator.SetActive(false);
				_prefabLvl1EMP.SetActive(false);
				_prefabLvl2EMP.SetActive(false);
				_prefabLvl3EMP.SetActive(false);
				break;
			case 3:
				_prefabLvl1StandardSelect.SetActive (false);
				_prefabLvl2StandardSelect.SetActive (false);
				_prefabLvl3StandardSelect.SetActive (false);
				_prefabLvl1DisintegratorSelect.SetActive (false);
				_prefabLvl2DisintegratorSelect.SetActive (false);
				_prefabLvl3DisintegratorSelect.SetActive (true);
				_prefabLvl1EMPSelect.SetActive (false);
				_prefabLvl2EMPSelect.SetActive (false);
				_prefabLvl3EMPSelect.SetActive (false);
				_prefabLvl1Standard.SetActive(false);
				_prefabLvl2Standard.SetActive(false);
				_prefabLvl3Standard.SetActive(false);
				_prefabLvl1Disintegrator.SetActive(false);
				_prefabLvl2Disintegrator.SetActive(false);
				_prefabLvl3Disintegrator.SetActive(false);
				_prefabLvl1EMP.SetActive(false);
				_prefabLvl2EMP.SetActive(false);
				_prefabLvl3EMP.SetActive(false);
				break;
				
			}
		}
	}
	
	private void EMPLvl(int lvl,bool isSelect){
		if (!isSelect) {
			switch (lvl) {
			case 1:
				_prefabLvl1Standard.SetActive(false);
				_prefabLvl2Standard.SetActive(false);
				_prefabLvl3Standard.SetActive(false);
				_prefabLvl1Disintegrator.SetActive(false);
				_prefabLvl2Disintegrator.SetActive(false);
				_prefabLvl3Disintegrator.SetActive(false);
				_prefabLvl1EMP.SetActive(true);
				_prefabLvl2EMP.SetActive(false);
				_prefabLvl3EMP.SetActive(false);
				_prefabLvl1StandardSelect.SetActive (false);
				_prefabLvl2StandardSelect.SetActive (false);
				_prefabLvl3StandardSelect.SetActive (false);
				_prefabLvl1DisintegratorSelect.SetActive (false);
				_prefabLvl2DisintegratorSelect.SetActive (false);
				_prefabLvl3DisintegratorSelect.SetActive (false);
				_prefabLvl1EMPSelect.SetActive (false);
				_prefabLvl2EMPSelect.SetActive (false);
				_prefabLvl3EMPSelect.SetActive (false);
				break;
			case 2:
				_prefabLvl1Standard.SetActive(false);
				_prefabLvl2Standard.SetActive(false);
				_prefabLvl3Standard.SetActive(false);
				_prefabLvl1Disintegrator.SetActive(false);
				_prefabLvl2Disintegrator.SetActive(false);
				_prefabLvl3Disintegrator.SetActive(false);
				_prefabLvl1EMP.SetActive(false);
				_prefabLvl2EMP.SetActive(true);
				_prefabLvl3EMP.SetActive(false);
				_prefabLvl1StandardSelect.SetActive (false);
				_prefabLvl2StandardSelect.SetActive (false);
				_prefabLvl3StandardSelect.SetActive (false);
				_prefabLvl1DisintegratorSelect.SetActive (false);
				_prefabLvl2DisintegratorSelect.SetActive (false);
				_prefabLvl3DisintegratorSelect.SetActive (false);
				_prefabLvl1EMPSelect.SetActive (false);
				_prefabLvl2EMPSelect.SetActive (false);
				_prefabLvl3EMPSelect.SetActive (false);
				break;
			case 3:
				_prefabLvl1Standard.SetActive(false);
				_prefabLvl2Standard.SetActive(false);
				_prefabLvl3Standard.SetActive(false);
				_prefabLvl1Disintegrator.SetActive(false);
				_prefabLvl2Disintegrator.SetActive(false);
				_prefabLvl3Disintegrator.SetActive(false);
				_prefabLvl1EMP.SetActive(false);
				_prefabLvl2EMP.SetActive(false);
				_prefabLvl3EMP.SetActive(true);
				_prefabLvl1StandardSelect.SetActive (false);
				_prefabLvl2StandardSelect.SetActive (false);
				_prefabLvl3StandardSelect.SetActive (false);
				_prefabLvl1DisintegratorSelect.SetActive (false);
				_prefabLvl2DisintegratorSelect.SetActive (false);
				_prefabLvl3DisintegratorSelect.SetActive (false);
				_prefabLvl1EMPSelect.SetActive (false);
				_prefabLvl2EMPSelect.SetActive (false);
				_prefabLvl3EMPSelect.SetActive (false);
				break;
			}
		}else{
			switch (lvl) {
			case 1:
				_prefabLvl1StandardSelect.SetActive(false);
				_prefabLvl2StandardSelect.SetActive(false);
				_prefabLvl3StandardSelect.SetActive(false);
				_prefabLvl1DisintegratorSelect.SetActive(false);
				_prefabLvl2DisintegratorSelect.SetActive(false);
				_prefabLvl3DisintegratorSelect.SetActive(false);
				_prefabLvl1EMPSelect.SetActive(true);
				_prefabLvl2EMPSelect.SetActive(false);
				_prefabLvl3EMPSelect.SetActive(false);
				_prefabLvl1Standard.SetActive(false);
				_prefabLvl2Standard.SetActive(false);
				_prefabLvl3Standard.SetActive(false);
				_prefabLvl1Disintegrator.SetActive(false);
				_prefabLvl2Disintegrator.SetActive(false);
				_prefabLvl3Disintegrator.SetActive(false);
				_prefabLvl1EMP.SetActive(false);
				_prefabLvl2EMP.SetActive(false);
				_prefabLvl3EMP.SetActive(false);
				break;
			case 2:
				_prefabLvl1StandardSelect.SetActive(false);
				_prefabLvl2StandardSelect.SetActive(false);
				_prefabLvl3StandardSelect.SetActive(false);
				_prefabLvl1DisintegratorSelect.SetActive(false);
				_prefabLvl2DisintegratorSelect.SetActive(false);
				_prefabLvl3DisintegratorSelect.SetActive(false);
				_prefabLvl1EMPSelect.SetActive(false);
				_prefabLvl2EMPSelect.SetActive(true);
				_prefabLvl3EMPSelect.SetActive(false);
				_prefabLvl1Standard.SetActive(false);
				_prefabLvl2Standard.SetActive(false);
				_prefabLvl3Standard.SetActive(false);
				_prefabLvl1Disintegrator.SetActive(false);
				_prefabLvl2Disintegrator.SetActive(false);
				_prefabLvl3Disintegrator.SetActive(false);
				_prefabLvl1EMP.SetActive(false);
				_prefabLvl2EMP.SetActive(false);
				_prefabLvl3EMP.SetActive(false);
				break;
			case 3:
				_prefabLvl1StandardSelect.SetActive(false);
				_prefabLvl2StandardSelect.SetActive(false);
				_prefabLvl3StandardSelect.SetActive(false);
				_prefabLvl1DisintegratorSelect.SetActive(false);
				_prefabLvl2DisintegratorSelect.SetActive(false);
				_prefabLvl3DisintegratorSelect.SetActive(false);
				_prefabLvl1EMPSelect.SetActive(false);
				_prefabLvl2EMPSelect.SetActive(false);
				_prefabLvl3EMPSelect.SetActive(true);
				_prefabLvl1Standard.SetActive(false);
				_prefabLvl2Standard.SetActive(false);
				_prefabLvl3Standard.SetActive(false);
				_prefabLvl1Disintegrator.SetActive(false);
				_prefabLvl2Disintegrator.SetActive(false);
				_prefabLvl3Disintegrator.SetActive(false);
				_prefabLvl1EMP.SetActive(false);
				_prefabLvl2EMP.SetActive(false);
				_prefabLvl3EMP.SetActive(false);
				break;
			}
			
		}
	}
	
}

