using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Game Manager that handles points, meats, explosion particles, level changes, item identities, and Game Over
//responds to over object calling function on it

public class GameManagerScript : MonoBehaviour {

	public static GameManagerScript instance = null;

	public AudioClip _meatPassClip;
	public AudioClip _forkHitClip;

	[SerializeField]
	private GameObject _gameParticles;

	public int _points { get; set; }
	public int _meat { get; set; }
	public int _levelNumber { get; set; }
	public bool _gameOver { get; set; }
	public bool _changingLevel { get; set; }
	public bool _displayTutorial { get; set; }
	public float _ItemSpeed { get; set; }

	private float _speedIncrease;
	private float _pointsCap;
	private bool _dropFork;
	private bool _lastWasMeat;
	private int _forkDropCap;
	private int _meatScreenCount;
	private int _vegetableScreenCount;

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

	}

	void Update () {
		
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}

	}

	public int GetIdentity () {

		//0 - vegetable
		//1 - meat
		//2 - fork
		//limits the number of meats that can appear

		_vegetableScreenCount++;

		if (_vegetableScreenCount >= 10) {
			_vegetableScreenCount = 0;
			_meatScreenCount = 0;
		}
			
		if (!_dropFork) {
			int itemchance = Random.Range (0, 100);
			if (itemchance < 75) {
				_lastWasMeat = false;
				return 0;
			} else if (_meatScreenCount <= 3 && !_lastWasMeat) {
				_meatScreenCount++;
				_lastWasMeat = true;
				return 1;
			} else {
				_lastWasMeat = false;
				return 0;
			}
		} else {
			_dropFork = false;
			_lastWasMeat = false;
			return 2;
		}

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
				SoundManagerScript.instance.PlaySfx (_forkHitClip);
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
		
		SoundManagerScript.instance.PlaySfx (_meatPassClip);

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
		_forkDropCap = 0;
		_ItemSpeed = 1;
		_changingLevel = false;
		_levelNumber = 0;
		_displayTutorial = true;
		ChangeLevel ();

	}

	private IEnumerator GameOver () {
		
		yield return new WaitForSeconds(5f);
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

	public void EndDisplayingTutorial (){
		
		_displayTutorial = false;

	}

	public void HitParticles (Vector3 hitLocation) {
		
		_gameParticles.transform.position = hitLocation;
		_gameParticles.SetActive (true);

	}
		
}
