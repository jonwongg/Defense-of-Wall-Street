using UnityEngine;
using System.Collections;

public class handRev : MonoBehaviour {
	
	public float swipeDelay = 10.0f;
	private float timeToSwipe = 0.0f;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(timeToSwipe < Time.time)
		{
			animation.Play("swipeRight");
			timeToSwipe = Time.time + swipeDelay;
		}
	}
}