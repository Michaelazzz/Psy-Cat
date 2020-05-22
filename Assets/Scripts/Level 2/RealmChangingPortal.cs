using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealmChangingPortal : MonoBehaviour {

	//realm to change to
	public int nextRealm = 0;

	PlayerChangeRealms changeRealms;

	void Start()
	{
		changeRealms = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerChangeRealms>();

	}


	//collide with player and change to specified realm
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Player")) {

			//gm.currentRealm = nextRealm;
			changeRealms.ChangeRealms(nextRealm);
		}
	}

}
