using UnityEngine;
using System.Collections;

public class BossRotate : MonoBehaviour {
	int co,changeFlag;
	float tmpY,timer;

	void Start () {
		if (this.name == "S1Square")
			co = 1;
		else if(this.name == "S2Candle" || this.name == "S2SquareF")
			co = 2;
		else if(this.name == "S2Ghost"){
			co = 3;
			this.transform.GetChild(0).GetChild(1).renderer.material.color = new Color(this.transform.GetChild(0).GetChild(1).renderer.material.color.r,this.transform.GetChild(0).GetChild(1).renderer.material.color.g,this.transform.GetChild(0).GetChild(1).renderer.material.color.b,0.5f);
		}else if(this.name == "S3SkyBall"){
			this.renderer.material.color = new Color(0f,0.8f,0f);
		}else if(this.name == "S4Capsule"){
			co = 4;
		}
	}

	void Update () {
		if(co == 1){
			this.transform.Rotate (1, 2, 3);
		}else if(co == 2){
			this.transform.localEulerAngles = Vector3.Lerp(this.transform.localEulerAngles,new Vector3(this.transform.localEulerAngles.x,tmpY,this.transform.localEulerAngles.z),0.1f);
			if((timer -= 0.02f)<0){
				timer = 3f;
				tmpY = Random.Range(-30f,60f);
			}
		}else if(co == 3){
			this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(this.transform.position.x,this.transform.position.y,tmpY),0.1f);
			if(changeFlag == 0){
				if((timer -= 0.02f)<0){
					timer = 1f;
					tmpY = -12f;
					changeFlag = 1;
				}
			}else{
				if((timer -= 0.02f)<0){
					timer = 5f;
					tmpY = -7f;
					changeFlag = 0;
				}
			}
		}else if(co == 4){
			if(tmpY > -50f)
				tmpY -= 0.05f;
			this.transform.Rotate(0f,0f,tmpY);
		}
	}
}
