using UnityEngine;
using System.Collections;

public class LRwind : MonoBehaviour {
	//左吹或右吹
	public static bool isWind=false,toLwind=false;
	float timer=0.0f;


	void Awake(){

	}

	void Start () {
		if (this.gameObject.name == "toLwind(Clone)")
			toLwind=true;
		else if (this.gameObject.name == "toRwind(Clone)")
			toLwind=false;
	}

	void FixedUpdate () {
		//左右吹
		if (toLwind) {
				isWind = true;
				transform.Translate (-0.042f, 0, 0);
		} else {
				isWind = true;
				transform.Translate (0.042f, 0, 0);
		}
		if ((timer += 0.02f) > 2.4f) {
				isWind = false;
				Destroy (this.gameObject);
		}
	}
}
