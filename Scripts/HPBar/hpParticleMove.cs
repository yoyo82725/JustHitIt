using UnityEngine;
using System.Collections;

public class hpParticleMove : MonoBehaviour {
	private float nowW;
	public PlayingManager hpColor;
	float Rate;

	// Use this for initialization
	void Start () {
		Rate = Screen.width*0.04694f;
		Rate = 1/Rate;
		//transform.localPosition = new Vector3(-11.0f,4.94742f,-3.0f);
	}
	
	// Update is called once per frame
	void Update () {
		if(nowW != hpColor.W){
			nowW = hpColor.W;
			//float x = nowW/31.16279f+10.3f;
			this.transform.localPosition = new Vector3(nowW*Rate+10.3f,4.94742f,-3.0f);
		}
	}
}
