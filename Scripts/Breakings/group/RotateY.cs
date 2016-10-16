using UnityEngine;
using System.Collections;

public class RotateY : MonoBehaviour {
	
	void Start () {
		//Destroy (this.gameObject,5.0f);
	}

	void Update () {
		if (Time.timeScale != 0) {
			this.transform.Rotate (0f, 8f, 0f);
		}
	}
}
