using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InvotoryManager : MonoBehaviour {

	private List<GameObject> Invotory = new List<GameObject>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Interact")){
			RaycastHit hit;
			Ray ray = gameObject.GetComponentInChildren<Camera>().ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2));
			
			if(Physics.Raycast(ray, out hit)){
				if(hit.transform.gameObject.tag == "Interactable"){
					Invotory.Add(hit.collider.gameObject);
				}
			}
		}
	}

	public List<GameObject> getInvotory(){
		return Invotory;
	}
	
}
