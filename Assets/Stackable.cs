using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stackable : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Stack(GameObject toStack) {
		Debug.Log ("Stacking");
		GetComponent<BoxCollider> ().isTrigger = false;
		toStack.transform.parent = transform;
		toStack.transform.position = transform.parent.position;
		Vector3 newPosition = new Vector3 (0f, 0.5f, 0f);
		toStack.transform.position = newPosition;

	}
}
