using UnityEngine;
using System.Collections;

public class SplitBall : MonoBehaviour {
	public GameObject boom;
	float timer;
	bool deleteNowBall=false;
	//風吹慣性
	bool windForceBool=false,windForceBool2=false;
	float windForceF;
	public AudioClip boomSE,minusHpSE;

	void Start () {

	}

	void OnTriggerEnter(Collider other){
		if(timer>0.1f){
			//棒子
			if((other.tag=="sticks" && UserScreen.hitting>0) || other.tag=="playerBall"){
				//+血
				int addHP = PlayingManager.addHP/2 + (int)((float)PlayingManager.addHP*0.5f * Random.Range(-0.1f,0.1f));
				PlayingManager.stageHp += addHP;
				PlayingManager.ShowPlus(addHP,this.transform.position);
				PlayingManager.brkCnt++;
				GameManager.playerExp += PlayingManager.getExp/2;
				GameManager.money += PlayingManager.getMoney/2;
				GameManager.breakCnt++;
				if(PlayingManager.sk11On && PlayingManager.mineHp < PlayingManager.mineHpL){
					PlayingManager.mineHp += PlayingManager.sk11Pow;
					if(PlayingManager.mineHp > PlayingManager.mineHpL){
						PlayingManager.mineHp = PlayingManager.mineHpL;
					}
				}

				AudioSource.PlayClipAtPoint(boomSE,Vector3.one+Vector3.one,0.2f);
				Destroy(this.gameObject);
				Instantiate(boom,transform.position,Quaternion.identity);
			}
			//刪除
			else if(other.tag=="deleteLine"){
				//-血
				int minusHP = PlayingManager.minusHP/2 + (int)((float)PlayingManager.minusHP*0.5f * Random.Range(-0.1f,0.1f));
				PlayingManager.mineHp -= minusHP;
				PlayingManager.ShowPlus(minusHP,this.transform.position,true);
				PlayingManager.lostCount++;

				AudioSource.PlayClipAtPoint(minusHpSE,Vector3.one,0.2f);
				Destroy(this.gameObject);
			}
		}
	}

	void FixedUpdate(){
		if(timer<=0.1f)
			timer += 0.02f;

		//左右移
		if(FireBall.LRmove){
			if(FireBall.moveFlag==0)
				transform.Translate(0.04f,0,0,Space.World);
			else
				transform.Translate(-0.04f,0,0,Space.World);
		}
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
		//清除
		if(FireBall.bossFireBall){
			//刪除不是BOSS的
			if(deleteNowBall){
				Destroy(this.gameObject);
				PlayingManager.outCount--;
				Instantiate(boom,transform.position,Quaternion.identity);
				deleteNowBall=false;
			}
			//rigidbody.velocity = transform.TransformDirection(Vector3.forward * 20);
		}else{
			deleteNowBall=true;
		}
	}
}
