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

	public void InitiateInventory(List<GameObject> scraps){
		foreach(GameObject scrap in scraps){
			GameObject invoItem = Instantiate(InventoryItemPrefab) as GameObject;
			invoItem.transform.parent = transform;

			Text iteamName = invoItem.transform.Find("ItemName").GetComponent<Text>();
			iteamName.text = scrap.GetComponent<ScrapPiece>().name(); 

		}
	}
}
