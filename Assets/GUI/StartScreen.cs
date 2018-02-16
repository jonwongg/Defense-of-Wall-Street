using UnityEngine;
using System.Collections;

public class StartScreen : MonoBehaviour {

	private Rect window;

	void OnGUI () {

		GUI.Box(new Rect(Screen.width/2-200,10,400,100), "Tower Climber");
		
		//Start new game button
		if (GUI.Button (new Rect (20,200,200,100), "Start"))
			Application.LoadLevel(1);
		
		//Store menu
		if(GUI.Button (new Rect(20,350,200,100), "Store"))
			Application.LoadLevel(3);
	}
}
