using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UltCoundown : MonoBehaviour
{
    public Image imageCount;
    public float cooldown;
    // Start is called before the first frame update

    private void Start()
    {
        cooldown = GameManager.instance.player.curWeapon.ultCd;
    }
    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.player.curWeapon.ultReady)
        {
            imageCount.fillAmount -= 1 / cooldown * Time.deltaTime;
            if(imageCount.fillAmount <= 0)
            {
                imageCount.fillAmount = 1;
            }
        }
    }
}
