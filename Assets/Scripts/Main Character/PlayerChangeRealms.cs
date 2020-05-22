using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChangeRealms : MonoBehaviour {

	public int startRealm = 1;
	public bool disableControls;
	public GameObject[] realm1Objects;
	public GameObject[] realm2Objects;
	public GameObject[] realm3Objects;

	private GameMaster gm;

	void Awake () 
	{
		gm = GameObject.FindGameObjectWithTag ("GM").GetComponent<GameMaster> ();

		realm1Objects = new GameObject[GameObject.FindGameObjectsWithTag("Realm1").Length];
		realm2Objects = new GameObject[GameObject.FindGameObjectsWithTag("Realm2").Length];
		realm3Objects = new GameObject[GameObject.FindGameObjectsWithTag("Realm3").Length];

		realm1Objects = GameObject.FindGameObjectsWithTag ("Realm1");
		realm2Objects = GameObject.FindGameObjectsWithTag ("Realm2");
		realm3Objects = GameObject.FindGameObjectsWithTag ("Realm3");

		ChangeRealms (startRealm);
		gm.currentRealm = startRealm;
	}

	void Update () 
	{
		if (!disableControls) {
			//button pressed to change realm
			if (Input.GetButtonDown ("ChangeRealmLeft")) {
				if (startRealm == 0) {
					ChangeRealms (2);
				} else {
					startRealm--;
					ChangeRealms (startRealm);
				}
			}

			if (Input.GetButtonDown ("ChangeRealmRight")) {
				if (startRealm == 2) {
					ChangeRealms (0);
				} else {
					startRealm++;
					ChangeRealms (startRealm);
				}
			}
		}
	}

	public void ChangeRealms(int realm)
	{

		gm.currentRealm = realm;
		transform.SetParent (null);

		startRealm = realm;

		if (startRealm == 0) {
			for (int i = 0; i < realm1Objects.Length; i++) {
				GameObject curObject = realm1Objects [i];

				curObject.SetActive(true);
			}
		} else {
			for (int i = 0; i < realm1Objects.Length; i++) {
				GameObject curObject = realm1Objects [i];

				curObject.SetActive(false);
			}
		}
			
		if (startRealm == 1 || startRealm == -1) {
			for(int i = 0; i < realm2Objects.Length; i++) {
				GameObject curObject = realm2Objects[i];

				curObject.SetActive(true);
			}
		} else {
			for (int i = 0; i < realm2Objects.Length; i++) {
				GameObject curObject = realm2Objects [i];

				curObject.SetActive(false);
			}
		}

		if (startRealm == 2 || startRealm == -2) {
			for(int i = 0; i < realm3Objects.Length; i++) {
				GameObject curObject = realm3Objects[i];

				curObject.SetActive(true);
			}
		} else {
			for (int i = 0; i < realm3Objects.Length; i++) {
				GameObject curObject = realm3Objects [i];

				curObject.SetActive(false);
			}
		}
	}
}
