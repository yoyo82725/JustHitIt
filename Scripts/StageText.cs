using UnityEngine;
using System.Collections;

public class StageText : MonoBehaviour {
	float scaleIniX=1.16f,to1=0.17f,to2=-0.17f,nowScaleX;
	int step=1;

	// Use this for initialization
	void Start () {
		transform.localScale = new Vector3(scaleIniX,transform.localScale.y,transform.localScale.z);
		nowScaleX = scaleIniX;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale != 0) {
			if (step == 1) {
				nowScaleX = Mathf.Lerp (nowScaleX, to1, 0.05f);
				if (nowScaleX <= to1 + 0.01f)
					step++;
			} else if (step == 2) {
				nowScaleX -= 0.03f;
				if (nowScaleX <= to2 + 0.01f)
					step++;
			} else if (step == 3) {
				nowScaleX = Mathf.Lerp (nowScaleX, to1, 0.07f);
				if (nowScaleX >= to1 - 0.001f)
					step++;
			} else if (step == 4) {
				nowScaleX += 0.03f;
				if (nowScaleX >= scaleIniX + 0.3f)
					step++;
			}
			else if (step == 5) {
				Destroy(this.gameObject);
			}
			//Vector3.Lerp(transform.localScale,new Vector3(to1,transform.localScale.y,transform.localScale.z));
			transform.localScale = new Vector3(nowScaleX,transform.localScale.y,transform.localScale.z);

		}
	}
}
