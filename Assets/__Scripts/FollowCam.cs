using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour {
	static public FollowCam S; // a FollowCam Singleton
	//fields set in the UNity Inspector pane
	public float easing = 0.05f; // move the camera about 5% of the way from its current location to the location of poi every frame
	public Vector2 minXY;
	public bool __________________________________;
	//fields set dinamically
	public GameObject poi; //The point of interest
	public float camZ; //The desired Z  pos of the camera

	void Awake () {
		S = this;
		camZ = this.transform.position.z;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {	// changed from Update so that it happens every frame of physics simulation
		Vector3 destination;
		//If there is no poi, return to P:[0,0,0]
		if (poi == null) {
			destination = Vector3.zero;
		} else {
			//Get the position of the poi
			destination = poi.transform.position;
			//If poi is a Projectile, check to see if it is at rest
			if (poi.tag == "Projectile") {
				//If it is sleeping which means it is not moving
				if (poi.GetComponent<Rigidbody>().IsSleeping()) { // Modified for Unit 5
					//return to default view
					poi = null;
					// in the next update
					return;
				}
			}
		}
		//if there is only one line following an if, it doe snot need braces
		//if (poi == null) return; // return is there is no poi
		//Get the position of the poi
		//Vector3 destination = poi.transform.position;

		// Limit the X & Y to minimum values
		destination.x = Mathf.Max (minXY.x, destination.x);
		destination.y = Mathf.Max (minXY.y, destination.y);
		//Interpolate from the current camera position towad destination
		destination = Vector3.Lerp (transform.position, destination, easing);
		//Retain a destination.z of camZ
		destination.z = camZ;
		//Set the camera to the destination
		transform.position = destination;
		//Set the orthographic size of the camera to keep ground in view
		this.GetComponent<Camera>().orthographicSize = destination.y + 10; // Unity 5 adjustment made
	}
}
