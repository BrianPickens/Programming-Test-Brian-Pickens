using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Displays what level the player is on
//Listens to the GameManager to determine what level should be displayed next

public class LevelDisplayScript : MonoBehaviour {

	public AudioClip _newLevelClip;

	private Text _myText;
	private bool _updateLevel;

	void Start () {
		
		_updateLevel = false;
		_myText = GetComponent<Text> ();
		_myText.enabled = true;

	}

	void Update () {

		if (GameManagerScript.instance._changingLevel && !_updateLevel) {
			_updateLevel = true;
			StartCoroutine(UpdateLevelDisplay ());
		}

		if (!GameManagerScript.instance._changingLevel) {
			_myText.enabled = false;
			_updateLevel = false;
		}

	}

	private IEnumerator UpdateLevelDisplay () {
		
		SoundManagerScript.instance.PlayLevelSfx (_newLevelClip);
		_myText.text = "Level " + GameManagerScript.instance._levelNumber;
		_myText.enabled = true;

		//make it wait longer if the tutorial is displayed;
		if (GameManagerScript.instance._displayTutorial) {
			yield return new WaitForSeconds (3f);
		}

		yield return new WaitForSeconds (4f);
		GameManagerScript.instance.EndChangingLevel ();

	}

}
