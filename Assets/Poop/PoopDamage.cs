using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopDamage : MonoBehaviour {

    public float activationDelay;

    public float hitOwnerDelay;
    bool hitOwner = false;

	// Use this for initialization
	void Start () {
        Invoke("ActivateCollider", activationDelay);
        Invoke("StartHittingOwner", hitOwnerDelay);
    }

    void StartHittingOwner()
    {
        hitOwner = true;
    }

    void ActivateCollider()
    {
        GetComponent<Collider2D>().enabled = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!hitOwner && tag == other.tag)
            return;

        other.SendMessage("Die");
        Destroy(gameObject);
    }
}
