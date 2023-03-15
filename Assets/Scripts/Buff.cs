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
                quantity = 5;
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

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        Player p = collision.gameObject.GetComponent<Player>();

        if (p != null)
        {
            if(GameManager.instance.isStrongInfo && style == BuffStyle.strong)
            {
                GameManager.instance.introControl.SetIntro(0);
                GameManager.instance.isStrongInfo= false;
            }else if(GameManager.instance.isSpeedInfo && style == BuffStyle.speed) {
                GameManager.instance.introControl.SetIntro(0);
                GameManager.instance.isSpeedInfo = false;
            }else if(GameManager.instance.isHealthInfo && style == BuffStyle.health) {
                GameManager.instance.introControl.SetIntro(0);
                GameManager.instance.isHealthInfo = false;
            }else if (GameManager.instance.isDashInfo && buffskill == BuffSkillStyle.dashSkill)
            {
                GameManager.instance.introControl.SetIntro(0);
                GameManager.instance.isDashInfo = false;
            }else if (GameManager.instance.isBoomInfo && buffskill == BuffSkillStyle.boomSkill)
            {
                GameManager.instance.introControl.SetIntro(0);
                GameManager.instance.isBoomInfo = false;
            }else if (GameManager.instance.isImmortalInfo && buffskill == BuffSkillStyle.immortalSkill)
            {
                GameManager.instance.introControl.SetIntro(0);
                GameManager.instance.isImmortalInfo = false;
            }
            p.ChangeBuffSkill(this);
            GameManager.instance.skillButton.ChangeAvatar();

            Destroy(this.gameObject);

        }
    }


   
}
