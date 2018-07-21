using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPickup : MonoBehaviour {

	public Animator pickupAnim;
	public Animator pickupAnim2;

	void OnTriggerEnter2D(Collider2D other)
	{
		pickupAnim.SetTrigger ("out");
		pickupAnim2.SetTrigger ("out");
	}
}
