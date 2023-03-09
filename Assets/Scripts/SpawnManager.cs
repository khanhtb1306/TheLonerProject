using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{

    public List<Buff> buffPrefab;

    public List<Enemies> enemiesPrefab;
    public static int totalEnemies = 10;
   
    public List<Weapon> weaponsPrefab;
    public GameObject[] gunPrefabs; 
    // Start is called before the first frame update
    public void BuffSpawn(Transform tf)
    {


        int r = Random.Range(0, 10);
        if (r < 2)
        {
            Instantiate(buffPrefab[Random.Range(0, 3)], tf);
        }
        else if (r < 3)
        {
            Instantiate(buffPrefab[Random.Range(3, 6)], tf);
        }
    }
    void Start()
    {
        //InvokeRepeating("SpawnEnemies", 0f, 10f);
        //InvokeRepeating("SpawnBoss", 50f, 50f);
        SpawnBoss();
    }
    void Update()
    {
    }

    public void SpawnEnemies()
    {
        if (GameManager.instance.isBossAlive == false)
        {
            foreach (var item in enemiesPrefab)
            {
                if (item.enemyType == EnemyType.Bee)
                {
                    for (int i = 0; i < totalEnemies * 0.1; i++)
                    {
                        Instantiate(item.gameObject, Gennerate(), Quaternion.identity);
                    }
                }

                if (item.enemyType == EnemyType.Ant)
                {
                    for (int i = 0; i < totalEnemies * 0.7; i++)
                    {
                        Instantiate(item.gameObject, Gennerate(), Quaternion.identity);
                    }
                }

                if (item.enemyType == EnemyType.Ranged)
                {
                    for (int i = 0; i < totalEnemies * 0.2; i++)
                    {
                        Instantiate(item.gameObject, Gennerate(), Quaternion.identity);
                    }
                }
            }
        }
    }

    public void SpawnBoss()
    {
        foreach (var item in enemiesPrefab)
        {
            if (item.enemyType == EnemyType.Boss)
            {
                GameManager.instance.isBossAlive = true;
                Instantiate(item.gameObject, Gennerate(), Quaternion.identity);
            }
        }
    }


    public void SpawnWeapon(Transform tf)
    {
        int r = Random.Range(0, 10);
        if (r <= 2)
        {
            Instantiate(weaponsPrefab[Random.Range(0, 2)], tf);
        }
        else if (r <= 3)
        {
            Instantiate(weaponsPrefab[Random.Range(0, 3)], tf);
        }

    }
    public Vector3 Gennerate()
    {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        // save screen edges in world coordinates
        float screenZ = -Camera.main.transform.position.z;
        Vector3 lowerLeftCornerScreen = new Vector3(0, 0, screenZ);
        Vector3 upperRightCornerScreen = new Vector3(screenWidth, screenHeight, screenZ);
        Vector3 lowerLeftCornerWorld = Camera.main.ScreenToWorldPoint(lowerLeftCornerScreen);
        Vector3 upperRightCornerWorld = Camera.main.ScreenToWorldPoint(upperRightCornerScreen);
        float screenLeft = lowerLeftCornerWorld.x;
        float screenRight = upperRightCornerWorld.x;
        float screenTop = upperRightCornerWorld.y;
        float screenBottom = lowerLeftCornerWorld.y;
        return new Vector3(Random.Range(screenLeft, screenRight), Random.Range(screenBottom, screenTop), -1);
    }
}