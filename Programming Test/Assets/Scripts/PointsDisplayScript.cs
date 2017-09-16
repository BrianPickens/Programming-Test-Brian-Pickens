using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsDisplayScript : MonoBehaviour {

	private Text _myText;

	// Use this for initialization
	void Start () {
		_myText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		_myText.text = "" + GameManagerScript.instance._points;
	}
}
