using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour {

    public float maxRotation;
    float rot;

	// Use this for initialization
	void Start () {
        rot = Random.Range(-maxRotation, maxRotation);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.forward * rot * Time.deltaTime);
	}
}
