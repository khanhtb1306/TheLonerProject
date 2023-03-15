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




    public bool isIntro;

    public bool isGamePause;
    public bool showIntro;


    // Update is called once per frame
    public void StartGame() { }
    public void PauseGame() { }
    public void EndGame()
    {

    }
    private void Awake()
    {
        ResetState();
    }
    public void ResetState()
    {
        totalEnemies = 10;
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
        isIntro = true;

      

        isGamePause = false;
        showIntro = false;

    }

    public void UpgradeAttribute()
    {
        UpdateEnemyAttribute();
    }

    public void UpdateEnemyAttribute()
    {
        totalEnemies = (int)Mathf.Round(totalEnemies * 1.3f);
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

    }
}
