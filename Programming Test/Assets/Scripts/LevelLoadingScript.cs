using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//A punchable object that loads a specific level depending on what is assigned in the inspector
//Scene Numbers
//0 - Menu
//1 - Game
//2 - End
//3 - Credits

public class LevelLoadingScript : PunchableObjectScript {

	public GameObject _Meat;
	public GameObject _Vegetable;

	[SerializeField]
	private bool _loadMenu;
	[SerializeField]
	private bool _loadGame;

	void Start () {
		
		SetItemModel ();

	}

	private void SetItemModel() {

		_Meat.SetActive (false);
		_Vegetable.SetActive (false);

		if (_loadGame) {
			_Meat.SetActive (true);
		}

		if (_loadMenu) {
			_Vegetable.SetActive (true);
		}


	}

	public override void OnTriggerEnter (Collider other){

		base.OnTriggerEnter (other);

		if (other.CompareTag("RobotFist")) {

			if (_loadMenu) {
				StartCoroutine (LoadDelay (0));
			}

			if (_loadGame) {
				GameManagerScript.instance.ResetGame ();
				StartCoroutine (LoadDelay (1));
			}

		}
	}

	private IEnumerator LoadDelay(int sceneNum){

		//load delay so player can watch the object fly
		yield return new WaitForSeconds (2f);
		SceneManager.LoadScene (sceneNum);

	}
}
