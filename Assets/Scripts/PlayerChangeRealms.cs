using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChangeRealms : MonoBehaviour {

	public float realm = 1;
	public GameObject[] objects;
	public int size = 100;

	void Start () {

		objects = new GameObject[size];

		//realm the player starts in
		objects = GameObject.FindGameObjectsWithTag("Realm2");
		foreach (GameObject x in objects) {
			x.SetActive(true);
		}

		//other realms
		objects = GameObject.FindGameObjectsWithTag("Realm1");
		foreach (GameObject x in objects) {
			x.SetActive(false);
		}

		objects = GameObject.FindGameObjectsWithTag("Realm3");
		foreach (GameObject x in objects) {
			x.SetActive(false);
		}
	}

	void Update () {
		if (Input.GetKeyUp(KeyCode.Alpha2)) {
			realm = realm + 1;
			//realm = realm % 3;

			if (realm == 0) {
				objects = GameObject.FindGameObjectsWithTag ("Realm1");
				foreach (GameObject x in objects) {
					x.SetActive (true);
				}

				objects = GameObject.FindGameObjectsWithTag ("Realm2");
				foreach (GameObject x in objects) {
					x.SetActive (false);
				}

				objects = GameObject.FindGameObjectsWithTag ("Realm3");
				foreach (GameObject x in objects) {
					x.SetActive (false);
				}
			}
			if (realm == 1) {
				objects = GameObject.FindGameObjectsWithTag ("Realm2");
				foreach (GameObject x in objects) {
					x.SetActive (true);
				}

				objects = GameObject.FindGameObjectsWithTag ("Realm1");
				foreach (GameObject x in objects) {
					x.SetActive (false);
				}

				objects = GameObject.FindGameObjectsWithTag ("Realm3");
				foreach (GameObject x in objects) {
					x.SetActive (false);
				}
			}
			if (realm == 2) {
				objects = GameObject.FindGameObjectsWithTag ("Realm3");
				foreach (GameObject x in objects) {
					x.SetActive (true);
				}

				objects = GameObject.FindGameObjectsWithTag ("Realm2");
				foreach (GameObject x in objects) {
					x.SetActive (false);
				}

				objects = GameObject.FindGameObjectsWithTag ("Realm1");
				foreach (GameObject x in objects) {
					x.SetActive (false);
				}
			}
		} 
		else if (Input.GetKeyUp(KeyCode.Alpha1)) {
			realm = realm - 1;
			//realm = realm % 3;

			if (realm == 0) {
				objects = GameObject.FindGameObjectsWithTag ("Realm1");
				foreach (GameObject x in objects) {
					x.SetActive (true);
				}

				objects = GameObject.FindGameObjectsWithTag ("Realm2");
				foreach (GameObject x in objects) {
					x.SetActive (false);
				}

				objects = GameObject.FindGameObjectsWithTag ("Realm3");
				foreach (GameObject x in objects) {
					x.SetActive (false);
				}
			}
			if (realm == 1) {
				objects = GameObject.FindGameObjectsWithTag ("Realm2");
				foreach (GameObject x in objects) {
					x.SetActive (true);
				}

				objects = GameObject.FindGameObjectsWithTag ("Realm1");
				foreach (GameObject x in objects) {
					x.SetActive (false);
				}

				objects = GameObject.FindGameObjectsWithTag ("Realm3");
				foreach (GameObject x in objects) {
					x.SetActive (false);
				}
			}
			if (realm == 2) {
				objects = GameObject.FindGameObjectsWithTag ("Realm3");
				foreach (GameObject x in objects) {
					x.SetActive (true);
				}

				objects = GameObject.FindGameObjectsWithTag ("Realm2");
				foreach (GameObject x in objects) {
					x.SetActive (false);
				}

				objects = GameObject.FindGameObjectsWithTag ("Realm1");
				foreach (GameObject x in objects) {
					x.SetActive (false);
				}
			}
		}
		
		Debug.Log (realm);
	}
}
