using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour {

	RoomLoaderController roomLoader = null;

	protected bool facingRight = true;
	protected Rigidbody2D rb;
	protected Animator anim;

	private bool grounded = false;
	Transform groundCheck;
	float groundRadius = 0.2f;
	LayerMask isGround;


	public AudioClip footstep;
	AudioSource source;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		source = GetComponent<AudioSource> ();
		groundCheck = gameObject.GetComponentInChildren<Transform> ();
		isGround = LayerMask.GetMask ("Ground");
	}

	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, isGround);
		anim.SetBool ("grounded", grounded);
		anim.SetFloat ("vSpeed", rb.velocity.y);
		var horizontalForce = Input.GetAxis("Horizontal");

		rb.velocity = new Vector2 (horizontalForce, rb.velocity.y);

		if (Mathf.Abs (horizontalForce) > 0 && grounded && !source.isPlaying) {
			source.PlayOneShot (footstep);
		}

		if (horizontalForce > 0 && !facingRight)
			Flip ();
		else if (horizontalForce < 0 && facingRight)
			Flip ();

		anim.SetFloat ("speed", Mathf.Abs (horizontalForce));
	}

	void Update() {
		if (grounded && Input.GetKeyDown (KeyCode.Space)) {
			anim.SetBool ("grounded", false);
			rb.AddForce (Vector2.up * 125);
		}

		if (Input.GetKeyDown (KeyCode.W)) {
			if (roomLoader != null) {
				transform.position = roomLoader.GetExitPosition();
			}
		}
	}

	private void Flip() {
		facingRight = !facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Door") {
			roomLoader = other.gameObject.GetComponent<RoomLoaderController> ();
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.tag == "Door") {
			roomLoader = null;
		}
	}

	public bool isFacingRight() {
		return facingRight;
	}
}
