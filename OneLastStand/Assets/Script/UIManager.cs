using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIManager : MonoBehaviour{


	public GameObject _prefabButton;

	public List<ButtonScript> _listTurretButton;
	public List<ButtonScript> _listUpgradeButton;


	void Start () {
		_listTurretButton = new List<ButtonScript>();
	}

	public void StartShoot ()
	{

	}

	public void StartConstruction ()
	{
	}

	void Update(){

	}

	public void UpdateConstruction () {
	}

	public void UpdateShoot () {
	}
}
