using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIInventorytItem : MonoBehaviour {

	public GameObject itemObjectRefrance;
	private GameObject inventoryGUIRefrance;
	private Button activeButton;

	void Awake(){
		activeButton = GetComponentInChildren<Button> ();
	}

	public void setWorkbenchSelection(string mode, Transform selectionParent){
		inventoryGUIRefrance = transform.parent.gameObject;
		if (mode == "RecipeSelect") {
			activeButton.onClick.AddListener(() => {

				Rigidbody rig = itemObjectRefrance.GetComponent<Rigidbody>();
				Collider  col = itemObjectRefrance.GetComponent<Collider>();
				rig.isKinematic = true;
				col.enabled = false;

				itemObjectRefrance.transform.SetParent(selectionParent, false);
				itemObjectRefrance.SetActive(true);
				inventoryGUIRefrance.SetActive(false);

				//Reset the inven iteams to vis
				foreach (Transform child in inventoryGUIRefrance.transform) {
						child.gameObject.SetActive(true);
				}
				//Remove form InvoItem
				Destroy(gameObject);
			});
		}
		else{
			activeButton.onClick.RemoveAllListeners();
		}

	}

}
