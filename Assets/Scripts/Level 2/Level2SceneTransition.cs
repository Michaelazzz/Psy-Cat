using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2SceneTransition : MonoBehaviour {

	//scene transition
	[Header("Scene Transistion")]
	public Animator transitionAnim;
	public string sceneName;
	public float time = 1.5f;

	IEnumerator LoadScene()
	{
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
