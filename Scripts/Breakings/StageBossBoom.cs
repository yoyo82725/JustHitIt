using UnityEngine;
using System.Collections;

public class StageBossBoom : MonoBehaviour {
	public GameObject boom;
	float timer=0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		timer += 0.02f;
		if (timer > 5f) {
			Instantiate(boom,transform.position,Quaternion.identity);
			Destroy(this.transform.parent.gameObject);
		}
	}
}
