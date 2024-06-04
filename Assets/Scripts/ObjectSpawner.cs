using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public bool spawn = true;
    public GameObject prefab;
    public float spawnRate = 5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while(spawn)
        {
            Instantiate(prefab, transform.position, transform.rotation);
            yield return new WaitForSeconds(spawnRate);
        }
    }
}
