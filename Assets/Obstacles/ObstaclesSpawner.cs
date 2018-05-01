using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpawner : MonoBehaviour {

    public Vector2 spawnArea;

    public float spawnRateIncrease;
    public float maxSpawnRate;
    float spawnRate;

    public GameObject[] prefabs;

	// Update is called once per frame
	void Update () {
        spawnRate += spawnRateIncrease * Time.deltaTime;
        spawnRate = Mathf.Clamp(spawnRate, 0, maxSpawnRate);

		if(Random.Range(0,1.0f)< spawnRate * Time.deltaTime)
        {
            SpawnObstacle();
        }
	}

    public void SpawnObstacle()
    {
        Vector3 position = GetRandomSpawningPosition();
        Instantiate(prefabs[Random.Range(0, prefabs.Length)], position, Quaternion.identity);
    }

    public Vector3 GetRandomSpawningPosition()
    {
        int rand = Random.Range(0, 4);
        Vector3 pos = Vector3.zero;

        switch (rand)
        {
            case 0:
                pos.x = -spawnArea.x;
                pos.y = Random.Range(-spawnArea.y, spawnArea.y);
                break;
            case 1:
                pos.x = spawnArea.x;
                pos.y = Random.Range(-spawnArea.y, spawnArea.y);
                break;
            case 2:
                pos.y = -spawnArea.y;
                pos.x = Random.Range(-spawnArea.x, spawnArea.x);
                break;
            case 3:
                pos.y = spawnArea.y;
                pos.x = Random.Range(-spawnArea.x, spawnArea.x);
                break;
            default:
                pos = Vector3.zero;
                break;
        }

        return pos;
    }

#if UNITY_EDITOR
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(Vector3.zero, spawnArea * 2);
    }
#endif
}
