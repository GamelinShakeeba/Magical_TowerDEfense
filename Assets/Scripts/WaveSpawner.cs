using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
	public static int EnemiesAlive = 0;

	public Wave[] waves;

	public Transform spawnPoint;

	public float timeBetweenWaves = 25f;
	private float countdown = 2f;

	private int waveIndex = 0;

	public GameManager gameManager;

	void Update()
	{
		if (EnemiesAlive > 0)
		{
			return;
		}

		if (waveIndex == waves.Length)
		{
			gameManager.WinGame();
			this.enabled = false;
		}

		if (countdown <= 0f)
        {
			StartCoroutine(SpawnWave());
			countdown = timeBetweenWaves;
			return;
		}

		countdown -= Time.deltaTime;
		countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
	}

	IEnumerator SpawnWave()
    {
		PlayerStats.Rounds++;

		Wave wave = waves[waveIndex];

		for (int i = 0; i < wave.count; i++)
		{
			SpawnEnemy(wave.enemy);
			yield return new WaitForSeconds(1f / wave.rate);
		}
		waveIndex++;
	}

	void SpawnEnemy(GameObject enemy)
    {
		Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
	}
}
