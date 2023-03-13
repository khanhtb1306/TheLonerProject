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
    public Player player;

    public int totalEnemies = 10;
    public bool isBossAlive = false;
    public SkillButton skillButton;

    
    // Update is called once per frame
    public void StartGame() { }
    public void PauseGame() { }
    public void EndGame() { }

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
            } else
            {
                enemyType.maxHealth += enemyType.maxHealth * 0.2f;
                enemyType.damage += (int)Mathf.Round(enemyType.damage * 0.2f);
                enemyType.movementSpeed += enemyType.movementSpeed * 0.1f;

            }
           
        }
    }
}
