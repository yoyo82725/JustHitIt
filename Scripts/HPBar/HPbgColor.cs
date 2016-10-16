using UnityEngine;
using System.Collections;

public class HPbgColor : MonoBehaviour {
	public PlayingManager hpColor;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		guiTexture.color = hpColor.bgColor;
	}
}
