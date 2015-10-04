using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {
	//A static field accessible by code anywhere
	static public bool goalMet = false;

	void OnTriggerEnter (Collider other) {
		// when the trigger is hit by something
		// check to see if it is a projectile
		if (other.gameObject.tag == "Projectile") {
			//If so, set goalMet to true
			Goal.goalMet = true;
			// Also set the alpha of the color to higher opacity
			Color c = GetComponent<Renderer>().material.color; //Changed for Unity 5
			c.a = 1;
			GetComponent<Renderer>().material.color = c; // Changed for UNity 5
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
