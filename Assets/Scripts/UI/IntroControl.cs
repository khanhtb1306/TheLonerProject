using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroControl : Singleton<IntroControl> 
{

    private Image introImage;

    public List<Sprite> introImages;
    public Button skip;

    private void Start()
    {
        introImage = GetComponent<Image>();
        SkipIntro();
    }
    public void SetIntro(int index)
    {
        Time.timeScale = 0;
        this.gameObject.SetActive(true);
        introImage.sprite = introImages[index];
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
