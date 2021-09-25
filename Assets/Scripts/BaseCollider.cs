using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Attacker>())
        {
            FindObjectOfType<BaseHealth>().GetHit();
        }
        Destroy(other.gameObject);
    }
}
