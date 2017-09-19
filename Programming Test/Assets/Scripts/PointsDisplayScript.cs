using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Displays points during game and gives the final score at end of game
//listens to GameManger to update points

public class PointsDisplayScript : MonoBehaviour {

	private Text _myText;
	private Animator _myAnim;
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
