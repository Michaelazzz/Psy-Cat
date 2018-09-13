﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyedoor : MonoBehaviour {

	public Animator eyeDoorAnim;

	void OnTriggerEnter2D(Collider2D other)
	{
		eyeDoorAnim.SetTrigger ("close");
	}
}