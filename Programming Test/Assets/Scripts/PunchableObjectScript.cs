using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Base class for all punchable objects
//handles adding force to the objects that are punched, and give them a direction to fly

public class PunchableObjectScript : MonoBehaviour {

	public AudioClip _hitClip;

	[SerializeField]
	protected GameObject _myChild;

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
		_myAnim = _myChild.GetComponent<Animator> ();

	}

	public virtual void OnTriggerEnter (Collider other){
		
		if (other.CompareTag("RobotFist")) {
			SoundManagerScript.instance.PlaySfx (_hitClip);
			int direction = other.GetComponent<RobotFistScript> ()._facingRight ? 1 : -1;
			other.enabled = false;
			Punched (direction);
		}

	}

	private void Punched (int forceDirection){
		
		_myCollider.enabled = false;
		_myRigidbody.isKinematic = false;
		_myTrailRenderer.enabled = true;
		_myAnim.SetBool ("isPunched", true);
		GameManagerScript.instance.HitParticles (gameObject.transform.position);
		CameraShakeScript.instance.ShakeCamera ();
		int _horizontalForce = Random.Range (_punchForceMin, _punchForceMax);
		int _verticalForce = Random.Range (_punchForceMin, _punchForceMax);
		_myRigidbody.AddForce (_horizontalForce * forceDirection, _verticalForce, 0, ForceMode.Impulse);

	}

}
