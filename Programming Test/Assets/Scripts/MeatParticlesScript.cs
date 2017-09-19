using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Meat Impact Particle System
//Turns itself off after single burst so that it can be reused

public class MeatParticlesScript : MonoBehaviour {

	void OnEnable () {
		
		Invoke ("Destroy", 0.45f);

	}

	private void Destroy () {
		
		gameObject.SetActive (false);

	}
}
