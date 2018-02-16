using UnityEngine;
using System.Collections;

public class Protester : MonoBehaviour {

	ProtesterMovement pMovement;
	private float deathTime = 50.0f;
	private bool hasBeenPaid = false;
	
	/* ----------------------------- Added by me --------------------------------------- */
	
	Nameless nameless; //used to access nameless currency
	
	/* -------------- used for slow receipt ---- */
	
	public float wealth = 500.0f;
	public bool decHealth = false;
	public bool decSpeed = false;
	private float initSpeed;
	private bool touchingReceipt = false;
	
	/*------------------------------------------------------------------------------------- */
	
	
	
	void Start () 
	{
		animation.wrapMode = WrapMode.Loop;
		nameless = GameObject.Find("Nameless").GetComponent<Nameless>(); 
		pMovement = GetComponent<ProtesterMovement>();
		initSpeed = pMovement.speed;
	}
	
	void Update () 
	{
		//decrements wealth if the protestor is touching the receipt
		if(touchingReceipt)
			wealth -= 30 * Time.deltaTime;
		
		//protestors dies
		if(wealth <= 0)
		{		
			animation.wrapMode = WrapMode.Once;
			animation.Play("deathKneel");
			pMovement.speed = 0;
			deathTime--;
			if(deathTime <= 0)
			{
				Destroy(gameObject);
				Destroy(this);
			}
			
			if(!hasBeenPaid)
			{
				nameless.currency += 100;
				hasBeenPaid = true;
			}
		}
	}
	
	void OnCollisionEnter(Collision collider) 
	{
		if(collider.gameObject.tag == "Projectile")
		{
			//audio.PlayOneShot(death);
			wealth -= Nameless.damage;
			Destroy(collider.gameObject);
		}
	}
	
	void OnTriggerEnter(Collider hit) {		
		if(hit.gameObject.name == "waypointFinal")
		{
			animation.Play("cheer");
			WaveControl.Finished++;
			Destroy(collider);
		}
		
		if(hit.gameObject.tag == "Hand")
		{
			transform.position -= transform.forward * 5.0f;
		}
		
		if(hit.gameObject.tag == "Freeze")
		{
			pMovement.speed = 0;
		}
		
		/* -------- Slow Receipt code ------------- */
		
		if(hit.gameObject.tag == "taxReturn")
		{
			if(decSpeed)
				pMovement.speed *= 0.8f;
			if(decHealth)
				touchingReceipt = true;
		}
	}
	
	void OnTriggerExit(Collider hit)
	{
		if(hit.gameObject.tag == "taxReturn")
		{
			touchingReceipt = false;
			pMovement.speed = initSpeed;	
		}
	}
}