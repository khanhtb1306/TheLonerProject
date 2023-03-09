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
public enum BuffSkillStyle
{
    dashSkill, immortalSkill, boomSkill
}
public class Buff : MonoBehaviour
{
 
    public BuffStyle style;
    public BuffSkillStyle buffskill;
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
    
    
    public void UpHealth(Player player)
    {
        player.maxHealth += quantity;
    }
    public void UpSpeed(Player player)
    {
        player.speed += quantity;
    }
    public void upDame(Player player)
    {
        player.bonusdame += quantity;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Player p = collision.gameObject.GetComponent<Player>();

        if(p != null)
        {
            p.ChangeBuffSkill(this);
<<<<<<< HEAD
        }Destroy(this.gameObject);
=======
        }
        GameManager.instance.skillButton.ChangeAvatar();
        Destroy(this.gameObject);
>>>>>>> 3f7fda57859a022c34e6c22e565bf0534e5d3ab6
    }
}
