using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour {

	//scene transition
	public Animator transitionAnim;
	public string sceneName;

	//music transition
	public Animator musicAnim;

	void Update()
	{
		//condition for change
		//StartCoroutine (LoadScene());
	}

	IEnumerator LoadScene()
	{
		musicAnim.SetTrigger ("mute");
		transitionAnim.SetTrigger ("dead");
		yield return new WaitForSeconds (1.5f);
		SceneManager.LoadScene (sceneName);
	}
}