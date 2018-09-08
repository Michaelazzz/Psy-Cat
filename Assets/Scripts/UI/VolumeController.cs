using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour {

	//slider
	[Header("Slider")]
	public Slider slider;
	//object with the sound
	[Header("Sound Object")]
	public AudioSource soundObject; 

	[Header("Animator (Background Music)")]
	public Animator musicAnim;

	void Start()
	{
		//get volume from object
		slider.value = soundObject.volume;

		//disable animator if there is one
		if (musicAnim != null)
			musicAnim.enabled = false;
	}

	void Update()
	{
		//update volume with slider value
		soundObject.volume = slider.value;
	}
}
