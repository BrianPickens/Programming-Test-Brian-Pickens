using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : PunchableObjectScript {

	public GameObject[] _Vegetable;
	public GameObject[] _Meat;
	public GameObject _Fork;

	private bool _isPunched;

	[SerializeField]
	private float _fallSpeed;

	[SerializeField]
	private int _itemIdentity;

	void OnEnable () {
		Invoke ("Destroy", 10f);
		_myAnim.SetBool ("isPunched", false);
		_myTrailRenderer.enabled = false;
		_myCollider.enabled = true;
		_myRigidbody.isKinematic = true;
		_isPunched = false;
		_itemIdentity = GameManagerScript.instance.GetIdentity ();
		_fallSpeed = GameManagerScript.instance._ItemSpeed;
		AssignIdentity (_itemIdentity);
	}

	void Start () {

	}

	void FixedUpdate () {

		if (!_isPunched) {
			Move ();
		}
	}

	private void Move (){
		_myTransform.Translate (Vector3.down * _fallSpeed * Time.deltaTime);
	}

	private void AssignIdentity (int identity) {

		for (int i = 0; i < _Vegetable.Length; i++) {
			_Vegetable [i].SetActive (false);
		}

		for (int i = 0; i < _Meat.Length; i++) {
			_Meat [i].SetActive (false);
		}
		_Fork.SetActive (false);

		_itemIdentity = identity;
		if (identity == 0) {
			gameObject.tag = "Vegetable";
			int randomIndex = Random.Range (0, _Vegetable.Length);
			_Vegetable[randomIndex].SetActive (true);
		}

		if (identity == 1) {
			gameObject.tag = "Meat";
			int randomIndex = Random.Range (0, _Meat.Length);
			_Meat[randomIndex].SetActive (true);
		}

		if (identity == 2) {
			gameObject.tag = "Fork";
			_Fork.SetActive (true);
		}

	}

	public override void OnTriggerEnter(Collider other){
		base.OnTriggerEnter (other);

		if (other.gameObject.tag == "RobotFist") {
			if (_itemIdentity == 1 || _itemIdentity == 2) {
				GameManagerScript.instance.AddPoints (_itemIdentity);
			}
			_isPunched = true;
		}
	}

	private void Destroy (){
		_myTrailRenderer.enabled = false;
		gameObject.SetActive (false);
	}

	void OnDisable (){

		CancelInvoke ();
	
	}
}
