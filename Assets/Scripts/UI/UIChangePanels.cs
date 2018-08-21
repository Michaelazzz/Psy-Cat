using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIChangePanels : MonoBehaviour {

	//public GameObject panel;

	void ChangePanel()
	{
		if (gameObject.activeInHierarchy == false) 
		{
			gameObject.SetActive(true);
			Time.timeScale = 0;
		} 
		else 
		{
			gameObject.SetActive(false);
			Time.timeScale = 1;
		}
	}
}
