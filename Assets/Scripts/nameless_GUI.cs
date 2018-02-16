using UnityEngine;
using System.Collections;

public class nameless_GUI : MonoBehaviour {
	
	public Texture currency_GUI;
	Nameless nameless;
	
	void Start()
	{
		nameless = GetComponent<Nameless>();	
	}
	
	void OnGUI()
	{
		GUI.DrawTexture(new Rect(0, 0, currency_GUI.width-80, currency_GUI.height-60), currency_GUI);  //x.position, y.position, width, height
		GUI.Box(new Rect(50, 32, 70, 30), "" + nameless.currency);
	}
}