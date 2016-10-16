using UnityEngine;
using System.Collections;

public class S2RoundBallMaker : MonoBehaviour {
	public GameObject[] balls;
	// Use this for initialization
	void Start () {
		GameObject testV;
		testV = Instantiate (balls [Random.Range (0, balls.Length)], Vector3.zero, Quaternion.identity) as GameObject;
		testV.transform.parent = this.transform;
		testV.transform.localPosition = new Vector3 (0f,-2f,0f);
		testV.rigidbody.useGravity = false;
		
		testV = Instantiate (balls [Random.Range (0, balls.Length)], Vector3.zero, Quaternion.identity) as GameObject;
		testV.transform.parent = this.transform;
		testV.transform.localPosition = new Vector3 (-2f,0f,0f);
		testV.rigidbody.useGravity = false;
		
		testV = Instantiate (balls [Random.Range (0, balls.Length)], Vector3.zero, Quaternion.identity) as GameObject;
		testV.transform.parent = this.transform;
		testV.transform.localPosition = new Vector3 (2f,0f,0f);
		testV.rigidbody.useGravity = false;
		
		testV = Instantiate (balls [Random.Range (0, balls.Length)], Vector3.zero, Quaternion.identity) as GameObject;
		testV.transform.parent = this.transform;
		testV.transform.localPosition = new Vector3 (-1.3f,-1.3f,0f);
		testV.rigidbody.useGravity = false;
		
		testV = Instantiate (balls [Random.Range (0, balls.Length)], Vector3.zero, Quaternion.identity) as GameObject;
		testV.transform.parent = this.transform;
		testV.transform.localPosition = new Vector3 (1.3f,-1.3f,0f);
		testV.rigidbody.useGravity = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
