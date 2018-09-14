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

	public void Play()
	{
		StartCoroutine (LoadScene ());
	}

	IEnumerator LoadScene()
	{
		video.Play ();
		if(musicAnim != null)
			musicAnim.SetTrigger ("mute");
		transitionAnim.SetTrigger ("dead");
		yield return new WaitForSeconds (time);
		//SceneManager.LoadScene (sceneName);
		SceneManager.LoadScene (sceneIndex);
	}
}
