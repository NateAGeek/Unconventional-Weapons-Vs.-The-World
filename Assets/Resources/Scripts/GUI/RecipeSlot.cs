using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RecipeSlot : MonoBehaviour {

	public GameObject RecipeSlotNameObject;
	public GameObject RecipeSlotButtonObject;
	
	private Text RecipeSlotNameText;
	private Button RecipeSlotButton;
	private bool required = false;

	void Awake(){
		RecipeSlotNameText = RecipeSlotNameObject.GetComponent<Text>();
		RecipeSlotButton = RecipeSlotButtonObject.GetComponent<Button>();
	}

	// Use this for initialization
	void Start () {

	}

	public void setRecipeName(string text){
		RecipeSlotNameText.text = text;
	}

	public void setRequired(bool req){
		required = req;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
