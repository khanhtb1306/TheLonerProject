using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    [SerializeField] private List<Sprite> buttonAvas;
    private Button button;
    private Image buttonImage;

    void Start()
    {
        button = GetComponent<Button>();
        buttonImage = button.GetComponent<Image>();
        GameManager.instance.skillButton = this ;
    }
    // Start is called before the first frame update

    public void ChangeAvatar()
    {
        if (GameManager.instance.player.GetCurBuffSkill() == null) 
            buttonImage.sprite = null;
        for (int i = 0; i < 3; i++)
        {
            if (GameManager.instance.BuffSkill[i] == GameManager.instance.player.GetCurBuffSkill())
            {
                buttonImage.sprite = buttonAvas[i];
                break;
            }
        }
    }

    //public void ChangeAvatarSkill()
    //{
    //    if (GameManager.instance.player.GetCurBuff() == null)
    //        buttonImage.sprite = null;
    //    for (int i = 3; i < 3; i++)
    //    {
    //        if (GameManager.instance.BuffSkill[i] == GameManager.instance.player.GetCurBuffSkill())
    //        {
    //            buttonImage.sprite = buttonAvas[i];
    //            break;
    //        }
    //    }
    //}

}
