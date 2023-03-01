//using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public enum EnemyType
{
    Ant, 
    Ranged, 
    Bee, 
    Boss
}
public class Enemies : MonoBehaviour
{
    //Attribute and Property
    [SerializeField] public GameObject explosivePrefabs;

    public EnemyType enemyType;
    public float currentHealth;
    public float maxHealth;
    public int damage;
    public float movementSpeed;
    public float attackSpeed = 0;
    public bool isBossAlive;
    public bool isAlive;
    public bool isHunt;
    Vector3 endPoint;
    public Player player;
    public List<BulletEnemies> bulletPrefabs;
    Timer timer;

    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        SetUp();
        currentHealth = maxHealth;
        isAlive = true;
        isBossAlive = false;
        isHunt = false;
        endPoint = Gennerate();
    }

    public void SetUp()
    {
        switch(enemyType)
        {
            case EnemyType.Ant:
                maxHealth = 50;
                damage = 5;
                movementSpeed= 1;
                break;
            case EnemyType.Ranged:
                maxHealth = 40;
                damage = 15;
                movementSpeed = 5;
                break;
            case EnemyType.Bee:
                maxHealth = 20;
                damage = 20;
                movementSpeed = 1;
                attackSpeed= 50;
                break;
            case EnemyType.Boss:
                maxHealth = 50;
                damage = 5;
                movementSpeed = 20;
                break;
        }
    }
    void Update()
    {
        if (enemyType == EnemyType.Ant)
        {
            Hunt(GameManager.instance.player.transform.position, movementSpeed);
        }

        if (enemyType == EnemyType.Ranged)
        {
            Patrol();
        } 

        if (enemyType == EnemyType.Bee)
        {
            Patrol();
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            isAlive = false;
            isBossAlive = false;
            Destroy(gameObject);
        }
    }

    public void Hunt(Vector3 player, float MovementSpeed)
    {
        if (enemyType == EnemyType.Ant)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                        player, MovementSpeed * Time.deltaTime);
        }
        if (enemyType == EnemyType.Ranged)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                        player, MovementSpeed * Time.deltaTime);
        }
        Vector3 po = player;
        if (enemyType== EnemyType.Bee)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                       po, MovementSpeed * Time.deltaTime);
        }

        if (enemyType == EnemyType.Boss)
        {

        }
    }


    public void AttackPlayer()
    {
        switch(enemyType)
        {
            case EnemyType.Ranged: //sau 0.5s bắn đạn
                timer.Duarion = 0.5f;
                timer.Run();
                if (timer.Finished) //kiểm tra thơi gian finished
                {
                    foreach (var item in bulletPrefabs)
                    {
                        if (item.typeBullet == BulletType.Ranged)
                        {
                            GameObject bur = Instantiate(item.gameObject);
                            bur.GetComponent<Rigidbody2D>().AddForce(GameManager.instance.player.transform.position * 9f, ForceMode2D.Impulse);
                            timer.Duarion = 1;
                            timer.Run();
                        }
                    }
                }
                break;
            case EnemyType.Bee:
                player.TakeDamge(damage);
                break;
            case EnemyType.Boss:
                break;
        }
    }

    public void Patrol()
    {
        if (enemyType == EnemyType.Bee)
        {
            if (Vector3.Distance(transform.position, GameManager.instance.player.transform.position) < 10f)
            {
                Hunt(GameManager.instance.player.transform.position, movementSpeed);
            }
        } else
        {
            Vector2 dir = endPoint - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = rotation;

            transform.position = Vector3.MoveTowards(transform.position, endPoint, 10 * Time.deltaTime);
            if (Vector3.Distance(transform.position, endPoint) < 0.001f)
            {
                endPoint = Gennerate();
            }
        }   
    }

    public Vector3 Gennerate()
    {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
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

    //Check event takeDamage
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            if(enemyType == EnemyType.Bee)
            {
                AttackPlayer();
                Destroy(gameObject);
            }

            if (enemyType == EnemyType.Ant)
            {
                AttackPlayer();
            }
        }
        if (collision.gameObject.tag == "Bullet")
        {
            TakeDamage(10);
        }
    }
}
