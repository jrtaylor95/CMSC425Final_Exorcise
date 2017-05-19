using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour {

	public int startingHealth = 100;

	private int currentHealth;
	GamePlayController gameController;
	// Use this for initialization
	void Start () {
		currentHealth = startingHealth;
		gameController = GameObject.Find ("GameplayObject").GetComponent<GamePlayController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void takeDamage(int damage) {
		currentHealth -= damage;
		if (currentHealth <= 0) {
			Death ();
		}
	}

	private void Death() {
		Destroy (gameObject);
		gameController.DecrementGhosts ();
	}
}
