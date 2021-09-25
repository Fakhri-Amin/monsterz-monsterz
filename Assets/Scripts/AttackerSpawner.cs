
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] float startTime = 4f;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attacker[] attackerPrefabs;
    private int randomAttacker;

    private bool spawn = true;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(startTime);
        while (spawn)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    private void SpawnAttacker()
    {
        randomAttacker = Random.Range(0, attackerPrefabs.Length);
        Attacker newAttacker = Instantiate(attackerPrefabs[randomAttacker], transform.position, transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }
}
