using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 5f;
    [SerializeField] int damage = 100;

    void Update()
    {
        transform.Translate(Vector2.right * projectileSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Health health = other.GetComponent<Health>();
        Attacker attacker = other.GetComponent<Attacker>();

        if (health && attacker)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }
    }
}
