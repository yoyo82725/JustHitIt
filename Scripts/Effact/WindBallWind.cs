using UnityEngine;
using System.Collections;

public class WindBallWind : MonoBehaviour {
	public static bool toLwind=false,isWind=false;
	public static float windFource=0f;
	float timer=0f;
	// Use this for initialization
	void Start () {
		if((Random.Range(0f,10f))>5f){
			isWind=true;
			toLwind=true;
			this.transform.position = new Vector3(12f,0f,-7f);
			this.particleEmitter.localVelocity = new Vector3(-60f,0f,0f);
			windFource+=0.02f;
		}else{
			isWind=true;
			toLwind=false;
			this.transform.position = new Vector3(-12f,0f,-7f);
			this.particleEmitter.localVelocity = new Vector3(60f,0f,0f);
			windFource+=0.02f;
		}
		Destroy (this.gameObject, 5);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (timer > 3f){
			if(this.particleEmitter.emit){
				windFource -= 0.02f;
				if(windFource<0.01f)
					isWind=false;
				this.particleEmitter.emit = false;
			}
		}else
			timer += 0.02f;
	}
}
