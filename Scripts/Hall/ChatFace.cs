using UnityEngine;
using System.Collections;

public class ChatFace : MonoBehaviour {
	public Sprite girl_laugh,girl_sLaugh,girl_why,girl_giveup;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Girl_laugh(){
		this.GetComponent<SpriteRenderer>().sprite = girl_laugh;
	}
	public void Girl_sLaugh(){
		this.GetComponent<SpriteRenderer>().sprite = girl_sLaugh;
	}
	public void Girl_why(){
		this.GetComponent<SpriteRenderer>().sprite = girl_why;
	}
	public void Girl_giveup(){
		this.GetComponent<SpriteRenderer>().sprite = girl_giveup;
	}
}
