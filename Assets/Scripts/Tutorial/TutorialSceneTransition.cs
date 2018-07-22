using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialSceneTransition : MonoBehaviour {

	//scene transition
	[Header("Scene Transistion")]
	public Animator transitionAnim;
	public string sceneName;
	public float time = 1.5f;

	//music transition
	[Header("Music Transition")]
	public Animator musicAnim;

	IEnumerator LoadScene()
	{
		if(musicAnim != null)
			musicAnim.SetTrigger ("mute");
		transitionAnim.SetTrigger ("dead");
		yield return new WaitForSeconds (time);
		SceneManager.LoadScene (sceneName);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			StartCoroutine (LoadScene ());
		}
	}
}
