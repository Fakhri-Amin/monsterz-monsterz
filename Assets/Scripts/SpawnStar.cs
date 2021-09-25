using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStar : MonoBehaviour
{
    public GameObject starPrefab;

    public void SpawnStars()
    {
        Vector3 offset = new Vector3(0.2f, 0.3f, 0);
        Instantiate(starPrefab, transform.position - offset, transform.rotation);
    }
}
