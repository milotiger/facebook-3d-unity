using UnityEngine;
using System.Collections;

public class FadeLCD : MonoBehaviour {
	private Renderer LCDMainRenderer;
	private Renderer LCDHolderRenderer;
	private bool isFadeIn = false;
	private float Speed = Global.FadeSpeed;
	private float Alpha = 0;

	// Use this for initialization
	void Start () {
		LCDMainRenderer = Helper.getChildByTag ("LCD_Main", gameObject).GetComponent<Renderer>();
		LCDHolderRenderer = Helper.getChildByTag ("LCD_Holder", gameObject).GetComponent<Renderer>();
	}

	// Update is called once per frame
	void Update () {
		if (isFadeIn) {
			//var Lerp = Mathf.PingPong (Time.time - CurrentTime, Duration) / Duration;
			Alpha = Mathf.Lerp (Alpha, 1.0f, Speed * Time.deltaTime);
			//print (Alpha);
			var CurrentColor = LCDMainRenderer.material.color;
			CurrentColor.a = Alpha;
			LCDMainRenderer.material.color = CurrentColor;
			LCDHolderRenderer.material.color = CurrentColor;
			if (Alpha >= 0.98f) {
//				print ("stop fade");
				isFadeIn = false;
			}
		}
	}

	public void FadeIn () {
		isFadeIn = true;
//		print ("start fade");
	}
}
