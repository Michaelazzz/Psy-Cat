using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIChangeRealms : MonoBehaviour {

	//eyelides
	public Image middle;
	public Image left;
	public Image right;

	//current realm
	public int realm = 1;									//middle realm

	void Start()
	{
		ChangeRealms (realm);
	}

	void Update()
	{
		//button pressed to change realm
		if (Input.GetButtonDown ("ChangeRealmLeft")) {
			if (realm == 0)
				realm = 2;
			else
				realm--;

			ChangeRealms (realm);
		}

		if (Input.GetButtonDown ("ChangeRealmRight")) {
			if (realm == 2)
				realm = 0;
			else
				realm++;

			ChangeRealms (realm);
		}
	}

	void ChangeRealms(int realm)
	{
		if (realm == 0) {
			left.enabled = false;
		} else {
			left.enabled = true;
		}

		if (realm == 1) {
			middle.enabled = false;
		} else {
			middle.enabled = true;
		}

		if (realm == 2) {
			right.enabled = false;
		} else {
			right.enabled = true;
		}
	}
}
