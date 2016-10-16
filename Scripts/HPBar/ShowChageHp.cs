using UnityEngine;
using System.Collections;

public class ShowChageHp : MonoBehaviour {
	int step=0;
	Vector3 toPos;
	// Use this for initialization
	void Start () {
		toPos = this.transform.position + new Vector3(0,3f,0);
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale != 0) {
			if (step == 0) {
				this.transform.localScale = Vector3.Lerp(this.transform.localScale,new Vector3(5f,5f,5f),0.2f);
				if(this.transform.localScale.x > 4.4f)
					step++;
			}else if(step == 1){
				this.transform.localScale = Vector3.Lerp(this.transform.localScale,new Vector3(2f,2f,2f),0.1f);
				if(this.transform.localScale.x < 2.1f){
					Destroy(this.gameObject,0.3f);
					step++;
				}
			}
			this.transform.position = Vector3.Lerp (this.transform.position, toPos, 0.1f);
		}
	}
}
