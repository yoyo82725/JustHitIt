using UnityEngine;
using System.Collections;

public class RoundBall : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject,5.0f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Time.timeScale != 0) {
			transform.Translate (0,-0.1f,0,Space.World);
			transform.Rotate (0, 0, 8);
		}
	}
}
