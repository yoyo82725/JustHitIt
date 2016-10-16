using UnityEngine;
using System.Collections;

public class S2FourBallMaker : MonoBehaviour {
	public GameObject[] balls;
	// Use this for initialization
	void Start () {
		GameObject testV;
		testV = Instantiate (balls [Random.Range (0, balls.Length)], Vector3.zero, Quaternion.identity) as GameObject;
		testV.transform.parent = this.transform;
		testV.transform.localPosition = new Vector3 (0.7f,0.7f,0f);

		testV = Instantiate (balls [Random.Range (0, balls.Length)], Vector3.zero, Quaternion.identity) as GameObject;
		testV.transform.parent = this.transform;
		testV.transform.localPosition = new Vector3 (-0.7f,0.7f,0f);

		testV = Instantiate (balls [Random.Range (0, balls.Length)], Vector3.zero, Quaternion.identity) as GameObject;
		testV.transform.parent = this.transform;
		testV.transform.localPosition = new Vector3 (-0.7f,-0.7f,0f);

		testV = Instantiate (balls [Random.Range (0, balls.Length)], Vector3.zero, Quaternion.identity) as GameObject;
		testV.transform.parent = this.transform;
		testV.transform.localPosition = new Vector3 (0.7f,-0.7f,0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
