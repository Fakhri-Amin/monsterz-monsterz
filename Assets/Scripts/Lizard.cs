using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherObject = other.gameObject;

        Defender defender = other.GetComponent<Defender>();
        if (defender)
        {
            GetComponent<Attacker>().Attack(otherObject);
        }
    }
}
