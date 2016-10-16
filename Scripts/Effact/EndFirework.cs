using UnityEngine;
using System.Collections;

public class EndFirework : MonoBehaviour {
	public GameObject fireworks;
	float fireTimer=0.5f;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if ((fireTimer -= 0.02f) <= 0f) {
			fireTimer=0.5f;
			GameObject testV;
			testV = Instantiate(fireworks,new Vector3((Random.Range(-10f,10f)),(Random.Range(-5f,5f)),0f),Quaternion.identity) as GameObject;
			Destroy(testV.gameObject,2f);
		}
	}
}
