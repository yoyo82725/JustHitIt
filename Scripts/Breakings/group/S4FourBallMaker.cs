using UnityEngine;
using System.Collections;

public class S4FourBallMaker : MonoBehaviour {
	public GameObject[] balls;

	void Start () {
		GameObject testV;
		testV = Instantiate (balls [Random.Range (0, balls.Length)], Vector3.zero, Quaternion.identity) as GameObject;
		testV.transform.parent = this.transform;
		testV.transform.localPosition = new Vector3 (0.7f,0.7f,0f);
		testV.rigidbody.useGravity = false;
		
		testV = Instantiate (balls [Random.Range (0, balls.Length)], Vector3.zero, Quaternion.identity) as GameObject;
		testV.transform.parent = this.transform;
		testV.transform.localPosition = new Vector3 (-0.7f,0.7f,0f);
		testV.rigidbody.useGravity = false;

		testV = Instantiate (balls [Random.Range (0, balls.Length)], Vector3.zero, Quaternion.identity) as GameObject;
		testV.transform.parent = this.transform;
		testV.transform.localPosition = new Vector3 (-0.7f,-0.7f,0f);
		testV.rigidbody.useGravity = false;

		testV = Instantiate (balls [Random.Range (0, balls.Length)], Vector3.zero, Quaternion.identity) as GameObject;
		testV.transform.parent = this.transform;
		testV.transform.localPosition = new Vector3 (0.7f,-0.7f,0f);
		testV.rigidbody.useGravity = false;
	}

	void Update () {
	
	}
}
