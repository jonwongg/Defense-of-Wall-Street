using UnityEngine;
using System.Collections;

public class inGameGUI : MonoBehaviour {
	
	public Texture return_to_game, controls, main_menu; //can drag some pic on this to show up in the gui
	private bool main_menu_GUI= false; //used to show in game menu when set to true;
	public static bool paused = false; //used to pause the game
	Nameless shameless;
	
	private bool show_control_menu = false;
	
	void Start()
	{
		shameless = GameObject.Find("Nameless").GetComponent<Nameless>();	
	}
	
	void Update()
	{
		AllowPlayerControl();
		
		if(paused)
			Screen.lockCursor = false;
	}
	
	void OnGUI()
	{
		if(Input.GetKeyDown("escape") || Input.GetKeyDown("p"))
	    {
			shameless.enabled = false; //disables script when the screen is paused to remove the crosshairs
			main_menu_GUI = true;
			paused = true;
		}
		if(main_menu_GUI)
		{
			Time.timeScale = 0;
			
			//main outer gui box
			GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");  
			
			if(! show_control_menu)
			{
				GUI.backgroundColor = Color.green;
				if(GUI.Button(new Rect(Screen.width/2-75, Screen.height/2-200, return_to_game.width, return_to_game.height), return_to_game) || Input.GetKeyDown("g")) 
				{
					main_menu_GUI = false;
				    shameless.enabled = true;
					paused = false;
					Time.timeScale = 1f;	
				}
				
				if(GUI.Button(new Rect(Screen.width/2-75, Screen.height/2-100, controls.width, controls.height), controls) || Input.GetKeyDown("c"))
				{
						show_control_menu = true;
				}
				
				if(GUI.Button(new Rect(Screen.width/2-75, Screen.height/2, main_menu.width, main_menu.height), main_menu) || Input.GetKeyDown("m"))
				{
					Time.timeScale = 1;
					paused = false;
					main_menu_GUI = false;
					Application.LoadLevel("StartScreen");
				}
			}
			else
			{
				GUI.backgroundColor = Color.green;
				GUI.Box(new Rect(Screen.width/2-250, Screen.height/2-250, 500, 500), "\nMove = W, S, D, A\n\nJump = Space bar\n\n" +
					"Shoot Shuriken = left click\n\nBuild Defense Tower = E\n\nGrapple = R\n\nEscape/P = Opens In-Game Menu/Pauses Game\n\n" +
					"(Although if you found this menu you probably already knew this)\n\n\nGrappable objects are the white cubes placed above buildings and are\n" +
					"indicated by a yellow highlight when scrolled over.");
				
				if(GUI.Button(new Rect(Screen.width/2-return_to_game.width/2, Screen.height/2+100, return_to_game.width, return_to_game.height), return_to_game) || Input.GetKeyDown("g"))
				{
					main_menu_GUI = false;
					show_control_menu = false;
				    shameless.enabled = true;
					paused = false;
					Time.timeScale = 1f;
				}
			}
		}
	}
	
	void AllowPlayerControl()
	{
		if(main_menu_GUI)
		{
			GetComponent<MouseLook>().enabled = false;
			
			placeTower.allowBuilding = false;
		}
		else
		{
			GetComponent<MouseLook>().enabled = true;
			placeTower.allowBuilding = true;
		}
	}
}