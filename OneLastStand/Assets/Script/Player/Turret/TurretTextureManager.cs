using UnityEngine;
using System.Collections;

public class TurretTextureManager : MonoBehaviour{

	public string _pathFolderRoot;
	public string _pathTypeTurret;


	public string _textureLvl1; //1
	public string _textureLvl2; //2
	public string _textureLvl3; //3
	public string _destroy; 	//4
	public string _none;		//5

	public UITexture _currentTexture;
	private int _currentIntTexture;
	
	// Use this for initialization
	void Start (){
		_currentIntTexture = 5;

	}

	// Update is called once per frame
	void Update (){
		string pathTexture = "";
		switch (_currentIntTexture) {
			case 1:
				pathTexture = _pathFolderRoot + "/" + _pathTypeTurret + "/" + _textureLvl1;
				_currentTexture.mainTexture = Resources.Load<Texture2D> (pathTexture);
			break;
			case 2:
				pathTexture = _pathFolderRoot + "/" + _pathTypeTurret + "/" + _textureLvl2;
				_currentTexture.mainTexture = Resources.Load<Texture2D> (pathTexture);
				break; 
			case 3:
				pathTexture = _pathFolderRoot + "/" + _pathTypeTurret + "/" + _textureLvl3;
				_currentTexture.mainTexture = Resources.Load<Texture2D> (pathTexture);
				break; 
			case 4:
				pathTexture = _pathFolderRoot + "/" + _pathTypeTurret + "/" + _destroy;
				_currentTexture.mainTexture = Resources.Load<Texture2D> (pathTexture);
				break;   
			case 5:
				pathTexture = _pathFolderRoot + "/" + _pathTypeTurret + "/" + _none;
				_currentTexture.mainTexture = Resources.Load<Texture2D> (pathTexture);
				break;  
			default: 
				Debug.Log ("Wrong _currentIntTexture in " + this.gameObject.name); 
				break;
		}
	}
	

	public void changeLvl(int lvl){
		_currentIntTexture = lvl;
	}
}

