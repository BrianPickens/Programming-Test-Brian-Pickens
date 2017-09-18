using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour {

	[SerializeField]
	private Collider _punchCollider;
	private Animator _myAnim;
	private Rigidbody _myRigidbody;
	private RobotFistScript _myFist;

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
	[SerializeField]
	private float _punchDelay;

	public AudioClip _punchClip;
	public AudioClip _jumpClip;
	public AudioClip _walkClip;
	public AudioClip[] _phraseClips;
	private int _phraseCounter;

	void Awake () {
		_myAnim = GetComponent<Animator> ();
		_myRigidbody = GetComponent<Rigidbody> ();
		if(_punchCollider == null){
			_punchCollider = GameObject.FindGameObjectWithTag ("RobotFist").GetComponent<Collider> ();
		}
		_myFist = _punchCollider.GetComponent<RobotFistScript>();
	}
		
	void Start () {
		_punchCollider.enabled = false;
		_facingRight = true;
		_directionModifier = 1;
	}

	void Update () {
		_horizontalMovement = Input.GetAxisRaw ("Horizontal");

		if (Input.GetKeyDown (KeyCode.UpArrow) && !_isJumping && !_isPunching) {
			_isJumping = true;
			Jump ();
		}

		if (Input.GetKeyDown (KeyCode.Space) && !_isPunching && !_isJumping) {
			_isPunching = true;
			Punch ();
		}

	}

	void FixedUpdate () {

		Move ();
		CheckDirection ();

	}

	private void Move () {

		if (_horizontalMovement != 0) {
			_myAnim.SetBool ("isWalking", true);
			//SoundManagerScript.instance.PlayWalkSounds (_walkClip, true);
		} else {
			_myAnim.SetBool ("isWalking", false);
			//SoundManagerScript.instance.PlayWalkSounds (_walkClip, false);
		}

	
		Vector3 movement = transform.forward * _horizontalMovement  * _directionModifier * _speed * Time.deltaTime;

		if (!_isJumping && !_isPunching) {
			_myRigidbody.MovePosition (_myRigidbody.position + movement);
		}

	}

	private void CheckDirection (){
		if (!_isJumping && !_isPunching) {
			if (_horizontalMovement > 0 && !_facingRight) {
				transform.eulerAngles = new Vector3 (0, 90, 0);
				_facingRight = true;
				_myFist._facingRight = true;
				_directionModifier = 1;
			} else if (_horizontalMovement < 0 && _facingRight) {
				transform.eulerAngles = new Vector3 (0, -90, 0);
				_facingRight = false;
				_myFist._facingRight = false;
				_directionModifier = -1;
			}
		}
	}

	private void Jump () {
		_myAnim.SetTrigger ("jump");
		SoundManagerScript.instance.PlaySfx (_jumpClip);
		StartCoroutine (WaitForAnim (_jumpTime));
	}

	private void Punch () {
		_phraseCounter++;
		if (_phraseCounter >= 5) {
			SoundManagerScript.instance.PlayPhrase (_phraseClips);
			_phraseCounter = 0;
		}
		_myAnim.SetTrigger ("punch");
		SoundManagerScript.instance.PlaySfx (_punchClip);
		StartCoroutine (DelayPunchCollider (_punchDelay));
		StartCoroutine (WaitForAnim (_punchTime));
	}

	IEnumerator WaitForAnim (float seconds){
		yield return new WaitForSeconds (seconds);
		if (_isJumping) {
			_isJumping = false;
		}

		if (_isPunching) {
			_isPunching = false;
			_punchCollider.enabled = false;
		}
	}

	//this enables the punch collider late, because the aniamtion swings the arm in front of the robot before the punch
	IEnumerator DelayPunchCollider (float seconds){
		yield return new WaitForSeconds (seconds);
		_punchCollider.enabled = true;
	}
}
