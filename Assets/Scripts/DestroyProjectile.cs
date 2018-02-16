using UnityEngine;
using System.Collections;

public class DestroyProjectile : MonoBehaviour {

	void Update () {
		if(rigidbody.velocity == Vector3.zero)
			Destroy(gameObject);
	}
	
	void OnCollisionEnter(Collision collider) {
		if(collider.gameObject.tag == "boundary")
			Destroy(gameObject);
	}
}
