using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	//版本
	public static int ver = 151;
	//關卡
	public static int openLevel=1;
	public static bool[] s1BSee = new bool[]{false,false,false};
	public static bool[] s2BSee = new bool[]{false,false,false};
	public static bool[] s3BSee = new bool[]{false,false};
	public static bool[] s4BSee = new bool[]{false};
	//狀態
	public static int playerLevel=1;
	public static int playerExp=0;
	public static int playerPow=6;
	public static int playerDef=6;
	public static int playerHpL=100;
	public static int breakCnt=0;
	//技能
	public static int wearSk1=0;
	public static int wearSk2=0;
	public static int wearSk3=0;
	public static float playTime=0f;
	public static int[] skLv = new int[11];
	public static bool[] skOpen = new bool[11]{false,false,false,false,false,false,false,false,false,false,false};
	//商店
	public static int money=100; //1000
	public static int shExpLv=0;
	public static bool[] shOpen = new bool[12]{true,false,false,false,false,false,false,false,false,false,false,true};
	//聊天
	public static int chatLine=0;
	//成就計時
	public static float[,] bestTime = new float[5,3];
	public static int[,] bestStar = new int[5,3];
	public static int[,] bestBoss = new int[5,3];
	public static int[,] bestLv = new int[5,3];
	public static int[,] bestLost = new int[5,3];
	public static bool[,] bestPass = new bool[5,3];
	//成就表
	public static bool[] resGet = new bool[]{false,false,false,false,false,false,false,false,false,false};
	/****交流****/
	//關卡
	public static int playingLevel;
	
	void Start () {
	
	}
	void Update () {
	
	}

	//技能名稱
	public static string SkName(int skCo){
		if(skCo==1)
			return "商店祝福";
		else if(skCo==2)
			return "降低負擔";
		else if(skCo==3)
			return "千里肉山";
		else if(skCo==4)
			return "白球特好";
		else if(skCo==5)
			return "迴球特好";
		else if(skCo==6)
			return "直擊特好";
		else if(skCo==7)
			return "逆勢強打";
		else if(skCo==8)
			return "呼吸控制";
		else if(skCo==9)
			return "起跑戰術";
		else if(skCo==10)
			return "浪紋疾走";
		else if(skCo==11)
			return "侵蝕力量";
		else
			return "無";
	}
	//技能說明
	public static string SkHow(int skCo){
		if(skCo==1)
			return "使獲得的金錢量提高"+skLv[skCo-1]*skLv[skCo-1]+"點";
		else if(skCo==2)
			return "使受到的傷害降低"+skLv[skCo-1]+"點(最低為1)";
		else if(skCo==3)
			return "使血量提高"+skLv[skCo-1]*50+"點";
		else if(skCo==4)
			return "擊碎白球的分數增加"+skLv[skCo-1]*12+"點";
		else if(skCo==5)
			return "使返回球擊中物體的分數增加"+skLv[skCo-1]*20+"點";
		else if(skCo==6)
			return "直擊頭目的分數增加"+skLv[skCo-1]*50+"點";
		else if(skCo==7)
			return "使攻擊力提高"+skLv[skCo-1]*3+"點、防禦力降低"+skLv[skCo-1]*3+"點";
		else if(skCo==8)
			return "使增益維持時間提高"+((skLv[skCo-1]*3>300)?300:skLv[skCo-1]*3)+"%(最高為300%)";
		else if(skCo==9)
			return "關卡血量由"+((skLv[skCo-1]<10)?120*skLv[skCo-1]:240*skLv[skCo-1])+"點開始累計(最高為一半血量)";
		else if(skCo==10)
			return "使移動速度加快"+((skLv[skCo-1]*3>300)?300:skLv[skCo-1]*3)+"%(最高為300%)";
		else if(skCo==11)
			return "擊碎掉落物可使血量恢復力量的"+skLv[skCo-1]+"%(最高為100%)";
		else
			return "無";
	}
	//商品名
	public static string ShName(int shCo){
		if(shCo==1)
			return "商店祝福 Lv."+(skLv[0]+1);
		else if(shCo==2)
			return "降低負擔 Lv."+(skLv[1]+1);
		else if(shCo==3)
			return "千里肉山 Lv."+(skLv[2]+1);
		else if(shCo==4)
			return "白球特好 Lv."+(skLv[3]+1);
		else if(shCo==5)
			return "迴球特好 Lv."+(skLv[4]+1);
		else if(shCo==6)
			return "直擊特好 Lv."+(skLv[5]+1);
		else if(shCo==7)
			return "逆勢強打 Lv."+(skLv[6]+1);
		else if(shCo==8)
			return "呼吸控制 Lv."+(skLv[7]+1);
		else if(shCo==9)
			return "起跑戰術 Lv."+(skLv[8]+1);
		else if(shCo==10)
			return "浪紋疾走 Lv."+(skLv[9]+1);
		else if(shCo==11)
			return "侵蝕力量 Lv."+(skLv[10]+1);
		else if(shCo==12)
			return "經驗值 Lv."+(shExpLv+1);
		else
			return "無";
	}
	//商品價錢
	public static int ShPrice(int shCo){
		if(shCo==1)
			return (skLv[0]+1)*(skLv[0]+1)*100;
		else if(shCo==2)
			return (skLv[1]+1)*(skLv[1]+1)*80;
		else if(shCo==3)
			return (skLv[2]+1)*(skLv[2]+1)*80;
		else if(shCo==4)
			return (skLv[3]+1)*(skLv[3]+1)*50;
		else if(shCo==5)
			return (skLv[4]+1)*(skLv[4]+1)*80;
		else if(shCo==6)
			return (skLv[5]+1)*(skLv[5]+1)*70;
		else if(shCo==7)
			return (skLv[6]+1)*(skLv[6]+1)*70;
		else if(shCo==8)
			return (skLv[7]+1)*(skLv[7]+1)*100;
		else if(shCo==9)
			return (skLv[8]+1)*(skLv[8]+1)*100;
		else if(shCo==10)
			return (skLv[9]+1)*(skLv[9]+1)*70;
		else if(shCo==11)
			return (skLv[10]+1)*(skLv[10]+1)*100;
		else if(shCo==12)
			return (shExpLv+1)*(shExpLv+1)*100;
		else
			return 65534;
	}
	//商品敘述
	public static string ShHow(int shCo){
		if(shCo==1)
			return "讓\"商店祝福\"技能提升為等級"+(skLv[0]+1);
		else if(shCo==2)
			return "讓\"降低負擔\"技能提升為等級"+(skLv[1]+1);
		else if(shCo==3)
			return "讓\"千里肉山\"技能提升為等級"+(skLv[2]+1);
		else if(shCo==4)
			return "讓\"白球特好\"技能提升為等級"+(skLv[3]+1);
		else if(shCo==5)
			return "讓\"迴球特好\"技能提升為等級"+(skLv[4]+1);
		else if(shCo==6)
			return "讓\"直擊特好\"技能提升為等級"+(skLv[5]+1);
		else if(shCo==7)
			return "讓\"逆勢強打\"技能提升為等級"+(skLv[6]+1);
		else if(shCo==8)
			return "讓\"呼吸控制\"技能提升為等級"+(skLv[7]+1);
		else if(shCo==9)
			return "讓\"起跑戰術\"技能提升為等級"+(skLv[8]+1);
		else if(shCo==10)
			return "讓\"浪紋疾走\"技能提升為等級"+(skLv[9]+1);
		else if(shCo==11)
			return "讓\"侵蝕力量\"技能提升為等級"+(skLv[10]+1);
		else if(shCo==12)
			return "使角色經驗值增加"+ShPrice(12);
		else
			return "無";
	}
	//商品功能
	public static void ShAct(int shCo){
		if(shCo==1){
			if(!skOpen[0])
				skOpen[0] = true;
			skLv[0]++;
		}else if(shCo==2){
			skLv[1]++;
		}else if(shCo==3){
			skLv[2]++;
		}else if(shCo==4){
			skLv[3]++;
		}else if(shCo==5){
			skLv[4]++;
		}else if(shCo==6){
			skLv[5]++;
		}else if(shCo==7){
			skLv[6]++;
		}else if(shCo==8){
			skLv[7]++;
		}else if(shCo==9){
			skLv[8]++;
		}else if(shCo==10){
			skLv[9]++;
		}else if(shCo==11){
			skLv[10]++;
		}else if(shCo==12){
			playerExp += ShPrice(12);
			//升級
			if(playerExp >= GetExpLine()){
				LevelUp();
			}
			shExpLv++;
		}
	}
	//BOSS名子
	public static string BossName(int shCo){
		if(shCo==1)
			return "老鷹";
		else if(shCo==2)
			return "蝴蝶";
		else if(shCo==3)
			return "方塊";
		else if(shCo==4)
			return "幽靈";
		else if(shCo==5)
			return "燭台";
		else if(shCo==6)
			return "方半";
		else if(shCo==7)
			return "飛馬";
		else if(shCo==8)
			return "天球";
		else if(shCo==9)
			return "膠囊";
		else
			return "無";
	}
	//NPC名子
	public static string GetNpcName(int co){
		if(co==1)
			return "拉勇";
		else if(co==2)
			return "也也";
		else 
			return "無名氏";
	}
	//星數
	public static string Star(int grade){
		if (grade == 5)
			return "★★★★★";
		else if(grade == 4)
			return "★★★★☆";
		else if(grade == 3)
			return "★★★☆☆";
		else if(grade == 2)
			return "★★☆☆☆";
		else if(grade == 1)
			return "★☆☆☆☆";
		else
			return "☆☆☆☆☆";
	}
	//成就表
	public static string ResName(int shCo){
		if(shCo==1)
			return "向前邁進";
		else if(shCo==2)
			return "殲滅異形";
		else if(shCo==3)
			return "無形牽絆";
		else if(shCo==4)
			return "深綠的北方";
		else if(shCo==5)
			return "老舊的太古時計";
		else if(shCo==6)
			return "寂靜的星群";
		else if(shCo==7)
			return "擊落流星";
		else if(shCo==8)
			return "技能收集";
		else if(shCo==9)
			return "無限的天國";
		else if(shCo==10)
			return "感謝您的遊玩";
		else
			return "無";
	}
	//成就說明
	public static string ResHow(int shCo){
		if(shCo==1)
			return "等級提升為2";
		else if(shCo==2)
			return "成功完成關卡";
		else if(shCo==3)
			return "找別人聊天";
		else if(shCo==4)
			return "深綠的北方探索100%";
		else if(shCo==5)
			return "老舊的太古時計探索100%";
		else if(shCo==6)
			return "寂靜的星群探索100%";
		else if(shCo==7)
			return "完成Level 4.速度流動";
		else if(shCo==8)
			return "獲得所有技能";
		else if(shCo==9)
			return "無限迷宮突破Lv.100";
		else if(shCo==10)
			return "獲得所有成就";
		else
			return "無";
	}
	//成就取得提示
	public static string ResTips(int shCo){
		if(shCo==1)
			return "等級提升可以取得";
		else if(shCo==2)
			return "完成關卡可以取得";
		else if(shCo==3)
			return "聊天中取得";
		else if(shCo==4)
			return "提高關卡探索率取得";
		else if(shCo==5)
			return "提高關卡探索率取得";
		else if(shCo==6)
			return "提高關卡探索率取得";
		else if(shCo==7)
			return "完成關卡可以取得";
		else if(shCo==8)
			return "獲得所有技能後取得";
		else if(shCo==9)
			return "無限迷宮爬到一定程度後取得";
		else if(shCo==10)
			return "遊戲進度99%時取得";
		else
			return "無";
	}
	//成就獎勵
	public static int ResBackMoney(int shCo){
		int rtn;
		if(shCo==1)
			rtn = 2000;
		else if(shCo==2)
			rtn = 15000;
		else if(shCo==3)
			rtn = 5000;
		else if(shCo==4)
			rtn = 200000;
		else if(shCo==5)
			rtn = 250000;
		else if(shCo==6)
			rtn = 300000;
		else if(shCo==7)
			rtn = 1000000;
		else if(shCo==8)
			rtn = 5000000;
		else if(shCo==9)
			rtn = 10000000;
		else if(shCo==10)
			rtn = 10000000;
		else
			rtn = 0;
		if (wearSk1 == 1 || wearSk2 == 1 || wearSk3 == 1) {
			//sk商店祝福
			rtn += GameManager.skLv[0]*GameManager.skLv[0];
		}

		return rtn;
	}
	//關卡等級
	public static int StaLevel(int co){
		if (co == 0)
			return playerLevel;
		else if(co == 1){ //第一關
			//if(openLevel>1) //已破
			//	return (playerLevel>5)?playerLevel:5;
			//else
				return 5;
		}else if(co == 2){
			//if(openLevel>2)
			//	return (playerLevel>15)?playerLevel:15;
			//else
				return 15;
		}else if(co == 3){
			//if(openLevel>3)
			//	return (playerLevel>25)?playerLevel:25;
			//else
				return 25;
		}else if(co == 4){
			//if(openLevel>4)
			//	return (playerLevel>40)?playerLevel:40;
			//else
				return 40;
		}else if(co == 5){ //無限迷宮
			return (playerLevel>50)?playerLevel:50;
		}else
			return 0;
	}
	//關卡探索度
	public static string StaFinBosPa(int co){
		int count = 0;
		if(co == 1){ //第一關
			if(s1BSee[0])
				count++;
			if(s1BSee[1])
				count++;
			if(s1BSee[2])
				count++;
			return (count==3)?"100%":
				((count==2)?"66%":
				((count==1)?"33%":"0%"));
		}else if(co == 2){
			if(s2BSee[0])
				count++;
			if(s2BSee[1])
				count++;
			if(s2BSee[2])
				count++;
			return (count==3)?"100%":
				((count==2)?"66%":
				((count==1)?"33%":"0%"));
		}else if(co == 3){
			if(s3BSee[0])
				count++;
			if(s3BSee[1])
				count++;
			return (count==2)?"100%":
				((count==1)?"50%":"0%");
		}else if(co == 4){
			if(s4BSee[0])
				count++;
			return (count==1)?"100%":"0%";
		}else if(co == 5){ //無限迷宮
			if(bestPass[4,0])
				return "至Lv."+bestLv[4,0];
			else
				return "???%";
		}else
			return "";
	}
	//扣血公式
	public static int GetMinusHp(int level){
		int rtn = level * 4 - GetPlayerDef();
		if (wearSk1 == 2 || wearSk2 == 2 || wearSk3 == 2) {
			//sk降低負擔
			rtn -= skLv[1];
		}
		if(rtn<1)
			rtn = 1;
		return rtn;
	}
	public static int GetAddHp(){
		return GetPlayerAtk();
	}
	//取得關卡血量
	public static int GetLevelHp(int level){
		return 360+500*(level-1);
	}
	//升級
	public static void LevelUp(){
		playerLevel++;
		playerExp = 0;
		playerPow += 2;
		playerDef += 2;
		playerHpL += 150;
	}
	//經驗上限
	public static int GetExpLine(){
		return playerLevel * playerLevel * playerLevel * 10;
	}
	//關卡名稱
	public static string GetLevelName(int level){
		if(level == 0)
			return "遊戲教學 & 暖身關卡";
		else if(level == 1)
			return "Level 1.深綠的北方";
		else if(level == 2)
			return "Level 2.老舊的太古時計";
		else if(level == 3)
			return "Level 3.寂靜的星群";
		else if(level == 4)
			return "Level 4.速度流動";
		else if(level == 5)
			return "Level Y.無限迷宮";
		else
			return "";
	}
	//存檔
	public static void Save(){
		//版本
		PlayerPrefs.SetInt ("ver", ver);
		//關卡
		PlayerPrefs.SetInt ("openLevel", openLevel);
		PlayerPrefs.SetInt ("s1BSee[0]", ((s1BSee [0]) ? 1 : 0));
		PlayerPrefs.SetInt ("s1BSee[1]", ((s1BSee [1]) ? 1 : 0));
		PlayerPrefs.SetInt ("s1BSee[2]", ((s1BSee [2]) ? 1 : 0));
		PlayerPrefs.SetInt ("s2BSee[0]", ((s2BSee [0]) ? 1 : 0));
		PlayerPrefs.SetInt ("s2BSee[1]", ((s2BSee [1]) ? 1 : 0));
		PlayerPrefs.SetInt ("s2BSee[2]", ((s2BSee [2]) ? 1 : 0));
		PlayerPrefs.SetInt ("s3BSee[0]", ((s3BSee [0]) ? 1 : 0));
		PlayerPrefs.SetInt ("s3BSee[1]", ((s3BSee [1]) ? 1 : 0));
		PlayerPrefs.SetInt ("s4BSee[0]", ((s4BSee [0]) ? 1 : 0));
		//狀態
		PlayerPrefs.SetInt ("playerLevel", playerLevel);
		PlayerPrefs.SetInt ("playerExp", playerExp);
		PlayerPrefs.SetInt ("playerPow", playerPow);
		PlayerPrefs.SetInt ("playerDef", playerDef);
		PlayerPrefs.SetInt ("playerHpL", playerHpL);
		PlayerPrefs.SetInt ("breakCnt", breakCnt);
		//技能
		PlayerPrefs.SetInt ("wearSk1", wearSk1);
		PlayerPrefs.SetInt ("wearSk2", wearSk2);
		PlayerPrefs.SetInt ("wearSk3", wearSk3);
		PlayerPrefs.SetFloat ("playTime", playTime);

		PlayerPrefs.SetInt ("skLv[0]", skLv [0]);
		PlayerPrefs.SetInt ("skLv[1]", skLv [1]);
		PlayerPrefs.SetInt ("skLv[2]", skLv [2]);
		PlayerPrefs.SetInt ("skLv[3]", skLv [3]);
		PlayerPrefs.SetInt ("skLv[4]", skLv [4]);
		PlayerPrefs.SetInt ("skLv[5]", skLv [5]);
		PlayerPrefs.SetInt ("skLv[6]", skLv [6]);
		PlayerPrefs.SetInt ("skLv[7]", skLv [7]);
		PlayerPrefs.SetInt ("skLv[8]", skLv [8]);
		PlayerPrefs.SetInt ("skLv[9]", skLv [9]);
		PlayerPrefs.SetInt ("skLv[10]", skLv [10]);

		PlayerPrefs.SetInt ("skOpen[0]", ((skOpen [0]) ? 1 : 0));
		PlayerPrefs.SetInt ("skOpen[1]", ((skOpen [1]) ? 1 : 0));
		PlayerPrefs.SetInt ("skOpen[2]", ((skOpen [2]) ? 1 : 0));
		PlayerPrefs.SetInt ("skOpen[3]", ((skOpen [3]) ? 1 : 0));
		PlayerPrefs.SetInt ("skOpen[4]", ((skOpen [4]) ? 1 : 0));
		PlayerPrefs.SetInt ("skOpen[5]", ((skOpen [5]) ? 1 : 0));
		PlayerPrefs.SetInt ("skOpen[6]", ((skOpen [6]) ? 1 : 0));
		PlayerPrefs.SetInt ("skOpen[7]", ((skOpen [7]) ? 1 : 0));
		PlayerPrefs.SetInt ("skOpen[8]", ((skOpen [8]) ? 1 : 0));
		PlayerPrefs.SetInt ("skOpen[9]", ((skOpen [9]) ? 1 : 0));
		PlayerPrefs.SetInt ("skOpen[10]", ((skOpen [10]) ? 1 : 0));
		//商店
		PlayerPrefs.SetInt ("money", money);
		PlayerPrefs.SetInt ("shExpLv", shExpLv);

		PlayerPrefs.SetInt ("shOpen[1]", ((shOpen [1]) ? 1 : 0));
		PlayerPrefs.SetInt ("shOpen[2]", ((shOpen [2]) ? 1 : 0));
		PlayerPrefs.SetInt ("shOpen[3]", ((shOpen [3]) ? 1 : 0));
		PlayerPrefs.SetInt ("shOpen[4]", ((shOpen [4]) ? 1 : 0));
		PlayerPrefs.SetInt ("shOpen[5]", ((shOpen [5]) ? 1 : 0));
		PlayerPrefs.SetInt ("shOpen[6]", ((shOpen [6]) ? 1 : 0));
		PlayerPrefs.SetInt ("shOpen[7]", ((shOpen [7]) ? 1 : 0));
		PlayerPrefs.SetInt ("shOpen[8]", ((shOpen [8]) ? 1 : 0));
		PlayerPrefs.SetInt ("shOpen[9]", ((shOpen [9]) ? 1 : 0));
		PlayerPrefs.SetInt ("shOpen[10]", ((shOpen [10]) ? 1 : 0));
		//聊天
		PlayerPrefs.SetInt ("chatLine", chatLine);
		//成就計時
		PlayerPrefs.SetFloat ("bestTime[0,0]", bestTime[0,0]);
		PlayerPrefs.SetFloat ("bestTime[0,1]", bestTime[0,1]);
		PlayerPrefs.SetFloat ("bestTime[0,2]", bestTime[0,2]);
		PlayerPrefs.SetFloat ("bestTime[1,0]", bestTime[1,0]);
		PlayerPrefs.SetFloat ("bestTime[1,1]", bestTime[1,1]);
		PlayerPrefs.SetFloat ("bestTime[1,2]", bestTime[1,2]);
		PlayerPrefs.SetFloat ("bestTime[2,0]", bestTime[2,0]);
		PlayerPrefs.SetFloat ("bestTime[2,1]", bestTime[2,1]);
		PlayerPrefs.SetFloat ("bestTime[2,2]", bestTime[2,2]);
		PlayerPrefs.SetFloat ("bestTime[3,0]", bestTime[3,0]);
		PlayerPrefs.SetFloat ("bestTime[3,1]", bestTime[3,1]);
		PlayerPrefs.SetFloat ("bestTime[3,2]", bestTime[3,2]);
		PlayerPrefs.SetFloat ("bestTime[4,0]", bestTime[4,0]);
		PlayerPrefs.SetFloat ("bestTime[4,1]", bestTime[4,1]);
		PlayerPrefs.SetFloat ("bestTime[4,2]", bestTime[4,2]);

		PlayerPrefs.SetInt ("bestStar[0,0]", bestStar[0,0]);
		PlayerPrefs.SetInt ("bestStar[0,1]", bestStar[0,1]);
		PlayerPrefs.SetInt ("bestStar[0,2]", bestStar[0,2]);
		PlayerPrefs.SetInt ("bestStar[1,0]", bestStar[1,0]);
		PlayerPrefs.SetInt ("bestStar[1,1]", bestStar[1,1]);
		PlayerPrefs.SetInt ("bestStar[1,2]", bestStar[1,2]);
		PlayerPrefs.SetInt ("bestStar[2,0]", bestStar[2,0]);
		PlayerPrefs.SetInt ("bestStar[2,1]", bestStar[2,1]);
		PlayerPrefs.SetInt ("bestStar[2,2]", bestStar[2,2]);
		PlayerPrefs.SetInt ("bestStar[3,0]", bestStar[3,0]);
		PlayerPrefs.SetInt ("bestStar[3,1]", bestStar[3,1]);
		PlayerPrefs.SetInt ("bestStar[3,2]", bestStar[3,2]);
		PlayerPrefs.SetInt ("bestStar[4,0]", bestStar[4,0]);
		PlayerPrefs.SetInt ("bestStar[4,1]", bestStar[4,1]);
		PlayerPrefs.SetInt ("bestStar[4,2]", bestStar[4,2]);

		PlayerPrefs.SetInt ("bestBoss[0,0]", bestBoss[0,0]);
		PlayerPrefs.SetInt ("bestBoss[0,1]", bestBoss[0,1]);
		PlayerPrefs.SetInt ("bestBoss[0,2]", bestBoss[0,2]);
		PlayerPrefs.SetInt ("bestBoss[1,0]", bestBoss[1,0]);
		PlayerPrefs.SetInt ("bestBoss[1,1]", bestBoss[1,1]);
		PlayerPrefs.SetInt ("bestBoss[1,2]", bestBoss[1,2]);
		PlayerPrefs.SetInt ("bestBoss[2,0]", bestBoss[2,0]);
		PlayerPrefs.SetInt ("bestBoss[2,1]", bestBoss[2,1]);
		PlayerPrefs.SetInt ("bestBoss[2,2]", bestBoss[2,2]);
		PlayerPrefs.SetInt ("bestBoss[3,0]", bestBoss[3,0]);
		PlayerPrefs.SetInt ("bestBoss[3,1]", bestBoss[3,1]);
		PlayerPrefs.SetInt ("bestBoss[3,2]", bestBoss[3,2]);
		PlayerPrefs.SetInt ("bestBoss[4,0]", bestBoss[4,0]);
		PlayerPrefs.SetInt ("bestBoss[4,1]", bestBoss[4,1]);
		PlayerPrefs.SetInt ("bestBoss[4,2]", bestBoss[4,2]);

		PlayerPrefs.SetInt ("bestLv[0,0]", bestLv[0,0]);
		PlayerPrefs.SetInt ("bestLv[0,1]", bestLv[0,1]);
		PlayerPrefs.SetInt ("bestLv[0,2]", bestLv[0,2]);
		PlayerPrefs.SetInt ("bestLv[1,0]", bestLv[1,0]);
		PlayerPrefs.SetInt ("bestLv[1,1]", bestLv[1,1]);
		PlayerPrefs.SetInt ("bestLv[1,2]", bestLv[1,2]);
		PlayerPrefs.SetInt ("bestLv[2,0]", bestLv[2,0]);
		PlayerPrefs.SetInt ("bestLv[2,1]", bestLv[2,1]);
		PlayerPrefs.SetInt ("bestLv[2,2]", bestLv[2,2]);
		PlayerPrefs.SetInt ("bestLv[3,0]", bestLv[3,0]);
		PlayerPrefs.SetInt ("bestLv[3,1]", bestLv[3,1]);
		PlayerPrefs.SetInt ("bestLv[3,2]", bestLv[3,2]);
		PlayerPrefs.SetInt ("bestLv[4,0]", bestLv[4,0]);
		PlayerPrefs.SetInt ("bestLv[4,1]", bestLv[4,1]);
		PlayerPrefs.SetInt ("bestLv[4,2]", bestLv[4,2]);

		PlayerPrefs.SetInt ("bestPass[0,0]", ((bestPass [0, 0]) ? 1 : 0));
		PlayerPrefs.SetInt ("bestPass[0,1]", ((bestPass [0, 1]) ? 1 : 0));
		PlayerPrefs.SetInt ("bestPass[0,2]", ((bestPass [0, 2]) ? 1 : 0));
		PlayerPrefs.SetInt ("bestPass[1,0]", ((bestPass [1, 0]) ? 1 : 0));
		PlayerPrefs.SetInt ("bestPass[1,1]", ((bestPass [1, 1]) ? 1 : 0));
		PlayerPrefs.SetInt ("bestPass[1,2]", ((bestPass [1, 2]) ? 1 : 0));
		PlayerPrefs.SetInt ("bestPass[2,0]", ((bestPass [2, 0]) ? 1 : 0));
		PlayerPrefs.SetInt ("bestPass[2,1]", ((bestPass [2, 1]) ? 1 : 0));
		PlayerPrefs.SetInt ("bestPass[2,2]", ((bestPass [2, 2]) ? 1 : 0));
		PlayerPrefs.SetInt ("bestPass[3,0]", ((bestPass [3, 0]) ? 1 : 0));
		PlayerPrefs.SetInt ("bestPass[3,1]", ((bestPass [3, 1]) ? 1 : 0));
		PlayerPrefs.SetInt ("bestPass[3,2]", ((bestPass [3, 2]) ? 1 : 0));
		PlayerPrefs.SetInt ("bestPass[4,0]", ((bestPass [4, 0]) ? 1 : 0));
		PlayerPrefs.SetInt ("bestPass[4,1]", ((bestPass [4, 1]) ? 1 : 0));
		PlayerPrefs.SetInt ("bestPass[4,2]", ((bestPass [4, 2]) ? 1 : 0));

		PlayerPrefs.SetInt ("bestLost[0,0]", bestLost[0,0]);
		PlayerPrefs.SetInt ("bestLost[0,1]", bestLost[0,1]);
		PlayerPrefs.SetInt ("bestLost[0,2]", bestLost[0,2]);
		PlayerPrefs.SetInt ("bestLost[1,0]", bestLost[1,0]);
		PlayerPrefs.SetInt ("bestLost[1,1]", bestLost[1,1]);
		PlayerPrefs.SetInt ("bestLost[1,2]", bestLost[1,2]);
		PlayerPrefs.SetInt ("bestLost[2,0]", bestLost[2,0]);
		PlayerPrefs.SetInt ("bestLost[2,1]", bestLost[2,1]);
		PlayerPrefs.SetInt ("bestLost[2,2]", bestLost[2,2]);
		PlayerPrefs.SetInt ("bestLost[3,0]", bestLost[3,0]);
		PlayerPrefs.SetInt ("bestLost[3,1]", bestLost[3,1]);
		PlayerPrefs.SetInt ("bestLost[3,2]", bestLost[3,2]);
		PlayerPrefs.SetInt ("bestLost[4,0]", bestLost[4,0]);
		PlayerPrefs.SetInt ("bestLost[4,1]", bestLost[4,1]);
		PlayerPrefs.SetInt ("bestLost[4,2]", bestLost[4,2]);
		//成就表
		PlayerPrefs.SetInt ("resGet[0]", ((resGet [0]) ? 1 : 0));
		PlayerPrefs.SetInt ("resGet[1]", ((resGet [1]) ? 1 : 0));
		PlayerPrefs.SetInt ("resGet[2]", ((resGet [2]) ? 1 : 0));
		PlayerPrefs.SetInt ("resGet[3]", ((resGet [3]) ? 1 : 0));
		PlayerPrefs.SetInt ("resGet[4]", ((resGet [4]) ? 1 : 0));
		PlayerPrefs.SetInt ("resGet[5]", ((resGet [5]) ? 1 : 0));
		PlayerPrefs.SetInt ("resGet[6]", ((resGet [6]) ? 1 : 0));
		PlayerPrefs.SetInt ("resGet[7]", ((resGet [7]) ? 1 : 0));
		PlayerPrefs.SetInt ("resGet[8]", ((resGet [8]) ? 1 : 0));
		PlayerPrefs.SetInt ("resGet[9]", ((resGet [9]) ? 1 : 0));

		PlayerPrefs.Save ();
	}
	//讀檔
	public static void Load(){
		//關卡
		openLevel = PlayerPrefs.GetInt("openLevel");
		s1BSee [0] = ((PlayerPrefs.GetInt ("s1BSee[0]") == 1) ? true : false);
		s1BSee [1] = ((PlayerPrefs.GetInt ("s1BSee[1]") == 1) ? true : false);
		s1BSee [2] = ((PlayerPrefs.GetInt ("s1BSee[2]") == 1) ? true : false);
		s2BSee [0] = ((PlayerPrefs.GetInt ("s2BSee[0]") == 1) ? true : false);
		s2BSee [1] = ((PlayerPrefs.GetInt ("s2BSee[1]") == 1) ? true : false);
		s2BSee [2] = ((PlayerPrefs.GetInt ("s2BSee[2]") == 1) ? true : false);
		s3BSee [0] = ((PlayerPrefs.GetInt ("s3BSee[0]") == 1) ? true : false);
		s3BSee [1] = ((PlayerPrefs.GetInt ("s3BSee[1]") == 1) ? true : false);
		s4BSee [0] = ((PlayerPrefs.GetInt ("s4BSee[0]") == 1) ? true : false);
		//狀態
		playerLevel = PlayerPrefs.GetInt("playerLevel");
		playerExp = PlayerPrefs.GetInt("playerExp");
		playerPow = PlayerPrefs.GetInt("playerPow");
		playerDef = PlayerPrefs.GetInt("playerDef");
		playerHpL = PlayerPrefs.GetInt("playerHpL");
		breakCnt = PlayerPrefs.GetInt("breakCnt");
		//技能
		wearSk1 = PlayerPrefs.GetInt("wearSk1");
		wearSk2 = PlayerPrefs.GetInt("wearSk2");
		wearSk3 = PlayerPrefs.GetInt("wearSk3");
		playTime = PlayerPrefs.GetFloat("playTime");

		skLv[0] = PlayerPrefs.GetInt("skLv[0]");
		skLv[1] = PlayerPrefs.GetInt("skLv[1]");
		skLv[2] = PlayerPrefs.GetInt("skLv[2]");
		skLv[3] = PlayerPrefs.GetInt("skLv[3]");
		skLv[4] = PlayerPrefs.GetInt("skLv[4]");
		skLv[5] = PlayerPrefs.GetInt("skLv[5]");
		skLv[6] = PlayerPrefs.GetInt("skLv[6]");
		skLv[7] = PlayerPrefs.GetInt("skLv[7]");
		skLv[8] = PlayerPrefs.GetInt("skLv[8]");
		skLv[9] = PlayerPrefs.GetInt("skLv[9]");
		skLv[10] = PlayerPrefs.GetInt("skLv[10]");

		skOpen [0] = ((PlayerPrefs.GetInt ("skOpen[0]") == 1) ? true : false);
		skOpen [1] = ((PlayerPrefs.GetInt ("skOpen[1]") == 1) ? true : false);
		skOpen [2] = ((PlayerPrefs.GetInt ("skOpen[2]") == 1) ? true : false);
		skOpen [3] = ((PlayerPrefs.GetInt ("skOpen[3]") == 1) ? true : false);
		skOpen [4] = ((PlayerPrefs.GetInt ("skOpen[4]") == 1) ? true : false);
		skOpen [5] = ((PlayerPrefs.GetInt ("skOpen[5]") == 1) ? true : false);
		skOpen [6] = ((PlayerPrefs.GetInt ("skOpen[6]") == 1) ? true : false);
		skOpen [7] = ((PlayerPrefs.GetInt ("skOpen[7]") == 1) ? true : false);
		skOpen [8] = ((PlayerPrefs.GetInt ("skOpen[8]") == 1) ? true : false);
		skOpen [9] = ((PlayerPrefs.GetInt ("skOpen[9]") == 1) ? true : false);
		skOpen [10] = ((PlayerPrefs.GetInt ("skOpen[10]") == 1) ? true : false);
		//商店
		money = PlayerPrefs.GetInt("money");
		shExpLv = PlayerPrefs.GetInt("shExpLv");

		shOpen [1] = ((PlayerPrefs.GetInt ("shOpen[1]") == 1) ? true : false);
		shOpen [2] = ((PlayerPrefs.GetInt ("shOpen[2]") == 1) ? true : false);
		shOpen [3] = ((PlayerPrefs.GetInt ("shOpen[3]") == 1) ? true : false);
		shOpen [4] = ((PlayerPrefs.GetInt ("shOpen[4]") == 1) ? true : false);
		shOpen [5] = ((PlayerPrefs.GetInt ("shOpen[5]") == 1) ? true : false);
		shOpen [6] = ((PlayerPrefs.GetInt ("shOpen[6]") == 1) ? true : false);
		shOpen [7] = ((PlayerPrefs.GetInt ("shOpen[7]") == 1) ? true : false);
		shOpen [8] = ((PlayerPrefs.GetInt ("shOpen[8]") == 1) ? true : false);
		shOpen [9] = ((PlayerPrefs.GetInt ("shOpen[9]") == 1) ? true : false);
		shOpen [10] = ((PlayerPrefs.GetInt ("shOpen[10]") == 1) ? true : false);
		//聊天
		chatLine = PlayerPrefs.GetInt("chatLine");
		//成就計時
		bestTime [0, 0] = PlayerPrefs.GetFloat ("bestTime[0,0]");
		bestTime [0, 1] = PlayerPrefs.GetFloat ("bestTime[0,1]");
		bestTime [0, 2] = PlayerPrefs.GetFloat ("bestTime[0,2]");
		bestTime [1, 0] = PlayerPrefs.GetFloat ("bestTime[1,0]");
		bestTime [1, 1] = PlayerPrefs.GetFloat ("bestTime[1,1]");
		bestTime [1, 2] = PlayerPrefs.GetFloat ("bestTime[1,2]");
		bestTime [2, 0] = PlayerPrefs.GetFloat ("bestTime[2,0]");
		bestTime [2, 1] = PlayerPrefs.GetFloat ("bestTime[2,1]");
		bestTime [2, 2] = PlayerPrefs.GetFloat ("bestTime[2,2]");
		bestTime [3, 0] = PlayerPrefs.GetFloat ("bestTime[3,0]");
		bestTime [3, 1] = PlayerPrefs.GetFloat ("bestTime[3,1]");
		bestTime [3, 2] = PlayerPrefs.GetFloat ("bestTime[3,2]");
		bestTime [4, 0] = PlayerPrefs.GetFloat ("bestTime[4,0]");
		bestTime [4, 1] = PlayerPrefs.GetFloat ("bestTime[4,1]");
		bestTime [4, 2] = PlayerPrefs.GetFloat ("bestTime[4,2]");

		bestStar [0, 0] = PlayerPrefs.GetInt ("bestStar[0,0]");
		bestStar [0, 1] = PlayerPrefs.GetInt ("bestStar[0,1]");
		bestStar [0, 2] = PlayerPrefs.GetInt ("bestStar[0,2]");
		bestStar [1, 0] = PlayerPrefs.GetInt ("bestStar[1,0]");
		bestStar [1, 1] = PlayerPrefs.GetInt ("bestStar[1,1]");
		bestStar [1, 2] = PlayerPrefs.GetInt ("bestStar[1,2]");
		bestStar [2, 0] = PlayerPrefs.GetInt ("bestStar[2,0]");
		bestStar [2, 1] = PlayerPrefs.GetInt ("bestStar[2,1]");
		bestStar [2, 2] = PlayerPrefs.GetInt ("bestStar[2,2]");
		bestStar [3, 0] = PlayerPrefs.GetInt ("bestStar[3,0]");
		bestStar [3, 1] = PlayerPrefs.GetInt ("bestStar[3,1]");
		bestStar [3, 2] = PlayerPrefs.GetInt ("bestStar[3,2]");
		bestStar [4, 0] = PlayerPrefs.GetInt ("bestStar[4,0]");
		bestStar [4, 1] = PlayerPrefs.GetInt ("bestStar[4,1]");
		bestStar [4, 2] = PlayerPrefs.GetInt ("bestStar[4,2]");

		bestBoss [0, 0] = PlayerPrefs.GetInt ("bestBoss[0,0]");
		bestBoss [0, 1] = PlayerPrefs.GetInt ("bestBoss[0,1]");
		bestBoss [0, 2] = PlayerPrefs.GetInt ("bestBoss[0,2]");
		bestBoss [1, 0] = PlayerPrefs.GetInt ("bestBoss[1,0]");
		bestBoss [1, 1] = PlayerPrefs.GetInt ("bestBoss[1,1]");
		bestBoss [1, 2] = PlayerPrefs.GetInt ("bestBoss[1,2]");
		bestBoss [2, 0] = PlayerPrefs.GetInt ("bestBoss[2,0]");
		bestBoss [2, 1] = PlayerPrefs.GetInt ("bestBoss[2,1]");
		bestBoss [2, 2] = PlayerPrefs.GetInt ("bestBoss[2,2]");
		bestBoss [3, 0] = PlayerPrefs.GetInt ("bestBoss[3,0]");
		bestBoss [3, 1] = PlayerPrefs.GetInt ("bestBoss[3,1]");
		bestBoss [3, 2] = PlayerPrefs.GetInt ("bestBoss[3,2]");
		bestBoss [4, 0] = PlayerPrefs.GetInt ("bestBoss[4,0]");
		bestBoss [4, 1] = PlayerPrefs.GetInt ("bestBoss[4,1]");
		bestBoss [4, 2] = PlayerPrefs.GetInt ("bestBoss[4,2]");

		bestLv [0, 0] = PlayerPrefs.GetInt ("bestLv[0,0]");
		bestLv [0, 1] = PlayerPrefs.GetInt ("bestLv[0,1]");
		bestLv [0, 2] = PlayerPrefs.GetInt ("bestLv[0,2]");
		bestLv [1, 0] = PlayerPrefs.GetInt ("bestLv[1,0]");
		bestLv [1, 1] = PlayerPrefs.GetInt ("bestLv[1,1]");
		bestLv [1, 2] = PlayerPrefs.GetInt ("bestLv[1,2]");
		bestLv [2, 0] = PlayerPrefs.GetInt ("bestLv[2,0]");
		bestLv [2, 1] = PlayerPrefs.GetInt ("bestLv[2,1]");
		bestLv [2, 2] = PlayerPrefs.GetInt ("bestLv[2,2]");
		bestLv [3, 0] = PlayerPrefs.GetInt ("bestLv[3,0]");
		bestLv [3, 1] = PlayerPrefs.GetInt ("bestLv[3,1]");
		bestLv [3, 2] = PlayerPrefs.GetInt ("bestLv[3,2]");
		bestLv [4, 0] = PlayerPrefs.GetInt ("bestLv[4,0]");
		bestLv [4, 1] = PlayerPrefs.GetInt ("bestLv[4,1]");
		bestLv [4, 2] = PlayerPrefs.GetInt ("bestLv[4,2]");

		bestPass[0,0] = ((PlayerPrefs.GetInt ("bestPass[0,0]") == 1) ? true : false);
		bestPass[0,1] = ((PlayerPrefs.GetInt ("bestPass[0,1]") == 1) ? true : false);
		bestPass[0,2] = ((PlayerPrefs.GetInt ("bestPass[0,2]") == 1) ? true : false);
		bestPass[1,0] = ((PlayerPrefs.GetInt ("bestPass[1,0]") == 1) ? true : false);
		bestPass[1,1] = ((PlayerPrefs.GetInt ("bestPass[1,1]") == 1) ? true : false);
		bestPass[1,2] = ((PlayerPrefs.GetInt ("bestPass[1,2]") == 1) ? true : false);
		bestPass[2,0] = ((PlayerPrefs.GetInt ("bestPass[2,0]") == 1) ? true : false);
		bestPass[2,1] = ((PlayerPrefs.GetInt ("bestPass[2,1]") == 1) ? true : false);
		bestPass[2,2] = ((PlayerPrefs.GetInt ("bestPass[2,2]") == 1) ? true : false);
		bestPass[3,0] = ((PlayerPrefs.GetInt ("bestPass[3,0]") == 1) ? true : false);
		bestPass[3,1] = ((PlayerPrefs.GetInt ("bestPass[3,1]") == 1) ? true : false);
		bestPass[3,2] = ((PlayerPrefs.GetInt ("bestPass[3,2]") == 1) ? true : false);
		bestPass[4,0] = ((PlayerPrefs.GetInt ("bestPass[4,0]") == 1) ? true : false);
		bestPass[4,1] = ((PlayerPrefs.GetInt ("bestPass[4,1]") == 1) ? true : false);
		bestPass[4,2] = ((PlayerPrefs.GetInt ("bestPass[4,2]") == 1) ? true : false);

		bestLost [0, 0] = PlayerPrefs.GetInt ("bestLost[0,0]");
		bestLost [0, 1] = PlayerPrefs.GetInt ("bestLost[0,1]");
		bestLost [0, 2] = PlayerPrefs.GetInt ("bestLost[0,2]");
		bestLost [1, 0] = PlayerPrefs.GetInt ("bestLost[1,0]");
		bestLost [1, 1] = PlayerPrefs.GetInt ("bestLost[1,1]");
		bestLost [1, 2] = PlayerPrefs.GetInt ("bestLost[1,2]");
		bestLost [2, 0] = PlayerPrefs.GetInt ("bestLost[2,0]");
		bestLost [2, 1] = PlayerPrefs.GetInt ("bestLost[2,1]");
		bestLost [2, 2] = PlayerPrefs.GetInt ("bestLost[2,2]");
		bestLost [3, 0] = PlayerPrefs.GetInt ("bestLost[3,0]");
		bestLost [3, 1] = PlayerPrefs.GetInt ("bestLost[3,1]");
		bestLost [3, 2] = PlayerPrefs.GetInt ("bestLost[3,2]");
		bestLost [4, 0] = PlayerPrefs.GetInt ("bestLost[4,0]");
		bestLost [4, 1] = PlayerPrefs.GetInt ("bestLost[4,1]");
		bestLost [4, 2] = PlayerPrefs.GetInt ("bestLost[4,2]");
		//成就表
		resGet [0] = ((PlayerPrefs.GetInt ("resGet[0]") == 1) ? true : false);
		resGet [1] = ((PlayerPrefs.GetInt ("resGet[1]") == 1) ? true : false);
		resGet [2] = ((PlayerPrefs.GetInt ("resGet[2]") == 1) ? true : false);
		resGet [3] = ((PlayerPrefs.GetInt ("resGet[3]") == 1) ? true : false);
		resGet [4] = ((PlayerPrefs.GetInt ("resGet[4]") == 1) ? true : false);
		resGet [5] = ((PlayerPrefs.GetInt ("resGet[5]") == 1) ? true : false);
		resGet [6] = ((PlayerPrefs.GetInt ("resGet[6]") == 1) ? true : false);
		resGet [7] = ((PlayerPrefs.GetInt ("resGet[7]") == 1) ? true : false);
		resGet [8] = ((PlayerPrefs.GetInt ("resGet[8]") == 1) ? true : false);
		resGet [9] = ((PlayerPrefs.GetInt ("resGet[9]") == 1) ? true : false);
	}
	//取得自己血量上限
	public static int GetMineHpL(){
		int rtn = playerHpL;
		if (wearSk1 == 3 || wearSk2 == 3 || wearSk3 == 3) {
			//sk千里肉山
			rtn += skLv[2]*50;
		}
		return rtn;
	}
	//攻擊力
	public static int GetPlayerAtk(){
		int rtn = playerPow;
		if (wearSk1 == 7 || wearSk2 == 7 || wearSk3 == 7) {
			//sk逆勢強打
			rtn += skLv[6]*3;
		}
		return rtn;
	}
	//防禦力
	public static int GetPlayerDef(){
		int rtn = playerDef;
		if (wearSk1 == 7 || wearSk2 == 7 || wearSk3 == 7) {
			//sk逆勢強打
			rtn -= skLv[6]*3;
		}
		if(rtn < 0)
			rtn = 0;
		return rtn;
	}
}
