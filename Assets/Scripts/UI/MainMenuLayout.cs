using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuLayout : MonoBehaviour {

	public GameObject newGamePanel;
	public GameObject continueGamePanel;

	void Start()
	{
		if (PlayerPrefs.HasKey ("LevelKey")) {
			newGamePanel.SetActive (false);
			continueGamePanel.SetActive (true);
		} else {
			continueGamePanel.SetActive (false);
			newGamePanel.SetActive (true);
		}
	}
}
