using UnityEngine;
using System.Collections;

public class BackBall : MonoBehaviour {
	bool deleteNowBall=false,playerBall=false;
	public GameObject boom,littleBoom;
	public AudioClip littleBoomSE,boomSE,minusHpSE;
	//風吹慣性
	bool windForceBool=false,windForceBool2=false;
	float windForceF=0.0f;

	void Start () {
	
	}

	void FixedUpdate(){
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
				Instantiate(littleBoom,transform.position,Quaternion.identity);
				deleteNowBall=false;
			}
			//rigidbody.velocity = transform.TransformDirection(Vector3.forward * 20);
		}else{
			deleteNowBall=true;
		}
		//出天花板
		if (playerBall) {
			if(this.transform.position.y>7.4f){
				Instantiate(littleBoom,this.transform.position,Quaternion.identity);
				AudioSource.PlayClipAtPoint(boomSE,Vector3.one+Vector3.one,0.5f);
				PlayingManager.brkCnt++;
				Destroy(this.gameObject);
			}
		}
	}

	void OnTriggerEnter(Collider other){
		//棒子
		if((other.tag=="sticks" && UserScreen.hitting>0) || other.tag=="playerBall"){
			this.transform.parent=null;
			this.rigidbody.useGravity=true;
			this.rigidbody.AddForce(0,2000,0);
			AudioSource.PlayClipAtPoint(littleBoomSE,Vector3.one+Vector3.one,0.5f);
			if(PlayingManager.sk11On && PlayingManager.mineHp < PlayingManager.mineHpL){
				PlayingManager.mineHp += PlayingManager.sk11Pow;
				if(PlayingManager.mineHp > PlayingManager.mineHpL){
					PlayingManager.mineHp = PlayingManager.mineHpL;
				}
			}
			playerBall=true;
			this.tag="playerBall";
		}
		//刪除
		else if(other.tag=="deleteLine"){
			//-血
			int minusHP = PlayingManager.minusHP + (int)((float)PlayingManager.minusHP * Random.Range(-0.1f,0.1f));
			PlayingManager.mineHp -= minusHP;
			PlayingManager.ShowPlus(minusHP,this.transform.position,true);
			PlayingManager.lostCount++;

			AudioSource.PlayClipAtPoint(minusHpSE,Vector3.one+Vector3.one,0.5f);
			Destroy(this.gameObject);
		}else if(playerBall){
			if(other.tag=="fireBall"){
				//打到球
				Instantiate(boom,this.transform.position,Quaternion.identity);
				AudioSource.PlayClipAtPoint(boomSE,Vector3.one+Vector3.one,0.5f);
				//加HP
				int addHP;
				if (GameManager.wearSk1 == 5 || GameManager.wearSk2 == 5 || GameManager.wearSk3 == 5) {
					//sk迴球特好
					addHP = PlayingManager.addHP + GameManager.skLv[4]*20 + (int)((float)PlayingManager.addHP * Random.Range(-0.1f,0.1f));
				}else{
					addHP = PlayingManager.addHP + (int)((float)PlayingManager.addHP * Random.Range(-0.1f,0.1f));
				}
				PlayingManager.stageHp += addHP;
				PlayingManager.ShowPlus(addHP,this.transform.position);
				GameManager.playerExp += PlayingManager.getExp;
				GameManager.money += PlayingManager.getMoney;
				GameManager.breakCnt++;

				Destroy(this.gameObject);
			}else if(other.tag=="StageBoss"){
				//打到BOSS
				other.transform.Translate(0,2,0,Space.World);
				//加HP
				int addHP;
				if (GameManager.wearSk1 == 5 || GameManager.wearSk2 == 5 || GameManager.wearSk3 == 5) {
					//sk迴球特好
					addHP = PlayingManager.addHP*5 + GameManager.skLv[4]*20 + (int)((float)PlayingManager.addHP*5f * Random.Range(-0.1f,0.1f));
				}else{
					addHP = PlayingManager.addHP*5 + (int)((float)PlayingManager.addHP*5f * Random.Range(-0.1f,0.1f));
				}
				PlayingManager.stageHp += addHP;
				PlayingManager.ShowPlus(addHP,this.transform.position);
				GameManager.playerExp += PlayingManager.getExp;
				GameManager.money += PlayingManager.getMoney;
				GameManager.breakCnt++;

				AudioSource.PlayClipAtPoint(boomSE,Vector3.one+Vector3.one,0.5f);
				Instantiate(boom,this.transform.position,Quaternion.identity);
				Destroy(this.gameObject);
			}
		}
	}
}
