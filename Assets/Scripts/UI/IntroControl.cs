using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroControl : MonoBehaviour
{

    public Image introImage;

    public List<Sprite> introImages;

    public void SetIntro(int index)
    {
        GameManager.instance.showIntro = true;
        this.gameObject.SetActive(true);
        introImage.sprite =
            introImages[index];
        Time.timeScale = 0;

    }
    public void SkipIntro()
    {
        if (!GameManager.instance.isGamePause)
        {
            Time.timeScale = 1;
            gameObject.SetActive(false);
            GameManager.instance.showIntro = false;
        }
    }
    public void SetIntro1()
    {
        SetIntro(1);
    }

}
