using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Located on the Robots fist
//Necessary to deliver information to punched objects and tell them which direction they should fly

public class RobotFistScript : MonoBehaviour {

	public bool _facingRight{ get; set; }

	void Start(){
		
		_facingRight = true;

	}
		
}
