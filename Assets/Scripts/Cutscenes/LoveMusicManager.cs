using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoveMusicManager : SingletonMainBehaviour<LoveMusicManager> {

	public AudioClip MainMusic;
	public AudioClip LoveMusic;

	public LoopAudioSource looper;

	private float timeBeforeCutscene = 0.0f;

	void Awake(){

		looper = GetComponent<LoopAudioSource>();

	}

	public void StartCutscene(){

		PlayOneShotMusic(LoveMusic);

	}

	public void PlayOneShotMusic(AudioClip clip){

		looper.enabled = false;
		GetComponent<AudioSource>().clip = LoveMusic;
		timeBeforeCutscene = GetComponent<AudioSource>().time;
		GetComponent<AudioSource>().time = 0.0f;
		GetComponent<AudioSource>().Play();
		Invoke("EndCutscene", LoveMusic.length);

	}

	public void EndCutscene(){

		looper.enabled = true;
		GetComponent<AudioSource>().clip = MainMusic;
		GetComponent<AudioSource>().time = timeBeforeCutscene;
		GetComponent<AudioSource>().Play();

	}

}
