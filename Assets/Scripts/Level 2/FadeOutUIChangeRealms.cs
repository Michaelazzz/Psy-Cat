using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutUIChangeRealms : MonoBehaviour {

	Animator animator;

	void Start()
	{
		animator = GameObject.Find ("Realm Panel").GetComponent<Animator>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			animator.SetTrigger ("fade_out");
		}
	}
}
