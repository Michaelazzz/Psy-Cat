using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashScreen : MonoBehaviour {

	public Animator animator;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			animator.SetTrigger ("flash");
		}
	}
}
