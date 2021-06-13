using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelSpawner : MonoBehaviour
{
    public GameObject barrel;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;

    private Transform right,left;

    // Start is called before the first frame update
    void Start()
    {
        
        right = gameObject.transform.GetChild(0);
        left = gameObject.transform.GetChild(1);
        StartCoroutine(WaveSpawnRight());
        StartCoroutine(WaveSpawnLeft());
    }

    public void SpawnObjectRight()
    {
        Instantiate(barrel, right.transform.position, right.transform.rotation);
    }
    public void SpawnObjectLeft()
    {
        Instantiate(barrel, left.transform.position, left.transform.rotation);
    }
    IEnumerator WaveSpawnRight()
    {
        while (!stopSpawning)
        {
            SpawnObjectRight();
            yield return new WaitForSeconds(3);
        }
    }
    IEnumerator WaveSpawnLeft()
    {
        while (!stopSpawning)
        {
            SpawnObjectLeft ();
            yield return new WaitForSeconds(1.5f);
        }
    }
}
