using UnityEngine;
using System.Collections;

public class Nameless : MonoBehaviour {
	
	public float fireRate = 1.0f;
	public float projectileSpeed = 1000.0f;
	public static float damage = 60.0f;
	public Rigidbody[] projectile;
	public Transform projectileOrigin, target;
	public Texture crosshair;
	
	public int currency;// = 1000; //get point for hitting protestors
	
	void Start () 
	{
		animation.wrapMode = WrapMode.Loop;
		Screen.lockCursor = true;
		currency = 1000;
	}
	
	void OnGUI()
	{
    	GUI.DrawTexture(new Rect((Screen.width - crosshair.width)/2, 
                 (Screen.height - crosshair.height)/2, //so credit cards are thrown with crosshair 
                 crosshair.width, crosshair.height), crosshair);
	}

	
	void Update () 
	{
		Screen.lockCursor = true;
		animation.CrossFade("shurikenReady");
	
		if(Input.GetButtonDown("Shoot"))
		{
			//play animation and launch projectile
			animation.Play("shurikenFire");
			Rigidbody instanceProjectile = Instantiate(projectile[Random.Range(0, 4)], transform.position, transform.rotation) as Rigidbody;
			Quaternion deltaRotation = Quaternion.Euler(new Vector3(90.0f, 90.0f, 0));
			instanceProjectile.MoveRotation(transform.rotation * deltaRotation);
			instanceProjectile.rigidbody.AddForce(transform.forward * 10.0f * projectileSpeed);
		}
	}
}