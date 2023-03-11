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
    [SerializeField]
    public GameObject explosivePrefab;
    public BulletType typeBullet;
    public float damage;
    private Rigidbody2D rb2D;

    private void Awake()
    {
        SetUp();
        rb2D = GetComponent<Rigidbody2D>();
    }

    public void SetUp()
    {
        switch (typeBullet)
        {
            case BulletType.Ranged:
                damage = 15f;
                break;
            case BulletType.Boss:
                damage = 20f;
                break;
        }
    }

    void Update()
    {
    }

    public void Project(Vector3 direction)
    { 
        rb2D.velocity = direction * 10f * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null )
        {
            Destroy(gameObject);
            Debug.Log("Da huy RangedBullet");
            GameManager.instance.player.TakeDamge(damage);
        }
    }
}
