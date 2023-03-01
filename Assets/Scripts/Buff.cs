using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;


public enum BuffStyle
{
    health, strong, speed, dashSkill, immortalSkill, boomSkill
}
public class Buff : MonoBehaviour
{
    public float amout;
    public BuffStyle style;
   
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void upGrade(int amount)
    {
    }
    public void BuffEffectFirst()
    {
        switch (style)
        {
            case BuffStyle.health:
                amout = 20;
                break;
            case BuffStyle.strong:
                amout = 2;
                break; 
            case BuffStyle.speed:
                amout = 5;
                break;
        }
    }
    
    //public void BuffSkill(Player player)
    //{
    //    switch(style)
    //    {
    //        case BuffStyle.immortalSkill:
    //            Immortal();
    //            break;
    //        case BuffStyle.boomSkill:
    //            Boom();
    //            break;
                
    //        case BuffStyle.dashSkill:
    //            Dash();
    //            break;
    //    }
    //}
    public void UpHealth(Player player)
    {
        player.maxHealth += amout;
    }
    public void UpSpeed(Player player)
    {
        player.speed += amout;
    }
    public void upDame(Player player)
    {
        player.bonusdame += amout;
    }
   
}
