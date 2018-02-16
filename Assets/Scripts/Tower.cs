using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {
	
	public float range = 30.0f;
	public float shootAngle = 10.0f;
	public Transform target;
	public Transform projectile;
	public float initialSpeed = 20.0f;
	public float reload = 0.5f;
	private float previousShot = -10.0f;
	
	// Use this for initialization
	void Start () {
//		if(target == null && GameObject.FindWithTag("Protester"))
//			target = GameObject.FindWithTag("Protester").transform;
	}
	
	// Update is called once per frame
	void Update () {
		print("update has begun");
		
		if(target == null && GameObject.FindWithTag("Protester"))
		{
			target = GameObject.FindWithTag("Protester").transform;
			print("target found");
		}
/*			
		if(target == null)
			return;
*/
//		target = GameObject.FindWithTag("Protester").transform;
		
		if(!TargetVisible())
			return;
		
		print("update has been run");
		
//		Vector3 targetLoc = target.position;
//		Vector3 targetRotation = Quaternion.LookRotation(targetLoc - transform.position, Vector3.up);
//		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2.0);
		
		Vector3 vForward = transform.TransformDirection(Vector3.forward);
		Vector3 targetDirection = target.position - transform.position;

		if(Vector3.Angle(vForward, targetDirection) < shootAngle)
		{
			Fire();
		}
		
		
	}
	
	bool TargetVisible()
	{
		if(Vector3.Distance(transform.position, target.position) > range)
			return false;
		
		RaycastHit hit;
		if(Physics.Linecast(transform.position, target.position, out hit))
			return hit.transform == target;
		
		return false;
	}
	
	void Fire()
	{
		if(Time.time > reload + previousShot)
		{
			Rigidbody instanceProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
			Quaternion deltaRotation = Quaternion.Euler(new Vector3(90.0f, 90.0f, 0));
			instanceProjectile.MoveRotation(transform.rotation * deltaRotation);
			instanceProjectile.rigidbody.AddForce(transform.forward * initialSpeed);
//			instanceProjectile.velocity = transform.TransformDirection(new Vector3(0, 
		}
		previousShot = Time.time;
	}
}