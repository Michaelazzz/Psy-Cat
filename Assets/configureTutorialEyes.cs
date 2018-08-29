using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class configureTutorialEyes : MonoBehaviour {

	GameObject [] keyboardObjects;
	GameObject [] controllerObjects;
	string[] controllerNames = { "Controller (XBOX 360 For Windows)" };

	bool controller = false;

	void Start()
	{
		//get all the keyboard and controller tagged eyes
		keyboardObjects = GameObject.FindGameObjectsWithTag("Keyboard");
		controllerObjects = GameObject.FindGameObjectsWithTag("Controller");
	}

	void Update()
	{
		//detect controller
		controllerConnected ();

		if (controller) {
			//hide keyboard objects
			for (int i = 0; i < keyboardObjects.Length; i++)
				keyboardObjects [i].SetActive (false);

			//show controller objects
			for (int i = 0; i < keyboardObjects.Length; i++)
				controllerObjects [i].SetActive (true);
		} else {
			//show keyboard objects
			for (int i = 0; i < keyboardObjects.Length; i++)
				keyboardObjects [i].SetActive (true);

			//hide controller objects
			for (int i = 0; i < keyboardObjects.Length; i++)
				controllerObjects [i].SetActive (false);
		}
	}

	void controllerConnected()
	{
		string[] names = Input.GetJoystickNames ();
		//names loop
		for (int i = 0; i < names.Length; i++) {
			//controller names loop
			for (int j = 0; j < controllerNames.Length; j++) {
				if (names [i].Equals (controllerNames [j])) {
					//Debug.Log ("Controller connected");
					controller = true;
					return;
				} else {
					//Debug.Log ("Controller disconnected");
					controller = false;
				}
			}

		}
	}
}
