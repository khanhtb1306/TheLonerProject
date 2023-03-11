﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{

    [SerializeField]
    private int bulletsAmount = 10;
    private float angle = 0f;
    [SerializeField]
    private float startAngle = 0f, endAngle = 360f;
    public float involkTime = 1;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("BossShot", 0f, 3f);
    }

    public void BossShot()
    {
        int a = Random.Range(1, 4);
        if (a == 1 )
        {
            Fire();  
        }

        if (a == 2 )
        {
            DoubleSpiral();
        }   

        if (a == 3 )
        {
            Spiral();
        }
    }

    public void Fire()
    {
        involkTime = 1;
        float angleStep = (endAngle - startAngle) / bulletsAmount;
        float angle = startAngle;

        for (int i = 0; i < bulletsAmount + 1; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BulletPool.bulletPoolInstance.GetBullet();

            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<BulletForBoss>().SetMoveDirection(bulDir);
            angle += angleStep;
        }
    }


    // Check lại sau
    public void DoubleSpiral()
    {
        involkTime = 10;
        for (int i = 0; i <= 1; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin(((angle + 180f * i) * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos(((angle + 180f * i) * Mathf.PI) / 180f);
            
            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<BulletForBoss>().SetMoveDirection(bulDir);

           
        }
        angle += 10f;
        if (angle >= 360f)
        {
            angle = 0f;
        }
    }


    private void Spiral()
    {
        StartCoroutine(SpiralShoot());
    }

    private IEnumerator SpiralShoot()
    {
        for (int i = 0; i < 18; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<BulletForBoss>().SetMoveDirection(bulDir);

            angle += 20f;
            yield return new WaitForSeconds(0.1f);
        }  
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            Destroy(gameObject);
            GameManager.instance.player.TakeDamge(20);
        }
    }

}
