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
    public float amout;
    public BuffStyle style;
    private Rigidbody2D r2d;
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
    
    public void BuffSkill(Player player)
    {
        switch(style)
        {
            case BuffStyle.health:
                Immortal();
                break;
            case BuffStyle.strong:
                Boom(player);
                break;
                
            case BuffStyle.speed:
                Dash();
                break;
        }
    }
    public void UpHealth(Collider player)
    {
        Player player = player.GetComponent<Player>();
        player.maxHealth += healthup;
    }
    private void Dash()
    {
        throw new NotImplementedException();
    }

    private void Boom(Player player)
    {
        throw new NotImplementedException();
    }

    private void Immortal()
    {
        throw new NotImplementedException();
    }
}
