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
	private AudioSource backgroundMusic;

	[Header("Animator (Background Music)")]
	public Animator musicAnim;

	void Start()
	{
		backgroundMusic = GameObject.Find ("BackgroundMusic").GetComponent<AudioSource>();

		//get volume from object
		slider.value = backgroundMusic.volume;

		//disable animator if there is one
		if (musicAnim != null)
			musicAnim.enabled = false;
	}

	void Update()
	{
		//update volume with slider value
		backgroundMusic.volume = slider.value;
	}
}
