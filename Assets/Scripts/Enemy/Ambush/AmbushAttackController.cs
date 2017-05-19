using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbushAttackController : MonoBehaviour {

	private GameObject player;
	private PlayerMovementController movementController;
	private int interval = 5;
	private Vector3 startPos;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		movementController = player.GetComponent<PlayerMovementController> ();
		startPos = transform.position;
	}
	
	// Update is called once per frame
//	void Update () {
//		if (Vector3.Distance (player.transform.position, transform.position) < 1) {
//			attack ();
//		}
//
//	}

	private void attack() {
		Vector3 initialPos = transform.position;

		Vector3 popInPos = Vector3.zero;
//		transform.position = player.transform.position + ((movementController.isFacingRight() ? (Vector3.left) : (Vector3.right)) * .1f);
		transform.position = player.transform.position;

//		transform.position = initialPos;
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			attack ();
		}
	}
}
