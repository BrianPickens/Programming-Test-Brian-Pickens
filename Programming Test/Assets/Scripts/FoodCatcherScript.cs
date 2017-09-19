using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Waits for food to pass it and then tells the GameManager what happened
//also instantiates a particle system at location of meat impacts

public class FoodCatcherScript : MonoBehaviour {

	[SerializeField]
	private GameObject _myParticles;

	void OnTriggerEnter(Collider other){
		
		if (other.CompareTag("Vegetable")) {
			GameManagerScript.instance.AddPoints (0);
		}

		if (other.CompareTag("Meat")) {
			_myParticles.transform.position = other.gameObject.transform.position;
			_myParticles.SetActive (true);
			CameraShakeScript.instance.ShakeCamera ();
			GameManagerScript.instance.AddMeat ();
		}

	}
}
