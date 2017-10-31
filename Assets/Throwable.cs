using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : MonoBehaviour {
	private bool readyToThrow;
	// Use this for initialization
	void Start () {
		readyToThrow = false;
	}

	public void SetThrowable(bool canThrow) {
		readyToThrow = canThrow;
	}

	void ResetTrigger() {
		GetComponent<BoxCollider> ().isTrigger = true;
		readyToThrow = false;
	}

	// Update is called once per frame
	void Update () {
		if (readyToThrow) {
			if (Input.GetKey (KeyCode.LeftControl)) {
				transform.parent = null;
				GetComponent<Rigidbody> ().isKinematic = false;
				GetComponent<Rigidbody> ().AddForce (transform.forward * 50f);
				Invoke ("ResetTrigger", 1);
			}
		}
			
	}
}
