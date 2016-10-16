using UnityEngine;
using System.Collections;

public class HardBall : MonoBehaviour {
	public GameObject boom,littleBoom;
	int hitCount;
	float timer;
	bool deleteNowBall=false,havP;
	//風吹慣性
	bool windForceBool=false,windForceBool2=false;
	float windForceF=0.0f;
	public AudioClip littleBoomSE,boomSE,minusHpSE;

	void Start () {
		if (this.transform.parent != null)
			havP = true;
	}

	void OnTriggerEnter(Collider other){
		//棒子
		if((other.tag=="sticks" && UserScreen.hitting>0) || other.tag=="playerBall"){
			if(hitCount==0){
				AudioSource.PlayClipAtPoint(littleBoomSE,Vector3.one,0.5f);
				this.transform.parent = null;
				this.rigidbody.useGravity = true;
				hitCount++;
				if(havP)
					this.rigidbody.AddForce(0f,700f,0f);
				else
					this.rigidbody.AddForce(0f,1500f,0f);
				Instantiate(littleBoom,new Vector3(transform.position.x,transform.position.y,0f),Quaternion.identity);
				this.renderer.materials[0].color = Color.gray;
				this.renderer.materials[1].color = Color.gray;
				timer=0.2f;
			}else if(timer<=0){
				//+血
				int addHP = PlayingManager.addHP*2 + (int)((float)PlayingManager.addHP*2f * Random.Range(-0.1f,0.1f));
				PlayingManager.stageHp += addHP;
				PlayingManager.ShowPlus(addHP,this.transform.position);
				PlayingManager.brkCnt++;
				GameManager.playerExp += PlayingManager.getExp*2;
				GameManager.money += PlayingManager.getMoney*2;
				GameManager.breakCnt++;
				if(PlayingManager.sk11On && PlayingManager.mineHp < PlayingManager.mineHpL){
					PlayingManager.mineHp += PlayingManager.sk11Pow;
					if(PlayingManager.mineHp > PlayingManager.mineHpL){
						PlayingManager.mineHp = PlayingManager.mineHpL;
					}
				}

				AudioSource.PlayClipAtPoint(boomSE,Vector3.one,0.5f);
				Destroy(this.gameObject);
				Instantiate(boom,new Vector3(transform.position.x,transform.position.y,0f),Quaternion.identity);
			}
		}
		//刪除
		else if(other.tag=="deleteLine"){
			//-血
			int minusHP = PlayingManager.minusHP + (int)((float)PlayingManager.minusHP * Random.Range(-0.1f,0.1f));
			PlayingManager.mineHp -= minusHP;
			PlayingManager.ShowPlus(minusHP,this.transform.position,true);
			PlayingManager.lostCount++;

			AudioSource.PlayClipAtPoint(minusHpSE,Vector3.one,0.5f);
			Destroy(this.gameObject);
		}
	}
	void FixedUpdate(){
		//左右移
		if(FireBall.LRmove){
			if(FireBall.moveFlag==0)
				transform.Translate(0.04f,0,0,Space.World);
			else
				transform.Translate(-0.04f,0,0,Space.World);
		}
		if (timer > 0)
			timer -= 0.02f;
		
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
