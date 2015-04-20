using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WoodPlank : MonoBehaviour, ScrapPiece {
	
	private List<string> funtionality = new List<string>() {"Stock", "Base", "CrapInside"}; 
	private int health = 100;
	private string currentType = "default";
	private MeshFilter meshFilter;
    private string ScrapPieceName = "WoodPlank";

	void Start(){
		meshFilter = GetComponent<MeshFilter>();
		setMesh(currentType);
	}

	public void setFunctionality(string type, Vector3 scrap_postition){
		setMesh(type);
		currentType = type;
		transform.position = scrap_postition;
	}

	public void setMesh(string type){
		Debug.Log ("Loading Wood: "+"Models/MetalNail_" + type +".blend");
		//Mesh mesh = Resources.Load ("Models/WoodPlank_" + type+".blend") as Mesh;
		//meshFilter.mesh = mesh;
	}

	public bool canFunctionAs(string type){
		if (funtionality.Contains (type)) {
			return true;
		}
		return false;
	}
	
	public int getHealth(){
		return health;
	}
	
	public void onAttach(){


	}

    public string name() {
        return ScrapPieceName;
    }
	
	public void onBroken(){

	}

	public void isBroken(){

	}
}
