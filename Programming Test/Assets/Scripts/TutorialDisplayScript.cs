using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDisplayScript : MonoBehaviour {

	[SerializeField]
	private GameObject _myTutorial;

	private bool _displayingTutorial;

	void Update () {

		if (GameManagerScript.instance._displayTutorial && !_displayingTutorial) {
			_displayingTutorial = true;
			StartCoroutine (DisplayTutorial ());
		}

	}

	private IEnumerator DisplayTutorial () {
		_myTutorial.SetActive (true);
		yield return new WaitForSeconds (7f);
		GameManagerScript.instance.EndDisplayingTutorial ();
		_myTutorial.SetActive (false);
	}
}
