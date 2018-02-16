using UnityEngine;
using System.Collections;

public class main_menu_GUI : MonoBehaviour {
	
	public Texture start_button, quit_game, game_title;
	
	void OnGUI()
	{
		
		GUI.DrawTexture(new Rect(Screen.width/2-(game_title.width/2), -125, game_title.width, game_title.height), game_title);
		
		GUI.backgroundColor = Color.green;
		if(GUI.Button(new Rect( Screen.width/2-((start_button.width-20)/2), Screen.height/2+75, start_button.width-20, start_button.height-20), start_button)
		   || Input.GetKeyDown("s"))
			Application.LoadLevel("Level1");
		
		if(GUI.Button(new Rect( Screen.width/2-((quit_game.width-20)/2), Screen.height/2+175, quit_game.width-20, quit_game.height-20), quit_game)
		   || Input.GetKeyDown("q"))
		   Application.Quit();
	}
}