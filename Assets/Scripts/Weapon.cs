using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
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

    //public float fireRate = 0.5f;
    public GameObject bulletPrefab;
    public Transform firePos;
    public float TimeBtwFire = 0.2f;
    public float bulletForce;

    private float timeBtwFire;
    //public float bulletSpeed = 10f;
    public float ultimateBulletSpeed = 20f;
    public float ultimateDuration = 5f;

    //private bool isUsingUltimate = false;

    //private float nextFireTime = 0f;


    public bool Gun1;
    public bool Gun2;
    public bool Gun3;
    public bool Gun4;


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

    public void Update()
    {
        rotateTowardsMouse();
        if (Gun1)
        {
            timeBtwFire -= Time.deltaTime;
            if (Input.GetMouseButton(0) && timeBtwFire < 0)
            {
                Shoot();
            }
        }
        if (Gun2)
        {
            timeBtwFire -= Time.deltaTime;
            if (Input.GetMouseButton(0) && timeBtwFire < 0)
            {
                ShootFast();

            }
            if (Input.GetMouseButton(1) && timeBtwFire < 0)
            {
                UltimateSkillFast();

            }
        }
        if (Gun3)
        {
            timeBtwFire -= Time.deltaTime;
            if (Input.GetMouseButton(0) && timeBtwFire < 0)
            {
                ShootStrong();

            }
            if (Input.GetMouseButton(1) && timeBtwFire < 0)
            {
                UltimateSkillStrong();

            }
        }
        if (Gun4)
        {
            timeBtwFire -= Time.deltaTime;
            if (Input.GetMouseButton(0) && timeBtwFire < 0)
            {
                //Bom(); ;

            }
            if (Input.GetMouseButton(1) && timeBtwFire < 0)
            {
                //UltimateSkillBom();

            }
        }
    }

    void rotateTowardsMouse()
    {
        Vector2 range = Camera.main.ScreenToWorldPoint(Input.mousePosition) - bulletPrefab.transform.position;
        float angle = Mathf.Atan2(range.y, range.x)* Mathf.Rad2Deg;
        bulletPrefab.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }


    //Pistol weapon, no UltimateSkill
    public void Shoot()
    {
        timeBtwFire = TimeBtwFire;
        GameObject bullet = Instantiate(bulletPrefab, firePos.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);
    }


    // Machine gun weapon, UltimateSkill shoots bullets in a cone
    public void ShootFast()
    {
        timeBtwFire = TimeBtwFire;
        GameObject bullet = Instantiate(bulletPrefab, firePos.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);
    }

    public void UltimateSkillFast()
    {
        timeBtwFire = TimeBtwFire;
        StartCoroutine(FireBulletsInCone(5, 1, ultimateBulletSpeed, ultimateDuration));
    }

    // Sniper rifle weapon, UltimateSkill deals high damage
    public void ShootStrong()
    {
        timeBtwFire = TimeBtwFire;
        GameObject bullet = Instantiate(bulletPrefab, firePos.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);
    }

    public void UltimateSkillStrong()
    {
        timeBtwFire = TimeBtwFire;
        GameObject missile = Instantiate(bulletPrefab, firePos.position, Quaternion.identity);
        Rigidbody2D rb = missile.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * missileSpeed, ForceMode2D.Impulse);
        // perform ultimate attack with high damage
        StartCoroutine(Explode(missile));
    }


    public void Bom()
    {
        // Tạo một instance của prefab quả bom
        GameObject bombInstance = Instantiate(bulletPrefab, transform.position, transform.rotation);

        // Lấy Rigidbody của quả bom
        Rigidbody bombRigidbody = bombInstance.GetComponent<Rigidbody>();

        // Đặt tốc độ di chuyển cho quả bom
        bombRigidbody.velocity = transform.forward * 10;

        // Thiết lập collider để phát hiện va chạm giữa quả bom và các đối tượng khác
        Collider bombCollider = bombInstance.GetComponent<Collider>();
        Physics.IgnoreCollision(GetComponent<Collider>(), bombCollider);

        // Hủy quả bom sau khi đã tồn tại trong một khoảng thời gian nhất định
        //Destroy(bombInstance, 5f);
    }

    public void UltimateSkillBom()
    {
        // Tạo 10 quả bom xung quanh người chơi
        for (int i = 0; i < 10; i++)
        {
            // Tạo một instance của prefab quả bom
            GameObject bombInstance = Instantiate(bulletPrefab, transform.position, transform.rotation);

            // Lấy Rigidbody của quả bom
            Rigidbody bombRigidbody = bombInstance.GetComponent<Rigidbody>();

            // Đặt hướng di chuyển ngẫu nhiên cho quả bom
            Vector3 randomDirection = Random.insideUnitSphere;
            randomDirection.y = 0;
            bombRigidbody.velocity = randomDirection.normalized * 10;

            // Thiết lập collider để phát hiện va chạm giữa quả bom và các đối tượng khác
            Collider bombCollider = bombInstance.GetComponent<Collider>();
            Physics.IgnoreCollision(GetComponent<Collider>(), bombCollider);

            // Hủy quả bom sau khi đã tồn tại trong một khoảng thời gian nhất định
            //Destroy(bombInstance, 3f);
        }
    }

    private IEnumerator Explode(GameObject missile)
    {
        yield return new WaitForSeconds(3f);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(missile.transform.position, explosionRadius);
        foreach (Collider2D collider in colliders)
        {
            // apply damage to colliders within the explosion radius
        }

        // create explosion effect
        Destroy(missile);
    }


    private IEnumerator FireBulletsInCone(int coneCount, int bulletCount, float bulletSpeed, float duration)
    {
        float halfConeAngle = (coneCount - 1) * 5f / 2f;
        Vector2 direction = transform.right;

        //for (float t = 0f; t < 1; t += Time.deltaTime)
        //{
            for (int i = 0; i < coneCount; i++)
            {
                float angle = i * 5f - halfConeAngle;
                Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                Vector2 rotatedDirection = rotation * direction;

                for (int j = 0; j < 1; j++)
                {
                    GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                    bullet.GetComponent<Rigidbody2D>().velocity = rotatedDirection * bulletSpeed;
                }
            }
            yield return null;
        //}
    }
}