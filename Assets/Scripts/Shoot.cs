using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	
	public float speed = 20.0f;
	public Rigidbody projectile;
	
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Shoot"))
		{
			Rigidbody instanceProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
			Quaternion deltaRotation = Quaternion.Euler(new Vector3(90.0f, 90.0f, 0));
			instanceProjectile.MoveRotation(transform.rotation * deltaRotation);
			instanceProjectile.rigidbody.AddForce(transform.forward * speed);
		}
	}
}
