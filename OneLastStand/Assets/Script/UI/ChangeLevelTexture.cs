using UnityEngine;
using System.Collections;

public class ChangeLevelTexture : MonoBehaviour
{
	public GameObject _prefabLvl1;
	public GameObject _prefabLvl2;
	public GameObject _prefabLvl3;

	public void ChangeLevel(int lvl){
		switch (lvl) {
		case 1:
			_prefabLvl1.SetActive(true);
			_prefabLvl2.SetActive(false);
			_prefabLvl3.SetActive(false);
			break;
		case 2:
			_prefabLvl1.SetActive(false);
			_prefabLvl2.SetActive(true);
			_prefabLvl3.SetActive(false);
			break;
		case 3:
			_prefabLvl1.SetActive(false);
			_prefabLvl2.SetActive(false);
			_prefabLvl3.SetActive(true);
			break;
		default:
			Debug.Log ("Wrong lvl in " + this.gameObject.name);
			break;

		}


	}
}

