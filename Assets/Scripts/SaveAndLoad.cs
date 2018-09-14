using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveAndLoad : MonoBehaviour {

	private static SaveAndLoad instance;
	public int level;
	public Vector2 lastCheckPointPos;

	void Awake(){
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (instance);
		} else {
			Destroy (gameObject);
		}
			
	}
}
