using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuLayout : MonoBehaviour {

	public GameObject newGamePanel;
	public GameObject continueGamePanel;
	public EventSystem eventSystem;
	public GameObject newGameButton;
	public GameObject playButton;

	void Awake()
	{
		if (PlayerPrefs.HasKey ("LevelKey")) {
			newGamePanel.SetActive (false);
			continueGamePanel.SetActive (true);

			//change first button
			eventSystem.GetComponent<EventSystem>().firstSelectedGameObject = newGameButton;
		} else {
			continueGamePanel.SetActive (false);
			newGamePanel.SetActive (true);

			//change first button
			eventSystem.GetComponent<EventSystem>().firstSelectedGameObject = playButton;
		}
	}
}
