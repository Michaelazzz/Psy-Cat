using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MainMenuPlay : MonoBehaviour {

	//scene transition
	[Header("Scene Transistion")]
	public Animator transitionAnim;
	//public string sceneName;
	public int sceneIndex;
	public float time = 1.5f;

	//music transition
	[Header("Music Transition")]
	public Animator musicAnim;

	[Header("Video")]
	public VideoPlayer video;

	[Header("Save and Load")]
	public int savedLevel;
	private SaveAndLoad sal;

	void Start()
	{
		//get save and load component to use
		sal = this.GetComponent<SaveAndLoad> ();
		savedLevel = sal.Load ();
	}

	public void PlayContinue()
	{
		StartCoroutine (LoadScene (sal.Load()));
	}

	public void PlayNew()
	{
		sal.Delete ();
		StartCoroutine (LoadScene (sceneIndex));
	}

	IEnumerator LoadScene(int index)
	{
		video.Play ();
		if(musicAnim != null)
			musicAnim.SetTrigger ("mute");
		transitionAnim.SetTrigger ("dead");
		yield return new WaitForSeconds (time);
		//SceneManager.LoadScene (sceneName);
		SceneManager.LoadScene (index);
	}
}
