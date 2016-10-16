using UnityEngine;
using System.Collections;

public class UserScreen : MonoBehaviour {
	bool isDrag;
	public static Transform player;
	//人物移動速度
	public static float speed,iniSpeed; //0.4
	float selfDM = Screen.width * 0.03f;
	float screenRate = Screen.width*0.04545f;
	//旋轉變數
	int forward;//0前1左2右
	//打擊變數
	Vector2 nowPoint,eCXY;
	public static float hitting=0f;
	public static float stickBigBuff=1f;
	float hitPower,hitForward;
	float toBigTime=0.13f,toBigTimeIni=0.13f,helfToBigTime;
	Vector3 stickRIni,stickLIni;
	bool getDown;
	bool rightHit;
	bool smallAtkToBig,midiumAtkToBig,bigAtkToBig;
	public GameObject stickR,stickL;
	float sHitLine = Screen.width * 0.02f;
	float mHitLine = Screen.width * 0.03f;
	float bHitLine = Screen.width * 0.05f;
	//踏步變數
	float stepTime = 0;
	//追尾光
	float LtrailTime=0,RtrailTime=0;
	//音效
	public AudioClip atkSE;
	//球效
	public static Transform lToe;

	// Use this for initialization
	void Awake(){
		player = GameObject.FindGameObjectWithTag("playerCube").transform;
		lToe = GameObject.FindGameObjectWithTag("lToe").transform;
	}
	void Start () {
		stepTime = 0f;
		hitting = -1f;
		stickBigBuff = 1f;
		stickRIni = stickR.transform.localScale;
		stickLIni = stickL.transform.localScale;
		helfToBigTime = toBigTimeIni*0.5f;
		if (GameManager.wearSk1 == 10 || GameManager.wearSk2 == 10 || GameManager.wearSk3 == 10) {
			//sk浪紋疾走
			iniSpeed = (0.4f+(0.008f*GameManager.skLv[9])>1.2f)?1.2f:0.4f+(0.008f*GameManager.skLv[9]);
			if(iniSpeed > 0.799f)
				lToe.GetComponent<TrailRenderer>().enabled=true;
		}else{
			iniSpeed = 0.4f;
		}
		speed = iniSpeed;
	}

