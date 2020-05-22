using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

	public GameObject platfrom;
	public float velocity;
	public Transform currentPosition;
	public Transform[] points;
	public int pointSelection;

	private GameMaster gm;

	void Start()
	{
		gm = GameObject.FindGameObjectWithTag ("GM").GetComponent<GameMaster> ();
		currentPosition = points [pointSelection];
	}

	void Update()
	{
		if (gm.currentRealm == 1)
			platfrom.transform.position = Vector3.MoveTowards (platfrom.transform.position, currentPosition.position, 0 * Time.deltaTime);
		else if (gm.currentRealm == 0)
			platfrom.transform.position = Vector3.MoveTowards (platfrom.transform.position, currentPosition.position, velocity * Time.deltaTime);

		if (platfrom.transform.position == currentPosition.position) {
			pointSelection++;

			if (pointSelection == points.Length)
				pointSelection = 0;

			currentPosition = points [pointSelection];
		}
	}
}
