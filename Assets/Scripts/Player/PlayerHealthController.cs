using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour {

	public int startingHealth = 100;
	Slider healthSlider;

	private int currentHealth;
	private bool isDead = false;
	private PlayerMovementController movementController;
	PlayerAttackScript attackController;
	GamePlayController gameController;
	Animator anim;

	// Use this for initialization
	void Start () {
		currentHealth = startingHealth;
		movementController = GetComponent<PlayerMovementController> ();
		attackController = GetComponent<PlayerAttackScript> ();
		healthSlider = GameObject.Find ("HealthScale").GetComponent<Slider> ();
		anim = GetComponent<Animator> ();
		gameController = GameObject.Find ("GameplayObject").GetComponent<GamePlayController> ();
	}

	public void TakeDamage(int amount) {
		currentHealth -= amount;
		healthSlider.value = currentHealth;

		if (currentHealth <= 0 && !isDead) {
			Death ();
		}
	}

	private void Death() {
		isDead = true;

		movementController.enabled = false;
		attackController.enabled = false;
		anim.SetTrigger ("death");
		gameController.ShowLoseMenu ();
	}
}
