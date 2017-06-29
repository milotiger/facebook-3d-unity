using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using LitJson;

public class LCD_Generator : MonoBehaviour {
	public string userID = "me";
	public GameObject Player;
	public float MaximumDistance = 3.5f;
	private GameObject MainCamera;
	private GameObject[] LCD_Collection;
	private GameObject ClosestLCD = null;
	private GameObject LCD_Full;
	private GameObject Watching = null;
	private GameObject CaptionBox = null;

	void Update() 
	{
		if (Input.GetKeyDown(KeyCode.Return))
		{
			ClosestLCD = getClosestLCD ();
			if (ClosestLCD != null && Watching == null) {
				Debug.DrawLine (Vector3.zero, ClosestLCD.transform.position);
				Texture tex = Helper.getLCDTexture (ClosestLCD);
				Helper.setTextureToObject (Helper.getChildByTag ("LCD_Main", LCD_Full), tex, false);
				Helper.setTextureToObject (Helper.getChildByTag ("LCD_Holder", LCD_Full), tex, true);
				if (tex != null) {
					Watching = ClosestLCD;
					float aspectRatio = (float) tex.height / tex.width;
					Helper.resetAspectRatio (LCD_Full);
					Helper.changeAspectRatio (LCD_Full, aspectRatio);
					Watching.GetComponent<MoveToPosition> ().SetEndPosition (LCD_Full.transform);
					Watching.GetComponent<ParticleController> ().StartParticle (Global.ParticleDelay);
					CaptionBox.GetComponent<CaptionBoxController> ().SetCaption (Watching.GetComponent<LCD_Storage>().getCaption());
					CaptionBox.GetComponent<CaptionBoxController> ().Show();
					//Helper.setLCDVisibility (LCD_Full, true);
				}
			}
		}

		if (Input.GetKeyDown (KeyCode.Escape) && Watching != null) {
			Watching.GetComponent<ParticleController> ().StartParticle (Global.ParticleDelay);
			Helper.setLCDVisibility (LCD_Full, false);
			Watching.GetComponent<MoveToPosition> ().SetReturn ();
			Watching = null;
			CaptionBox.GetComponent<CaptionBoxController> ().Hide();
		}
	}

	void Start() {
		MainCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		Player = GameObject.FindGameObjectWithTag ("Player");
		LCD_Collection = GameObject.FindGameObjectsWithTag("LCD");
		CaptionBox = GameObject.FindGameObjectWithTag ("Caption_Box");
		print (LCD_Collection.Length);
		LCD_Full = GameObject.FindGameObjectWithTag ("LCD_Full");
		Helper.setLCDVisibility (LCD_Full, false);
		StartCoroutine(APICall.Call (userID, "photos", null, Process));
	}

	private void Process(string dataString)
	{
		print (dataString);
		JsonData result = JsonMapper.ToObject (dataString);
	
		try {
			print (result["data"].Count);
			for (int i = 0; i < Mathf.Min(result["data"].Count, LCD_Collection.Length); i++) {
				LCD_Collection [i].GetComponent<LoadImage> ().url = result ["data"] [i] ["images"] [2] ["source"].ToString ();
				if (result ["data"] [i].Keys.Contains("name")) {
					LCD_Collection[i].GetComponent<LCD_Storage>().setCaption (result ["data"] [i] ["name"].ToString());
				}
				StartCoroutine (LCD_Collection [i].GetComponent<LoadImage> ().Load ());
			}
		} catch (System.Exception ex) {
			print ("Invalid Token");
			GameObject.FindGameObjectWithTag ("Warning_Box").GetComponent<WarningBoxController> ().Show ();
		}

	}

	private GameObject getClosestLCD()
	{
		GameObject tMin = null;
		float minDist = Mathf.Infinity;
		Vector3 currentPos = Player.transform.position;
		foreach (GameObject t in LCD_Collection)
		{
			float dist = Vector3.Distance(t.transform.position, currentPos);
			if (dist < minDist)
			{
				tMin = t;
				minDist = dist;
			}
		}
		return minDist >= MaximumDistance ? null : tMin;
	}

}