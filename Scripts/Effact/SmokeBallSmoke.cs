using UnityEngine;
using System.Collections;

public class SmokeBallSmoke : MonoBehaviour {
	bool toLeft=false;
	float timer=0f;
	//風吹慣性
	bool windForceBool=false,windForceBool2=false;
	float windForceF=0.0f;
	// Use this for initialization
	void Start () {
		this.guiTexture.color = Color.clear;
		this.guiTexture.pixelInset = new Rect (Screen.width * 0.5f, Screen.height * 0.5f, 0f, 0f);
		if(Random.Range(1,3)==1)
		   toLeft=true;
		Destroy (this.gameObject, 7f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (toLeft) 
			this.transform.Translate(-0.0001f,0f,0f,Space.World);
		else
			this.transform.Translate(0.0001f,0f,0f,Space.World);
		timer += 0.02f;
		if (timer < 1)
			this.guiTexture.color = Color.Lerp(this.guiTexture.color,new Color(0.5f,0.5f,0.5f,0.5f),0.1f);
		else if(timer>6)
			this.guiTexture.color = Color.Lerp(this.guiTexture.color,Color.clear,0.1f);

		//風吹
		if (LRwind.isWind) {
			if(LRwind.toLwind){//左吹
				transform.Translate(-0.035f,0,0,Space.World);
				windForceF=-0.05f;
				windForceBool=true;
			}else{//右吹
				transform.Translate(0.035f,0,0,Space.World);
				windForceF=0.05f;
				windForceBool=true;
			}
		}
		if (windForceBool) { //風吹完的慣性
			if(!LRwind.isWind){
				windForceF = Mathf.Lerp(windForceF,0,0.01f);
				if(windForceF<=0.01f)
					windForceBool=false;
				transform.Translate(windForceF,0,0,Space.World);
			}
		}
		//風球吹
		if (WindBallWind.isWind) {
			if(WindBallWind.toLwind){//左吹
				transform.Translate(-WindBallWind.windFource,0,0,Space.World);
				windForceF=-WindBallWind.windFource;
				windForceBool2=true;
			}else{//右吹
				transform.Translate(WindBallWind.windFource,0,0,Space.World);
				windForceF=WindBallWind.windFource;
				windForceBool2=true;
			}
		}
		if (windForceBool2) { //風吹完的慣性
			if(!WindBallWind.isWind){
				windForceF = Mathf.Lerp(windForceF,0,0.01f);
				if(windForceF<=0.01f)
					windForceBool2=false;
				transform.Translate(windForceF,0,0,Space.World);
			}
		}
	}
}
