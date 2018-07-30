using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour 
{
	//movement
	[Header("Movement")]
	[SerializeField]
	private float speed = 10f;					//how fast the player moves
	[SerializeField]
	private float pushSpeed = 5f;				//how fast the player moves while push or pulling
	private Rigidbody2D playerRigidBody;		//the physics of the player
	[SerializeField]
	private bool facingRight = false;			//which way the player is facing
	Animator animator;							//get reference to the animator

	//jump
	[Header("Jump")]
	[SerializeField]
	private float jumpSpeed = 10f;
	[SerializeField]
	private float fallMultiplier = 3;
	[SerializeField]
	private float lowJumpMultiplier = 2;
	private bool jumpRequest = false;

	//ground
	[Header("Ground")]
	[SerializeField]
	private Transform[] groundPoints;
	[SerializeField]
	private LayerMask ground;
	private float groundRadius = 0.1f;
	public bool grounded;

	//pushable box
	[Header("Pushable Box")]
	public float raycastDistance = 1.2f;		//distance raycast will be projected
	public LayerMask boxMask;
	private bool pushpull = false;				// if the player is currently pushing or pulling
	private GameObject box;						//the box the raycast has hit
	private float tempSpeed;
	RaycastHit2D hit;							//raycast to detect collision with box
	private bool forward = true;

	//enemy
	[Header("Enemy")]
	public float enemyDetectionArea = 0.5f;
	public LayerMask enemyMask;
	RaycastHit2D enemyHitLeft;
	RaycastHit2D enemyHitRight;
	RaycastHit2D enemyHitDown;
	public bool dead = false;

	//environment detection
	[Header("Environment Detection")]
	public BoxCollider2D environmentCollider;
	//public float environmentDetectionArea = 1.2f;
	public LayerMask environmentMask;
	//RaycastHit2D environmentHit;

	//scene transition
	[Header("Scene Transition")]
	public Animator transitionAnim;
	public string sceneName;

	//sound effects
	[Header("Sound Effects")]
	public AudioClip[] jumpSounds;
	public float volLowRange = 0.5f;
	public float volHighRange = 1f;
	private AudioSource source;

	void Awake()
	{
		//get audio source from player
		source = GetComponent<AudioSource>();

		//pushable box
		tempSpeed = speed;
		hit = Physics2D.Raycast (transform.position, Vector2.left, raycastDistance, boxMask);

		//enemy detection raycasts
		enemyHitLeft = Physics2D.Raycast (transform.position, Vector2.left, enemyDetectionArea, enemyMask);
		enemyHitRight = Physics2D.Raycast (transform.position, Vector2.right, enemyDetectionArea, enemyMask);

		//environment detection
		//environmentHit = Physics2D.Raycast (transform.position, Vector2.left, environmentDetectionArea, environmentMask);

		playerRigidBody = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
	}

	//player input
	void Update()
	{
		//jump
		if (Input.GetButtonDown ("Jump") && grounded) {
			//play jump sound
			float vol = Random.Range(volLowRange, volHighRange);

			//get random number between 0 and size of the array and play sound
			source.PlayOneShot (jumpSounds[Random.Range(0, jumpSounds.Length)], vol);

			jumpRequest = true;
		}
	}

	//physics in fixed update
	void FixedUpdate()
	{
		//if player is dead disable controls
		if (!dead) {
			//grounded
			grounded = isGrounded ();

			//enemy detection
			detectEnemy ();

			//y velocity of player
			float velocityY = playerRigidBody.velocity.y;

			//get movement direction
			float horizontal = Input.GetAxis ("Horizontal");

			//if button is being pressed and front of character is colliding with the environment
			if (environmentCollider.IsTouchingLayers(environmentMask) && Mathf.Abs(horizontal) > 0f && !grounded) 
			{
				//stop horizontal movement
				horizontal = 0;


			}

			//add velocity to the rigid body in the direction of the movement * our speed
			playerRigidBody.velocity = new Vector2 (horizontal * speed, playerRigidBody.velocity.y);

			//change speed if push/pull is true
			if (pushpull)
				speed = pushSpeed;
			else
				speed = tempSpeed;

			//jump
			jump();

			//push box collision detecting
			Physics2D.queriesStartInColliders = false;

			if (!facingRight) 
			{
				//push box raycast left
				hit = Physics2D.Raycast (transform.position, Vector2.left, raycastDistance, boxMask);
			} 
			else 
			{
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
			if (hit.collider != null && Input.GetButtonDown ("PushPull")) 
			{
				pushpull = true;
				box = hit.collider.gameObject;
				box.GetComponent<FixedJoint2D> ().enabled = true;
				box.GetComponent<FixedJoint2D> ().connectedBody = playerRigidBody;

				//Debug.Log ("Pushing/Pulling");
			} 
			else if (!Input.GetButton ("PushPull") && box != null) { //alternative -> Input.GetButtonUp ("PushPull")
				pushpull = false;
				box.GetComponent<FixedJoint2D> ().enabled = false;
			}

			//animator variables
			animator.SetBool ("forward", forward);
			animator.SetBool ("pushpull", pushpull);
			animator.SetBool ("grounded", grounded);
			animator.SetFloat ("velocityX", Mathf.Abs (horizontal));
			animator.SetFloat ("rigidbodyVelocityX", playerRigidBody.velocity.x);
			animator.SetFloat ("velocityY", velocityY);
			animator.SetBool ("dead", dead);
		}
	}

	void Flip()
	{
		//saying we are facing in the opposite direction
		facingRight = !facingRight;

		//flip on the x axis
		animator.transform.Rotate (new Vector3(0, 180, 0));
	}

	void jump()
	{
		//if button is pressed and player is grounded
		if (jumpRequest && grounded) {
			//playerRigidBody.velocity = Vector2.up * jumpSpeed;
			playerRigidBody.AddForce (Vector2.up * jumpSpeed, ForceMode2D.Impulse);

			jumpRequest = false;
		} else if (!Input.GetButton ("Jump")) { //cancel jump if player lets go
			if (playerRigidBody.velocity.y > 0) {
				playerRigidBody.gravityScale = lowJumpMultiplier;
				//alternative
				//playerRigidBody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
			} 
			//else {
			//	playerRigidBody.gravityScale = 1f;
			//}
		} else if (playerRigidBody.velocity.y < 0) //if player is falling
		{
			playerRigidBody.gravityScale = fallMultiplier;
			//alternative
			//playerRigidBody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
		} 
		else
		{
			playerRigidBody.gravityScale = 1f;
		}
	}

	void detectEnemy()
	{
		enemyHitLeft = Physics2D.Raycast (transform.position, Vector2.left, enemyDetectionArea, enemyMask);
		enemyHitRight = Physics2D.Raycast (transform.position, Vector2.right, enemyDetectionArea, enemyMask);
		enemyHitDown = Physics2D.Raycast (transform.position, Vector2.down, enemyDetectionArea, enemyMask);

		//player dies
		if (enemyHitLeft.collider != null || enemyHitRight.collider != null || enemyHitDown.collider != null)
		{
			dead = true;
			StartCoroutine (LoadScene());
		}
	}

	private bool isGrounded()
	{
		//falling or on ground
		if (playerRigidBody.velocity.y == 0) 
		{
			foreach (Transform point in groundPoints) 
			{
				Collider2D[] colliders = Physics2D.OverlapCircleAll (point.position, groundRadius, ground);
				for (int i = 0; i < colliders.Length; i++) 
				{
					if (colliders [i].gameObject != null) 
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	IEnumerator LoadScene()
	{
		transitionAnim.SetTrigger ("dead");
		yield return new WaitForSeconds (1.5f);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		//SceneManager.LoadScene (sceneName);
	}
		
	void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;

		//box detection
		if(!facingRight)
			Gizmos.DrawLine (transform.position, (Vector2)transform.position + Vector2.left * raycastDistance);
		else if(facingRight)
			Gizmos.DrawLine (transform.position, (Vector2)transform.position + Vector2.right * raycastDistance);

		//enemy detection
		//Gizmos.DrawLine (transform.position, (Vector2)transform.position + Vector2.left * enemyDetectionArea);
		//Gizmos.DrawLine (transform.position, (Vector2)transform.position + Vector2.right * enemyDetectionArea);
	}
}
