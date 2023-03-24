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
    public Sprite intro;

    void Start()
    {
        Setup();
    }

    
    public void Setup()
    {
        //Khởi tạo ban đầu khi bắt đầu chơi game thì mỗi khi ăn từng loại buff sẽ có
        // những số lượng chỉ số được cộng thêm dựa trên loại buff nào
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
        //Check va chạm để in ra màn hình intro
        Debug.Log(collision.gameObject.name);
        Player p = collision.gameObject.GetComponent<Player>();

        if (p != null)
        {
            if (GameSave.instance.isIntro)
            {
 if(GameManager.instance.isStrongInfo && style == BuffStyle.strong)
            {
                GameManager.instance.introControl.SetIntro(intro);
                GameManager.instance.isStrongInfo= false;
            }else if(GameManager.instance.isSpeedInfo && style == BuffStyle.speed) {
                GameManager.instance.introControl.SetIntro(intro);
                GameManager.instance.isSpeedInfo = false;
            }else if(GameManager.instance.isHealthInfo && style == BuffStyle.health) {
                GameManager.instance.introControl.SetIntro(intro);
                GameManager.instance.isHealthInfo = false;
            }
            }
           
            p.BuffUpdate(this);
            
            Destroy(this.gameObject);

        }
    }


   
}
