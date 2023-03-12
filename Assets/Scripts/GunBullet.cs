using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBullet : MonoBehaviour
{
    public float bulletLifeTime = 3f;
    public float damage = 10;
    // Update is called once per frame
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
