using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCutscene : MonoBehaviour {

	public GameObject[] floorObjects;
	public float time;
	public Animator cameraShake;

	void OnTriggerEnter2D(Collider2D other)
	{
		for (int i = 0; i < floorObjects.Length; i++) {
			//camera shake
			cameraShake.SetTrigger("shake");
			StartCoroutine (DropObject (i));
		}
	}

	IEnumerator DropObject(int index)
	{
		//wait period of time
		yield return new WaitForSeconds (time*index);
		//make gravity affect it
		floorObjects[index].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
	}
}
