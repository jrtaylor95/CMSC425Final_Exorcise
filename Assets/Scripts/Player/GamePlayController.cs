using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayController : MonoBehaviour {

	public int numGhosts;
	static int ghostsLeft;
	public GameObject pauseMenu;
	public GameObject winMenu;
	public GameObject loseMenu;
	bool isPaused = false;
	AudioSource source;

	void Start() {
		source = GetComponent<AudioSource> ();
		source.loop = true;
		source.Play ();

		ghostsLeft = numGhosts;
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			TogglePause ();
		} else if (Input.GetKeyDown (KeyCode.R)) {
			SceneManager.LoadScene (0);
		} else if (Input.GetKeyDown (KeyCode.R)) {
			Application.Quit ();
		}
	}

	void TogglePause() {
		if (isPaused) {
			pauseMenu.SetActive (false);
			Time.timeScale = 1;
		} else {
			pauseMenu.SetActive (true);
			Time.timeScale = 0;
		}

		isPaused = !isPaused;
	}

	public void Restart() {
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		Time.timeScale = 1;
	}

	public void Quit() {
		Application.Quit ();
	}

	public void DecrementGhosts() {
		ghostsLeft -= 1;

		if (ghostsLeft <= 0) {
			winMenu.SetActive (true);
		}
	}

	public void ShowLoseMenu() {
		loseMenu.SetActive (true); 
	}

	public void Menu() {
		SceneManager.LoadScene (0);
	}

	public void LoadNextLevel() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}
}
