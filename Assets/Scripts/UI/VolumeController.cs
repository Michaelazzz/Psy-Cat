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
	public bool background;
	private AudioSource backgroundMusic;

	[Header("Animator (Background Music)")]
	public Animator musicAnim;

	void Start()
	{
		backgroundMusic = GameObject.Find ("BackgroundMusic").GetComponent<AudioSource>();

		//get volume from object
		if (background) {
			slider.value = backgroundMusic.volume;
		} else {
			slider.value = soundObject.volume;
		}

		//disable animator if there is one
		if (musicAnim != null)
			musicAnim.enabled = false;
	}

	void Update()
	{
		//update volume with slider value
		if (background) {
			backgroundMusic.volume = slider.value;
		} else {
			soundObject.volume = slider.value;
		}
	}
}
