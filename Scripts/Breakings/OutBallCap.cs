using UnityEngine;
using System.Collections;

public class OutBallCap : MonoBehaviour {
	float oTimer=0.5f;
	bool deleteNowBall;
	
	public GameObject[] ball;
	public GameObject boom;
	public AudioClip minusHpSE,piSE,boomSE;

	void Start () {
		this.rigidbody.AddForce (Random.Range(-150f,150f),Random.Range(0f,300f),0);
	}

	void FixedUpdate () {
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

		this.transform.Rotate (0, 0, 15f);
		//發球
		if (oTimer <= 0f) {
			Instantiate(ball[Random.Range(0,ball.Length)],this.transform.position,Quaternion.identity);
			AudioSource.PlayClipAtPoint (piSE,Vector3.one);
			PlayingManager.outCount++;
			oTimer = 0.5f;
		}else
			oTimer -= 0.02f;
	}

	void OnTriggerEnter(Collider other){
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
			
			AudioSource.PlayClipAtPoint(boomSE,Vector3.one+Vector3.one,0.5f);
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
			
			AudioSource.PlayClipAtPoint(minusHpSE,Vector3.one,0.5f);
			//玻璃球
			if(this.name=="GlassBall" || this.name=="TopGlassBall"){
				Destroy(this.transform.parent.gameObject);
			}else
				Destroy(this.gameObject);
		}
	}
}
