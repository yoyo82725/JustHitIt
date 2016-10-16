using UnityEngine;
using System.Collections;

public class HallManager : MonoBehaviour {
	string windowTitle = "Just Hit It ver."+GameManager.ver;
	int tmpSW = Screen.width;
	int butFoSi = Mathf.RoundToInt(Screen.width*0.04179f); //28
	//int winFoSi = Mathf.RoundToInt(Screen.width*0.02686f); //18
	int labFoSi = Mathf.RoundToInt(Screen.width*0.03582f); //24
	int resFoSi = Mathf.RoundToInt(Screen.width*0.02985f); //20
	float gcTimer = 10f;
	bool showGUI = true;
	//選單
	Rect windowRect = new Rect (Screen.width*0.4f,Screen.height*0.07f,Screen.width*0.57f,Screen.height*0.86f);
	Rect[] seRect = new Rect[]{
		new Rect(Screen.width*0.004f,Screen.height*0.06f,Screen.width*0.28f,Screen.height*0.21f),
		new Rect(Screen.width*0.285f,Screen.height*0.06f,Screen.width*0.28f,Screen.height*0.21f),
		new Rect(Screen.width*0.004f,Screen.height*0.27f,Screen.width*0.28f,Screen.height*0.21f),
		new Rect(Screen.width*0.285f,Screen.height*0.27f,Screen.width*0.28f,Screen.height*0.21f),
		new Rect(Screen.width*0.004f,Screen.height*0.48f,Screen.width*0.28f,Screen.height*0.21f),
		new Rect(Screen.width*0.285f,Screen.height*0.48f,Screen.width*0.28f,Screen.height*0.21f),
		new Rect(Screen.width*0.004f,Screen.height*0.69f,Screen.width*0.562f,Screen.height*0.16f)
	};
	Rect backHallRect = new Rect(0f,0f,Screen.width*0.28f,Screen.height*0.15f);
	//選關
	Rect stageNameRect = new Rect(Screen.width*0.12f,Screen.height*0.18f,Screen.width*0.76f,Screen.height*0.13f);
	Rect stageUpRect = new Rect(Screen.width*0.78f,Screen.height*0.41f,Screen.width*0.16f,Screen.height*0.19f);
	Rect stageDownRect = new Rect(Screen.width*0.78f,Screen.height*0.64f,Screen.width*0.16f,Screen.height*0.19f);
	Rect stageCheckRect = new Rect(Screen.width*0.3f,Screen.height*0.35f,Screen.width*0.4f,Screen.height*0.35f);
	Rect staCheLaRect = new Rect (Screen.width*0.1f,Screen.height*0.05f,Screen.width*0.2f,Screen.height*0.15f);
	Rect staYesRect = new Rect(Screen.width*0.02f,Screen.height*0.16f,Screen.width*0.15f,Screen.height*0.15f);
	Rect staNoRect = new Rect(Screen.width*0.23f,Screen.height*0.16f,Screen.width*0.15f,Screen.height*0.15f);
	Rect staHowWinRect = new Rect (Screen.width*0.03f,Screen.height*0.35f,Screen.width*0.25f,Screen.height*0.55f);
	Rect staHowLaRect = new Rect(Screen.width*0.01f,Screen.height*0.05f,Screen.width*0.23f,Screen.height*0.25f);
	Rect staHowLaRect2 = new Rect(Screen.width*0.01f,Screen.height*0.3f,Screen.width*0.23f,Screen.height*0.15f);
	int nowChoseLevel;
	bool showStaCheck;
	//狀態
	Rect stRect1 = new Rect(Screen.width*0.01f,Screen.height*0.07f,Screen.width*0.28f,Screen.height*0.15f);
	Rect stRect2 = new Rect(Screen.width*0.01f,Screen.height*0.17f,Screen.width*0.28f,Screen.height*0.4f);
	Rect stRect3 = new Rect(Screen.width*0.01f,Screen.height*0.32f,Screen.width*0.28f,Screen.height*0.15f);
	Rect stRect4 = new Rect(Screen.width*0.01f,Screen.height*0.42f,Screen.width*0.28f,Screen.height*0.15f);
	Rect stRect5 = new Rect(Screen.width*0.01f,Screen.height*0.52f,Screen.width*0.28f,Screen.height*0.15f);
	Rect stRect6 = new Rect(Screen.width*0.01f,Screen.height*0.67f,Screen.width*0.56f,Screen.height*0.15f);
	Rect stRect7 = new Rect(Screen.width*0.01f,Screen.height*0.77f,Screen.width*0.56f,Screen.height*0.15f);
	Rect stRect8 = new Rect(Screen.width*0.3f,Screen.height*0.07f,Screen.width*0.28f,Screen.height*0.3f);
	Rect stRect9 = new Rect(Screen.width*0.3f,Screen.height*0.27f,Screen.width*0.28f,Screen.height*0.3f);
	Rect stRect10 = new Rect(Screen.width*0.3f,Screen.height*0.47f,Screen.width*0.28f,Screen.height*0.3f);
	//技能
	Rect skWinRect = new Rect (Screen.width*0.05f,Screen.height*0.15f,Screen.width*0.9f,Screen.height*0.8f);
	Rect[] skRect = new Rect[]{
		new Rect (Screen.width*0.02f,Screen.height*0.07f,Screen.width*0.25f,Screen.height*0.3f),
		new Rect (Screen.width*0.302f,Screen.height*0.07f,Screen.width*0.25f,Screen.height*0.3f),
		new Rect (Screen.width*0.584f,Screen.height*0.07f,Screen.width*0.25f,Screen.height*0.3f),
		new Rect (Screen.width*0.02f,Screen.height*0.42f,Screen.width*0.25f,Screen.height*0.3f),
		new Rect (Screen.width*0.302f,Screen.height*0.42f,Screen.width*0.25f,Screen.height*0.3f)
	};
	Rect skLeRect = new Rect (Screen.width*0.58f,Screen.height*0.42f,Screen.width*0.148f,Screen.height*0.3f);
	Rect skRiRect = new Rect (Screen.width*0.7385f,Screen.height*0.42f,Screen.width*0.148f,Screen.height*0.3f);
	Rect skHowRect = new Rect(Screen.width*0.29f,0f,Screen.width*0.72f,Screen.height*0.15f);
	string skHowText = "請選擇一個技能";
	int skNowChoose = 0;
	int skRLine = 5; //一依次顯示幾筆 不只改這
	int skPageNum = 1;
	//商店
	Rect shLeRect = new Rect(Screen.width*0.004f,Screen.height*0.69f,Screen.width*0.17f,Screen.height*0.16f);
	Rect shByRect = new Rect(Screen.width*0.174f,Screen.height*0.69f,Screen.width*0.222f,Screen.height*0.16f);
	Rect shRiRect = new Rect(Screen.width*0.396f,Screen.height*0.69f,Screen.width*0.17f,Screen.height*0.16f);
	Rect moneyRect = new Rect(Screen.width*0.05f,Screen.height*0.8f,Screen.width*0.4f,Screen.height*0.2f);
	string shHowText = "請選擇一項商品";
	int shNowChoose = 0;
	int shRLine = 6;
	//聊天
	Rect chatRect = new Rect(Screen.width*0.03f,Screen.height*0.5f,Screen.width*0.93f,Screen.height*0.42f);
	string chatString = "";
	int chatStep=0,onceFlag=-1,shakOnce=-1,shakOnce2=-1;
	public GameObject chatGirl,s1Eagle,s1Butterfly,s1Square,s2Ghost,s2Candle,s2SquareF,s3Pegasus,s3SkyBall,s4Capsule;
	GameObject guest;
	bool playerShak=false,guestShak=false;
	bool playerDM=false,guestDM=false; //DM = dont move
	bool playEndSe=false;
	Vector3 plPosIni,guestPosIni;
	float shakeTime,shakeTime2,triJump;
	int nowChatID,triJmpFlag;
	//成就計時
	int resChLevel=1;
	Rect resTimeRect = new Rect(Screen.width*0.03f,Screen.height*0.35f,Screen.width*0.6f,Screen.height*0.6f);
	Rect resToLRect = new Rect(Screen.width*0.65f,Screen.height*0.64f,Screen.width*0.16f,Screen.height*0.19f);
	Rect resToRRect = new Rect(Screen.width*0.82f,Screen.height*0.64f,Screen.width*0.16f,Screen.height*0.19f);
	Rect[] resTimeRects = new Rect[]{
		new Rect(Screen.width*0.01f,Screen.height*0.01f,Screen.width*0.59f,Screen.height*0.19f),
		new Rect(Screen.width*0.01f,Screen.height*0.21f,Screen.width*0.59f,Screen.height*0.19f),
		new Rect(Screen.width*0.01f,Screen.height*0.41f,Screen.width*0.59f,Screen.height*0.19f)
	};
	int resTime1,resTime2,resTime3;
	//成就表
	Rect resResRect = new Rect(Screen.width*0.03f,Screen.height*0.15f,Screen.width*0.6f,Screen.height*0.8f);
	Rect[] resResRects = new Rect[]{
		new Rect (Screen.width*0.006f,Screen.height*0.07f,Screen.width*0.293f,Screen.height*0.17f),
		new Rect (Screen.width*0.301f,Screen.height*0.07f,Screen.width*0.293f,Screen.height*0.17f),
		new Rect (Screen.width*0.006f,Screen.height*0.25f,Screen.width*0.293f,Screen.height*0.17f),
		new Rect (Screen.width*0.301f,Screen.height*0.25f,Screen.width*0.293f,Screen.height*0.17f),
		new Rect (Screen.width*0.006f,Screen.height*0.43f,Screen.width*0.293f,Screen.height*0.17f),
		new Rect (Screen.width*0.301f,Screen.height*0.43f,Screen.width*0.293f,Screen.height*0.17f),
		new Rect (Screen.width*0.006f,Screen.height*0.61f,Screen.width*0.293f,Screen.height*0.17f),
		new Rect (Screen.width*0.301f,Screen.height*0.61f,Screen.width*0.1465f,Screen.height*0.17f),
		new Rect (Screen.width*0.4475f,Screen.height*0.61f,Screen.width*0.1465f,Screen.height*0.17f),
	};
	Rect getResRect = new Rect(Screen.width*0.75f,0f,Screen.width*0.25f,Screen.height*0.25f);
	Rect getResLabRec = new Rect(0,0,Screen.width*0.25f,Screen.height*0.25f);
	string resHowText = "請選擇一項成就";
	int resRLine = 7;
	string getResText;
	bool getRes;
	float showResTimer;


	public AudioClip clickSE,shbuySE,errSE,loginSE,logoutSE,startPlaySE,hallMu,teachMu,s1Mu,s2Mu,s3Mu,s4Mu,sYMu;
	bool showSelection=true; //顯示選項
	bool showStage; //關卡選擇
	bool showStatus; //狀態
	bool showWear; //裝備
	bool showSk1; //技能表1
	bool showSk2; //技能表2
	bool showSk3; //技能表3
	bool showShop; //商店
	bool showChat; //聊天
	bool showRes; //成就
	bool exitCheck;
	public GameObject player,teachBg,s1Bg,s2Bg,s3Bg,s4Bg,ldFace;
	public AudioSource audioObj;

	void Awake(){

	}

	void Start () {
		if (GameManager.money > 210000000)
			GameManager.money = 210000000;
		plPosIni = player.transform.position;
		if (!GameManager.resGet [7]) {
			//成就技能收集
			if(GameManager.skOpen[0] && GameManager.skOpen[1] && GameManager.skOpen[2] && GameManager.skOpen[3] && GameManager.skOpen[4] && GameManager.skOpen[5] && GameManager.skOpen[6] && GameManager.skOpen[7] && GameManager.skOpen[8] && GameManager.skOpen[9] && GameManager.skOpen[10]){
				MoneySE();
				getResText = "成就完成！\n" + GameManager.ResName(8) + "\n$" + GameManager.ResBackMoney(8).ToString("N0");
				getRes = true;
				showResTimer = 7f;
				GameManager.money += GameManager.ResBackMoney(8);
				GameManager.resGet [7] = true;
			}
		}
		if (!GameManager.resGet [9]) {
			//成就感謝遊玩
			if(GameManager.resGet[0] && GameManager.resGet[1] && GameManager.resGet[2] && GameManager.resGet[3] && GameManager.resGet[4] && GameManager.resGet[5] && GameManager.resGet[6] && GameManager.resGet[7] && GameManager.resGet[8]){
				MoneySE();
				getResText = "成就完成！\n" + GameManager.ResName(10) + "\n$" + GameManager.ResBackMoney(10).ToString("N0");
				getRes = true;
				showResTimer = 7f;
				GameManager.money += GameManager.ResBackMoney(10);
				GameManager.resGet [9] = true;
			}
		}
	}

	void Update(){
		//聊天進展
		if(showChat){
			if(Input.GetMouseButtonDown(0)){
				if(playEndSe)
					LogoutSound();
				else
					ClickSound();
				chatStep++;
			}
		}
	}

