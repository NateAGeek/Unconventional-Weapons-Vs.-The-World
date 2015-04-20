using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GUIInventory : MonoBehaviour {

	public GameObject InventoryItemPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Add(GameObject itemObject){
		GameObject invoItem = Instantiate(InventoryItemPrefab) as GameObject;
		GUIInventorytItem props = invoItem.GetComponent<GUIInventorytItem>();
		props.iteamObjectRefrance = itemObject;
		invoItem.name = itemObject.GetComponent<ScrapPiece>().name();
		invoItem.transform.parent = transform;
		
		Text iteamName = invoItem.transform.Find("ItemName").GetComponent<Text>();
		iteamName.text = itemObject.GetComponent<ScrapPiece>().name(); 
	}
	
	public void InitiateInventory(List<GameObject> scraps){
		foreach(GameObject scrap in scraps){
			GameObject invoItem = Instantiate(InventoryItemPrefab) as GameObject;
			GUIInventorytItem props = invoItem.GetComponent<GUIInventorytItem>();
			props.iteamObjectRefrance = scrap;
			invoItem.name = scrap.GetComponent<ScrapPiece>().name();
			invoItem.transform.parent = transform;

			Text iteamName = invoItem.transform.Find("ItemName").GetComponent<Text>();
			iteamName.text = scrap.GetComponent<ScrapPiece>().name(); 

		}
	}

	public void FilterInventory(string filterTag){
		foreach (Transform child in transform) {
//			ScrapPiece scrapChild = child.gameObject.GetComponent<ScrapPiece>();
//			if (!scrapChild.canFunctionAs(filterTag)){
//				child.gameObject.SetActive(false);
//			}
			Debug.Log("Filtering by:"+filterTag+". GameObject name:"+child.gameObject.name);
		}
	}
}
