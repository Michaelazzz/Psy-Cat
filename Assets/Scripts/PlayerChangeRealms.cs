using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChangeRealms : MonoBehaviour {

	public int startRealm = 1;
	public GameObject[] realm1Objects;
	public GameObject[] realm2Objects;
	public GameObject[] realm3Objects;

	void Awake () 
	{

		realm1Objects = new GameObject[GameObject.FindGameObjectsWithTag("Realm1").Length];
		realm2Objects = new GameObject[GameObject.FindGameObjectsWithTag("Realm2").Length];
		realm3Objects = new GameObject[GameObject.FindGameObjectsWithTag("Realm3").Length];

		realm1Objects = GameObject.FindGameObjectsWithTag ("Realm1");
		realm2Objects = GameObject.FindGameObjectsWithTag ("Realm2");
		realm3Objects = GameObject.FindGameObjectsWithTag ("Realm3");

		ChangeRealms (startRealm);
	}

	void Update () 
	{
		//button pressed to change realm
		if (Input.GetButtonDown ("ChangeRealmLeft")) {
			if (startRealm == 0)
				startRealm = 2;
			else
				startRealm--;

			ChangeRealms (startRealm);
		}

		if (Input.GetButtonDown ("ChangeRealmRight")) {
			if (startRealm == 2)
				startRealm = 0;
			else
				startRealm++;

			ChangeRealms (startRealm);
		}
	}

	void ChangeRealms(int realm)
	{

		if (startRealm == 0) {
			for (int i = 0; i < realm1Objects.Length; i++) {
				GameObject curObject = realm1Objects [i];

				curObject.GetComponent<Rigidbody2D> ().isKinematic = false;
				curObject.GetComponent<SpriteRenderer> ().enabled = true;
				curObject.GetComponent<BoxCollider2D> ().enabled = true;
				curObject.GetComponent<AudioSource> ().enabled = true;
			}
		} else {
			for (int i = 0; i < realm1Objects.Length; i++) {
				GameObject curObject = realm1Objects [i];

				curObject.GetComponent<Rigidbody2D> ().isKinematic = true;
				curObject.GetComponent<SpriteRenderer> ().enabled = false;
				curObject.GetComponent<BoxCollider2D> ().enabled = false;
				curObject.GetComponent<AudioSource> ().enabled = false;
			}
		}
			
		if (startRealm == 1 || startRealm == -1) {
			for(int i = 0; i < realm2Objects.Length; i++) {
				GameObject curObject = realm2Objects[i];

				curObject.GetComponent<Rigidbody2D> ().isKinematic = false;
				curObject.GetComponent<SpriteRenderer>().enabled = true;
				curObject.GetComponent<BoxCollider2D>().enabled = true;
				curObject.GetComponent<AudioSource>().enabled = true;
			}
		} else {
			for (int i = 0; i < realm2Objects.Length; i++) {
				GameObject curObject = realm2Objects [i];

				curObject.GetComponent<Rigidbody2D> ().isKinematic = true;
				curObject.GetComponent<SpriteRenderer> ().enabled = false;
				curObject.GetComponent<BoxCollider2D> ().enabled = false;
				curObject.GetComponent<AudioSource> ().enabled = false;
			}
		}

		if (startRealm == 2 || startRealm == -2) {
			for(int i = 0; i < realm3Objects.Length; i++) {
				GameObject curObject = realm3Objects[i];

				curObject.GetComponent<Rigidbody2D> ().isKinematic = false;
				curObject.GetComponent<SpriteRenderer>().enabled = true;
				curObject.GetComponent<BoxCollider2D>().enabled = true;
				curObject.GetComponent<AudioSource>().enabled = true;
			}
		} else {
			for (int i = 0; i < realm3Objects.Length; i++) {
				GameObject curObject = realm3Objects [i];

				curObject.GetComponent<Rigidbody2D> ().isKinematic = true;
				curObject.GetComponent<SpriteRenderer> ().enabled = false;
				curObject.GetComponent<BoxCollider2D> ().enabled = false;
				curObject.GetComponent<AudioSource> ().enabled = false;
			}
		}
	}
}
