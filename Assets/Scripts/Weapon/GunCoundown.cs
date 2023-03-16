using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunCoundown : MonoBehaviour
{
    public Image imageCount;
    public float cooldown;
    // Start is called before the first frame update

    private void Start()
    {
        cooldown = GameManager.instance.player.curWeapon.norCd;
    }
    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.player.curWeapon.norReady)
        {
            imageCount.fillAmount -= Time.deltaTime / cooldown;
            if (imageCount.fillAmount <= 0)
            {
                GameManager.instance.player.curWeapon.norReady = true;
                imageCount.fillAmount = 1;
            }
        }
    }
}
