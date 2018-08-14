using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOnePuzzle : MonoBehaviour {

	//puzzle zone objects
	public GameObject puzzleZoneRealm1;
	public GameObject puzzleZoneRealm2;
	public GameObject puzzleZoneRealm3;

	//puzzle trigger
	bool realm1PuzzleTrigger = false;
	bool realm2PuzzleTrigger = false;
	bool realm3PuzzleTrigger = false;

	//puzzle mask
	public LayerMask puzzleMask;

	//eye door
	public Animator eyeDoorAnim;

	void Update()
	{
		if (puzzleZoneRealm1.GetComponent<BoxCollider2D> ().IsTouchingLayers (puzzleMask)) {
			realm1PuzzleTrigger = true;
		}

		if (puzzleZoneRealm2.GetComponent<BoxCollider2D> ().IsTouchingLayers (puzzleMask)) {
			realm2PuzzleTrigger = true;
		}

		if (puzzleZoneRealm3.GetComponent<BoxCollider2D> ().IsTouchingLayers (puzzleMask)) {
			realm3PuzzleTrigger = true;
		}

		if (realm1PuzzleTrigger && realm2PuzzleTrigger && realm3PuzzleTrigger)
			eyeDoorAnim.SetTrigger ("open");
	}
}
