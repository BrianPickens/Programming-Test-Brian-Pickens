using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour {

	private Animator _myAnim;
	private Rigidbody _myRigidbody;

	private bool _facingRight;
	private float _horizontalMovement;
	private int _directionModifier;

	[SerializeField]
	private float _punchTime;
	[SerializeField]
	private float _jumpTime;

	[SerializeField]
	private float _speed;
	private bool _isJumping;
	private bool _isPunching;

	void Awake() {
		_myAnim = GetComponent<Animator> ();
		_myRigidbody = GetComponent<Rigidbody> ();
	}

	// Use this for initialization
	void Start () {
		_facingRight = true;
		_directionModifier = 1;
	}
	
	// Update is called once per frame
	void Update () {
		_horizontalMovement = Input.GetAxis ("ControllerHorizontal");

		if (Input.GetButtonDown ("A") && !_isJumping && !_isPunching) {
			_isJumping = true;
			Jump ();
		}

		if (Input.GetButtonDown ("X") && !_isPunching && !_isJumping) {
			_isPunching = true;
			Punch ();
		}

	}

	void FixedUpdate() {

		Move ();
		CheckDirection ();
	}

	private void Move() {

		if (_horizontalMovement != 0) {
			_myAnim.SetBool ("isWalking", true);
		} else {
			_myAnim.SetBool ("isWalking", false);
		}

	
		Vector3 movement = transform.forward * _horizontalMovement  * _directionModifier * _speed * Time.deltaTime;

		if (!_isJumping && !_isPunching) {
			_myRigidbody.MovePosition (_myRigidbody.position + movement);
		}

	}

	private void CheckDirection (){
		if (_horizontalMovement > 0 && !_facingRight) {

			transform.eulerAngles = new Vector3 (0, 90, 0);
			_facingRight = true;
			_directionModifier = 1;
		} else if (_horizontalMovement < 0 && _facingRight) {
			transform.eulerAngles = new Vector3 (0, -90, 0);
			_facingRight = false;
			_directionModifier = -1;
		}
	}

	private void Jump() {
		_myAnim.SetTrigger ("jump");
		StartCoroutine (WaitForAnim (_jumpTime));
	}

	private void Punch() {
		_myAnim.SetTrigger ("punch");
		StartCoroutine (WaitForAnim (_punchTime));
	}

	IEnumerator WaitForAnim(float seconds){
		yield return new WaitForSeconds (seconds);
		if (_isJumping) {
			_isJumping = false;
		}

		if (_isPunching) {
			_isPunching = false;
		}
	}
}
