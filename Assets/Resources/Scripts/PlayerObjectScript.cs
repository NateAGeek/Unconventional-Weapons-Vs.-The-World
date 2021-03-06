﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerObjectScript: HealthManager {

	//Public Prefrancese
	public Vector2    sensitivity       = new Vector2(10.0f, 10.0f);
	public float      speed             = 5.0f;
	public float      jumpVelocity      = 5.0f;
	public float      knockbackDistance = 5.0f;
	public GameObject GameHUDCanvas;
	public GameObject InventoryBag;

	//Component Vars
	private Rigidbody rigidbody;
	private Camera    camera;

	// Movement Vars
	private Vector2   rotationMin       = new Vector2(-360.0f, -60.0f);
	private Vector2   rotationMax       = new Vector2(360.0f, 60.0f);
	private Vector3   rotation          = new Vector3(0.0f, 0.0f, 0.0f);
	private bool      onGround          = true;
	private bool      hitSomethingInAir = false;
	private bool      freeze            = false;

	private List<GameObject> Inventory = new List<GameObject>();

	private GUIInventory InventoryGUI;
	private GameObject InventoryHUD;

    void Start() {
		if (maxHealth == 0) {
			maxHealth = 500;
		}
		//TODO: remove this once weapons are the things that actually do damage
		maxDamage = 15;

		//Add Temp items?
//		Inventory.Add(Instantiate(Resources.Load("Prefabs/MetalNail")) as GameObject);
//		Inventory.Add(Instantiate(Resources.Load("Prefabs/WoodPlank")) as GameObject);

		currentHealth = maxHealth;
		camera = GetComponentInChildren<Camera>();
		rigidbody = GetComponent<Rigidbody>();
		InventoryBag = transform.Find("InventoryBag").gameObject;
		if (GameHUDCanvas != null) {
			InventoryHUD = GameHUDCanvas.transform.Find("Inventory").gameObject;

			InventoryGUI = InventoryHUD.GetComponent<GUIInventory>();
			InventoryGUI.InitiateInventory(Inventory);
		}
    }

    void Update() {

		//Check if frozen for movment and other abilities to be active
		if (!freeze) {
			//Do the Calculations for rotation
			rotation.x += Input.GetAxis ("Mouse X") * sensitivity.x;
			rotation.y += Input.GetAxis ("Mouse Y") * sensitivity.y;
			rotation.y = Mathf.Clamp (rotation.y, rotationMin.y, rotationMax.y);

			transform.localEulerAngles = new Vector3 (0.0f, rotation.x, 0.0f);
			camera.transform.localEulerAngles = new Vector3 (-rotation.y, 0.0f, 0.0f);

			//Movement Controls
			if (!hitSomethingInAir) {
				Vector3 targetVelocity = new Vector3 (Input.GetAxis ("Horizontal"), 0.0f, Input.GetAxis ("Vertical"));
				targetVelocity = transform.TransformDirection (targetVelocity);
				targetVelocity = new Vector3 (targetVelocity.x * speed, rigidbody.velocity.y, targetVelocity.z * speed);
				Vector3 velocityChange = targetVelocity - rigidbody.velocity;

				rigidbody.AddForce (velocityChange, ForceMode.VelocityChange);
			}
			if (Input.GetButtonDown ("Crouch")) {
				transform.localScale -= new Vector3 (0.0f, 0.25f, 0.0f);
			}
			if (Input.GetButtonUp ("Crouch")) {
				transform.localScale += new Vector3 (0.0f, 0.25f, 0.0f);
			}
			if (Input.GetButtonDown ("Sprint")) {
				this.speed = 10f;
			}
			if (Input.GetButtonUp ("Sprint")) {
				this.speed = 5f;
			}
			if (onGround && Input.GetButtonDown ("Jump")) {
				rigidbody.AddForce (transform.up * jumpVelocity, ForceMode.VelocityChange);
			}


			//Item handel this stuff m8
			if (Input.GetButtonDown ("Interact")) {
				RaycastHit hit;
				Ray ray = gameObject.GetComponentInChildren<Camera> ().ScreenPointToRay (new Vector3 (Screen.width / 2, Screen.height / 2));
				
				if (Physics.Raycast (ray, out hit)) {
					if (hit.transform.gameObject.tag == "Interactable") {
						Inventory.Add (hit.collider.gameObject);
						InventoryGUI.Add (hit.collider.gameObject);

						hit.collider.transform.position = InventoryBag.transform.position;
						hit.collider.transform.rotation = InventoryBag.transform.rotation;
						hit.collider.transform.parent = InventoryBag.transform;
					}
				}
			}

			//Weapon Interactions
			if (Input.GetButtonDown ("Fire2")) { 
				//Knock dem bitches back
				RaycastHit hit;
				Ray ray = camera.ScreenPointToRay (new Vector3 (Screen.width / 2, Screen.height / 2, 0.0f));
				
				if (Physics.Raycast (ray, out hit, knockbackDistance)) {
					if (hit.collider.tag == "Gnome") {
						Gnome gnome = hit.collider.gameObject.GetComponent<Gnome> ();
						gnome.knockbackGnome (transform);
					}
				}
			}

			if (Input.GetButtonDown ("Fire1")) {
				RaycastHit hit;
				//ray through the middle of the screen, i.e. where the player is looking
				Ray ray = gameObject.GetComponentInChildren<Camera> ().ScreenPointToRay (new Vector3 (Screen.width / 2, Screen.height / 2));

				if (Physics.Raycast (ray, out hit)) {
					if (hit.collider.tag == "Gnome") {
						Gnome gnome = hit.collider.gameObject.GetComponent<Gnome> ();
						//TODO: weapons should be the things dealing damage. once the equip system is set up, change this to be something like `currentWeapon.DealDamage(gnome);`
						DealDamage (gnome);
					}
				}
			}
		}
		
	}
	
	void FixedUpdate() {
		
	}

    void OnCollisionEnter(Collision hit) {

		//If we hit a wall or something while in the air, should begin to ignore velocity vectors
		if (!onGround && hit.collider.tag == "Untagged") {
			hitSomethingInAir = true;
		}
    }

	void OnCollisionStay(Collision hit){

		//If we are on the ground we have hit something we should acknowledge the velocity vectors
		if (onGround && hit.collider.tag == "Untagged") {
			hitSomethingInAir = false;
		} else {
			//But if not and we are staying on a wall, we should ignore velocity vectors
			hitSomethingInAir = true;
		}
	}

	void OnCollisionExit(Collision hit) {
		//If we exit a collision we should just assume that we have not hit a wall or anything
		hitSomethingInAir = false;
	}

	void OnTriggerEnter(Collider hit){
		//Trigger for feet to see if on floor to entity
		onGround = true;

	}

	void OnTriggerExit(Collider hit){
		//Trigger for feet to see if off floor to entity
		onGround = false;
	}

	public void setFreeze(bool f){
		freeze = f;
	}

	protected override void OnDead() {
		Destroy(this.gameObject);
	}
}