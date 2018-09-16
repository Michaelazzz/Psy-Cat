using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLevel : MonoBehaviour {

	//private GameMaster gm;
	private SaveAndLoad sal;

	//determining if it is a palyable level
	public int size = 4;
	public int[] validLevels;

	void Start()
	{
		validLevels = new int[size];
		validLevels [0] = 1;
		validLevels [1] = 3;
		validLevels [2] = 5;

		//get scene index when the scene is loaded
		//gm = GameObject.FindGameObjectWithTag ("GM").GetComponent<GameMaster> ();

		//get save and load component to use
		sal = this.GetComponent<SaveAndLoad> ();

		int curLevel = SceneManager.GetActiveScene ().buildIndex;

		//set the level in the save as the current level if it is valid
		if(validLevels[0] == curLevel || validLevels[1] == curLevel || validLevels[2] == curLevel)
		{
			//save current level
			sal.Save(curLevel);
			//gm.level = curLevel;
		}

	}

}
