using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonDeath : MonoBehaviour {

    public GameObject deathEffect;

	public void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
}
