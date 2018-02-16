using UnityEngine;
using System.Collections;

public class TowerShooterAlpha : MonoBehaviour {
	
	public Transform projectileOrigin;
	public float speed = 20.0f;//, damage = 5.0f;
	public Rigidbody projectile;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider hit)
	{
		if(hit.gameObject.tag == "Protester")
		{
			Rigidbody instanceProjectile = Instantiate(projectile, projectileOrigin.position, projectileOrigin.rotation) as Rigidbody;
			Quaternion deltaRotation = Quaternion.Euler(new Vector3(180.0f, 90.0f, 0));
			instanceProjectile.MoveRotation(projectileOrigin.rotation * deltaRotation);
			instanceProjectile.rigidbody.AddForce(projectileOrigin.forward * speed);
		}
	}
}
