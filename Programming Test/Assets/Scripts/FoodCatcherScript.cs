using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCatcherScript : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Vegetable") {
			GameManagerScript.instance.AddPoints (0);
		}

		if (other.gameObject.tag == "Meat") {
			GameManagerScript.instance.AddMeat ();
		}
	}
}
