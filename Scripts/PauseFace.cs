using UnityEngine;
using System.Collections;

public class PauseFace : MonoBehaviour {

	void Awake(){

	}

	void Start () {
		this.guiTexture.pixelInset = new Rect (Screen.width*0.5f,Screen.height*0.5f,0.0f,0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale != 0) {
			Destroy(this.gameObject);
		}
	}
}
