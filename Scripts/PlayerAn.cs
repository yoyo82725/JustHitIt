using UnityEngine;
using System.Collections;

public class PlayerAn : MonoBehaviour {
	public static int anName=0;
	// Use this for initialization
	void Start () {
		//animation.wrapMode = WrapMode.Loop;
		/*
		animation["stand"].layer = -1;
		animation["run"].layer = -1;
		animation["step"].layer = -1;
		*/
		//animation.Stop();
	}
	
	// Update is called once per frame
	void Update () {
		if(anName==0){//站
			this.animation.CrossFade("stand",0.1f);
		}else if(anName==1){//跑步
			this.animation.CrossFade("run",0.2f);
		}else if(anName==2){//右打
			this.animation.Play("rightAtk",PlayMode.StopSameLayer);
		}else if(anName==3){//左打
			this.animation.Play("leftAtk",PlayMode.StopSameLayer);
		}else if(anName==4){//踏步
			this.animation.CrossFade("step",0.2f);
		}
	}
}
