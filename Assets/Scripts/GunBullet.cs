using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletStyle
{
    bulletPistol,
    bulletFart,
    bulletStrong,
    Bom,
}

public class GunBullet : MonoBehaviour
{

    public BulletStyle style;

    public float bulletLifeTime = 3f;
    public float damage = 10;
    public float bulletForce;

    public void SetUp()
    {
        switch (style)
        {
            case BulletStyle.bulletPistol:
                damage = 10;
                bulletForce = 25;
                break;
            case BulletStyle.bulletFart:
                damage = 15;
                bulletForce = 40;
                break;
            case BulletStyle.bulletStrong:
                damage = 30;
                bulletForce = 15;
                break;
            case BulletStyle.Bom:
                damage = 100;
                bulletForce = 40;
                break;
        }
    }

    public void Fire(Vector3 direction)
    {

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(direction * bulletForce, ForceMode2D.Impulse);
    }


    void Update()
    {
        DestroyBullet();
    }

    public void DestroyBullet()
    {
        Destroy(gameObject, bulletLifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemies e = collision.gameObject.GetComponent<Enemies>();
        if (e != null)
        {
            e.TakeDamage(damage);
            Destroy(gameObject);
        }
    }

}
