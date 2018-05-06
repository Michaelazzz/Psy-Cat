using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxAudio : MonoBehaviour {

	//public AudioClip fallSound;
	public AudioSource source;

	//RaycastHit2D hit;							//raycast to detect collision
	//public float raycastDistance = 1f;			//distance raycast will be projected
	//private GameObject surface;					//the surface the raycast has hit
	//public LayerMask surfaceMask;
	//public bool ground = false;

	void Start () {
		//draw ray cast
		//hit = Physics2D.Raycast (transform.position, Vector2.down, raycastDistance, surfaceMask);

		source = GetComponent<AudioSource>();
		//source.clip = fallSound;
	}
	
	void Update () 
	{
		//Physics2D.queriesStartInColliders = false;
		//hit = Physics2D.Raycast (transform.position, Vector2.down, raycastDistance, surfaceMask);

		//if (hit.collider != null) {
		//	ground = true;
		//	Debug.Log ("hit ground");
			//source.Play ();
		//} else if (hit.collider == null) {
		//	ground = false;
		//}

		//if (ground)
			
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log ("hit ground");
		//leayer 8 is environemt
		if(collision.gameObject.layer == 8)
			source.Play ();
	}

	//void OnDrawGizmos()
	//{
	//	Gizmos.color = Color.yellow;

	//	Gizmos.DrawLine (transform.position, (Vector2)transform.position + Vector2.down * raycastDistance);
	//}
}
