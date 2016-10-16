using UnityEngine;
using System.Collections;

public class S1Square : MonoBehaviour {
	bool blinkRed=false,worked=true;
	Transform player;
	//拍數,不連發
	int pi=0,tmpPi=0;
	float tempoCD=0f,tempoCDini=0.42857f; //60/140
	public GameObject squareBall;
	public GameObject[] fireBall;
	public GameObject boom;
	//stage
	int stageStep=0,changeFlag=0,changeFlag3=0;
	float changeFlag2=0.12f;
	float moveX,moveY,outZ=0f;
	//複製
	public static bool cpy = false;
	public AudioClip readyBoom,hitSE,piSE;
	float hitCD = 0f;
	//對話框
	int labFoSi = Mathf.RoundToInt(Screen.width*0.02682f); //18
	int winFoSi = Mathf.RoundToInt(Screen.width*0.02682f); //18
	Rect mesRect = new Rect(0f,0f,Screen.width*0.2f,Screen.height*0.23f);
	Rect mesLabRect = new Rect(Screen.width*0.005f,Screen.height*0.05f,Screen.width*0.19f,Screen.height*0.2f);
	float mesPoRate = Screen.width*0.04545f;
	float mesHiPoRate = Screen.height*0.02f;
	bool showMes;
	string mesText;
	float mesTimer;
	
	void Start () {
		player = UserScreen.player;
		FireBall.bossFireBall=false;
		if(!cpy){
			PlayingManager.bossCo = 3; //編號3方塊
			//對話
			mesTimer = 5f;
			if(!GameManager.s1BSee [2]){
				mesText = "這區域，由我們收下了！";
				GameManager.s1BSee [2] = true;
			}else{
				int ran = Random.Range(1,4);
				if(ran == 1)
					mesText = "再來試試吧！";
				else if(ran == 2)
					mesText = "你終於來了！ 我要好好找你算帳！";
				else
					mesText = "你擋住我了！ 撞死不負責哦！";
			}
			showMes = true;
		}
		//iniColor = this.transform.GetChild (0).GetChild (1).renderer.material.color;
	}
	
	void FixedUpdate () {
		if(worked){
			//計算拍數
			if(tempoCD <= 0){
				pi++;
				tempoCD = tempoCDini;
			}else{
				tempoCD -= 0.02f;
			}
			//**********行為*******************
			//登場
			//1~3拍 移至位置看人
			if(stageStep==0){
				//位移
				transform.position = Vector3.Lerp(transform.position,new Vector3(-4.5f,4.5f,0.0f),0.1f);
				Vector3 relativePos = player.position - this.transform.position;
				//看人
				transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.LookRotation(relativePos),0.2f);
				
				if(pi>7){
					//進入下階
					stageStep=1;
					changeFlag=10;
				}
			}
			//3~5拍 轉圈看人
			else if(stageStep==1){
				Vector3 relativePos = player.position - this.transform.position;
				//轉圈
				if(pi<10){
					transform.Rotate(0,(changeFlag>50)?changeFlag:changeFlag++,0);
				}else{
					//位移
					transform.position = Vector3.Lerp(transform.position,new Vector3(4.5f,4.5f,0.0f),0.1f);
					//看人
					transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.LookRotation(relativePos),0.2f);
				}
				if(pi>15){
					//進入下階
					stageStep=2;
				}
			}
			//5~9拍 原地發單
			else if(stageStep==2){
				Vector3 relativePos = player.position - this.transform.position;
				transform.position = Vector3.Lerp(transform.position,new Vector3(moveX,5.0f,0.0f),0.1f);
				if(tmpPi!=pi){
					tmpPi=pi;
					if(pi%2==0){
						moveX=Random.Range(-10.0f,10.0f);
						//向玩家發射
						if(pi<24){
							this.transform.Rotate(180f,0f,0f);
							Instantiate(squareBall,new Vector3(this.transform.position.x,this.transform.position.y,outZ),Quaternion.identity);
							PiSE();
							PlayingManager.outCount++;
						}else{
							//兩發
							this.transform.Rotate(0f,180f,0f);
							Instantiate(squareBall,new Vector3(this.transform.position.x,this.transform.position.y,outZ),Quaternion.identity);
							Instantiate(squareBall,new Vector3(this.transform.position.x,this.transform.position.y,outZ),Quaternion.identity);
							PiSE();
							PlayingManager.outCount+=2;
						}
					}
				}
				//看人
				transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.LookRotation(relativePos),0.2f);
				
