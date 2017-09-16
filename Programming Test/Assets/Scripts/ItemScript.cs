using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : PunchableObjectScript {

	private bool _isPunched;

	[SerializeField]
	private float _fallSpeed;

	[SerializeField]
	private int _itemIdentity;

	void OnEnable () {
		Invoke ("Destroy", 10f);
		_myCollider.enabled = true;
		_myRigidbody.isKinematic = true;
		_isPunched = false;
		_itemIdentity = GameManagerScript.instance.GetIdentity ();
		_fallSpeed = GameManagerScript.instance._ItemSpeed;
	}

	void Start () {
		AssignIdentity (_itemIdentity);
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
		_itemIdentity = identity;
		if (identity == 0) {
			gameObject.tag = "Vegetable";
			Debug.Log ("vegetable");
		}

		if (identity == 1) {
			gameObject.tag = "Meat";
			Debug.Log ("meat");
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
		gameObject.SetActive (false);
	}

	void OnDisable (){

		CancelInvoke ();
	
	}
}
