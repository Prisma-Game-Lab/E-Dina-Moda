using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SobrinhosSpawner : MonoBehaviour
{
    public GameObject[] prefabs;
    public static float speed = 10f;

    private int inverter = 0;
    private Vector3 pos;

    void Start()
    {

        // aysnchronous infinite skyscraper spawning
        StartCoroutine(SpawnSobrinhos());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnSobrinhos()
    {
        while (true)
        {
            inverter = Random.Range(0, 2);
            pos = this.transform.position + new Vector3(20, 0, 0);

            // create a new sobrinho from prefab selection at right edge of screen
            Instantiate(prefabs[Random.Range(0, prefabs.Length)], pos,
                Quaternion.identity);

            // randomly increase the speed by 1
            if (Random.Range(1, 4) == 1)
            {
                speed += 1f;
            }

            // wait between 1-5 seconds for a new sobrinho to spawn
            yield return new WaitForSeconds(10);
        }
    }
}
