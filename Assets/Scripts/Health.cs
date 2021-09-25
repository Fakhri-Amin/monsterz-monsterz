using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float currentHealth = 200;
    [SerializeField] GameObject explotionPrefab;

    public void DealDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            TriggerDeathEffect();
        }
    }

    private void TriggerDeathEffect()
    {
        if (explotionPrefab)
        {
            GameObject explotion = Instantiate(explotionPrefab, transform.position, transform.rotation);
            Destroy(explotion, 2.1f);
        }
    }
}