	void FixedUpdate () {
		//GUI位置變更
		if (tmpSW != Screen.width) {
			tmpSW = Screen.width;
			butFoSi = Mathf.RoundToInt(Screen.width*0.04179f); //28
			//int winFoSi = Mathf.RoundToInt(Screen.width*0.02686f); //18
			labFoSi = Mathf.RoundToInt(Screen.width*0.03582f); //24
			resFoSi = Mathf.RoundToInt(Screen.width*0.02985f); //20
			//選單
			windowRect = new Rect (Screen.width*0.4f,Screen.height*0.07f,Screen.width*0.57f,Screen.height*0.86f);
			seRect = new Rect[]{
				new Rect(Screen.width*0.004f,Screen.height*0.06f,Screen.width*0.28f,Screen.height*0.21f),
				new Rect(Screen.width*0.285f,Screen.height*0.06f,Screen.width*0.28f,Screen.height*0.21f),
				new Rect(Screen.width*0.004f,Screen.height*0.27f,Screen.width*0.28f,Screen.height*0.21f),
				new Rect(Screen.width*0.285f,Screen.height*0.27f,Screen.width*0.28f,Screen.height*0.21f),
				new Rect(Screen.width*0.004f,Screen.height*0.48f,Screen.width*0.28f,Screen.height*0.21f),
				new Rect(Screen.width*0.285f,Screen.height*0.48f,Screen.width*0.28f,Screen.height*0.21f),
				new Rect(Screen.width*0.004f,Screen.height*0.69f,Screen.width*0.562f,Screen.height*0.16f)
			};
			backHallRect = new Rect(0f,0f,Screen.width*0.28f,Screen.height*0.15f);
			//選關
			stageNameRect = new Rect(Screen.width*0.12f,Screen.height*0.18f,Screen.width*0.76f,Screen.height*0.13f);
			stageUpRect = new Rect(Screen.width*0.78f,Screen.height*0.41f,Screen.width*0.16f,Screen.height*0.19f);
			stageDownRect = new Rect(Screen.width*0.78f,Screen.height*0.64f,Screen.width*0.16f,Screen.height*0.19f);
			stageCheckRect = new Rect(Screen.width*0.3f,Screen.height*0.35f,Screen.width*0.4f,Screen.height*0.35f);
			staCheLaRect = new Rect (Screen.width*0.1f,Screen.height*0.05f,Screen.width*0.2f,Screen.height*0.15f);
			staYesRect = new Rect(Screen.width*0.02f,Screen.height*0.16f,Screen.width*0.15f,Screen.height*0.15f);
			staNoRect = new Rect(Screen.width*0.23f,Screen.height*0.16f,Screen.width*0.15f,Screen.height*0.15f);
			staHowWinRect = new Rect (Screen.width*0.03f,Screen.height*0.35f,Screen.width*0.25f,Screen.height*0.55f);
			staHowLaRect = new Rect(Screen.width*0.01f,Screen.height*0.05f,Screen.width*0.23f,Screen.height*0.25f);
			staHowLaRect2 = new Rect(Screen.width*0.01f,Screen.height*0.3f,Screen.width*0.23f,Screen.height*0.15f);
			//狀態
			stRect1 = new Rect(Screen.width*0.01f,Screen.height*0.07f,Screen.width*0.28f,Screen.height*0.15f);
			stRect2 = new Rect(Screen.width*0.01f,Screen.height*0.17f,Screen.width*0.28f,Screen.height*0.4f);
			stRect3 = new Rect(Screen.width*0.01f,Screen.height*0.32f,Screen.width*0.28f,Screen.height*0.15f);
			stRect4 = new Rect(Screen.width*0.01f,Screen.height*0.42f,Screen.width*0.28f,Screen.height*0.15f);
			stRect5 = new Rect(Screen.width*0.01f,Screen.height*0.52f,Screen.width*0.28f,Screen.height*0.15f);
			stRect6 = new Rect(Screen.width*0.01f,Screen.height*0.67f,Screen.width*0.56f,Screen.height*0.15f);
			stRect7 = new Rect(Screen.width*0.01f,Screen.height*0.77f,Screen.width*0.56f,Screen.height*0.15f);
			stRect8 = new Rect(Screen.width*0.3f,Screen.height*0.07f,Screen.width*0.28f,Screen.height*0.3f);
			stRect9 = new Rect(Screen.width*0.3f,Screen.height*0.27f,Screen.width*0.28f,Screen.height*0.3f);
			stRect10 = new Rect(Screen.width*0.3f,Screen.height*0.47f,Screen.width*0.28f,Screen.height*0.3f);
			//技能
			skWinRect = new Rect (Screen.width*0.05f,Screen.height*0.15f,Screen.width*0.9f,Screen.height*0.8f);
			skRect = new Rect[]{
				new Rect (Screen.width*0.02f,Screen.height*0.07f,Screen.width*0.25f,Screen.height*0.3f),
				new Rect (Screen.width*0.302f,Screen.height*0.07f,Screen.width*0.25f,Screen.height*0.3f),
				new Rect (Screen.width*0.584f,Screen.height*0.07f,Screen.width*0.25f,Screen.height*0.3f),
				new Rect (Screen.width*0.02f,Screen.height*0.42f,Screen.width*0.25f,Screen.height*0.3f),
				new Rect (Screen.width*0.302f,Screen.height*0.42f,Screen.width*0.25f,Screen.height*0.3f)
			};
			skLeRect = new Rect (Screen.width*0.58f,Screen.height*0.42f,Screen.width*0.148f,Screen.height*0.3f);
			skRiRect = new Rect (Screen.width*0.7385f,Screen.height*0.42f,Screen.width*0.148f,Screen.height*0.3f);
			skHowRect = new Rect(Screen.width*0.29f,0f,Screen.width*0.72f,Screen.height*0.15f);
			//商店
			shLeRect = new Rect(Screen.width*0.004f,Screen.height*0.69f,Screen.width*0.17f,Screen.height*0.16f);
			shByRect = new Rect(Screen.width*0.174f,Screen.height*0.69f,Screen.width*0.222f,Screen.height*0.16f);
			shRiRect = new Rect(Screen.width*0.396f,Screen.height*0.69f,Screen.width*0.17f,Screen.height*0.16f);
			moneyRect = new Rect(Screen.width*0.05f,Screen.height*0.8f,Screen.width*0.4f,Screen.height*0.2f);
			//聊天
			chatRect = new Rect(Screen.width*0.03f,Screen.height*0.5f,Screen.width*0.93f,Screen.height*0.42f);
			//成就計時
			resTimeRect = new Rect(Screen.width*0.03f,Screen.height*0.35f,Screen.width*0.6f,Screen.height*0.6f);
			resToLRect = new Rect(Screen.width*0.65f,Screen.height*0.64f,Screen.width*0.16f,Screen.height*0.19f);
			resToRRect = new Rect(Screen.width*0.82f,Screen.height*0.64f,Screen.width*0.16f,Screen.height*0.19f);
			resTimeRects = new Rect[]{
				new Rect(Screen.width*0.01f,Screen.height*0.01f,Screen.width*0.59f,Screen.height*0.19f),
				new Rect(Screen.width*0.01f,Screen.height*0.21f,Screen.width*0.59f,Screen.height*0.19f),
				new Rect(Screen.width*0.01f,Screen.height*0.41f,Screen.width*0.59f,Screen.height*0.19f)
			};
			//成就表
			resResRect = new Rect(Screen.width*0.03f,Screen.height*0.15f,Screen.width*0.6f,Screen.height*0.8f);
			resResRects = new Rect[]{
				new Rect (Screen.width*0.006f,Screen.height*0.07f,Screen.width*0.293f,Screen.height*0.17f),
				new Rect (Screen.width*0.301f,Screen.height*0.07f,Screen.width*0.293f,Screen.height*0.17f),
				new Rect (Screen.width*0.006f,Screen.height*0.25f,Screen.width*0.293f,Screen.height*0.17f),
				new Rect (Screen.width*0.301f,Screen.height*0.25f,Screen.width*0.293f,Screen.height*0.17f),
				new Rect (Screen.width*0.006f,Screen.height*0.43f,Screen.width*0.293f,Screen.height*0.17f),
				new Rect (Screen.width*0.301f,Screen.height*0.43f,Screen.width*0.293f,Screen.height*0.17f),
				new Rect (Screen.width*0.006f,Screen.height*0.61f,Screen.width*0.293f,Screen.height*0.17f),
				new Rect (Screen.width*0.301f,Screen.height*0.61f,Screen.width*0.1465f,Screen.height*0.17f),
				new Rect (Screen.width*0.4475f,Screen.height*0.61f,Screen.width*0.1465f,Screen.height*0.17f),
			};
			getResRect = new Rect(Screen.width*0.75f,0f,Screen.width*0.25f,Screen.height*0.25f);
			getResLabRec = new Rect(0,0,Screen.width*0.25f,Screen.height*0.25f);
		}
		//關卡切換音樂漸變
		if (audioObj.volume < 1f)
			audioObj.volume += 0.02f;
		//垃圾回收
		if ((gcTimer -= 0.02f) <= 0f) {
			System.GC.Collect ();
			gcTimer=10f;
		}
		GameManager.playTime += 0.02f;

		//聊天
		if (showChat) {
			//聊天抖動
			if(playerShak){
				if(shakOnce != chatStep && !playerDM){
					shakOnce = chatStep;
					shakeTime = 0.5f;
					//歸位
					if(player.transform.position != plPosIni)
						player.transform.position = plPosIni;
				}
				if(shakeTime>0.4f)
					player.transform.Translate(0,0.1f,0,Space.World);
				else if(shakeTime>0.3f)
					player.transform.Translate(0,-0.1f,0,Space.World);
				else if(shakeTime>0.2f)
					player.transform.Translate(0,0.1f,0,Space.World);
				else if(shakeTime>0.1f)
					player.transform.Translate(0,-0.1f,0,Space.World);
				else{
					player.transform.position = plPosIni;
					playerShak=false;
					shakOnce=-1;
				}
				shakeTime -= 0.02f;
			}
			if(guestShak){
				if(shakOnce2 != chatStep && !guestDM){
					shakOnce2 = chatStep;
					shakeTime2 = 0.5f;
					//歸位
					if(guest.transform.position != guestPosIni)
						guest.transform.position = guestPosIni;
				}
				if(shakeTime2>0.4f)
					guest.transform.Translate(0,0.1f,0,Space.World);
				else if(shakeTime2>0.3f)
					guest.transform.Translate(0,-0.1f,0,Space.World);
				else if(shakeTime2>0.2f)
					guest.transform.Translate(0,0.1f,0,Space.World);
				else if(shakeTime2>0.1f)
					guest.transform.Translate(0,-0.1f,0,Space.World);
				else{
					guest.transform.position = guestPosIni;
					guestShak=false;
					shakOnce2=-1;
				}
				shakeTime2 -= 0.02f;
			}
			//聊天三角抖動
			if(triJmpFlag == 0){
				if((triJump += chatRect.height*0.0013f) > chatRect.height*0.1f){
					triJmpFlag = 1;
				}
			}else{
				if((triJump -= chatRect.height*0.0013f) < chatRect.height*0.05f){
					triJmpFlag = 0;
				}
			}

		}

		if (!GameManager.resGet [0]) {
			//成就等級2
			if(GameManager.playerLevel>1){
				MoneySE();
				getResText = "成就完成！\n" + GameManager.ResName(1) + "\n$" + GameManager.ResBackMoney(1).ToString("N0");
				getRes = true;
				showResTimer = 7f;
				GameManager.money += GameManager.ResBackMoney(1);
				GameManager.resGet [0] = true;
			}
		}

		if(showResTimer > 0){
			showResTimer -= 0.02f;
			if(showResTimer <= 0){
				getRes=false;
			}
		}
	}

