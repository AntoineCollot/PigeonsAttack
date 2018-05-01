using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnLeavingArea : MonoBehaviour {

    public float outOfAreaDestroyTime;
    float timeOutOfArea = 0;

	// Update is called once per frame
	void Update () {
		if(!PlayArea.Instance.Contains(transform.position))
        {
            timeOutOfArea += Time.deltaTime / outOfAreaDestroyTime;

            if (timeOutOfArea >= 1)
                Destroy(gameObject);
        }
	}
}
