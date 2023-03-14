using System.Collections;
using UnityEngine;

public enum WeaponStyle
{
    Pistol,
    FartGun,
    StrongGun,
    Bom,
}
public class Weapon : MonoBehaviour
{
    public WeaponStyle style;
    public float quantity;
    public GunBullet normalBullet;
    public GunBullet ultiBullet;

    public float bulletForce;
    public float ultimateBulletSpeed = 20f;
    public float missileSpeed = 10f;
    public float explosionRadius = 5f;

    public void SetUp()
    {
        switch (style)
        {
            case WeaponStyle.Pistol:
                quantity = 20;
                break;
            case WeaponStyle.FartGun:
                quantity = 20;
                break;
            case WeaponStyle.StrongGun:
                quantity = 20;
                break;
            case WeaponStyle.Bom:
                quantity = 20;
                break;
        }
    }

    public void Shoot(Vector2 direction)
    {
        GunBullet bullet = Instantiate(normalBullet, transform.position, Quaternion.identity);
        bullet.Fire(direction,bulletForce);
    }

    public void UltiShoot(Vector2 direction)
    {

        switch (style)
        {
            case WeaponStyle.Pistol:
                break;
            case WeaponStyle.FartGun:
                FastGunUlti();
                break;
            case WeaponStyle.StrongGun:
                StronngShotUlti(direction);
                break;
            case WeaponStyle.Bom:
                break;
        }
        
    }

    public void StronngShotUlti(Vector2 direction)
    {
        GunBullet bullet = Instantiate(ultiBullet, transform.position, Quaternion.identity);
        bullet.Fire(direction, bulletForce);
    }
    public void FastGunUlti()
    {
        StartCoroutine(FireBulletsInCone());
    }

    //public void ShootPistol()
    //{
    //    GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    //    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
    //    rb.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);
    //}
    //public void ShootPistol()
    //{
    //    if (bulletPrefab == null)
    //    {
    //        Debug.LogError("bulletPrefab has not been assigned!");
    //        return;
    //    }

    //    GunBullet bullet = Instantiate(gunBullet, transform.position, transform.rotation);
    //    bullet.GetComponent<GunBullet>().Fire(transform.forward);
    //}

    //public void ShootFast()
    //{
    //    GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    //    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
    //    rb.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);
    //}

    

   



    //public void Bom()
    //{
    //    GameObject bombInstance = Instantiate(bulletPrefab, transform.position, transform.rotation);
    //    Rigidbody bombRigidbody = bombInstance.GetComponent<Rigidbody>();
    //    bombRigidbody.velocity = transform.forward * 10;
    //    Collider bombCollider = bombInstance.GetComponent<Collider>();
    //    Physics.IgnoreCollision(GetComponent<Collider>(), bombCollider);
    //    //Destroy(bombInstance, 5f);
    //}

    //public void UltimateSkillBom()
    //{
    //    for (int i = 0; i < 10; i++)
    //    {
    //        GameObject bombInstance = Instantiate(bulletPrefab, transform.position, transform.rotation);
    //        Rigidbody bombRigidbody = bombInstance.GetComponent<Rigidbody>();
    //        Vector3 randomDirection = Random.insideUnitSphere;
    //        randomDirection.y = 0;
    //        bombRigidbody.velocity = randomDirection.normalized * 10;
    //        Collider bombCollider = bombInstance.GetComponent<Collider>();
    //        Physics.IgnoreCollision(GetComponent<Collider>(), bombCollider);
    //        //Destroy(bombInstance, 3f);
    //    }
    //}

    private IEnumerator FireBulletsInCone()
    {
        float halfConeAngle = (6 - 1) * 6f / 2f;
        Vector2 direction = transform.right;
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                float angle = j * 6f - halfConeAngle;
                Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                Vector2 rotatedDirection = rotation * direction;
                Shoot(rotatedDirection);
            }
            yield return new WaitForSeconds(0.2f);
        }
    }

    

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Player p = collision.gameObject.GetComponent<Player>();
        if (p != null)
        {
            p.ChangeWeapon(this);
            Destroy(gameObject);
        }
    }
}