using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GUIInventory : MonoBehaviour {

	public GameObject InventoryItemPrefab;

	private string inventoryMode = "None";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Add(GameObject itemObject){
		GameObject invoItem = Instantiate(InventoryItemPrefab) as GameObject;
		GUIInventorytItem props = invoItem.GetComponent<GUIInventorytItem>();
		props.itemObjectRefrance = itemObject;
		invoItem.name = itemObject.GetComponent<ScrapPiece>().name();
		invoItem.transform.SetParent (transform, false);
		
		Text iteamName = invoItem.transform.Find("ItemName").GetComponent<Text>();
		iteamName.text = itemObject.GetComponent<ScrapPiece>().name(); 
	}
	
	public void InitiateInventory(List<GameObject> scraps){
		foreach(GameObject scrap in scraps){
			GameObject invoItem = Instantiate(InventoryItemPrefab) as GameObject;
			GUIInventorytItem props = invoItem.GetComponent<GUIInventorytItem>();
			props.itemObjectRefrance = scrap;
			invoItem.name = scrap.GetComponent<ScrapPiece>().name();
			invoItem.transform.SetParent(transform, false);

			Text iteamName = invoItem.transform.Find("ItemName").GetComponent<Text>();
			iteamName.text = scrap.GetComponent<ScrapPiece>().name(); 

		}
	}

	public void FilterInventory(string filterTag){
		foreach (Transform child in transform) {
			GUIInventorytItem invenItem = child.gameObject.GetComponent<GUIInventorytItem>();
			ScrapPiece scrapChild = invenItem.itemObjectRefrance.GetComponent<ScrapPiece>();

			Debug.Log("Filtering by: "+filterTag);

			if (!scrapChild.canFunctionAs(filterTag)){
				child.gameObject.SetActive(false);
			}
		}
	}

	public void FilterInventoryAndSetWorkbenchMode(string filterTag, GameObject recipeSlotSelection){
		foreach (Transform child in transform) {
			GUIInventorytItem invenItem = child.gameObject.GetComponent<GUIInventorytItem>();
			ScrapPiece scrapChild = invenItem.itemObjectRefrance.GetComponent<ScrapPiece>();
			
			Debug.Log("Filtering by: "+filterTag);
			
			if (!scrapChild.canFunctionAs(filterTag)){
				child.gameObject.SetActive(false);
				continue;
			}
			
			invenItem.setWorkbenchSelection("RecipeSelect", recipeSlotSelection.transform);
		}
	}

	public void setMode(string mode){
		inventoryMode = mode;
	}
}
