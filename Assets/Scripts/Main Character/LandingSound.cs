using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingSound : MonoBehaviour {

	//[Header("Ground Detection")]
	//public float groundDetectionArea = 0.5f;
	//RaycastHit2D groundHit;

	[Header("Audio")]
	public AudioClip[] landingSounds;
	public float volLowRange = 0.5f;
	public float volHighRange = 1f;
	private AudioSource source;

	public bool hasPlayed = false; 

	void Start()
	{
		//get audio source from player
		source = GetComponent<AudioSource>();

		//ground detection
		//groundHit = Physics2D.Raycast (transform.position, Vector2.down, groundDetectionArea, groundMask);
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		//layer 8 is environemt
		if(collision.gameObject.layer == 8 && !hasPlayed)
		{
			//play jump sound
			float vol = Random.Range(volLowRange, volHighRange);
			//get random number between 0 and size of the array and play sound
			source.PlayOneShot (landingSounds[Random.Range(0, landingSounds.Length)], vol);

			hasPlayed = true;
		}
	}

	void OnCollisionExit2D(Collision2D collision)
	{
		if(hasPlayed)
			hasPlayed = false;
	}

	//void OnDrawGizmos()
	//{
	//	Gizmos.color = Color.yellow;

		//ground detection
	//	Gizmos.DrawLine (transform.position, (Vector2)transform.position + Vector2.down * groundDetectionArea);
	//}
}
