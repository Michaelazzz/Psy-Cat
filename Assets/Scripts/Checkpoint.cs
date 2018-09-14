using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

	private GameMaster gm;
	private SaveAndLoad sal;

	void Start()
	{
		gm = GameObject.FindGameObjectWithTag ("GM").GetComponent<GameMaster> ();
		sal = GameObject.FindGameObjectWithTag ("SAL").GetComponent<SaveAndLoad> ();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			gm.lastCheckPointPos = transform.position;
			sal.lastCheckPointPos = transform.position;
		}
	}
}
