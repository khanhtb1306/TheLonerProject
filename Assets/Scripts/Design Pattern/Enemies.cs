//using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

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
    public EnemyType enemyType;
    public float currentHealth;
    public float maxHealth;
    public float damage;
    public float movementSpeed;
    public float attackSpeed = 0;
    public bool isBossAlive;
    public bool isAlive;
    public bool isHunt;
    Vector3 endPoint;


    void Start()
    {
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
                movementSpeed= 5;
                break;
            case EnemyType.Ranged:
                maxHealth = 40;
                damage = 15;
                movementSpeed = 20;
                break;
            case EnemyType.Bee:
                maxHealth = 20;
                damage = 20;
                movementSpeed = 15;
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

    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            isAlive = false;
            Destroy(gameObject);
        }
    }

    public void Hunt(Player player, float MovementSpeed)
    {
        transform.position = Vector3.MoveTowards(transform.position,
            player.transform.position, MovementSpeed * Time.deltaTime);
    }

    public void AttackPlayer()
    {
        switch(enemyType)
        {
            case EnemyType.Ant:
                break;
            case EnemyType.Ranged:
                break;
            case EnemyType.Bee:
                break;
            case EnemyType.Boss:
                break;
        }
    }

    public void Patrol()
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
        return new Vector3(Random.Range(screenLeft, screenRight), Random.Range(screenBottom, screenTop), -Camera.main.transform.position.z);
    }


    //Check event takeDamage
    public void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    public void Death()
    {
        SpawnManager spawn = new SpawnManager();
        spawn.BuffSpawn(this.transform);
        Destroy(this.gameObject);

    }
}
