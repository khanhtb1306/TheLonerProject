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
        this.gameObject.SetActive(true);
        introImage.sprite = 
            introImages[index];
        Time.timeScale = 0;

    }
    public void SkipIntro()
    {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }
    public void SetIntro1()
    {
        SetIntro(1);
    }
  
}
