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

    public float norCd;
    public float ultCd;

    public bool norReady;
    public bool ultReady;

    private void Awake()
    {
        SetUp();
    }

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
        if (norReady)
        {
            GunBullet bullet = Instantiate(normalBullet, transform.position, Quaternion.identity);
            bullet.Fire(direction, bulletForce);
            norReady = false;
            StartCoroutine(CountDownShoot(norCd));
        }
    }

    public void UltiShoot(Vector2 direction)
    {
        if (ultReady)
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
                    BoomShotUlti(direction);
                    break;
            }
            ultReady = false;
            StartCoroutine(CountDownUtil(ultCd));
        }

    }

    IEnumerator CountDownShoot(float time)
    {
        yield return new WaitForSeconds(time);
        norReady = true;
    }

    IEnumerator CountDownUtil(float time)
    {
        yield return new WaitForSeconds(time);
        ultReady = true;
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
    public void BoomShotUlti(Vector2 direction)
    {
        GunBullet bullet = Instantiate(ultiBullet, transform.position, Quaternion.identity);
        bullet.Fire(direction, bulletForce);
    }



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
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                float angle = j * 6f - halfConeAngle;
                Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                Vector2 rotatedDirection = rotation * direction;
                GunBullet bullet = Instantiate(normalBullet, transform.position, Quaternion.identity);
                bullet.Fire(rotatedDirection, bulletForce);
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