using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;


public enum BuffStyle
{
    health, strong, speed
}

public class Buff : MonoBehaviour
{

    public BuffStyle style;
   
    public float quantity;
    void Start()
    {
        Setup();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    
    public void Setup()
    {
        switch (style)
        {
            case BuffStyle.health:
                quantity = 20;
                break;
            case BuffStyle.strong:
                quantity = 10;
                break;
            case BuffStyle.speed:
                quantity = 1;
                break;
        }
    }


   

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        Player p = collision.gameObject.GetComponent<Player>();

        if (p != null)
        {

            if(GameManager.instance.isStrongInfo && style == BuffStyle.strong)
            {
                GameManager.instance.introControl.SetIntroBuff(0);
                GameManager.instance.isStrongInfo= false;
            }else if(GameManager.instance.isSpeedInfo && style == BuffStyle.speed) {
                GameManager.instance.introControl.SetIntroBuff(1);
                GameManager.instance.isSpeedInfo = false;
            }else if(GameManager.instance.isHealthInfo && style == BuffStyle.health) {
                GameManager.instance.introControl.SetIntroBuff(2);
                GameManager.instance.isHealthInfo = false;
            }
            p.BuffUpdate(this);
            
            Destroy(this.gameObject);

        }
    }


   
}