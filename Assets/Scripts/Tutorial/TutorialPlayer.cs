using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPlayer : MonoBehaviour {

	Rigidbody2D player;
	Animator animator;
	public float speed = -200f;

	void Start () 
	{
		player = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
	}

	void Update () 
	{
		if (player.velocity.y < 0) {
			animator.SetBool ("falling", true);
		} else {
			player.AddForce (transform.right * speed);
			animator.SetBool ("falling", false);
			animator.SetBool ("run", true);
		}
	}
}
