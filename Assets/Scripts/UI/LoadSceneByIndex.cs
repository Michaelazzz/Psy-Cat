using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneByIndex : MonoBehaviour {

	//public Animator musicAnim;

	public void Load(string sceneName)
	{
		
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
