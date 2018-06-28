using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour {

	public Animator transitionAnim;
	public string sceneName;

	void Update()
	{
		//condition for change
		//StartCoroutine (LoadScene());
	}

	IEnumerator LoadScene()
	{
		transitionAnim.SetTrigger ("dead");
		yield return new WaitForSeconds (1.5f);
		SceneManager.LoadScene (sceneName);
	}
}
