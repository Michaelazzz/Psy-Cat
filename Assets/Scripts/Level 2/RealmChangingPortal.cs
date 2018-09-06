using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealmChangingPortal : MonoBehaviour {

	//realm to change to
	public int nextRealm = 0;

	//the current realm
	//get current realm from game master
	int currentRealm;

	//name of realms
	public string nextRealmName;
	public string currentRealmName;

	//realm objects
	//next realm objects
	public GameObject[] nextRealmObjects;
	//current realm objects
	public GameObject[] currentRealmObjects;

	//game master
	private GameMaster gm;

	void Awake()
	{
		gm = GameObject.FindGameObjectWithTag ("GM").GetComponent<GameMaster> ();

		//get current realm
		currentRealm = gm.currentRealm;

		if (currentRealm == 0) {
			currentRealmName = "Realm1";
		} else if (currentRealm == 1) {
			currentRealmName = "Realm2";
		} else {
			currentRealmName = "Realm3";
		}

		//get right tag for the next realm
		if (nextRealm == 0) {
			nextRealmName = "Realm1";
		} else if (nextRealm == 1) {
			nextRealmName = "Realm2";
		} else {
			nextRealmName = "Realm3";
		}

		nextRealmObjects = new GameObject[GameObject.FindGameObjectsWithTag(nextRealmName).Length];
		nextRealmObjects = GameObject.FindGameObjectsWithTag (nextRealmName);

		currentRealmObjects = new GameObject[GameObject.FindGameObjectsWithTag(currentRealmName).Length];
		currentRealmObjects = GameObject.FindGameObjectsWithTag (currentRealmName);
	}

	void Update()
	{
		currentRealm = gm.currentRealm;

		//get right tag for the current realm
		if (currentRealm == 0) {
			currentRealmName = "Realm1";
		} else if (currentRealm == 1) {
			currentRealmName = "Realm2";
		} else {
			currentRealmName = "Realm3";
		}

		currentRealmObjects = new GameObject[GameObject.FindGameObjectsWithTag(currentRealmName).Length];
		currentRealmObjects = GameObject.FindGameObjectsWithTag (currentRealmName);
	}

	//collide with player and change to specofoed realm
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			//hide current realm objects
			for (int i = 0; i < currentRealmObjects.Length; i++) {
				GameObject curObject = currentRealmObjects [i];

				curObject.SetActive (false);
			}

			//display next realm objects
			for (int i = 0; i < nextRealmObjects.Length; i++) {
				GameObject curObject = nextRealmObjects [i];

				curObject.SetActive (true);
			}

			gm.currentRealm = nextRealm;
		}
	}

}
