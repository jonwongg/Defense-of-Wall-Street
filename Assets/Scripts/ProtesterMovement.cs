using UnityEngine;
using System.Collections;

public class ProtesterMovement : MonoBehaviour
{
	public Transform[] pathA;
	public Transform[] pathB;
	public int numberOfPaths = 2;
	
    public bool loop = false;
    public float speed = 2.0f;
	
	private Transform[] waypoints;
    private Vector3 currentHeading,targetHeading;
    private int targetwaypoint;
//	private Transform xform;

    void Start ()
    {
//        xform = transform;
//        currentHeading = xform.forward;
		currentHeading = transform.forward;
        targetwaypoint = 0;
		if(Random.Range(0, numberOfPaths) == 0)
			waypoints = pathA;
		
		else
			waypoints = pathB;
    }
	
    // moves us along current heading
    void Update()
    {
//		targetHeading = waypoints[targetwaypoint].position - xform.position;
		targetHeading = waypoints[targetwaypoint].position - transform.position;
        currentHeading = Vector3.Lerp(currentHeading,targetHeading,Time.deltaTime);
//        xform.position += currentHeading.normalized * Time.deltaTime * speed;
//		xform.LookAt(xform.position + currentHeading);
		transform.position += currentHeading.normalized * Time.deltaTime * speed;
		transform.LookAt(transform.position + currentHeading);
		
//		if(Vector3.Distance(xform.position,waypoints[targetwaypoint].position)<= 3.0f)
		if(Vector3.Distance(transform.position, waypoints[targetwaypoint].position) <= 3.0f)
        {
            targetwaypoint++;			
            if(targetwaypoint == waypoints.Length)
            {
//				xform.position += new Vector3(Random.Range(-12.0f, 12.0f), 0, Random.Range(-12.0f, 12.0f));
				transform.position += new Vector3(Random.Range(-12.0f, 12.0f), 0, Random.Range(-12.0f, 12.0f));
                enabled = false;
            }
        }
    }
/*	
	void SetSpeed(float newSpeed)
	{
		speed = newSpeed;
	}
	*/
}