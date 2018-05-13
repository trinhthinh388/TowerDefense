using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public Transform EnemyPreFab;
	public Transform SpawnPoint;
	public float TimeBetweenSpawn = 6f;
	public float countdown = 0;
	public int WaveNumbers = 0;
	public Text SpawningText;
	// Use this for initialization
	void Update() {
		if(countdown <= 0)
		{
			StartCoroutine(WaveSpawner());
			countdown = TimeBetweenSpawn;
		}
		countdown -= Time.deltaTime;     
		SpawningText.text = Mathf.Floor(countdown).ToString();

	}


    IEnumerator WaveSpawner()
	{
		WaveNumbers++;
		for (int i = 0; i < WaveNumbers; i++)
		{
			SpawnEnemy();
			yield return new WaitForSeconds(0.5f);
		}
	}

    void SpawnEnemy()
	{
		Instantiate(EnemyPreFab, SpawnPoint.position, SpawnPoint.rotation);
	}
}
