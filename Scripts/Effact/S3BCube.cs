using UnityEngine;
using System.Collections;

public class S3BCube : MonoBehaviour {
	Transform player;
	public GameObject[] balls;
	public GameObject boom;
	float timer=5f;
	public AudioClip piSE;

	void Start () {
		//player = GameObject.FindWithTag("playerCube").transform;
		player = UserScreen.player;
	}
	

	void FixedUpdate () {
		if (PlayingManager.endIn) {
			Instantiate(boom,this.transform.position,Quaternion.identity);
			Destroy(this.gameObject);
		}else{
			Vector3 relativePos = player.position-transform.position;
			transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.LookRotation(relativePos),0.1f);
			transform.RotateAround (this.transform.parent.transform.position, Vector3.forward, 1f);
			if (timer < 0) {
				timer=3f;
				if(Random.Range(1,3)==1){
					Instantiate(balls[Random.Range(0,balls.Length)],new Vector3(transform.position.x,transform.position.y,0f),Quaternion.LookRotation(relativePos));
					PiSE();
					PlayingManager.outCount++;
				}
			}else
				timer -= 0.02f;
		}
	}
	void PiSE(){
		AudioSource.PlayClipAtPoint (piSE,Vector3.one);
	}
}
