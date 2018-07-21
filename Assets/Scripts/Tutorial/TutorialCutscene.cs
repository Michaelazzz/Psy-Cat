using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCutscene : MonoBehaviour {

	//when the floor is animated
	//Animator floorAnim;

	public GameObject floor;

	void Start()
	{
		
	}

	void Update()
	{
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		floor.SetActive (false);
	}
}
