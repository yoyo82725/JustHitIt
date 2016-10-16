using UnityEngine;
using System.Collections;

public class HealthOut : MonoBehaviour {
	float timer;
	public GameObject ball;
	public AudioClip piSE;

	void Start () {
	
	}

	void FixedUpdate () {
		if (!PlayingManager.endIn && !PlayingManager.warningIn && PlayingManager.mineHp < PlayingManager.mineHpL*0.5f) {
			if ((timer -= 0.02f) < 0) {
				timer = 3.8f;
				//移動
				this.transform.position = new Vector3(Random.Range(-6f,6f),7f,0f);
				//發射
				Instantiate(ball,this.transform.position,Quaternion.identity);
				AudioSource.PlayClipAtPoint (piSE,Vector3.one);
				PlayingManager.outCount++;
			}
		}
	}
}
