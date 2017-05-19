using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAttackController : MonoBehaviour {

	GameObject player;
	PlayerHealthController healthController;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		healthController = player.GetComponent<PlayerHealthController> ();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			healthController.TakeDamage (10);
		}
	}
}
