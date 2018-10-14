using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundEffectsVolume : MonoBehaviour {

	//slider
	[Header("Slider")]
	public Slider slider;
	//object with the sound
	[Header("Sound Object")]
	public AudioSource[] soundEffects;

	void Start()
	{
		//get volume from object
		slider.value = soundEffects[0].volume;
	}

	void Update()
	{
		//update volume with slider value
		for(int i = 0; i < soundEffects.Length; i++)
			soundEffects[i].volume = slider.value;
	}
}
