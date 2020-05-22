using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SetEventSystemButton : MonoBehaviour {

	public EventSystem eventSystem;
	public GameObject newButton;
	public GameObject altButton;

	public GameObject newPanel;
	public GameObject altPanel;

	public void setButton()
	{
		//change first button
		eventSystem.GetComponent<EventSystem>().SetSelectedGameObject(newButton);
	}

	public void setButtonWithKey()
	{
		if (PlayerPrefs.HasKey ("LevelKey")) {
			//change first button
			eventSystem.GetComponent<EventSystem>().SetSelectedGameObject(newButton);
			newPanel.SetActive (true);
		} else {
			//change first button
			eventSystem.GetComponent<EventSystem>().SetSelectedGameObject(altButton);
			altPanel.SetActive (true);
		}
	}
}
