using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatParticlesScript : MonoBehaviour {

	void OnEnable () {
		Invoke ("Destroy", 0.45f);
	}

	private void Destroy () {
		gameObject.SetActive (false);
	}
}
