using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideEyes : MonoBehaviour {

	public GameObject[] eyes;

	void OnTriggerEnter2D(Collider2D other)
	{
		for (int i = 0; i < eyes.Length; i++) {
			eyes[i].SetActive (false);
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		for (int i = 0; i < eyes.Length; i++) {
			eyes[i].SetActive (true);
		}
	}
}
