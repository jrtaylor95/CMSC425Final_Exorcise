using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovementScript : MonoBehaviour {

	public float speed = .5f;

	Rigidbody2D rb;
	GameObject player;
	public bool facingRight = true;
	Vector2 destinationPos;
	Vector2 startingPos;
	bool attacking = false;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		startingPos = transform.position;
	}

	void FixedUpdate() {
		
	}

	// Update is called once per frame
	void Update () {
		Vector3 playerPos = player.transform.position;

		if (!attacking) {
			float dist = Vector2.Distance (playerPos, transform.position);

			if (dist < .5f) {
				attacking = true;
				destinationPos = playerPos;
				Vector2 diff = playerPos - transform.position;

				if (diff.x > 0) {
					if (!facingRight)
						Flip ();
					destinationPos += new Vector2 (0.5f, 0);
				} else {
					if (facingRight)
						Flip ();
					destinationPos += new Vector2 (-0.5f, 0);
				}
			}
		} else {
			if (Vector2.Distance (destinationPos, transform.position) > .1f) {
				if (facingRight)
					transform.Translate (new Vector2 (speed, 0) * Time.deltaTime);
				else
					transform.Translate (new Vector2 (-speed, 0) * Time.deltaTime);
			} else
				attacking = false;
		}
	}

	void Flip() {
		facingRight = !facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
}
