using UnityEngine;
using System.Collections;

public class RotateAroundPa : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Time.timeScale != 0) {
			this.transform.RotateAround (this.transform.parent.position, Vector3.up, 0.1f);
			this.transform.Translate (0, 0.1f, 0);
		}
	}
}
