using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Gravestone>())
        {
            GetComponent<Animator>().SetTrigger("jumpTrigger");
        }
        else if (other.gameObject.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(other.gameObject);
        }
    }
}
