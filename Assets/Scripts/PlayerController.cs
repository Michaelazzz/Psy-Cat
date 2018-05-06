using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	//movement
	[SerializeField]
	private float speed = 10f;					//how fast the player moves
	[SerializeField]
	private float pushSpeed = 5f;				//how fast the player moves while push or pulling
	private Rigidbody2D playerRigidBody;		//the physics of the player
	private bool facingRight = false;			//which way the player is facing
	Animator animator;							//get reference to the animator

	//jump
	[SerializeField]
	private float jumpSpeed = 10f;
	[SerializeField]
	private float fallMultiplier = 2;
	[SerializeField]
	private float lowJumpMultiplier = 2;
	private bool jumpRequest = false;

	//ground
	[SerializeField]
	private Transform[] groundPoints;
	[SerializeField]
	private LayerMask ground;
	private float groundRadius = 0.1f;
	public bool grounded;

	//pushable box
	public float raycastDistance = 1.2f;		//distance raycast will be projected
	public LayerMask boxMask;
	private bool pushpull = false;				// if the player is currently pushing or pulling
	private GameObject box;						//the box the raycast has hit
	private float tempSpeed;
	RaycastHit2D hit;							//raycast to detect collision
	private bool forward = true;

	//sound effects
	public AudioClip jumpSound;
	private AudioSource playerSource;

	void Awake()
	{
		//get audio source from player
		playerSource = GetComponent<AudioSource>();
		playerSource.clip = jumpSound;

		tempSpeed = speed;
		hit = Physics2D.Raycast (transform.position, Vector2.left, raycastDistance, boxMask);

		playerRigidBody = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
	}

	//player input
	void Update()
	{
		//jump
		if (Input.GetButtonDown ("Jump")) {
			//play jump sound
			playerSource.Play();

			jumpRequest = true;
		}
	}

	//physics in fixed update
	void FixedUpdate()
	{
		//grounded?
		grounded = isGrounded();

		//get movement direction
		float horizontal = Input.GetAxis("Horizontal");

		//add velocity to the rigid body in the direction of the movement * our speed
		playerRigidBody.velocity = new Vector2(horizontal * speed, playerRigidBody.velocity.y);

		//change speed if push/pull is true
		if (pushpull) 
			speed = pushSpeed;
		else 
			speed = tempSpeed;

		//jump
		//if button is pressed and player is grounded
		if (jumpRequest && grounded) 
		{
			//playerRigidBody.velocity = Vector2.up * jumpSpeed;
			playerRigidBody.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);

			//if player is falling
			if (playerRigidBody.velocity.y < 0) {
				playerRigidBody.gravityScale = fallMultiplier;
				//alternative
				//playerRigidBody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
			} else {
				playerRigidBody.gravityScale = 1f;
			}
			jumpRequest = false;
		} 
		else if (!Input.GetButton ("Jump")) //cancel jump if player lets go
		{
			if (playerRigidBody.velocity.y > 0) {
				playerRigidBody.gravityScale = lowJumpMultiplier;
				//alternative
				//playerRigidBody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
			} else {
				playerRigidBody.gravityScale = 1f;
			}
		}

		//push box collision detecting
		Physics2D.queriesStartInColliders = false;

		if (!facingRight) {
			//push box raycast left
			hit = Physics2D.Raycast (transform.position, Vector2.left, raycastDistance, boxMask);
		} else {
			//push box raycast right
			hit = Physics2D.Raycast (transform.position, Vector2.right, raycastDistance, boxMask);
		}

		//if push/pull is true the player cannot flip
		if (!pushpull) {
			//flip
			//if we are not moving left anymore then flip the player
			if (horizontal > 0 && !facingRight) {
				//flip player
				Flip ();
			} else if (horizontal < -0 && facingRight) {
				//flip player
				Flip ();
			}
		} 

		if (!facingRight) {
			if (horizontal < 0) {
				forward = true;
			} else if (horizontal > 0) {
				forward = false;
			}
		} else {
			if (horizontal > 0) {
				forward = true;
			} else if (horizontal < 0) {
				forward = false;
			}
		}

		//if colliding with object and push/pull button is being pressed
		if (hit.collider != null && Input.GetButtonDown ("PushPull")) {
			pushpull = true;
			box = hit.collider.gameObject;
			box.GetComponent<FixedJoint2D> ().enabled = true;
			box.GetComponent<FixedJoint2D> ().connectedBody = playerRigidBody;

			//Debug.Log ("Pushing/Pulling");
		} 
		else if(!Input.GetButton ("PushPull") && box != null) //alternative -> Input.GetButtonUp ("PushPull")
		{
			pushpull = false;
			box.GetComponent<FixedJoint2D> ().enabled = false;
		}

		//animator variables
		animator.SetBool ("forward", forward);
		animator.SetBool ("pushpull", pushpull);
		animator.SetBool ("grounded", grounded);
		animator.SetFloat("velocityX", Mathf.Abs(horizontal));
	}

	void Flip()
	{
		//saying we are facing in the opposite direction
		facingRight = !facingRight;

		//flip on the x axis
		animator.transform.Rotate (new Vector3(0, 180, 0));
	}

	/*void onCollisionEnter(Collision2D collision)
	{
		if (collision.gameObject.layer == ground) {
			grounded = true;
			Debug.Log ("hit ground");
		}
	}

	void onCollisionExit(Collision2D collision)
	{
		if (collision.gameObject.layer == ground)
			grounded = false;
	}*/

	private bool isGrounded()
	{
		//falling or on ground
		if (playerRigidBody.velocity.y <= 0) {
			foreach (Transform point in groundPoints) {
				Collider2D[] colliders = Physics2D.OverlapCircleAll (point.position, groundRadius, ground);

				for (int i = 0; i < colliders.Length; i++) {
					if (colliders [i].gameObject != null) {
						return true;
					}
				}
			}
		}
		return false;
	}
		
	void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;

		if(!facingRight)
			Gizmos.DrawLine (transform.position, (Vector2)transform.position + Vector2.left * raycastDistance);
		else if(facingRight)
			Gizmos.DrawLine (transform.position, (Vector2)transform.position + Vector2.right * raycastDistance);
	}
}
