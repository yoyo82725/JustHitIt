using UnityEngine;
using System.Collections;

public class PlayingManager : MonoBehaviour {
	int tmpSW = Screen.width;
	float gcTimer = 5f;
	float useTime;
	bool showGUI = true;
	int labFoSi = Mathf.RoundToInt(Screen.width*0.02682f); //18
	int labFoSi2 = Mathf.RoundToInt(Screen.width*0.03582f); //24
	int resFoSi = Mathf.RoundToInt(Screen.width*0.02985f); //20
	float screenW05 = Screen.width*0.5f;
	float screenH05 = Screen.height*0.5f;
	float screenH025 = Screen.height*0.25f;
	//音樂背景
	public AudioClip clickSE,buffSE,shbuySE,gameOverSE,clearSE,lvUpSE,clearMu,teachMu,teachLoop,s1Start,s1Loop,s1BStart,s1BLoop,s2Start,s2Loop,s2BStart,s2BLoop,s3Start,s3Loop,s3BStart,s3BLoop,s4BStart,s4BLoop,s4B150;
	public GameObject teachBg,s1Bg,s2Bg,s3Bg,s4Bg,touchTeach1;
	public GameObject s1Text,s2Text,s3Text;
	public GameObject warFace,teachOut,s1Out,s2Out,s3Out,s1Eagle,s1But,s1Square,s2Ghost,s2Candle,s2SquareF,s3Pegasus,s3SkyBall,s4Capsule;
	public AudioSource audioObj;
	float audioPlayTimer;
	//敵人血條
	public static int addHP, minusHP;
	public GUITexture hpColor;
	public static int stageHp;
	public float W=-Screen.width;
	int hpMaxLine,oneLineHP,staLv,showdEHp;
	float X=Screen.width*0.02923f; //19.5849
	float nowW,nowStaHP;
	float rate,showdEHptmp;
	public Color bgColor=new Color(0.717f,0.721f,0.396f,0.203f); //183,184,101,52
	Color iniColor,addColor=new Color(0.0f,0.6f,0.0f,0.5f); //0,0,255 - 15,122,15 - 255,0,0
	public Color[] stageColor;
	public Color[] stageBgColor;
	Rect showHpRect = new Rect(0f,Screen.height*0.05f,Screen.width*0.95f,Screen.height*0.1f);
	public GameObject showChangeHp;
	public GameObject[] nums;
	public GameObject[] pNums;
	public static GameObject showChangeHp2;
	public static GameObject[] nums2;
	public static GameObject[] pNums2;
	public static bool endIn;
	int lifeCount;
	//自己血條
	public GUITexture mineHpColor;
	public static int mineHp,mineHpL;
	int showdMHp;
	Rect mineHpLRect = new Rect(Screen.width*0.04f,Screen.height*0.85f,Screen.width*0.5f,Screen.height*0.2f);
	float mineHpW = -Screen.width, nowMineHpW = -Screen.width;
	float mineHpRate,mineHPCoRa,showdMHptmp;
	float mineHpCo = 0.878f; //224
	float tr=0.878f,tg=0.878f;
	//暫停
	public GameObject pauseFace,loadingFace;
	Rect pauseRect = new Rect(Screen.width*0.01f,Screen.height*0.13f,Screen.width*0.15f,Screen.height*0.15f);
	Rect pauUpRect = new Rect (Screen.width*0.3f,Screen.height*0.5f,Screen.width*0.4f,Screen.height*0.15f);
	Rect pauDownRect = new Rect (Screen.width*0.28f,Screen.height*0.7f,Screen.width*0.44f,Screen.height*0.2f);
	//EXP條
	public GUITexture expBar;
	Rect expHowRect = new Rect(Screen.width*0.97f,Screen.height*0.14f,Screen.width*0.02f,Screen.height*0.52f);
	Rect expLvRect = new Rect(Screen.width*0.9f,Screen.height*0.65f,Screen.width*0.1f,Screen.height*0.15f);
	float expH,expRate,showdXptmp,expCoRa,nowExpH;
	float expY = Screen.height * 0.5f * 0.02923f;
	int expNowLine,showdXp;
	public static int getExp,bossGetExp;
	//右上成就
	Rect getResRect = new Rect(Screen.width*0.75f,0f,Screen.width*0.25f,Screen.height*0.25f);
	Rect getResLabRec = new Rect(0,0,Screen.width*0.25f,Screen.height*0.25f);
	string getResText;
	bool getRes;
	float showResTimer;
	//左下錢
	Rect moneyRect = new Rect(Screen.width*0.025f,Screen.height*0.935f,Screen.width*0.8f,Screen.height*0.1f);
	public static int getMoney,bossGetMoney;
	int showdMoney;
	float showdMoneytmp;
	int tmpMoney = GameManager.money; //減少21E檢查
	//GAME OVER
	public GameObject gameoverFace;
	bool gameover;
	float gameoverTimer=4f;
	//Clear
	public GameObject clearFace,clearFireW;
	float endTimer=6f;
	Rect backHallRect = new Rect(Screen.width*0.01f,Screen.height*0.15f,Screen.width*0.2f,Screen.height*0.15f);
	Rect restartRect = new Rect(Screen.width*0.79f,Screen.height*0.15f,Screen.width*0.2f,Screen.height*0.15f);
	Rect timeRect = new Rect(0f,Screen.height*0.5f,Screen.width,Screen.height*0.5f);
	int timeH,timeM,timeS,starCount,showdHitPa;
	public static int lostCount,outCount,brkCnt;
	float hitPa,showdHitPatmp;
	bool showEnd,showHiPaGo;
	//BOSS
	public static bool isBossed=false,bossBoomed=false;
	public static int bossCo=0,phase;
	float warningTimer = 3.9f;
	public static bool warningIn;
	bool rewardIn;
	//主角對話框
	public Transform player;
	Rect mesRect = new Rect(0f,0f,Screen.width*0.2f,Screen.height*0.23f);
	Rect mesLabRect = new Rect(Screen.width*0.005f,Screen.height*0.05f,Screen.width*0.19f,Screen.height*0.2f);
	float mesPoRate = Screen.width*0.04545f;
	bool showMes;
	string mesText;
	float mesTimer;
	//LevelY
	int levelYFlag,lifeCountY;
	GameObject nowBg;
	//sk白球特好
	public static bool sk4On = false;
	public static float sk4Pow = 0;
	//sk侵蝕力量
	public static bool sk11On = false;
	public static int sk11Pow = 0;

	void Start () {
		endIn = false;
		isBossed = false;
		bossBoomed = false;
		warningIn = false;
		lostCount = 0;
		outCount = 0;
		brkCnt = 0;
		bossCo = 0;
		phase = 0;
		StickBigBuff.isShow = false;
		MoveSpeedUpBuff.isShow = false;
		WindBallWind.isWind = false;
		WindBallWind.windFource = 0f;
		LRwind.isWind = false;
		FireBall.LRmove = false;
		FireBall.moveFlag = 0;
		showdMoney = GameManager.money;
		showdXp = GameManager.playerExp;
		//技能
		if (GameManager.wearSk1 == 4 || GameManager.wearSk2 == 4 || GameManager.wearSk3 == 4) {
			//sk白球特好
			sk4On = true;
			sk4Pow = (float)(addHP + GameManager.skLv[3]*12);
		}else{
			sk4On = false;
			sk4Pow = 0;
		}
		if (GameManager.wearSk1 == 11 || GameManager.wearSk2 == 11 || GameManager.wearSk3 == 11) {
			//sk侵蝕力量
			sk11On = true;
			sk11Pow = Mathf.RoundToInt((float)GameManager.GetPlayerAtk() * 0.01f * (float)GameManager.skLv[10]);
			if(sk11Pow < 1)
				sk11Pow = 1;
			else if(sk11Pow > GameManager.GetPlayerAtk())
				sk11Pow = GameManager.GetPlayerAtk();
		}else{
			sk11On = false;
			sk11Pow = 0;
		}
		//讀入背景 讀入音樂
		if (GameManager.playingLevel == 0){
			isBossed = true;
			Instantiate (teachBg, new Vector3 (0f,0f,10f), Quaternion.identity);
			Instantiate (touchTeach1, new Vector3 (0f,0f,5f), Quaternion.identity);
			Instantiate (teachOut, Vector3.zero, Quaternion.identity);
			audioObj.clip = teachMu;
			audioObj.volume = 0.4f;
			audioObj.loop = false;
			audioObj.Play();
			audioPlayTimer = audioObj.clip.length;
			//對話
			mesTimer = 3f;
			mesText = "我要趕快變強才行！";
			showMes = true;
		}else if(GameManager.playingLevel == 1){
			Instantiate (s1Bg, new Vector3 (0f,0f,10f),Quaternion.identity);
			Instantiate (s1Out, Vector3.zero, Quaternion.identity);
			Instantiate (s1Text, new Vector3(0.5f,0.55f,-3f), Quaternion.identity);
			audioObj.clip = s1Start;
			audioObj.volume = 0.4f;
			audioObj.loop = false;
			audioObj.Play();
			audioPlayTimer = audioObj.clip.length;
			//對話
			mesTimer = 5f;
			if(GameManager.openLevel < 2){
				mesText = "嗯...有股不尋常的氣息...";
			}else{
				int ran = Random.Range(1,6);
				if(ran == 1 || ran == 2){
					mesText = "準備萬全！";
				}else if(ran == 3){
					mesText = "啊啊！ 地上有10圓！賺到了~~";
					MoneySE();
					GameManager.money += 10;
				}else{
					mesText = "這飄下來的東西到底是甚麼呢...?";
				}
			}
			showMes = true;
		}else if(GameManager.playingLevel == 2){
			Instantiate (s2Bg, new Vector3 (0f,0f,10f),Quaternion.identity);
			Instantiate (s2Out, Vector3.zero, Quaternion.identity);
			Instantiate (s2Text, new Vector3(0.5f,0.55f,-3f), Quaternion.identity);
			audioObj.clip = s2Start;
			audioObj.volume = 0.4f;
			audioObj.loop = false;
			audioObj.Play();
			audioPlayTimer = audioObj.clip.length;
			//對話
			mesTimer = 5f;
			if(GameManager.openLevel < 3){
				mesText = "好陰森的地方...有種不祥的預感...";
			}else{
				int ran = Random.Range(1,6);
				if(ran == 1 || ran == 2){
					mesText = "剛剛好像有什麼東西漂過去了...";
				}else if(ran == 3){
					mesText = "啊啊！ 地上有10圓！賺到了~~";
					MoneySE();
					GameManager.money += 10;
				}else{
					mesText = "風一直吹好煩啊！";
				}
			}
			showMes = true;
		}else if(GameManager.playingLevel == 3){
			Instantiate (s3Bg, new Vector3 (0f,0f,10f),Quaternion.identity);
			Instantiate (s3Out, Vector3.zero, Quaternion.identity);
			Instantiate (s3Text, new Vector3(0.5f,0.55f,-3f), Quaternion.identity);
			audioObj.clip = s3Start;
			audioObj.volume = 0.4f;
			audioObj.loop = false;
			audioObj.Play();
			audioPlayTimer = audioObj.clip.length;
			//對話
			mesTimer = 5f;
			if(GameManager.openLevel < 4){
				mesText = "雲上的建築物? 這太神奇了...";
			}else{
				int ran = Random.Range(1,6);
				if(ran == 1 || ran == 2){
					mesText = "地板黏答答的！這就是雲嗎?";
				}else if(ran == 3){
					mesText = "啊啊！ 地上有10圓！賺到了~~";
					MoneySE();
					GameManager.money += 10;
				}else{
					mesText = "好像有流星劃過去了...是我眼花了嗎?";
				}
			}
			showMes = true;
		}else if(GameManager.playingLevel == 4){
			Instantiate (s4Bg, new Vector3 (0f,0f,10f),Quaternion.identity);
			//Boss起頭
			Instantiate(warFace,Vector3.zero,Quaternion.identity);
			warningIn = true;
			audioObj.Stop();
			audioObj.clip = null;
			isBossed = true;
			//對話
			mesTimer = 5f;
			if(GameManager.openLevel < 5){
				mesText = "!!??? 有股強大的氣息...";
			}else{
				int ran = Random.Range(1,6);
				if(ran == 1 || ran == 2){
					mesText = "好熱啊！";
				}else if(ran == 3){
					mesText = "啊啊！ 地上有10圓！賺到了~~";
					MoneySE();
					GameManager.money += 10;
				}else{
					mesText = "地板還是黏答答的！";
				}
			}
			showMes = true;
		}else if(GameManager.playingLevel == 5){
			bossCo = Random.Range(1,10);
			//背景
			/*
			if(bossCo < 4)
				nowBg = Instantiate (s1Bg, new Vector3 (0f,0f,10f),Quaternion.identity) as GameObject;
			else if(bossCo < 7)
				nowBg = Instantiate (s2Bg, new Vector3 (0f,0f,10f),Quaternion.identity) as GameObject;
			else if(bossCo < 9)
				nowBg = Instantiate (s3Bg, new Vector3 (0f,0f,10f),Quaternion.identity) as GameObject;
			else
				nowBg = Instantiate (s4Bg, new Vector3 (0f,0f,10f),Quaternion.identity) as GameObject;
			*/
			int tmp = Random.Range(1,5);
			if(tmp == 1)
				nowBg = Instantiate (s1Bg, new Vector3 (0f,0f,10f),Quaternion.identity) as GameObject;
			else if(tmp == 2)
				nowBg = Instantiate (s2Bg, new Vector3 (0f,0f,10f),Quaternion.identity) as GameObject;
			else if(tmp == 3)
				nowBg = Instantiate (s3Bg, new Vector3 (0f,0f,10f),Quaternion.identity) as GameObject;
			else
				nowBg = Instantiate (s4Bg, new Vector3 (0f,0f,10f),Quaternion.identity) as GameObject;
			//Boss起頭
			Instantiate(warFace,Vector3.zero,Quaternion.identity);
			warningIn = true;
			audioObj.Stop();
			audioObj.clip = null;
			isBossed = true;
			//對話
			mesTimer = 5f;
			int ran = Random.Range(1,6);
			if(ran == 1 || ran == 2){
				mesText = "這個地方感覺非常的不得了啊！";
			}else if(ran == 3){
				mesText = "啊啊！ 地上有10圓！賺到了~~";
				MoneySE();
				GameManager.money += 10;
			}else{
				mesText = "全身都熱起來了！";
			}
			showMes = true;
			//提示離開
			getResRect = new Rect(Screen.width*0.6f,0f,Screen.width*0.4f,Screen.height*0.18f);
			getResLabRec = new Rect(0,0,Screen.width*0.4f,Screen.height*0.18f);
			getResText = "可從暫停離開\n會紀錄成績";
			getRes = true;
			showResTimer = 10f;
		}
		//敵血條
		iniColor=stageColor[0];
		bgColor=stageBgColor[0];
		hpColor.pixelInset = new Rect(X,0f,-Screen.width,0f);
		hpColor.color = iniColor;
		nums2 = nums;
		pNums2 = pNums;
		showChangeHp2 = showChangeHp;
		staLv = GameManager.StaLevel (GameManager.playingLevel);
		hpMaxLine = GameManager.GetLevelHp(staLv);
		oneLineHP = hpMaxLine/10;
		rate = Screen.width / (float)oneLineHP;
		minusHP = GameManager.GetMinusHp (staLv);
		if (GameManager.wearSk1 == 9 || GameManager.wearSk2 == 9 || GameManager.wearSk3 == 9) {
			//sk起跑戰術
			if(GameManager.skLv[8]<10)
				stageHp = 120 * GameManager.skLv[8];
			else
				stageHp = 240 * GameManager.skLv[8];
			if(stageHp > hpMaxLine/2)
				stageHp = hpMaxLine/2;
		}else
			stageHp = 0;
		//自血條
		addHP = GameManager.GetAddHp ();
		mineHpL = GameManager.GetMineHpL();
		mineHp = mineHpL;
		mineHpRate = Screen.width / (float)mineHpL;
		mineHpColor.pixelInset = new Rect(X,0f,0f,0f);
		mineHPCoRa = mineHpCo / screenW05;
		//經驗條
		expRate = screenH05 / (float)GameManager.GetExpLine ();
		expH = -screenH05;
		expBar.pixelInset = new Rect (0f,expY,0f,expH);
		expNowLine = GameManager.GetExpLine ();
		getExp = staLv * staLv;
		bossGetExp = staLv * staLv * 50;
		getMoney = getExp;
		bossGetMoney = bossGetExp;
		expCoRa = mineHpCo / (screenH025);
		if (GameManager.wearSk1 == 1 || GameManager.wearSk2 == 1 || GameManager.wearSk3 == 1) {
			//sk商店祝福
			getMoney += GameManager.skLv[0]*GameManager.skLv[0];
			bossGetMoney += GameManager.skLv[0]*GameManager.skLv[0];
		}
		//對話
		mesRect.y = ToScreen(player.position.y);
	}

