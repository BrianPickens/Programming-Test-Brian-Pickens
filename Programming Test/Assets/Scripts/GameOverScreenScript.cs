using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreenScript : MonoBehaviour {

	public AudioClip _gameOverClip;

	public GameObject _GameOverScreen;
	private bool _gameIsOver;

	void Start () {
		_GameOverScreen.SetActive (false);
		_gameIsOver = false;
	}

	void Update () {

		if (GameManagerScript.instance._gameOver && !_gameIsOver) {
			_gameIsOver = true;
			_GameOverScreen.SetActive (true);
			SoundManagerScript.instance.PlayLevelSfx (_gameOverClip);
		}

	}
}
