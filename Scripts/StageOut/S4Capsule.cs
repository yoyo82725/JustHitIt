using UnityEngine;
using System.Collections;

public class S4Capsule : MonoBehaviour {
	bool worked=true;
	//拍數,不連發
	int pi=0,tmpPi=-1;
	//發射間隔
	float tempoCD=0.0f,tempoCDini=0.35294f; //60/170
	//發射體
	public GameObject[] fireBall;
	public GameObject boom,triBall,fourBall,xBall,roundBall,vBall;
	Transform player;
	//stage
	int stageStep=0,changeFlag=0;
	float moveX,moveZ=0f,moveY=1.0f,changeFlag2=0.0f;
	public AudioClip cpySE,readyBoom,hitSE,piSE;
	float hitCD=0f;
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
		PlayingManager.bossCo = 9; //編號9膠囊
		//對話
		mesTimer = 7f;
		if(!GameManager.s4BSee [0]){
			mesText = "居然敢向我挑戰！膽量不錯嘛！";
			GameManager.s4BSee [0] = true;
		}else if(GameManager.openLevel < 4){
			mesText = "哼！真是學不乖！";
		}else{
			int ran = Random.Range(1,4);
			if(ran == 1)
				mesText = "我可沒有要輸的打算！";
			else if(ran == 2)
				mesText = "殺個你片甲不留！";
			else
				mesText = "心裡準備做好了嗎？";
		}
		showMes = true;
	}

	void FixedUpdate () {
		if (worked) {
			//計算拍數
			if(tempoCD<=0){
				pi++;
				tempoCD=tempoCDini;
			}else{
				tempoCD -= 0.02f;
			}
			//**********行為*******************
			//1~9拍 POSE
			if(stageStep==0){
				if(tmpPi!=pi){
					tmpPi=pi;
					if(pi<15){
						if(pi%4==1){
							if(changeFlag==0){
								moveX = -15.0f;
								moveY = 6.0f;
							}else if(changeFlag==1){
								moveX = 15.0f;
							}else if(changeFlag==2){
								moveX = -7.0f;
								moveY = 2f;
							}else if(changeFlag==3){
								moveX = 15.0f;
							}
							changeFlag++;
						}
					}else{
						if(pi%2==1){
							if(changeFlag==4){
								moveX = -20.0f;
								moveY = 4.5f;
							}else if(changeFlag==5){
								moveX = 9.5f;
								moveY = 1f;
							}else if(changeFlag==6){
								moveX = 15f;
								moveY = 3f;
							}else if(changeFlag==7){
								moveX = 8f;
								moveY = 6f;
							}else if(changeFlag==8){
								moveX = -15f;
								moveY = 1f;
							}else if(changeFlag==9){
								moveX = -9.5f;
								moveY = 0f;
							}else if(changeFlag==10){
								moveX = -1.0f;
								moveY = 4;
							}
							changeFlag++;
						}
					}
				}
				this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(moveX,moveY,moveZ),0.1f);

				//看人
				//transform.LookAt(player);
				Vector3 relativePos = player.position-transform.position;
				transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.LookRotation(relativePos),0.1f);

				if(pi>28){
					stageStep=1;
					moveX = 0.0f;
					moveY = 5;
				}
			}
			//9~17拍 向上發射+POSE 30
			if(stageStep==1){
				Vector3 relativePos = player.position-transform.position;
				GameObject testV;
				//發射
				if(pi<46){
					if(tmpPi!=pi){
						tmpPi=pi;
						if(pi%2==0){
							moveX = Random.Range(-4.5f,4.5f);
							moveY = Random.Range(4.0f,6.0f);
							testV = Instantiate(fireBall[Random.Range(0,fireBall.Length)],this.transform.position,new Quaternion(1f,0f,0f,0f))as GameObject;
							testV.rigidbody.velocity = testV.transform.TransformDirection(Vector3.down*20);
							testV = Instantiate(fireBall[Random.Range(0,fireBall.Length)],this.transform.position,new Quaternion(1f,0f,0f,0f))as GameObject;
							testV.rigidbody.velocity = testV.transform.TransformDirection(Vector3.down*20);
							PiSE();
							PiSE();
							PlayingManager.outCount+=2;
						}else{
							moveX = Random.Range(-4.5f,4.5f);
							moveY = Random.Range(4.0f,6.0f);
						}
					}
					//看人
					if(pi==45)
						transform.rotation = new Quaternion(0,0,0,1);
					else
						transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.LookRotation(relativePos),0.1f);
				}else{
					//旋轉
					this.transform.Rotate(0,0,(changeFlag2<-50)?changeFlag2:(changeFlag2--));
					if(pi>52){
						if(pi > 58)
							moveX = Random.Range(-6.5f,6.5f);
						else
							moveX = -15;
					}
				}
				//移動
				this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(moveX,moveY,moveZ),0.1f);

				if(pi>58){
					stageStep=2;
				}
			}
			//17~25拍 三顆 60
			else if(stageStep==2){
				//Vector3 relativePos = player.position-transform.position;
				//發射
				if(tmpPi!=pi){
					tmpPi=pi;
					if(pi<83){
						if(pi%2==0){
							moveX = Random.Range(-6.5f,6.5f);
							moveY = Random.Range(4.0f,6.0f);
							Instantiate(triBall,this.transform.position,new Quaternion(0.7f,0f,0f,0.7f));
							PiSE();
							PlayingManager.outCount+=3;
						}else{
							moveX = Random.Range(-6.5f,6.5f);
							moveY = Random.Range(4.0f,6.0f);
						}
					}else{
						//向上發
						GameObject testV;
						moveX = Random.Range(-4.5f,4.5f);
						moveY = Random.Range(4.0f,6.0f);
						testV = Instantiate(fireBall[Random.Range(0,fireBall.Length)],this.transform.position,new Quaternion(1f,0f,0f,0f))as GameObject;
						testV.rigidbody.velocity = testV.transform.TransformDirection(Vector3.down*20);
						testV = Instantiate(fireBall[Random.Range(0,fireBall.Length)],this.transform.position,new Quaternion(1f,0f,0f,0f))as GameObject;
						testV.rigidbody.velocity = testV.transform.TransformDirection(Vector3.down*20);
						PiSE();
						PlayingManager.outCount+=2;
					}
				}
				//旋轉
				this.transform.Rotate(0,0,changeFlag2);
				//移動
				this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(moveX,moveY,moveZ),0.1f);
				
				if(pi>88){
					stageStep=3;
				}
			}
			//25~29拍 四方 90
			else if(stageStep==3){
				//Vector3 relativePos = player.position-transform.position;
				//發射
				if(tmpPi!=pi){
					tmpPi=pi;
					if(pi%4==2){
						moveX = Random.Range(-6.5f,6.5f);
						moveY = Random.Range(4.0f,6.0f);
						int tmp=Random.Range(1,6);
						if(tmp==1){
							Instantiate(xBall,this.transform.position,new Quaternion(0.7f,0f,0f,0.7f));
							PiSE();
							PlayingManager.outCount+=5;
						}else if(tmp==2){
							Instantiate(fourBall,this.transform.position,new Quaternion(0.7f,0f,0f,0.7f));
							PiSE();
							PlayingManager.outCount+=4;
						}else if(tmp==3){
							Instantiate(triBall,this.transform.position,new Quaternion(0.7f,0f,0f,0.7f));
							PiSE();
							PlayingManager.outCount+=3;
						}else if(tmp==4){
							Instantiate(vBall,this.transform.position,new Quaternion(0.7f,0f,0f,0.7f));
							PiSE();
							PlayingManager.outCount+=5;
						}else if(tmp==5){
							Instantiate(roundBall,this.transform.position,new Quaternion(0.5f,0.5f,-0.5f,0.5f));
							PiSE();
							PlayingManager.outCount+=5;
						}
					}else{
						moveX = Random.Range(-6.5f,6.5f);
						moveY = Random.Range(4.0f,6.0f);
					}
				}
				//旋轉
				this.transform.Rotate(0,0,changeFlag2);
				//移動
				this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(moveX,moveY,moveZ),0.1f);
				
				if(pi>102){
					stageStep=4;
				}
			}
			//29~37拍 X球 104
			else if(stageStep==4){
				//Vector3 relativePos = player.position-transform.position;
				//發射
				if(tmpPi!=pi){
					tmpPi=pi;
					if(pi<127){
						if(pi%2==1){
							moveX = Random.Range(-6.5f,6.5f);
							moveY = Random.Range(4.0f,6.0f);
							int tmp=Random.Range(1,6);
							if(tmp==1){
								Instantiate(xBall,this.transform.position,new Quaternion(0.7f,0f,0f,0.7f));
								PiSE();
								PlayingManager.outCount+=5;
							}else if(tmp==2){
								Instantiate(fourBall,this.transform.position,new Quaternion(0.7f,0f,0f,0.7f));
								PiSE();
								PlayingManager.outCount+=4;
							}else if(tmp==3){
								Instantiate(triBall,this.transform.position,new Quaternion(0.7f,0f,0f,0.7f));
								PiSE();
								PlayingManager.outCount+=3;
							}else if(tmp==4){
								Instantiate(vBall,this.transform.position,new Quaternion(0.7f,0f,0f,0.7f));
								PiSE();
								PlayingManager.outCount+=5;
							}else if(tmp==5){
								Instantiate(roundBall,this.transform.position,new Quaternion(0.5f,0.5f,-0.5f,0.5f));
								PiSE();
								PlayingManager.outCount+=5;
							}
						}else{
							moveX = Random.Range(-6.5f,6.5f);
							moveY = Random.Range(4.0f,6.0f);
						}
					}else{
						//向上發
						GameObject testV;
						moveX = Random.Range(-4.5f,4.5f);
						moveY = Random.Range(4.0f,6.0f);
						testV = Instantiate(fireBall[Random.Range(0,fireBall.Length)],this.transform.position,new Quaternion(1f,0f,0f,0f))as GameObject;
						testV.rigidbody.velocity = testV.transform.TransformDirection(Vector3.down*20);
						testV = Instantiate(fireBall[Random.Range(0,fireBall.Length)],this.transform.position,new Quaternion(1f,0f,0f,0f))as GameObject;
						testV.rigidbody.velocity = testV.transform.TransformDirection(Vector3.down*20);
						PiSE();
						PlayingManager.outCount+=2;
					}
				}
				//旋轉
				this.transform.Rotate(0,0,changeFlag2);
				//移動
				this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(moveX,moveY,moveZ),0.1f);
				
				if(pi>132){
					stageStep=5;
					moveY=3;
				}
			}
			//37~45拍 單發+四方 134
			else if(stageStep==5){
				//Vector3 relativePos = player.position-transform.position;
				//發射
				if(tmpPi!=pi){
					tmpPi=pi;
					if(pi<150){
						moveX = Random.Range(-6.5f,6.5f);
						moveY++;
						Instantiate(fireBall[Random.Range(0,fireBall.Length)],this.transform.position,Quaternion.identity);
						PiSE();
						PlayingManager.outCount++;
					}else{
						//if(pi==150)
						//	moveY=5f;
						if(pi%4==1){
							moveX = Random.Range(-6.5f,6.5f);
							moveY = Random.Range(4.0f,6.0f);
							int tmp=Random.Range(1,6);
							if(tmp==1){
								Instantiate(xBall,this.transform.position,new Quaternion(0.7f,0f,0f,0.7f));
								PiSE();
								PlayingManager.outCount+=5;
							}else if(tmp==2){
								Instantiate(fourBall,this.transform.position,new Quaternion(0.7f,0f,0f,0.7f));
								PiSE();
								PlayingManager.outCount+=4;
							}else if(tmp==3){
								Instantiate(triBall,this.transform.position,new Quaternion(0.7f,0f,0f,0.7f));
								PiSE();
								PlayingManager.outCount+=3;
							}else if(tmp==4){
								Instantiate(vBall,this.transform.position,new Quaternion(0.7f,0f,0f,0.7f));
								PiSE();
								PlayingManager.outCount+=5;
							}else if(tmp==5){
								Instantiate(roundBall,this.transform.position,new Quaternion(0.5f,0.5f,-0.5f,0.5f));
								PiSE();
								PlayingManager.outCount+=5;
							}
						}else{
							moveX = Random.Range(-6.5f,6.5f);
							moveY = Random.Range(4.0f,6.0f);
						}
					}
				}
				//旋轉
				this.transform.Rotate(0,0,changeFlag2);
				//移動
				this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(moveX,moveY,moveZ),0.1f);
				
				if(pi>162){
					stageStep=6;
					moveY = -3.5f;
				}
			}
			//45~53拍 下來見人 164
			else if(stageStep==6){
				Vector3 relativePos = player.position-transform.position;
				//發射
				if(tmpPi!=pi){
					tmpPi=pi;
					if(pi%4==0){
						if(pi>179){
							Instantiate(roundBall,this.transform.position,Quaternion.LookRotation(relativePos));
							PiSE();
							PlayingManager.outCount+=5;
						}
						moveY = -3.5f;
					}else{
						moveY = Random.Range(4.0f,6.0f);
						moveX = Random.Range(-10.0f,10.0f);
					}
				}
				//旋轉
				this.transform.Rotate(0,0,changeFlag2);
				//移動
				this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(moveX,moveY,moveZ),0.1f);
				
				if(pi>192){
					stageStep=7;
					moveY=3;
				}
			}
			//53~61拍 單發+V 194
			else if(stageStep==7){
				//Vector3 relativePos = player.position-transform.position;
				//發射
				if(tmpPi!=pi){
					tmpPi=pi;
					if(pi<208){
						moveX = Random.Range(-6.5f,6.5f);
						moveY++;
						Instantiate(fireBall[Random.Range(0,fireBall.Length)],this.transform.position,Quaternion.identity);
						PiSE();
						PlayingManager.outCount++;
					}else{
						//if(pi==220)
						//	moveY=5;
						if(pi%4==0){
							moveX = Random.Range(-6.5f,6.5f);
							moveY = Random.Range(4.0f,6.0f);
							int tmp=Random.Range(1,6);
							if(tmp==1){
								Instantiate(xBall,this.transform.position,new Quaternion(0.7f,0f,0f,0.7f));
								PiSE();
								PlayingManager.outCount+=5;
							}else if(tmp==2){
								Instantiate(fourBall,this.transform.position,new Quaternion(0.7f,0f,0f,0.7f));
								PiSE();
								PlayingManager.outCount+=4;
							}else if(tmp==3){
								Instantiate(triBall,this.transform.position,new Quaternion(0.7f,0f,0f,0.7f));
								PiSE();
								PlayingManager.outCount+=3;
							}else if(tmp==4){
								Instantiate(vBall,this.transform.position,new Quaternion(0.7f,0f,0f,0.7f));
								PiSE();
								PlayingManager.outCount+=5;
							}else if(tmp==5){
								Instantiate(roundBall,this.transform.position,new Quaternion(0.5f,0.5f,-0.5f,0.5f));
								PiSE();
								PlayingManager.outCount+=5;
							}
						}else{
							moveX = Random.Range(-6.5f,6.5f);
							moveY = Random.Range(4.0f,6.0f);
						}
					}
				}
				//旋轉
				this.transform.Rotate(0,0,changeFlag2);
				//移動
				this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(moveX,moveY,moveZ),0.1f);
				
				if(pi>222){
					stageStep=8;
				}
			}
			//61~69拍 隨機球 224
			else if(stageStep==8){
				//Vector3 relativePos = player.position-transform.position;
				//發射
				if(tmpPi!=pi){
					tmpPi=pi;
					if(pi<245){
						if(pi%2==0){
							moveX = Random.Range(-6.5f,6.5f);
							moveY = Random.Range(4.0f,6.0f);
							int tmp=Random.Range(1,6);
							if(tmp==1){
								Instantiate(xBall,this.transform.position,new Quaternion(0.7f,0f,0f,0.7f));
								PiSE();
								PlayingManager.outCount+=5;
							}else if(tmp==2){
								Instantiate(fourBall,this.transform.position,new Quaternion(0.7f,0f,0f,0.7f));
								PiSE();
								PlayingManager.outCount+=4;
							}else if(tmp==3){
								Instantiate(triBall,this.transform.position,new Quaternion(0.7f,0f,0f,0.7f));
								PiSE();
								PlayingManager.outCount+=3;
							}else if(tmp==4){
								Instantiate(vBall,this.transform.position,new Quaternion(0.7f,0f,0f,0.7f));
								PiSE();
								PlayingManager.outCount+=5;
							}else if(tmp==5){
								Instantiate(roundBall,this.transform.position,new Quaternion(0.5f,0.5f,-0.5f,0.5f));
								PiSE();
								PlayingManager.outCount+=5;
							}
						}else{
							moveX = Random.Range(-6.5f,6.5f);
							moveY = Random.Range(4.0f,6.0f);
						}
					}else{
						//向上發
						GameObject testV;
						moveX = Random.Range(-4.5f,4.5f);
						moveY = Random.Range(4.0f,6.0f);
						testV = Instantiate(fireBall[Random.Range(0,fireBall.Length)],this.transform.position,new Quaternion(1f,0f,0f,0f))as GameObject;
						testV.rigidbody.velocity = testV.transform.TransformDirection(Vector3.down*20);
						testV = Instantiate(fireBall[Random.Range(0,fireBall.Length)],this.transform.position,new Quaternion(1f,0f,0f,0f))as GameObject;
						testV.rigidbody.velocity = testV.transform.TransformDirection(Vector3.down*20);
						PiSE();
						PlayingManager.outCount+=2;
					}
				}
				//旋轉
				this.transform.Rotate(0,0,changeFlag2);
				//移動
				this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(moveX,moveY,moveZ),0.1f);
				
				if(pi>250){
					stageStep=9;
					moveY=3;
				}
			}
			//69~73拍 隨機 (完) 252
			else if(stageStep==9){
				Vector3 relativePos = player.position-transform.position;
				GameObject testV;
				//發射
				if(tmpPi!=pi){
					tmpPi=pi;
					moveX = Random.Range(-10.0f,10.0f);
					moveY++;
					testV = Instantiate(fireBall[Random.Range(0,fireBall.Length)],this.transform.position,Quaternion.LookRotation(relativePos)) as GameObject;
					testV.rigidbody.velocity = testV.transform.TransformDirection(Vector3.forward * 20);
					testV = Instantiate(fireBall[Random.Range(0,fireBall.Length)],this.transform.position,Quaternion.LookRotation(relativePos+Vector3.right)) as GameObject;
					testV.rigidbody.velocity = testV.transform.TransformDirection(Vector3.forward * 20);
					testV = Instantiate(fireBall[Random.Range(0,fireBall.Length)],this.transform.position,Quaternion.LookRotation(relativePos+Vector3.left)) as GameObject;
					testV.rigidbody.velocity = testV.transform.TransformDirection(Vector3.forward * 20);
					PiSE();
					PlayingManager.outCount+=3;
				}
				//旋轉
				this.transform.Rotate(0,0,changeFlag2);
				//移動
				this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(moveX,moveY,moveZ),0.1f);
				
				if(pi>266){
					stageStep=2;
					pi=59;
				}
			}

			//**********行為END*******************
			//閃紅恢復
			/*
			if (blinkRed) {
				if(renderer.material.color.r > 254){
					renderer.material.color = Color.white;
					blinkRed=false;
				}else{
					renderer.material.color = Color.Lerp(renderer.material.color,Color.white,0.1f);
				}
			}
			*/
			//第二階段
			/*
			if(!phase2 && HPcolor.HPsum >= 6030) {
				//Stage1Boss.cpy=true;
				AudioSource.PlayClipAtPoint(cpySE,Vector3.zero);
				Instantiate(CpyS1Boss,this.transform.position,Quaternion.identity);
				phase2=true;
			}
			if(!phase3 && HPcolor.HPsum >= 6700) {
				//Stage1Boss.cpy=false;
				AudioObj.spStop=true;
				AudioSource.PlayClipAtPoint(cpySE,Vector3.zero);
				//Stage3Boss.cpy=true;
				Instantiate(CpyS3Boss,new Vector3(6.5f,4.5f,moveZ),Quaternion.identity);
				phase3=true;
			}
			*/
			if(hitCD > 0f)
				hitCD -= 0.02f;
			//Boss死亡
			if (PlayingManager.endIn) {
				GameManager.playerExp += PlayingManager.bossGetExp;
				GameManager.money += PlayingManager.bossGetMoney;
				if(GameManager.openLevel < 5)
					GameManager.openLevel = 5;
				//對話
				labFoSi = Mathf.RoundToInt((float)labFoSi * 1.2f);
				mesTimer = 3f;
				mesText = "不該是這樣的！！！";
				showMes = true;
				//清場
				FireBall.bossFireBall=true;
				//爆炸
				AudioSource.PlayClipAtPoint(readyBoom,Vector3.one);
				GameObject testV;
				testV = Instantiate(boom,new Vector3(transform.position.x,transform.position.y,0f),Quaternion.identity) as GameObject;
				testV.transform.parent = this.transform;
				//this.GetComponent<Stage4Boss>().enabled=false;
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
			GUI.Window(4,mesRect,mesWindow,GameManager.BossName(9));
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
				//renderer.material.color = Color.red;
				//blinkRed=true;
				transform.Translate(0,1,0,Space.World);
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
				hitCD = 0.2f;
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
