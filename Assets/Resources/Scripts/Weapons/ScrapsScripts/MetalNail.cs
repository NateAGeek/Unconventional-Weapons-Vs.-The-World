using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MetalNail : MonoBehaviour, ScrapPiece {
	
	private List<string> funtionality = new List<string>() {"Ammo", "CrapInside"}; 
	private int health = 100;
	private string currentType = "default";
	private MeshFilter meshFilter;
    private string ScrapPieceMetalNailName = "MetalNail";

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
		Debug.Log ("Loading Nail: "+"Models/MetalNail_" + type);
		//Mesh mesh = Resources.Load("Models/MetalNail_" + type) as Mesh;
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
        return ScrapPieceMetalNailName;
    }
	
	public void onBroken(){
		
	}
	
	public void isBroken(){
		
	}
}

