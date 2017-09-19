using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCatcherScript : MonoBehaviour {

	[SerializeField]
	private GameObject _myParticles;

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Vegetable") {
			GameManagerScript.instance.AddPoints (0);
		}

		if (other.gameObject.tag == "Meat") {
			_myParticles.transform.position = other.gameObject.transform.position;
			_myParticles.SetActive (true);
			CameraShakeScript.instance.ShakeCamera ();
			GameManagerScript.instance.AddMeat ();
		}
	}
}