	void FixedUpdate () {
		//GUI位置變更
		if (tmpSW != Screen.width) {
			tmpSW = Screen.width;
			labFoSi = Mathf.RoundToInt(Screen.width*0.02682f); //18
			labFoSi2 = Mathf.RoundToInt(Screen.width*0.03582f); //24
			resFoSi = Mathf.RoundToInt(Screen.width*0.02985f); //20
			screenW05 = Screen.width*0.5f;
			screenH05 = Screen.height*0.5f;
			screenH025 = Screen.height*0.25f;
			//敵人血條
			W=-Screen.width;
			X=Screen.width*0.02923f; //19.5849
			showHpRect = new Rect(0f,Screen.height*0.05f,Screen.width*0.95f,Screen.height*0.1f);
			//自己血條
			mineHpLRect = new Rect(Screen.width*0.04f,Screen.height*0.85f,Screen.width*0.5f,Screen.height*0.2f);
			mineHpW = -Screen.width;
			nowMineHpW = -Screen.width;
			//暫停
			pauseRect = new Rect(Screen.width*0.01f,Screen.height*0.13f,Screen.width*0.15f,Screen.height*0.15f);
			pauUpRect = new Rect (Screen.width*0.3f,Screen.height*0.5f,Screen.width*0.4f,Screen.height*0.15f);
			pauDownRect = new Rect (Screen.width*0.28f,Screen.height*0.7f,Screen.width*0.44f,Screen.height*0.2f);
			//EXP條
			expHowRect = new Rect(Screen.width*0.97f,Screen.height*0.14f,Screen.width*0.02f,Screen.height*0.52f);
			expLvRect = new Rect(Screen.width*0.9f,Screen.height*0.65f,Screen.width*0.1f,Screen.height*0.15f);
			expY = Screen.height * 0.5f * 0.02923f;
			//右上成就
			getResRect = new Rect(Screen.width*0.75f,0f,Screen.width*0.25f,Screen.height*0.25f);
			getResLabRec = new Rect(0,0,Screen.width*0.25f,Screen.height*0.25f);
			//左下錢
			moneyRect = new Rect(Screen.width*0.025f,Screen.height*0.935f,Screen.width*0.8f,Screen.height*0.1f);
			backHallRect = new Rect(Screen.width*0.01f,Screen.height*0.15f,Screen.width*0.2f,Screen.height*0.15f);
			restartRect = new Rect(Screen.width*0.79f,Screen.height*0.15f,Screen.width*0.2f,Screen.height*0.15f);
			timeRect = new Rect(0f,Screen.height*0.5f,Screen.width,Screen.height*0.5f);
			//主角對話框
			mesRect = new Rect(0f,0f,Screen.width*0.2f,Screen.height*0.23f);
			mesLabRect = new Rect(Screen.width*0.005f,Screen.height*0.05f,Screen.width*0.19f,Screen.height*0.2f);
			mesPoRate = Screen.width*0.04545f;
		}
		//21E檢查
		if (tmpMoney != GameManager.money) {
			tmpMoney = GameManager.money;
			if (GameManager.money > 2100000000){
				getMoney = 0;
				bossGetMoney = 0;
				GameManager.money = 2100000000;
			}
		}
		//垃圾回收
		if ((gcTimer -= 0.02f) <= 0f) {
			System.GC.Collect ();
			gcTimer=5f;
		}
		GameManager.playTime += 0.02f;

		if(!endIn){
			useTime += 0.02f;
		}
		//*******************音樂***********************/
		//關卡切換音樂漸變
		if (audioObj.volume < 1f)
			audioObj.volume += 0.02f;
		
		//Start轉Loop
		if (!audioObj.loop && !warningIn) {
			if (audioPlayTimer > 0)
				audioPlayTimer -= 0.02f;
			else{
				if (GameManager.playingLevel == 0){
					audioObj.clip = teachLoop;
				}else if (GameManager.playingLevel == 1){
					if(isBossed){
						audioObj.clip = s1BLoop;
					}else{
						audioObj.clip = s1Loop;
					}
				}else if(GameManager.playingLevel == 2){
					if(isBossed){
						audioObj.clip = s2BLoop;
					}else{
						audioObj.clip = s2Loop;
					}
				}else if(GameManager.playingLevel == 3){
					if(isBossed){
						audioObj.clip = s3BLoop;
					}else{
						audioObj.clip = s3Loop;
					}
				}else if(GameManager.playingLevel == 4){
					audioObj.clip = s4BLoop;
				}else{
					if(bossCo < 4)
						audioObj.clip = s1BLoop;
					else if(bossCo < 7)
						audioObj.clip = s2BLoop;
					else if(bossCo < 9)
						audioObj.clip = s3BLoop;
					else
						audioObj.clip = s4BLoop;
				}
				audioObj.loop = true;
				audioObj.Play();
			}
		}
		//*******************敵人血條***********************/
		//色轉回
		if(hpColor.color != iniColor)
			hpColor.color = Color.Lerp(hpColor.color,iniColor,0.1f);
		//寬變
		if(endIn)
			W = Mathf.Lerp(W,(float)oneLineHP*rate-Screen.width,0.1f);
		else
			W = Mathf.Lerp(W,(float)(stageHp%oneLineHP)*rate-Screen.width,0.1f);
		if(showdEHp != stageHp){
			if(showdEHptmp > (float)stageHp * 0.999f)
				showdEHptmp = (float)stageHp;
			else
				showdEHptmp = Mathf.Lerp(showdEHptmp,(float)stageHp,0.2f);
			showdEHp = Mathf.RoundToInt(showdEHptmp);
		}
		if(nowW != W){
			nowW = W;
			X = Mathf.Abs(W*0.02923f);
			hpColor.pixelInset = new Rect(X,0f,W,0f);
		}
		if(nowStaHP != stageHp){
			hpColor.color=addColor; //轉綠
			nowStaHP = stageHp;
			//背色改變
			if(!endIn){
				if(lifeCount<10 && stageHp>=oneLineHP*10 && isBossed){ //Stage4Boss血量區間-2
					//CLEAR
					iniColor=stageColor[10];
					bgColor=stageBgColor[10];
					lifeCount = 10;
					lifeCountY+=lifeCount-lifeCountY%10;
					bossBoomed = false; //S4B
					endIn=true;
					AudioSource.PlayClipAtPoint(clearSE,Vector3.zero);
					if(GameManager.playingLevel == 0){
						bossBoomed = true;
					}
				}else if(lifeCount<9 && stageHp>=oneLineHP*9 && isBossed){
					//改色
					iniColor=stageColor[9];
					bgColor=stageBgColor[9];
					lifeCount = 9;
					phase = 5;
					lifeCountY+=lifeCount-lifeCountY%10;
				}else if(lifeCount<8 && stageHp>=oneLineHP*8 && isBossed){
					//改色
					iniColor=stageColor[8];
					bgColor=stageBgColor[8];
					lifeCount = 8;
					phase = 4;
					lifeCountY+=lifeCount-lifeCountY%10;
				}else if(lifeCount<7 && stageHp>=oneLineHP*7 && isBossed){
					//改色
					iniColor=stageColor[7];
					bgColor=stageBgColor[7];
					lifeCount = 7;
					phase = 3;
					lifeCountY+=lifeCount-lifeCountY%10;
				}else if(lifeCount<6 && stageHp>=oneLineHP*6 && isBossed){
					//改色
					iniColor=stageColor[6];
					bgColor=stageBgColor[6];
					lifeCount = 6;
					phase = 2;
					lifeCountY+=lifeCount-lifeCountY%10;
				}else if(lifeCount<5 && stageHp>=oneLineHP*5 && isBossed){
					//改色
					iniColor=stageColor[5];
					bgColor=stageBgColor[5];
					lifeCount = 5;
					if(GameManager.playingLevel == 5)
						phase = 3;
					else
						phase = 1;
					lifeCountY+=lifeCount-lifeCountY%10;
				}else if(lifeCount<4 && stageHp>=oneLineHP*4){
					//BOSSIn
					if(!isBossed){
						FireBall.bossFireBall = true; //清場
						Instantiate(warFace,Vector3.zero,Quaternion.identity);
						warningIn = true;
						audioObj.Stop();
						audioObj.clip = null;
						stageHp = oneLineHP*4;
						isBossed = true;
					}
					//改色
					iniColor=stageColor[4];
					bgColor=stageBgColor[4];
					lifeCount = 4;
					lifeCountY+=lifeCount-lifeCountY%10;
				}else if(lifeCount<3 && stageHp>=oneLineHP*3){
					//改色
					iniColor=stageColor[3];
					bgColor=stageBgColor[3];
					lifeCount = 3;
					lifeCountY+=lifeCount-lifeCountY%10;
				}else if(lifeCount<2 && stageHp>=oneLineHP*2){
					//改色
					iniColor=stageColor[2];
					bgColor=stageBgColor[2];
					lifeCount = 2;
					lifeCountY+=lifeCount-lifeCountY%10;
				}else if(lifeCount<1 && stageHp>=oneLineHP){
					//改色
					iniColor=stageColor[1];
					bgColor=stageBgColor[1];
					lifeCount = 1;
					lifeCountY+=lifeCount-lifeCountY%10;
				}
			}
		}
		//warning
		if (warningIn) {
			if(warningTimer > 0){
				warningTimer -= 0.02f;
			}else{
				//warning結束 BOSSIN
				if(GameManager.playingLevel == 1){
					int tmp = Random.Range(1,4);
					if(tmp == 1)
						Instantiate(s1Eagle,new Vector3(15.0f,8f,7.0f),Quaternion.identity);
					else if(tmp == 2)
						Instantiate(s1But,new Vector3(15.0f,8f,7.0f),Quaternion.identity);
					else
						Instantiate(s1Square,new Vector3(15.0f,8f,7.0f),Quaternion.identity);
					audioObj.volume = 1;
					audioObj.clip = s1BStart;
					audioObj.loop = false;
					audioPlayTimer = audioObj.clip.length;
					audioObj.Play ();
				}else if(GameManager.playingLevel == 2){
					int tmp = Random.Range(1,4);
					if(tmp == 1)
						Instantiate(s2Ghost,new Vector3(0.0f,3.5f,-11.0f),new Quaternion(0,1,0,0));
					else if(tmp == 2)
						Instantiate(s2Candle,new Vector3(0.0f,3.5f,-11.0f),new Quaternion(0,1,0,0));
					else
						Instantiate(s2SquareF,new Vector3(0.0f,3.5f,-11.0f),new Quaternion(0,1,0,0));
					audioObj.volume = 1;
					audioObj.clip = s2BStart;
					audioObj.loop = false;
					audioPlayTimer = audioObj.clip.length;
					audioObj.Play ();
				}else if(GameManager.playingLevel == 3){
					if((int)Random.Range(1,3) == 1)
						Instantiate(s3Pegasus,new Vector3(0.0f,1.5f,0f),Quaternion.identity);
					else{
						Instantiate(s3SkyBall,new Vector3(0.0f,1.5f,0f),Quaternion.identity);
						if(!GameManager.s3BSee[1]){
							//對話
							mesTimer = 5f;
							mesText = "...";
							showMes = true;
						}
					}
					audioObj.clip = s3BStart;
					audioObj.volume = 0.4f;
					audioObj.loop = false;
					audioPlayTimer = audioObj.clip.length;
					audioObj.Play ();
				}else if(GameManager.playingLevel == 4){
					Instantiate(s4Capsule,new Vector3(15.0f,0.0f,-7.0f),Quaternion.identity);
					audioObj.clip = s4BStart;
					audioObj.volume = 0.4f;
					audioObj.loop = false;
					audioPlayTimer = audioObj.clip.length;
					audioObj.Play ();
				}else if(GameManager.playingLevel == 5){
					//BOSS
					if(bossCo == 1)
						Instantiate(s1Eagle,new Vector3(15.0f,8f,7.0f),Quaternion.identity);
					else if(bossCo == 2)
						Instantiate(s1But,new Vector3(15.0f,8f,7.0f),Quaternion.identity);
					else if(bossCo == 3)
						Instantiate(s1Square,new Vector3(15.0f,8f,7.0f),Quaternion.identity);
					else if(bossCo == 4)
						Instantiate(s2Ghost,new Vector3(0.0f,3.5f,-11.0f),new Quaternion(0,1,0,0));
					else if(bossCo == 5)
						Instantiate(s2Candle,new Vector3(0.0f,3.5f,-11.0f),new Quaternion(0,1,0,0));
					else if(bossCo == 6)
						Instantiate(s2SquareF,new Vector3(0.0f,3.5f,-11.0f),new Quaternion(0,1,0,0));
					else if(bossCo == 7)
						Instantiate(s3Pegasus,new Vector3(0.0f,1.5f,0f),Quaternion.identity);
					else if(bossCo == 8)
						Instantiate(s3SkyBall,new Vector3(0.0f,1.5f,0f),Quaternion.identity);
					else
						Instantiate(s4Capsule,new Vector3(15.0f,0.0f,-7.0f),Quaternion.identity);
					//MU
					if(bossCo < 4)
						audioObj.clip = s1BStart;
					else if(bossCo < 7)
						audioObj.clip = s2BStart;
					else if(bossCo < 9)
						audioObj.clip = s3BStart;
					else
						audioObj.clip = s4BStart;
					audioObj.volume = 0.4f;
					audioObj.loop = false;
					audioPlayTimer = audioObj.clip.length;
					audioObj.Play ();
				}
				warningIn = false;
			}
		}
		//*******************自己血條***********************/
		//錢變
		if(showdMoney != GameManager.money){
			if(showdMoneytmp > (float)GameManager.money * 0.999f)
				showdMoneytmp = (float)GameManager.money;
			else
				showdMoneytmp = Mathf.Lerp(showdMoneytmp,(float)GameManager.money,0.2f);
			showdMoney = Mathf.RoundToInt(showdMoneytmp);
		}
		//寬變
		if(showdMHp != mineHp){
			if(showdMHptmp > (float)mineHp * 0.999f)
				showdMHptmp = (float)mineHp;
			else
				showdMHptmp = Mathf.Lerp(showdMHptmp,(float)mineHp,0.2f);
			showdMHp = Mathf.RoundToInt(showdMHptmp);
		}
		mineHpW = Mathf.Lerp(mineHpW,(float)mineHp*mineHpRate-Screen.width,0.1f);
		if(nowMineHpW != mineHpW){
			nowMineHpW = mineHpW;
			X = Mathf.Abs(mineHpW*0.02923f);
			mineHpColor.pixelInset = new Rect(X,0f,mineHpW,0f);
			//色變
			if(mineHpW > -screenW05){
				tr = Mathf.Abs(mineHpW * mineHPCoRa);
				tg = mineHpCo;
			}else if(mineHpW == -screenW05){
				tr = mineHpCo;
				tg = mineHpCo;
			}else{
				tr = mineHpCo;
				tg = mineHpCo - (Mathf.Abs(mineHpW * mineHPCoRa) - mineHpCo);
			}
			mineHpColor.color = new Color(tr,tg,0f,0.25f);
		}
		//*******************經驗條***********************/
		if(showdXp != GameManager.playerExp){
			if(showdXptmp > (float)GameManager.playerExp * 0.999f)
				showdXptmp = (float)GameManager.playerExp;
			else
				showdXptmp = Mathf.Lerp(showdXptmp,(float)GameManager.playerExp,0.2f);
			showdXp = Mathf.RoundToInt(showdXptmp);
		}
		//升級
		if(GameManager.playerExp >= expNowLine){
			LvUpSE();
			GameManager.LevelUp();
			expRate = screenH05 / (float)GameManager.GetExpLine ();
			expNowLine = GameManager.GetExpLine ();
			addHP = GameManager.GetAddHp ();
			minusHP = GameManager.GetMinusHp (staLv);
			mineHpL = GameManager.GetMineHpL ();
			mineHpRate = Screen.width / (float)mineHpL;
		}
		//寬變
		expH = Mathf.Lerp(expH,(float)GameManager.playerExp*expRate-screenH05,0.1f);
		if (nowExpH != expH) {
			nowExpH = expH;
			expY = Mathf.Abs(expH*0.01461f);
			expBar.pixelInset = new Rect(0f,expY,0f,expH);
			//色變
			if(expH < -screenH025){
				tr = Mathf.Abs((expH+screenH05) * expCoRa);
				tg = mineHpCo;
			}else if(expH == -screenH025){
				tr = mineHpCo;
				tg = mineHpCo;
			}else{
				tr = mineHpCo;
				tg = mineHpCo - (Mathf.Abs((expH+screenH05) * expCoRa) - mineHpCo);
			}
			expBar.color = new Color(tr,tg,0f,0.25f);
		}
		//*******************成就***********************/
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
		//*******************GAME OVER***********************/
		if(mineHp<1 && !endIn){
			mineHp = 0;
			mineHpColor.color = new Color(mineHpCo,0f,0f,0.25f);
			//時間結算
			int playTime = Mathf.FloorToInt(useTime);
			timeH = playTime/3600;
			timeM = (playTime/60)%60;
			timeS = playTime%60;
			//星數計算
			hitPa = (float)brkCnt / (float)outCount;
			if(hitPa >= 0.9f)
				starCount = 5;
			else if(hitPa >= 0.8f)
				starCount = 4;
			else if(hitPa >= 0.7f)
				starCount = 3;
			else if(hitPa >= 0.6f)
				starCount = 2;
			else
				starCount = 1;
			//登記成就
			if(GameManager.playingLevel != 0)
				ResIn();
			getRes = false; //隱藏成就
			audioObj.Stop();
			AudioSource.PlayClipAtPoint(gameOverSE,Vector3.one+Vector3.one);
			mineHpColor.pixelInset = new Rect(0f,0f,-Screen.width,0f);
			Instantiate (gameoverFace, Vector3.up, Quaternion.identity);
			gameover = true;
			Time.timeScale = 0;
		}
		//*******************CLEAR***********************/
		if(endIn && bossBoomed && !showEnd){
			if(GameManager.playingLevel != 5){
				showEnd=true;
				//時間結算
				int playTime = Mathf.FloorToInt(useTime);
				timeH = playTime/3600;
				timeM = (playTime/60)%60;
				timeS = playTime%60;
				//END MU
				audioObj.clip = clearMu;
				audioObj.loop = true;
				audioObj.volume = 0.4f;
				audioObj.Play();
				//產生Clear物件
				Instantiate(clearFireW,Vector3.zero,Quaternion.identity);
				Instantiate(clearFace,Vector3.zero,Quaternion.identity);
				//星數計算
				hitPa = (float)brkCnt / (float)outCount;
				if(hitPa >= 0.9f)
					starCount = 5;
				else if(hitPa >= 0.8f)
					starCount = 4;
				else if(hitPa >= 0.7f)
					starCount = 3;
				else if(hitPa >= 0.6f)
					starCount = 2;
				else
					starCount = 1;
				//登記成就
				if(GameManager.playingLevel != 0)
					ResIn(true);
				if (!GameManager.resGet [1]) {
					//成就首殺BOSS
					MoneySE();
					getResText = "成就完成！\n" + GameManager.ResName(2) + "\n$" + GameManager.ResBackMoney(2).ToString("N0");
					getRes = true;
					showResTimer = 7f;
					GameManager.money += GameManager.ResBackMoney(2);
					GameManager.resGet [1] = true;
				}else if(GameManager.playingLevel == 1){
					if (!GameManager.resGet [3]) {
						//成就深綠北方
						if(GameManager.s1BSee[0] && GameManager.s1BSee[1] && GameManager.s1BSee[2]){
							MoneySE();
							getResText = "成就完成！\n" + GameManager.ResName(4) + "\n$" + GameManager.ResBackMoney(4).ToString("N0");
							getRes = true;
							showResTimer = 7f;
							GameManager.money += GameManager.ResBackMoney(4);
							GameManager.resGet [3] = true;
						}
					}
				}else if(GameManager.playingLevel == 2){
					if (!GameManager.resGet [4]) {
						//成就太古時計
						if(GameManager.s2BSee[0] && GameManager.s2BSee[1] && GameManager.s2BSee[2]){
							MoneySE();
							getResText = "成就完成！\n" + GameManager.ResName(5) + "\n$" + GameManager.ResBackMoney(5).ToString("N0");
							getRes = true;
							showResTimer = 7f;
							GameManager.money += GameManager.ResBackMoney(5);
							GameManager.resGet [4] = true;
						}
					}
				}else if(GameManager.playingLevel == 3){
					if (!GameManager.resGet [5]) {
						//成就寂靜星群
						if(GameManager.s3BSee[0] && GameManager.s3BSee[1]){
							MoneySE();
							getResText = "成就完成！\n" + GameManager.ResName(6) + "\n$" + GameManager.ResBackMoney(6).ToString("N0");
							getRes = true;
							showResTimer = 7f;
							GameManager.money += GameManager.ResBackMoney(6);
							GameManager.resGet [5] = true;
						}
					}
				}else if(GameManager.playingLevel == 4){
					if (!GameManager.resGet [6]) {
						//成就擊落流星
						MoneySE();
						getResText = "成就完成！\n" + GameManager.ResName(7) + "\n$" + GameManager.ResBackMoney(7).ToString("N0");
						getRes = true;
						showResTimer = 7f;
						GameManager.money += GameManager.ResBackMoney(7);
						GameManager.resGet [6] = true;
					}
				}
			}else{ //Level Y
				endTimer = 6f;
				showEnd = true;
				audioObj.Stop();
				audioObj.clip = null;
				if (!GameManager.resGet [3]) {
					//成就深綠北方
					if(GameManager.s1BSee[0] && GameManager.s1BSee[1] && GameManager.s1BSee[2]){
						MoneySE();
						getResText = "成就完成！\n" + GameManager.ResName(4) + "\n$" + GameManager.ResBackMoney(4).ToString("N0");
						getRes = true;
						showResTimer = 7f;
						GameManager.money += GameManager.ResBackMoney(4);
						GameManager.resGet [3] = true;
					}
				}
				else if (!GameManager.resGet [4]) {
					//成就太古時計
					if(GameManager.s2BSee[0] && GameManager.s2BSee[1] && GameManager.s2BSee[2]){
						MoneySE();
						getResText = "成就完成！\n" + GameManager.ResName(5) + "\n$" + GameManager.ResBackMoney(5).ToString("N0");
						getRes = true;
						showResTimer = 7f;
						GameManager.money += GameManager.ResBackMoney(5);
						GameManager.resGet [4] = true;
					}
				}
				else if (!GameManager.resGet [5]) {
					//成就寂靜星群
					if(GameManager.s3BSee[0] && GameManager.s3BSee[1]){
						MoneySE();
						getResText = "成就完成！\n" + GameManager.ResName(6) + "\n$" + GameManager.ResBackMoney(6).ToString("N0");
						getRes = true;
						showResTimer = 7f;
						GameManager.money += GameManager.ResBackMoney(6);
						GameManager.resGet [5] = true;
					}
				}
				else if (!GameManager.resGet [8]) {
					//成就無限天國
					if(staLv > 99){
						MoneySE();
						getResText = "成就完成！\n" + GameManager.ResName(9) + "\n$" + GameManager.ResBackMoney(9).ToString("N0");
						getRes = true;
						showResTimer = 7f;
						GameManager.money += GameManager.ResBackMoney(9);
						GameManager.resGet [8] = true;
					}
				}
			}
		}
		if(showEnd){
			if(endTimer >= 0){
				if(endTimer>4f && endTimer<4.1f && !showMes){
					//對話
					mesTimer = 3f;
					if(GameManager.playingLevel == 0){
						mesText = "感覺我又變得更強了!";
					}else if(GameManager.playingLevel == 5){
						int ran = Random.Range(1,7);
						if(ran == 1)
							mesText = "打得真辛苦~有沒有寶藏可以撿呢?";
						else if(ran == 2)
							mesText = "這也太難打了!";
						else if(ran == 3)
							mesText = "下一個來吧!";
						else if(ran == 3)
							mesText = "再來！";
						else if(ran == 4)
							mesText = "YES! 就是要這樣!";
						else if(ran == 5)
							mesText = "哇~天女散花了!";
						else if(ran == 6)
							mesText = "好像賺到了不少錢呢!";
					}else{
						int ran = Random.Range(1,8);
						if(ran == 1)
							mesText = "打得真辛苦~有沒有寶藏可以撿呢?";
						else if(ran == 2)
							mesText = "這也太難打了!";
						else if(ran == 3)
							mesText = "打完收工~~!";
						else if(ran == 3 && GameManager.resGet[2])
							mesText = "回去可以見到也也了嗎?";
						else if(ran == 3 || ran == 4)
							mesText = "YES! 就是要這樣!";
						else if(ran == 5)
							mesText = "哇~天女散花了!";
						else if(ran == 6)
							mesText = "好像賺到了不少錢呢!";
						else
							mesText = "呀呼!! 回去囉!!";
					}
					showMes = true;
				}
				if(endTimer<2.1f && !rewardIn && GameManager.playingLevel != 0){
					if(((int)Random.Range(1,5))>1){ //75%
						//獲得技能
						int getSk = Random.Range(2,12);

						//等級破表
						if(getSk == 10 && GameManager.skLv[9] > 99){
							//獲得摳摳
							int tmp = staLv*staLv*150;
							if (GameManager.wearSk1 == 1 || GameManager.wearSk2 == 1 || GameManager.wearSk3 == 1) {
								//sk商店祝福
								tmp += GameManager.skLv[0]*GameManager.skLv[0];
							}
							getResText = "關卡獎勵\n$" + tmp;
							if(GameManager.money + tmp < 2100000000)
								GameManager.money += tmp;
							else
								GameManager.money = 2100000000;
						}else if(getSk == 8 && GameManager.skLv[7] > 99){
							//獲得摳摳
							int tmp = staLv*staLv*150;
							if (GameManager.wearSk1 == 1 || GameManager.wearSk2 == 1 || GameManager.wearSk3 == 1) {
								//sk商店祝福
								tmp += GameManager.skLv[0]*GameManager.skLv[0];
							}
							getResText = "關卡獎勵\n$" + tmp;
							if(GameManager.money + tmp < 2100000000)
								GameManager.money += tmp;
							else
								GameManager.money = 2100000000;
						}else if(getSk == 11 && GameManager.skLv[10] > 99){
							//獲得摳摳
							int tmp = staLv*staLv*150;
							if (GameManager.wearSk1 == 1 || GameManager.wearSk2 == 1 || GameManager.wearSk3 == 1) {
								//sk商店祝福
								tmp += GameManager.skLv[0]*GameManager.skLv[0];
							}
							getResText = "關卡獎勵\n$" + tmp;
							if(GameManager.money + tmp < 2100000000)
								GameManager.money += tmp;
							else
								GameManager.money = 2100000000;
						}else{
							//正常獎勵
							getResText = "關卡獎勵\n" + GameManager.ShName(getSk);
							GameManager.skLv[getSk-1]++;
							//開商店開技能
							if(!GameManager.shOpen[getSk-1])
								GameManager.shOpen[getSk-1] = true;
							if(!GameManager.skOpen[getSk-1])
								GameManager.skOpen[getSk-1] = true;
						}
					}else{
						//獲得摳摳
						int tmp = staLv*staLv*150;
						if (GameManager.wearSk1 == 1 || GameManager.wearSk2 == 1 || GameManager.wearSk3 == 1) {
							//sk商店祝福
							tmp += GameManager.skLv[0]*GameManager.skLv[0];
						}
						getResText = "關卡獎勵\n$" + tmp;
						if(GameManager.money + tmp < 2100000000)
							GameManager.money += tmp;
						else
							GameManager.money = 2100000000;
					}
					MoneySE();
					getResRect = new Rect(Screen.width*0.6f,0f,Screen.width*0.4f,Screen.height*0.18f);
					getResLabRec = new Rect(0,0,Screen.width*0.4f,Screen.height*0.18f);
					getRes = true;
					showResTimer = 7f;
					rewardIn = true;
					GameManager.Save();
				}
				endTimer -= 0.02f;
			}else if(GameManager.playingLevel == 5){
				//Y接關
				//Ini
				showEnd = false;
				endIn = false;
				bossBoomed = false;
				rewardIn = false;
				phase = 0;
				levelYFlag += 3;
				lifeCount = 0;

				//敵血條
				stageHp = 0;
				iniColor = stageColor[0];
				bgColor = stageBgColor[0];
				hpColor.pixelInset = new Rect(X,0f,-Screen.width,0f);
				hpColor.color = iniColor;
				staLv = GameManager.StaLevel (GameManager.playingLevel) + levelYFlag;
				hpMaxLine = GameManager.GetLevelHp(staLv);
				oneLineHP = hpMaxLine/10;
				rate = Screen.width / (float)oneLineHP;
				minusHP = GameManager.GetMinusHp (staLv);
				if (GameManager.wearSk1 == 9 || GameManager.wearSk2 == 9 || GameManager.wearSk3 == 9) {
					//sk起跑戰術
					if(GameManager.skLv[8]<10)
						stageHp = 120 * GameManager.skLv[8];
					else
						stageHp = 240 * GameManager.skLv[8];
					if(stageHp > hpMaxLine/2)
						stageHp = hpMaxLine/2;
				}else
					stageHp = 0;
				//自血條
				mineHp = mineHpL;
				//經驗條
				getExp = staLv * staLv;
				bossGetExp = staLv * staLv * 50;
				getMoney = getExp;
				bossGetMoney = bossGetExp;
				//技能
				if(sk4On){
					sk4Pow = (float)(addHP + GameManager.skLv[3]*12);
				}
				if(sk11On){
					sk11Pow = Mathf.RoundToInt((float)GameManager.GetPlayerAtk() * 0.01f * (float)GameManager.skLv[10]);
					if(sk11Pow < 1)
						sk11Pow = 1;
					else if(sk11Pow > GameManager.GetPlayerAtk())
						sk11Pow = GameManager.GetPlayerAtk();
				}

				//不重複BOSS
				int tmpCo = Random.Range(1,10);
				while(tmpCo == bossCo)
					tmpCo = Random.Range(1,10);
				bossCo = tmpCo;
				//背景
				Destroy(nowBg);
				/*
				if(bossCo < 4)
					nowBg = Instantiate (s1Bg, new Vector3 (0f,0f,10f),Quaternion.identity) as GameObject;
				else if(bossCo < 7)
					nowBg = Instantiate (s2Bg, new Vector3 (0f,0f,10f),Quaternion.identity) as GameObject;
				else if(bossCo < 9)
					nowBg = Instantiate (s3Bg, new Vector3 (0f,0f,10f),Quaternion.identity) as GameObject;
				else
					nowBg = Instantiate (s4Bg, new Vector3 (0f,0f,10f),Quaternion.identity) as GameObject;
				*/
				int tmp = Random.Range(1,5);
				if(tmp == 1)
					nowBg = Instantiate (s1Bg, new Vector3 (0f,0f,10f),Quaternion.identity) as GameObject;
				else if(tmp == 2)
					nowBg = Instantiate (s2Bg, new Vector3 (0f,0f,10f),Quaternion.identity) as GameObject;
				else if(tmp == 3)
					nowBg = Instantiate (s3Bg, new Vector3 (0f,0f,10f),Quaternion.identity) as GameObject;
				else
					nowBg = Instantiate (s4Bg, new Vector3 (0f,0f,10f),Quaternion.identity) as GameObject;
				//Boss起頭
				Instantiate(warFace,Vector3.zero,Quaternion.identity);
				warningIn = true;
				isBossed = true;
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

	void Update () {
		if(gameover && gameoverTimer >= 1){
			gameoverTimer -= 0.02f;
			//未跑完數值
			if(showdEHp != stageHp){
				if(showdEHptmp > (float)stageHp * 0.9f)
					showdEHptmp = (float)stageHp;
				else
					showdEHptmp = Mathf.Lerp(showdEHptmp,(float)stageHp,0.2f);
				showdEHp = Mathf.RoundToInt(showdEHptmp);
			}
			if(showdMoney != GameManager.money){
				if(showdMoneytmp > (float)GameManager.money * 0.9f)
					showdMoneytmp = (float)GameManager.money;
				else
					showdMoneytmp = Mathf.Lerp(showdMoneytmp,(float)GameManager.money,0.2f);
				showdMoney = Mathf.RoundToInt(showdMoneytmp);
			}
			if(showdMHp != mineHp){
				if(showdMHptmp > (float)mineHp * 0.9f)
					showdMHptmp = (float)mineHp;
				else
					showdMHptmp = Mathf.Lerp(showdMHptmp,(float)mineHp,0.2f);
				showdMHp = Mathf.RoundToInt(showdMHptmp);
			}
			if(showdXp != GameManager.playerExp){
				if(showdXptmp > (float)GameManager.playerExp * 0.9f)
					showdXptmp = (float)GameManager.playerExp;
				else
					showdXptmp = Mathf.Lerp(showdXptmp,(float)GameManager.playerExp,0.2f);
				showdXp = Mathf.RoundToInt(showdXptmp);
			}
		}
		if(showHiPaGo && showdHitPa != hitPa*100){
			showdHitPatmp = Mathf.Lerp(showdHitPatmp,hitPa*100.0f,0.2f);
			showdHitPa = Mathf.RoundToInt(showdHitPatmp);
		}
		//*******************對話***********************/
		if(showMes){
			mesRect.x = ToScreen(player.position.x);
			//超界
			if(mesRect.x + mesRect.width > Screen.width){
				mesRect.x = Screen.width - mesRect.width;
			}else if(mesRect.x < 0f){
				mesRect.x = 0f;
			}
		}
	}

	void OnGUI(){
		if(showGUI){
			GUI.skin.label.fontSize = labFoSi;
			GUI.skin.button.fontSize = labFoSi2;
			//敵血條
			GUI.skin.label.alignment = TextAnchor.UpperRight;
			GUI.Label (showHpRect, showdEHp.ToString("N0")+"/"+hpMaxLine.ToString("N0"));
			//血條累計
			GUI.skin.label.alignment = TextAnchor.UpperLeft;
			GUI.Label (showHpRect, "　 X"+lifeCountY.ToString()+" 關卡Lv."+staLv.ToString());
			//自血條
			GUI.Label (mineHpLRect, showdMHp.ToString("N0")+"/"+mineHpL.ToString("N0"));
			//左下錢
			GUI.Label (moneyRect, "$"+showdMoney.ToString("N0"));
			//經驗條
			GUI.skin.label.alignment = TextAnchor.LowerLeft;
			GUI.Label (expHowRect,showdXp.ToString());
			GUI.skin.label.alignment = TextAnchor.UpperCenter;
			GUI.Label (expLvRect, "Lv."+GameManager.playerLevel);
			//右上成就視窗
			if(getRes){
				GUI.Window(2,getResRect,getResWindow,"");
			}
			//玩家對話
			if(showMes){
				GUI.skin.window.fontSize = labFoSi;
				GUI.Window(3,mesRect,mesWindow,GameManager.GetNpcName(1));
			}
			if(gameover || endIn){
				//GAME OVER
				if(gameoverTimer < 1f){
					//回大廳
					if(GUI.Button(backHallRect,"回大廳")){
						ClickSound();
						showGUI = false;
						audioObj.Stop();
						Instantiate(loadingFace,new Vector3(0f,0f,0.5f),Quaternion.identity);
						Time.timeScale=1;
						GameManager.Save();
						Application.LoadLevel("hall");
					}
					//重來
					if(GUI.Button(restartRect,"再來一次")){
						ClickSound();
						LRwind.isWind = false;
						WindBallWind.isWind = false;
						WindBallWind.windFource = 0f;
						showGUI = false;
						Instantiate(loadingFace,new Vector3(0f,0f,0.5f),Quaternion.identity);
						Time.timeScale=1;
						GameManager.Save();
						Application.LoadLevel("playing");
					}
					//使用時間
					showHiPaGo = true;
					GUI.skin.label.fontSize = labFoSi2;
					GUI.Label(timeRect,"總時間："+
					          ((timeH<10)?"0":"")+timeH.ToString()+":"+
					          ((timeM<10)?"0":"")+timeM.ToString()+":"+
					          ((timeS<10)?"0":"")+timeS.ToString()+
					          "\n打擊率："+showdHitPa+"% "+GameManager.Star(starCount)+
					          "\n遺漏數："+lostCount);
				}
				//CLEAR
				else if(endTimer < 1f && GameManager.playingLevel != 5){
					//回大廳
					if(GUI.Button(backHallRect,"回大廳")){
						ClickSound();
						showGUI = false;
						audioObj.Stop();
						Instantiate(loadingFace,new Vector3(0f,0f,0.5f),Quaternion.identity);
						Time.timeScale=1;
						GameManager.Save();
						Application.LoadLevel("hall");
					}
					//重來
					if(GUI.Button(restartRect,"再來一次")){
						ClickSound();
						LRwind.isWind = false;
						WindBallWind.isWind = false;
						WindBallWind.windFource = 0f;
						showGUI = false;
						Instantiate(loadingFace,new Vector3(0f,0f,0.5f),Quaternion.identity);
						Time.timeScale=1;
						GameManager.Save();
						Application.LoadLevel("playing");
					}
					//使用時間+星數
					showHiPaGo = true;
					GUI.skin.label.fontSize = labFoSi2;
					GUI.Label(timeRect,"總時間："+
					          ((timeH<10)?"0":"")+timeH+":"+
					          ((timeM<10)?"0":"")+timeM+":"+
					          ((timeS<10)?"0":"")+timeS+
					          "\n打擊率："+showdHitPa+"% "+GameManager.Star(starCount)+
					          "\n遺漏數："+lostCount.ToString("N0"));
				}
			}else{
				//暫停
				if(Time.timeScale!=0){
					if (GUI.Button (pauseRect, "暫停")) {
						ClickSound();
						Time.timeScale=0;
						audioObj.Pause();
						Instantiate(pauseFace,new Vector3(0f,0f,0.4f),Quaternion.identity);
					}
				}else{
					GUI.skin.button.fontSize = labFoSi+labFoSi;
					if(GUI.Button(pauUpRect,"繼續")){
						ClickSound();
						Time.timeScale=1;
						audioObj.Play();
					}
					if(GUI.Button(pauDownRect,"返回大廳")){
						if(GameManager.playingLevel == 5){
							//時間結算
							int playTime = Mathf.FloorToInt(useTime);
							timeH = playTime/3600;
							timeM = (playTime/60)%60;
							timeS = playTime%60;
							//星數計算
							hitPa = (float)brkCnt / (float)outCount;
							if(hitPa >= 0.9f)
								starCount = 5;
							else if(hitPa >= 0.8f)
								starCount = 4;
							else if(hitPa >= 0.7f)
								starCount = 3;
							else if(hitPa >= 0.6f)
								starCount = 2;
							else
								starCount = 1;
							//登記成就
							ResIn(true);
						}
						ClickSound();
						showGUI = false;
						Instantiate(loadingFace,new Vector3(0f,0f,0.5f),Quaternion.identity);
						Time.timeScale=1;
						GameManager.Save();
						Application.LoadLevel("hall");
					}
				}
			}
		}
	}
	void getResWindow(int WindowID){
		GUI.skin.label.fontSize = resFoSi;
		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		GUI.Label (getResLabRec, getResText);
	}
	void mesWindow(int windowID){
		GUI.skin.label.alignment = TextAnchor.UpperLeft;
		GUI.skin.label.fontSize = labFoSi;
		GUI.Label(mesLabRect,mesText);
	}
	//加血字
	public static void ShowPlus(int num,Vector3 pos,bool minus=false,bool plusMine=false){
		if (num < 10) {
			int one = num;
			GameObject testV;
			testV = Instantiate(showChangeHp2,pos,Quaternion.identity) as GameObject;
			GameObject testV2;
			if(plusMine){
				//+
				testV2 = Instantiate(pNums2[10],Vector3.zero,Quaternion.identity) as GameObject;
				testV2.transform.parent = testV.transform;
				testV2.transform.localPosition = new Vector3(-0.4f,0f,0f);
				//1
				testV2 = Instantiate(pNums2[one],Vector3.zero,Quaternion.identity) as GameObject;
				testV2.transform.parent = testV.transform;
				testV2.transform.localPosition = new Vector3(0f,0f,0f);
			}else{
				//+
				if(minus)
					testV2 = Instantiate(nums2[11],Vector3.zero,Quaternion.identity) as GameObject;
				else
					testV2 = Instantiate(nums2[10],Vector3.zero,Quaternion.identity) as GameObject;
				testV2.transform.parent = testV.transform;
				testV2.transform.localPosition = new Vector3(-0.4f,0f,0f);
				//1
				testV2 = Instantiate(nums2[one],Vector3.zero,Quaternion.identity) as GameObject;
				testV2.transform.parent = testV.transform;
				testV2.transform.localPosition = new Vector3(0f,0f,0f);
			}
		}else if(num < 100){
			int ten = num / 10;
			int one = num-(ten*10);
			GameObject testV;
			testV = Instantiate(showChangeHp2,pos,Quaternion.identity) as GameObject;
			GameObject testV2;
			if(plusMine){
				testV2 = Instantiate(pNums2[10],Vector3.zero,Quaternion.identity) as GameObject;
				testV2.transform.parent = testV.transform;
				testV2.transform.localPosition = new Vector3(-0.4f,0f,0f);
				testV2 = Instantiate(pNums2[ten],Vector3.zero,Quaternion.identity) as GameObject;
				testV2.transform.parent = testV.transform;
				testV2.transform.localPosition = new Vector3(0f,0f,0f);
				testV2 = Instantiate(pNums2[one],Vector3.zero,Quaternion.identity) as GameObject;
				testV2.transform.parent = testV.transform;
				testV2.transform.localPosition = new Vector3(0.4f,0f,0f);
			}else{
				if(minus)
					testV2 = Instantiate(nums2[11],Vector3.zero,Quaternion.identity) as GameObject;
				else
					testV2 = Instantiate(nums2[10],Vector3.zero,Quaternion.identity) as GameObject;
				testV2.transform.parent = testV.transform;
				testV2.transform.localPosition = new Vector3(-0.4f,0f,0f);
				testV2 = Instantiate(nums2[ten],Vector3.zero,Quaternion.identity) as GameObject;
				testV2.transform.parent = testV.transform;
				testV2.transform.localPosition = new Vector3(0f,0f,0f);
				testV2 = Instantiate(nums2[one],Vector3.zero,Quaternion.identity) as GameObject;
				testV2.transform.parent = testV.transform;
				testV2.transform.localPosition = new Vector3(0.4f,0f,0f);
			}
		}else if(num < 1000){
			int hun = num / 100;
			int ten = (num - hun*100) / 10;
			int one = num-(hun*100+ten*10);
			GameObject testV;
			testV = Instantiate(showChangeHp2,pos,Quaternion.identity) as GameObject;
			GameObject testV2;
			if(plusMine){
				testV2 = Instantiate(pNums2[10],Vector3.zero,Quaternion.identity) as GameObject;
				testV2.transform.parent = testV.transform;
				testV2.transform.localPosition = new Vector3(-0.4f,0f,0f);
				testV2 = Instantiate(pNums2[hun],Vector3.zero,Quaternion.identity) as GameObject;
				testV2.transform.parent = testV.transform;
				testV2.transform.localPosition = new Vector3(0f,0f,0f);
				testV2 = Instantiate(pNums2[ten],Vector3.zero,Quaternion.identity) as GameObject;
				testV2.transform.parent = testV.transform;
				testV2.transform.localPosition = new Vector3(0.4f,0f,0f);
				testV2 = Instantiate(pNums2[one],Vector3.zero,Quaternion.identity) as GameObject;
				testV2.transform.parent = testV.transform;
				testV2.transform.localPosition = new Vector3(0.8f,0f,0f);
			}else{
				if(minus)
					testV2 = Instantiate(nums2[11],Vector3.zero,Quaternion.identity) as GameObject;
				else
					testV2 = Instantiate(nums2[10],Vector3.zero,Quaternion.identity) as GameObject;
				testV2.transform.parent = testV.transform;
				testV2.transform.localPosition = new Vector3(-0.4f,0f,0f);
				testV2 = Instantiate(nums2[hun],Vector3.zero,Quaternion.identity) as GameObject;
				testV2.transform.parent = testV.transform;
				testV2.transform.localPosition = new Vector3(0f,0f,0f);
				testV2 = Instantiate(nums2[ten],Vector3.zero,Quaternion.identity) as GameObject;
				testV2.transform.parent = testV.transform;
				testV2.transform.localPosition = new Vector3(0.4f,0f,0f);
				testV2 = Instantiate(nums2[one],Vector3.zero,Quaternion.identity) as GameObject;
				testV2.transform.parent = testV.transform;
				testV2.transform.localPosition = new Vector3(0.8f,0f,0f);
			}
		}else if(num < 10000){
			int sou = num / 1000;
			int hun = (num - sou*1000) / 100;
			int ten = (num - (sou*1000+hun*100)) / 10;
			int one = num % 10;
			GameObject testV;
			testV = Instantiate(showChangeHp2,pos,Quaternion.identity) as GameObject;
			GameObject testV2;
			if(plusMine){
				testV2 = Instantiate(pNums2[10],Vector3.zero,Quaternion.identity) as GameObject;
				testV2.transform.parent = testV.transform;
				testV2.transform.localPosition = new Vector3(-0.4f,0f,0f);
				testV2 = Instantiate(pNums2[sou],Vector3.zero,Quaternion.identity) as GameObject;
				testV2.transform.parent = testV.transform;
				testV2.transform.localPosition = new Vector3(0f,0f,0f);
				testV2 = Instantiate(pNums2[hun],Vector3.zero,Quaternion.identity) as GameObject;
				testV2.transform.parent = testV.transform;
				testV2.transform.localPosition = new Vector3(0.4f,0f,0f);
				testV2 = Instantiate(pNums2[ten],Vector3.zero,Quaternion.identity) as GameObject;
				testV2.transform.parent = testV.transform;
				testV2.transform.localPosition = new Vector3(0.8f,0f,0f);
				testV2 = Instantiate(pNums2[one],Vector3.zero,Quaternion.identity) as GameObject;
				testV2.transform.parent = testV.transform;
				testV2.transform.localPosition = new Vector3(1.2f,0f,0f);
			}else{
				if(minus)
					testV2 = Instantiate(nums2[11],Vector3.zero,Quaternion.identity) as GameObject;
				else
					testV2 = Instantiate(nums2[10],Vector3.zero,Quaternion.identity) as GameObject;
				testV2.transform.parent = testV.transform;
				testV2.transform.localPosition = new Vector3(-0.4f,0f,0f);
				testV2 = Instantiate(nums2[sou],Vector3.zero,Quaternion.identity) as GameObject;
				testV2.transform.parent = testV.transform;
				testV2.transform.localPosition = new Vector3(0f,0f,0f);
				testV2 = Instantiate(nums2[hun],Vector3.zero,Quaternion.identity) as GameObject;
				testV2.transform.parent = testV.transform;
				testV2.transform.localPosition = new Vector3(0.4f,0f,0f);
				testV2 = Instantiate(nums2[ten],Vector3.zero,Quaternion.identity) as GameObject;
				testV2.transform.parent = testV.transform;
				testV2.transform.localPosition = new Vector3(0.8f,0f,0f);
				testV2 = Instantiate(nums2[one],Vector3.zero,Quaternion.identity) as GameObject;
				testV2.transform.parent = testV.transform;
				testV2.transform.localPosition = new Vector3(1.2f,0f,0f);
			}
		}else if(num < 100000){
			int tes = num / 10000;
			int sou = (num - tes*10000) / 1000;
			int hun = (num - (tes*10000+sou*1000)) / 100;
			int ten = (num - (tes*10000+sou*1000+hun*100)) / 10;
			int one = num % 10;
			GameObject testV;
			testV = Instantiate(showChangeHp2,pos,Quaternion.identity) as GameObject;
			GameObject testV2;
			if(plusMine){
				testV2 = Instantiate(pNums2[10],Vector3.zero,Quaternion.identity) as GameObject;
				testV2.transform.parent = testV.transform;
				testV2.transform.localPosition = new Vector3(-0.4f,0f,0f);
				testV2 = Instantiate(pNums2[tes],Vector3.zero,Quaternion.identity) as GameObject;
				testV2.transform.parent = testV.transform;
				testV2.transform.localPosition = new Vector3(0f,0f,0f);
				testV2 = Instantiate(pNums2[sou],Vector3.zero,Quaternion.identity) as GameObject;
				testV2.transform.parent = testV.transform;
				testV2.transform.localPosition = new Vector3(0.4f,0f,0f);
				testV2 = Instantiate(pNums2[hun],Vector3.zero,Quaternion.identity) as GameObject;
				testV2.transform.parent = testV.transform;
				testV2.transform.localPosition = new Vector3(0.8f,0f,0f);
				testV2 = Instantiate(pNums2[ten],Vector3.zero,Quaternion.identity) as GameObject;
				testV2.transform.parent = testV.transform;
				testV2.transform.localPosition = new Vector3(1.2f,0f,0f);
				testV2 = Instantiate(pNums2[one],Vector3.zero,Quaternion.identity) as GameObject;
				testV2.transform.parent = testV.transform;
				testV2.transform.localPosition = new Vector3(1.6f,0f,0f);
			}else{
				if(minus)
					testV2 = Instantiate(nums2[11],Vector3.zero,Quaternion.identity) as GameObject;
				else
					testV2 = Instantiate(nums2[10],Vector3.zero,Quaternion.identity) as GameObject;
				testV2.transform.parent = testV.transform;
				testV2.transform.localPosition = new Vector3(-0.4f,0f,0f);
				testV2 = Instantiate(nums2[tes],Vector3.zero,Quaternion.identity) as GameObject;
				testV2.transform.parent = testV.transform;
				testV2.transform.localPosition = new Vector3(0f,0f,0f);
				testV2 = Instantiate(nums2[sou],Vector3.zero,Quaternion.identity) as GameObject;
				testV2.transform.parent = testV.transform;
				testV2.transform.localPosition = new Vector3(0.4f,0f,0f);
				testV2 = Instantiate(nums2[hun],Vector3.zero,Quaternion.identity) as GameObject;
				testV2.transform.parent = testV.transform;
				testV2.transform.localPosition = new Vector3(0.8f,0f,0f);
				testV2 = Instantiate(nums2[ten],Vector3.zero,Quaternion.identity) as GameObject;
				testV2.transform.parent = testV.transform;
				testV2.transform.localPosition = new Vector3(1.2f,0f,0f);
				testV2 = Instantiate(nums2[one],Vector3.zero,Quaternion.identity) as GameObject;
				testV2.transform.parent = testV.transform;
				testV2.transform.localPosition = new Vector3(1.6f,0f,0f);
			}
		}else if(num < 1000000){
			int hus = num / 100000;
			int tes = (num - hus*100000) / 10000;
			int sou = (num - (hus*100000+tes*10000)) / 1000;
			int hun = (num - (hus*100000+tes*10000+sou*1000)) / 100;
			int ten = (num - (hus*100000+tes*10000+sou*1000+hun*100)) / 10;
			int one = num % 10;
			GameObject testV;
			testV = Instantiate(showChangeHp2,pos,Quaternion.identity) as GameObject;
			GameObject testV2;
			if(plusMine){
				testV2 = Instantiate(pNums2[10],Vector3.zero,Quaternion.identity) as GameObject;
				testV2.transform.parent = testV.transform;
				testV2.transform.localPosition = new Vector3(-0.4f,0f,0f);
				testV2 = Instantiate(pNums2[hus],Vector3.zero,Quaternion.identity) as GameObject;
				testV2.transform.parent = testV.transform;
				testV2.transform.localPosition = new Vector3(0f,0f,0f);
				testV2 = Instantiate(pNums2[tes],Vector3.zero,Quaternion.identity) as GameObject;
				testV2.transform.parent = testV.transform;
				testV2.transform.localPosition = new Vector3(0.4f,0f,0f);
				testV2 = Instantiate(pNums2[sou],Vector3.zero,Quaternion.identity) as GameObject;
				testV2.transform.parent = testV.transform;
				testV2.transform.localPosition = new Vector3(0.8f,0f,0f);
				testV2 = Instantiate(pNums2[hun],Vector3.zero,Quaternion.identity) as GameObject;
				testV2.transform.parent = testV.transform;
				testV2.transform.localPosition = new Vector3(1.2f,0f,0f);
				testV2 = Instantiate(pNums2[ten],Vector3.zero,Quaternion.identity) as GameObject;
				testV2.transform.parent = testV.transform;
				testV2.transform.localPosition = new Vector3(1.6f,0f,0f);
				testV2 = Instantiate(pNums2[one],Vector3.zero,Quaternion.identity) as GameObject;
				testV2.transform.parent = testV.transform;
				testV2.transform.localPosition = new Vector3(2.0f,0f,0f);
			}else{
				if(minus)
					testV2 = Instantiate(nums2[11],Vector3.zero,Quaternion.identity) as GameObject;
				else
					testV2 = Instantiate(nums2[10],Vector3.zero,Quaternion.identity) as GameObject;
				testV2.transform.parent = testV.transform;
				testV2.transform.localPosition = new Vector3(-0.4f,0f,0f);
				testV2 = Instantiate(nums2[hus],Vector3.zero,Quaternion.identity) as GameObject;
				testV2.transform.parent = testV.transform;
				testV2.transform.localPosition = new Vector3(0f,0f,0f);
				testV2 = Instantiate(nums2[tes],Vector3.zero,Quaternion.identity) as GameObject;
				testV2.transform.parent = testV.transform;
				testV2.transform.localPosition = new Vector3(0.4f,0f,0f);
				testV2 = Instantiate(nums2[sou],Vector3.zero,Quaternion.identity) as GameObject;
				testV2.transform.parent = testV.transform;
				testV2.transform.localPosition = new Vector3(0.8f,0f,0f);
				testV2 = Instantiate(nums2[hun],Vector3.zero,Quaternion.identity) as GameObject;
				testV2.transform.parent = testV.transform;
				testV2.transform.localPosition = new Vector3(1.2f,0f,0f);
				testV2 = Instantiate(nums2[ten],Vector3.zero,Quaternion.identity) as GameObject;
				testV2.transform.parent = testV.transform;
				testV2.transform.localPosition = new Vector3(1.6f,0f,0f);
				testV2 = Instantiate(nums2[one],Vector3.zero,Quaternion.identity) as GameObject;
				testV2.transform.parent = testV.transform;
				testV2.transform.localPosition = new Vector3(2.0f,0f,0f);
			}
		}
	}
	void ResIn(bool pass=false){
		//登記成就
		int playLvM1 = GameManager.playingLevel - 1;
		//比第一
		//比等級
		if(staLv > GameManager.bestLv[playLvM1,0]){
			GameManager.bestTime[playLvM1,2] = GameManager.bestTime[playLvM1,1];
			GameManager.bestStar[playLvM1,2] = GameManager.bestStar[playLvM1,1];
			GameManager.bestBoss[playLvM1,2] = GameManager.bestBoss[playLvM1,1];
			GameManager.bestLv[playLvM1,2] = GameManager.bestLv[playLvM1,1];
			GameManager.bestPass[playLvM1,2] = GameManager.bestPass[playLvM1,1];
			GameManager.bestLost[playLvM1,2] = GameManager.bestLost[playLvM1,1];

			GameManager.bestTime[playLvM1,1] = GameManager.bestTime[playLvM1,0];
			GameManager.bestStar[playLvM1,1] = GameManager.bestStar[playLvM1,0];
			GameManager.bestBoss[playLvM1,1] = GameManager.bestBoss[playLvM1,0];
			GameManager.bestLv[playLvM1,1] = GameManager.bestLv[playLvM1,0];
			GameManager.bestPass[playLvM1,1] = GameManager.bestPass[playLvM1,0];
			GameManager.bestLost[playLvM1,1] = GameManager.bestLost[playLvM1,0];

			GameManager.bestTime[playLvM1,0] = useTime;
			GameManager.bestStar[playLvM1,0] = starCount;
			GameManager.bestBoss[playLvM1,0] = bossCo;
			GameManager.bestLv[playLvM1,0] = staLv;
			GameManager.bestPass[playLvM1,0] = pass;
			GameManager.bestLost[playLvM1,0] = lostCount;
		}else if(staLv == GameManager.bestLv[playLvM1,0]){
			//比星數
			if(starCount > GameManager.bestStar[GameManager.playingLevel-1,0]){
				GameManager.bestTime[playLvM1,2] = GameManager.bestTime[playLvM1,1];
				GameManager.bestStar[playLvM1,2] = GameManager.bestStar[playLvM1,1];
				GameManager.bestBoss[playLvM1,2] = GameManager.bestBoss[playLvM1,1];
				GameManager.bestLv[playLvM1,2] = GameManager.bestLv[playLvM1,1];
				GameManager.bestPass[playLvM1,2] = GameManager.bestPass[playLvM1,1];
				GameManager.bestLost[playLvM1,2] = GameManager.bestLost[playLvM1,1];
				
				GameManager.bestTime[playLvM1,1] = GameManager.bestTime[playLvM1,0];
				GameManager.bestStar[playLvM1,1] = GameManager.bestStar[playLvM1,0];
				GameManager.bestBoss[playLvM1,1] = GameManager.bestBoss[playLvM1,0];
				GameManager.bestLv[playLvM1,1] = GameManager.bestLv[playLvM1,0];
				GameManager.bestPass[playLvM1,1] = GameManager.bestPass[playLvM1,0];
				GameManager.bestLost[playLvM1,1] = GameManager.bestLost[playLvM1,0];
				
				GameManager.bestTime[playLvM1,0] = useTime;
				GameManager.bestStar[playLvM1,0] = starCount;
				GameManager.bestBoss[playLvM1,0] = bossCo;
				GameManager.bestLv[playLvM1,0] = staLv;
				GameManager.bestPass[playLvM1,0] = pass;
				GameManager.bestLost[playLvM1,0] = lostCount;
			}
			//比獲勝
			else if(pass && !GameManager.bestPass[GameManager.playingLevel-1,0]){
				GameManager.bestTime[playLvM1,2] = GameManager.bestTime[playLvM1,1];
				GameManager.bestStar[playLvM1,2] = GameManager.bestStar[playLvM1,1];
				GameManager.bestBoss[playLvM1,2] = GameManager.bestBoss[playLvM1,1];
				GameManager.bestLv[playLvM1,2] = GameManager.bestLv[playLvM1,1];
				GameManager.bestPass[playLvM1,2] = GameManager.bestPass[playLvM1,1];
				GameManager.bestLost[playLvM1,2] = GameManager.bestLost[playLvM1,1];
				
				GameManager.bestTime[playLvM1,1] = GameManager.bestTime[playLvM1,0];
				GameManager.bestStar[playLvM1,1] = GameManager.bestStar[playLvM1,0];
				GameManager.bestBoss[playLvM1,1] = GameManager.bestBoss[playLvM1,0];
				GameManager.bestLv[playLvM1,1] = GameManager.bestLv[playLvM1,0];
				GameManager.bestPass[playLvM1,1] = GameManager.bestPass[playLvM1,0];
				GameManager.bestLost[playLvM1,1] = GameManager.bestLost[playLvM1,0];
				
				GameManager.bestTime[playLvM1,0] = useTime;
				GameManager.bestStar[playLvM1,0] = starCount;
				GameManager.bestBoss[playLvM1,0] = bossCo;
				GameManager.bestLv[playLvM1,0] = staLv;
				GameManager.bestPass[playLvM1,0] = pass;
				GameManager.bestLost[playLvM1,0] = lostCount;
			}
			//比時間
			else if(useTime <= GameManager.bestTime[GameManager.playingLevel-1,0]){
				GameManager.bestTime[playLvM1,2] = GameManager.bestTime[playLvM1,1];
				GameManager.bestStar[playLvM1,2] = GameManager.bestStar[playLvM1,1];
				GameManager.bestBoss[playLvM1,2] = GameManager.bestBoss[playLvM1,1];
				GameManager.bestLv[playLvM1,2] = GameManager.bestLv[playLvM1,1];
				GameManager.bestPass[playLvM1,2] = GameManager.bestPass[playLvM1,1];
				GameManager.bestLost[playLvM1,2] = GameManager.bestLost[playLvM1,1];
				
				GameManager.bestTime[playLvM1,1] = GameManager.bestTime[playLvM1,0];
				GameManager.bestStar[playLvM1,1] = GameManager.bestStar[playLvM1,0];
				GameManager.bestBoss[playLvM1,1] = GameManager.bestBoss[playLvM1,0];
				GameManager.bestLv[playLvM1,1] = GameManager.bestLv[playLvM1,0];
				GameManager.bestPass[playLvM1,1] = GameManager.bestPass[playLvM1,0];
				GameManager.bestLost[playLvM1,1] = GameManager.bestLost[playLvM1,0];
				
				GameManager.bestTime[playLvM1,0] = useTime;
				GameManager.bestStar[playLvM1,0] = starCount;
				GameManager.bestBoss[playLvM1,0] = bossCo;
				GameManager.bestLv[playLvM1,0] = staLv;
				GameManager.bestPass[playLvM1,0] = pass;
				GameManager.bestLost[playLvM1,0] = lostCount;
			}
			//比遺漏
			else if(lostCount <= GameManager.bestLost[GameManager.playingLevel-1,0]){
				GameManager.bestTime[playLvM1,2] = GameManager.bestTime[playLvM1,1];
				GameManager.bestStar[playLvM1,2] = GameManager.bestStar[playLvM1,1];
				GameManager.bestBoss[playLvM1,2] = GameManager.bestBoss[playLvM1,1];
				GameManager.bestLv[playLvM1,2] = GameManager.bestLv[playLvM1,1];
				GameManager.bestPass[playLvM1,2] = GameManager.bestPass[playLvM1,1];
				GameManager.bestLost[playLvM1,2] = GameManager.bestLost[playLvM1,1];
				
				GameManager.bestTime[playLvM1,1] = GameManager.bestTime[playLvM1,0];
				GameManager.bestStar[playLvM1,1] = GameManager.bestStar[playLvM1,0];
				GameManager.bestBoss[playLvM1,1] = GameManager.bestBoss[playLvM1,0];
				GameManager.bestLv[playLvM1,1] = GameManager.bestLv[playLvM1,0];
				GameManager.bestPass[playLvM1,1] = GameManager.bestPass[playLvM1,0];
				GameManager.bestLost[playLvM1,1] = GameManager.bestLost[playLvM1,0];
				
				GameManager.bestTime[playLvM1,0] = useTime;
				GameManager.bestStar[playLvM1,0] = starCount;
				GameManager.bestBoss[playLvM1,0] = bossCo;
				GameManager.bestLv[playLvM1,0] = staLv;
				GameManager.bestPass[playLvM1,0] = pass;
				GameManager.bestLost[playLvM1,0] = lostCount;
			}
			//比第二
			else if(staLv > GameManager.bestLv[GameManager.playingLevel-1,1]){
				GameManager.bestTime[playLvM1,2] = GameManager.bestTime[playLvM1,1];
				GameManager.bestStar[playLvM1,2] = GameManager.bestStar[playLvM1,1];
				GameManager.bestBoss[playLvM1,2] = GameManager.bestBoss[playLvM1,1];
				GameManager.bestLv[playLvM1,2] = GameManager.bestLv[playLvM1,1];
				GameManager.bestPass[playLvM1,2] = GameManager.bestPass[playLvM1,1];
				GameManager.bestLost[playLvM1,2] = GameManager.bestLost[playLvM1,1];
				
				GameManager.bestTime[playLvM1,1] = useTime;
				GameManager.bestStar[playLvM1,1] = starCount;
				GameManager.bestBoss[playLvM1,1] = bossCo;
				GameManager.bestLv[playLvM1,1] = staLv;
				GameManager.bestPass[playLvM1,1] = pass;
				GameManager.bestLost[playLvM1,1] = lostCount;
			}else if(staLv == GameManager.bestLv[GameManager.playingLevel-1,1]){
				//比星數
				if(starCount > GameManager.bestStar[GameManager.playingLevel-1,1]){
					GameManager.bestTime[playLvM1,2] = GameManager.bestTime[playLvM1,1];
					GameManager.bestStar[playLvM1,2] = GameManager.bestStar[playLvM1,1];
					GameManager.bestBoss[playLvM1,2] = GameManager.bestBoss[playLvM1,1];
					GameManager.bestLv[playLvM1,2] = GameManager.bestLv[playLvM1,1];
					GameManager.bestPass[playLvM1,2] = GameManager.bestPass[playLvM1,1];
					GameManager.bestLost[playLvM1,2] = GameManager.bestLost[playLvM1,1];
					
					GameManager.bestTime[playLvM1,1] = useTime;
					GameManager.bestStar[playLvM1,1] = starCount;
					GameManager.bestBoss[playLvM1,1] = bossCo;
					GameManager.bestLv[playLvM1,1] = staLv;
					GameManager.bestPass[playLvM1,1] = pass;
					GameManager.bestLost[playLvM1,1] = lostCount;
				}
				//比獲勝
				else if(pass && !GameManager.bestPass[GameManager.playingLevel-1,1]){
					GameManager.bestTime[playLvM1,2] = GameManager.bestTime[playLvM1,1];
					GameManager.bestStar[playLvM1,2] = GameManager.bestStar[playLvM1,1];
					GameManager.bestBoss[playLvM1,2] = GameManager.bestBoss[playLvM1,1];
					GameManager.bestLv[playLvM1,2] = GameManager.bestLv[playLvM1,1];
					GameManager.bestPass[playLvM1,2] = GameManager.bestPass[playLvM1,1];
					GameManager.bestLost[playLvM1,2] = GameManager.bestLost[playLvM1,1];
					
					GameManager.bestTime[playLvM1,1] = useTime;
					GameManager.bestStar[playLvM1,1] = starCount;
					GameManager.bestBoss[playLvM1,1] = bossCo;
					GameManager.bestLv[playLvM1,1] = staLv;
					GameManager.bestPass[playLvM1,1] = pass;
					GameManager.bestLost[playLvM1,1] = lostCount;
				}
				//比時間
				else if(useTime <= GameManager.bestTime[GameManager.playingLevel-1,1]){
					GameManager.bestTime[playLvM1,2] = GameManager.bestTime[playLvM1,1];
					GameManager.bestStar[playLvM1,2] = GameManager.bestStar[playLvM1,1];
					GameManager.bestBoss[playLvM1,2] = GameManager.bestBoss[playLvM1,1];
					GameManager.bestLv[playLvM1,2] = GameManager.bestLv[playLvM1,1];
					GameManager.bestPass[playLvM1,2] = GameManager.bestPass[playLvM1,1];
					GameManager.bestLost[playLvM1,2] = GameManager.bestLost[playLvM1,1];
					
					GameManager.bestTime[playLvM1,1] = useTime;
					GameManager.bestStar[playLvM1,1] = starCount;
					GameManager.bestBoss[playLvM1,1] = bossCo;
					GameManager.bestLv[playLvM1,1] = staLv;
					GameManager.bestPass[playLvM1,1] = pass;
					GameManager.bestLost[playLvM1,1] = lostCount;
				}
				//比遺漏
				else if(lostCount <= GameManager.bestLost[GameManager.playingLevel-1,1]){
					GameManager.bestTime[playLvM1,2] = GameManager.bestTime[playLvM1,1];
					GameManager.bestStar[playLvM1,2] = GameManager.bestStar[playLvM1,1];
					GameManager.bestBoss[playLvM1,2] = GameManager.bestBoss[playLvM1,1];
					GameManager.bestLv[playLvM1,2] = GameManager.bestLv[playLvM1,1];
					GameManager.bestPass[playLvM1,2] = GameManager.bestPass[playLvM1,1];
					GameManager.bestLost[playLvM1,2] = GameManager.bestLost[playLvM1,1];
					
					GameManager.bestTime[playLvM1,1] = useTime;
					GameManager.bestStar[playLvM1,1] = starCount;
					GameManager.bestBoss[playLvM1,1] = bossCo;
					GameManager.bestLv[playLvM1,1] = staLv;
					GameManager.bestPass[playLvM1,1] = pass;
					GameManager.bestLost[playLvM1,1] = lostCount;
				}
				//比第三
				else if(staLv > GameManager.bestLv[GameManager.playingLevel-1,2]){
					GameManager.bestTime[playLvM1,2] = useTime;
					GameManager.bestStar[playLvM1,2] = starCount;
					GameManager.bestBoss[playLvM1,2] = bossCo;
					GameManager.bestLv[playLvM1,2] = staLv;
					GameManager.bestPass[playLvM1,2] = pass;
					GameManager.bestLost[playLvM1,2] = lostCount;
				}else if(staLv == GameManager.bestLv[GameManager.playingLevel-1,2]){
					//比星數
					if(starCount > GameManager.bestStar[GameManager.playingLevel-1,2]){
						GameManager.bestTime[playLvM1,2] = useTime;
						GameManager.bestStar[playLvM1,2] = starCount;
						GameManager.bestBoss[playLvM1,2] = bossCo;
						GameManager.bestLv[playLvM1,2] = staLv;
						GameManager.bestPass[playLvM1,2] = pass;
						GameManager.bestLost[playLvM1,2] = lostCount;
					}
					//比獲勝
					else if(pass && !GameManager.bestPass[GameManager.playingLevel-1,2]){
						GameManager.bestTime[playLvM1,2] = useTime;
						GameManager.bestStar[playLvM1,2] = starCount;
						GameManager.bestBoss[playLvM1,2] = bossCo;
						GameManager.bestLv[playLvM1,2] = staLv;
						GameManager.bestPass[playLvM1,2] = pass;
						GameManager.bestLost[playLvM1,2] = lostCount;
					}
					//比時間
					else if(useTime <= GameManager.bestTime[GameManager.playingLevel-1,2]){
						GameManager.bestTime[playLvM1,2] = useTime;
						GameManager.bestStar[playLvM1,2] = starCount;
						GameManager.bestBoss[playLvM1,2] = bossCo;
						GameManager.bestLv[playLvM1,2] = staLv;
						GameManager.bestPass[playLvM1,2] = pass;
						GameManager.bestLost[playLvM1,2] = lostCount;
					}
					//比遺漏
					else if(lostCount <= GameManager.bestLost[GameManager.playingLevel-1,2]){
						GameManager.bestTime[playLvM1,2] = useTime;
						GameManager.bestStar[playLvM1,2] = starCount;
						GameManager.bestBoss[playLvM1,2] = bossCo;
						GameManager.bestLv[playLvM1,2] = staLv;
						GameManager.bestPass[playLvM1,2] = pass;
						GameManager.bestLost[playLvM1,2] = lostCount;
					}
				}
			}
		}
		//比第二
		else if(staLv > GameManager.bestLv[GameManager.playingLevel-1,1]){
			GameManager.bestTime[playLvM1,2] = GameManager.bestTime[playLvM1,1];
			GameManager.bestStar[playLvM1,2] = GameManager.bestStar[playLvM1,1];
			GameManager.bestBoss[playLvM1,2] = GameManager.bestBoss[playLvM1,1];
			GameManager.bestLv[playLvM1,2] = GameManager.bestLv[playLvM1,1];
			GameManager.bestPass[playLvM1,2] = GameManager.bestPass[playLvM1,1];
			GameManager.bestLost[playLvM1,2] = GameManager.bestLost[playLvM1,1];
			
			GameManager.bestTime[playLvM1,1] = useTime;
			GameManager.bestStar[playLvM1,1] = starCount;
			GameManager.bestBoss[playLvM1,1] = bossCo;
			GameManager.bestLv[playLvM1,1] = staLv;
			GameManager.bestPass[playLvM1,1] = pass;
			GameManager.bestLost[playLvM1,1] = lostCount;
		}else if(staLv == GameManager.bestLv[GameManager.playingLevel-1,1]){
			//比星數
			if(starCount > GameManager.bestStar[GameManager.playingLevel-1,1]){
				GameManager.bestTime[playLvM1,2] = GameManager.bestTime[playLvM1,1];
				GameManager.bestStar[playLvM1,2] = GameManager.bestStar[playLvM1,1];
				GameManager.bestBoss[playLvM1,2] = GameManager.bestBoss[playLvM1,1];
				GameManager.bestLv[playLvM1,2] = GameManager.bestLv[playLvM1,1];
				GameManager.bestPass[playLvM1,2] = GameManager.bestPass[playLvM1,1];
				GameManager.bestLost[playLvM1,2] = GameManager.bestLost[playLvM1,1];
				
				GameManager.bestTime[playLvM1,1] = useTime;
				GameManager.bestStar[playLvM1,1] = starCount;
				GameManager.bestBoss[playLvM1,1] = bossCo;
				GameManager.bestLv[playLvM1,1] = staLv;
				GameManager.bestPass[playLvM1,1] = pass;
				GameManager.bestLost[playLvM1,1] = lostCount;
			}
			//比獲勝
			else if(pass && !GameManager.bestPass[GameManager.playingLevel-1,1]){
				GameManager.bestTime[playLvM1,2] = GameManager.bestTime[playLvM1,1];
				GameManager.bestStar[playLvM1,2] = GameManager.bestStar[playLvM1,1];
				GameManager.bestBoss[playLvM1,2] = GameManager.bestBoss[playLvM1,1];
				GameManager.bestLv[playLvM1,2] = GameManager.bestLv[playLvM1,1];
				GameManager.bestPass[playLvM1,2] = GameManager.bestPass[playLvM1,1];
				GameManager.bestLost[playLvM1,2] = GameManager.bestLost[playLvM1,1];
				
				GameManager.bestTime[playLvM1,1] = useTime;
				GameManager.bestStar[playLvM1,1] = starCount;
				GameManager.bestBoss[playLvM1,1] = bossCo;
				GameManager.bestLv[playLvM1,1] = staLv;
				GameManager.bestPass[playLvM1,1] = pass;
				GameManager.bestLost[playLvM1,1] = lostCount;
			}
			//比時間
			else if(useTime <= GameManager.bestTime[GameManager.playingLevel-1,1]){
				GameManager.bestTime[playLvM1,2] = GameManager.bestTime[playLvM1,1];
				GameManager.bestStar[playLvM1,2] = GameManager.bestStar[playLvM1,1];
				GameManager.bestBoss[playLvM1,2] = GameManager.bestBoss[playLvM1,1];
				GameManager.bestLv[playLvM1,2] = GameManager.bestLv[playLvM1,1];
				GameManager.bestPass[playLvM1,2] = GameManager.bestPass[playLvM1,1];
				GameManager.bestLost[playLvM1,2] = GameManager.bestLost[playLvM1,1];
				
				GameManager.bestTime[playLvM1,1] = useTime;
				GameManager.bestStar[playLvM1,1] = starCount;
				GameManager.bestBoss[playLvM1,1] = bossCo;
				GameManager.bestLv[playLvM1,1] = staLv;
				GameManager.bestPass[playLvM1,1] = pass;
				GameManager.bestLost[playLvM1,1] = lostCount;
			}
			//比遺漏
			else if(lostCount <= GameManager.bestLost[GameManager.playingLevel-1,1]){
				GameManager.bestTime[playLvM1,2] = GameManager.bestTime[playLvM1,1];
				GameManager.bestStar[playLvM1,2] = GameManager.bestStar[playLvM1,1];
				GameManager.bestBoss[playLvM1,2] = GameManager.bestBoss[playLvM1,1];
				GameManager.bestLv[playLvM1,2] = GameManager.bestLv[playLvM1,1];
				GameManager.bestPass[playLvM1,2] = GameManager.bestPass[playLvM1,1];
				GameManager.bestLost[playLvM1,2] = GameManager.bestLost[playLvM1,1];
				
				GameManager.bestTime[playLvM1,1] = useTime;
				GameManager.bestStar[playLvM1,1] = starCount;
				GameManager.bestBoss[playLvM1,1] = bossCo;
				GameManager.bestLv[playLvM1,1] = staLv;
				GameManager.bestPass[playLvM1,1] = pass;
				GameManager.bestLost[playLvM1,1] = lostCount;
			}
			//比第三
			else if(staLv > GameManager.bestLv[GameManager.playingLevel-1,2]){
				GameManager.bestTime[playLvM1,2] = useTime;
				GameManager.bestStar[playLvM1,2] = starCount;
				GameManager.bestBoss[playLvM1,2] = bossCo;
				GameManager.bestLv[playLvM1,2] = staLv;
				GameManager.bestPass[playLvM1,2] = pass;
				GameManager.bestLost[playLvM1,2] = lostCount;
			}else if(staLv == GameManager.bestLv[GameManager.playingLevel-1,2]){
				//比星數
				if(starCount > GameManager.bestStar[GameManager.playingLevel-1,2]){
					GameManager.bestTime[playLvM1,2] = useTime;
					GameManager.bestStar[playLvM1,2] = starCount;
					GameManager.bestBoss[playLvM1,2] = bossCo;
					GameManager.bestLv[playLvM1,2] = staLv;
					GameManager.bestPass[playLvM1,2] = pass;
					GameManager.bestLost[playLvM1,2] = lostCount;
				}
				//比獲勝
				else if(pass && !GameManager.bestPass[GameManager.playingLevel-1,2]){
					GameManager.bestTime[playLvM1,2] = useTime;
					GameManager.bestStar[playLvM1,2] = starCount;
					GameManager.bestBoss[playLvM1,2] = bossCo;
					GameManager.bestLv[playLvM1,2] = staLv;
					GameManager.bestPass[playLvM1,2] = pass;
					GameManager.bestLost[playLvM1,2] = lostCount;
				}
				//比時間
				else if(useTime <= GameManager.bestTime[GameManager.playingLevel-1,2]){
					GameManager.bestTime[playLvM1,2] = useTime;
					GameManager.bestStar[playLvM1,2] = starCount;
					GameManager.bestBoss[playLvM1,2] = bossCo;
					GameManager.bestLv[playLvM1,2] = staLv;
					GameManager.bestPass[playLvM1,2] = pass;
					GameManager.bestLost[playLvM1,2] = lostCount;
				}
				//比遺漏
				else if(lostCount <= GameManager.bestLost[GameManager.playingLevel-1,2]){
					GameManager.bestTime[playLvM1,2] = useTime;
					GameManager.bestStar[playLvM1,2] = starCount;
					GameManager.bestBoss[playLvM1,2] = bossCo;
					GameManager.bestLv[playLvM1,2] = staLv;
					GameManager.bestPass[playLvM1,2] = pass;
					GameManager.bestLost[playLvM1,2] = lostCount;
				}
			}
		}
		//比第三
		else if(staLv > GameManager.bestLv[GameManager.playingLevel-1,2]){
			GameManager.bestTime[playLvM1,2] = useTime;
			GameManager.bestStar[playLvM1,2] = starCount;
			GameManager.bestBoss[playLvM1,2] = bossCo;
			GameManager.bestLv[playLvM1,2] = staLv;
			GameManager.bestPass[playLvM1,2] = pass;
			GameManager.bestLost[playLvM1,2] = lostCount;
		}else if(staLv == GameManager.bestLv[GameManager.playingLevel-1,2]){
			//比星數
			if(starCount > GameManager.bestStar[GameManager.playingLevel-1,2]){
				GameManager.bestTime[playLvM1,2] = useTime;
				GameManager.bestStar[playLvM1,2] = starCount;
				GameManager.bestBoss[playLvM1,2] = bossCo;
				GameManager.bestLv[playLvM1,2] = staLv;
				GameManager.bestPass[playLvM1,2] = pass;
				GameManager.bestLost[playLvM1,2] = lostCount;
			}
			//比獲勝
			else if(pass && !GameManager.bestPass[GameManager.playingLevel-1,2]){
				GameManager.bestTime[playLvM1,2] = useTime;
				GameManager.bestStar[playLvM1,2] = starCount;
				GameManager.bestBoss[playLvM1,2] = bossCo;
				GameManager.bestLv[playLvM1,2] = staLv;
				GameManager.bestPass[playLvM1,2] = pass;
				GameManager.bestLost[playLvM1,2] = lostCount;
			}
			//比時間
			else if(useTime <= GameManager.bestTime[GameManager.playingLevel-1,2]){
				GameManager.bestTime[playLvM1,2] = useTime;
				GameManager.bestStar[playLvM1,2] = starCount;
				GameManager.bestBoss[playLvM1,2] = bossCo;
				GameManager.bestLv[playLvM1,2] = staLv;
				GameManager.bestPass[playLvM1,2] = pass;
				GameManager.bestLost[playLvM1,2] = lostCount;
			}
			//比遺漏
			else if(lostCount <= GameManager.bestLost[GameManager.playingLevel-1,2]){
				GameManager.bestTime[playLvM1,2] = useTime;
				GameManager.bestStar[playLvM1,2] = starCount;
				GameManager.bestBoss[playLvM1,2] = bossCo;
				GameManager.bestLv[playLvM1,2] = staLv;
				GameManager.bestPass[playLvM1,2] = pass;
				GameManager.bestLost[playLvM1,2] = lostCount;
			}
		}
	}
	void ClickSound(){
		AudioSource.PlayClipAtPoint (clickSE, Vector3.one);
	}
	void BuffSound(){
		AudioSource.PlayClipAtPoint(buffSE,Vector3.zero);
	}
	void MoneySE(){
		AudioSource.PlayClipAtPoint(shbuySE,Vector3.zero);
	}
	void LvUpSE(){
		AudioSource.PlayClipAtPoint(lvUpSE,Vector3.one);
	}
	//轉換滑鼠座標&世界座標
	float ToScreen(float x){
		//return (x+11.0f)*(Screen.width/22.0f); //左-11右11
		return (x+11.0f)*mesPoRate; //左-11右11
	}
}
