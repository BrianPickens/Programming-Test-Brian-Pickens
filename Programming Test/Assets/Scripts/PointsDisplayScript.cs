using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsDisplayScript : MonoBehaviour {

	private Text _myText;

	void Start () {
		_myText = GetComponent<Text> ();
	}

	void Update () {
		_myText.text = "" + GameManagerScript.instance._points;
	}
}
