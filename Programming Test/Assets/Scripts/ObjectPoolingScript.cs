using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Generaic Object Pooling script that can be used to pool objects
//parents them to this object to keep inspector clean
//looks for inactive objects in it the hierarchy to use, otherwise it will create a new one

public class ObjectPoolingScript : MonoBehaviour {

	public static ObjectPoolingScript instance;

	public GameObject _PooledObject;

	[SerializeField]
	private bool _willGrow = true;

	private List<GameObject> _pooledObjects;

	void Awake (){
		
		instance = this;

	}
		
	void Start () {
		
		_pooledObjects = new List<GameObject> ();

	}

	public GameObject GetPooledObject (){
		
		for (int i = 0; i < _pooledObjects.Count; i++) {
			if (!_pooledObjects [i].activeInHierarchy) {
				return _pooledObjects [i];
			}
		}

		if (_willGrow) {
			GameObject obj = (GameObject)Instantiate (_PooledObject);
			_pooledObjects.Add (obj);
			obj.transform.SetParent (this.transform);
			return obj;
		}

		return null;

	}
}
