using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class WorkBench : MonoBehaviour {
	
	public GameObject WeaponRecipeGUI;
	public GameObject InventoryGUI;
	
	private List<IWeaponOutfit> Recipes = new List<IWeaponOutfit>();
	
	void Start () {
		
		Recipes.Add(new MeleeWeapon());
		
		foreach (KeyValuePair<string, bool> recipe in Recipes[0].getRecipe()) {
			GameObject GUIRecipeSlot = Instantiate(Resources.Load("Prefabs/GUI/RecipeSlot")) as GameObject;
			RecipeSlot recipeSlot    = GUIRecipeSlot.GetComponent<RecipeSlot>();

			recipeSlot.setRecipeName(recipe.Key);
			recipeSlot.setRequired(recipe.Value);

			Button recipeSlotButton = recipeSlot.getButton();
			GUIInventory inven = InventoryGUI.GetComponent<GUIInventory>();

			recipeSlotButton.onClick.AddListener(() => {
				inven.FilterInventory(recipe.Key);
				InventoryGUI.SetActive(true);
			});

			GUIRecipeSlot.transform.parent = WeaponRecipeGUI.transform;

		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}