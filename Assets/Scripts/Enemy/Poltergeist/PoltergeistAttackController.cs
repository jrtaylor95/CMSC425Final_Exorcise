using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoltergeistAttackController : MonoBehaviour {

	public int damage = 10;

	GameObject player;
	PlayerHealthController healthController;
	Vector2 startPos;
	bool isAttacking = false;
	bool isRising = false;
	bool thrown = false;
	Vector2 destinationPos;
	Rigidbody2D rb;
	Vector2 playerPos;

	GamePlayController gameController;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		healthController = player.GetComponent<PlayerHealthController> ();
		startPos = transform.position;
		destinationPos = startPos + new Vector2 (0, .1f);
		rb = GetComponent<Rigidbody2D> ();
		gameController = GameObject.Find ("GameplayObject").GetComponent<GamePlayController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!isAttacking) {
			if (PlayerInRange ()) {
				isAttacking = true;
				playerPos = player.transform.position;
				isRising = true;
			}
		} else {
			if (isRising) {
				Vector2 pos = transform.position;
				transform.Translate ((destinationPos - pos) * Time.deltaTime);

				if (Vector2.Distance (pos, destinationPos) < .05f) {
					isRising = false;
				}
			} else {
				if (!thrown) {
					Vector2 diff = player.transform.position - transform.position;
					if (diff.x > 0) {
						rb.AddForce (Vector2.right * 100);
					} else {
						rb.AddForce (Vector2.left  * 100);
					}
					
					thrown = true;
				}
			}
		}
	}

	bool PlayerInRange() {
		Vector3 playerPos = player.transform.position;

		return Vector2.Distance (playerPos, transform.position) < .5f;
	}

	void Attack() {

	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Player") {
			healthController.TakeDamage (damage);
			Destroy (gameObject);
			gameController.DecrementGhosts ();
		}
	}
}
