using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
