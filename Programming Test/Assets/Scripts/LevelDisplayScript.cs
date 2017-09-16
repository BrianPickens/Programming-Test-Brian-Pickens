using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDisplayScript : MonoBehaviour {

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
			//UpdateLevelDisplay ();
			StartCoroutine(UpdateLevelDisplay ());
			Debug.Log ("updatecalled");
		}

		if (!GameManagerScript.instance._changingLevel) {
			_myText.enabled = false;
			_updateLevel = false;
		}

	}

	private IEnumerator UpdateLevelDisplay () {
		_myText.text = "Level " + GameManagerScript.instance._levelNumber;
		Debug.Log ("level displayed");
		_myText.enabled = true;
		yield return new WaitForSeconds (4f);
		GameManagerScript.instance.EndChangingLevel ();
	}

	/*private void UpdateLevelDisplay (){
		_updateLevel = true;
		_myText.text = "Level " + GameManagerScript.instance._levelNumber;
		Debug.Log ("level displayed");
		_myText.enabled = true;
	}*/
}
