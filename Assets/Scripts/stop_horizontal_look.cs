using UnityEngine;
using System.Collections;

public class stop_horizontal_look : MonoBehaviour {
	
	void Update()
	{
		AllowPlayerControl();	
	}
		
	void AllowPlayerControl()
	{
		if(inGameGUI.paused)
		{
			GetComponent<MouseLook>().enabled = false;
		}
		else
		{
			GetComponent<MouseLook>().enabled = true;
		}
	}
}