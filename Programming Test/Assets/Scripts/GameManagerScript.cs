using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour {

	public static GameManagerScript instance = null;

	public int _points { get; set; }
	private int _meat;
	private bool _gameOver;
	public float _ItemSpeed { get; }

	public List<int> _objectIdentities;

	void Awake (){

		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}

		DontDestroyOnLoad (gameObject);
	}

	void Start () {
		_objectIdentities = new List<int> ();

	}

	void Update () {
		
	}

	public int GetIdentity () {

		//0 - vegetable
		//1 - meat
		//2 - fork

		int tempIdentity = Random.Range (0, 2);
		return tempIdentity;

	}

	private void CheckIdentities () {

	}

	public void AddPoints (int itemIdentity) {

		Debug.Log ("Item was punched");

		switch (itemIdentity) {
		case 0:
			_points += 10;
			break;

		case 1:
			_points += 100;
			break;

		case 2:
			_points += 500;
			RemoveMeat ();
			break;


		default:
			Debug.Log ("Something is broken in addpoints");
			break;
		}
		Debug.Log (_points);
	}

	public void AddMeat () {
		_meat += 1;
		if (_meat >= 3 && !_gameOver) {
			_gameOver = true;
			StartCoroutine (GameOver ());
		}
	}

	public void RemoveMeat () {
		if (_meat > 0) {
			_meat -= 1;
		}
	}

	public void ResetGame () {
		_gameOver = false;
		_meat = 0;
		_points = 0;

	}

	private IEnumerator GameOver () {
		//add game over screen
		yield return new WaitForSeconds(2f);
		//load ending
		SceneManager.LoadScene (2);
	}

}
