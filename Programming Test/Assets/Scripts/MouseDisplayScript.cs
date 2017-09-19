using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Hides cursor during game, but shows it on end screen for credits

public class MouseDisplayScript : MonoBehaviour {

	[SerializeField]
	private bool _hideCursor;

	void Start () {

		DisplayCursor ();

	}

	private void DisplayCursor () {

		if (_hideCursor) {
			Cursor.visible = false;
		} else {
			Cursor.visible = true;
		}

	}

}
