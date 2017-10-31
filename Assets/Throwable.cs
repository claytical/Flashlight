using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : MonoBehaviour {
	public bool readyToThrow;
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
			if (Input.GetKeyDown (KeyCode.LeftControl)) {
				GetComponentInParent<BackPack> ().itemInHands = false;
				transform.parent = null;
				GetComponent<Rigidbody> ().isKinematic = false;
				//one time hit
				GetComponent<Rigidbody> ().AddForce (transform.forward * 25f, ForceMode.Impulse);

			}
			if (Input.GetKey (KeyCode.LeftControl)) {
				//make the force continuous
				//				GetComponent<Rigidbody> ().AddForce (transform.forward * 25f, ForceMode.Acceleration);
			}
			if (Input.GetKeyUp (KeyCode.LeftControl)) {
				Invoke ("ResetTrigger", 1);
			}
		}
			
	}
}
