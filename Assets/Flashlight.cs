using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour {
	public Light light;
	private float energy;
	// Use this for initialization
	void Start () {
		energy = 1f;
	}
	
	// Update is called once per frame
	void Update () {
		energy -= .001f;
		if (energy <= 0) {
			energy = 0;
		}
		light.intensity = energy;
	}

	public void AddEnergy() {
		energy += .5f;
	}
}
