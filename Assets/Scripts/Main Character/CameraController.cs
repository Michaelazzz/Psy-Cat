using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	private Transform target;
	public float smoothSpeed = 10f;
	public Vector3 offset;

	void Awake()
	{
		target = GameObject.Find ("Player").transform;
		transform.position = target.position;
	}

	//when this function is called the character is already done with its movement
	void LateUpdate()
	{
		Vector3 desiredPosition = target.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp (transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
		transform.position = smoothedPosition;
	}
}
