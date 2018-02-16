using UnityEngine;
using System.Collections;

public class protesterSpawn : MonoBehaviour {
	
	public Transform spawnPoint;
	public Transform[] mobToSpawn;
	public int numberOfUniqueMobs = 2;
	public float streetWidth = 8.5f;
	public int numberOfMobsToSpawn = 10;
	public float spawnRate = 3.0f;
	private float nextMobSpawn = 0.0f;
	
	void Update () {
		if(numberOfMobsToSpawn > 0)
		{
			if(nextMobSpawn < Time.time)
			{
				spawnMob();
				nextMobSpawn = Time.time + spawnRate;
				numberOfMobsToSpawn--;
			}
		}
	}
	
	void spawnMob()
	{
		float deviateSpawnPosition = Random.Range(-(streetWidth/2.0f), streetWidth/2.0f);
		Vector3 spawnPos = transform.position + new Vector3(deviateSpawnPosition, 0, 0);
		Instantiate(mobToSpawn[Random.Range(0, numberOfUniqueMobs)], spawnPos, transform.rotation);
	}
}
