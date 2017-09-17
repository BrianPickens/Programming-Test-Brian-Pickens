using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeScript : MonoBehaviour {

	public static CameraShakeScript instance;

	private Transform _myTransform;

	[SerializeField]
	private float _shakeDuration;
	[SerializeField]
	private float _shakeAmount;
	[SerializeField]
	private float _decreaseAmount;

	private Vector3 _originalPosition;


	void Awake () {
		instance = this;

		_myTransform = GetComponent<Transform> ();
	}

	void OnEnable () {
		_originalPosition = _myTransform.localPosition;
	}


	void Update () {

		if (_shakeDuration > 0) {
			_myTransform.localPosition = _originalPosition + Random.insideUnitSphere * _shakeAmount;

			_shakeDuration -= Time.deltaTime * _decreaseAmount;
		} else {
			_shakeDuration = 0;
			_myTransform.localPosition = _originalPosition;
		}

	}

	public void ShakeCamera () {
		_shakeDuration = 0.1f;
	}
}
