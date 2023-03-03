using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<Buff> buffPrefab;
    Vector3 endPoint;
    public List<Enemies> enemiesPrefab;
    public static int totalEnemies = 10;
    Timer timer;
    public List<Weapon> weaponsPrefab;
    // Start is called before the first frame update
    public void BuffSpawn(Transform tf)
    {
       
        int a = Random.Range(0, 10);
        Debug.Log(a);
        if(a <= 2) {
        
        }else if ( a <= 3)
        {
            Instantiate(buffPrefab[Random.Range(3, 5)],tf);
        }
        int r = Random.Range(0, 10);
        if(r <= 2)
        {
            Instantiate(buffPrefab[(Random.Range(0, 2)],tf);
        }
    }
    void Start()
    {
        InvokeRepeating("BuffSpawn", 0f, 3f);
        SpawnEnemies();
        timer = gameObject.AddComponent<Timer>();
        timer.Duarion = 2;
        timer.Run();
    }
    void Update()
    {
        endPoint = Gennerate();
        
    }

    public void SpawnEnemies()
    {
        if (true)
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
        //Enemies.isBossAlive = true;
        foreach (var item in enemiesPrefab)
        {
            if (item.enemyType == EnemyType.Boss)
            {
                Instantiate(item.gameObject, Gennerate(), Quaternion.identity);
            }
        }
    }

    public void UpGradeAttribute()
    {
        //Enemies.maxHealth += float.Parse((Enemies.maxHealth * 0.2).ToString());
        //totalEnemies += int.Parse((totalEnemies * 0.2).ToString());
        //Enemies.damage += float.Parse((Enemies.damage * 0.2).ToString());

    }
    public void SpawnWeapon()
    {

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
