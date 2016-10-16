using UnityEngine;
using System.Collections;

public class SelfYMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject,5.0f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		this.transform.Translate (0, -0.2f, 0, Space.Self);
	}
}
