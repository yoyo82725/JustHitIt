using UnityEngine;
using System.Collections;

public class S2VBallMaker : MonoBehaviour {
	public GameObject[] balls;
	// Use this for initialization
	void Start () {
		GameObject testV;
		testV = Instantiate (balls [Random.Range (0, balls.Length)], Vector3.zero, Quaternion.identity) as GameObject;
		testV.transform.parent = this.transform;
		testV.transform.localPosition = new Vector3 (0f,-1f,0f);
		testV.rigidbody.useGravity = false;
		
		testV = Instantiate (balls [Random.Range (0, balls.Length)], Vector3.zero, Quaternion.identity) as GameObject;
		testV.transform.parent = this.transform;
		testV.transform.localPosition = new Vector3 (1.2f,1f,0f);
		testV.rigidbody.useGravity = false;
		
		testV = Instantiate (balls [Random.Range (0, balls.Length)], Vector3.zero, Quaternion.identity) as GameObject;
		testV.transform.parent = this.transform;
		testV.transform.localPosition = new Vector3 (-1.2f,1f,0f);
		testV.rigidbody.useGravity = false;
		
		testV = Instantiate (balls [Random.Range (0, balls.Length)], Vector3.zero, Quaternion.identity) as GameObject;
		testV.transform.parent = this.transform;
		testV.transform.localPosition = new Vector3 (0.6f,0f,0f);
		testV.rigidbody.useGravity = false;

		testV = Instantiate (balls [Random.Range (0, balls.Length)], Vector3.zero, Quaternion.identity) as GameObject;
		testV.transform.parent = this.transform;
		testV.transform.localPosition = new Vector3 (-0.6f,0f,0f);
		testV.rigidbody.useGravity = false;
	}
}
