using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOnePuzzle : MonoBehaviour {

	//scene transition
	[Header("Scene Transistion")]
	public Animator transitionAnim;
	public string sceneName;
	public float time = 1.5f;

	//music transition
	[Header("Music Transition")]
	public Animator musicAnim;

	//puzzle zone objects
	[Header("Puzzle Objects")]
	public GameObject puzzleZoneRealm1;
	public GameObject puzzleZoneRealm2;
	public GameObject puzzleZoneRealm3;

	//puzzle trigger
	[Header("Puzzle Triggers")]
	public bool realm1PuzzleTrigger = false;
	public bool realm2PuzzleTrigger = false;
	public bool realm3PuzzleTrigger = false;

	//puzzle mask
	[Header("Puzzle Mask")]
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

		if (realm1PuzzleTrigger && realm2PuzzleTrigger && realm3PuzzleTrigger) {
			eyeDoorAnim.SetTrigger ("open");
			StartCoroutine (LoadScene ());
		}
	}

	IEnumerator LoadScene()
	{
		if(musicAnim != null)
			musicAnim.SetTrigger ("mute");
		yield return new WaitForSeconds (time/2);
		transitionAnim.SetTrigger ("dead");
		yield return new WaitForSeconds (time);
		SceneManager.LoadScene (sceneName);
	}
}
