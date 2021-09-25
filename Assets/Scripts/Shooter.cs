using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("Shooter")]
    [SerializeField] GameObject projectile;
    [SerializeField] Transform firePoint;

    private AttackerSpawner myLaneSpawner;
    private Animator animator;

    private GameObject projectileParent;
    const string PROECTILE_PARENT_NAME = "Projectiles";

    private void Start()
    {
        animator = GetComponent<Animator>();
        SetLaneSpawner();
        CreateProjectileParent();
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROECTILE_PARENT_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROECTILE_PARENT_NAME);
        }
    }

    private void Update()
    {
        if (IsAttackerInLane())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawners)
        {
            // bool isCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            bool isCloseEnough = (Mathf.Approximately(spawner.transform.position.y, Mathf.Floor(transform.position.y)));
            if (isCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void Fire()
    {
        GameObject newProjectile = Instantiate(projectile, firePoint.transform.position, transform.rotation);
        newProjectile.transform.parent = projectileParent.transform;
    }
}
