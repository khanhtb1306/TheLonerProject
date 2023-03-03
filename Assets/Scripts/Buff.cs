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
 
    public BuffStyle style;
      public float quantity;
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
    public void BuffEffect()
    {
        switch (style)
        {
            case BuffStyle.health:
                quantity = 20;
                break;
            case BuffStyle.strong:
                quantity = 2;
                break; 
            case BuffStyle.speed:
                quantity  = 5;
                break;
        }
    }
    
}
