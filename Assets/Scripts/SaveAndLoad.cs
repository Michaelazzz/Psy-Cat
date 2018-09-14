using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveAndLoad : MonoBehaviour {

	private static SaveAndLoad instance;
	public int level;
	public bool continueGame = false;

	void Awake(){
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (instance);
		} else {
			Destroy (gameObject);
		}
			
	}
}
