using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPickup : MonoBehaviour {

	public Animator pickupAnim;
	public Animator pickupAnim2;

	public GameObject player;
	public Canvas canvas;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			pickupAnim.SetTrigger ("out");
			pickupAnim2.SetTrigger ("out");

			//enable change realms script
			player.GetComponent<PlayerChangeRealms> ().enabled = true;
			canvas.GetComponentInChildren<UIChangeRealms> ().enabled = true;
		}
	}
}
