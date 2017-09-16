using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchableObjectScript : MonoBehaviour {

	public AudioClip _hitClip;

	private Rigidbody _myRigidbody;
	private Collider _myCollider;
	private Transform _myTransform;

	private bool _isPunched;
	[SerializeField]
	private float _fallSpeed;


	[SerializeField]
	[Range(0,10)]
	private int _punchForceMax;
	[SerializeField]
	[Range(0,10)]
	private int _punchForceMin;

	void Awake () {
		_myRigidbody = GetComponent<Rigidbody> ();
		_myCollider = GetComponent<Collider> ();
		_myTransform = GetComponent<Transform> ();
	}

	void OnEnable () {
		Invoke ("Destroy", 10f);
		_myCollider.enabled = true;
		_myRigidbody.isKinematic = true;
		_isPunched = false;
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

	void OnTriggerEnter (Collider other){
		if (other.gameObject.tag == "RobotFist") {
			_isPunched = true;
			SoundManagerScript.instance.PlaySfx (_hitClip);
			int direction = other.GetComponent<RobotFistScript> ()._facingRight ? 1 : -1; //Mathf.RoundToInt(this.transform.position.x - other.transform.position.x);
			Punched (direction);
		}
	}

	private void Punched (int forceDirection){
		_myCollider.enabled = false;
		_myRigidbody.isKinematic = false;
		int _horizontalForce = Random.Range (_punchForceMin, _punchForceMax);
		int _verticalForce = Random.Range (_punchForceMin, _punchForceMax);
		_myRigidbody.AddForce (_horizontalForce * forceDirection, _verticalForce, 0, ForceMode.Impulse);
	}

	private void Destroy (){
		gameObject.SetActive (false);
	}

	void OnDisable (){
		
		CancelInvoke ();

	}
}
