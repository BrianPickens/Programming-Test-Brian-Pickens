using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeatsDisplayScript : MonoBehaviour {

	public Sprite _MeatOn;
	public Sprite _MeatOff;

	public Image[] _meatDisplays;
	private int _currentMeatLevel;

	void Start () {
		
		_currentMeatLevel = 0;
		_meatDisplays = GetComponentsInChildren<Image> ();
	
		for (int i = 0; i < _meatDisplays.Length; i++) {
			_meatDisplays [i].sprite = _MeatOff;
		}
			
	}

	void Update () {

		if (_currentMeatLevel != GameManagerScript.instance._meat) {
			_currentMeatLevel = GameManagerScript.instance._meat;
			UpdateMeatDisplay ();
		}
			
	}

	private void UpdateMeatDisplay() {
		
		for (int i = 0; i < _meatDisplays.Length; i++) {
			if (i <= _currentMeatLevel - 1) {
				_meatDisplays [i].sprite = _MeatOn;
			} else {
				_meatDisplays [i].sprite = _MeatOff;
			}
		}

	}
}
