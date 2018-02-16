using UnityEngine;
using System.Collections;

public class placeTower : MonoBehaviour {

	public Transform[] IDM;
	public Transform[] repressor;
	public Transform taxReturn;
	private bool towerGUI = false;
	public static bool allowBuilding = true;
	public Texture insuffFunds;
	Transform obj; //used to store the location of the buildingBlock hit
	
	public int IDM_cost = 200;
	public int Repressor_cost = 1000;
	public int Tax_return_cost = 1200;
	private bool insufficient_funds = false;
	private float insufficient_funds_timeout = 300.0f;
	Nameless nameless;
	
	void Start()
	{
		nameless = GameObject.Find("Nameless").GetComponent<Nameless>();	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(allowBuilding) //allows building if game is not paused. Boolean is changed in the inGameGUI sc
		{
			if(Input.GetButtonDown("Construct"))
			{
				Ray ray = Camera.main.ScreenPointToRay(new Vector3(Camera.mainCamera.pixelWidth/2f, Camera.mainCamera.pixelHeight/2f, 0));
				RaycastHit hit;
	
				if(Physics.Raycast(ray, out hit))
				{
					if(hit.transform.tag == "1Block" || hit.transform.tag == "2Block" || hit.transform.tag == "3Block" || hit.transform.tag == "4Block")
					{
						obj = hit.transform;
						towerGUI = true;
					}
				}
			}
		}
		
		if(insufficient_funds)
			insufficient_funds_timeout--;
		else
			insufficient_funds_timeout = 300.0f;
	}
	
	void OnGUI()
	{
		if(insufficient_funds)
		{
			GUI.Box(new Rect(Screen.width/2, Screen.height/2-250, insuffFunds.width, insuffFunds.height), insuffFunds);
			if(insufficient_funds_timeout <= 0)
				insufficient_funds = false;
		}
		
		if(towerGUI)
		{
			insufficient_funds = false;
			GUI.backgroundColor = Color.black;
			GUI.Box(new Rect(0, 80, 250, 100), "Select a tower:\n\n1. IDM (Instant debt machine): $200\n2. The Repressor: $1000\n3. Tax Return: $1200");
			
			
			/* --------- If a players builds an IDM -------- */
			if(Input.GetKeyDown("1"))
			{
				towerGUI = false;
				insufficient_funds = false;
				
				if(nameless.currency < IDM_cost)
					insufficient_funds = true;
				else
				{
					nameless.currency -= IDM_cost; //subtracts the funds from the players currency
					insufficient_funds = false;
					
					if(obj.transform.tag == "1Block")
					{	
						Instantiate(IDM[0], obj.position + new Vector3(0, 6.0f, 0), IDM[0].rotation);
						Destroy(obj.gameObject);
					}
					else if(obj.transform.tag == "2Block")
					{
						Instantiate(IDM[1], obj.position + new Vector3(0, 6.0f, 0), IDM[1].rotation);
						Destroy(obj.gameObject);
					}
					else if(obj.transform.tag == "3Block")
					{
						Instantiate(IDM[2], obj.position + new Vector3(0, 6.0f, 0), IDM[2].rotation);
						Destroy(obj.gameObject);
					}
					else
					{
						Instantiate(IDM[3], obj.position + new Vector3(0, 6.0f, 0), IDM[3].rotation);
						Destroy(obj.gameObject);
					}
				}
			}
			
			/* --------- If a players builds a Repressor -------- */
			if(Input.GetKeyDown("2"))
			{
				towerGUI = false;
				insufficient_funds = false;
				
				if(nameless.currency < Repressor_cost)
					insufficient_funds = true;
				else
				{
					nameless.currency -= Repressor_cost; //subtracts the funds from the players currency
					insufficient_funds = false;
					
					if(obj.transform.tag == "1Block")
					{
						Instantiate(repressor[0], obj.position, repressor[0].rotation); 
						Destroy(obj.gameObject);
					}
					else if(obj.transform.tag == "2Block")
					{
						Instantiate(repressor[1], obj.position, repressor[1].rotation); 
						Destroy(obj.gameObject);	
					}
					else if(obj.transform.tag == "3Block")
					{
						Instantiate(repressor[2], obj.position, repressor[2].rotation); 
						Destroy(obj.gameObject);	
					}
					else 
					{
						Instantiate(repressor[3], obj.position, repressor[3].rotation); 
						Destroy(obj.gameObject);	
					}
				}
			}
			
			/* --------- If a players builds a Tax Return -------- */
			if(Input.GetKeyDown("3"))
			{
				towerGUI = false;
				Vector3 moveBlock;
				
				if(nameless.currency < Tax_return_cost)
					insufficient_funds = true;
				else
				{
					nameless.currency -= Tax_return_cost; //subtracts the funds from the players currency
					insufficient_funds = false;
					
					if(obj.transform.tag == "1Block")
					{
						moveBlock = new Vector3(7.5f, -0.4f, 0); 
						Instantiate(taxReturn, obj.position+moveBlock, obj.rotation);
						Destroy(obj.gameObject);
					}
				
					else if(obj.transform.tag == "2Block")
					{
						moveBlock =	new Vector3(-7.5f, -0.5f, 0);
						Instantiate(taxReturn, obj.position+moveBlock, obj.rotation);
						Destroy(obj.gameObject);
					}
					else if(obj.gameObject.tag == "3Block")
					{
						moveBlock = new Vector3(0, -0.3f, -6.5f);
						Instantiate(taxReturn, obj.position+moveBlock, obj.rotation);
						Destroy(obj.gameObject);
					}
					else
					{
						moveBlock = new Vector3(0, -0.2f, 6.5f);
						Instantiate(taxReturn, obj.position+moveBlock, obj.rotation);
						Destroy(obj.gameObject);
					}
				}
			}
				
		}
	}
}