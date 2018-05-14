using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour {

	public Animator transitionAnim;
	public string sceneName;

	void Update()
	{
		//condition for scene change
		StartCoroutine(LoadScene());
	}

	IEnumerator LoadScene()
	{
		transitionAnim.SetTrigger ("Fade from black");
		yield return new WaitForSeconds (1.5f);
		//SceneManager.LoadScene (sceneName);
	}
}
