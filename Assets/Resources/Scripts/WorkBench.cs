using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class WorkBench : MonoBehaviour {
	
	public GameObject WeaponRecipeGUI;
	public GameObject InventoryGUI;
	public GameObject dButton;
	
	private List<GameObject> Recipes = new List<GameObject>();
	
	void Start () {

		GameObject WeaponObject = Instantiate (Resources.Load("Prefabs/MeleeWeapon")) as GameObject;
		WeaponObject.name = "WeaponCrafting";
		WeaponObject.transform.SetParent(transform, false);

		Recipes.Add(WeaponObject);
		
		foreach (KeyValuePair<string, bool> recipe in Recipes[0].GetComponent<IWeaponOutfit>().getRecipe()) {
			GameObject GUIRecipeSlot = Instantiate(Resources.Load("Prefabs/GUI/RecipeSlot")) as GameObject;
			RecipeSlot recipeSlot    = GUIRecipeSlot.GetComponent<RecipeSlot>();

			GUIRecipeSlot.name = recipe.Key;
			recipeSlot.setRecipeName(recipe.Key);
			recipeSlot.setRequired(recipe.Value);

			Button recipeSlotButton = recipeSlot.getButton();
			GUIInventory inven = InventoryGUI.GetComponent<GUIInventory>();

			Debug.Log("Bulilding Recipe with name: "+recipe.Key+"...");

			recipeSlotButton.onClick.AddListener(() => {
				inven.FilterInventoryAndSetWorkbenchMode(GUIRecipeSlot.name, WeaponObject.transform.Find(GUIRecipeSlot.name).gameObject);
				inven.setMode("WorkBench");
				InventoryGUI.SetActive(true);
			});

			GUIRecipeSlot.transform.SetParent(WeaponRecipeGUI.transform, false);
			dButton.GetComponent<DoneButton>().setMadeWeapon(WeaponObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}