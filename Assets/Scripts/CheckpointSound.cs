using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSound : MonoBehaviour {

	public AudioSource source;
	public bool hasPlayed = false;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Player") && !hasPlayed) {
			source.Play ();
			hasPlayed = true;
		}
	}
}
