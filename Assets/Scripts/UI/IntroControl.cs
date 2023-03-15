using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroControl : MonoBehaviour
{

    public Image introImage;

    public List<Sprite> introImages;

    private void Start()
    {
        GameManager.instance.introControl = this;
        gameObject.SetActive(false);
    }
    public void SetIntro(int index)
    {
        ButtonControl.instance.isShowIntro = true;
        this.gameObject.SetActive(true);
        introImage.sprite =
            introImages[index];
        Time.timeScale = 0;

    }
    public void SkipIntro()
    {
        if (!ButtonControl.instance.isGamePause)
        {
            Time.timeScale = 1;
            gameObject.SetActive(false);
            ButtonControl.instance.isShowIntro = true;
        }
    }
    public void SetIntro1()
    {
        SetIntro(1);
    }

}
