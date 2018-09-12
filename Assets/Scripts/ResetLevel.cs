using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetLevel : MonoBehaviour {

	//public Animator transitionAnim;
	//public PauseGame pauseScript;

	public void Reset()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);

		//StartCoroutine (LoadScene ());
	}

	/*IEnumerator LoadScene()
	{
		transitionAnim.SetTrigger ("dead");
		yield return new WaitForSeconds (1.5f);
		//Debug.Log ("Here");
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);

	}*/
}
