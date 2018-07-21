using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour {

	//scene transition
	[Header("Scene Transistion")]
	public Animator transitionAnim;
	public string sceneName;

	//music transition
	[Header("Music Transition")]
	public Animator musicAnim;

	//game master
	public GameObject gameMaster;

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
		//destroy game master
		Destroy(gameMaster);
		SceneManager.LoadScene (sceneName);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		StartCoroutine (LoadScene());
	}
}