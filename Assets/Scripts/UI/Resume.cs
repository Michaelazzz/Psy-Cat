using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour {

	public PauseGame pauseScript;

	void Awake()
	{
		pauseScript.Resume ();
	}
}
