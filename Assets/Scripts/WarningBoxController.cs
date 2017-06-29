using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class WarningBoxController : MonoBehaviour {
	private bool isShow = false;
	public float Speed = 0.4f;
	public Button LoginButton;
	// Use this for initialization
	void Start () {
		LoginButton.onClick.AddListener (MoveToLoginScene);
	}

	void MoveToLoginScene()
	{
		print ("move to login");
		SceneManager.LoadScene ("Login");
	}
	
	// Update is called once per frame
	void Update () {
		if (isShow) {
			transform.localScale = Vector3.Lerp (transform.localScale, Vector3.one, Speed * Time.deltaTime);
		} else {
			transform.localScale = Vector3.Lerp (transform.localScale, new Vector3(0, 1, 1), Speed * Time.deltaTime);
		}
	}

	public void Show()
	{
		isShow = true;
	}

	public void Hide()
	{
		isShow = false;
	}
}
