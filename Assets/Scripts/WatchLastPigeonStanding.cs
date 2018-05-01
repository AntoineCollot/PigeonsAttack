using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchLastPigeonStanding : MonoBehaviour {

    public GameObject endCanvas;
	
	// Update is called once per frame
	void Update () {
        int pigeonAlive = 0;
        foreach(Transform child in transform)
        {
            if(child.gameObject.activeSelf)
            {
                pigeonAlive++;
            }
        }
        if (pigeonAlive <= 1)
        {
            endCanvas.SetActive(true);
            GetComponentInChildren<Collider2D>().enabled = false;
        }
	}
}
