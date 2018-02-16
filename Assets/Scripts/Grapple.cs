using UnityEngine;
using System.Collections;

public class Grapple : MonoBehaviour
{
    public float grappleSpeed = 100.0f;
    private Vector3 currentHeading,targetHeading;
    private Transform xform;
	private bool latched = false;
	RaycastHit grappleTarget;
	CharacterMotor nameless;
	private float storeGrav;
   
    // Use this for initialization
    void Start ()
    {
        xform = transform;
        currentHeading = xform.forward;
		nameless = GetComponent<CharacterMotor>();
    }
   
   
    // moves us along current heading
    void Update()
    {
		if(Input.GetButtonDown("Grapple"))
		{
			Ray ray = Camera.main.ScreenPointToRay(new Vector3(Camera.mainCamera.pixelWidth/2f, Camera.mainCamera.pixelHeight/2f, 0));
			RaycastHit hit;
			
			if(Physics.Raycast(ray, out hit))
			{
				if(hit.collider.gameObject.tag == "GrappleMaterial")
				{	
					latched = true;
					grappleTarget = hit;
				}
			}
		}
		
		if(latched)
		{
//			storeGrav = nameless.GetGravity();
			nameless.SetGravity(0.0f);
//			storeGrav = nameless.gravity;
//			nameless.gravity = 0.0f;
			if(Vector3.Distance(xform.position, grappleTarget.collider.gameObject.transform.position) >= 12.0f)
			{
				targetHeading = grappleTarget.transform.position - xform.position;
//		        currentHeading = Vector3.Lerp(currentHeading, targetHeading, Time.deltaTime);
				currentHeading = targetHeading;
		        xform.position += currentHeading.normalized * Time.deltaTime * grappleSpeed;
			}
			
			else
			{
				latched = false;
				nameless.SetGravity(30.0f);
//				nameless.gravity = storeGrav;
			}
		}
    }
}