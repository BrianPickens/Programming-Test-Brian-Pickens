using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchableObjectScript : MonoBehaviour {

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

	/*[SerializeField]
	[Range(0,10)]
	private int _punchForceVertical;
	[SerializeField]
	[Range(0,10)]
	private int _punchForceHorizontal;
	*/

	// Use this for initialization
	void Awake() {
		_myRigidbody = GetComponent<Rigidbody> ();
		_myCollider = GetComponent<Collider> ();
		_myTransform = GetComponent<Transform> ();
	}

	void Start () {
		_isPunched = false;
		//_fallSpeed = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (!_isPunched) {
			Move ();
		}

	}

	private void Move(){
		_myTransform.Translate (Vector3.down * _fallSpeed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "RobotFist") {
			_isPunched = true;
			int direction = Mathf.RoundToInt(this.transform.position.x - other.transform.position.x);
			Punched (direction);
		}
	}

	private void Punched(int forceDirection){
		_myCollider.enabled = false;
		_myRigidbody.isKinematic = false;
		int _horizontalForce = Random.Range (_punchForceMin, _punchForceMax);
		int _verticalForce = Random.Range (_punchForceMin, _punchForceMax);
		_myRigidbody.AddForce (_horizontalForce * forceDirection, _verticalForce, 0, ForceMode.Impulse);
	}

	private void Destroy(){
		//need to destroy obejct after curtain time, or use a object pool
	}
}
