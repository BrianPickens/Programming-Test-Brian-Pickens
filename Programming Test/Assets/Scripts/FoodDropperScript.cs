using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Grabs objects from the object pooling script to be dropped.
//uses two sets of droppers called dropfood and offsetdropfood to add more variation to where food can be dropped
//these two droppers alternate to make food always appear all over the screen

public class FoodDropperScript : MonoBehaviour {

	[SerializeField]
	private float _dropInterval;

	private int _lastDropIndex;
	private int _lastDropIndexOffset;
	private int _currentDropIndex;
	private int _currentDropIndexOffset;

	private Transform[] _FoodDroppers;

	void Start () {
		
		_FoodDroppers = GetComponentsInChildren<Transform> ();

		//makes food droppers fire in alternating sequence
		InvokeRepeating ("DropFood", _dropInterval, _dropInterval);
		InvokeRepeating ("OffsetDropFood", _dropInterval * 1.5f, _dropInterval);

	}

	private void DropFood (){

		if (!GameManagerScript.instance._changingLevel) {

			while (_lastDropIndex == _currentDropIndex) {
				_currentDropIndex = Random.Range (1, _FoodDroppers.Length/2 + 1);
			}

			_lastDropIndex = _currentDropIndex;
			GameObject obj = ObjectPoolingScript.instance.GetPooledObject ();

			obj.transform.position = _FoodDroppers [_currentDropIndex].position;
			obj.transform.rotation = _FoodDroppers [_currentDropIndex].rotation;
			obj.SetActive (true);

		}

	}

	private void OffsetDropFood() {
		
		if (!GameManagerScript.instance._changingLevel) {

			while (_lastDropIndexOffset == _currentDropIndexOffset) {
				_currentDropIndexOffset = Random.Range (_FoodDroppers.Length/2 + 1, _FoodDroppers.Length);
			}

			_lastDropIndexOffset = _currentDropIndexOffset;
			GameObject obj = ObjectPoolingScript.instance.GetPooledObject ();

			obj.transform.position = _FoodDroppers [_currentDropIndexOffset].position;
			obj.transform.rotation = _FoodDroppers [_currentDropIndexOffset].rotation;
			obj.SetActive (true);
		}

	}
}
