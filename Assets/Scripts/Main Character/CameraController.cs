using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	private Transform target;
	public float smoothSpeed = 10f;
	public Vector3 offset;

	public float cameraMultiplier = 1;
	Vector3 inputDirection;

	void Awake()
	{
		target = GameObject.Find ("Player").transform;
		transform.position = target.position;
	}

	void Update()
	{
		inputDirection.x = Input.GetAxis ("RightStickXAxis") * cameraMultiplier;
		inputDirection.y = Input.GetAxis ("RightStickYAxis") * cameraMultiplier;
	}

	//when this function is called the character is already done with its movement
	void LateUpdate()
	{
		Vector3 desiredPosition = target.position + offset + inputDirection;
		Vector3 smoothedPosition = Vector3.Lerp (transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
		transform.position = smoothedPosition;
	}
}
