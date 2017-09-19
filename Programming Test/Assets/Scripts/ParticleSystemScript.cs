using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Punch Particle System Script
//Turns itself off after a single burst so that it can be relocated and reused

public class ParticleSystemScript : MonoBehaviour {

	public static ParticleSystemScript instance = null;


	void Awake (){

		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}

		DontDestroyOnLoad (gameObject);

	}

	void OnEnable () {
		
		Invoke ("Destroy", 0.45f);

	}

	private void Destroy () {
		
		gameObject.SetActive (false);

	}

}
