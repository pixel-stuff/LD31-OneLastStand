using UnityEngine;
using System.Collections;

public class ChangeButton : MonoBehaviour
{
	GameObject _prefabLvl1Standard;
	GameObject _prefabLvl2Standard;
	GameObject _prefabLvl3Standard;
	GameObject _prefabLvl1EMP;
	GameObject _prefabLvl2EMP;
	GameObject _prefabLvl3EMP;
	GameObject _prefabLvl1Disintegrator;
	GameObject _prefabLvl2Disintegrator;
	GameObject _prefabLvl3Disintegrator;


	public void ChangeButtonFonction(int lvl, Enum_TurretType typeTur){
		switch (typeTur) {
		case Enum_TurretType.Disintegrator:
				DisintegratorLvl(lvl);
			break;
		case Enum_TurretType.EMP:
			StandardLvl(lvl);
			break;
		case Enum_TurretType.Standard:
			EMPLvl( lvl);
			break;
		}
	}

	private void StandardLvl(int lvl){
		switch (lvl) {
		case 1:
			_prefabLvl1Standard.SetActive(true);
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
			_prefabLvl1Standard.SetActive(false);
			_prefabLvl2Standard.SetActive(true);
			_prefabLvl3Standard.SetActive(false);
			_prefabLvl1Disintegrator.SetActive(false);
			_prefabLvl2Disintegrator.SetActive(false);
			_prefabLvl3Disintegrator.SetActive(false);
			_prefabLvl1EMP.SetActive(false);
			_prefabLvl2EMP.SetActive(false);
			_prefabLvl3EMP.SetActive(false);
			break;
		case 3:
			_prefabLvl1Standard.SetActive(false);
			_prefabLvl2Standard.SetActive(false);
			_prefabLvl3Standard.SetActive(true);
			_prefabLvl1Disintegrator.SetActive(false);
			_prefabLvl2Disintegrator.SetActive(false);
			_prefabLvl3Disintegrator.SetActive(false);
			_prefabLvl1EMP.SetActive(false);
			_prefabLvl2EMP.SetActive(false);
			_prefabLvl3EMP.SetActive(false);
			break;

		}
	
	}

	private void DisintegratorLvl(int lvl){
		switch (lvl) {
		case 1:
			_prefabLvl1Standard.SetActive(false);
			_prefabLvl2Standard.SetActive(false);
			_prefabLvl3Standard.SetActive(false);
			_prefabLvl1Disintegrator.SetActive(true);
			_prefabLvl2Disintegrator.SetActive(false);
			_prefabLvl3Disintegrator.SetActive(false);
			_prefabLvl1EMP.SetActive(false);
			_prefabLvl2EMP.SetActive(false);
			_prefabLvl3EMP.SetActive(false);
			break;
		case 2:
			_prefabLvl1Standard.SetActive(false);
			_prefabLvl2Standard.SetActive(false);
			_prefabLvl3Standard.SetActive(false);
			_prefabLvl1Disintegrator.SetActive(false);
			_prefabLvl2Disintegrator.SetActive(true);
			_prefabLvl3Disintegrator.SetActive(false);
			_prefabLvl1EMP.SetActive(false);
			_prefabLvl2EMP.SetActive(false);
			_prefabLvl3EMP.SetActive(false);
			break;
		case 3:
			_prefabLvl1Standard.SetActive(false);
			_prefabLvl2Standard.SetActive(false);
			_prefabLvl3Standard.SetActive(false);
			_prefabLvl1Disintegrator.SetActive(false);
			_prefabLvl2Disintegrator.SetActive(false);
			_prefabLvl3Disintegrator.SetActive(true);
			_prefabLvl1EMP.SetActive(false);
			_prefabLvl2EMP.SetActive(false);
			_prefabLvl3EMP.SetActive(false);
			break;
		}
	}

	private void EMPLvl(int lvl){
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
			break;
		}
	}

}

