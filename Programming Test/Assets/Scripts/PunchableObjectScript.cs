using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchableObjectScript : MonoBehaviour {

	public AudioClip _hitClip;

	protected Rigidbody _myRigidbody;
	protected Collider _myCollider;
	protected Transform _myTransform;
	protected TrailRenderer _myTrailRenderer;
	protected Animator _myAnim;

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
		_myTrailRenderer = GetComponent<TrailRenderer> ();
		_myAnim = GetComponent<Animator> ();
	}

	public virtual void OnTriggerEnter (Collider other){
		if (other.gameObject.tag == "RobotFist") {
			SoundManagerScript.instance.PlaySfx (_hitClip);
			int direction = other.GetComponent<RobotFistScript> ()._facingRight ? 1 : -1;
			Punched (direction);
		}
	}

	private void Punched (int forceDirection){
		_myCollider.enabled = false;
		_myRigidbody.isKinematic = false;
		_myTrailRenderer.enabled = true;
		_myAnim.SetBool ("isPunched", true);
		int _horizontalForce = Random.Range (_punchForceMin, _punchForceMax);
		int _verticalForce = Random.Range (_punchForceMin, _punchForceMax);
		_myRigidbody.AddForce (_horizontalForce * forceDirection, _verticalForce, 0, ForceMode.Impulse);
	}

}
