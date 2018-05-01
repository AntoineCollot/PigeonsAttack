using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoop : MonoBehaviour {

    public float poopTimeInterval;
    float nextAllowedPoopTime;

    public GameObject poopPrefab;

    PlayerInputs playerInputs;

    new AudioSource audio;

	// Use this for initialization
	void Awake () {
        playerInputs = GetComponent<PlayerInputs>();
        audio = GetComponent<AudioSource>();
    }

    void Start()
    {
        playerInputs.onAPressed.AddListener(TryPooping);
    }
	
	public void TryPooping()
    {
        if (Time.time < nextAllowedPoopTime)
            return;

        Poop();
    }

    IEnumerator VibrateIn(float delay)
    {
        yield return new WaitForSeconds(delay);

        playerInputs.Vibrate();
    }

    public void Poop()
    {
        GameObject poop = Instantiate(poopPrefab, transform.position, Quaternion.identity);
        poop.tag = tag;
        nextAllowedPoopTime = Time.time + poopTimeInterval;
        audio.Play();

        StartCoroutine(VibrateIn(poopTimeInterval));
    }
}
