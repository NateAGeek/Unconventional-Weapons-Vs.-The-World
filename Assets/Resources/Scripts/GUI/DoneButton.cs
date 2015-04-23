using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DoneButton : MonoBehaviour {

	public GameObject MadeWeapon;
	public GameObject Player;
	public Transform  PlayerHand;
	private Button dButton;

	// Use this for initialization
	void Start () {
		dButton = GetComponent<Button> ();
		dButton.onClick.AddListener (() => {
			MadeWeapon.transform.SetParent(PlayerHand, false);
			Player.GetComponent<PlayerObjectScript>().setFreeze(false);
			transform.parent.gameObject.SetActive(false);
		});
	}
	
	public void setMadeWeapon(GameObject mweapon){
		MadeWeapon = mweapon;
	}
}
