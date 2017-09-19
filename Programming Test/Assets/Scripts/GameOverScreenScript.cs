using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Displays the Game Over Screen
//Listens to the GameManager to determine when to display the Game Over Screen

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
