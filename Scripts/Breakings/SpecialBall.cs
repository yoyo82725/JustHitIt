using UnityEngine;
using System.Collections;

public class SpecialBall : MonoBehaviour {
	bool slow,quick,bigSmall,hide,rotateAround,jump;
	Vector3 iniScale;
	int changeFlag;
	float alpha,jumpTimer;
	// Use this for initialization
	void Start () {
		if (this.name == "SlowBall(Clone)" || this.name == "SlowBall") {
			slow=true;
		}else if (this.name == "QuickBall(Clone)" || this.name == "QuickBall") {
			quick=true;
		}else if (this.name == "BigSmallBall" || this.name == "BigSmallBall(Clone)") {
			iniScale = this.transform.localScale;
			bigSmall=true;
		}else if (this.name == "HideBall" || this.name == "HideBall(Clone)") {
			hide=true;
			alpha=1.0f;
		}else if (this.name == "wind") {
			rotateAround=true;
		}else if(this.name == "JumpBall" || this.name == "JumpBall(Clone)"){
			if(this.transform.parent != null){
				this.transform.parent = null;
				this.rigidbody.useGravity = true;
			}
			jump = true;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		/*
		if (rotateXYZ) {
			this.transform.Rotate(7f,7f,7f);
		}
		if (rotateY) {
			this.transform.Rotate(0,7f,0);
		}
		if (rotateX) {
			this.transform.Rotate(7f,0,0);
		}
		*/
		if (slow) {
			if(this.name == "SlowBall"){
				this.transform.parent.Translate(0,0,0.1f);
			}else
				this.rigidbody.velocity = this.transform.TransformDirection(Vector3.down);
		}
		if (quick) {
			if(this.name == "QuickBall"){
				this.transform.parent.Translate(0,0,0.4f);
			}else
				this.rigidbody.velocity = this.transform.TransformDirection(Vector3.down*12);
		}
		if (bigSmall) {
			if(changeFlag==0){
				this.transform.localScale = Vector3.Lerp(this.transform.localScale,-(iniScale),0.1f);
				if(this.transform.localScale.x<(-iniScale.x)+0.1f)
					changeFlag = (changeFlag+1)%2;
			}else{
				this.transform.localScale = Vector3.Lerp(this.transform.localScale,iniScale,0.1f);
				if(this.transform.localScale.x>iniScale.x-0.1f)
					changeFlag = (changeFlag+1)%2;
			}
		}
		if (hide) {
			if(changeFlag==0){
				if(alpha>0)
					alpha-=0.02f;
				else
					changeFlag = 1;
			}else{
				if(alpha<1.0f)
					alpha+=0.02f;
				else
					changeFlag = 0;
			}
			this.renderer.material.color = new Color(this.renderer.material.color.r,this.renderer.material.color.g,this.renderer.material.color.b,alpha);
		}
		if(rotateAround){
			this.transform.RotateAround(transform.parent.position,Vector3.up,15);
		}
		if (jump) {
			if(jumpTimer > 0)
				jumpTimer -= 0.02f;
			else{
				alpha = Random.Range(-6.5f,6.5f);
				jumpTimer = 1f;
			}
			this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(alpha,this.transform.position.y,0),0.1f);
		}
		
		/*
		if(Lwing){
			if(changeFlag==0){
				this.transform.RotateAround(transform.parent.position,Vector3.forward,5f);
				alpha+=5f;
				if(alpha>=30f)
					changeFlag = 1;
			}else{
				this.transform.RotateAround(transform.parent.position,Vector3.forward,-2.5f);
				alpha-=2.5f;
				if(alpha<=-30f)
					changeFlag = 0;
			}
		}
		if(Rwing){
			if(changeFlag==0){
				this.transform.RotateAround(transform.parent.position,Vector3.forward,-5f);
				alpha-=5f;
				if(alpha<=-30f)
					changeFlag = 1;
			}else{
				this.transform.RotateAround(transform.parent.position,Vector3.forward,2.5f);
				alpha+=2.5f;
				if(alpha>=30f)
					changeFlag = 0;
			}
		}
		*/
		/*
		//顏色變回
		if(colorIniBool){
			if(this.renderer.material.color.r > 254){
				this.renderer.material.color = Color.white;
				colorIniBool=false;
			}else
				this.renderer.material.color = Color.Lerp(this.renderer.material.color,Color.white,0.05f);
		}
		*/
	}
}
