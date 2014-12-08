using UnityEngine;
using System.Collections;

public class Decharge : MonoBehaviour{

	public int _quantiteFragment;

	public GameObject _labelPrefab;

	public UITexture _textureDecharge;
	public Enum_DechargeQuantity _enumDechargeQuantity = Enum_DechargeQuantity.None; 

	public string _pathDerchargeTextureFull = "Decharge/Decharge1";
	public string _pathDerchargeTextureMoyen = "Decharge/Decharge2";
	public string _pathDerchargeTextureFew = "Decharge/Decharge3";
	public string _pathDerchargeTextureNone = "";

	public GameObject _textureFew;
	public GameObject _textureMoy;
	public GameObject _textureFull;

	void Start(){
		_quantiteFragment = 0;
	}

	public void StartShoot ()
	{
	}

	public void StartConstruction ()
	{
	}
	
	public void UpdateShoot (){
	
	}

	public void UpdateConstruction (){
		
	}

	public void Update (){
		if (_quantiteFragment <= 5000) {
			_enumDechargeQuantity = Enum_DechargeQuantity.Few;
		}else if (_quantiteFragment <= 10000) {
			_enumDechargeQuantity = Enum_DechargeQuantity.Moyen;
		}else if (_quantiteFragment <= 15000) {
			_enumDechargeQuantity = Enum_DechargeQuantity.Full;
		}

		UpdateTexture();
	}



	public void UpdateTexture(){
		switch (_enumDechargeQuantity) {
			case Enum_DechargeQuantity.Few:
				_textureFew.SetActive(true);
				_textureMoy.SetActive(false);
				_textureFull.SetActive(false);
				break;
			case Enum_DechargeQuantity.Moyen:
				_textureFew.SetActive(false);
				_textureMoy.SetActive(true);
				_textureFull.SetActive(false);

				break;

			case Enum_DechargeQuantity.Full:
				_textureFew.SetActive(false);
				_textureMoy.SetActive(false);
				_textureFull.SetActive(true);
				break;


			}
	}

	public void addFragment(int frag){
		_quantiteFragment += frag;
		GameObject label = (GameObject)Instantiate (_labelPrefab,this.transform.position, Quaternion.identity);
		label.transform.parent = this.transform;
		label.transform.localPosition = new Vector3 (0, 100, 0);
		label.GetComponent<UILabel> ().color = ConstantesManager.FRAGMENT_LABEL_COLOR;
		label.GetComponent<UILabel> ().text = "+" + frag;
	}

	public void subFragment(int frag){
		//Debug.Log ("Sub Fragmen");
		_quantiteFragment -= frag;
		GameObject label = (GameObject)Instantiate (_labelPrefab,this.transform.position, Quaternion.identity);
		label.transform.parent = this.transform;
		label.transform.localPosition = new Vector3 (0, 100, 0);
		label.GetComponent<UILabel> ().color = ConstantesManager.FRAGMENT_LABEL_COLOR;
		label.GetComponent<UILabel> ().text = "-" + frag;
	}
}

