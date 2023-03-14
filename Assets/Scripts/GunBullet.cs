using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletStyle
{
    bulletPistol,
    bulletFast,
    bulletStrong,
    Bom,
}

public class GunBullet : MonoBehaviour
{

    public BulletStyle style;

    public float bulletLifeTime = 2f;
    public float damage = 10;



    public void Fire(Vector3 direction, float bulletForce)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(direction * bulletForce, ForceMode2D.Impulse);
    }


    void Start()
    {
        DestroyBullet(bulletLifeTime);
    }

    void DestroyBullet(float Time)
    {
        switch (style)
        {
            case BulletStyle.bulletPistol:
                Destroy(gameObject, Time);
                break;
            case BulletStyle.bulletFast:
                Destroy(gameObject, Time);
                break;
            case BulletStyle.bulletStrong:
                StrongUltimateBullet(Time);
                break;
            case BulletStyle.Bom:
                Destroy(gameObject, Time);
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemies e = collision.gameObject.GetComponent<Enemies>();
        if (e != null)
        {
            e.TakeDamage(damage);
            DestroyBullet(0f);
        }
    }

    public void StrongUltimateBullet(float time)
    {

        StartCoroutine(FireBulletsStrong(time));

    }

    private IEnumerator FireBulletsStrong(float time)
    {
        yield return new WaitForSeconds(time);
        GunBullet extraBullet = GameManager.instance.Bullet[0];
        float halfConeAngle = (10 - 1) * 10f / 2f;
        //Vector2 direction = transform.right;

        GetComponent<Rigidbody2D>().velocity = transform.up * 0;

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                float angle = j * 36f - halfConeAngle;
                Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                Vector2 rotatedDirection = rotation * transform.up;
                GunBullet bullet = Instantiate(extraBullet, transform.position, Quaternion.identity);
                bullet.Fire(rotatedDirection, 10f);
            }
            yield return new WaitForSeconds(0.1f);
        }
        Destroy(gameObject);

    }




   

    //private IEnumerator FireBulletsStrong()
    //{
    //    yield return new WaitForSeconds(1f);
    //    float halfConeAngle = (10 - 1) * 10f / 2f;
    //    Vector2 direction = transform.right;

    //    GetComponent<Rigidbody2D>().velocity = direction * 15;

    //    for (int i = 0; i < 10; i++)
    //    {
    //        for (int j = 0; j < 10; j++)
    //        {
    //            float angle = j * 36f - halfConeAngle;
    //            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    //            Vector2 rotatedDirection = rotation * direction;
    //            GameObject spawnedBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    //            spawnedBullet.GetComponent<Rigidbody2D>().velocity = rotatedDirection * 15;
    //        }
    //        yield return new WaitForSeconds(0.1f);
    //    }
    //}

}
