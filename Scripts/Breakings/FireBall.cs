using UnityEngine;
using System.Collections;

public class FireBall : MonoBehaviour {
	public GameObject boom,splitBall,windBallWind,smokeBallSmoke,moveSpeedUpBuff,stickBigBuff;
	public static bool bossFireBall=false,LRmove=false; //,downPow=false,reflex=false,topReflex=false,split=false
	public static int moveFlag;
	int ballCo;
	bool deleteNowBall=false;
	//風吹慣性
	bool windForceBool=false,windForceBool2=false;
	float windForceF;
	//se
	public AudioClip boomSE,buffSE,windSE,minusHpSE;

	void Awake(){

	}

	void Start () {
		if(this.name=="GlassBall" || this.name=="TopGlassBall"){
			ballCo = 1;
		}else if(this.name=="CellBall" || this.name=="CellBall(Clone)"){
			ballCo = 2;
		}else if(this.name=="WindBall" || this.name=="WindBall(Clone)"){
			ballCo = 3;
		}else if(this.name=="SmokeBall" || this.name=="SmokeBall(Clone)"){
			ballCo = 4;
		}else if(this.name=="AcceBall" || this.name=="AcceBall(Clone)"){
			ballCo = 5;
		}else if(this.name=="StickBigBall" || this.name=="StickBigBall(Clone)"){
			ballCo = 6;
		}else if (PlayingManager.sk4On) {
			//sk白球特好
			if(this.name=="WhiteBall" || this.name=="WhiteBall(Clone)")
				ballCo = 7;
		}
		/*
		if(ballCo == 1){
			Destroy(this.transform.parent.gameObject,15f);
		}else
			Destroy(this.gameObject,15f);
		*/
	}

	void OnTriggerEnter(Collider other){
		//棒子
		if((other.tag=="sticks" && UserScreen.hitting>0) || other.tag=="playerBall"){
			//+血
			int addHP;
			if(ballCo == 0){
				addHP = PlayingManager.addHP + (int)((float)PlayingManager.addHP * Random.Range(-0.1f,0.1f));
			}else if(ballCo == 1){
				addHP = (int)((float)PlayingManager.addHP*1.3f) + (int)((float)PlayingManager.addHP*1.3f * Random.Range(-0.1f,0.1f));
			}else if(ballCo == 7){
				addHP = (int)(PlayingManager.sk4Pow * Random.Range(-0.1f,0.1f));
			}else{
				addHP = PlayingManager.addHP + (int)((float)PlayingManager.addHP * Random.Range(-0.1f,0.1f));
				//分裂
				if(ballCo == 2){
					GameObject testV;
					//int amount=Random.Range(2,5);
					for(int i=0;i<4;i++){
						testV = Instantiate(splitBall,transform.position,Quaternion.identity) as GameObject;
						testV.rigidbody.AddForce((Random.Range(-80.0f,80.0f)),(Random.Range(400.0f,600.0f)),0);
						PlayingManager.outCount++;
					}
				}
				//吹風
				else if(ballCo == 3){
					Instantiate(windBallWind,Vector3.zero,Quaternion.identity);
					AudioSource.PlayClipAtPoint(windSE,Vector3.forward);
				}
				//煙霧
				else if(ballCo == 4){
					Instantiate(smokeBallSmoke,new Vector3(this.transform.position.x*0.04545f,this.transform.position.y*0.07142f,-7.0f),Quaternion.identity);
				}
				//移動加速BUFF
				else if(ballCo == 5){
					AudioSource.PlayClipAtPoint(buffSE,Vector3.zero);
					if(MoveSpeedUpBuff.isShow)
						MoveSpeedUpBuff.timer=0f;
					else{
						if(StickBigBuff.isShow)
							Instantiate(moveSpeedUpBuff,new Vector3(-9.67f,5f,0f),Quaternion.identity);
						else
							Instantiate(moveSpeedUpBuff,new Vector3(-10.37f,5f,0f),Quaternion.identity);
					}
				}
				//大棒BUFF
				else if(ballCo == 6){
					AudioSource.PlayClipAtPoint(buffSE,Vector3.zero);
					if(StickBigBuff.isShow)
						StickBigBuff.timer=0f;
					else{
						if(MoveSpeedUpBuff.isShow)
							Instantiate(stickBigBuff,new Vector3(-9.67f,5f,0f),Quaternion.identity);
						else
							Instantiate(stickBigBuff,new Vector3(-10.37f,5f,0f),Quaternion.identity);
					}
				}
			}
			PlayingManager.stageHp += addHP;
			PlayingManager.ShowPlus(addHP,this.transform.position);
			PlayingManager.brkCnt++;
			GameManager.playerExp += PlayingManager.getExp;
			GameManager.money += PlayingManager.getMoney;
			GameManager.breakCnt++;
			if(PlayingManager.sk11On && PlayingManager.mineHp < PlayingManager.mineHpL){
				PlayingManager.mineHp += PlayingManager.sk11Pow;
				if(PlayingManager.mineHp > PlayingManager.mineHpL){
					PlayingManager.mineHp = PlayingManager.mineHpL;
				}
			}

			Instantiate(boom,transform.position,Quaternion.identity);
			AudioSource.PlayClipAtPoint(boomSE,Vector3.one,0.5f);
			//玻璃球
			if(ballCo == 1){
				Destroy(this.transform.parent.gameObject);
			}else
				Destroy(this.gameObject);
		}
		//刪除
		else if(other.tag=="deleteLine"){
			//-血
			int minusHP = PlayingManager.minusHP + (int)((float)PlayingManager.minusHP * Random.Range(-0.1f,0.1f));
			PlayingManager.mineHp -= minusHP;
			PlayingManager.ShowPlus(minusHP,this.transform.position,true);
			PlayingManager.lostCount++;

			AudioSource.PlayClipAtPoint(minusHpSE,Vector3.one,0.5f);
			//玻璃球
			if(ballCo == 1){
				Destroy(this.transform.parent.gameObject);
			}else
				Destroy(this.gameObject);
		}
	}

	void FixedUpdate(){
		//左右移
		if(LRmove){
			if(moveFlag==0)
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
		if(bossFireBall){
			//刪除不是BOSS的
			if(deleteNowBall){
				if(ballCo == 1){
					Destroy(this.transform.parent.gameObject);
				}else
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
