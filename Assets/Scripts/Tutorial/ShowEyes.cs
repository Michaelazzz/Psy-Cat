using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowEyes : MonoBehaviour {

	public GameObject[] eyes;

	void OnTriggerEnter2D(Collider2D other)
	{
		for (int i = 0; i < eyes.Length; i++) {
			eyes [i].SetActive (true);
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		for (int i = 0; i < eyes.Length; i++) {
			eyes [i].SetActive (false);
		}
	}
}
