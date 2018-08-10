using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnMovingPlatform : MonoBehaviour {

	//collide with player make it a child
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			other.transform.SetParent (transform);
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			other.transform.SetParent (null);
		}
	}
}
