using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletType
{
    Ranged, 
    Boss
}

public class BulletEnemies : MonoBehaviour
{
    //Attribute and Property
    [SerializeField] 
    public GameObject explosivePrefab;
    public BulletType typeBullet;
    public float damage;
    public Enemies enemies;
    public GameObject head;

    void Start()
    {
        SetUp(); 
        GetComponent<Rigidbody2D>().AddForce(
            head.transform.position, ForceMode2D.Impulse);
    }

    public void SetUp()
    {
        switch(typeBullet)
        {
            case BulletType.Ranged:
                damage = 15f;
                break;
            case BulletType.Boss:
                damage = 20f;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        Instantiate(explosivePrefab, transform.position, Quaternion.identity);
    //        Destroy(gameObject);
    //    }  
    //}

    //public void Project(Vector3 direction)
    //{
    //    rigidbody2D.AddForce(direction * speedBullet * Time.deltaTime);
    //    Destroy(gameObject, maxLifeTime);
    //}

    //private void OnBecameInvisible()
    //{
    //    Destroy(gameObject);
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(explosivePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void AttackPlayer()
    {

    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
