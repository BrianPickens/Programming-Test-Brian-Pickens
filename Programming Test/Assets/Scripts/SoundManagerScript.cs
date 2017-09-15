using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour {

	public AudioSource _phraseSource;
	public AudioSource _walkSource;
	public AudioSource _sfxSource;
	public AudioSource _bgmSource;
	public static SoundManagerScript instance = null;

	[SerializeField]
	private float _pitchMin;
	[SerializeField]
	private float _pitchMax;

	void Awake (){

		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}

		DontDestroyOnLoad (gameObject);
	}
		
	public void PlayBackgroundMusic (AudioClip clip){
		_sfxSource.clip = clip;
		_sfxSource.Play ();
	}

	public void PlayPhrase (params AudioClip[] clips){
		int clipIndex = Random.Range (0, clips.Length);

		_phraseSource.clip = clips [clipIndex];
		_phraseSource.Play ();
	}

	public void PlaySfx (params AudioClip[] clips){
		int clipIndex = Random.Range (0, clips.Length);
		float pitch = Random.Range (_pitchMin, _pitchMax);

		_sfxSource.pitch = pitch;
		_sfxSource.clip = clips [clipIndex];
		_sfxSource.Play ();
	}

	public void PlayWalkSounds(AudioClip clip, bool isWalking){

		_walkSource.clip = clip;

		if (isWalking) {
			_walkSource.Play ();
		} else {
			_walkSource.Stop ();
		}
	}
}
