using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CaptionBoxController : MonoBehaviour {
	private Transform Text;
	private bool isShow  = false;
	public float Speed = 4.0f;
	// Use this for initialization
	void Start () {
		Text = Helper.getChildByTag ("Text", gameObject);
	}

	void Update () {
		if (isShow) {
			transform.localScale = Vector3.Lerp (transform.localScale, Vector3.one, Speed * Time.deltaTime);
		} else {
			transform.localScale = Vector3.Lerp (transform.localScale, new Vector3(0, 1, 1), Speed * Time.deltaTime);
		}
	}

	public void Show()
	{
		if (Text.GetComponent<Text> ().text == "")
			return;
		isShow = true;
	}

	public void Hide()
	{
		isShow = false;
	}

	public void SetCaption (string Caption){
		Text.GetComponent<Text> ().text = Caption;
	}
}
