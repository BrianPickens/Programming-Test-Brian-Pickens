using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsDisplayScript : MonoBehaviour {

	private Text _myText;
	public Animator _myAnim;
	private int _myPoints;

	void Start () {
		_myAnim = GetComponent<Animator> ();
		_myText = GetComponent<Text> ();
	}

	void Update () {

		if (_myPoints != GameManagerScript.instance._points) {
			AdjustPoints ();
		}

	}

	private void AdjustPoints () {
		
		_myPoints = GameManagerScript.instance._points;
		_myText.text = "" + _myPoints;
		_myAnim.SetTrigger("popPoints");

	}
}
