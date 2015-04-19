using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {
	public Transform inventoryMenu;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Open Inventory")){
			inventoryMenu.gameObject.SetActive(!inventoryMenu.gameObject.activeSelf);
		}
	}
}
