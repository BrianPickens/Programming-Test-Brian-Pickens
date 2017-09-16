﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingScript : MonoBehaviour {

	public static ObjectPoolingScript instance;
	public GameObject _PooledObject;
	private int _pooledAmount;

	[SerializeField]
	private bool _willGrow = true;

	public List<GameObject> _pooledObjects;

	void Awake (){
		
		instance = this;

	}
		
	void Start () {
		_pooledAmount = 0;

		_pooledObjects = new List<GameObject> ();
		for (int i = 0; i < _pooledAmount; i++) {
			GameObject obj = (GameObject)Instantiate (_PooledObject);
			obj.SetActive (false);
			_pooledObjects.Add (obj);
		}
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
			return obj;
		}

		return null;
	}
}