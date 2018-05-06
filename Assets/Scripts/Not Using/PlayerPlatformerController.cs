using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject {

	public float maxSpeed;
	public float jumpTakeOffSpeed;
	//push box
	public float pushSpeed;
	public float distance = 1f;
	public LayerMask boxMask;
	public bool pushpull = false;
	private GameObject box;
	private Rigidbody2D rb2dBox;

	private float speed;
	private bool facingRight = false;
	//private SpriteRenderer spriteRenderer;
	private Animator animator;

	void Awake()
	{
		speed = maxSpeed;
		animator = GetComponent<Animator> ();
		//spriteRenderer = GetComponent<SpriteRenderer> ();
	}

	protected override void ComputeVelocity()
	{
		Vector2 move = Vector2.zero;
		move.x = Input.GetAxis ("Horizontal");

		//change speed if push/pull is true
		if (pushpull) {
			//change box position based on the player movement
			rb2dBox.AddForce(transform.right * velocity.x);
			//box.transform.position = new Vector3();
			maxSpeed = pushSpeed;
		} 
		else {
			maxSpeed = speed;
		}

		if (Input.GetButtonDown ("Jump") && grounded) 
		{
			velocity.y = jumpTakeOffSpeed;
		} 
		else if (Input.GetButtonUp ("Jump")) //cancel jump if player lets go
		{
			if(velocity.y > 0)
				velocity.y = velocity.y * 0.5f;
		}

		//push box collision detecting
		Physics2D.queriesStartInColliders = false;
		RaycastHit2D hit = Physics2D.Raycast (transform.position, Vector2.left, distance, boxMask);

		//if push/pul is true the player cannot flip
		if (!pushpull) {
			//flip
			if (velocity.x > 0 && !facingRight) {
				//push box raycast
				hit = Physics2D.Raycast (transform.position, Vector2.left, distance, boxMask);

				//flip player
				Flip ();
			} else if (velocity.x < -0 && facingRight) {
				//push box raycast
				hit = Physics2D.Raycast (transform.position, Vector2.right, distance, boxMask);

				//flip player
				Flip ();
			}
		}

		//if colliding with object and push/pull button is being pressed
		if (hit.collider != null && Input.GetButtonDown ("PushPull")) {
			pushpull = true;
			box = hit.collider.gameObject;
			rb2dBox = hit.collider.attachedRigidbody;
			Debug.Log ("Pushing/Pulling");
		} 
		else if(Input.GetButtonUp ("PushPull")) 
		{
			pushpull = false;
		}

		animator.SetBool ("pushpull", pushpull);
		animator.SetBool ("grounded", grounded);
		animator.SetFloat ("velocityX", Mathf.Abs(velocity.x)/maxSpeed);

		targetVelocity = move * maxSpeed;
	}

	void Flip()
	{
		//saying we are facing in the opposite direction
		facingRight = !facingRight;

		//flip on the x axis
		animator.transform.Rotate (new Vector3(0, 180, 0));
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;

		if(!facingRight)
			Gizmos.DrawLine (transform.position, (Vector2)transform.position + Vector2.left* distance);
		else if(facingRight)
			Gizmos.DrawLine (transform.position, (Vector2)transform.position + Vector2.right* distance);
	}
}
