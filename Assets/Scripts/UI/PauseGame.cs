using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour {

	public static bool GameIsPaused = false;

	public GameObject pauseMenuUI;

	void Update () 
	{
		if (SceneManager.GetActiveScene ().buildIndex != 0) {
			if (Input.GetButtonDown ("Escape")) {
				if (GameIsPaused) {
					Resume ();
				} else {
					Pause ();
				}
			}
		}
	}

	public void Resume()
	{
		pauseMenuUI.SetActive (false);
		Time.timeScale = 1f;
		GameIsPaused = false;
	}

	public void Pause()
	{
		pauseMenuUI.SetActive (true);
		Time.timeScale = 0f;
		GameIsPaused = true;
	}
}
