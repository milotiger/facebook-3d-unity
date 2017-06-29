using UnityEngine;
using System.Collections;

public class LCD_Storage : MonoBehaviour {
	private string Caption = "";
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setCaption (string Caption) {
		this.Caption = Caption;
		print (this.Caption);
	}

	public string getCaption(){
		return this.Caption;
	}
}
