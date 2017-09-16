using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDropperScript : MonoBehaviour {

	[SerializeField]
	private float _dropInterval;

	private Transform[] _FoodDroppers;

	void Start () {
		_FoodDroppers = GetComponentsInChildren<Transform> ();

		InvokeRepeating ("DropFood", _dropInterval, _dropInterval);

	}

	private void DropFood (){

		for (int i = 1; i < _FoodDroppers.Length; i++) {
			GameObject obj = ObjectPoolingScript.instance.GetPooledObject ();

			if (obj == null) {
				return;
			}

			obj.transform.position = _FoodDroppers[i].position;
			obj.transform.rotation = _FoodDroppers[i].rotation;
			obj.SetActive (true);
		}

	}
}
