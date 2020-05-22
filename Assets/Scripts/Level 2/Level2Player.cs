using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Player : MonoBehaviour {

	Rigidbody2D player;
	Animator playerAnim;
	public float speed = -200f;
	public float time = 1.5f;

	void Start () 
	{
		player = GetComponent<Rigidbody2D> ();
		playerAnim = GetComponent<Animator> ();
	}

	void Update () 
	{
		StartCoroutine (PlayerMove ());
	}

	IEnumerator PlayerMove()
	{
		yield return new WaitForSeconds (time);
		player.AddForce (transform.right * speed);
		playerAnim.SetBool ("run", true);
	}
}
