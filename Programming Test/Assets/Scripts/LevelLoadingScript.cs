using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoadingScript : PunchableObjectScript {

	[SerializeField]
	private bool _LoadMenu;
	[SerializeField]
	private bool _LoadGame;

	void Start () {
		// assign what type of object it is
	}

	public override void OnTriggerEnter (Collider other){

		base.OnTriggerEnter (other);

		if (other.gameObject.tag == "RobotFist") {

			if (_LoadMenu) {
				StartCoroutine (LoadDelay (0));
			}

			if (_LoadGame) {
				GameManagerScript.instance.ResetGame ();
				StartCoroutine (LoadDelay (1));
			}

		}
	}

	private IEnumerator LoadDelay(int sceneNum){
		yield return new WaitForSeconds (2f);
		SceneManager.LoadScene (sceneNum);
	}
}
