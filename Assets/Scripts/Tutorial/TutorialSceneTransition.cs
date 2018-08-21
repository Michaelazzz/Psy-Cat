using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialSceneTransition : MonoBehaviour {

	//game master
	public GameObject gameMaster;
	//background music
	GameObject backgroundMusic;

	//scene transition
	[Header("Scene Transistion")]
	public Animator transitionAnim;
	public string sceneName;
	public float time = 1.5f;

	//music transition
	[Header("Music Transition")]
	public Animator musicAnim;

	void Start()
	{
		backgroundMusic = GameObject.Find ("BackgroundMusic");
		gameMaster = GameObject.Find ("GameMaster");
	}

	IEnumerator LoadScene()
	{
		if(musicAnim != null)
			musicAnim.SetTrigger ("mute");
		transitionAnim.SetTrigger ("dead");
		yield return new WaitForSeconds (time);

		Destroy (gameMaster);
		Destroy (backgroundMusic);

		SceneManager.LoadScene (sceneName);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			StartCoroutine (LoadScene ());
		}
	}
}
