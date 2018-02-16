using UnityEngine;
using System.Collections;

public class mouseOver : MonoBehaviour {

	private int canChange = 0;
	Transform obj;
	
	void Update()
	{
		Ray ray = Camera.main.ScreenPointToRay(new Vector3(Camera.mainCamera.pixelWidth/2f, Camera.mainCamera.pixelHeight/2f, 0));
		RaycastHit hit;
			
		if(Physics.Raycast(ray, out hit))
		{
			if(hit.collider.gameObject.tag == "1Block" || hit.collider.gameObject.tag == "2Block" || 
			   hit.collider.gameObject.tag == "3Block" || hit.collider.gameObject.tag == "4Block" || 
			   hit.collider.gameObject.tag == "GrappleMaterial")
			{	
				obj = hit.transform;
				obj.transform.renderer.material.color -= new Color(0, 0, 5F) * Time.deltaTime; //makes the object a yellow
				canChange = 1;
			}	
			
			if(hit.collider.gameObject.tag != obj.gameObject.tag)
			{	
				obj.transform.renderer.material.color = Color.white;
				canChange = 0;
			}	
		}	
		else if(canChange == 1)
		{
			obj.transform.renderer.material.color = Color.white;
		}	
	}
}   