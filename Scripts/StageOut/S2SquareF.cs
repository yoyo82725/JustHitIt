using UnityEngine;
using System.Collections;

public class S2SquareF : MonoBehaviour {
	bool blinkRed=false,worked=true;
	//拍數,不連發
	int pi=0,tmpPi=-1;
	//發射間隔
	float tempoCD=0f,tempoCDini=0.375f; //60.0f/160.0f
	//發射體
	public GameObject capsule;
	public GameObject[] fireBall;
	public GameObject boom,fourBall,vBall,roundBall;
	Transform player;
	//stage
	int stageStep=0,changeFlag=0;
	float moveX,moveY=5.0f,fireZ=0f;
	//風
	public GameObject toLwind,toRwind;
	//模型
	public bool cpy = false;
	Color iniColor;
	public AudioClip p2SE,readyBoom,hitSE,piSE;
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
		AudioSource.PlayClipAtPoint(p2SE,Vector3.one);
		FireBall.bossFireBall=false;
		iniColor = this.transform.GetChild (0).renderer.material.color;
		if(!cpy){
			PlayingManager.bossCo = 6; //編號6方半
			//對話
			mesTimer = 5f;
			if(!GameManager.s2BSee [2]){
				mesText = "你.....迷路了嗎.....";
				GameManager.s2BSee [2] = true;
			}else{
				int ran = Random.Range(1,4);
				if(ran == 1)
					mesText = "我們的計畫會繼續下去......";
				else if(ran == 2)
					mesText = "喀喀喀喀.......";
				else
					mesText = "真敢來阿.......";
			}
			showMes = true;
		}
	}
	
	void FixedUpdate () {
		if (worked) {
			//**********行為*******************
			//1~9拍 風吹
			if (stageStep == 0) {
				if(tmpPi!=pi){
					tmpPi=pi;
					if(pi%8==0){
						//風吹
						S2wind();
					}
				}
				
				if(pi>29){
					//進入下階
					stageStep=1;
					changeFlag=0;
				}
			}
			//9~26拍 POSE
			else if(stageStep==1){
				//出現
				if(pi<34){
					transform.position = Vector3.Lerp(transform.position,new Vector3(0,3.5f,0.0f),0.1f);
				}
				//消失
				else if(pi<41){
					transform.position = Vector3.Lerp(transform.position,new Vector3(0,3.5f,-12.0f),0.1f);
				}
				//閃身
				else if(pi<59){
					if(pi%2==0){
						if(tmpPi!=pi){
							tmpPi=pi;
							//風吹
							if(pi==42 || pi==50)
								S2wind();
							//隨機移動
							if(pi==58)
								moveX=0;
							else
								moveX = (Random.Range(-6.5f,6.5f));
							transform.position = new Vector3(moveX,3.5f,transform.position.z);
							changeFlag=(changeFlag+1)%2;
						}
						if(changeFlag==0){
							transform.position = Vector3.Lerp(transform.position,new Vector3(moveX,3.5f,-12.0f),0.1f);
						}else{
							transform.position = Vector3.Lerp(transform.position,new Vector3(moveX,3.5f,0f),0.1f);
						}
					}
				}
				//旋轉
				else if(pi<64){
					transform.Rotate(0f,((changeFlag<50)?changeFlag++:changeFlag),0f);
				}
				//看人
				else if(pi<72){
					transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.LookRotation(new Vector3(player.position.x,player.position.y,-7f)),0.2f);
				}
				//隱形
				else if(pi<80){
					transform.position = Vector3.Lerp(transform.position,new Vector3(moveX,3.5f,-12.0f),0.1f);
				}
				//移動至定位
				else if(pi<86){
					transform.position = new Vector3(15.0f,5.5f,-12.0f);
					changeFlag=0;
				}
				//旋轉入場
				else if(pi<93){
					transform.position = Vector3.Lerp(transform.position,new Vector3(-4.0f,5f,0f),0.1f);
					transform.Rotate(0,((changeFlag<50)?changeFlag++:changeFlag),0);
				}
				//看人
				else{
					transform.rotation = Quaternion.LookRotation(new Vector3(player.position.x,player.position.y,-7f));
				}
				
				if(pi>93){
					//進入下階
					stageStep=2;
					tmpPi=0; //吹風用
					changeFlag=0;
				}
			}
			//26~34拍 風+隱出掃射
			else if(stageStep==2){
				if(tmpPi!=pi){ //每一拍
					tmpPi=pi;
					//吹風
					if(pi==94)
						S2wind();
					//隨機移動
					else if(pi<101)
						moveX = (Random.Range(-6.0f,6.0f));
					else
						moveX = (Random.Range(-6.5f,6.5f));
					moveY = Random.Range(4.3f,6.3f);
					transform.position = new Vector3(moveX,moveY,transform.position.z);
					changeFlag=(changeFlag+1)%2;
					//發射
					if(pi<103){
						if(pi%2==0){
							this.transform.Rotate(180f,0f,0f);
							Instantiate(capsule,new Vector3(transform.position.x,transform.position.y,fireZ),Quaternion.identity);
							PiSE();
							PlayingManager.outCount++;
						}
					}else{
						if(pi<124){
							this.transform.Rotate(180f,0f,0f);
							Instantiate(capsule,new Vector3(transform.position.x,transform.position.y,fireZ),Quaternion.identity);
							PiSE();
							PlayingManager.outCount++;
						}
					}
				}
				if(changeFlag==0){
					transform.position = Vector3.Lerp(transform.position,new Vector3(moveX,moveY,-12.0f),0.1f);
				}else{
					transform.position = Vector3.Lerp(transform.position,new Vector3(moveX,moveY,0f),0.1f);
				}
				//看人
				transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.LookRotation(new Vector3(player.position.x,player.position.y,-7f)),0.2f);
				
				if(pi>123){
					//進入下階
					stageStep=3;
					tmpPi=0; //吹風用
				}
			}
			//34~42拍 風+向玩家發三
			else if(stageStep==3){
				
				if(tmpPi!=pi){ //每一拍
					tmpPi=pi;
					//吹風
					if(pi==124)
						S2wind();
					//向玩家發射
					//三發
					if(pi<141){
						if(pi%2==0){
							this.transform.Rotate(0f,180f,0f);
							Vector3 relativePos = player.position-new Vector3(this.transform.position.x,this.transform.position.y,0f);
							//Ghost.animation.CrossFade("rightAtk",0.2f);
							Instantiate(fireBall[fireBall.Length-1],new Vector3(transform.position.x,transform.position.y,fireZ),Quaternion.LookRotation(relativePos+Vector3.right));
							Instantiate(fireBall[fireBall.Length-1],new Vector3(transform.position.x,transform.position.y,fireZ),Quaternion.LookRotation(relativePos));
							Instantiate(fireBall[fireBall.Length-1],new Vector3(transform.position.x,transform.position.y,fireZ),Quaternion.LookRotation(relativePos+Vector3.left));
							PiSE();
							PlayingManager.outCount+=3;
						}
					}else{
						if(pi!=154){
							if(pi%2==0){
								this.transform.Rotate(0f,180f,0f);
								Vector3 relativePos = player.position-new Vector3(this.transform.position.x,this.transform.position.y,0f);
								//Ghost.animation.CrossFade("rightAtk",0.2f);
								Instantiate(fireBall[fireBall.Length-1],new Vector3(transform.position.x,transform.position.y,fireZ),Quaternion.LookRotation(relativePos+Vector3.right+Vector3.right));
								Instantiate(fireBall[fireBall.Length-1],new Vector3(transform.position.x,transform.position.y,fireZ),Quaternion.LookRotation(relativePos+Vector3.right));
								Instantiate(fireBall[fireBall.Length-1],new Vector3(transform.position.x,transform.position.y,fireZ),Quaternion.LookRotation(relativePos));
								Instantiate(fireBall[fireBall.Length-1],new Vector3(transform.position.x,transform.position.y,fireZ),Quaternion.LookRotation(relativePos+Vector3.left));
								Instantiate(fireBall[fireBall.Length-1],new Vector3(transform.position.x,transform.position.y,fireZ),Quaternion.LookRotation(relativePos+Vector3.left+Vector3.left));
								PiSE();
								PiSE();
								PlayingManager.outCount+=5;
							}
						}
					}
					//隨機移動
					if(pi<131)
						moveX = (Random.Range(-6.0f,6.0f));
					else
						moveX = (Random.Range(-6.5f,6.5f));
					moveY = Random.Range(4.3f,6.3f);
					transform.position = new Vector3(moveX,moveY,transform.position.z);
					changeFlag=(changeFlag+1)%2;
				}
				//隱出
				if(changeFlag==0){
					transform.position = Vector3.Lerp(transform.position,new Vector3(moveX,moveY,-12.0f),0.1f);
				}else{
					transform.position = Vector3.Lerp(transform.position,new Vector3(moveX,moveY,0f),0.1f);
				}
				//看人
				transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.LookRotation(new Vector3(player.position.x,player.position.y,-7f)),0.2f);
				
				if(pi>153){
					//進入下階
					stageStep=4;
					tmpPi=0; //吹風用
					FireBall.moveFlag=0;
					changeFlag=(changeFlag+1)%2;
				}
			}
			//42~50拍 風吹+左右晃
			else if(stageStep==4){
				if(tmpPi!=pi){ //每一拍
					tmpPi=pi;
					//吹風
					if(pi==154)
						S2wind();
					FireBall.LRmove=true;
					//掉落
					if(pi<170){
						if(pi%2==0){
							Instantiate(fireBall[Random.Range(0,fireBall.Length-1)],new Vector3(transform.position.x,transform.position.y,fireZ),Quaternion.identity);
							PiSE();
							PlayingManager.outCount++;
							FireBall.moveFlag = (FireBall.moveFlag+1)%2;
						}
					}else{
						if(pi!=184){
							if(pi%2==0){
								Instantiate(fireBall[Random.Range(0,fireBall.Length-1)],new Vector3(transform.position.x+1,transform.position.y,fireZ),Quaternion.identity);
								Instantiate(fireBall[Random.Range(0,fireBall.Length-1)],new Vector3(transform.position.x-1,transform.position.y,fireZ),Quaternion.identity);
								PiSE();
								PlayingManager.outCount+=2;
								FireBall.moveFlag = (FireBall.moveFlag+1)%2;
							}
							
						}
					}
					//隨機移動
					if(pi<161)
						moveX = (Random.Range(-6.0f,6.0f));
					else
						moveX = (Random.Range(-6.5f,6.5f));
					moveY = Random.Range(4.3f,6.3f);
					transform.position = new Vector3(moveX,moveY,transform.position.z);
					tmpPi=pi;
					changeFlag=(changeFlag+1)%2;
				}
				//隱出
				if(changeFlag==0){
					transform.position = Vector3.Lerp(transform.position,new Vector3(moveX,moveY,-12.0f),0.1f);
				}else{
					transform.position = Vector3.Lerp(transform.position,new Vector3(moveX,moveY,0f),0.1f);
				}
				//看人
				transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.LookRotation(new Vector3(player.position.x,player.position.y,-7f)),0.2f);
				
				if(pi>183){
					//進入下階
					stageStep=5;
					tmpPi=0; //吹風用
					changeFlag=(changeFlag+1)%2;
				}
			}
			//50~58拍 風+四方 184
			else if(stageStep==5){
				if(tmpPi!=pi){ //每一拍
					tmpPi=pi;
					//吹風
					if(pi==184)
						S2wind();
					//掉落
					if(pi!=214){
						if(pi%2==0){
							Instantiate(fourBall,new Vector3(transform.position.x,transform.position.y,fireZ),new Quaternion((Random.Range(-1f,1f)),(Random.Range(-1f,1f)),0,0));
							PiSE();
							PlayingManager.outCount+=4;
						}
					}
					//隨機移動
					if(pi<191)
						moveX = (Random.Range(-6.0f,6.0f));
					else
						moveX = (Random.Range(-6.5f,6.5f));
					moveY = Random.Range(4.3f,6.3f);
					transform.position = new Vector3(moveX,moveY,transform.position.z);
					tmpPi=pi;
					changeFlag=(changeFlag+1)%2;
				}
				//隱出
				if(changeFlag==0){
					transform.position = Vector3.Lerp(transform.position,new Vector3(moveX,moveY,-12.0f),0.1f);
				}else{
					transform.position = Vector3.Lerp(transform.position,new Vector3(moveX,moveY,0f),0.1f);
				}
				//看人
				transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.LookRotation(new Vector3(player.position.x,player.position.y,-7f)),0.2f);
				
				
				if(pi>213){
					//進入下階
					stageStep=6;
					tmpPi=0; //吹風用
					changeFlag=(changeFlag+1)%2;
					FireBall.LRmove=false;
				}
			}
			//58~66拍 風+V字射玩家 214
			else if(stageStep==6){
				//看人
				transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.LookRotation(new Vector3(player.position.x,player.position.y,-7f)),0.2f);
				if(tmpPi!=pi){ //每一拍
					tmpPi=pi;
					//吹風
					if(pi==214)
						S2wind();
					//掉落
					if(pi!=244){
						if(pi%2==0){
							Vector3 relativePos = player.position-new Vector3(this.transform.position.x,this.transform.position.y,0f);
							this.transform.Rotate(0f,180f,0f);
							Instantiate(vBall,new Vector3(transform.position.x,transform.position.y,fireZ),Quaternion.LookRotation(relativePos+new Vector3((Random.Range(-3.0f,3.0f)),0,0)));
							PiSE();
							PiSE();
							PlayingManager.outCount+=5;
						}
					}
					//隨機移動
					if(pi<219)
						moveX = (Random.Range(-6.0f,6.0f));
					else
						moveX = (Random.Range(-6.5f,6.5f));
					moveY = Random.Range(4.3f,6.3f);
					transform.position = new Vector3(moveX,moveY,transform.position.z);
					tmpPi=pi;
					changeFlag=(changeFlag+1)%2;
				}
				//隱出
				if(changeFlag==0){
					transform.position = Vector3.Lerp(transform.position,new Vector3(moveX,moveY,-12.0f),0.1f);
				}else{
					transform.position = Vector3.Lerp(transform.position,new Vector3(moveX,moveY,0f),0.1f);
				}
				
				if(pi>243){
					//進入下階
					stageStep=7;
					tmpPi=0; //吹風用
					changeFlag=(changeFlag+1)%2;
					FireBall.moveFlag = 0;
					FireBall.LRmove=true;
				}
			}
			//66~74拍 風+左右+隨機 244
			else if(stageStep==7){
				if(tmpPi!=pi){ //每一拍
					tmpPi=pi;
					//吹風
					if(pi==244)
						S2wind();
					//掉落
					//左右
					if(pi<259){
						if(pi%2==0){
							Instantiate(fireBall[Random.Range(0,fireBall.Length-1)],new Vector3(transform.position.x+1,transform.position.y,fireZ),Quaternion.identity);
							Instantiate(fireBall[Random.Range(0,fireBall.Length-1)],new Vector3(transform.position.x-1,transform.position.y,fireZ),Quaternion.identity);
							FireBall.moveFlag = (FireBall.moveFlag+1)%2;
							PiSE();
							PlayingManager.outCount+=2;
						}
					}else{
						//隨機
						this.transform.Rotate(180f,0f,0f);
						Instantiate(capsule,new Vector3(transform.position.x,transform.position.y,fireZ),Quaternion.identity);
						PiSE();
						PlayingManager.outCount++;
					}
					
					//隨機移動
					if(pi<251)
						moveX = (Random.Range(-6.0f,6.0f));
					else
						moveX = (Random.Range(-6.5f,6.5f));
					moveY = Random.Range(4.3f,6.3f);
					transform.position = new Vector3(moveX,moveY,transform.position.z);
					tmpPi=pi;
					changeFlag=(changeFlag+1)%2;
				}
				//隱出
				if(changeFlag==0){
					transform.position = Vector3.Lerp(transform.position,new Vector3(moveX,moveY,-12.0f),0.1f);
				}else{
					transform.position = Vector3.Lerp(transform.position,new Vector3(moveX,moveY,0f),0.1f);
				}
				//看人
				transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.LookRotation(new Vector3(player.position.x,player.position.y,-7f)),0.2f);
				
				if(pi>271){
					//進入下階
					FireBall.LRmove=false;
					stageStep=8;
					tmpPi=0; //吹風用
				}
			}
			//74~82拍 移過玩家上方 275
			else if(stageStep==8){
				//左上移出
				if(pi<273){
					this.transform.position = Vector3.Lerp(transform.position,new Vector3(-15.0f,5.5f,0f),0.1f);
				}
				//送至右上
				else if(pi<274){
					this.transform.position = new Vector3(15.0f,5.2f,0f);
				}
				//右上至左上移動
				else if(pi<279){
					this.transform.position = Vector3.Lerp(transform.position,new Vector3(-15.0f,3.5f,0f),0.1f);
				}
				//移至左下
				else if(pi<282){
					this.transform.position = new Vector3(-15.0f,-0.5f,0f);
				}
				//左下至右下移動
				else if(pi<285){
					this.transform.position = Vector3.Lerp(transform.position,new Vector3(15.0f,-0.5f,0f),0.04f);
				}
				//移至左上
				else if(pi<286){
					this.transform.position = new Vector3(-15.0f,5.2f,0f);
				}
				//左上至右上
				else if(pi<289){
					this.transform.position = Vector3.Lerp(transform.position,new Vector3(15.0f,3.5f,0f),0.1f);
				}
				//移至右下
				else if(pi<290){
					this.transform.position = new Vector3(15.0f,-0.5f,0f);
				}
				//右下至左下移動
				else if(pi<293){
					this.transform.position = Vector3.Lerp(transform.position,new Vector3(-15.0f,-0.5f,0f),0.04f);
				}
				//移至左上
				else if(pi<294){
					this.transform.position = new Vector3(-15.0f,5.5f,0f);
				}
				//移進場景
				else if(pi<295){
					this.transform.position = Vector3.Lerp(transform.position,new Vector3(0.0f,4.0f,0f),0.1f);
				}
				//至發射點
				else if(pi<299){
					this.transform.position = Vector3.Lerp(transform.position,new Vector3(-4.0f,5.0f,0.0f),0.1f);
				}
				//隱形
				else if(pi<303){
					this.transform.position = Vector3.Lerp(transform.position,new Vector3(-4.0f,5.0f,-12f),0.1f);
				}
				
				
				//看人
				transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.LookRotation(new Vector3(player.position.x,player.position.y,-7f)),0.2f);
				if(tmpPi!=pi){ //每一拍
					tmpPi=pi;
					//吹風
					if(pi==274)
						S2wind();
				}
				
				if(pi>303){
					//進入下階
					stageStep=9;
					tmpPi=0; //吹風用
					changeFlag=(changeFlag+1)%2;
				}
			}
			//82~90拍 風+圓球 304
			else if(stageStep==9){
				if(tmpPi!=pi){ //每一拍
					tmpPi=pi;
					//吹風
					if(pi==304)
						S2wind();
					//掉落
					if(pi<321){
						if(pi%2==0){
							Instantiate(roundBall,new Vector3(transform.position.x,transform.position.y,fireZ),Quaternion.identity);
							PiSE();
							PiSE();
							PlayingManager.outCount+=5;
						}
					}else{
						if(pi!=335){
							this.transform.Rotate(180f,0f,0f);
							Instantiate(roundBall,new Vector3(transform.position.x,transform.position.y,fireZ),Quaternion.identity);
							PiSE();
							PiSE();
							PlayingManager.outCount+=5;
						}
					}
					//隨機移動
					if(pi<335)
						moveX = (Random.Range(-7.0f,7.0f));
					else
						moveX = (Random.Range(-9.0f,9.0f));
					moveY = Random.Range(4.3f,6.3f);
					transform.position = new Vector3(moveX,moveY,transform.position.z);
					tmpPi=pi;
					changeFlag=(changeFlag+1)%2;
				}
				//隱出
				if(changeFlag==0){
					transform.position = Vector3.Lerp(transform.position,new Vector3(moveX,moveY,-12.0f),0.1f);
				}else{
					transform.position = Vector3.Lerp(transform.position,new Vector3(moveX,moveY,0f),0.1f);
				}
				//看人
				transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.LookRotation(new Vector3(player.position.x,player.position.y,-7f)),0.2f);
				
				if(pi>333){
					//進入下階
					stageStep=10;
				}
			}
			//90~98拍 閃現 334
			else if(stageStep==10){
				if(tmpPi!=pi){ //每一拍
					tmpPi=pi;
					//吹風
					if(pi==334)
						S2wind();
					//隨機移動
					moveX = (Random.Range(-6.5f,6.5f));
					transform.position = new Vector3(moveX,4f,transform.position.z);
					if(pi!=364){
						if(pi%2==0){
							this.transform.Rotate(180f,0f,0f);
							Instantiate(capsule,new Vector3(transform.position.x,transform.position.y,fireZ),Quaternion.identity);
							PiSE();
							PlayingManager.outCount++;
						}
					}
					changeFlag=(changeFlag+1)%2;
				}
				//隱出
				if(changeFlag==0){
					transform.position = Vector3.Lerp(transform.position,new Vector3(moveX,4f,-12.0f),0.1f);
				}else{
					transform.position = Vector3.Lerp(transform.position,new Vector3(moveX,4f,0f),0.1f);
				}
				//正面
				transform.rotation = new Quaternion(0,1,0,0);
				
				if(pi>363){
					//進入下階
					stageStep=11;
					tmpPi=0; //吹風用
					changeFlag=(changeFlag+1)%2;
				}
			}
			//98~106拍 風+四方 (完) 364
			else if(stageStep==11){
				if(tmpPi!=pi){ //每一拍
					tmpPi=pi;
					//吹風
					if(pi==364)
						S2wind();
					//掉落
					if(pi!=396){
						if(pi%2==0){
							//Ghost.animation.CrossFade("rightAtk",0.2f);
							Instantiate(fourBall,new Vector3(transform.position.x,transform.position.y,fireZ),new Quaternion((Random.Range(-1f,1f)),(Random.Range(-1f,1f)),0,0));
							PiSE();
							PiSE();
							PlayingManager.outCount+=4;
						}
					}
					//隨機移動
					if(pi<371)
						moveX = (Random.Range(-6.0f,6.0f));
					else
						moveX = (Random.Range(-6.5f,6.5f));
					moveY = Random.Range(4.3f,6.3f);
					transform.position = new Vector3(moveX,moveY,transform.position.z);
					tmpPi=pi;
					changeFlag=(changeFlag+1)%2;
				}
				//隱出
				if(changeFlag==0){
					transform.position = Vector3.Lerp(transform.position,new Vector3(moveX,moveY,-12.0f),0.1f);
				}else{
					transform.position = Vector3.Lerp(transform.position,new Vector3(moveX,moveY,0f),0.1f);
				}
				//看人
				transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.LookRotation(new Vector3(player.position.x,player.position.y,-7f)),0.2f);
				
				if(pi>393){
					//回頭繼續
					stageStep=2;
					tmpPi=0; //吹風用
					changeFlag=0;
					pi=93;
				}
			}
			
			//**********行為END*******************
			//所有元件閃紅恢復
			if (blinkRed) {
				if(this.transform.GetChild(0).renderer.material.color == iniColor){
					blinkRed=false;
				}else{
					for(int i=0;i<this.transform.childCount;i++){
						this.transform.GetChild(i).renderer.material.color = Color.Lerp(this.transform.GetChild(i).renderer.material.color,iniColor,0.1f);
					}
				}
			}
			if(hitCD>0f)
				hitCD -= 0.02f;
			//Boss死亡
			if (PlayingManager.endIn) {
				FireBall.LRmove=false;
				if(cpy){
					GameManager.playerExp += PlayingManager.bossGetExp/2;
					GameManager.money += PlayingManager.bossGetMoney/2;
				}else{
					GameManager.playerExp += PlayingManager.bossGetExp;
					GameManager.money += PlayingManager.bossGetMoney;
					if(GameManager.openLevel < 3)
						GameManager.openLevel = 3;
					//對話
					labFoSi = Mathf.RoundToInt((float)labFoSi * 1.2f);
					mesTimer = 3f;
					mesText = "~~~~~~~！";
					showMes = true;
					//清場
					FireBall.bossFireBall=true;
				}
				for(int i=0;i<this.transform.childCount;i++){
					this.transform.GetChild(i).renderer.material.color = Color.gray;
				}
				//爆炸
				AudioSource.PlayClipAtPoint(readyBoom,Vector3.one);
				this.transform.position = new Vector3(transform.position.x,transform.position.y,0f);
				GameObject testV;
				testV = Instantiate(boom,new Vector3(transform.position.x,transform.position.y,0f),Quaternion.identity) as GameObject;
				testV.transform.parent = this.transform;
				//this.GetComponent<Stage1Boss>().enabled=false;
				worked = false;
			}
			//計算拍數
			if(tempoCD>0){
				tempoCD -= 0.02f;
			}else{
				pi++;
				tempoCD=tempoCDini;
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
	
	void OnTriggerEnter(Collider other){
		if (Time.timeScale != 0) {
			//被棒子揮到時
			if(other.tag=="sticks" && hitCD<=0){
				//所有元件閃紅 往上位移
				for(int i=0;i<this.transform.childCount;i++){
					this.transform.GetChild(i).renderer.material.color = Color.red;
				}
				blinkRed=true;
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
				AudioSource.PlayClipAtPoint(hitSE,Vector3.one);
				hitCD=0.2f;
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
			GUI.Window(4,mesRect,mesWindow,GameManager.BossName(6));
		}
	}
	void mesWindow(int windowID){
		GUI.skin.label.alignment = TextAnchor.UpperLeft;
		GUI.skin.label.fontSize = labFoSi;
		GUI.Label(mesLabRect,mesText);
	}
	
	void S2wind(){
		if(Random.Range(1,3) == 1)
			Instantiate(toLwind,Vector3.zero,Quaternion.identity);
		else
			Instantiate(toRwind,Vector3.zero,Quaternion.identity);
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
