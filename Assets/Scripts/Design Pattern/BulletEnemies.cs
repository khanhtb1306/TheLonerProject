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
    public GameObject rangedBulletPrefab;
    [SerializeField] 
    public GameObject explosivePrefab;
    public BulletType typeBullet;
    private Rigidbody2D rigidbody2D;
    public float maxLifeTime;
    public float speedBullet;

    void Start()
    {
        SetUp();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void SetUp()
    {
        switch(typeBullet)
        {
            case BulletType.Ranged:
                maxLifeTime = 10.0f;
                speedBullet = 50.0f;
                break;
            case BulletType.Boss:
                maxLifeTime = 20.0f;
                speedBullet = 50.0f;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "")
        {
            Instantiate(explosivePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }  
    }

    public void Project(Vector3 direction)
    {
        rigidbody2D.AddForce(direction * speedBullet * Time.deltaTime);
        Destroy(gameObject, maxLifeTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
