using UnityEngine;
using System.Collections;

public class ShellDect : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 4);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Time.timeScale!=0)
			this.transform.Translate (0, 0, 0.2f, Space.Self);
	}
}
