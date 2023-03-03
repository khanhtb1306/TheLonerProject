using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponStyle
{
    pistol,
    fartGun,
    strongGun,
    bom,
}
public class Weapon : MonoBehaviour
{
    public WeaponStyle style;

    public float fireRate = 0.5f;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public float ultimateBulletSpeed = 20f;
    public float ultimateDuration = 5f;

    private float nextFireTime = 0f;

    public void Start()
    {
        SetUp();
    }
    public void SetUp()
    {
        switch (style)
        {
            case WeaponStyle.pistol:
                Shoot();
                break;
            case WeaponStyle.fartGun:
                ShootFast();
                break;
            case WeaponStyle.strongGun:
                ShootStrong();
                break;
        }
    }
    // Pistol weapon, no UltimateSkill
    public void Shoot() 
    { 
        if (bulletPrefab != null)
        {
            if (Time.time >= nextFireTime)
            {
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;
                nextFireTime = Time.time + fireRate;
            }
        }
    }
    // Machine gun weapon, UltimateSkill shoots bullets in a cone
    public void ShootFast()
    {
        if (Time.time >= nextFireTime)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;
            nextFireTime = Time.time + fireRate;
        }
    }

    public void UltimateSkillFast( )
    {
        StartCoroutine(FireBulletsInCone(5, 5, ultimateBulletSpeed, ultimateDuration));
    }

    // Sniper rifle weapon, UltimateSkill deals high damage
    public void ShootStrong()
    {
        if (Time.time >= nextFireTime)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;
            nextFireTime = Time.time + fireRate;
        }
    }

    public void UltimateSkillStrong()
    {
        // perform ultimate attack with high damage
    }

    private IEnumerator FireBulletsInCone(int coneCount, int bulletCount, float bulletSpeed, float duration)
    {
        float halfConeAngle = (coneCount - 1) * 5f / 2f;
        Vector2 direction = transform.right;

        for (float t = 0f; t < duration; t += Time.deltaTime)
        {
            for (int i = 0; i < coneCount; i++)
            {
                float angle = i * 5f - halfConeAngle;
                Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                Vector2 rotatedDirection = rotation * direction;

                for (int j = 0; j < bulletCount; j++)
                {
                    GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                    bullet.GetComponent<Rigidbody2D>().velocity = rotatedDirection * bulletSpeed;
                }
            }
            yield return null;
        }
    }
}