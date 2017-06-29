using UnityEngine;
using System.Collections;

public class LoadImage : MonoBehaviour {
	public string url = "";

	public IEnumerator Load() {
		Helper.setLCDVisibility (gameObject, false);
		if (url == "")
			yield return new WaitUntil(()=>url != "");
			//yield return new WaitForSeconds(10);

		Texture2D tex;
		tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
		WWW www = new WWW(url);
		yield return www;
		www.LoadImageIntoTexture(tex);

		Helper.setTextureToObject (Helper.getChildByTag ("LCD_Main", gameObject), tex);
		Helper.setTextureToObject (Helper.getChildByTag ("LCD_Holder", gameObject), tex, true);

		float aspectRatio = (float) tex.height / tex.width;
		Helper.changeAspectRatio (gameObject, aspectRatio);
		Helper.setLCDVisibility (gameObject, true);

		print ("load image");

		yield return new WaitUntil (Helper.getChildByTag ("LCD_Main", gameObject).GetComponent<TriggerLoadTexture> ().isLoadDone); //wait for texture load done to fade it in
		GetComponent<FadeLCD> ().FadeIn ();
		GetComponent<ParticleController>().StartParticle(Global.ParticleDelay);
	}
}
