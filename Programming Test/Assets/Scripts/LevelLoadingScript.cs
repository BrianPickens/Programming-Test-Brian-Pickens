using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoadingScript : PunchableObjectScript {

	public GameObject _Meat;
	public GameObject _Vegetable;

	[SerializeField]
	private bool _LoadMenu;
	[SerializeField]
	private bool _LoadGame;

	void Start () {
		SetItemModel ();
	}

	private void SetItemModel() {

		_Meat.SetActive (false);
		_Vegetable.SetActive (false);

		if (_LoadGame) {
			_Meat.SetActive (true);
		}

		if (_LoadMenu) {
			_Vegetable.SetActive (true);
		}


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
