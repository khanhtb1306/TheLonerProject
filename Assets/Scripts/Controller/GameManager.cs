using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    // Start is called before the first frame update
    public List<Buff> Buffs;
    public List<BuffSkill> BuffSkill;
    public List<Weapon> Weapons;
    public List<Enemies> Enemies;
    public List<GunBullet> Bullet;
    public Player player;
    public SkillButton skillButton;
    public IntroControl introControl;

    public int totalEnemies ;
    public bool isBossAlive ;
    public bool isAntAliveIntro ;
    public bool isBeeAliveIntro ;
    public bool isRangedAliveIntro ;
    public bool isDashInfo;
    public bool isImmortalInfo;
    public bool isBoomInfo;
    public bool isSpeedInfo;
    public bool isHealthInfo;
    public bool isStrongInfo;
    public bool isPistoGun;
    public bool isFastGun;
    public bool isStrongGun;
    public bool isBoomGun;
    public bool isUpgrade;







 
    private void Awake()
    {
        ResetState();
    }
    public void ResetState()
    {
        totalEnemies = 5;
        isBossAlive = false;
        isAntAliveIntro = true;
        isBeeAliveIntro = true;
        isRangedAliveIntro = true;
        isDashInfo = true;
        isImmortalInfo = true;
        isBoomInfo = true;
        isHealthInfo= true;
        isSpeedInfo= true;
        isStrongInfo=true;
        isFastGun= true;
        isStrongGun=true;
        isBoomGun=true;
        isPistoGun=true;
        isUpgrade = false;

    }

    public void UpgradeAttribute()
    {
        totalEnemies = (int)Mathf.Round(totalEnemies * 1.3f);
        UpdateEnemyAttribute();
        UpdateBuffAttribute();

    }

    public Enemies GetEnemy(EnemyType type)
    {
        foreach(var e in Enemies)
        {
            if (e.enemyType == type)
                return e;
            break;
        }
        return null;
    }
    public Buff GetBuff(BuffStyle type)
    {
        foreach (var b in Buffs)
        {
            if (b.style == type)
                return b;
            break;
        }
        return null;
    }
    public BuffSkill GetBuffSkill(BuffSkillStyle type)
    {
        foreach (var b in BuffSkill)
        {
            if (b.buffskill == type)
                return b;
            break;
        }
        return null;
    }
    public Weapon GetWeapon(WeaponStyle type)
    {
        foreach (var w in Weapons)
        {
            if (w.style == type)
                return w;
            break;
        }
        return null;
    }

    public void UpdateEnemyAttribute()
    {
        foreach (var enemyType in Enemies)
        {
            if (enemyType.enemyType != EnemyType.Boss)
            {
                enemyType.maxHealth += enemyType.maxHealth * 0.1f;
                enemyType.damage += (int)Mathf.Round(enemyType.damage * 0.1f);
                enemyType.movementSpeed += enemyType.movementSpeed * 0.1f;
            }
            else
            {
                enemyType.maxHealth += enemyType.maxHealth * 0.2f;
                enemyType.damage += (int)Mathf.Round(enemyType.damage * 0.2f);
                enemyType.movementSpeed += enemyType.movementSpeed * 0.1f;

            }

        }
    }

    public void UpdateBuffAttribute()
    {
        foreach (var buffs in BuffSkill)
        {
            buffs.timeEffect += 0.5f;
            buffs.cdBuff += 1f;
        }
        foreach (var buff in Buffs)
        {
            buff.quantity *= 0.2f;
        }
        
    }
}
