using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float bulletLifeTime = 3f;

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
        if (collision.gameObject.tag == "Ant" || collision.gameObject.tag == "Bee" ||collision.gameObject.tag == "Enemy"|| collision.gameObject.tag == "Range" || collision.gameObject.tag == "Boss")
        {
            Destroy(gameObject);
        }

    }
}
