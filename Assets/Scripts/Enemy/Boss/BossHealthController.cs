using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthController : MonoBehaviour {

	public int startingHealth = 200;

	public Slider healthSlider;
	int currentHealth;

	// Use this for initialization
	void Start () {
		currentHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void TakeDamage(int amount) {
		currentHealth -= amount;

		healthSlider.value = currentHealth;

		if (currentHealth <= 0) {
			Death ();
		}
	}

	void Death() {

	}
}
