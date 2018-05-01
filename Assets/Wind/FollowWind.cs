using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWind : MonoBehaviour {
	
	// Update is called once per frame
	void LateUpdate () {
        transform.Translate(Wind.Instance.GetWind(transform.position), Space.World);
	}
}
