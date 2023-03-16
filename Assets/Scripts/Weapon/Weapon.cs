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
    public int quantity;
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
                quantity = 100000;
                break;
            case WeaponStyle.FartGun:
                quantity = 500;
                break;
            case WeaponStyle.StrongGun:
                quantity = 500;
                break;
            case WeaponStyle.Bom:
                quantity = 10;
                break;
        }
    }




    public void Shoot(Vector2 direction)
    {
        if (norReady)
        {
            GunBullet bullet = Instantiate(normalBullet, transform.position, Quaternion.identity);
            bullet.Fire(direction, bulletForce);
            quantity -= 1;
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
                    UltimateSkillBom();
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



    public void UltimateSkillBom()
    {
        Collider2D[] colliders = FindObjectsOfType<Collider2D>();
        foreach (Collider2D collider in colliders)
        {
            Debug.Log("1");
            Enemies e = collider.gameObject.GetComponent<Enemies>();
            if(e!= null)
            {
                if(e.enemyType != EnemyType.Boss)
                {
                    e.TakeDamage(10000);
                }
                else
                {
                    e.TakeDamage(20);
                }

            }
        }
        GameManager.instance.player.TakeDamge(20);
        quantity = 0;


    }

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