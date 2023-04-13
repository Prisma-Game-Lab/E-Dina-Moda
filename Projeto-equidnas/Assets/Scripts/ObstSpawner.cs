using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstSpawner : MonoBehaviour
{
    public GameObject[] prefabs;
    public static float speed = 10f;

    private int inverter = 0;
    private Vector3 pos;
    private int index;
    private int maxTime;

    void Start()
    {
        maxTime = 6;
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
            inverter = Random.Range(-1, 1);
            if (inverter == 0) { inverter = 1; }

            pos = this.transform.position + new Vector3(20, 0, 0);

            index = Random.Range(0, prefabs.Length);

            if (index == 0)
            {
                pos = this.transform.position + new Vector3(20, 0, 0);
            } else if (index == 1)
            {
                pos = this.transform.position + new Vector3(20, 1.5f * inverter, 0);
            }
            // create a new obstacle from prefab selection at right edge of screen
            Instantiate(prefabs[index], pos, Quaternion.identity);

            // randomly increase the speed by 1
            if (Random.Range(1, 4) == 1)
            {
                speed += 1f;
            }

            if (Random.Range(1,5) == 1)
            {
                maxTime--;
                maxTime = Mathf.Max(2, maxTime);
            }

            // wait between 1-5 seconds for a new skyscraper to spawn
            yield return new WaitForSeconds(Random.Range(1, maxTime));
        }
    }
}
