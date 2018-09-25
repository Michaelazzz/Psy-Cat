using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCamera : MonoBehaviour {

	public GameObject movingCamera;
	public float time;
	public float velocity;
	public Transform currentPosition;
	public Transform[] points;
	public int pointSelection;

	void Start()
	{
		currentPosition = points [pointSelection];
	}

	void Update()
	{
		StartCoroutine (StartMovingCamera ());
	}

	IEnumerator StartMovingCamera()
	{
		yield return new WaitForSeconds (time);

		movingCamera.transform.position = Vector3.MoveTowards (movingCamera.transform.position, currentPosition.position, velocity * Time.deltaTime);

		//if (movingCamera.transform.position == currentPosition.position) {
		//	pointSelection++;

		//	if (pointSelection == points.Length)
		//		pointSelection = 0;

		//	currentPosition = points [pointSelection];
		//}
	}
}
