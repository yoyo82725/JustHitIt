using UnityEngine;
using System.Collections;

public class MoveSpeedUpBuff : MonoBehaviour {
	public static float timer=0;
	public static bool isShow=false;
	float alpha=1.0f,timeLine;
	bool changeFlag=true;
	SpriteRenderer sp;
	Transform lToe;
	// Use this for initialization
	void Start () {
		timeLine = 5f;
		if (GameManager.wearSk1 == 8 || GameManager.wearSk2 == 8 || GameManager.wearSk3 == 8) {
			//sk呼吸控制
			timeLine += (float)GameManager.skLv[7]*0.1f;
			if(timeLine > 15.0f)
				timeLine = 15.0f;
		}
		isShow=true;
		UserScreen.speed = (UserScreen.iniSpeed*2f > 1.2f)?1.2f:UserScreen.iniSpeed*2f;
		sp = this.GetComponent<SpriteRenderer>();
		if(UserScreen.iniSpeed <= 0.799f){
			lToe = UserScreen.lToe;
			lToe.GetComponent<TrailRenderer>().enabled=true;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//功能
		if(timer>timeLine){
			UserScreen.speed = UserScreen.iniSpeed;
			if(UserScreen.iniSpeed <= 0.799f){
				lToe.GetComponent<TrailRenderer>().enabled=false;
			}
			timer=0f;
			isShow=false;
			Destroy(this.gameObject);
		}else if(timer>timeLine-2f){
			//閃爍
			if(changeFlag){
				alpha-=0.1f;
				if(alpha<0.1f)
					changeFlag = false;
			}else{
				alpha+=0.1f;
				if(alpha>0.9f)
					changeFlag = true;
			}
			//sp.color = new Color(sp.color.r,sp.color.g,sp.color.b,alpha);
			sp.color = new Color(1f,1f,1f,alpha);
			timer += 0.02f;
		}else{
			if(alpha<0.99f){
				alpha=1.0f;
				sp.color = new Color(1f,1f,1f,1f);
			}
			timer += 0.02f;
		}
	}
}
