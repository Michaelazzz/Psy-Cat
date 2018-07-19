using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInUIChangeRealms : MonoBehaviour {

	public Animator animator;
	public GameObject pickup;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			animator.SetBool ("fade_in", true);

			//animation for pickup
			//let the pickup handle its fade out

			//temp solution
			pickup.SetActive(false);
		}
	}
}
