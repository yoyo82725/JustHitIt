using UnityEngine;
using System.Collections;

public class ReflexBall : MonoBehaviour {
	bool topReflex=false,downPow=false;
	float downSpd=-0.2f;
	public AudioClip reflexSE;

	void Start () {
		if (this.name == "GlassBallShell(Clone)"){
			downPow=true;
		}else if (this.name == "TopGlassBallShell(Clone)") {
			topReflex=true;
			downPow=true;
		}else if (this.name == "TopGlassBallShell"){
			topReflex=true;
		}
	}
	

	void FixedUpdate () {
		if(this.transform.position.x < -11.0f || this.transform.position.x > 11.0f){ //碰到邊界
			if(this.transform.childCount == 0){
				Destroy(this.gameObject);
			}else{
				if(this.transform.position.x<-11.0f)
					this.transform.position = new Vector3(-10.8f,this.transform.position.y,this.transform.position.z);
				else
					this.transform.position = new Vector3(10.8f,this.transform.position.y,this.transform.position.z);
				if(downSpd > -1)
					downSpd -= 0.15f;
				else
					topReflex = false;
				AudioSource.PlayClipAtPoint(reflexSE,Vector3.one);
				this.transform.rotation = new Quaternion(0.0f,0.0f,(-this.transform.rotation.z),this.transform.rotation.w);
				this.transform.parent = null;
				downPow = true;
				//向上發改向
				if(!topReflex){
					if(Mathf.Abs(this.transform.rotation.w) < 0.75f)
						this.transform.rotation = new Quaternion(this.transform.rotation.x,this.transform.rotation.y,this.transform.rotation.z,0.9f);
				}
			}
		}
		if(topReflex){
			if(this.transform.position.y > 6.0f){ //碰到上邊界
				this.transform.position = new Vector3(this.transform.position.x,5.9f,this.transform.position.z);
				this.transform.rotation = new Quaternion(0.0f,0.0f,this.transform.rotation.w,this.transform.rotation.z);
				this.transform.parent = null;
				downSpd -= 0.15f;
				AudioSource.PlayClipAtPoint(reflexSE,Vector3.one);
				downPow = true;
			}
		}
		if(downPow){
			this.transform.Translate(0f,downSpd,0f,Space.Self);
		}
	}
}