	void Update(){
		if(hitting < 0f){
			//鍵盤操作
			if(Input.GetKeyDown(KeyCode.Z)){
				//左打
				//修正面向
				if(forward != 0){
					player.rotation = new Quaternion(0f,0f,0f,1f);
					forward = 0;
				}
				stickL.transform.localScale = stickLIni;
				hitting = 0.19f;
				LtrailTime = 4f;
				rightHit=false;
				bigAtkToBig=true;
				AudioSource.PlayClipAtPoint(atkSE,Vector3.zero,0.5f);
			}else if(Input.GetKeyDown(KeyCode.X)){
				//右打
				//修正面向
				if(forward != 0){
					player.rotation = new Quaternion(0f,0f,0f,1f);
					forward = 0;
				}
				hitting = 0.19f;
				RtrailTime = 4f;
				rightHit=true;
				bigAtkToBig=true;
				AudioSource.PlayClipAtPoint(atkSE,Vector3.zero,0.5f);
			}else if(Input.GetKey(KeyCode.RightArrow)){
				//右走
				player.Translate(speed,0,0,Space.World);
				if(forward != 2){
					player.rotation = new Quaternion(0f,0.7f,0f,0.7f);
					forward = 2;
				}
				footStepSE(1);
				PlayerAn.anName=1;
			}else if(Input.GetKey(KeyCode.LeftArrow)){
				//左走
				player.Translate(-speed,0,0,Space.World);
				if(forward != 1){
					player.rotation = new Quaternion(0f,0.7f,0f,-0.7f);
					forward = 1;
				}
				footStepSE(1);
				PlayerAn.anName=1;
			}else if(Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.X) || Input.GetKeyUp(KeyCode.Z)){
				footStepSE(0);
				//修正面向
				if(forward != 0){
					player.rotation = new Quaternion(0f,0f,0f,1f);
					forward = 0;
				}
				PlayerAn.anName = 0;
			}
			//*******************************移動*******************************
			else if(isDrag){
				//打擊
				if(nowPoint.y - eCXY.y > sHitLine){
					hitting = 0.19f;
					hitPower = Vector2.Distance(eCXY,nowPoint);
					hitForward = nowPoint.x - toScreen(player.position.x);
					//修正面向
					if(forward != 0){
						player.rotation = new Quaternion(0f,0f,0f,1f);
						forward = 0;
					}
					if(hitPower > bHitLine){//最大力
						if(hitForward > 0){//右打
							RtrailTime = 4f;
							rightHit=true;
							bigAtkToBig=true;
						}else{//左打
							LtrailTime = 4f;
							rightHit=false;
							bigAtkToBig=true;
						}
						AudioSource.PlayClipAtPoint(atkSE,Vector3.zero,0.5f);
					}else if(hitPower > mHitLine){//中力
						if(hitForward > 0){//右打
							rightHit=true;
							midiumAtkToBig=true;
						}else{//左打
							rightHit=false;
							midiumAtkToBig=true;
						}
						AudioSource.PlayClipAtPoint(atkSE,Vector3.one,0.5f);
					}else{//最小力
						if(hitForward > 0){//右打
							rightHit=true;
							smallAtkToBig=true;
						}else{//左打
							rightHit=false;
							smallAtkToBig=true;
						}
						AudioSource.PlayClipAtPoint(atkSE,new Vector3(2f,2f,2f),0.5f);
					}
					nowPoint = eCXY;
				}else{
					nowPoint = eCXY;
					//入物移動
					float moveDist=eCXY.x - toScreen(player.position.x);
					//停止移動
					if(Mathf.Abs(moveDist) <= selfDM){
						if(forward != 0){
							player.rotation = new Quaternion(0f,0f,0f,1f);
							forward = 0;
						}
						footStepSE(0);
					}
					//往左走
					else if(moveDist < selfDM){
						player.Translate(-speed,0,0,Space.World);
						if(forward != 1){
							player.rotation = new Quaternion(0f,0.7f,0f,-0.7f);
							forward = 1;
						}
						footStepSE(1);
						PlayerAn.anName=1;
					}
					//往右走
					else if(moveDist > selfDM){
						player.Translate(speed,0,0,Space.World);
						if(forward != 2){
							player.rotation = new Quaternion(0f,0.7f,0f,0.7f);
							forward = 2;
						}
						footStepSE(1);
						PlayerAn.anName=1;
					}
				}
			}
		}else if(isDrag || hitting>0){
			footStepSE(0);
		}
	}

	void FixedUpdate(){
		//踏步
		if(stepTime>0){
			if(hitting > 0)
				PlayerAn.anName = 4;
			if((stepTime -= 0.02f) <= 0)
				PlayerAn.anName = 0;
		}
		//尾徑
		if(LtrailTime>0){
			LtrailTime -= 0.02f;
			stickL.GetComponent<TrailRenderer>().enabled=true;
		}else{
			stickL.GetComponent<TrailRenderer>().enabled=false;
		}
		if(RtrailTime>0){
			RtrailTime -= 0.02f;
			stickR.GetComponent<TrailRenderer>().enabled=true;
		}else{
			stickR.GetComponent<TrailRenderer>().enabled=false;
		}
		//修正位置
		if(player.position.x > 12f)
			player.position = new Vector3(11.5f,player.position.y,player.position.z);
		else if(player.position.x < -12f)
			player.position = new Vector3(-11.5f,player.position.y,player.position.z);
		
		//風吹
		if (LRwind.isWind) {
			if(LRwind.toLwind){//左吹
				player.transform.Translate(-0.035f,0,0,Space.World);
			}else{//右吹
				player.transform.Translate(0.035f,0,0,Space.World);
			}
		}
		if (WindBallWind.isWind) {
			if(WindBallWind.toLwind){//左吹
				player.transform.Translate(-WindBallWind.windFource,0,0,Space.World);
			}else{//右吹
				player.transform.Translate(WindBallWind.windFource,0,0,Space.World);
			}
		}

		//棒子漸漸變大
		if(bigAtkToBig){
			Vector3 changePower = new Vector3(0.18f,0.8f,0.8f) * stickBigBuff;
			//開始變大
			if(toBigTime>0f){
				//右打
				if(rightHit){
					//變大
					if(toBigTime > helfToBigTime){
						PlayerAn.anName=2;
						stickR.transform.localScale += changePower;
					}
					//變小
					else{
						stickR.transform.localScale -= changePower;
					}
				}
				//左打
				else{
					//變大
					if(toBigTime > helfToBigTime){
						PlayerAn.anName=3;
						stickL.transform.localScale += changePower;
					}
					//變小
					else{
						stickL.transform.localScale -= changePower;
					}
				}
				toBigTime -= 0.02f;
			}
			//揮擊結束
			else{
				if(rightHit){
					stickR.transform.localScale = stickRIni;
				}else{
					stickL.transform.localScale = stickLIni;
				}
				stepTime = 1;
				toBigTime = toBigTimeIni;
				bigAtkToBig=false;
			}
		}else if(midiumAtkToBig){
			Vector3 changePower = new Vector3(0.11f,0.5f,0.5f) * stickBigBuff;
			//開始變大
			if(toBigTime>0){
				//右打
				if(rightHit){
					//變大
					if(toBigTime > helfToBigTime){
						PlayerAn.anName=2;
						stickR.transform.localScale += changePower;
					}
					//變小
					else{
						stickR.transform.localScale -= changePower;
					}
				}
				//左打
				else{
					//變大
					if(toBigTime > helfToBigTime){
						PlayerAn.anName=3;
						stickL.transform.localScale += changePower;
					}
					//變小
					else{
						stickL.transform.localScale -= changePower;
					}
				}
				toBigTime -= 0.02f;
			}
			//揮擊結束
			else{
				if(rightHit){
					stickR.transform.localScale = stickRIni;
				}else{
					stickL.transform.localScale = stickLIni;
				}
				stepTime = 1;
				toBigTime = toBigTimeIni;
				midiumAtkToBig=false;
			}
		}else if(smallAtkToBig){
			Vector3 changePower = new Vector3(0.06f,0.3f,0.3f) * stickBigBuff;
			//開始變大
			if(toBigTime>0){
				//右打
				if(rightHit){
					//變大
					if(toBigTime > helfToBigTime){
						PlayerAn.anName=2;
						stickR.transform.localScale += changePower;
					}
					//變小
					else{
						stickR.transform.localScale -= changePower;
					}
				}
				//左打
				else{
					//變大
					if(toBigTime > helfToBigTime){
						PlayerAn.anName=3;
						stickL.transform.localScale += changePower;
					}
					//變小
					else{
						stickL.transform.localScale -= changePower;
					}
				}
				toBigTime -= 0.02f;
			}
			//揮擊結束
			else{
				if(rightHit){
					stickR.transform.localScale = stickRIni;
				}else{
					stickL.transform.localScale = stickLIni;
				}
				stepTime = 1;
				toBigTime = toBigTimeIni;
				smallAtkToBig=false;
			}
		}
		if(hitting>0f)
			hitting -= 0.02f;
	}

	void OnMouseDown() {
		getDown=true;
	}
	void OnMouseUp() {
		isDrag=false;
		footStepSE(0);
		//修正面向
		if(forward != 0){
			player.rotation = new Quaternion(0f,0f,0f,1f);
			forward = 0;
		}
		PlayerAn.anName = 0;
	}
	void OnGUI() {
		//按下時
		if(getDown){
			eCXY = Event.current.mousePosition;
			nowPoint = eCXY;
			isDrag=true;
			getDown=false;
		}else if(isDrag){
			eCXY=Event.current.mousePosition;
		}
		/*
		GUI.skin.label.fontSize = 20;
		GUI.skin.label.alignment = TextAnchor.LowerCenter;
		GUI.Label(new Rect(0, Screen.height * 0.0f, Screen.width, 60), "rotation:"+player.rotation.ToString());
		GUI.Label(new Rect(0, Screen.height * 0.1f, Screen.width, 60), "nowPoint:"+nowPoint.ToString());
		GUI.Label(new Rect(0, Screen.height * 0.2f, Screen.width, 60), "power:"+hitPower.ToString());
		*/
	}

	//轉換滑鼠座標&世界座標
	float toScreen(float x){
		//return (x+11.0f)*(Screen.width/22.0f); //左-11右11
		return (x+11.0f)*screenRate; //左-11右11
	}
	void footStepSE(int x){
		if(x==1){
			if(!audio.isPlaying){
				audio.loop=true;
				audio.Play();
			}
		}else{
			if(audio.isPlaying)
				audio.loop=false;
		}
	}
}
