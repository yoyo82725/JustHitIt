using UnityEngine;
using System.Collections;

public class OutBallCube : MonoBehaviour {
	float oTimer=1f,moveX;
	bool deleteNowBall,isGlass,isMeteor;
	
	public GameObject[] ball;
	public GameObject boom;
	public AudioClip piSE,boomSE;

	void Start () {
		this.transform.localEulerAngles = new Vector3 (54.8f,4.1f,319f);

		if (this.name == "CubeGlass(Clone)") {
			isGlass = true;
			moveX = Random.Range (-6f, 6f);
		}else if(this.name=="CubeMeteor(Clone)"){
			isMeteor = true;
			moveX = Random.Range (-3.8f, 3.8f);
		}else{
			moveX = Random.Range (-7f, 7f);
		}
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

		this.transform.position = Vector3.Lerp(this.transform.position,new Vector3 (moveX,-1f,0f),0.1f);
		//發球
		if (oTimer <= 0f) {
			if(isGlass){
				Instantiate(ball[0],this.transform.position,new Quaternion(0,0,(Random.Range(-1.0f,1.0f)),(Random.Range(-1.0f,1.0f))));
				PlayingManager.outCount++;
			}else if(isMeteor){
				GameObject testV;
				testV = Instantiate(ball[Random.Range(0,ball.Length)],this.transform.position,new Quaternion(1f,0f,0f,0f))as GameObject;
				testV.rigidbody.velocity = testV.transform.TransformDirection(Vector3.down*20);
				testV = Instantiate(ball[Random.Range(0,ball.Length)],this.transform.position,new Quaternion(1f,0f,0f,0f))as GameObject;
				testV.rigidbody.velocity = testV.transform.TransformDirection(Vector3.down*20);
				PlayingManager.outCount+=2;
			}else{
				Instantiate(ball[Random.Range(0,ball.Length)],this.transform.position,Quaternion.identity);
				PlayingManager.outCount++;
			}

			AudioSource.PlayClipAtPoint (piSE,Vector3.one);
			oTimer = 1f;
		}else
			oTimer -= 0.02f;
	}

	void OnTriggerEnter(Collider other){
		//棒子
		if((other.tag=="sticks" && UserScreen.hitting>0) || other.tag=="playerBall"){
			//+血
			int addHP = PlayingManager.addHP + (int)((float)PlayingManager.addHP * Random.Range(-0.1f,0.1f));
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
			
			AudioSource.PlayClipAtPoint(boomSE,Vector3.one+Vector3.one,0.5f);
			Destroy(this.gameObject);
			Instantiate(boom,transform.position,Quaternion.identity);
		}
	}
}
