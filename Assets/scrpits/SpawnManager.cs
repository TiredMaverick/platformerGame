using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    public GameObject RegPlatformPrefab;
    public GameObject DissappearPlatformPrefab;
    public GameObject BrokePlatformPrefab;
    public GameObject PowerupPlatformPrefab;
    [SerializeField] Transform player;

    public int platformCount = 200;
    Vector3 spawnPosition = new Vector3();
    public float platformDistance = 2f;
    public int currentPlatformCount = 0;
    public int maxPlatforms = 100;
    public bool hasBeenRan = false;
    public int totalPlatforms = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        // on start platforms are spawned
        SpawnPlatforms();
    }

    // Update is called once per frame
    void Update()
    {

        if (player.position.y > platformDistance * totalPlatforms - 30 && hasBeenRan == true)
        {
            // spawn new platforms
            SpawnPlatforms();
        }
    }


    void SpawnPlatforms()
    {

        currentPlatformCount = 0;

        while (currentPlatformCount < maxPlatforms)
        {

            spawnPosition.y += platformDistance;
            spawnPosition.x = Random.Range(-5f, 5f);
            ChosenPlatform();
            currentPlatformCount++;
            totalPlatforms++;
        }

        if (currentPlatformCount >= maxPlatforms)
        {

            hasBeenRan = false;
        }

        hasBeenRan = true;
    }


    void ChosenPlatform()
    {

        if (player.position.y <= 500.0f)
        {

            int lowRank = Random.Range(0, 10);
            
            switch (lowRank)
            {
                case 0:
                    Instantiate(RegPlatformPrefab, spawnPosition, Quaternion.identity);
                    break;
                case 1:
                    Instantiate(RegPlatformPrefab, spawnPosition, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(RegPlatformPrefab, spawnPosition, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(RegPlatformPrefab, spawnPosition, Quaternion.identity);
                    break;
                case 4:
                    Instantiate(RegPlatformPrefab, spawnPosition, Quaternion.identity);
                    break;
                case 5:
                    Instantiate(RegPlatformPrefab, spawnPosition, Quaternion.identity);
                    break;
                case 6: 
                    Instantiate(PowerupPlatformPrefab, spawnPosition, Quaternion.identity);
                    break;  
                case 7:
                    Instantiate(BrokePlatformPrefab, spawnPosition, Quaternion.identity);
                    break;
                case 8:
                    Instantiate(DissappearPlatformPrefab, spawnPosition, Quaternion.identity);
                    break;
                case 9:
                    Instantiate(DissappearPlatformPrefab, spawnPosition, Quaternion.identity);
                    break;
                case 10:
                    Instantiate(DissappearPlatformPrefab, spawnPosition, Quaternion.identity);
                    break;
            }
        }

        else if (player.position.y <= 1200.0f)
        {

            int Medium = Random.Range(0, 10);
            switch (Medium)
            {
                case 0:
                    Instantiate(RegPlatformPrefab, spawnPosition, Quaternion.identity);
                    break;
                case 1:
                    Instantiate(RegPlatformPrefab, spawnPosition, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(RegPlatformPrefab, spawnPosition, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(PowerupPlatformPrefab, spawnPosition, Quaternion.identity);
                    break;
                case 4:
                    Instantiate(BrokePlatformPrefab, spawnPosition, Quaternion.identity);
                    break;
                case 5:
                    Instantiate(BrokePlatformPrefab, spawnPosition, Quaternion.identity);
                    break;
                case 6:
                    Instantiate(DissappearPlatformPrefab, spawnPosition, Quaternion.identity);
                    break;  
                case 7:
                    Instantiate(DissappearPlatformPrefab, spawnPosition, Quaternion.identity);
                    break;
                case 8:
                    Instantiate(DissappearPlatformPrefab, spawnPosition, Quaternion.identity);
                    break;
                case 9:
                    Instantiate(DissappearPlatformPrefab, spawnPosition, Quaternion.identity);
                    break;
                case 10:
                    Instantiate(DissappearPlatformPrefab, spawnPosition, Quaternion.identity);
                    break;
            }
        }

        else
        {
         
            int finalWave = Random.Range(0, 10);
            switch (finalWave)
            {
                case 0: 
                    Instantiate(PowerupPlatformPrefab, spawnPosition, Quaternion.identity);
                    break;
                case 1:
                    Instantiate(DissappearPlatformPrefab, spawnPosition, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(DissappearPlatformPrefab, spawnPosition, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(DissappearPlatformPrefab, spawnPosition, Quaternion.identity);
                    break;
                case 4: 
                    Instantiate(DissappearPlatformPrefab, spawnPosition, Quaternion.identity);
                    break;
                case 5:
                    Instantiate(DissappearPlatformPrefab, spawnPosition, Quaternion.identity);
                    break;
                case 6:
                    Instantiate(DissappearPlatformPrefab, spawnPosition, Quaternion.identity);
                    break;
                case 7:
                    Instantiate(DissappearPlatformPrefab, spawnPosition, Quaternion.identity);
                    break;
                case 8:
                    Instantiate(BrokePlatformPrefab, spawnPosition, Quaternion.identity);
                    break;
                case 9:
                    Instantiate(BrokePlatformPrefab, spawnPosition, Quaternion.identity);
                    break;
                case 10:
                    Instantiate(BrokePlatformPrefab, spawnPosition, Quaternion.identity);
                    break;
            }
        }
    }
}