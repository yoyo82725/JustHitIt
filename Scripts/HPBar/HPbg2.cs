using UnityEngine;
using System.Collections;

public class HPbg2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//if (guiTexture.color != this.transform.parent.guiTexture.color) {
			guiTexture.color = this.transform.parent.guiTexture.color;
		//}
	}
}
