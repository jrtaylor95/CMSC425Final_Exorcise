using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	public int damage;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, .5f);
	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D collision) {
		Destroy (gameObject);

		if (collision.gameObject.tag == "Enemy") {
			EnemyHealthController controller = collision.gameObject.GetComponent<EnemyHealthController> ();

			controller.takeDamage (damage);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Enemy") {
			Destroy (gameObject);
			EnemyHealthController controller = other.gameObject.GetComponent<EnemyHealthController> ();

			controller.takeDamage (damage);
		}
	}
}
