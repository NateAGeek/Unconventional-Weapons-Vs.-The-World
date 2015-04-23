using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {

	public Camera     camera;
	public GameObject GameHUDCanvas;

	private PlayerObjectScript player;    

	private string    CurrentAction     = "None";
	private string    CurrentMenu       = "HUD";
	
	//Game HUD
	private GameObject GameHUD;
	private GameObject WorkBenchHUD;
	private GameObject InventoryHUD;


	// Use this for initialization
	void Start () {
		player = GetComponent<PlayerObjectScript>();
		if (GameHUDCanvas != null) {
			GameHUD = GameHUDCanvas.transform.Find ("HUD").gameObject;
			WorkBenchHUD = GameHUDCanvas.transform.Find ("WorkBenchMenu").gameObject;
			InventoryHUD = GameHUDCanvas.transform.Find("Inventory").gameObject;
		}
	}
	
	// Update is called once per frame
	void Update () {
		//Menu controls
		if (Input.GetButtonDown ("Interact") && CurrentAction == "None") {
			RaycastHit hit;
			Ray ray = camera.ScreenPointToRay (new Vector3 (Screen.width / 2, Screen.height / 2, 0.0f));
			
			if (Physics.Raycast (ray, out hit, 1.0f)) {
				if (hit.collider.tag == "WorkBench") {
					player.setFreeze(true);
					CurrentAction = "WorkBench";
					WorkBenchHUD.SetActive (true);
					GameHUD.SetActive (false);
				}
			}			
		} else if (Input.GetButtonDown ("Interact") && CurrentAction == "WorkBench") {
			player.setFreeze(false);
			CurrentAction = "None";
			WorkBenchHUD.SetActive (false);
			GameHUD.SetActive (true);
		} else if (Input.GetButtonDown("Inventory") && CurrentAction == "None") {
			player.setFreeze(true);
			CurrentAction = "Inventory";
			InventoryHUD.SetActive (true);
			GameHUD.SetActive (false);
		} else if (Input.GetButtonDown("Inventory") && CurrentAction == "Inventory") {
			player.setFreeze(false);
			CurrentAction = "None";
			InventoryHUD.SetActive (false);
			GameHUD.SetActive (true);
		}
	}
}