				if(pi>29){
					//進入下階
					stageStep=3;
					moveY = Random.Range(2.5f,4.0f);
				}
			}
			//9~17拍 固定走向
			else if(stageStep==3){
				Vector3 relativePos = player.position - this.transform.position;
				if(pi%2==0){
					//移動
					if(pi<34)
						this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(-4.5f,moveY,0.0f),0.1f);
					else if(pi<38)
						this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(-9f,moveY,0.0f),0.1f);
					else if(pi<42)
						this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(8f,moveY,0.0f),0.1f);
					else if(pi<46)
						this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(-3f,moveY,0.0f),0.1f);
					else if(pi<50)
						this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(4.5f,moveY,0.0f),0.1f);
					else if(pi<52)
						this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(9f,moveY,0.0f),0.1f);
					else if(pi<58)
						this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(-4.5f,moveY,0.0f),0.1f);
					else if(pi<62)
						this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(-8f,moveY,0.0f),0.1f);
					//發射
					if(tmpPi!=pi){
						tmpPi=pi;
						moveY = Random.Range(2.5f,4.0f);
						//兩發
						this.transform.Rotate(180f,0f,0f);
						Instantiate(fireBall[Random.Range(0,fireBall.Length)],new Vector3(this.transform.position.x,this.transform.position.y,outZ),Quaternion.LookRotation(relativePos+Vector3.right));
						Instantiate(fireBall[Random.Range(0,fireBall.Length)],new Vector3(this.transform.position.x,this.transform.position.y,outZ),Quaternion.LookRotation(relativePos+Vector3.left));
						PiSE();
						PlayingManager.outCount+=2;
					}
				}
				//看人
				transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.LookRotation(relativePos),0.2f);
				
				if(pi>59){
					//進入下階
					stageStep=4;
					moveX=Random.Range(-10f,10f);
				}
			}
			//17~21拍 小鋼琴 移出隨機
			else if(stageStep==4){
				Vector3 relativePos = player.position - this.transform.position;
				//移動
				if(pi<61)
					this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(-15f,5.5f,0.0f),0.1f);
				else if(pi<62)
					this.transform.position = new Vector3(15f,5.5f,0.0f);
				else
					this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(moveX,5.0f,0.0f),0.1f);
				//發射
				if(tmpPi!=pi){
					tmpPi=pi;
					//控制尾徑
					if(pi==61)
						GetComponent<TrailRenderer>().enabled=false;
					else if(pi==62)
						GetComponent<TrailRenderer>().enabled=true;
					//向玩家發射
					if(pi>61){//第一拍不射
						this.transform.Rotate(0f,180f,0f);
						Instantiate(squareBall,new Vector3(this.transform.position.x,this.transform.position.y,outZ),Quaternion.identity);
						PiSE();
						PlayingManager.outCount++;
					}
					moveX=Random.Range(-10.0f,10.0f);
				}
				//看人
				this.transform.rotation = Quaternion.Lerp(this.transform.rotation,Quaternion.LookRotation(relativePos),0.2f);
				
				if(pi>74){
					//進入下階
					stageStep=5;
					changeFlag=0;
					moveX=-4.5f;
					moveY = Random.Range(2.5f,4.0f);
				}
			}
			//21~25拍 三連
			if(stageStep==5){
				Vector3 relativePos = player.position - this.transform.position;
				if(pi%2==0){
					//發射
					if(tmpPi!=pi){
						if(changeFlag==0)
							moveX=4.5f;
						else
							moveX=-4.5f;
						changeFlag=(changeFlag+1)%2;
						tmpPi=pi;
						moveY = Random.Range(2.5f,4.0f);
						//向玩家發射
						//三發
						this.transform.Rotate(180f,0f,0f);
						Instantiate(fireBall[Random.Range(0,fireBall.Length)],new Vector3(this.transform.position.x,this.transform.position.y,outZ),Quaternion.LookRotation(relativePos+Vector3.right));
						Instantiate(fireBall[Random.Range(0,fireBall.Length)],new Vector3(this.transform.position.x,this.transform.position.y,outZ),Quaternion.LookRotation(relativePos+Vector3.left));
						Instantiate(fireBall[Random.Range(0,fireBall.Length)],new Vector3(this.transform.position.x,this.transform.position.y,outZ),Quaternion.LookRotation(relativePos));
						PiSE();
						PlayingManager.outCount+=3;
					}
				}
				//移動
				this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(moveX,moveY,0.0f),0.1f);
				//看人
				this.transform.rotation = Quaternion.Lerp(this.transform.rotation,Quaternion.LookRotation(relativePos),0.2f);
				
				if(pi>89){
					//進入下階
					stageStep=6;
					moveX=Random.Range(-10.0f,10.0f);
				}
			}
			//25~29拍 移出隨機
			else if(stageStep==6){
				Vector3 relativePos = player.position - this.transform.position;
				//移動
				if(pi<91)
					this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(-15f,5.5f,0.0f),0.1f);
				else if(pi<92)
					this.transform.position = new Vector3(15f,5.5f,0.0f);
				else{
					this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(moveX,5.0f,0.0f),0.1f);
				}
				//發射
				if(tmpPi!=pi){
					tmpPi=pi;
					//控制尾徑
					if(pi==91)
						GetComponent<TrailRenderer>().enabled=false;
					else if(pi==92)
						GetComponent<TrailRenderer>().enabled=true;
					//向玩家發射
					if(pi>91){//第一拍+最後不射
						this.transform.Rotate(0f,180f,0f);
						Instantiate(squareBall,new Vector3(this.transform.position.x,this.transform.position.y,outZ),Quaternion.identity);
						PiSE();
						PlayingManager.outCount++;
					}
					moveX=Random.Range(-10.0f,10.0f);
				}
				//看人
				this.transform.rotation = Quaternion.Lerp(this.transform.rotation,Quaternion.LookRotation(relativePos),0.2f);
				
				if(pi>105){
					//進入下階
					stageStep=7;
					changeFlag=0;
				}
			}
			//29~33拍 POSE
			else if(stageStep==7){
				Vector3 relativePos = player.position - this.transform.position;
				if(pi<108){
					this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(0.0f,2.77f,0.0f),0.1f);
					//看人
					this.transform.rotation = Quaternion.Lerp(this.transform.rotation,Quaternion.LookRotation(relativePos),0.2f);
				}else if(pi<110){
					this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(0.0f,-1.73f,0.0f),0.1f);
					//看人
					this.transform.rotation = Quaternion.Lerp(this.transform.rotation,Quaternion.LookRotation(relativePos),0.2f);
				}else if(pi<111){
					this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(-4.5f,2.77f,0.0f),0.1f);
					//看人
					this.transform.rotation = Quaternion.Lerp(this.transform.rotation,Quaternion.LookRotation(relativePos),0.2f);
				}else if(pi<113){
					this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(0f,4.5f,0.0f),0.1f);
					//看人
					//if(pi==112)
					//	this.transform.rotation = Quaternion.Lerp(this.transform.rotation,new Quaternion(0,-0.7f,0.7f,0),0.2f);
					//else
						this.transform.rotation = Quaternion.Lerp(this.transform.rotation,Quaternion.LookRotation(relativePos),0.2f);
				}else if(pi<120){
					//if(changeFlag==0)
					//	this.transform.rotation = new Quaternion(0,-0.7f,0.7f,0);
					this.transform.Rotate(0,(changeFlag>50)?changeFlag:changeFlag++,0);
				}else if(pi<121){
					this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(moveX,moveY,0.0f),0.1f);
					//看人
					this.transform.rotation = Quaternion.Lerp(this.transform.rotation,Quaternion.LookRotation(relativePos),0.2f);
				}
				
				if(pi>118){
					//進入下階
					stageStep=8;
					moveY = Random.Range(2.5f,4.0f);
				}
			}
			//33~37拍 固定走向
			else if(stageStep==8){
				Vector3 relativePos = player.position - this.transform.position;
				if(pi%2==0){
					//移動
					if(pi<126)
						this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(4.5f,moveY,0.0f),0.1f);
					else if(pi<130)
						this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(9f,moveY,0.0f),0.1f);
					else if(pi<132)
						this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(-8f,moveY,0.0f),0.1f);
					else if(pi<134)
						this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(-4.5f,moveY,0.0f),0.1f);
					else if(pi<136)
						this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(-9f,moveY,0.0f),0.1f);
					//發射
					if(tmpPi!=pi){
						tmpPi=pi;
						moveY = Random.Range(2.5f,4.0f);
						//向玩家發射
						//三發
						this.transform.Rotate(180f,0f,0f);
						Instantiate(fireBall[Random.Range(0,fireBall.Length)],new Vector3(this.transform.position.x,this.transform.position.y,outZ),Quaternion.LookRotation(relativePos+Vector3.right));
						Instantiate(fireBall[Random.Range(0,fireBall.Length)],new Vector3(this.transform.position.x,this.transform.position.y,outZ),Quaternion.LookRotation(relativePos+Vector3.left));
						Instantiate(fireBall[Random.Range(0,fireBall.Length)],new Vector3(this.transform.position.x,this.transform.position.y,outZ),Quaternion.LookRotation(relativePos));
						PiSE();
						PlayingManager.outCount+=3;
					}
				}
				//看人
				this.transform.rotation = Quaternion.Lerp(this.transform.rotation,Quaternion.LookRotation(relativePos),0.2f);
				
				if(pi>132){
					//進入下階
					stageStep=9;
					moveX=Random.Range(-10.0f,10.0f);
				}
			}
			//37~41拍 移出隨機
			else if(stageStep==9){
				Vector3 relativePos = player.position - this.transform.position;
				//移動
				if(pi<134)
					this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(-15f,5.5f,0.0f),0.1f);
				else if(pi<135)
					this.transform.position = new Vector3(15f,5.5f,0.0f);
				else{
					this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(moveX,5.0f,0.0f),0.1f);
				}
				//發射
				if(tmpPi!=pi){
					tmpPi=pi;
					//控制尾徑
					if(pi==134)
						GetComponent<TrailRenderer>().enabled=false;
					else if(pi==135)
						GetComponent<TrailRenderer>().enabled=true;
					//向玩家發射
					if(pi>134){ //第一拍不射
						this.transform.Rotate(0f,180f,0f);
						Instantiate(squareBall,new Vector3(this.transform.position.x,this.transform.position.y,outZ),Quaternion.identity);
						PiSE();
						PlayingManager.outCount++;
					}
					moveX=Random.Range(-10.0f,10.0f);
				}
				//看人
				transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.LookRotation(relativePos),0.2f);
				
				if(pi>148){
					//進入下階
					stageStep=10;
					changeFlag=0;
					changeFlag2=0.12f;
				}
			}
			//41~45拍 滑行三連
			else if(stageStep==10){
				Vector3 relativePos = player.position - this.transform.position;
				if(pi%2==0){
					//移動
					if(changeFlag==0){
						this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(11.0f,4.8f,0.0f),0.1f);
					}else{
						this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(-11.0f,4.8f,0.0f),0.1f);
					}
					//發射
					if(tmpPi!=pi){
						tmpPi=pi;
						changeFlag3=0;
						changeFlag=(changeFlag+1)%2;
					}
					if(changeFlag2>0)
						changeFlag2 -= 0.02f;
					else{
						//發射
						if(changeFlag3<3){ //三發,每發0.142秒
							this.transform.Rotate(0f,180f,0f);
							Instantiate(fireBall[Random.Range(0,fireBall.Length)],new Vector3(this.transform.position.x,this.transform.position.y,outZ),Quaternion.LookRotation(relativePos));
							PiSE();
							PlayingManager.outCount++;
							changeFlag2=0.12f;
							changeFlag3++;
						}
					}
				}
				//看人
				this.transform.rotation = Quaternion.Lerp(this.transform.rotation,Quaternion.LookRotation(relativePos),0.2f);
				
				if(pi>164){
					//進入下階
					stageStep=11;
					moveX=Random.Range(-10.0f,10.0f);
					moveY = Random.Range(2.5f,4.0f);
					tmpPi=0;
				}
			}
			//45~49拍 隨機2
			else if(stageStep==11){
				Vector3 relativePos = player.position - this.transform.position;
				//移動
				this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(moveX,moveY,0.0f),0.1f);
				if(pi%2==0){
					//發射
					if(tmpPi!=pi){
						tmpPi=pi;
						moveY = Random.Range(2.5f,4.0f);
						//向玩家發射
						this.transform.Rotate(180f,0f,0f);
						Instantiate(fireBall[Random.Range(0,fireBall.Length)],new Vector3(this.transform.position.x,this.transform.position.y,outZ),Quaternion.LookRotation(relativePos+Vector3.right));
						Instantiate(fireBall[Random.Range(0,fireBall.Length)],new Vector3(this.transform.position.x,this.transform.position.y,outZ),Quaternion.LookRotation(relativePos+Vector3.left));
						Instantiate(fireBall[Random.Range(0,fireBall.Length)],new Vector3(this.transform.position.x,this.transform.position.y,outZ),Quaternion.LookRotation(relativePos));
						PiSE();
						PlayingManager.outCount+=3;
						moveX=Random.Range(-10.0f,10.0f);
					}
				}
				//看人
				this.transform.rotation = Quaternion.Lerp(this.transform.rotation,Quaternion.LookRotation(relativePos),0.2f);
				
				if(pi>178){
					//進入下階
					stageStep=12;
					changeFlag=0;
				}
			}
			//49~53拍 POSE
			else if(stageStep==12){
				Vector3 relativePos = player.position - this.transform.position;
				if(pi<181){
					this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(0.0f,2.77f,0.0f),0.1f);
					//看人
					this.transform.rotation = Quaternion.Lerp(this.transform.rotation,Quaternion.LookRotation(relativePos),0.2f);
				}else if(pi<183){
					this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(0.0f,-1.73f,0.0f),0.1f);
					//看人
					this.transform.rotation = Quaternion.Lerp(this.transform.rotation,Quaternion.LookRotation(relativePos),0.2f);
				}else if(pi<184){
					this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(4.5f,2.77f,0.0f),0.1f);
					//看人
					this.transform.rotation = Quaternion.Lerp(this.transform.rotation,Quaternion.LookRotation(relativePos),0.2f);
				}else if(pi<186){
					this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(0f,4.5f,0.0f),0.1f);
					//看人
					//if(pi==185)
					//	this.transform.rotation = Quaternion.Lerp(this.transform.rotation,new Quaternion(0,-0.7f,0.7f,0),0.2f);
					//else
						this.transform.rotation = Quaternion.Lerp(this.transform.rotation,Quaternion.LookRotation(relativePos),0.2f);
				}else if(pi<193){
					//if(changeFlag==0)
					//	transform.rotation = new Quaternion(0,-0.7f,0.7f,0);
					this.transform.Rotate(0,(changeFlag>50)?changeFlag:changeFlag++,0);
				}else{
					this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(moveX,moveY,0.0f),0.1f);
					//看人
					this.transform.rotation = Quaternion.Lerp(this.transform.rotation,Quaternion.LookRotation(relativePos),0.2f);
				}
				
				if(pi>194){
					//進入下階
					stageStep=13;
					moveX = Random.Range(-10.0f,10.0f);
					moveY = Random.Range(2.5f,4.0f);
				}
			}
			//53~61拍 隨機三砲
			else if(stageStep==13){
				Vector3 relativePos = player.position - this.transform.position;
				//移動
				this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(moveX,moveY,0.0f),0.1f);
				if(pi%2==1){
					//發射
					if(tmpPi!=pi){
						tmpPi=pi;
						moveY = Random.Range(2.5f,4.0f);
						//向玩家發射
						this.transform.Rotate(0f,180f,0f);
						Instantiate(fireBall[Random.Range(0,fireBall.Length)],new Vector3(this.transform.position.x,this.transform.position.y,outZ),Quaternion.LookRotation(relativePos+Vector3.right));
						Instantiate(fireBall[Random.Range(0,fireBall.Length)],new Vector3(this.transform.position.x,this.transform.position.y,outZ),Quaternion.LookRotation(relativePos+Vector3.left));
						Instantiate(fireBall[Random.Range(0,fireBall.Length)],new Vector3(this.transform.position.x,this.transform.position.y,outZ),Quaternion.LookRotation(relativePos));
						PiSE();
						PlayingManager.outCount+=3;
						moveX=Random.Range(-10.0f,10.0f);
					}
				}
				//看人
				this.transform.rotation = Quaternion.Lerp(this.transform.rotation,Quaternion.LookRotation(relativePos),0.2f);
				
				if(pi>238){
					//進入下階
					stageStep=14;
					moveX=Random.Range(-10.0f,10.0f);
					moveY=5.0f;
				}
			}
			//65~73拍(完) 移出隨機+隨機2
			else if(stageStep==14){
				Vector3 relativePos = player.position - this.transform.position;
				//移動
				if(pi<240)
					this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(-15f,5.5f,0.0f),0.1f);
				else if(pi<241)
					this.transform.position = new Vector3(15f,5.5f,0.0f);
				else{
					this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(moveX,moveY,0.0f),0.1f);
				}
				//發射
				if(tmpPi!=pi){
					tmpPi=pi;
					//控制尾徑
					if(pi==240)
						GetComponent<TrailRenderer>().enabled=false;
					else if(pi==241)
						GetComponent<TrailRenderer>().enabled=true;
					//向玩家發射
					if(pi>240){ //第一拍+最後不射
						if(pi<255){
							this.transform.Rotate(180f,0f,0f);
							Instantiate(squareBall,new Vector3(this.transform.position.x,this.transform.position.y,outZ),Quaternion.identity);
							PiSE();
							PlayingManager.outCount++;
						}else if(pi<261){
							moveY=4.0f;
							this.transform.Rotate(0f,180f,0f);
							Instantiate(fireBall[Random.Range(0,fireBall.Length)],new Vector3(this.transform.position.x,this.transform.position.y,outZ),Quaternion.LookRotation(relativePos+Vector3.right));
							Instantiate(fireBall[Random.Range(0,fireBall.Length)],new Vector3(this.transform.position.x,this.transform.position.y,outZ),Quaternion.LookRotation(relativePos+Vector3.left));
							PiSE();
							PlayingManager.outCount+=2;
						}else{
							moveY=3.0f;
							this.transform.Rotate(180f,0f,0f);
							Instantiate(fireBall[Random.Range(0,fireBall.Length)],new Vector3(this.transform.position.x,this.transform.position.y,outZ),Quaternion.LookRotation(relativePos+Vector3.right));
							Instantiate(fireBall[Random.Range(0,fireBall.Length)],new Vector3(this.transform.position.x,this.transform.position.y,outZ),Quaternion.LookRotation(relativePos));
							Instantiate(fireBall[Random.Range(0,fireBall.Length)],new Vector3(this.transform.position.x,this.transform.position.y,outZ),Quaternion.LookRotation(relativePos+Vector3.left));
							PiSE();
							PlayingManager.outCount+=3;
						}
					}
					moveX=Random.Range(-10.0f,10.0f);
				}
				//看人
				this.transform.rotation = Quaternion.Lerp(this.transform.rotation,Quaternion.LookRotation(relativePos),0.2f);
				
				if(pi>269){
					//回頭loop
					stageStep=3;
					pi=30;
					moveY = Random.Range(2.5f,4.0f);
				}
			}
			
			//**********行為END*******************

			//閃紅恢復
			if (blinkRed) {
				if(renderer.material.color.r > 0.99f){
					this.renderer.material.color = Color.white;
					blinkRed=false;
				}else{
					this.renderer.material.color = Color.Lerp(this.renderer.material.color,Color.white,0.1f);
				}
			}
			if(hitCD > 0f)
				hitCD -= 0.02f;
			//Boss死亡
			if (PlayingManager.endIn) {
				if(cpy){
					GameManager.playerExp += PlayingManager.bossGetExp/2;
					GameManager.money += PlayingManager.bossGetMoney/2;
				}else{
					GameManager.playerExp += PlayingManager.bossGetExp;
					GameManager.money += PlayingManager.bossGetMoney;
					if(GameManager.openLevel < 2)
						GameManager.openLevel = 2;
					//對話
					labFoSi = Mathf.RoundToInt((float)labFoSi * 1.2f);
					mesTimer = 3f;
					mesText = "呃啊～～～～";
					showMes = true;
					//清場
					FireBall.bossFireBall=true;
				}
				//爆炸
				AudioSource.PlayClipAtPoint(readyBoom,Vector3.one);
				this.renderer.material.color = Color.gray;
				GameObject testV;
				testV = Instantiate(boom,new Vector3(transform.position.x,transform.position.y,0f),Quaternion.identity) as GameObject;
				testV.transform.parent = this.transform;
				//this.GetComponent<Stage1Boss>().enabled=false;
				worked = false;
			}
		}
		//*******************對話***********************/
		if(showMes){
			if(mesTimer > 0){
				mesTimer -= 0.02f;
			}else{
				showMes = false;
			}
		}
	}
	
	void Update (){
		//*******************對話***********************/
		if(showMes){
			mesRect.x = ToScreen(this.transform.position.x);
			mesRect.y = ToScreenY(this.transform.position.y);
			//超界
			if(mesRect.x + mesRect.width > Screen.width){
				mesRect.x = Screen.width - mesRect.width;
			}else if(mesRect.x < 0f){
				mesRect.x = 0f;
			}
		}
	}
	void OnGUI (){
		//對話
		if(showMes){
			GUI.skin.window.fontSize = winFoSi;
			GUI.Window(4,mesRect,mesWindow,GameManager.BossName(3));
		}
	}
	void mesWindow(int windowID){
		GUI.skin.label.alignment = TextAnchor.UpperLeft;
		GUI.skin.label.fontSize = labFoSi;
		GUI.Label(mesLabRect,mesText);
	}
	void OnTriggerEnter(Collider other){
		if (Time.timeScale != 0) {
			//被棒子揮到時
			if(other.tag=="sticks" && hitCD<=0){
				//閃紅 往上位移
				if(!cpy){
					renderer.material.color = Color.red;
					blinkRed=true;
				}
				this.transform.Translate(0,1,0,Space.World);
				//加HP
				int addHP = PlayingManager.addHP*5;
				if (GameManager.wearSk1 == 6 || GameManager.wearSk2 == 6 || GameManager.wearSk3 == 6) {
					addHP += GameManager.skLv[5]*50 + (int)((float)addHP * Random.Range(-0.1f,0.1f));
				}else{
					addHP += (int)((float)addHP * Random.Range(-0.1f,0.1f));
				}
				PlayingManager.stageHp += addHP;
				PlayingManager.ShowPlus(addHP,this.transform.position);
				AudioSource.PlayClipAtPoint(hitSE,Vector3.zero);
				hitCD=0.2f;
			}
		}
	}
	
	void PiSE(){
		AudioSource.PlayClipAtPoint (piSE,Vector3.one);
	}
	//轉換滑鼠座標&世界座標
	float ToScreen(float x){
		//return (x+11.0f)*(Screen.width/22.0f); //左-11右11
		return (x+11.0f)*mesPoRate; //左-11右11
	}
	float ToScreenY(float x){
		return (x+7.0f)*mesHiPoRate;
	}
}
