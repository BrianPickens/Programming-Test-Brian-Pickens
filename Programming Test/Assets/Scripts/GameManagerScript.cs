using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour {

	public static GameManagerScript instance = null;

	public int _points { get; set; }
	public int _meat { get; set; }
	private bool _gameOver;
	public float _ItemSpeed { get; set; }
	private float _speedIncrease;
	private float _pointsCap;
	public bool _changingLevel { get; set; }
	public int _levelNumber { get; set; }
	private int _forkDropCap;
	private bool _dropFork;

	//public List<int> _objectIdentities;

	void Awake (){

		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}

		DontDestroyOnLoad (gameObject);
	}

	void Start () {
		_speedIncrease = 0.25f;
		ResetGame ();

		//	_objectIdentities = new List<int> ();
	}

	public int GetIdentity () {

		//0 - vegetable
		//1 - meat
		//2 - fork

		if (!_dropFork) {
			int itemchance = Random.Range (0, 100);
			if (itemchance < 75) {
				return 0;
			} else {
				return 1;
			}
		} else {
			_dropFork = false;
			return 2;
		}
		//return tempIdentity;

	}

	private void CheckIdentities () {
		//use this to balance the amount of meats/forks
	}

	public void AddPoints (int itemIdentity) {
		if (!_gameOver) {
			switch (itemIdentity) {
			case 0:
				_points += 10;
				_pointsCap += 10;
				_forkDropCap += 10;
				break;

			case 1:
				_points += 100;
				_pointsCap += 100;
				_forkDropCap += 100;
				break;

			case 2:
				RemoveMeat ();
				break;


			default:
				Debug.Log ("Something is broken in addpoints");
				break;
			}
		}

		if (_pointsCap >= 1000) {
			_pointsCap -= 1000;
			_ItemSpeed += _speedIncrease;
			ChangeLevel ();
		}

		if (_forkDropCap >= 750) {
			_forkDropCap -= 750;
			_dropFork = true;
		}

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
		_pointsCap = 0;
		_ItemSpeed = 1;
		_changingLevel = false;
		_levelNumber = 0;
		ChangeLevel ();
	}

	private IEnumerator GameOver () {
		//add game over screen
		yield return new WaitForSeconds(2f);
		//load ending
		SceneManager.LoadScene (2);
	}
		
	private void ChangeLevel () {
		_changingLevel = true;
		_levelNumber++;

	}

	public void EndChangingLevel () {
		_changingLevel = false;
	}

}
