using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPoints : MonoBehaviour {

	//variables
	public Animator eyeAnim;			//animator for the eye

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			eyeAnim.SetBool ("tutorial", true);
		}
	}

	void OnTriggerExit2D(Collider2D other){
		eyeAnim.SetBool ("tutorial", false);
	}
}
