using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneByIndex : MonoBehaviour {

	//game master
	GameObject gameMaster;
	//background music
	GameObject backgroundMusic;

	//public Animator musicAnim;

	void Start()
	{
		backgroundMusic = GameObject.Find ("BackgroundMusic");
		gameMaster = GameObject.Find ("GameMaster");
	}

	public void Load(string sceneName)
	{
		Destroy (gameMaster);
		Destroy (backgroundMusic);

		SceneManager.LoadScene (sceneName);
		//StartCoroutine (LoadScene (sceneName));
	}

	//IEnumerator LoadScene(string sceneName)
	//{
		//if(musicAnim != null)
		//	musicAnim.SetTrigger ("mute");
		//yield return new WaitForSeconds (1.5f);
		//SceneManager.LoadScene (sceneName);
	//}
}
