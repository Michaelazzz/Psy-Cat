using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

	//this script goes onto the camera

	public Transform[] backgrounds;
	private float[] parallaxScales;		//amount of movement for each layer as the camera moves
	public float smooth = 10;				//how smooth it looks

	private Vector3 previousCameraPosition;

	void Start()
	{
		previousCameraPosition = transform.position;

		parallaxScales = new float[backgrounds.Length];
		for (int i = 0; i < parallaxScales.Length; i++) {
			parallaxScales [i] = backgrounds [i].position.z * -1;
		}
	}

	void LateUpdate()
	{
		for (int i = 0; i < backgrounds.Length; i++) {
			Vector3 parallax = (previousCameraPosition - transform.position) * (parallaxScales [i] / smooth);

			backgrounds [i].position = new Vector3 (backgrounds[i].position.x + parallax.x, backgrounds[i].position.y + parallax.y, backgrounds[i].position.z);
		}

		previousCameraPosition = transform.position;
	}
}
