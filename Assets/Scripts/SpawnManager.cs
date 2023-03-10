using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
    private static bool isIntro = true;

    // Start is called before the first frame update
    public void BuffSpawn(Transform tf)
    {

        int r = Random.Range(0, 10);
        if (r < 2)
        {
            Instantiate(GameManager.instance.Buffs[Random.Range(0, 3)], tf.position, Quaternion.identity);
        }
        else if (r < 3)
        {
            Instantiate(GameManager.instance.Buffs[Random.Range(3, 5)], tf.position, Quaternion.identity);
        }
    }
    void Start()
    {
        IntroGame(); 
        InvokeRepeating("SpawnEnemies", 0f, 10f);
        StartCoroutine(SpawnBosses());

    }

    void Update()
    {
        
    }

    public float AmountEnemy(Enemies enemyType)
    {
        return enemyType.popular * GameManager.instance.totalEnemies;
    }

    public void SpawnEnemies()
    {
        foreach (var item in GameManager.instance.Enemies)
        {
            if (item.enemyType != EnemyType.Boss && isIntro == false)
            {
                SpawnEachEnemy(item, AmountEnemy(item));
            }
        }
    }

    public void SpawnEachEnemy(Enemies enemyType, float amount)
    {
        if (GameManager.instance.isBossAlive == false)
        {
            for (int i = 0; i < amount; i++)
            {
                Instantiate(enemyType, Gennerate(), Quaternion.identity);
            }
        }
    }

    public void SpawnBoss()
    {
        foreach (var item in GameManager.instance.Enemies)
        {
            if (item.enemyType == EnemyType.Boss && GameManager.instance.isBossAlive == false && isIntro == false)
            {
                GameManager.instance.isBossAlive = true;
                Instantiate(item.gameObject, Gennerate(), Quaternion.identity);
            }
        }
    }

    private IEnumerator SpawnBosses()
    {
        while (true)
        {
            // Wait until the boss is destroyed
            yield return new WaitUntil(() => isIntro == false);
            yield return new WaitUntil(() => GameManager.instance.isBossAlive == false);

            // Wait for the spawn delay before spawning another boss
            yield return new WaitForSeconds(50);
            SpawnBoss();
        }
    }

    private void IntroGame()
    {
        StartCoroutine(Intro());
    }

    private IEnumerator Intro()
    {
        foreach (var item in GameManager.instance.Enemies)
        {
            if (item.enemyType == EnemyType.Ant)
            {
                SpawnEachEnemy(item, 1);
                GameManager.instance.introControl.SetIntro(0);
            }
        }
        yield return new WaitUntil(() => GameManager.instance.isAntAliveIntro == false);
        Debug.Log("Ant Done");
        foreach (var item in GameManager.instance.Enemies)
        {
            if (item.enemyType == EnemyType.Bee)
            {
                SpawnEachEnemy(item, 1);
                GameManager.instance.introControl.SetIntro(1);
            }
        }
        yield return new WaitUntil(() => GameManager.instance.isBeeAliveIntro == false);
        Debug.Log("Bee Done");

        foreach (var item in GameManager.instance.Enemies)
        {
            if (item.enemyType == EnemyType.Ranged)
            {
                SpawnEachEnemy(item, 1);
                GameManager.instance.introControl.SetIntro(2);

            }
        }
        yield return new WaitUntil(() => GameManager.instance.isRangedAliveIntro == false);
        Debug.Log("Ranged Done");

        foreach (var item in GameManager.instance.Enemies)
        {
            if (item.enemyType == EnemyType.Boss)
            {
                SpawnEachEnemy(item, 1);
                GameManager.instance.introControl.SetIntro(3);

            }
        }
        yield return new WaitUntil(() => GameManager.instance.isBossAlive == false);

        isIntro = false;
    }


    public void SpawnWeapon(Transform tf)
    {
        int r = Random.Range(0, 10);
        if (r <= 2)
        {
            Instantiate(GameManager.instance.Weapons[Random.Range(0, 2)], tf.position, Quaternion.identity);
        }
        else if (r <= 3)
        {
            Instantiate(GameManager.instance.Weapons[Random.Range(0, 3)], tf.position, Quaternion.identity);
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