	void OnGUI(){
		if(showGUI){
			GUI.skin.button.fontSize = butFoSi;
			GUI.skin.window.fontSize = resFoSi;
			GUI.skin.label.fontSize = labFoSi;
			GUI.backgroundColor = Color.white;
			GUI.skin.label.alignment = TextAnchor.LowerCenter;
			//右上成就視窗
			if(getRes){
				GUI.Window(4,getResRect,getResWindow,"");
			}
			//***********************選單***************************
			if(showSelection){
				GUI.Window(0, windowRect, SelectionWindow, windowTitle);
			}
			//***********************選關***************************
			else if(showStage){
				//回去按鈕
				if(GUI.Button(backHallRect,"回去")){
					ClickSound();
					showStage = BackToHall();
					showStaCheck = false;
					//關閉場景
					CloseBg(nowChoseLevel);
					//改音樂
					ChangeMu(-1);
				}
				//關卡名
				if(GUI.Button(stageNameRect,GameManager.GetLevelName(nowChoseLevel))){
					ClickSound();
					AudioSource.PlayClipAtPoint(startPlaySE,Vector3.one);
					GameManager.playingLevel = nowChoseLevel;
					showStaCheck=true;
				}
				//關卡描述
				GUI.Window(1,staHowWinRect,staHowWindow,"");
				//上下
				GUI.skin.button.fontSize = butFoSi+butFoSi;
				if(GUI.Button(stageUpRect,"△")){
					ClickSound();
					CloseBg(nowChoseLevel);
					showStaCheck = false;
					if(nowChoseLevel>0)
						nowChoseLevel--;
					else
						nowChoseLevel=GameManager.openLevel;
					//改背景
					OpenBg(nowChoseLevel);
					//改音樂
					ChangeMu(nowChoseLevel);
				}
				if(GUI.Button(stageDownRect,"▽")){
					ClickSound();
					CloseBg(nowChoseLevel);
					showStaCheck = false;
					if(nowChoseLevel<GameManager.openLevel)
						nowChoseLevel++;
					else
						nowChoseLevel=0;
					//改背景
					OpenBg(nowChoseLevel);
					//改音樂
					ChangeMu(nowChoseLevel);
				}
				//是否要
				if(showStaCheck){
					GUI.Window(2,stageCheckRect,staCheckWindow,"");
				}
			}
			//***********************狀態***************************
			else if(showStatus){
				GUI.Window(1, windowRect, StatusWindow, windowTitle);
				//回去按鈕
				if(GUI.Button(backHallRect,"回去")){
					ClickSound();
					showStatus = BackToHall();
				}
			}
			//***********************裝備***************************
			else if(showWear){
				GUI.Window(4, windowRect, WearWindow, windowTitle);
				//回去按鈕
				if(GUI.Button(backHallRect,"回去")){
					ClickSound();
					showWear = BackToHall();
				}
			}
			//***********************技能表***************************
			else if(showSk1 || showSk2 || showSk3){
				//說明
				GUI.skin.label.alignment = TextAnchor.UpperLeft;
				GUI.skin.label.fontSize = labFoSi;
				GUI.Label(skHowRect,skHowText);
				//技能表
				if(showSk1)
					GUI.Window(1,skWinRect,skillsWindow,"");
				else if(showSk2)
					GUI.Window(2,skWinRect,skillsWindow,"");
				else if(showSk3)
					GUI.Window(3,skWinRect,skillsWindow,"");
				//回去
				if(GUI.Button(backHallRect,"回去")){
					ClickSound();
					showWear=true;
					showSk1=false;
					showSk2=false;
					showSk3=false;
					player.SetActive(true);
					skHowText = "請選擇一個技能";
					skNowChoose=0;
				}
			}
			//***********************商店***************************
			else if(showShop){
				//說明
				GUI.skin.label.alignment=TextAnchor.UpperLeft;
				GUI.skin.label.fontSize = resFoSi;
				GUI.Label(skHowRect,"說明："+shHowText);
				//目前金錢
				GUI.Label(moneyRect,"金錢："+GameManager.money.ToString("N0"));
				//購買單
				GUI.Window(1, windowRect, shopWindow, windowTitle);
				//回去按鈕
				if(GUI.Button(backHallRect,"回去")){
					ClickSound();
					showShop = BackToHall();
					shHowText = "請選擇一項商品";
					shNowChoose = 0;
				}
			}
			//***********************聊天***************************
			else if(showChat){
				GUI.Window(nowChatID,chatRect,chatWindow,"");
			}
			//***********************成就***************************
			else if(showRes){
				//回去按鈕
				if(GUI.Button(backHallRect,"回去")){
					ClickSound();
					showRes = BackToHall();
					//關閉場景
					CloseBg(resChLevel);
					//改音樂
					ChangeMu(-1);
				}
				//成就表&時間表
				if(resChLevel>GameManager.openLevel){
					//成就表
					GUI.Window(1,resResRect,resResWindow,"成　就　一　覽");
					//說明文字
					GUI.skin.label.alignment = TextAnchor.UpperLeft;
					GUI.skin.label.fontSize = labFoSi;
					GUI.Label(skHowRect,resHowText);
				}else{
					//關卡名
					GUI.Button(stageNameRect,GameManager.GetLevelName(resChLevel));
					//時間表
					GUI.Window(1,resTimeRect,resTimeWindow,"");
				}
				//左右
				GUI.skin.button.fontSize = butFoSi+butFoSi;
				if(GUI.Button(resToLRect,"◁")){
					ClickSound();
					CloseBg(resChLevel);
					if(resChLevel>1)
						resChLevel--;
					else
						resChLevel=GameManager.openLevel+1;
					if(resChLevel == GameManager.openLevel+1){
						//成就顯示
						OpenBg(-1);
						ChangeMu(-1);
					}else{
						//時間顯示
						OpenBg(resChLevel);
						ChangeMu(resChLevel);
					}
					//讀取該關時間
					if(resChLevel<=GameManager.openLevel){
						resTime1 = Mathf.FloorToInt(GameManager.bestTime [resChLevel-1,0]);
						resTime2 = Mathf.FloorToInt(GameManager.bestTime [resChLevel-1,1]);
						resTime3 = Mathf.FloorToInt(GameManager.bestTime [resChLevel-1,2]);
					}
				}
				if(GUI.Button(resToRRect,"▷")){
					ClickSound();
					CloseBg(resChLevel);
					if(resChLevel < GameManager.openLevel+1)
						resChLevel++;
					else
						resChLevel=1;
					if(resChLevel == GameManager.openLevel+1){
						//成就顯示
						OpenBg(-1);
						ChangeMu(-1);
					}else{
						//時間顯示
						OpenBg(resChLevel);
						ChangeMu(resChLevel);
					}
					//讀取該關時間
					if(resChLevel<=GameManager.openLevel){
						resTime1 = Mathf.FloorToInt(GameManager.bestTime [resChLevel-1,0]);
						resTime2 = Mathf.FloorToInt(GameManager.bestTime [resChLevel-1,1]);
						resTime3 = Mathf.FloorToInt(GameManager.bestTime [resChLevel-1,2]);
					}
				}
			}
			//***********************結束確認***************************
			else if(exitCheck){
				GUI.Window(1,stageCheckRect,exitCheWin,"");
			}
		}
	}
	//*************************************************
	//選單
	void SelectionWindow(int windowID) {
		GUI.skin.button.fontSize = butFoSi;
		if (GUI.Button(seRect[0], "關卡")){
			ClickSound();
			player.SetActive(false);
			showSelection=false;
			showStage=true;
			//改場景
			OpenBg(nowChoseLevel);
			//改音樂
			ChangeMu(nowChoseLevel);
		}else if (GUI.Button(seRect[1], "狀態")){
			ClickSound();
			showSelection=false;
			showStatus=true;
		}else if (GUI.Button(seRect[2], "技能")){
			ClickSound();
			showSelection=false;
			showWear=true;
		}else if (GUI.Button(seRect[3], "商店")){
			ClickSound();
			showSelection=false;
			showShop=true;
		}else if (GUI.Button(seRect[4], "聊天")){
			LoginSound();
			showSelection=false;
			showChat=true;
			chatStep=0;
			playEndSe=false;
			//跑chatID
			if(GameManager.chatLine == 0){ //第一次
				nowChatID = 0;
			}else if(GameManager.chatLine == 1){ //第一次美女
				nowChatID = 1;
				guest = chatGirl;
				guestPosIni = guest.transform.position;
			}else if(GameManager.chatLine == 2){ //第一次老鷹
				nowChatID = 2;
				guest = s1Eagle;
				guestPosIni = guest.transform.position;
			}else if(GameManager.chatLine == 3){ //第一次蝴蝶
				nowChatID = 3;
				guest = s1Butterfly;
				guestPosIni = guest.transform.position;
			}else if(GameManager.chatLine == 4){ //第一次方塊
				nowChatID = 4;
				guest = s1Square;
				guestPosIni = guest.transform.position;
			}else if(GameManager.openLevel > 1){
				if(GameManager.chatLine == 5){ //第一次幽靈
					nowChatID = 5;
					guest = s2Ghost;
					guestPosIni = guest.transform.position;
				}else if(GameManager.chatLine == 6){ //第一次燭台
					nowChatID = 6;
					guest = s2Candle;
					guestPosIni = guest.transform.position;
				}else if(GameManager.chatLine == 7){ //第一次方半
					nowChatID = 7;
					guest = s2SquareF;
					guestPosIni = guest.transform.position;
				}else if(GameManager.chatLine == 8){ //第二次也也
					nowChatID = 8;
					guest = chatGirl;
					guestPosIni = guest.transform.position;
				}else if(GameManager.chatLine == 9){ //第二次方塊
					nowChatID = 9;
					guest = s1Square;
					guestPosIni = guest.transform.position;
				}else if(GameManager.chatLine == 10){ //第二次蝴蝶
					nowChatID = 10;
					guest = s1Butterfly;
					guestPosIni = guest.transform.position;
				}else if(GameManager.chatLine == 11){ //第二次老鷹
					nowChatID = 11;
					guest = s1Eagle;
					guestPosIni = guest.transform.position;
				}else if(GameManager.chatLine == 12){ //第二次拉勇
					nowChatID = 12;
				}else if(GameManager.openLevel > 2){
					if(GameManager.chatLine == 13){ //第一次飛馬
						nowChatID = 13;
						guest = s3Pegasus;
						guestPosIni = guest.transform.position;
					}else if(GameManager.chatLine == 14){ //第一次天球
						nowChatID = 14;
						guest = s3SkyBall;
						guestPosIni = guest.transform.position;
					}else if(GameManager.chatLine == 15){ //第二次幽靈
						nowChatID = 15;
						guest = s2Ghost;
						guestPosIni = guest.transform.position;
					}else if(GameManager.chatLine == 16){ //第二次燭台
						nowChatID = 16;
						guest = s2Candle;
						guestPosIni = guest.transform.position;
					}else if(GameManager.chatLine == 17){ //第三次老鷹
						nowChatID = 17;
						guest = s1Eagle;
						guestPosIni = guest.transform.position;
					}else if(GameManager.chatLine == 18){ //第二次方半
						nowChatID = 18;
						guest = s2SquareF;
						guestPosIni = guest.transform.position;
					}else if(GameManager.chatLine == 19){ //第三次方塊
						nowChatID = 19;
						guest = s1Square;
						guestPosIni = guest.transform.position;
					}else if(GameManager.chatLine == 20){ //第三次蝴蝶
						nowChatID = 20;
						guest = s1Butterfly;
						guestPosIni = guest.transform.position;
					}else if(GameManager.chatLine == 21){ //第三次也也
						nowChatID = 21;
						guest = chatGirl;
						guestPosIni = guest.transform.position;
					}else if(GameManager.chatLine == 22){ //第三次拉勇
						nowChatID = 22;
					}else if(GameManager.openLevel > 3){
						if(GameManager.chatLine == 23){ //第一次膠囊
							nowChatID = 23;
							guest = s4Capsule;
							guestPosIni = guest.transform.position;
						}else if(GameManager.chatLine == 24){ //第四次也也
							nowChatID = 24;
							guest = chatGirl;
							guestPosIni = guest.transform.position;
						}else if(GameManager.chatLine == 25){ //第二次飛馬
							nowChatID = 25;
							guest = s3Pegasus;
							guestPosIni = guest.transform.position;
						}else if(GameManager.chatLine == 26){ //第二次天球
							nowChatID = 26;
							guest = s3SkyBall;
							guestPosIni = guest.transform.position;
						}else if(GameManager.chatLine == 27){ //第三次幽靈
							nowChatID = 27;
							guest = s2Ghost;
							guestPosIni = guest.transform.position;
						}else if(GameManager.chatLine == 28){ //第三次燭台
							nowChatID = 28;
							guest = s2Candle;
							guestPosIni = guest.transform.position;
						}else if(GameManager.chatLine == 29){ //第三次方半
							nowChatID = 29;
							guest = s2SquareF;
							guestPosIni = guest.transform.position;
						}else if(GameManager.chatLine == 30){ //第四次老鷹
							nowChatID = 30;
							guest = s1Eagle;
							guestPosIni = guest.transform.position;
						}else if(GameManager.chatLine == 31){ //第四次蝴蝶
							nowChatID = 31;
							guest = s1Butterfly;
							guestPosIni = guest.transform.position;
						}else if(GameManager.chatLine == 32){ //第四次方塊
							nowChatID = 32;
							guest = s1Square;
							guestPosIni = guest.transform.position;
						}else if(GameManager.chatLine == 33){ //第四次拉勇
							nowChatID = 33;
						}else if(GameManager.openLevel > 4){
							if(GameManager.chatLine == 34){ //第二次膠囊
								nowChatID = 34;
								guest = s4Capsule;
								guestPosIni = guest.transform.position;
							}else if(GameManager.chatLine == 35){ //第五次也也
								nowChatID = 35;
								guest = chatGirl;
								guestPosIni = guest.transform.position;
							}else if(GameManager.chatLine == 36){ //第五次拉勇
								nowChatID = 36;
								guest = chatGirl;
								guestPosIni = guest.transform.position;
							}else{
								nowChatID = Random.Range(0,37);
								if(nowChatID == 1){ //女
									guest = chatGirl;
									guestPosIni = guest.transform.position;
								}else if(nowChatID == 2){ //老鷹
									guest = s1Butterfly;
									guestPosIni = guest.transform.position;
								}else if(nowChatID == 3){ //蝴蝶
									guest = s1Eagle;
									guestPosIni = guest.transform.position;
								}else if(nowChatID == 4){ //方塊
									guest = s1Square;
									guestPosIni = guest.transform.position;
								}else if(nowChatID == 5){ //幽靈1
									guest = s2Ghost;
									guestPosIni = guest.transform.position;
								}else if(nowChatID == 6){ //燭台1
									guest = s2Candle;
									guestPosIni = guest.transform.position;
								}else if(nowChatID == 7){ //方半1
									guest = s2SquareF;
									guestPosIni = guest.transform.position;
								}else if(nowChatID == 8){ //也也2
									guest = chatGirl;
									guestPosIni = guest.transform.position;
								}else if(nowChatID == 9){ //方塊2
									guest = s1Square;
									guestPosIni = guest.transform.position;
								}else if(nowChatID == 10){ //蝴蝶2
									guest = s1Butterfly;
									guestPosIni = guest.transform.position;
								}else if(nowChatID == 11){ //老鷹2
									guest = s1Eagle;
									guestPosIni = guest.transform.position;
								}else if(nowChatID == 13){ //飛馬1
									guest = s3Pegasus;
									guestPosIni = guest.transform.position;
								}else if(nowChatID == 14){ //天球1
									guest = s3SkyBall;
									guestPosIni = guest.transform.position;
								}else if(nowChatID == 15){ //幽靈2
									guest = s2Ghost;
									guestPosIni = guest.transform.position;
								}else if(nowChatID == 16){ //燭台2
									guest = s2Candle;
									guestPosIni = guest.transform.position;
								}else if(nowChatID == 17){ //老鷹3
									guest = s1Eagle;
									guestPosIni = guest.transform.position;
								}else if(nowChatID == 18){ //方半2
									guest = s2SquareF;
									guestPosIni = guest.transform.position;
								}else if(nowChatID == 19){ //方塊3
									guest = s1Square;
									guestPosIni = guest.transform.position;
								}else if(nowChatID == 20){ //蝴蝶3
									guest = s1Square;
									guestPosIni = guest.transform.position;
								}else if(nowChatID == 21){ //也也3
									guest = chatGirl;
									guestPosIni = guest.transform.position;
								}else if(nowChatID == 23){ //膠囊1
									guest = s4Capsule;
									guestPosIni = guest.transform.position;
								}else if(nowChatID == 24){ //也也4
									guest = chatGirl;
									guestPosIni = guest.transform.position;
								}else if(nowChatID == 25){ //飛馬2
									guest = s3Pegasus;
									guestPosIni = guest.transform.position;
								}else if(nowChatID == 26){ //天球2
									guest = s3SkyBall;
									guestPosIni = guest.transform.position;
								}else if(nowChatID == 27){ //幽靈3
									guest = s2Ghost;
									guestPosIni = guest.transform.position;
								}else if(nowChatID == 28){ //燭台3
									guest = s2Candle;
									guestPosIni = guest.transform.position;
								}else if(nowChatID == 29){ //方半3
									guest = s2SquareF;
									guestPosIni = guest.transform.position;
								}else if(nowChatID == 30){ //老鷹4
									guest = s1Eagle;
									guestPosIni = guest.transform.position;
								}else if(nowChatID == 31){ //蝴蝶4
									guest = s1Butterfly;
									guestPosIni = guest.transform.position;
								}else if(nowChatID == 32){ //方塊4
									guest = s1Square;
									guestPosIni = guest.transform.position;
								}else if(nowChatID == 34){ //膠囊2
									guest = s4Capsule;
									guestPosIni = guest.transform.position;
								}else if(nowChatID == 35){ //也也5
									guest = chatGirl;
									guestPosIni = guest.transform.position;
								}
							}
						}else{
							nowChatID = Random.Range(23,34);
							if(nowChatID == 23){ //膠囊1
								guest = s4Capsule;
								guestPosIni = guest.transform.position;
							}else if(nowChatID == 24){ //也也4
								guest = chatGirl;
								guestPosIni = guest.transform.position;
							}else if(nowChatID == 25){ //飛馬2
								guest = s3Pegasus;
								guestPosIni = guest.transform.position;
							}else if(nowChatID == 26){ //天球2
								guest = s3SkyBall;
								guestPosIni = guest.transform.position;
							}else if(nowChatID == 27){ //幽靈3
								guest = s2Ghost;
								guestPosIni = guest.transform.position;
							}else if(nowChatID == 28){ //燭台3
								guest = s2Candle;
								guestPosIni = guest.transform.position;
							}else if(nowChatID == 29){ //方半3
								guest = s2SquareF;
								guestPosIni = guest.transform.position;
							}else if(nowChatID == 30){ //老鷹4
								guest = s1Eagle;
								guestPosIni = guest.transform.position;
							}else if(nowChatID == 31){ //蝴蝶4
								guest = s1Butterfly;
								guestPosIni = guest.transform.position;
							}else if(nowChatID == 32){ //方塊4
								guest = s1Square;
								guestPosIni = guest.transform.position;
							}
						}
					}else{
						nowChatID = Random.Range(13,23);
						if(nowChatID == 13){ //飛馬1
							guest = s3Pegasus;
							guestPosIni = guest.transform.position;
						}else if(nowChatID == 14){ //天球1
							guest = s3SkyBall;
							guestPosIni = guest.transform.position;
						}else if(nowChatID == 15){ //幽靈2
							guest = s2Ghost;
							guestPosIni = guest.transform.position;
						}else if(nowChatID == 16){ //燭台2
							guest = s2Candle;
							guestPosIni = guest.transform.position;
						}else if(nowChatID == 17){ //老鷹3
							guest = s1Eagle;
							guestPosIni = guest.transform.position;
						}else if(nowChatID == 18){ //方半2
							guest = s2SquareF;
							guestPosIni = guest.transform.position;
						}else if(nowChatID == 19){ //方塊3
							guest = s1Square;
							guestPosIni = guest.transform.position;
						}else if(nowChatID == 20){ //蝴蝶3
							guest = s1Square;
							guestPosIni = guest.transform.position;
						}else if(nowChatID == 21){ //也也
							guest = chatGirl;
							guestPosIni = guest.transform.position;
						}
					}
				}else{
					nowChatID = Random.Range(5,13);
					if(nowChatID == 5){ //幽靈1
						guest = s2Ghost;
						guestPosIni = guest.transform.position;
					}else if(nowChatID == 6){ //燭台1
						guest = s2Candle;
						guestPosIni = guest.transform.position;
					}else if(nowChatID == 7){ //方半1
						guest = s2SquareF;
						guestPosIni = guest.transform.position;
					}else if(nowChatID == 8){ //也也2
						guest = chatGirl;
						guestPosIni = guest.transform.position;
					}else if(nowChatID == 9){ //方塊2
						guest = s1Square;
						guestPosIni = guest.transform.position;
					}else if(nowChatID == 10){ //蝴蝶2
						guest = s1Butterfly;
						guestPosIni = guest.transform.position;
					}else if(nowChatID == 11){ //老鷹2
						guest = s1Eagle;
						guestPosIni = guest.transform.position;
					}
				}
			}else{
				nowChatID = Random.Range(0,5);
				if(nowChatID == 1){ //女
					guest = chatGirl;
					guestPosIni = guest.transform.position;
				}else if(nowChatID == 2){ //老鷹
					guest = s1Butterfly;
					guestPosIni = guest.transform.position;
				}else if(nowChatID == 3){ //蝴蝶
					guest = s1Eagle;
					guestPosIni = guest.transform.position;
				}else if(nowChatID == 4){ //方塊
					guest = s1Square;
					guestPosIni = guest.transform.position;
				}
			}
		}else if (GUI.Button(seRect[5], "成就")){
			ClickSound();
			showRes=true;
			showSelection=false;
			player.SetActive(false);
			if(resChLevel == GameManager.openLevel+1){
				//成就顯示
				OpenBg(-1);
				ChangeMu(-1);
			}else{
				//時間顯示
				OpenBg(resChLevel);
				ChangeMu(resChLevel);
			}
			//讀取該關時間
			if(resChLevel<=GameManager.openLevel){
				resTime1 = Mathf.FloorToInt(GameManager.bestTime [resChLevel-1,0]);
				resTime2 = Mathf.FloorToInt(GameManager.bestTime [resChLevel-1,1]);
				resTime3 = Mathf.FloorToInt(GameManager.bestTime [resChLevel-1,2]);
			}
		}else if (GUI.Button(seRect[6], "離開遊戲")){
			ClickSound();
			GameManager.Save();
			showSelection = false;
			exitCheck = true;
		}
	}
	//狀態
	void StatusWindow(int windowID){
		GUI.skin.label.fontSize = labFoSi;
		GUI.skin.label.alignment = TextAnchor.UpperLeft;
		GUI.Label (stRect1,"等級："+GameManager.playerLevel);
		GUI.Label (stRect2,"經驗："+GameManager.playerExp.ToString("N0")+"/"+GameManager.GetExpLine().ToString("N0"));
		GUI.Label (stRect3,"力量："+GameManager.GetPlayerAtk().ToString("N0"));
		GUI.Label (stRect4,"防禦："+GameManager.GetPlayerDef().ToString("N0"));
		GUI.Label (stRect5,"血量："+GameManager.GetMineHpL().ToString("N0"));
		GUI.Label (stRect6,"擊碎量："+GameManager.breakCnt.ToString("N0"));
		int playTime = Mathf.FloorToInt(GameManager.playTime);
		GUI.Label (stRect7,"遊戲時間："+
		           ((playTime/3600<10)?"0":"")+playTime/3600+":"+
		           ((playTime/60<10)?"0":"")+(playTime/60)%60+":"+
		           ((playTime%60<10)?"0":"")+playTime%60);
		if(GameManager.wearSk1==0)
			GUI.Label (stRect8,"無技能");
		else
			GUI.Label (stRect8,GameManager.SkName(GameManager.wearSk1)+"\n等級"+GameManager.skLv[GameManager.wearSk1-1]);
		if(GameManager.wearSk2==0)
			GUI.Label (stRect9,"無技能");
		else
			GUI.Label (stRect9,GameManager.SkName(GameManager.wearSk2)+"\n等級"+GameManager.skLv[GameManager.wearSk2-1]);
		if(GameManager.wearSk3==0)
			GUI.Label (stRect10,"無技能");
		else
			GUI.Label (stRect10,GameManager.SkName(GameManager.wearSk3)+"\n等級"+GameManager.skLv[GameManager.wearSk3-1]);
	}
	//目前技能
	void WearWindow(int windowID){
		GUI.skin.button.fontSize = resFoSi;
		GUI.skin.label.fontSize = resFoSi;
		GUI.skin.label.alignment = TextAnchor.MiddleLeft;
		string tmpText;
		if (GameManager.wearSk1 > 0) {
			tmpText = GameManager.SkName (GameManager.wearSk1) + "\nLv" + GameManager.skLv [GameManager.wearSk1 - 1];
			GUI.Label(seRect[1],GameManager.SkHow(GameManager.wearSk1));
		}else{
			tmpText="請選擇技能";
			GUI.Label(seRect[1],"該技能描述");
		}
		if(GUI.Button(seRect[0],tmpText)){
			ClickSound();
			showWear=false;
			player.SetActive(false);
			showSk1=true;
		}
		if(GameManager.openLevel<2){
			tmpText="未解鎖";
			if(GUI.Button(seRect[2],tmpText))
				ClickSound();
		}else{
			if(GameManager.wearSk2>0){
				tmpText = GameManager.SkName(GameManager.wearSk2)+"\nLv"+GameManager.skLv[GameManager.wearSk2-1];
				GUI.Label(seRect[3],GameManager.SkHow(GameManager.wearSk2));
			}else{
				tmpText = "請選擇技能";
				GUI.Label(seRect[3],"該技能描述");
			}
			if(GUI.Button(seRect[2],tmpText)){
				ClickSound();
				showWear=false;
				player.SetActive(false);
				showSk2=true;
			}
		}
		if(GameManager.openLevel<3){
			tmpText="未解鎖";
			if(GUI.Button(seRect[4],tmpText))
				ClickSound();
		}else{
			if(GameManager.wearSk3>0){
				tmpText=GameManager.SkName(GameManager.wearSk3)+"\nLv"+GameManager.skLv[GameManager.wearSk3-1];
				GUI.Label(seRect[5],GameManager.SkHow(GameManager.wearSk3));
			}else{
				tmpText="請選擇技能";
				GUI.Label(seRect[5],"該技能描述");
			}
			if(GUI.Button(seRect[4],tmpText)){
				ClickSound();
				showWear=false;
				player.SetActive(false);
				showSk3=true;
			}
		}
		if(GUI.Button(seRect[6],"全部卸下")){
			ClickSound();
			GameManager.wearSk1=0;
			GameManager.wearSk2=0;
			GameManager.wearSk3=0;
		}
	}
	void skillsWindow(int windowID){
		//技能頁數
		GUI.skin.label.fontSize = resFoSi;
		GUI.Label (new Rect (Screen.width*0.01f,Screen.height*0.72f,Screen.width*0.1f,Screen.height*0.1f), skPageNum+"/3");
		//技能
		GUI.skin.button.fontSize = labFoSi;
		for(int i=skRLine-5,j=0;i<skRLine && i<GameManager.skLv.Length;i++,j++){
			if(GameManager.skOpen[i]){
				if(GUI.Button(skRect[j],GameManager.SkName(i+1)+"\nLv"+GameManager.skLv[i])){
					ClickSound();
					skHowText = GameManager.SkHow(i+1);
					if(skNowChoose != i+1){
						skNowChoose = i+1;
					}else{
						//選完返回
						skHowText = "請選擇一個技能";
						skNowChoose = 0;
						if(windowID==1){
							//重複裝備卸下
							if(GameManager.wearSk2 == i+1)
								GameManager.wearSk2 = 0;
							if(GameManager.wearSk3 == i+1)
								GameManager.wearSk3 = 0;
							//穿上
							GameManager.wearSk1 = i+1;
						}else if(windowID==2){
							//重複裝備卸下
							if(GameManager.wearSk1 == i+1)
								GameManager.wearSk1 = 0;
							if(GameManager.wearSk3 == i+1)
								GameManager.wearSk3 = 0;
							//穿上
							GameManager.wearSk2 = i+1;
						}else if(windowID==3){
							//重複裝備卸下
							if(GameManager.wearSk1 == i+1)
								GameManager.wearSk1 = 0;
							if(GameManager.wearSk2 == i+1)
								GameManager.wearSk2 = 0;
							//穿上
							GameManager.wearSk3 = i+1;
						}
						showWear = true;
						showSk1 = false;
						showSk2 = false;
						showSk3 = false;
						player.SetActive(true);
					}
				}
			}else{
				if(GUI.Button(skRect[j],"未取得")){
					ClickSound();
					if(i==0)
						skHowText = "商店購買後取得";
					else
						skHowText = "關卡中機率性取得";
				}
			}
		}
		GUI.skin.button.fontSize = butFoSi+butFoSi;
		if(GUI.Button(skLeRect,"◁")){
			ClickSound();
			if(skRLine > 5){
				skRLine -= 5;
				skPageNum --;
			}
		}
		if(GUI.Button(skRiRect,"▷")){
			ClickSound();
			if(skRLine < GameManager.skLv.Length){
				skRLine += 5;
				skPageNum ++;
			}
		}
	}
	void shopWindow(int windowID){
		GUI.skin.button.fontSize = resFoSi;
		//商店商品
		for(int i=shRLine-6,j=0;i<shRLine && i<GameManager.shOpen.Length;i++,j++){
			if(GameManager.shOpen[i]){
				if(i==9 && GameManager.skLv[9] > 99){
					if(GUI.Button(seRect[j],GameManager.ShName(i+1)+"\n無法購買")){
						ClickSound();
						shHowText = "技能等級已滿";
						shNowChoose=0;
					}
				}else if(i==7 && GameManager.skLv[7] > 99){
					if(GUI.Button(seRect[j],GameManager.ShName(i+1)+"\n無法購買")){
						ClickSound();
						shHowText = "技能等級已滿";
						shNowChoose=0;
					}
				}else if(i==10 && GameManager.skLv[10] > 99){
					if(GUI.Button(seRect[j],GameManager.ShName(i+1)+"\n無法購買")){
						ClickSound();
						shHowText = "技能等級已滿";
						shNowChoose=0;
					}
				}else{
					if(GUI.Button(seRect[j],GameManager.ShName(i+1)+"\n$"+GameManager.ShPrice(i+1).ToString("N0"))){
						ClickSound();
						shHowText = GameManager.ShHow(i+1);
						shNowChoose = i+1;
					}
				}
			}else{
				if(GUI.Button(seRect[j],"未進貨")){
					ClickSound();
					shHowText = "取得某技能後解鎖";
					shNowChoose=0;
				}
			}
		}
		GUI.skin.button.fontSize = butFoSi;
		if(GUI.Button(shByRect,"購買")){
			if(shNowChoose!=0 && GameManager.money >= GameManager.ShPrice(shNowChoose)){
				shHowText = "成功購買"+GameManager.ShName(shNowChoose)+"，一共是$"+GameManager.ShPrice(shNowChoose).ToString("N0")+"。";
				GameManager.money -= GameManager.ShPrice(shNowChoose);
				GameManager.ShAct(shNowChoose);
				MoneySE();
				if((shNowChoose == 10 && GameManager.skLv[9] > 99) || (shNowChoose == 8 && GameManager.skLv[7] > 99) || (shNowChoose == 11 && GameManager.skLv[10] > 99))
					shNowChoose = 0;
			}else{
				ErrSE();
				if(shNowChoose==0)
					shHowText = "請選擇一項商品";
				else
					shHowText = "金錢不足，差額$"+(GameManager.ShPrice(shNowChoose)-GameManager.money).ToString("N0")+"。";
			}
		}
		GUI.skin.button.fontSize = butFoSi+butFoSi;
		if(GUI.Button(shLeRect,"◁")){
			ClickSound();
			if(shRLine > 6)
				shRLine -= 6;
		}
		if(GUI.Button(shRiRect,"▷")){
			ClickSound();
			if(shRLine < GameManager.shOpen.Length)
				shRLine += 6;
		}
	}
	void resTimeWindow(int windowID){
		GUI.skin.label.alignment = TextAnchor.MiddleLeft;
		GUI.skin.label.fontSize = resFoSi;
		GUI.Label (resTimeRects[0],"最佳成績："+
		           ((resTime1/3600<10)?"0":"")+(resTime1/3600).ToString()+":"+
		           ((resTime1/60<10)?"0":"")+((resTime1/60)%60).ToString()+":"+
		           ((resTime1%60<10)?"0":"")+(resTime1%60).ToString()+
		           "　"+GameManager.Star(GameManager.bestStar[resChLevel-1,0])+
		           "\n該次頭目："+GameManager.BossName(GameManager.bestBoss[resChLevel-1,0])+
		           ((resChLevel!=5)?((GameManager.bestPass[resChLevel-1,0])?"(獲勝)":"(未獲勝)"):"")+
		           " 頭目等級"+GameManager.bestLv[resChLevel-1,0]+
		           "\n遺漏數："+GameManager.bestLost[resChLevel-1,0].ToString("N0"));
		GUI.Label (resTimeRects[1],"次佳成績："+
		           ((resTime2/3600<10)?"0":"")+(resTime2/3600).ToString()+":"+
		           ((resTime2/60<10)?"0":"")+((resTime2/60)%60).ToString()+":"+
		           ((resTime2%60<10)?"0":"")+(resTime2%60).ToString()+
		           "　"+GameManager.Star(GameManager.bestStar[resChLevel-1,1])+
		           "\n該次頭目："+GameManager.BossName(GameManager.bestBoss[resChLevel-1,1])+
		           ((resChLevel!=5)?((GameManager.bestPass[resChLevel-1,1])?"(獲勝)":"(未獲勝)"):"")+
		           " 頭目等級"+GameManager.bestLv[resChLevel-1,1]+
		           "\n遺漏數："+GameManager.bestLost[resChLevel-1,1].ToString("N0"));
		GUI.Label (resTimeRects[2],"三佳成績："+
		           ((resTime3/3600<10)?"0":"")+(resTime3/3600).ToString()+":"+
		           ((resTime3/60<10)?"0":"")+((resTime3/60)%60).ToString()+":"+
		           ((resTime3%60<10)?"0":"")+(resTime3%60).ToString()+
		           "　"+GameManager.Star(GameManager.bestStar[resChLevel-1,2])+
		           "\n該次頭目："+GameManager.BossName(GameManager.bestBoss[resChLevel-1,2])+
		           ((resChLevel!=5)?((GameManager.bestPass[resChLevel-1,2])?"(獲勝)":"(未獲勝)"):"")+
		           " 頭目等級"+GameManager.bestLv[resChLevel-1,2]+
		           "\n遺漏數："+GameManager.bestLost[resChLevel-1,2].ToString("N0"));
	}
	void resResWindow(int windowID){
		GUI.skin.button.fontSize = resFoSi;
		//成就
		for(int i=resRLine-7,j=0;i<resRLine && i<GameManager.resGet.Length;i++,j++){
			if(GameManager.resGet[i]){
				if(GUI.Button(resResRects[j],GameManager.ResName(i+1))){
					ClickSound();
					resHowText = GameManager.ResHow(i+1);
				}
			}else{
				if(GUI.Button(resResRects[j],"？？？")){
					ClickSound();
					resHowText = GameManager.ResTips(i+1);
				}
			}
		}
		GUI.skin.button.fontSize = butFoSi+butFoSi;
		if(GUI.Button(resResRects[7],"◁")){
			ClickSound();
			if(resRLine > 7)
				resRLine -= 7;
		}
		if(GUI.Button(resResRects[8],"▷")){
			ClickSound();
			if(resRLine < GameManager.resGet.Length)
				resRLine += 7;
		}
	}
	void staCheckWindow(int windowID){
		GUI.skin.label.alignment = TextAnchor.UpperCenter;
		GUI.skin.label.fontSize = labFoSi;
		GUI.Label (staCheLaRect, "確認開始？");
		GUI.skin.button.fontSize = resFoSi;
		if (GUI.Button (staYesRect, "是")) {
			ClickSound();
			showGUI = false;
			Instantiate(ldFace,new Vector3(0f,0f,0.5f),Quaternion.identity);
			GameManager.playingLevel = nowChoseLevel;
			Application.LoadLevel("playing");
		}
		if (GUI.Button (staNoRect, "否")) {
			ClickSound();
			showStaCheck = false;
		}
	}
	void exitCheWin(int windowID){
		GUI.skin.label.alignment = TextAnchor.UpperCenter;
		GUI.skin.label.fontSize = labFoSi;
		GUI.Label (staCheLaRect, "結束遊戲？");
		GUI.skin.button.fontSize = resFoSi;
		if (GUI.Button (staYesRect, "是")) {
			ClickSound();
			Application.Quit();
		}
		if (GUI.Button (staNoRect, "否")) {
			ClickSound();
			exitCheck = BackToHall();
		}
	}
	void staHowWindow(int windowID){
		GUI.skin.label.alignment = TextAnchor.UpperLeft;
		GUI.skin.label.fontSize = resFoSi;
		GUI.Label (staHowLaRect, "關卡等級："+((GameManager.StaLevel(nowChoseLevel)>99)?"\n":"")+GameManager.StaLevel(nowChoseLevel));
		if(nowChoseLevel>0)
			GUI.Label (staHowLaRect2, "探索"+GameManager.StaFinBosPa(nowChoseLevel));
	}
	void getResWindow(int WindowID){
		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		GUI.skin.label.fontSize = resFoSi;
		GUI.Label (getResLabRec, getResText);
	}
	#region chatWindow
	void chatWindow(int windowID){
		GUI.skin.label.alignment = TextAnchor.UpperLeft;
		GUI.skin.label.fontSize = labFoSi;
		GUI.Label(new Rect(chatRect.width*0.01f,chatRect.height*0.1f,chatRect.width,chatRect.height),chatString);
		if(windowID==0){ //拉勇1
			if(chatStep==0){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n嗯......";
				}
			}else if(chatStep==1){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n看來這個功能可以蒐集情報、甚至打開世界中的某些開關呢...";
				}
			}else if(chatStep==2){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerShak = true;
					playEndSe = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n現在好像沒什麼人在，先離開吧！";
				}
			}else{
				if(GameManager.chatLine == windowID){
					GameManager.chatLine++; //增加其他可能
				}
				playerDM = true; //別動
				chatStep = -1;
				showChat = BackToHall();
			}
		}else if(windowID==1){ //也也1
			if(chatStep==0){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = "(聊天對象搜尋中．．．)";
				}
			}else if(chatStep==1){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = true;
					guestDM = false;
					chatGirl.GetComponent<ChatFace>().Girl_sLaugh();
					chatGirl.SetActive(true);
					guestShak = true;
					//對話
					chatString = "？？？\n诶? " + GameManager.GetNpcName(1) + "好久不見！！";
				}
			}else if(chatStep==2){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n唔唔唔喔喔！！！\n這不是我暗戀已久的" + GameManager.GetNpcName(2) + "美女嗎！！！";
				}
			}else if(chatStep==3){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					chatGirl.GetComponent<ChatFace>().Girl_laugh();
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.GetNpcName(2) + "\n什麼？ 你剛剛說什麼？\n沒聽清楚吶！";
				}
			}else if(chatStep==4){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n啊啊啊不不不～\n我是說這不是超可愛的" + GameManager.GetNpcName(2) + "小姐嗎～";
				}
			}else if(chatStep==5){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					chatGirl.GetComponent<ChatFace>().Girl_sLaugh();
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.GetNpcName(2) + "\n诶～"+GameManager.GetNpcName(1)+"的嘴巴真甜～～\n剛剛講的不是騙我的吧？";
				}
			}else if(chatStep==6){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n呃......嗯？(難道說她有聽到?)\n啊～～我剛剛是隨便亂講的～～(我在說什麼啊?)";
				}
			}else if(chatStep==7){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					chatGirl.GetComponent<ChatFace>().Girl_giveup();
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.GetNpcName(2) + "\n你說什麼！！\n真是的！ " + GameManager.GetNpcName(1) + "真無情！！";
				}
			}else if(chatStep==8){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					chatGirl.SetActive(false);
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n啊啊啊！！！！！等等啊！！！";
				}
			}else if(chatStep==9){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerShak = true;
					playEndSe = true;
					if (!GameManager.resGet [2]) {
						//成就聊天
						MoneySE();
						getResText = "成就完成！\n" + GameManager.ResName(3) + "\n$" + GameManager.ResBackMoney(3).ToString("N0");
						getRes = true;
						showResTimer = 7f;
						GameManager.money += GameManager.ResBackMoney(3);
						GameManager.resGet [2] = true;
					}
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n可惡！為了能再遇到" + GameManager.GetNpcName(2) + "，我還要再多多加強才行！";
				}
			}else{
				if(GameManager.chatLine == windowID){
					GameManager.chatLine++; //增加其他可能
				}
				playerDM = true; //別動
				chatStep = -1;
				showChat = BackToHall();
			}
		}else if(windowID == 2){ //第一次老鷹
			if(chatStep==0){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = "(聊天對象搜尋中．．．)";
				}
			}else if(chatStep==1){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					guestDM = true;
					guest.SetActive(true);
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1) + " <主角>\n！！！！！！！！！！";
				}
			}else if(chatStep==2){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					guestDM = true;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1) + " <主角>\n這傢伙...好像是外星人...";
				}
			}else if(chatStep==3){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(1) + "\n......挖哩勒...\n原來你也在用JTalk嗎？";
				}
			}else if(chatStep==4){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1) + " <主角>\nJTalk？\n原來這個App叫JTalk啊！";
				}
			}else if(chatStep==5){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(1) + "\n唉呀呀呀～～\n不小心讓你成長了啊！！";
				}
			}else if(chatStep==6){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1) + " <主角>\n呿！！  這根本沒什麼！！";
				}
			}else if(chatStep==7){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(1) + "\n哼...算了～～\n連這個都不知道的話......看來我其他兩個夥伴也能輕鬆解決你呢！";
				}
			}else if(chatStep==8){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guest.SetActive(false);
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1) + " <主角>\nWhat！！！！！！";
				}
			}else if(chatStep==9){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guest.SetActive(false);
					guestDM = true;
					playerDM = false;
					playerShak = true;
					playEndSe = true;
					//對話
					chatString = GameManager.GetNpcName(1) + " <主角>\n感覺好像有危險了！ 好像敵人不只一隻的樣子，看來要小心點了！";
				}
			}else{
				if(GameManager.chatLine == windowID){
					GameManager.chatLine++; //增加其他可能
				}
				playerDM = true; //別動
				chatStep = -1;
				showChat = BackToHall();
			}
		}else if(windowID == 3){ //蝴蝶1
			if(chatStep==0){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = "(聊天對象搜尋中．．．)";
				}
			}else if(chatStep==1){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					guestDM = true;
					guest.SetActive(true);
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1) + " <主角>\n！！！！！！！！！！";
				}
			}else if(chatStep==2){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					guestDM = true;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1) + " <主角>\n咦．．．？ 好大隻的蝴蝶．．．．．．";
				}
			}else if(chatStep==3){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(2) + "\n................(剛睡醒)";
				}
			}else if(chatStep==4){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(2) + "\n哦哦！！ 你會說話嗎？！\n你叫什麼名子？ 好新鮮的傢伙！！";
				}
			}else if(chatStep==5){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					guestDM = true;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1) + " <主角>\n(我靠! 你會說話才奇怪好不好!)";
				}
			}else if(chatStep==6){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					guestDM = true;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1) + " <主角>\n啊啊!  我胸前剛好有張名片可以給你!\n我是拉勇，工作是消滅奇葩...";
				}
			}else if(chatStep==7){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(2) + "\n哦哦～～我的工作也是消滅奇葩吔！！\n你是消滅怎麼樣的奇葩??";
				}
			}else if(chatStep==8){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					guestDM = true;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1) + " <主角>\n恩......這個我也說不太清楚，我要消滅的奇葩有各種各樣的......";
				}
			}else if(chatStep==9){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					playEndSe = true;
					//對話
					chatString = GameManager.BossName(2) + "\n哈哈哈！！ 跟我一樣！！\n說不定，我們會在哪裡重逢呢！！";
				}
			}else{
				if(GameManager.chatLine == windowID){
					GameManager.chatLine++; //增加其他可能
				}
				guest.SetActive(false);
				playerDM = true; //別動
				chatStep = -1;
				showChat = BackToHall();
			}
		}else if(windowID == 4){ //方塊1
			if(chatStep==0){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = "(聊天對象搜尋中．．．)";
				}
			}else if(chatStep==1){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					guestDM = true;
					guest.SetActive(true);
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1) + " <主角>\n！！！！！！！！！！";
				}
			}else if(chatStep==2){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					guestDM = true;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1) + " <主角>\n天哪．．．我快被嚇破膽了啊．．．　怎麼都遇到一些奇怪的傢伙．．．";
				}
			}else if(chatStep==3){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(3) + "\n嚇個P啊！！ 你叫拉勇是吧？？ 我長得很恐怖嗎？？";
				}
			}else if(chatStep==4){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					guestDM = true;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1) + " <主角>\n唔唔唔喔喔！！ 這莫名其妙的東西居然會知道我的名子！！";
				}
			}else if(chatStep==5){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(3) + "\n莫名其妙的東西？！ 難道被知道我中午吃了什麼？\n你好樣的！ 不能這樣簡單判斷一個人的好壞啊！！";
				}
			}else if(chatStep==6){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					guestDM = true;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1) + " <主角>\n(...都你在說)\n(不過好像聽到了什麼有趣的東西...)";
				}
			}else if(chatStep==7){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					guestDM = true;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1) + " <主角>\n沒有啦！！ 我根本不知道你中午吃了什麼東西！！ (咦？他要怎麼吃東西？)\n你沒有嘴巴要怎麼吃東西啊？";
				}
			}else if(chatStep==8){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(3) + "\n(他說我是啞巴？)\n你這臭傢伙！！ 下次走著瞧！！";
				}
			}else if(chatStep==9){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					guestDM = true;
					playerShak = true;
					playEndSe = true;
					guest.SetActive(false);
					//對話
					chatString = GameManager.GetNpcName(1) + " <主角>\n噢天啊！！！ 他好像生氣了！！！";
				}
			}else{
				if(GameManager.chatLine == windowID){
					GameManager.chatLine++; //增加其他可能
				}
				playerDM = true; //別動
				chatStep = -1;
				showChat = BackToHall();
			}
		}else if(windowID == 5){ //幽靈1
			if(chatStep==0){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = "(聊天對象搜尋中．．．)";
				}
			}else if(chatStep==1){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guest.SetActive(true);
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(4) + "\n你~~偷~~拿~~我~~的~~東~~西~~";
				}
			}else if(chatStep==2){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					guestDM = true;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1) + " <主角>\n唔唔唔喔喔！！ 好幽靈！！";
				}
			}else if(chatStep==3){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(4) + "\n別~~裝~~傻~~啦~~快~~還~~來~~";
				}
			}else if(chatStep==4){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					guestDM = true;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1) + " <主角>\n等等等等！！ 你掉了什麼東西？ 我應該沒拿才對！";
				}
			}else if(chatStep==5){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(4) + "\n錢~~包~~";
				}
			}else if(chatStep==6){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					guestDM = true;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1) + " <主角>\n噢買尬！！ 那可真不得了！！\n......是說...你們也會花錢?";
				}
			}else if(chatStep==7){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(4) + "\n乾~~XX咧~~快~~點~~還~~我~~";
				}
			}else if(chatStep==8){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					guestDM = true;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1) + " <主角>\n喂～～不是我拿的啦！！ 離我遠一點！！";
				}
			}else if(chatStep==9){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					playEndSe = true;
					//對話
					chatString = GameManager.BossName(4) + "\n嗚~~嗚~~嗚~~";
				}
			}else{
				if(GameManager.chatLine == windowID){
					GameManager.chatLine++; //增加其他可能
				}
				guest.SetActive(false);
				playerDM = true; //別動
				chatStep = -1;
				showChat = BackToHall();
			}
		}else if(windowID == 6){ //燭台1
			if(chatStep==0){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = "(聊天對象搜尋中．．．)";
				}
			}else if(chatStep==1){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guest.SetActive(true);
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(5) + "\nHi！！ 我最近聽到一個笑話！要聽聽看嗎？";
				}
			}else if(chatStep==2){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					guestDM = true;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1) + " <主角>\n啊！ 你是...";
				}
			}else if(chatStep==3){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(5) + "\n就是．．．．．．";
				}
			}else if(chatStep==4){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					guestDM = true;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1) + " <主角>\n(這傢伙怎顧自的說起來了)";
				}
			}else if(chatStep==5){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(5) + "\n有ㄧ天哇沙米走在路上被人打了一頓，哇沙米就問：你幹嘛打我？ 路人就說：啊你不是很嗆？！";
				}
			}else if(chatStep==6){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(5) + "\n是不是很好笑啊？";
				}
			}else if(chatStep==7){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					//對話
					chatString = "(一陣冷風吹過)";
				}
			}else if(chatStep==8){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					guestDM = true;
					playerShak = true;
					playEndSe = true;
					//對話
					chatString = GameManager.GetNpcName(1) + " <主角>\n呵呵.. (冷笑)";
				}
			}else{
				if(GameManager.chatLine == windowID){
					GameManager.chatLine++; //增加其他可能
				}
				guest.SetActive(false);
				playerDM = true; //別動
				chatStep = -1;
				showChat = BackToHall();
			}
		}else if(windowID == 7){ //方半1
			if(chatStep==0){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = "(聊天對象搜尋中．．．)";
				}
			}else if(chatStep==1){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guest.SetActive(true);
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(6) + "\n窩(wo)~~科(ker)~~科(ker)~~";
				}
			}else if(chatStep==2){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					guestDM = true;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1) + " <主角>\n！！！！！！\n好強大的陰謀氣息！ 是你幹的嗎？";
				}
			}else if(chatStep==3){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(6) + "\n哼哼哼～～ Chaos已經開始了！\n誰都還不知道事實的真相！ 到時候你們都會變成那個樣子！";
				}
			}else if(chatStep==4){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					guestDM = true;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1) + " <主角>\n噢天啊！！ 什麼東西都聽不懂！！";
				}
			}else if(chatStep==5){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(6) + "\n嘻嘻嘻～～～\n我的頭越來越重了，好像不能在這裡待太久了！";
				}
			}else if(chatStep==6){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					guestDM = true;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1) + " <主角>\n(啊！ 好像只是單純的想睡覺而已！)";
				}
			}else if(chatStep==7){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					guestDM = true;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1) + " <主角>\n噗噗噗～～ 想睡覺就快去吧！！";
				}
			}else if(chatStep==8){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					playEndSe = true;
					//對話
					chatString = GameManager.BossName(6) + "\n你居然小看我！！\n哼～！ 下次就讓你見識見識我的發明！！";
				}
			}else{
				if(GameManager.chatLine == windowID){
					GameManager.chatLine++; //增加其他可能
				}
				guest.SetActive(false);
				playerDM = true; //別動
				chatStep = -1;
				showChat = BackToHall();
			}
		}else if(windowID == 8){ //女角2
			if(chatStep==0){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = "(聊天對象搜尋中．．．)";
				}
			}else if(chatStep==1){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = true;
					guestDM = false;
					chatGirl.GetComponent<ChatFace>().Girl_sLaugh();
					guest.SetActive(true);
					guestShak = true;
					//對話
					chatString = GameManager.GetNpcName(2) + "\n啊！！\n是"+GameManager.GetNpcName(1)+"！！！";
				}
			}else if(chatStep==2){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					guestDM = true;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1) + " <主角>\n也...也也！！！！！！";
				}
			}else if(chatStep==3){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.GetNpcName(2) + "\n等等有沒有空？ 我們等等一起去外面逛逛吧！～～";
				}
			}else if(chatStep==4){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					guestDM = true;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1) + " <主角>\n好！！　當然好！！\n雖然想這麼說...不過還是下次吧！ 我現在離不開......";
				}
			}else if(chatStep==5){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					chatGirl.GetComponent<ChatFace>().Girl_sLaugh();
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.GetNpcName(2) + "\n诶诶～～ 拉勇工作太認真了啦！～ 我們一起去逛街比較有趣嘛！～";
				}
			}else if(chatStep==6){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					guestDM = true;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1) + " <主角>\n唔唔唔喔喔喔！！！！！！  沒問題！！！  我們走！！！";
				}
			}else if(chatStep==7){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					chatGirl.GetComponent<ChatFace>().Girl_sLaugh();
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.GetNpcName(2) + "\n哇啊啊啊！！！ 太棒了！！\n那我在外頭等你過來～～～";
				}
			}else if(chatStep==8){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guest.SetActive(false);
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n.......................................... (腳拔不起來)";
				}
			}else if(chatStep==9){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					playEndSe = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n天啊！！ 我沒辦法跟也也赴約了，得趕快打給她取消才行！";
				}
			}else{
				if(GameManager.chatLine == windowID){
					GameManager.chatLine++; //增加其他可能
				}
				playerDM = true; //別動
				chatStep = -1;
				showChat = BackToHall();
			}
		}else if(windowID == 9){ //方塊2
			if(chatStep==0){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = "(聊天對象搜尋中．．．)";
				}
			}else if(chatStep==1){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n咦...？\n有人嗎？ 好像有人......人哩......？";
				}
			}else if(chatStep==2){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guest.SetActive(true);
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(3) + "\n寫特！！ 我根本沒做錯什麼！！";
				}
			}else if(chatStep==3){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n你怎麼啦？～ 好好冷靜下來我聽你說！！";
				}
			}else if(chatStep==4){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(3) + "\n什麼？！ 我講的笑話很冷嗎？ 怎麼連你也這樣說？";
				}
			}else if(chatStep==5){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n不不不不不......我是叫你冷靜......";
				}
			}else if(chatStep==6){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(3) + "\nNOOOOO～～～～～～\n我的老婆也是對我這樣說的～～～～～～";
				}
			}else if(chatStep==7){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guest.SetActive(false);
					//對話
					chatString = "(方塊離開了房間)";
				}
			}else if(chatStep==8){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playEndSe = true;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\nOh～ Sh@t！！ 好像又惹他生氣了！！";
				}
			}else{
				if(GameManager.chatLine == windowID){
					GameManager.chatLine++; //增加其他可能
				}
				playerDM = true; //別動
				chatStep = -1;
				showChat = BackToHall();
			}
		}else if(windowID == 10){ //蝴蝶2
			if(chatStep==0){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = "(聊天對象搜尋中．．．)";
				}
			}else if(chatStep==1){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guest.SetActive(true);
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n！！！！！！";
				}
			}else if(chatStep==2){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n又是好大隻的蝴蝶．．．";
				}
			}else if(chatStep==3){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(2) + "\n...............................(剛睡醒)";
				}
			}else if(chatStep==4){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(2) + "\n哦哦！！ 你來得正好！！\n我按Ctrl+V沒辦法貼上耶！！ 快來幫我看看！！";
				}
			}else if(chatStep==5){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n(我靠！ 你們居然也在用Ctrl+V！)";
				}
			}else if(chatStep==6){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n(作業系統...Jindows？！ 怎麼有這樣子的作業系統！ 好奇怪的鍵盤！ 我按不了Ctrl+V！)";
				}
			}else if(chatStep==7){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(2) + "\n挖靠！！ 成功了耶！！\n你怎麼用的？ 也教教我吧！！";
				}
			}else if(chatStep==8){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n兒......我自己也覺得很神奇，莫名其妙就好了！";
				}
			}else if(chatStep==9){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playEndSe = true;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(2) + "\n別藏招啦！！ 我一定要知道要怎麼Ctrl+V才行！！";
				}
			}else{
				if(GameManager.chatLine == windowID){
					GameManager.chatLine++; //增加其他可能
				}
				guest.SetActive(false);
				playerDM = true; //別動
				chatStep = -1;
				showChat = BackToHall();
			}
		}else if(windowID == 11){ //老鷹2
			if(chatStep==0){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = "(聊天對象搜尋中．．．)";
				}
			}else if(chatStep==1){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guest.SetActive(true);
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n！！！！！！";
				}
			}else if(chatStep==2){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n這揮動的風......有機會讓裙子飄起來！！";
				}
			}else if(chatStep==3){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(1) + "\n......拉勇\n您真是癡漢呢...";
				}
			}else if(chatStep==4){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n驚呆！！！！！！！";
				}
			}else if(chatStep==5){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n我不是癡漢......我不是癡漢......我不是癡漢......我不是癡漢......我不是癡漢......";
				}
			}else if(chatStep==6){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(1) + "\n放心吧！ 你不是一個人！ 我們可以做朋友！";
				}
			}else if(chatStep==7){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n我靠！ 不要跟我講你奇怪的嗜好！";
				}
			}else if(chatStep==8){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playEndSe = true;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(1) + "\n不要這麼拘束嘛！ 我陪著你的！";
				}
			}else{
				if(GameManager.chatLine == windowID){
					GameManager.chatLine++; //增加其他可能
				}
				guest.SetActive(false);
				playerDM = true; //別動
				chatStep = -1;
				showChat = BackToHall();
			}
		}else if(windowID == 12){ //拉勇2
			if(chatStep==0){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = "(似乎沒有可聊天的對象．．．)";
				}
			}else if(chatStep==1){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n居然還要績效考核......";
				}
			}else if(chatStep==2){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n績效考核真是扯後腿！！ 妨礙我的工作！！";
				}
			}else if(chatStep==3){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n這根本沒辦法考核真正努力工作的人！ 只能考核努力做報告的人！";
				}
			}else if(chatStep==4){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playEndSe = true;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n社會上真是充滿了各式各樣病態的規定！ 為什麼都沒人發現呢？";
				}
			}else{
				if(GameManager.chatLine == windowID){
					GameManager.chatLine++; //增加其他可能
				}
				guest.SetActive(false);
				playerDM = true; //別動
				chatStep = -1;
				showChat = BackToHall();
			}
		}else if(windowID == 13){ //飛馬1
			if(chatStep==0){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = "(聊天對象搜尋中．．．)";
				}
			}else if(chatStep==1){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guest.SetActive(true);
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(7) + "\n喔喔喔喔喔！！！ 真是可愛的孩子！ 當我的女朋友吧！！";
				}
			}else if(chatStep==2){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n～！＠＃＄％︿＆\nWhat！！！ 可是我是男的啊？";
				}
			}else if(chatStep==3){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(7) + "\n男的有什麼關係～？ 只要可愛就行了！！";
				}
			}else if(chatStep==4){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n考邀！！ 你走開！！ 我要下線了！！";
				}
			}else if(chatStep==5){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(7) + "\n嘿嘿嘿～～～～ 我已經把登出給駭掉了，你就老老實實的當我女朋友...";
				}
			}else if(chatStep==6){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n囧  拜託不要，放過我吧大大！！";
				}
			}else if(chatStep==7){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					playerShak = true;
					guestDM = false;
					guestShak = true;
					//對話
					chatString = "(經過了一段快樂的時間......)";
				}
			}else if(chatStep==8){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playEndSe = true;
					playerDM = false;
					playerShak = true;
					guestDM = false;
					guestShak = true;
					//對話
					chatString = "(又再經過了一段快樂的時間......)";
				}
			}else{
				if(GameManager.chatLine == windowID){
					GameManager.chatLine++; //增加其他可能
				}
				guest.SetActive(false);
				playerDM = true; //別動
				chatStep = -1;
				showChat = BackToHall();
			}
		}else if(windowID == 14){ //天球1
			if(chatStep==0){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = "(聊天對象搜尋中．．．)";
				}
			}else if(chatStep==1){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guest.SetActive(true);
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n請問...... 有沒有撿到我的AK47？";
				}
			}else if(chatStep==2){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(8) + "\n哦...？ 我找找......";
				}
			}else if(chatStep==3){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(8) + "\n你掉的是金色的AK47？ 還是黑色的AK47？ 還是這把破破爛爛的AK47？";
				}
			}else if(chatStep==4){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(8) + "\n啊對了...我還撿到一個錢包上面寫著\"幽靈\"\n...這也是你掉的嗎？";
				}
			}else if(chatStep==5){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n我靠！！ 你好多東西啊！！ 我掉的是金色的AK47！！";
				}
			}else if(chatStep==6){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(8) + "\n啊啊！！ 不要靠過來！ 我通通都給你！ 放在地上！";
				}
			}else if(chatStep==7){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guest.SetActive(false);
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n等等啊！！ 我不要這麼多東西！！";
				}
			}else if(chatStep==8){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playEndSe = true;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n(我靠！！ 幽靈的錢包！！ 這下子麻煩了...)";
				}
			}else{
				if(GameManager.chatLine == windowID){
					GameManager.chatLine++; //增加其他可能
				}
				playerDM = true; //別動
				chatStep = -1;
				showChat = BackToHall();
			}
		}else if(windowID == 15){ //幽靈2
			if(chatStep==0){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = "(聊天對象搜尋中．．．)";
				}
			}else if(chatStep==1){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guest.SetActive(true);
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(4) + "\n快~~把~~東~~西~~還~~給~~我~~";
				}
			}else if(chatStep==2){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n太棒了！！ 找到失主了！！ 你掉的是這個錢包吧？";
				}
			}else if(chatStep==3){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(4) + "\n是~~~~~~";
				}
			}else if(chatStep==4){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(4) + "\n是~~破~~破~~爛~~爛~~的~~A~~K~~4~~7~~!!";
				}
			}else if(chatStep==5){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n挖哩咧！！ 那個我把他丟了！！ 你怎麼會有那種東西！！";
				}
			}else if(chatStep==6){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(4) + "\n嗚~~嗚~~嗚~~\n我~~要~~去~~垃~~圾~~堆~~裡~~找~~回~~來~~";
				}
			}else if(chatStep==7){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guest.SetActive(false);
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n咦？ 原來還在我身上...丟錯丟到黑色的AK47了......";
				}
			}else if(chatStep==8){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playEndSe = true;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n幽靈？？ 你還在這嗎？？";
				}
			}else{
				if(GameManager.chatLine == windowID){
					GameManager.chatLine++; //增加其他可能
				}
				playerDM = true; //別動
				chatStep = -1;
				showChat = BackToHall();
			}
		}else if(windowID == 16){ //燭台2
			if(chatStep==0){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = "(聊天對象搜尋中．．．)";
				}
			}else if(chatStep==1){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\nOh！ Sh@t！ 我好像把誰的水給打翻了！";
				}
			}else if(chatStep==2){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guest.SetActive(true);
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(5) + "\n沒關係！！！ 交給我來處理！！！";
				}
			}else if(chatStep==3){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(5) + "\n你OX的！！ 這是我的水！！ 這水很貴的！！ 你要怎麼陪我！！";
				}
			}else if(chatStep==4){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n(交出了光金色的AK47)";
				}
			}else if(chatStep==5){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(5) + "\n哇靠！！ 這把AK47會不會太炫砲！！ 你的誠意十足！！";
				}
			}else if(chatStep==6){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(5) + "\n傲傲喔喔喔！！！！ 好像開始融化了耶！！";
				}
			}else if(chatStep==7){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(5) + "\n你給我這麼好的東西！！ 地上的水就給你喝好了！！ 你要好好感謝我！！ 哈哈哈哈哈哈哈！！！！";
				}
			}else if(chatStep==8){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guest.SetActive(false);
					playEndSe = true;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n我靠!! 鬼才喝地上的水!!\n話說......燭台要怎麼喝水啊？ 這真的是他的水杯？";
				}
			}else{
				if(GameManager.chatLine == windowID){
					GameManager.chatLine++; //增加其他可能
				}
				playerDM = true; //別動
				chatStep = -1;
				showChat = BackToHall();
			}
		}else if(windowID == 17){ //老鷹3
			if(chatStep==0){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = "(聊天對象搜尋中．．．)";
				}
			}else if(chatStep==1){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guest.SetActive(true);
					playerDM = false;
					playerShak = true;
					guestDM = false;
					guestShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n噢噢！！！！！！ (撞上)";
				}
			}else if(chatStep==2){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n我看到了！！ 你的嘴裡含著女性內褲！！";
				}
			}else if(chatStep==3){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(1) + "\n等等等等......你別這麼大聲嘛......";
				}
			}else if(chatStep==4){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(1) + "\n說過我們是朋友了～～其實這是幫你帶來的！ 我可沒有虧待你！";
				}
			}else if(chatStep==5){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n握槽！！ 你哪有這麼好心！！ 這樣可是犯罪的行為！！ (雖然有點想要...)";
				}
			}else if(chatStep==6){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(1) + "\n什麼！ 我會被抓嗎？！ 我可不能在這裡被抓！！ 褲褲就交給你了！ 我要先走一步！！";
				}
			}else if(chatStep==7){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guest.SetActive(false);
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n(獲得了偷來的女性內褲)";
				}
			}else if(chatStep==8){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playEndSe = true;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\nOh～～歐買尬！！ 我獲得了！！！ 說不定我是天才也不一定！！";
				}
			}else{
				if(GameManager.chatLine == windowID){
					GameManager.chatLine++; //增加其他可能
				}
				playerDM = true; //別動
				chatStep = -1;
				showChat = BackToHall();
			}
		}else if(windowID == 18){ //方半2
			if(chatStep==0){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = "(聊天對象搜尋中．．．)";
				}
			}else if(chatStep==1){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guest.SetActive(true);
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(6) + "\n窩(wo)~~科(ker)~~科(ker)~~";
				}
			}else if(chatStep==2){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n好強大的陰謀氣息！！！ 冷得我直發抖！！ 寒毛全部豎起來！！";
				}
			}else if(chatStep==3){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(6) + "\n嘻嘻嘻～～～ 你說得不錯！ 果然還是要這種反應才對！！";
				}
			}else if(chatStep==4){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(6) + "\nChaos是不會停止的...... 我那可是能讓一切毀滅的大發明！ 當然我不會被毀滅～～ 哈哈哈～～～";
				}
			}else if(chatStep==5){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n(怎麼會這樣！！ 我居然又聽不懂了！！！)";
				}
			}else if(chatStep==6){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n雖然不是很懂，但是好像很厲害的樣子！";
				}
			}else if(chatStep==7){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(6) + "\n哼哼～～ 很快的！ 誰都還不知道的真相！ 到時候你們都會變成牙籤！～ 哈哈哈哈哈！！！";
				}
			}else if(chatStep==8){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guest.SetActive(false);
					playEndSe = true;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n天啊！！！ 他到底要做些甚麼！！！\n......但好像什麼都不會發生的感覺......";
				}
			}else{
				if(GameManager.chatLine == windowID){
					GameManager.chatLine++; //增加其他可能
				}
				playerDM = true; //別動
				chatStep = -1;
				showChat = BackToHall();
			}
		}else if(windowID == 19){ //方塊3
			if(chatStep==0){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = "(聊天對象搜尋中．．．)";
				}
			}else if(chatStep==1){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guest.SetActive(true);
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(3) + "\n啊啊！！ 你！！";
				}
			}else if(chatStep==2){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(3) + "\n我這裡有批便宜的鮮奶，你幫我買一點吧？";
				}
			}else if(chatStep==3){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n離富贏！！ 我不要喝這家的！！ 這家聽說加了一整頭牛下去！！";
				}
			}else if(chatStep==4){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(3) + "\n錯的是他們！！ 我們是受害者！！ 都是他們亂加才害我們賣不出去！！ 拜託行行好買個一打回去吧！";
				}
			}else if(chatStep==5){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n這麼說好像有點道理......可是我也有參與抵制離富贏的活動！ 不能購買！";
				}
			}else if(chatStep==6){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(3) + "\n不然你買兩公升我送你一把AK47！！";
				}
			}else if(chatStep==7){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n嗯......就算這麼說我也......";
				}
			}else if(chatStep==8){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(3) + "\n買兩公升送一公升！！！";
				}
			}else if(chatStep==9){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playEndSe = true;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n真便宜！！！ 我要買！！！";
				}
			}else{
				if(GameManager.chatLine == windowID){
					GameManager.chatLine++; //增加其他可能
				}
				guest.SetActive(false);
				playerDM = true; //別動
				chatStep = -1;
				showChat = BackToHall();
			}
		}else if(windowID == 20){ //蝴蝶3
			if(chatStep==0){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = "(聊天對象搜尋中．．．)";
				}
			}else if(chatStep==1){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guest.SetActive(true);
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(2) + "\n................................(剛睡醒)";
				}
			}else if(chatStep==2){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(2) + "\n啊啊～～ 家裡啤酒喝完了......拜託你幫我去買一些......";
				}
			}else if(chatStep==3){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n哇啊啊！！ 一身酒臭味！！ 振作一點啊！！";
				}
			}else if(chatStep==4){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(2) + "\n哦哦哦！！！ 離富贏的發票！！ 你怎麼這樣......明明就說要一起抵制的...... (打嗝)";
				}
			}else if(chatStep==5){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n啊啊啊！！！ 對喔！ 剛剛看到買二送一就不小心買了！ 我要去問問能不能退貨！";
				}
			}else if(chatStep==6){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(2) + "\n哦哦！！！ 那跟我退吧！！！ 我要買下你全部的離富贏鮮乳......當然是以買二送一的方式......(笑)";
				}
			}else if(chatStep==7){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\nYA!! 真是太感激了，感動到我都說不出話來了！";
				}
			}else if(chatStep==8){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playEndSe = true;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(2) + "\n喀喀喀.........我們一直都很好的............ (睡著了)";
				}
			}else{
				if(GameManager.chatLine == windowID){
					GameManager.chatLine++; //增加其他可能
				}
				guest.SetActive(false);
				playerDM = true; //別動
				chatStep = -1;
				showChat = BackToHall();
			}
		}else if(windowID == 21){ //也也3
			if(chatStep==0){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = "(聊天對象搜尋中．．．)";
				}
			}else if(chatStep==1){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guest.SetActive(true);
					chatGirl.GetComponent<ChatFace>().Girl_sLaugh();
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.GetNpcName(2) + "\n啊哈！！！ 拉～勇～";
				}
			}else if(chatStep==2){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.GetNpcName(2) + "\n我上個月的發票中獎了耶！！ 而且是中1000元！！ 你看～～！";
				}
			}else if(chatStep==3){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n哦哦！！ 妳手氣這麼好！！ 也幫我對一下吧！！";
				}
			}else if(chatStep==4){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					chatGirl.GetComponent<ChatFace>().Girl_why();
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.GetNpcName(2) + "\n嘩～～ 這是.........";
				}
			}else if(chatStep==5){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n什麼什麼？ 我看看.........";
				}
			}else if(chatStep==6){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n南方小島雙人行？！ 為什麼發票可以兌出這種東西？！";
				}
			}else if(chatStep==7){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					chatGirl.GetComponent<ChatFace>().Girl_sLaugh();
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.GetNpcName(2) + "\n哇喔！！ 拉勇太厲害啦！！ 我們兩個去吧！！";
				}
			}else if(chatStep==8){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playEndSe = true;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n好啊！！！！！ 我家裡還有一堆發票！ 明天也麻煩妳了！ 啊哈哈哈哈！～～～";
				}
			}else{
				if(GameManager.chatLine == windowID){
					GameManager.chatLine++; //增加其他可能
				}
				guest.SetActive(false);
				playerDM = true; //別動
				chatStep = -1;
				showChat = BackToHall();
			}
		}else if(windowID == 22){ //拉勇3
			if(chatStep==0){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = "(似乎沒有可聊天的對象．．．)";
				}
			}else if(chatStep==1){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n哦......學測放榜了啊......";
				}
			}else if(chatStep==2){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n想當年我在學校，一直都是背書拿高分，出來全部都忘光了......";
				}
			}else if(chatStep==3){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playEndSe = true;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n現在回想起來，那些分數根本沒甚麼！要是那些時間拿去學一些生活技能就好了！";
				}
			}else{
				if(GameManager.chatLine == windowID){
					GameManager.chatLine++; //增加其他可能
				}
				playerDM = true; //別動
				chatStep = -1;
				showChat = BackToHall();
			}
		}else if(windowID == 23){ //膠囊1
			if(chatStep==0){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = "(聊天對象搜尋中．．．)";
				}
			}else if(chatStep==1){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guest.SetActive(true);
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(9) + "\n呼～呼～呼～ 好累啊！";
				}
			}else if(chatStep==2){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(9) + "\n喂！那邊那個你！ 來幫我一下！ 會給你薪水！";
				}
			}else if(chatStep==3){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n唔喔喔喔！！！！ 這是！！！";
				}
			}else if(chatStep==4){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(9) + "\n這是勞資牌的電風扇喲！ 我們現在在量產這個！ 如何？很厲害吧？！";
				}
			}else if(chatStep==5){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n哦哦！！！！！ (幫忙轉動)\n哦哦哦哦！！！！！ (幫忙轉動)";
				}
			}else if(chatStep==6){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(9) + "\n哇哈哈哈～～ 我們的電風扇是世界第一！！！！";
				}
			}else if(chatStep==7){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guest.SetActive(false);
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n呼～呼～呼～ 好累啊！！！";
				}
			}else if(chatStep==8){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playEndSe = true;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n啊啊！！！！ 我沒有領到薪水！！";
				}
			}else{
				if(GameManager.chatLine == windowID){
					GameManager.chatLine++; //增加其他可能
				}
				playerDM = true; //別動
				chatStep = -1;
				showChat = BackToHall();
			}
		}else if(windowID == 24){ //也也4
			if(chatStep==0){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = "(聊天對象搜尋中．．．)";
				}
			}else if(chatStep==1){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					chatGirl.GetComponent<ChatFace>().Girl_sLaugh();
					guest.SetActive(true);
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.GetNpcName(2) + "\n啊！！ 拉勇！～～\n你看我這裡收到好多面紙喔！！！";
				}
			}else if(chatStep==2){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n哇！！！ 好多候選人的文宣！！ 我這裡才收到一兩包！！";
				}
			}else if(chatStep==3){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.GetNpcName(2) + "\n那我分你一點吧！！！ 他們看到我就一直送過來了～～害人家都不能好好走路了呢！ 哈哈哈～～～";
				}
			}else if(chatStep==4){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n(咦？ 這包裝摸起來怪怪的！)";
				}
			}else if(chatStep==5){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n(唔唔唔喔喔！！ 裡面裝了好像情書的東西！！)\n這.....這裡面好像有什麼...";
				}
			}else if(chatStep==6){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					chatGirl.GetComponent<ChatFace>().Girl_laugh();
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.GetNpcName(2) + "\n那好像也是文宣吧！ 我也去分一點給其他人囉～～";
				}
			}else if(chatStep==7){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guest.SetActive(false);
					playEndSe = true;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n咦咦？？是這樣嗎？？\n不過裡面的用詞感覺不太像啊......";
				}
			}else{
				if(GameManager.chatLine == windowID){
					GameManager.chatLine++; //增加其他可能
				}
				playerDM = true; //別動
				chatStep = -1;
				showChat = BackToHall();
			}
		}else if(windowID == 25){ //飛馬2
			if(chatStep==0){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = "(聊天對象搜尋中．．．)";
				}
			}else if(chatStep==1){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guest.SetActive(true);
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n！！！！！！！！";
				}
			}else if(chatStep==2){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(7) + "\n咦？ 你身上股好熟悉的味道！！";
				}
			}else if(chatStep==3){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n不......你肯定是認錯人了... (得趕快走...)";
				}
			}else if(chatStep==4){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(7) + "\n你身上那件女性內褲是我的！！！";
				}
			}else if(chatStep==5){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n蛤啊？ 你是說......這件偷來的女性內褲？ (老鷹偷來的)";
				}
			}else if(chatStep==6){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(7) + "\n對！沒錯！ 我太感動了！！ 沒想到你會對我念念不忘！！ 你這壞孩子，我要好好處罰你！";
				}
			}else if(chatStep==7){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n囧  拜託不要，放過我吧大大！！";
				}
			}else if(chatStep==8){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					playerShak = true;
					guestDM = false;
					guestShak = true;
					//對話
					chatString = "(經過了一段快樂的時間......)";
				}
			}else if(chatStep==9){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playEndSe = true;
					playerDM = false;
					playerShak = true;
					guestDM = false;
					guestShak = true;
					//對話
					chatString = "(又再經過了一段快樂的時間......)";
				}
			}else{
				if(GameManager.chatLine == windowID){
					GameManager.chatLine++; //增加其他可能
				}
				guest.SetActive(false);
				playerDM = true; //別動
				chatStep = -1;
				showChat = BackToHall();
			}
		}else if(windowID == 26){ //天球2
			if(chatStep==0){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = "(聊天對象搜尋中．．．)";
				}
			}else if(chatStep==1){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guest.SetActive(true);
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n(拉勇將狀態改為：7-111點數絕讚蒐集中！ 拜託施捨)";
				}
			}else if(chatStep==2){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(8) + "\n那個......我這邊有一些7-111點數......不嫌棄的話......";
				}
			}else if(chatStep==3){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n哦哦！！ 剛改狀態馬上就有了！！ 上次也從你那得到不少幫助呢！！";
				}
			}else if(chatStep==4){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(8) + "\n這......這也沒甚麼啦！ 別人都不懂得欣賞我！";
				}
			}else if(chatStep==5){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n唔唔喔喔喔！！！ 裡面居然還有三神卡！！ 還有金家便利商店的三幻卡！！ 你真的是厲害到一個不行！！";
				}
			}else if(chatStep==6){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(8) + "\n耶？ 三神卡跟三幻卡也在裡面啊......我忘了拿出來了......";
				}
			}else if(chatStep==7){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n那這幾張還給你吧！ 我這裡點數也夠了！";
				}
			}else if(chatStep==8){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(8) + "\n不不不......那幾張就送給你好了，我得先走了！ 這個牧田牌100M電動圓鋸也送給你好了！";
				}
			}else if(chatStep==9){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guest.SetActive(false);
					playEndSe = true;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n我靠！！！！！ 好危險的東西！！！ 這個要怎麼用呢......？";
				}
			}else{
				if(GameManager.chatLine == windowID){
					GameManager.chatLine++; //增加其他可能
				}
				playerDM = true; //別動
				chatStep = -1;
				showChat = BackToHall();
			}
		}else if(windowID == 27){ //幽靈3
			if(chatStep==0){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = "(聊天對象搜尋中．．．)";
				}
			}else if(chatStep==1){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guest.SetActive(true);
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(4) + "\n你~~出~~賣~~我~~";
				}
			}else if(chatStep==2){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n唔唔喔喔喔！！！！！ 好幽靈！！！";
				}
			}else if(chatStep==3){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(4) + "\n你~~這~~傢~~伙~~納~~命~~來~~";
				}
			}else if(chatStep==4){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n等等等等！！ 發生什麼事了？ 我做人坦蕩蕩！";
				}
			}else if(chatStep==5){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(4) + "\n你~~跟~~膠~~囊~~說~~我~~去~~翻~~垃~~圾~~\n所以他說我很臭！ 不想理我了！";
				}
			}else if(chatStep==6){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n咦？ 你剛剛居然好好說話了！！";
				}
			}else if(chatStep==7){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(4) + "\n廢~~話~~少~~說~~納~~命~~來~~";
				}
			}else if(chatStep==8){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n啊啊啊啊！！！！！ 等等！！ 不是我說的！！ 你去問問膠囊吧！ 你身上還好臭啊！";
				}
			}else if(chatStep==9){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playEndSe = true;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(4) + "\n嗚~~嗚~~嗚~~";
				}
			}else{
				if(GameManager.chatLine == windowID){
					GameManager.chatLine++; //增加其他可能
				}
				guest.SetActive(false);
				playerDM = true; //別動
				chatStep = -1;
				showChat = BackToHall();
			}
		}else if(windowID == 28){ //燭台3
			if(chatStep==0){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = "(聊天對象搜尋中．．．)";
				}
			}else if(chatStep==1){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guest.SetActive(true);
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(5) + "\n缺人組隊啦！！ 打JJ破壞神的地下城！！ 組不？";
				}
			}else if(chatStep==2){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n(我靠!! 你們居然也玩JJ破壞神!)";
				}
			}else if(chatStep==3){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n組！ 我要組！ "+(GameManager.playingLevel*36)+"等的訓獸師！";
				}
			}else if(chatStep==4){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(5) + "\n考~~ 那不收喔！ 我們只缺弓格法(弓箭手、格鬥士、法師)，其他職業都太弱了不收！ 我們是效率團！";
				}
			}else if(chatStep==5){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n等等啊！！ 可是我也有學範圍技能！ 我也要升級！";
				}
			}else if(chatStep==6){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(5) + "\n啊！ 有人密我了！ 已滿不收喔！";
				}
			}else if(chatStep==7){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guest.SetActive(false);
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\nOh～～Sh@t～～ 難道說我要重練？ 可是我只想玩訓獸師！ 都怪官方都不把職業平衡做好！";
				}
			}else{
				if(GameManager.chatLine == windowID){
					GameManager.chatLine++; //增加其他可能
				}
				playerDM = true; //別動
				chatStep = -1;
				showChat = BackToHall();
			}
		}else if(windowID == 29){ //方半3
			if(chatStep==0){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = "(聊天對象搜尋中．．．)";
				}
			}else if(chatStep==1){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guest.SetActive(true);
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(6) + "\n窩(wo)~~科(ker)~~科(ker)~~科(ker)~~";
				}
			}else if(chatStep==2){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n！！！！！！！\n好強大的陰謀氣息！！ 你又想做什麼了！！";
				}
			}else if(chatStep==3){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(6) + "\n你們地球上的香蕉準備消失吧！！！ 哈哈哈哈哈！！！";
				}
			}else if(chatStep==4){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(6) + "\n我們最新的研究技術有辦法把水果變成肉！！ 我們要從香蕉先下手！！ 到時候大家都會吃不到香蕉了～～ 哈哈哈哈哈！！！";
				}
			}else if(chatStep==5){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n天啊！！！！！ 我們的祖先要滅絕了！！！";
				}
			}else if(chatStep==6){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(6) + "\n不只這樣！！ 我們還要對小黃瓜下手！！ 這樣以後就沒有女大生買得到小黃瓜了～～　哈哈哈哈哈！！！！";
				}
			}else if(chatStep==7){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n天啊！！！ 多麼殘忍的陰謀！！！ (但好像還不錯......)";
				}
			}else if(chatStep==8){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(6) + "\n哼哼哼～～ 你就等著看吧！ 白銀的明天在等著我們！ 喀喀喀喀喀.........";
				}
			}else if(chatStep==9){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guest.SetActive(false);
					playEndSe = true;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n這......要報警嗎？";
				}
			}else{
				if(GameManager.chatLine == windowID){
					GameManager.chatLine++; //增加其他可能
				}
				playerDM = true; //別動
				chatStep = -1;
				showChat = BackToHall();
			}
		}else if(windowID == 30){ //老鷹4
			if(chatStep==0){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = "(聊天對象搜尋中．．．)";
				}
			}else if(chatStep==1){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guest.SetActive(true);
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(1) + "\nSh@t！ 老子被詐騙了！ 我要夾那個藍色盒子！ 怎麼也夾不起來！";
				}
			}else if(chatStep==2){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n哦哦哦哦！！！ 夾娃娃機！！！ 讓我來試試！！！";
				}
			}else if(chatStep==3){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n(拉勇使用了夾娃娃機)";
				}
			}else if(chatStep==4){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guest.SetActive(false);
					guest = s2Ghost;
					guest.SetActive(true);
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(4) + "\n嗚~~嗚~~嗚~~(幽靈被夾了起來)";
				}
			}else if(chatStep==5){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guest.SetActive(false);
					guest = s1Eagle;
					guest.SetActive(true);
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n我靠！！ 幽靈怎麼跑到裡面去！！";
				}
			}else if(chatStep==6){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(1) + "\n太棒啦！！！ 他手上拿著我要的藍色盒子！！！ 快把他夾起來！！！";
				}
			}else if(chatStep==7){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					//對話
					chatString = "(幽靈帶著藍色盒子穿透了玻璃，消失在遙遠的彼方......)";
				}
			}else if(chatStep==8){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(1) + "\n哇賽！！！ 這招還真方便！！ 幽靈真好吶！！";
				}
			}else if(chatStep==9){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playEndSe = true;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n咦...？ 這樣真的沒問題嗎...？";
				}
			}else{
				if(GameManager.chatLine == windowID){
					GameManager.chatLine++; //增加其他可能
				}
				guest.SetActive(false);
				playerDM = true; //別動
				chatStep = -1;
				showChat = BackToHall();
			}
		}else if(windowID == 31){ //蝴蝶4
			if(chatStep==0){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = "(聊天對象搜尋中．．．)";
				}
			}else if(chatStep==1){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guest.SetActive(true);
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n！！！！！！！";
				}
			}else if(chatStep==2){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(2) + "\n.............................(剛睡醒)";
				}
			}else if(chatStep==3){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(2) + "\n啊......我們這邊沒水了......我想到你們那邊去住個幾天......(黏上拉勇)";
				}
			}else if(chatStep==4){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n哦～～ 這大概沒什麼問題！ 我們這裡空房很多！\n(牧田牌100M電動圓鋸因為被擠壓而掉了下來，開關也不知道為什麼地被打開了...)";
				}
			}else if(chatStep==5){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(2) + "\n嘩～～！ 這......這是！！ 地板被......！！";
				}
			}else if(chatStep==6){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					//對話
					chatString = "(地板被切了開來，噴出了大量的水......)";
				}
			}else if(chatStep==7){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(2) + "\n吼吼吼！！！ 有水能用啦～～～ 呀啊～～～～";
				}
			}else if(chatStep==8){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guest.SetActive(false);
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n啊啊......那真是太好了...... 我得把掉下去的圓鋸撿起來才行！\n 咦？ 好像切到什麼東西停止了......";
				}
			}else if(chatStep==9){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playEndSe = true;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = "(拉勇撿回了擋下牧田牌100M電動圓鋸的Nokia3310手機)";
				}
			}else{
				if(GameManager.chatLine == windowID){
					GameManager.chatLine++; //增加其他可能
				}
				playerDM = true; //別動
				chatStep = -1;
				showChat = BackToHall();
			}
		}else if(windowID == 32){ //方塊4
			if(chatStep==0){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = "(聊天對象搜尋中．．．)";
				}
			}else if(chatStep==1){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guest.SetActive(true);
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(3) + "\n唔唔唔唔唔～～～～～ 肚子好痛．．．．．． 難道說...是我剛剛吃的晚餐有問題...";
				}
			}else if(chatStep==2){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(3) + "\n難道說是離富贏鮮乳的關係！！！ 我把賣不掉的全都喝下去了！！！";
				}
			}else if(chatStep==3){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n那慘了啊！！ 快去看醫生吧！！";
				}
			}else if(chatStep==4){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(3) + "\n唔喔喔喔！！ 好像是因為接觸了真相的關係，身體開始不聽使喚了！！";
				}
			}else if(chatStep==5){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(3) + "\n嗚嗚嗚啊啊啊啊啊！！！！！！";
				}
			}else if(chatStep==6){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guest.SetActive(false);
					//對話
					chatString = "("+GameManager.BossName(3)+"化作一陣煙霧，消失在了遙遠的洗手間)";
				}
			}else if(chatStep==7){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n嘩！！！！！ 這也太恐怖了！！ 還好我沒喝！！ 要趕快上網張貼一下勸世文才行！！";
				}
			}else{
				if(GameManager.chatLine == windowID){
					GameManager.chatLine++; //增加其他可能
				}
				playerDM = true; //別動
				chatStep = -1;
				showChat = BackToHall();
			}
		}else if(windowID == 33){ //拉勇4
			if(chatStep==0){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = "(似乎沒有可聊天的對象．．．)";
				}
			}else if(chatStep==1){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n我的薪資！ 萬年不漲！";
				}
			}else if(chatStep==2){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n嗯......平時事情太多了......感覺一點都不想和長官吵薪資......";
				}
			}else if(chatStep==3){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n唉唉～～ 現在收到薪資條都想直接丟垃圾桶了......裡面的東西看到都背起來了！";
				}
			}else if(chatStep==4){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n哦？ 這些是也也之前給我的文宣！ 這些候選人...有辦法將我的薪資救起來嗎...？";
				}
			}else if(chatStep==5){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playEndSe = true;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n唉唉～～ 我看應該沒這可能！ 反正日子都還過得去，就算了吧！";
				}
			}else{
				if(GameManager.chatLine == windowID){
					GameManager.chatLine++; //增加其他可能
				}
				playerDM = true; //別動
				chatStep = -1;
				showChat = BackToHall();
			}
		}else if(windowID == 34){ //膠囊2
			if(chatStep==0){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = "(聊天對象搜尋中．．．)";
				}
			}else if(chatStep==1){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guest.SetActive(true);
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(9) + "\n終於把堆積的遊戲全破台了！！！ 火@、瑪@那、瑪@歐讓我卡關好久！！！";
				}
			}else if(chatStep==2){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n哦哦！！ 你居然也玩那些！！ 要不要來連機啊？";
				}
			}else if(chatStep==3){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(9) + "\n哼哼～～ 就憑你也想跟我連線？ 還早了十年呢！";
				}
			}else if(chatStep==4){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n吼哦！！！ 口氣還真不小！ 我可是被稱為\"電動之神\"的人！(小學) 你難道沒有興趣跟我試試嗎？";
				}
			}else if(chatStep==5){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(9) + "\n摁嗯？ 真不巧我也是\"電動之神\"啊！ 真是自不量力的傢伙！ 我們就來試試吧！";
				}
			}else if(chatStep==6){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = false;
					playerShak = true;
					guestShak = true;
					//對話
					chatString = "(經過了一番激戰......)";
				}
			}else if(chatStep==7){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n怎麼可能！！！ 我居然輸了！！！";
				}
			}else if(chatStep==8){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playEndSe = true;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.BossName(9) + "\n啊哈哈哈哈！！！ 回去練個十年再來吧！！！";
				}
			}else{
				if(GameManager.chatLine == windowID){
					GameManager.chatLine++; //增加其他可能
				}
				guest.SetActive(false);
				playerDM = true; //別動
				chatStep = -1;
				showChat = BackToHall();
			}
		}else if(windowID == 35){ //也也5
			if(chatStep==0){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = "(聊天對象搜尋中．．．)";
				}
			}else if(chatStep==1){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					chatGirl.GetComponent<ChatFace>().Girl_sLaugh();
					guest.SetActive(true);
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.GetNpcName(2) + "\n诶～～～ 拉勇！！！ 你看我撿到一顆好奇怪的石頭！！";
				}
			}else if(chatStep==2){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n咦？ 真的吔！！ 上面還寫著龜字......";
				}
			}else if(chatStep==3){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.GetNpcName(2) + "\n欸～～ 這個周末要不要一起去哪裡玩玩？～～ 說不定又能再撿到奇怪的東西！！～";
				}
			}else if(chatStep==4){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n這周末啊．．．．．． 好啊！！ 那我們要去哪裡呢？";
				}
			}else if(chatStep==5){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = false;
					playerDM = true;
					guestShak = true;
					//對話
					chatString = GameManager.GetNpcName(2) + "\n哇～～～ 太棒了！～～ 那我們就中午十二點在車站見吧！～～";
				}
			}else if(chatStep==6){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guest.SetActive(false);
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n诶诶？ 那我們到底要去......\n算了，能看到也也就好了，真羨慕有那樣的個性啊～～";
				}
			}else if(chatStep==7){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n(長官簡訊：紅A同仁因身體不適這幾天都請假，這周末麻煩幫忙補完他的進度，謝謝！ ~Best Regards~)";
				}
			}else if(chatStep==8){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playEndSe = true;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n我去！！！ 我要陪也也去玩！！！ 鬼才要陪你們加班！！！";
				}
			}else{
				if(GameManager.chatLine == windowID){
					GameManager.chatLine++; //增加其他可能
				}
				playerDM = true; //別動
				chatStep = -1;
				showChat = BackToHall();
			}
		}else if(windowID == 36){ //拉勇5
			if(chatStep==0){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = "(似乎沒有可聊天的對象．．．)";
				}
			}else if(chatStep==1){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n啊啊．．．．．． 我的遊戲片越來越多了．．．．．． 早知道當初就不該買實體的，現在這麼多可能都要丟垃圾桶了！";
				}
			}else if(chatStep==2){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n不過在首都好像有店家可以拿舊片折現！ 好像能以目前價格的3~5折來回收，有會員再加上主打遊戲的話更是能以9折來回收！";
				}
			}else if(chatStep==3){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n嗯......不過看起來很划算......但這樣好像是讓遊戲重複販賣，說不定會間接讓作品的銷量減少......";
				}
			}else if(chatStep==4){
				//抖動
				if(onceFlag != chatStep){
					onceFlag = chatStep;
					playEndSe = true;
					guestDM = true;
					playerDM = false;
					playerShak = true;
					//對話
					chatString = GameManager.GetNpcName(1)+" <主角>\n我看以後還是買預付卡來買下載版的遊戲好了！ 這樣也環保的多！";
				}
			}else{
				if(GameManager.chatLine == windowID){
					GameManager.chatLine++; //增加其他可能
				}
				playerDM = true; //別動
				chatStep = -1;
				showChat = BackToHall();
			}
		}else{
			chatStep = -1;
			showChat = BackToHall();
		}
		//右下三角
		GUI.skin.label.alignment = TextAnchor.LowerRight;
		GUI.skin.label.fontSize = butFoSi+butFoSi;
		GUI.Label(new Rect(0,triJump,chatRect.width,chatRect.height),"▽");
	}
	#endregion
	//*************************************************
	//other
	bool BackToHall(){
		showSelection = true;
		player.SetActive (true);
		GameManager.Save ();
		return false;
	}
	void ClickSound(){
		AudioSource.PlayClipAtPoint (clickSE, Vector3.one);
	}
	void LoginSound(){
		AudioSource.PlayClipAtPoint (loginSE, Vector3.zero);
	}
	void LogoutSound(){
		AudioSource.PlayClipAtPoint (logoutSE, Vector3.zero);
	}
	void MoneySE(){
		AudioSource.PlayClipAtPoint(shbuySE,Vector3.zero);
	}
	void ErrSE(){
		AudioSource.PlayClipAtPoint(errSE,Vector3.zero);
	}
	void CloseBg(int num){
		if(num==0)
			teachBg.SetActive(false);
		else if(num==1)
			s1Bg.SetActive(false);
		else if(num==2)
			s2Bg.SetActive(false);
		else if(num==3)
			s3Bg.SetActive(false);
		else if(num==4)
			s4Bg.SetActive(false);
		else if(num==5)
			s4Bg.SetActive(false);
	}
	void OpenBg(int num){
		if(num==0)
			teachBg.SetActive(true);
		else if(num==1)
			s1Bg.SetActive(true);
		else if(num==2)
			s2Bg.SetActive(true);
		else if(num==3)
			s3Bg.SetActive(true);
		else if(num==4)
			s4Bg.SetActive(true);
		else if(num==5)
			s4Bg.SetActive(true);
	}
	void ChangeMu(int num){
		if(num==0){
			audioObj.clip = teachMu;
			audioObj.volume = 0.4f;
			audioObj.Play();
		}else if(num==1){
			audioObj.clip = s1Mu;
			audioObj.volume = 0.4f;
			audioObj.Play();
		}else if(num==2){
			audioObj.clip = s2Mu;
			audioObj.volume = 0.4f;
			audioObj.Play();
		}else if(num==3){
			audioObj.clip = s3Mu;
			audioObj.volume = 0.4f;
			audioObj.Play();
		}else if(num==4){
			audioObj.clip = s4Mu;
			audioObj.volume = 0.4f;
			audioObj.Play();
		}else if(num==5){
			audioObj.clip = sYMu;
			audioObj.volume = 0.4f;
			audioObj.Play();
		}else{
			if(audioObj.clip != hallMu){
				audioObj.clip = hallMu;
				audioObj.Play();
				audioObj.volume = 0.4f;
			}
		}
	}
}
