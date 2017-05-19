using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController: MonoBehaviour {

	public GameObject player;

	private Vector3 startPos;
	// Use this for initialization
	void Start () {
		startPos = transform.position;
	}

	// Update is called once per frame
	void Update () {
		var playerPos = player.transform.position;

		if (Vector3.Distance (playerPos, transform.position) < 1) {
			transform.Translate ((playerPos - transform.position) * Time.deltaTime * .5f);
		} else {
			transform.Translate ((startPos - transform.position) * Time.deltaTime * .5f);
		}
	}


}
