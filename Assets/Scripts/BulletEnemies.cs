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
    private Rigidbody2D rb2D;

    private void Awake()
    {
        SetUp();
        rb2D = GetComponent<Rigidbody2D>();
        //Physics2D.gravity = new Vector2(0, 0);
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

    public void Project(Vector3 direction)
    {
        //rb2D.AddForce(direction * 9f * Time.deltaTime);
        //Destroy(gameObject, 10f);
        rb2D.velocity = direction * 1f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
