using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 20;
    private float spawnPosZ = 20;
    private float spawnRangeZ = 15;
    private float spawnPosLeft = -30;
    private float spawnPosRight = 30;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimalFront", startDelay, spawnInterval);
        //InvokeRepeating("SpawnRandomAnimalLeft", startDelay, spawnInterval);
        //InvokeRepeating("SpawnRandomAnimalRight", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            SpawnRandomAnimalFront();
            SpawnRandomAnimalLeft();
            SpawnRandomAnimalRight();
        }
    }

    void SpawnRandomAnimalFront()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Instantiate(animalPrefabs[animalIndex], spawnPos,
            animalPrefabs[animalIndex].transform.rotation);
    }

    void SpawnRandomAnimalLeft()
    {
        Vector3 spawnPos = new Vector3(spawnPosLeft, 0, Random.Range(0, spawnRangeZ));

        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(0, 90, 0)
            );// animalPrefabs[animalIndex].transform.rotation + Quaternion.Euler(0, 90, 0)
    }

    void SpawnRandomAnimalRight()
    {
        Vector3 spawnPos = new Vector3(spawnPosRight, 0, Random.Range(0, spawnRangeZ));

        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(0, -90, 0)
            );// animalPrefabs[animalIndex].transform.rotation + Quaternion.Euler(0, -90, 0)
    }
}
