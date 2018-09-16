using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Pickup : MonoBehaviour {

	public GameObject boundary; 

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			boundary.SetActive (true);
		}
	}
}
