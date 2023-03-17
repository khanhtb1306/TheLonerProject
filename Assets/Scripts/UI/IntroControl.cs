using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroControl : MonoBehaviour
{

    public Image introImage;

    public List<Sprite> introEnemyImages;
    public List<Sprite> introBuffImages;
    public List<Sprite> introWeaponImages;

    private void Start()
    {
        GameManager.instance.introControl = this;
        gameObject.SetActive(false);


    }
    public void SetIntroEnemy(int index)
    {
        ButtonControl.instance.isShowIntro = true;
        this.gameObject.SetActive(true);
        introImage.sprite =
            introEnemyImages[index];
        Time.timeScale = 0;

    }
    public void SetIntroBuff(int index)
    {
        ButtonControl.instance.isShowIntro = true;
        this.gameObject.SetActive(true);
        introImage.sprite =
            introBuffImages[index];
        Time.timeScale = 0;

    }
    public void SetIntroWeapon(int index)
    {
        ButtonControl.instance.isShowIntro = true;
        this.gameObject.SetActive(true);
        introImage.sprite =
            introWeaponImages[index];
        Time.timeScale = 0;

    }


    public void SkipIntro()
    {
        if (!ButtonControl.instance.isGamePause)
        {
            Time.timeScale = 1;
            gameObject.SetActive(false);
            ButtonControl.instance.isShowIntro = false;
        }
    }


   

}
