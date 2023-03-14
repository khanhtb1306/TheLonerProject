using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletStyle
{
    BulletPistol,
    BulletFast,
    BulletStrong,
    Bom,
}

public class GunBullet : MonoBehaviour
{
    public float bulletLifeTime = 3f;
    public float damage = 10;
    // Update is called once per frame

    public float bulletForce = 10;

    public void Fire()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);
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
