using UnityEngine;
using System.Collections;

public class S3SkyBall : MonoBehaviour {
	bool blinkRed=false,phase2=false,worked=true;
	//拍數,不連發
	int pi,tmpPi=-1;
	//發射間隔
	float tempoCD,tempoCDini=0.66666f; //60/90
	//發射體
	public GameObject[] fireBall;
	public GameObject boom,cube,VBall,XBall,fourFireBall,sobi,cloth;
	//stage
	int stageStep,changeFlag;
	float moveX,moveZ=0f,moveY=1.0f;
	//模型
	Color iniColor = Color.green;
	public AudioClip p2SE,readyBoom,hitSE,piSE;
	bool clothWear=false;
	//cpy
	public bool cpy=false;
	float hitCD;
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
		this.renderer.material.color = Color.green;
		FireBall.bossFireBall=false;
		if(!cpy){
			PlayingManager.bossCo = 8; //編號8天球
			//對話
			mesTimer = 7f;
			if(!GameManager.s3BSee [1]){
				mesText = "你長得真帥!";
				GameManager.s3BSee [1] = true;
			}else{
				int ran = Random.Range(1,4);
				if(ran == 1)
					mesText = "...我要在這裡解決你。";
				else if(ran == 2)
					mesText = "真想輕鬆一點......";
				else
					mesText = "我要不要等等再來呢...?";
			}
			showMes = true;
		}
	}
	
	void FixedUpdate () {
		if (worked) {
			//計算拍數
			if(tempoCD<=0){
				pi++;
				tempoCD = tempoCDini;
			}else{
				tempoCD -= 0.02f;
			}
			//**********行為*******************
			//1~5拍 空等
			if(stageStep==0){
				if(pi==9){
					this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(0f,2f,moveZ),0.1f);
				}if(pi==11){
					this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(-7.0f,2.5f,moveZ),0.1f);
				}else if(pi==13){
					this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(4.0f,0.7f,moveZ),0.1f);
				}if(pi==15){
					//移至定位
					this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(8.0f,moveY,moveZ),0.1f);
				}
				else if(pi>15){
					//進入下階
					stageStep=1;
					changeFlag=0;
				}
			}
			//5~9拍 兩發上發
			else if(stageStep==1){
				if(tmpPi!=pi){
					tmpPi=pi;
					if(pi!=32){
						if(pi%2==0){
							//發射
							Instantiate(cube,transform.position,Quaternion.identity);
							Instantiate(cube,transform.position,Quaternion.identity);
							PiSE();
							PlayingManager.outCount+=2;
							if(phase2){
								GameObject testV;
								testV = Instantiate(fireBall[0],this.transform.position,Quaternion.identity) as GameObject;
								testV.transform.localEulerAngles = new Vector3(85f,90f,0f);
								testV = Instantiate(fireBall[0],this.transform.position,Quaternion.identity) as GameObject;
								testV.transform.localEulerAngles = new Vector3(275f,90f,0f);
								PlayingManager.outCount+=2;
							}
							
							changeFlag = (changeFlag+1)%2;
							//BUFF球
							if(pi==30){
								Instantiate(fireBall[Random.Range(1,4)],transform.position,new Quaternion(0,0,-0.9f,0.3f));
								PiSE();
								PlayingManager.outCount++;
							}
						}
					}
				}
				//移動
				if(changeFlag==0){
					this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(8.0f,moveY,moveZ),0.1f);
				}else{
					this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(-8.0f,moveY,moveZ),0.1f);
				}
				
				if(pi>31){
					//進入下階
					stageStep=2;
					tmpPi=0;
				}
			}
			//9~13拍 左右轉四方
			else if(stageStep==2){
				if(tmpPi!=pi){
					tmpPi=pi;
					if(pi!=48){
						if(pi%2==0){
							//發射
							Instantiate(fourFireBall,transform.position,Quaternion.identity);
							PiSE();
							PlayingManager.outCount+=4;
							changeFlag = (changeFlag+1)%2;
							//BUFF球
							if(pi==46){
								Instantiate(fireBall[Random.Range(1,4)],transform.position,new Quaternion(0,0,-0.9f,0.3f));
								PlayingManager.outCount++;
							}
						}
					}
				}
				//移動
				if(changeFlag==0){
					this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(8.0f,3f,moveZ),0.1f);
				}else{
					this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(-8.0f,3f,moveZ),0.1f);
				}
				
				if(pi>47){
					//進入下階
					stageStep=3;
					tmpPi=0;
				}
			}
			//13~17拍 移動+隨機轉向發射
			else if (stageStep == 3) {
				if(tmpPi!=pi){
					tmpPi=pi;
					if(pi!=64){
						moveX = Random.Range(-9.0f,9.0f);
						moveY = Random.Range(1.0f,4.8f);
						//發射
						Instantiate(cube,transform.position,Quaternion.identity);
						PiSE();
						PlayingManager.outCount++;
						if(phase2){
							if(pi%2==0){
								Instantiate(fireBall[0],this.transform.position,new Quaternion(0,0,(Random.Range(-1.0f,1.0f)),(Random.Range(-1.0f,1.0f))));
								PlayingManager.outCount++;
							}
						}
						//BUFF球
						if(pi==62){
							Instantiate(fireBall[Random.Range(1,4)],transform.position,new Quaternion(0,0,-0.9f,0.3f));
							PiSE();
							PlayingManager.outCount++;
						}
					}
				}
				//移動
				if(pi>62) //接下關
					this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(0,1.0f,moveZ),0.1f);
				else
					this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(moveX,moveY,moveZ),0.1f);
				
				if(pi>63){
					stageStep=4;
					tmpPi=0;
				}
			}
			//17~21拍 左右三發
			else if (stageStep == 4) {
				if(tmpPi!=pi){
					tmpPi=pi;
					if(pi!=78){
						if(pi%2==0){
							GameObject testV;
							//發射
							if(pi<73){
								/*
								Instantiate(fireBall[0],this.transform.position,Quaternion.LookRotation(new Vector3(0.1f,5.5f,0.0f)));
								Instantiate(fireBall[0],this.transform.position,Quaternion.LookRotation(new Vector3(1.1f,5.5f,0.0f)));
								Instantiate(fireBall[0],this.transform.position,Quaternion.LookRotation(new Vector3(-1.1f,5.5f,0.0f)));
								*/
								testV = Instantiate(fireBall[0],this.transform.position,Quaternion.identity) as GameObject;
								testV.transform.localEulerAngles = new Vector3(275f,90f,0f);
								testV = Instantiate(fireBall[0],this.transform.position,Quaternion.identity) as GameObject;
								testV.transform.localEulerAngles = new Vector3(280f,90f,0f);
								testV = Instantiate(fireBall[0],this.transform.position,Quaternion.identity) as GameObject;
								testV.transform.localEulerAngles = new Vector3(85f,90f,0f);
								PiSE();
								PlayingManager.outCount+=3;
							}else{
								/*
								Instantiate(fireBall[0],this.transform.position,Quaternion.LookRotation(new Vector3(-0.1f,5.5f,0.0f)));
								Instantiate(fireBall[0],this.transform.position,Quaternion.LookRotation(new Vector3(1.1f,5.5f,0.0f)));
								Instantiate(fireBall[0],this.transform.position,Quaternion.LookRotation(new Vector3(-1.1f,5.5f,0.0f)));
								*/
								testV = Instantiate(fireBall[0],this.transform.position,Quaternion.identity) as GameObject;
								testV.transform.localEulerAngles = new Vector3(80f,90f,0f);
								testV = Instantiate(fireBall[0],this.transform.position,Quaternion.identity) as GameObject;
								testV.transform.localEulerAngles = new Vector3(85f,90f,0f);
								testV = Instantiate(fireBall[0],this.transform.position,Quaternion.identity) as GameObject;
								testV.transform.localEulerAngles = new Vector3(275f,90f,0f);
								PiSE();
								PlayingManager.outCount+=3;
							}
							//BUFF球
							if(pi==78){
								Instantiate(fireBall[Random.Range(1,4)],transform.position,new Quaternion(0,0,-0.9f,0.3f));
								PlayingManager.outCount++;
							}
							if(phase2){
								if(changeFlag==0)
									Instantiate(fireBall[0],transform.position,new Quaternion(0,0,-0.9f,0.3f));
								else
									Instantiate(fireBall[0],transform.position,new Quaternion(0,0,-0.9f,-0.3f));
								PlayingManager.outCount++;
								changeFlag = (changeFlag+1)%2;
							}
						}
					}
				}
				//移動
				this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(0,1.0f,moveZ),0.1f);
				
				if(pi>77){
					stageStep=5;
					tmpPi=0;
				}
			}
			//21~25拍 反向V
			else if (stageStep == 5) {
				if(tmpPi!=pi){
					tmpPi=pi;
					if(pi!=94){
						if(pi%2==0){
							moveX = Random.Range(-9.0f,9.0f);
							moveY = Random.Range(1.0f,4.8f);
							//發射
							if(phase2){
								if(changeFlag==0){
									Instantiate(VBall,this.transform.position,new Quaternion(0.9f,-0.4f,0f,0f));
									PiSE();
									PlayingManager.outCount+=5;
								}else{
									Instantiate(VBall,this.transform.position,new Quaternion(0.9f,0.4f,0f,0f));
									PiSE();
									PlayingManager.outCount+=5;
								}
								changeFlag = (changeFlag+1)%2;
							}else{
								Instantiate(VBall,this.transform.position,new Quaternion(1f,0f,0f,0f));
								PiSE();
								PlayingManager.outCount+=5;
							}
							//BUFF球
							if(pi==94){
								Instantiate(fireBall[Random.Range(1,4)],transform.position,new Quaternion(0,0,-0.9f,0.3f));
								PiSE();
								PlayingManager.outCount++;
							}
						}
					}
					
				}
				//移動
				this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(moveX,moveY,moveZ),0.1f);
				
				if(pi>93){
					stageStep=6;
					tmpPi=0;
				}
			}
			//25~29拍 下來見人
			else if (stageStep == 6) {
				if(tmpPi!=pi){
					tmpPi=pi;
					if(pi!=110){
						if(pi%2==0){
							moveX = Random.Range(-9.0f,9.0f);
							moveY = Random.Range(-2.0f,-3.0f);
							//往上發砲
							if(pi>102){
								if(phase2){
									if(changeFlag==0){
										Instantiate(fireBall[0],transform.position,new Quaternion(0,0,-0.9f,0.3f));
										PlayingManager.outCount++;
									}else{
										Instantiate(fireBall[0],transform.position,new Quaternion(0,0,-0.9f,-0.3f));
										PlayingManager.outCount++;
									}
									changeFlag = (changeFlag+1)%2;
								}
								Instantiate(cube,transform.position,Quaternion.identity);
								PiSE();
								PlayingManager.outCount++;
							}
						}else{
							moveX = Random.Range(-9.0f,9.0f);
							if(pi==109)
								moveY = Random.Range(3.0f,4.8f);
							else
								moveY = Random.Range(2.0f,4.8f);
						}
						//BUFF球
						if(pi==109){
							Instantiate(fireBall[Random.Range(1,4)],transform.position,new Quaternion(0,0,-0.9f,0.3f));
							PiSE();
							PlayingManager.outCount++;
						}
					}
				}
				
				//移動
				this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(moveX,moveY,moveZ),0.1f);
				
				if(pi>109){
					stageStep=7;
					tmpPi=0;
				}
			}
			//29~33拍 X球
			else if (stageStep == 7) {
				if(tmpPi!=pi){
					tmpPi=pi;
					if(pi!=126){
						if(pi%2==0){
							if(changeFlag==0)
								moveX = -9.0f;
							else
								moveX = 9.0f;
							moveY = Random.Range(3.0f,4.8f);
							//發砲
							if(changeFlag==0){
								Instantiate(XBall,new Vector3(this.transform.position.x-1,this.transform.position.y-1,moveZ),new Quaternion(0f,0f,0.9f,0.4f));
								PiSE();
								PlayingManager.outCount+=5;
							}else{
								Instantiate(XBall,new Vector3(this.transform.position.x+1,this.transform.position.y-1,moveZ),new Quaternion(0f,0f,0.9f,-0.4f));
								PiSE();
								PlayingManager.outCount+=5;
							}
							
							//BUFF球
							if(pi==124){
								Instantiate(fireBall[Random.Range(1,4)],transform.position,new Quaternion(0,0,-0.9f,0.3f));
								PiSE();
								PlayingManager.outCount++;
							}
							if(phase2){
								if(changeFlag==0){
									Instantiate(fireBall[0],transform.position,new Quaternion(0,0,-0.9f,0.3f));
									PlayingManager.outCount++;
								}else{
									Instantiate(fireBall[0],transform.position,new Quaternion(0,0,-0.9f,-0.3f));
									PlayingManager.outCount++;
								}
							}
							changeFlag = (changeFlag+1)%2;
						}
					}
				}
				
				//移動
				this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(moveX,moveY,moveZ),0.1f);
				if(pi>125){
					stageStep=8;
					tmpPi=0;
				}
			}
			//33~37拍 動左右三
			else if (stageStep == 8) {
				if(tmpPi!=pi){
					tmpPi=pi;
					if(pi!=142){
						GameObject testV;
						moveX = Random.Range(-9.0f,9.0f);
						moveY = 3f;
						if(pi%2==0){
							//發射
							if(changeFlag==0){
								/*
								Instantiate(fireBall[0],this.transform.position,new Quaternion(0,0,0.7f,0.8f));
								Instantiate(fireBall[0],this.transform.position,new Quaternion(0,0,0.5f,0.8f));
								Instantiate(fireBall[0],this.transform.position,new Quaternion(0,0,-0.6f,0.8f));
								*/
								testV = Instantiate(fireBall[0],this.transform.position,Quaternion.identity) as GameObject;
								testV.transform.localEulerAngles = new Vector3(80f,90f,0f);
								testV = Instantiate(fireBall[0],this.transform.position,Quaternion.identity) as GameObject;
								testV.transform.localEulerAngles = new Vector3(85f,90f,0f);
								testV = Instantiate(fireBall[0],this.transform.position,Quaternion.identity) as GameObject;
								testV.transform.localEulerAngles = new Vector3(275f,90f,0f);
								PiSE();
								PlayingManager.outCount+=3;
							}else{
								/*
								Instantiate(fireBall[0],this.transform.position,new Quaternion(0,0,-0.7f,0.8f));
								Instantiate(fireBall[0],this.transform.position,new Quaternion(0,0,-0.5f,0.8f));
								Instantiate(fireBall[0],this.transform.position,new Quaternion(0,0,0.6f,0.8f));
								*/
								testV = Instantiate(fireBall[0],this.transform.position,Quaternion.identity) as GameObject;
								testV.transform.localEulerAngles = new Vector3(275f,90f,0f);
								testV = Instantiate(fireBall[0],this.transform.position,Quaternion.identity) as GameObject;
								testV.transform.localEulerAngles = new Vector3(280f,90f,0f);
								testV = Instantiate(fireBall[0],this.transform.position,Quaternion.identity) as GameObject;
								testV.transform.localEulerAngles = new Vector3(85f,90f,0f);
								PiSE();
								PlayingManager.outCount+=3;
							}
							changeFlag = (changeFlag+1)%2;
							//BUFF球
							if(pi==140){
								Instantiate(fireBall[Random.Range(1,4)],transform.position,new Quaternion(0,0,-0.9f,0.3f));
								PiSE();
								PlayingManager.outCount++;
							}
							if(phase2){
								if(changeFlag==0){
									Instantiate(fireBall[0],transform.position,new Quaternion(0,0,-0.9f,0.3f));
									PlayingManager.outCount++;
								}else{
									Instantiate(fireBall[0],transform.position,new Quaternion(0,0,-0.9f,-0.3f));
									PlayingManager.outCount++;
								}
							}
						}
					}
				}
				//移動
				if(pi==141){
					//移至定位
					this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(8.0f,moveY,moveZ),0.1f);
				}else
					this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(moveX,moveY,moveZ),0.1f);
				
				if(pi>141){
					stageStep=9;
					tmpPi=0;
				}
			}
			//37~41拍 左右上四方 f
			else if(stageStep==9){
				if(tmpPi!=pi){
					tmpPi=pi;
					if(pi!=158){
						if(pi%2==0){
							//發射
							Instantiate(fourFireBall,transform.position,Quaternion.identity);
							PiSE();
							PlayingManager.outCount+=4;
							if(phase2){
								if(changeFlag==0){
									Instantiate(fireBall[0],transform.position,new Quaternion(0,0,-0.9f,0.3f));
									PlayingManager.outCount++;
								}else{
									Instantiate(fireBall[0],transform.position,new Quaternion(0,0,-0.9f,-0.3f));
									PlayingManager.outCount++;
								}
							}
							
							changeFlag = (changeFlag+1)%2;
							//BUFF球
							if(pi==158){
								Instantiate(fireBall[Random.Range(1,4)],transform.position,new Quaternion(0,0,-0.9f,0.3f));
								PiSE();
								PlayingManager.outCount++;
							}
						}
					}
				}
				//移動
				if(changeFlag==0){
					this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(8.0f,moveY,moveZ),0.1f);
				}else{
					this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(-8.0f,moveY,moveZ),0.1f);
				}
				
				if(pi>157){
					//進入下階
					stageStep=10;
					tmpPi=0;
				}
			}
			//41~45拍 休息(完)
			else if(stageStep==10){
				if(tmpPi!=pi){
					tmpPi=pi;
					if(pi!=172){
						if(pi%2==0){
							GameObject testV;
							//發射
							if(pi<165){
								/*
								Instantiate(fireBall[0],this.transform.position,Quaternion.LookRotation(new Vector3(0.1f,5.5f,0.0f)));
								Instantiate(fireBall[0],this.transform.position,Quaternion.LookRotation(new Vector3(1.1f,5.5f,0.0f)));
								Instantiate(fireBall[0],this.transform.position,Quaternion.LookRotation(new Vector3(-1.1f,5.5f,0.0f)));
								*/
								testV = Instantiate(fireBall[0],this.transform.position,Quaternion.identity) as GameObject;
								testV.transform.localEulerAngles = new Vector3(275f,90f,0f);
								testV = Instantiate(fireBall[0],this.transform.position,Quaternion.identity) as GameObject;
								testV.transform.localEulerAngles = new Vector3(280f,90f,0f);
								testV = Instantiate(fireBall[0],this.transform.position,Quaternion.identity) as GameObject;
								testV.transform.localEulerAngles = new Vector3(85f,90f,0f);
								PiSE();
								PlayingManager.outCount+=3;
							}else{
								/*
								Instantiate(fireBall[0],this.transform.position,Quaternion.LookRotation(new Vector3(-0.1f,5.5f,0.0f)));
								Instantiate(fireBall[0],this.transform.position,Quaternion.LookRotation(new Vector3(1.1f,5.5f,0.0f)));
								Instantiate(fireBall[0],this.transform.position,Quaternion.LookRotation(new Vector3(-1.1f,5.5f,0.0f)));
								*/
								testV = Instantiate(fireBall[0],this.transform.position,Quaternion.identity) as GameObject;
								testV.transform.localEulerAngles = new Vector3(80f,90f,0f);
								testV = Instantiate(fireBall[0],this.transform.position,Quaternion.identity) as GameObject;
								testV.transform.localEulerAngles = new Vector3(85f,90f,0f);
								testV = Instantiate(fireBall[0],this.transform.position,Quaternion.identity) as GameObject;
								testV.transform.localEulerAngles = new Vector3(275f,90f,0f);
								PiSE();
								PlayingManager.outCount+=3;
							}
							if(phase2){
								if(changeFlag==0){
									Instantiate(fireBall[0],transform.position,new Quaternion(0,0,-0.9f,0.3f));
									PlayingManager.outCount++;
								}else{
									Instantiate(fireBall[0],transform.position,new Quaternion(0,0,-0.9f,-0.3f));
									PlayingManager.outCount++;
								}
								changeFlag = (changeFlag+1)%2;
							}
							
							//BUFF球
							if(pi==170){
								Instantiate(fireBall[Random.Range(1,4)],transform.position,new Quaternion(0,0,-0.9f,0.3f));
								PiSE();
								PlayingManager.outCount++;
							}
						}
					}
				}
				
				if(pi==171){
					//移至定位
					this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(8.0f,moveY,moveZ),0.1f);
				}else
					this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(0,1.5f,moveZ),0.1f);
				if(pi>171){
					//進入下階
					changeFlag=1;
					stageStep=1;
					pi=15;
					tmpPi=0;
				}
			}
			
			//**********行為END*******************
			//閃紅恢復
			if (blinkRed) {
				if(this.renderer.material.color == iniColor){
					blinkRed=false;
				}else{
					this.renderer.material.color = Color.Lerp(this.renderer.material.color,iniColor,0.1f);
				}
			}
			if(hitCD>0f)
				hitCD -= 0.02f;
			//Boss死亡
			if (PlayingManager.endIn) {
				if(cpy){
					GameManager.playerExp += PlayingManager.bossGetExp/2;
					GameManager.money += PlayingManager.bossGetMoney/2;
				}else{
					GameManager.playerExp += PlayingManager.bossGetExp;
					GameManager.money += PlayingManager.bossGetMoney;
					if(GameManager.openLevel < 4)
						GameManager.openLevel = 4;
					//對話
					labFoSi = Mathf.RoundToInt((float)labFoSi * 1.2f);
					mesTimer = 3f;
					mesText = "嗚啊！";
					showMes = true;
				}
				//清場
				FireBall.bossFireBall=true;
				//爆炸
				AudioSource.PlayClipAtPoint(readyBoom,Vector3.one);
				this.renderer.material.color = Color.gray;
				GameObject testV;
				testV = Instantiate(boom,new Vector3(transform.position.x,transform.position.y,0f),Quaternion.identity) as GameObject;
				testV.transform.parent = this.transform;
				//this.GetComponent<Stage3Boss>().enabled=false;
				worked = false;
			}
			//2階段
			if(!phase2 && PlayingManager.phase > 2 && !cpy){
				AudioSource.PlayClipAtPoint(p2SE,Vector3.one);
				if(!cpy){
					iniColor = Color.yellow;
					this.renderer.material.color = Color.red;
					blinkRed=true;
				}
				GameObject testV;
				testV = Instantiate(sobi,this.transform.position,Quaternion.identity) as GameObject;
				testV.transform.parent = this.transform;
				phase2=true;
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
		if(Time.timeScale!=0){
			if(clothWear){
				//重新穿衣
				Destroy(this.transform.GetChild(1).gameObject);
				GameObject testV;
				testV = Instantiate(cloth,this.transform.position,Quaternion.identity) as GameObject;
				testV.transform.localEulerAngles = new Vector3(270f,0f,0f);
				testV.transform.parent = this.transform;
				testV.transform.localPosition = new Vector3(0f,0f,0.5f);
				testV.GetComponent<InteractiveCloth>().AttachToCollider(this.collider);
				clothWear=false;
			}
		}else{
			//暫停脫衣
			clothWear=true;
		}
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
			GUI.Window(4,mesRect,mesWindow,GameManager.BossName(8));
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
					this.renderer.material.color = Color.red;
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
		return (x+11.5f)*mesPoRate; //左-11右11
	}
	float ToScreenY(float x){
		return (x+7.0f)*mesHiPoRate;
	}
}
