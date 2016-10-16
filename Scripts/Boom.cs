using UnityEngine;
using System.Collections;

public class Boom : MonoBehaviour {
	public AudioClip bossBoomSE;

	void Start () {
		if (this.name == "BossBoom(Clone)") {
			PlayingManager.bossBoomed = true;
			Destroy (this.gameObject, 4.99f);
			AudioSource.PlayClipAtPoint(bossBoomSE,Vector3.one);
		}else if (this.name == "RainbowBoom(Clone)") {
			Destroy (this.gameObject, 1.99f);
		}else
			Destroy(this.gameObject,0.49f);
		//this.renderer.material.shader = Shader.Find ("Particles/Additive");
	}

	void Update () {
		/* 低效能?
		if(timer>0.1){
			if(this.particleEmitter.particleCount==0){
				Destroy(this.gameObject);
			}
		}else{
			timer+=Time.deltaTime;
		}
		*/
	}
}
