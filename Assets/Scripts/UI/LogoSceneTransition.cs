using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoSceneTransition : MonoBehaviour {

	//scene transition
	[Header("Scene Transistion")]
	public Animator transitionAnim;
	public string sceneName;
	public float time = 8f;

	void Start()
	{
		StartCoroutine (LoadScene());
	}

	IEnumerator LoadScene()
	{
		transitionAnim.SetTrigger ("dead");
		yield return new WaitForSeconds (time);
		SceneManager.LoadScene (sceneName);
	}
}
