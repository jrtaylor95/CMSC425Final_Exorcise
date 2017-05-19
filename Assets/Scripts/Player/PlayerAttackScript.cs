using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackScript : MonoBehaviour {

	Animator anim;
	PlayerMovementController movementController;
	public int attack;
	public float reach;
	public float knockBack;
	public AudioClip hitNoise;
	AudioSource source;
	public Rigidbody2D bullet;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		movementController = GetComponent<PlayerMovementController> ();
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			Attack ();
		} else if (Input.GetKeyDown(KeyCode.Mouse1)) {
			RangeAttack ();
		}
	}

	void Attack () {
		anim.SetTrigger ("attack");

		RaycastHit2D hit;

		Vector3 dir = Vector3.zero;

		if (movementController.isFacingRight ()) {
			dir = Vector3.right;
		} else {
			dir = Vector3.left;
		}

		hit = Physics2D.Raycast (transform.position + (dir * .06f), dir, reach);
		if (hit.collider != null) {
			Debug.DrawRay (transform.position + (dir * .06f), dir * reach);
			GameObject col = hit.collider.gameObject;
			if (col.tag == "Enemy") {
				source.PlayOneShot (hitNoise);
				Rigidbody2D rb = col.GetComponent<Rigidbody2D> ();
				EnemyHealthController healthController = col.GetComponent<EnemyHealthController> ();
				healthController.takeDamage (attack);
				rb.AddForce (dir * knockBack);
			}
		}
	}

	void RangeAttack() {
		anim.SetTrigger ("attack");
		if (movementController.isFacingRight ()) {
			Rigidbody2D bulletClone = (Rigidbody2D)Instantiate (bullet, transform.position + (Vector3.right * .1f), transform.rotation);
			bulletClone.velocity = transform.right * 1;
		} else {
			Rigidbody2D bulletClone = (Rigidbody2D)Instantiate (bullet, transform.position + (Vector3.left * .1f), transform.rotation);
			bulletClone.velocity = transform.right * -1;
		}
	}
}
