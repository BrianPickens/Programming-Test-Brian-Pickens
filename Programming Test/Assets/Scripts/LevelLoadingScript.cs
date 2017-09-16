using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoadingScript : MonoBehaviour {

	[SerializeField]
	private bool _LoadMenu;
	[SerializeField]
	private bool _LoadGame;
	[SerializeField]
	private bool _LoadEnd;

	void OnTriggerEnter (Collider other){
		if (other.gameObject.tag == "RobotFist") {

			if (_LoadMenu) {
				StartCoroutine (LoadDelay (0));
			}

			if (_LoadGame) {
				StartCoroutine (LoadDelay (1));
			}

			if (_LoadEnd) {
				StartCoroutine (LoadDelay (2));
			}

		}
	}

	private IEnumerator LoadDelay(int sceneNum){
		yield return new WaitForSeconds (2f);
		SceneManager.LoadScene (sceneNum);
	}
}
