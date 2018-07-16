using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEyesClash : MonoBehaviour {

	//variables
	public Animator eyeAnim;					//animator for the eye
	public bool tutorialPoint = false;			//if player has hit a point where they nedd instructions
	public bool tutorialPoint2 = false;
	bool blink = true;							//if blink time has been assigned
	public BoxCollider2D point;					//tutorial point linked to the eye
	public BoxCollider2D point2;					//tutorial point linked to the eye
	public LayerMask playerMask;

	void Update()
	{
		if (point.IsTouchingLayers (playerMask)) {
			tutorialPoint = true;
		} else {
			tutorialPoint = false;
		}

		if (point2.IsTouchingLayers (playerMask)) {
			tutorialPoint2 = true;
		} else {
			tutorialPoint2 = false;
		}

		if (tutorialPoint) {
			eyeAnim.SetBool ("tutorial", true);
		} else {
			eyeAnim.SetBool ("tutorial", false);
			StartCoroutine (Blink());
		}

		if (tutorialPoint2) {
			eyeAnim.SetBool ("tutorial2", true);
		} else {
			eyeAnim.SetBool ("tutorial2", false);
			StartCoroutine (Blink());
		}
	}

	IEnumerator Blink()
	{
		float time = randomTime ();
		if(blink)
		{
			blink = false;
			//Debug.Log (time);
			yield return new WaitForSeconds (time);
			eyeAnim.SetTrigger ("close");
			blink = true;
		}
	}

	public float randomTime()
	{
		return Random.Range (4f, 10f);
	}
}
