using UnityEngine;
using System.Collections;

public class WaveControl : MonoBehaviour {
	
	protesterSpawn pSpawn;
	public float waveTime;
	public static int Finished = 0;
	private float nextWaveTime;
	private int wave;
	public int numberOfWaves = 10;
	
	void Start () {
		pSpawn = GetComponent<protesterSpawn>();
		waveTime = 90.0f;
		nextWaveTime = waveTime + Time.time;
		wave = 1;
	}
	
	void Update () {
		if(numberOfWaves > 0)
		{
			if(nextWaveTime < Time.time)
			{
				SpawnWave(wave);
				nextWaveTime = Time.time + waveTime;
				numberOfWaves--;
				wave++;
			}
		}
		
		if(Finished == 30)
		{
			Application.LoadLevel("LoseScreen");
			Finished = 0;
		}
	}
			
			
			
	void SpawnWave(int waveNumber)
	{
		switch(waveNumber)
		{
		case 1:
			pSpawn.numberOfMobsToSpawn = 10;
			pSpawn.spawnRate = 4.75f;
			break;
		case 2:
			pSpawn.numberOfMobsToSpawn = 20;
			pSpawn.spawnRate = 3.0f;
			break;
		case 3:
			pSpawn.numberOfMobsToSpawn = 30;
			pSpawn.spawnRate = 2.5f;
			break;
		case 4:
			pSpawn.numberOfMobsToSpawn = 40;
			pSpawn.spawnRate = 2.0f;
			break;
		case 5:
			pSpawn.numberOfMobsToSpawn = 50;
			pSpawn.spawnRate = 1.90f;
			break;
		case 6:
			pSpawn.numberOfMobsToSpawn = 55;
			pSpawn.spawnRate = 1.90f;
			break;
		case 7:
			pSpawn.numberOfMobsToSpawn = 60;
			pSpawn.spawnRate = 1.75f;
			break;
		case 8:
			pSpawn.numberOfMobsToSpawn = 65;
			pSpawn.spawnRate = 1.50f;
			break;
		case 9:
			pSpawn.numberOfMobsToSpawn = 70;
			pSpawn.spawnRate = 1.50f;
			break;
		case 10:
				pSpawn.numberOfMobsToSpawn = 75;
			pSpawn.spawnRate = 1.30f;
			break;
		case 11:
				pSpawn.numberOfMobsToSpawn = 75;
			pSpawn.spawnRate = 1.30f;
			break;
		case 12:
				pSpawn.numberOfMobsToSpawn = 80;
			pSpawn.spawnRate = 1.30f;
			break;
		case 13:
				pSpawn.numberOfMobsToSpawn = 80;
			pSpawn.spawnRate = 1.25f;
			break;
		case 14:
				pSpawn.numberOfMobsToSpawn = 80;
			pSpawn.spawnRate = 1.2f;
			break;
		case 15:
				pSpawn.numberOfMobsToSpawn = 85;
			pSpawn.spawnRate = 1.15f;
			break;
		case 16:
				pSpawn.numberOfMobsToSpawn = 85;
			pSpawn.spawnRate = 1.1f;
			break;
		case 17:
				pSpawn.numberOfMobsToSpawn = 90;
			pSpawn.spawnRate = 1.0f;
			break;
		case 18:
				pSpawn.numberOfMobsToSpawn = 95;
			pSpawn.spawnRate = 1.0f;
			break;
		case 19:
				pSpawn.numberOfMobsToSpawn = 100;
			pSpawn.spawnRate = 1.0f;
			break;
		case 20:
			pSpawn.numberOfMobsToSpawn = 100;
			pSpawn.spawnRate = 0.95f;
			break;
		}
	}
}
