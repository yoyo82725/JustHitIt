using UnityEngine;
using System.Collections;

public class WorldYMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Time.timeScale != 0) {
			this.transform.Translate (0, -0.2f, 0, Space.World);
		}
	}
}
