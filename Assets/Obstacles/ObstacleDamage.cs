using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDamage : MonoBehaviour {


    void OnTriggerEnter2D(Collider2D other)
    {
        other.SendMessage("Die");
    }
}
