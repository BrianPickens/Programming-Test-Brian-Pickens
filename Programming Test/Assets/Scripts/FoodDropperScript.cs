using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDropperScript : MonoBehaviour {

	[SerializeField]
	private float _dropInterval;

	private Transform[] _FoodDroppers;
//	public List<GameObject> _foodHolders;

	void Start () {
		_FoodDroppers = GetComponentsInChildren<Transform> ();
	//	_foodHolders = new List<GameObject> ();

		InvokeRepeating ("DropFood", _dropInterval, _dropInterval);

	}

	private void DropFood (){

		for (int i = 1; i < _FoodDroppers.Length; i++) {
			GameObject obj = ObjectPoolingScript.instance.GetPooledObject ();
			//int listNum = obj.GetComponent<PunchableObjectScript> ().listIndex;
			//_foodHolders.Insert (listNum, obj);
			//_foodHolders.RemoveAt (listNum + 1);
			if (obj == null) {
				return;
			}

			obj.transform.position = _FoodDroppers[i].position;
			obj.transform.rotation = _FoodDroppers[i].rotation;
			obj.SetActive (true);
		}

	}
}
