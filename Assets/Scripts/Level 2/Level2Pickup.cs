using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Pickup : MonoBehaviour {

	public GameObject[] boundaries; 

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			for(int i = 0; i < boundaries.Length; i++)
				boundaries[i].SetActive (true);
		}
	}
}
