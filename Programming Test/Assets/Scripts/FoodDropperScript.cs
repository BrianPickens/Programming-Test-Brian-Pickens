using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDropperScript : MonoBehaviour {

	[SerializeField]
	private float _dropInterval;

	void Start () {

		InvokeRepeating ("DropFood", _dropInterval, _dropInterval);

	}

	void Update () {
		
	}

	private void DropFood (){

		GameObject obj = ObjectPoolingScript.instance.GetPooledObject ();

		if (obj == null) {
			return;
		}

		obj.transform.position = transform.position;
		obj.transform.rotation = transform.rotation;
		obj.SetActive (true);

	}
}
