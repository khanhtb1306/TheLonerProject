using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    // Start is called before the first frame update
    public List<Buff> Buffs;
    public List<Weapon> Weapons;
    public Player player;
    public SkillButton skillButton;

    
    // Update is called once per frame
    public void StartGame() { }
    public void PauseGame() { }
    public void EndGame() { }
}