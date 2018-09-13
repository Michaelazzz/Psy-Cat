using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpin : MonoBehaviour {

	public float rotateSpeed = 5f;

	void Update()
	{
		transform.Rotate (Vector3.forward * rotateSpeed);
	}
}
