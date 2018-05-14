using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	//rotation
	public float rotationSpeed = 2f;

	//patrol
	public float speed;
	public float distance = 2f;
	public Transform groundDetection;

	//moving right or left
	private bool movingRight = true;

	//follow player
	public float followSpeed;
	Transform target;

	public float detectionArea = 4f;
	public RaycastHit2D playerDetectedLeft;
	public RaycastHit2D playerDetectedRight;
	public bool detected = false;
	public LayerMask detectionMask;

	void Start()
	{
		target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();

		//detect player raycasts
		playerDetectedLeft = Physics2D.Raycast (transform.position, Vector2.left, detectionArea, detectionMask);
		playerDetectedRight = Physics2D.Raycast (transform.position, Vector2.right, detectionArea, detectionMask);
	}

	void Update()
	{
		//detect player on surface
		DetectPlayer();

		//player not detected yet
		if (detected == false) {
			//patrol state
			transform.Translate (Vector2.right * speed * Time.deltaTime);

			RaycastHit2D groundInfo = Physics2D.Raycast (groundDetection.position, Vector2.down, distance);

			//time to turn the enemy around when it has run out of ground
			if (groundInfo.collider == false) {
				if (movingRight == true) {
					transform.eulerAngles = new Vector3 (0, -180, 0);
					movingRight = false;
				} else {
					transform.eulerAngles = new Vector3 (0, 0, 0);
					movingRight = true;
				}
			}
		} else //player detected
		{
			//follow player state
			transform.position = Vector2.MoveTowards(transform.position, target.position, followSpeed * Time.deltaTime);
		}

	}

	void DetectPlayer()
	{
		//update colliders
		playerDetectedLeft = Physics2D.Raycast (transform.position, Vector2.left, detectionArea, detectionMask);
		playerDetectedRight = Physics2D.Raycast (transform.position, Vector2.right, detectionArea, detectionMask);

		if (playerDetectedLeft.collider != null || playerDetectedRight.collider != null) {
			detected = true;
		} else {
			detected = false;
		}
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;

		//ground detection
		Gizmos.DrawLine (groundDetection.transform.position, (Vector2)groundDetection.transform.position + Vector2.down * distance);

		//player detection
		Gizmos.DrawLine (transform.position, (Vector2)transform.position + Vector2.left * detectionArea);
		Gizmos.DrawLine (transform.position, (Vector2)transform.position + Vector2.right * detectionArea);
	}
}
