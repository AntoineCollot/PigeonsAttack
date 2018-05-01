using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour {

    public float windStrenght;
    public float noiseFrequency;
    public float windSpeed;

    Vector2 windCoords;

    public static Wind Instance;

	// Use this for initialization
	void Awake () {
        Instance = this;

        windCoords.x = Random.Range(0, 1000);
        windCoords.y = Random.Range(0, 1000);
    }
	
	// Update is called once per frame
	void Update () {
        //windCoords.x += windSpeed * Time.deltaTime;
        windCoords.y += windSpeed * Time.deltaTime;
    }

    public Vector2 GetWindDirection(Vector2 position)
    {
        Vector2 dir = Vector2.zero;
        dir.x = (Mathf.PerlinNoise(position.x * noiseFrequency + windCoords.x, position.y * noiseFrequency + windCoords.y) - 0.5f)*2;
        dir.y = (Mathf.PerlinNoise(position.x * noiseFrequency + windCoords.x+1000, position.y * noiseFrequency + windCoords.y) - 0.5f)*2;
        return dir.normalized;
    }

    public Vector3 GetWind(Vector2 position)
    {
        return GetWindDirection(position) * windStrenght * Time.deltaTime;
    }

}
