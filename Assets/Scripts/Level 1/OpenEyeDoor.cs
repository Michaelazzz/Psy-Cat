using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenEyeDoor : MonoBehaviour {

	//scene transition
	[Header("Animator")]
	public Animator eyeDoorAnim;

	void OnTriggerEnter2D(Collider2D other)
	{
		eyeDoorAnim.SetTrigger ("open");
	}
}
