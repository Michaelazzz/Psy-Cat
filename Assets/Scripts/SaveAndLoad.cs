using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveAndLoad : MonoBehaviour {

	//private static SaveAndLoad instance;
	//int level;
	//int continueGame = 0;		//0->false 1->true

	public void Save(int level)
	{
		PlayerPrefs.SetInt ("LevelKey", level);
	}


	public int Load()
	{
		if (PlayerPrefs.HasKey("LevelKey")) {
			//return the saved level
			return PlayerPrefs.GetInt ("LevelKey", 0);
		} else {
			//return 1 (the first level) if there has not been a save yet
			return 1;
		}
	}

	public void Delete()
	{
		PlayerPrefs.DeleteAll ();
	}
}
