using UnityEngine;
using System.Collections;

public class RotateXYZ : MonoBehaviour {
	
	void Start () {
	
	}

	void Update () {
		if (Time.timeScale != 0) {
			this.transform.Rotate (8, 8, 8);
		}
	}
}
