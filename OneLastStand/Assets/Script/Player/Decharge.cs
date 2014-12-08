using UnityEngine;
using System.Collections;

public class Decharge : MonoBehaviour{

	public int _quantiteFragment;

	public GameObject _labelPrefab;

	public UITexture _textureDecharge;
	public Enum_DechargeQuantity _enumDechargeQuantity = Enum_DechargeQuantity.None; 

	public string _pathDerchargeTextureFull = "Decharge/nom_Image";
	public string _pathDerchargeTextureMoyen = "";
	public string _pathDerchargeTextureFew = "";
	public string _pathDerchargeTextureNone = "";

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

	public void ChangeTexture(){
		//TODO Lié dynamiquement les texture au _enumDeachargeQuantity;
		// _textureDecharge.mainTexture = Resources.Load<Texture2D> (pathTextureBase); (Return Textur2D
	}

	public void addFragment(int frag){
		_quantiteFragment += frag;
		GameObject label = (GameObject)Instantiate (_labelPrefab,this.transform.position, Quaternion.identity);
		label.transform.parent = this.transform;
		label.GetComponent<UILabel> ().color = ConstantesManager.FRAGMENT_LABEL_COLOR;
		label.GetComponent<UILabel> ().text = "+" + frag;
	}

	public void subFragment(int frag){
		//Debug.Log ("Sub Fragmen");
		_quantiteFragment -= frag;
		GameObject label = (GameObject)Instantiate (_labelPrefab,this.transform.position, Quaternion.identity);
		label.transform.parent = this.transform;
		label.GetComponent<UILabel> ().color = ConstantesManager.FRAGMENT_LABEL_COLOR;
		label.GetComponent<UILabel> ().text = "-" + frag;
	}
}

