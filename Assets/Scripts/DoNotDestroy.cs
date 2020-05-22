using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoNotDestroy : MonoBehaviour {

	private static DoNotDestroy instance;

	void Awake(){
		if (SceneManager.GetActiveScene ().name.Equals ("level2")) {
			if (instance == null) {
				instance = this;
				DontDestroyOnLoad (instance);
			} else {
				Destroy (gameObject);
			}
		} else {
			Destroy (gameObject);
		}
	}
}
