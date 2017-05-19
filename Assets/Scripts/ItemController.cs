using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour {

	PlayerInventoryController inventoryController;

	// Use this for initialization
	void Start () {
		inventoryController = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerInventoryController> ();
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			inventoryController.AddItem (gameObject);
		}
	}
}
