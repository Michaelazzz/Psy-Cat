using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxAudio : MonoBehaviour {

	//player
	private Transform player;

	//public AudioClip fallSound;
	private AudioSource source;

	//distance
	float distance;

	//distance range
	public float range = 11;
	public float minRange = 2;

	//volume range
	public float volClose = 0.3f;
	public float volFar = 0f;

	void Start () 
	{
		//player
		player = GameObject.Find ("Player").transform;
		//audio source
		source = GetComponent<AudioSource>();
	}
	
	void Update () 
	{
		//get distance from box to player
		distance = Vector3.Distance(player.position, transform.position);

		//calculate volume
		if (distance > range || distance < minRange)
			source.volume = volFar;
		else
			source.volume = volClose;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		//layer 8 is environemt
		if(collision.gameObject.layer == 8)
			source.Play ();
	}
}
