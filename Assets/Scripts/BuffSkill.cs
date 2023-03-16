using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BuffSkillStyle
    {
        dashSkill, immortalSkill, boomSkill
    }
public class BuffSkill : MonoBehaviour
{
    

    public BuffSkillStyle buffskill;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        Player p = collision.gameObject.GetComponent<Player>();

        if (p != null)
        {

           
            if (GameManager.instance.isDashInfo && buffskill == BuffSkillStyle.dashSkill)
            {
                GameManager.instance.introControl.SetIntro(0);
                GameManager.instance.isDashInfo = false;
            }
            else if (GameManager.instance.isBoomInfo && buffskill == BuffSkillStyle.boomSkill)
            {
                GameManager.instance.introControl.SetIntro(0);
                GameManager.instance.isBoomInfo = false;
            }
            else if (GameManager.instance.isImmortalInfo && buffskill == BuffSkillStyle.immortalSkill)
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
