using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstSpawner : MonoBehaviour
{
    public GameObject[] prefabs;
    public static float speed = 10f;

    void Start()
    {

        // aysnchronous infinite skyscraper spawning
        StartCoroutine(SpawnObstacles());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {

            // create a new obstacle from prefab selection at right edge of screen
            Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(20, -4, 0),
                Quaternion.identity);

            // randomly increase the speed by 1
            if (Random.Range(1, 4) == 1)
            {
                speed += 1f;
            }

            // wait between 1-5 seconds for a new skyscraper to spawn
            yield return new WaitForSeconds(Random.Range(1, 5));
        }
    }
}
