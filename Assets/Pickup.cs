using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			if (other.GetComponentInChildren<Inventory> ().list.Count == 0) {
				GetComponent<Rigidbody> ().isKinematic = true;
				transform.parent = other.GetComponentInChildren<Inventory> ().transform;
				transform.position = transform.parent.position;
				transform.rotation = other.GetComponentInChildren<Inventory> ().transform.rotation;
				GetComponent<BoxCollider> ().isTrigger = false;
				if (GetComponent<Throwable> () != null) {
					GetComponent<Throwable> ().SetThrowable (true);
				}
				other.GetComponentInChildren<Inventory> ().list.Add (gameObject);
			} else {
				if(GetComponent<Stackable>() != null) {
					List<GameObject> gos = other.GetComponentInChildren<Inventory> ().list;

					if (gos [0].GetComponent<Stackable> () != null) {
						GetComponent<Stackable> ().Stack(gos[0]);
					}
					gos.RemoveAt (0);
				}
			}

		}
	}
}
