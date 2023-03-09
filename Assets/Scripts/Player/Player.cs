using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] public float speed = 10.0f;
    [SerializeField] private float rotationSpeed = 600.0f;
    [SerializeField] public float maxHealth = 200;
    [SerializeField] private float curHealth;
    [SerializeField] private Transform gunSpawnPos;
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] public float bonusdame = 0;
    [SerializeField] public Slider healthBar;

    public Weapon firstWeapon;
    public Buff firtBuff;
    //abc
    private Rigidbody2D rb2d;
    private Camera mainCamera;
    [SerializeField] private Weapon curWeapon;
    [SerializeField] private Buff curBuff;

    private Vector2 movementInput;
    private Vector2 movementInputSmooth;
    private Vector2 velocityInputSmooth;


    private void Awake()
    {
        GameManager.instance.player = this;
        healthBar.maxValue = maxHealth;
    }
    private void Start()
    {
        mainCamera = Camera.main;
        rb2d = GetComponent<Rigidbody2D>();
        curHealth = maxHealth;
        curWeapon = Instantiate(firstWeapon, gunSpawnPos.position, gunSpawnPos.rotation);
        curWeapon.transform.SetParent(this.transform);
    }
    private void Update()
    {
        healthBar.value = curHealth;
    }

    private void LateUpdate()
    {
        //set camera follow
        if (this != null)
        {
            Vector3 cameraPos = mainCamera.transform.position;
            cameraPos.x = transform.position.x;
            cameraPos.y = transform.position.y;
            mainCamera.transform.position = cameraPos;
        }
    }

    public Rigidbody2D GetRigidbody2D()
    {
        return rb2d;
    }
    public Vector2 GetMovementInputSmooth()
    {
        return movementInputSmooth;
    }
    public Buff GetCurBuff()
    {
        return curBuff;
    }
    public float GetCurHealth()
    {
        return curHealth;
    }
    public void SetCurHealth(float healthUndead)
    {
        curHealth = healthUndead;
    }

    private void FixedUpdate()
    {
        SetVelocityOfInput();
        SetRotationInDirectinOfInput();
        Dead();
    }


    private void SetVelocityOfInput()
    {
        movementInput = new Vector2(joystick.Horizontal, joystick.Vertical)
            + new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        movementInputSmooth = Vector2.SmoothDamp(movementInputSmooth,
            movementInput, ref velocityInputSmooth, 0.1f);

        rb2d.velocity = movementInputSmooth * speed;
    }



    private void SetRotationInDirectinOfInput()
    {
        if (movementInput != Vector2.zero)
        {
            Quaternion targetRotaion =
                Quaternion.LookRotation(transform.forward, movementInputSmooth);

            Quaternion rotation = Quaternion.RotateTowards
                (transform.rotation, targetRotaion, rotationSpeed * Time.deltaTime);

            rb2d.MoveRotation(rotation);
        }

    }

    public void Shoot()
    {
        curWeapon.Shoot();
    }

    public void BuffSkill()
    {
        if (curBuff != null)
        {
            switch (curBuff.style)
            {
                case BuffStyle.strong:
                    Boom();
                    break;
                case BuffStyle.speed:
                    Dash();
                    break;
                case BuffStyle.health:
                    Undead();
                    break;
            }
        }

    }

    private void Boom()
    {

    }
    private void Dash()
    {
        Vector2 force = 1000 * transform.up;
        Debug.Log(force);
        rb2d.AddForce(force);
    }


    float undeadDuration = 5.0f;
    bool isUndead = true;
    private void Undead()
    {
        StartCoroutine(Undead(undeadDuration, this));
    }


    public void ChangeWeapon(Weapon newWeapon)
    {
        if (curWeapon.style != newWeapon.style)
        {
            Destroy(curWeapon.gameObject);
            curWeapon = Instantiate(newWeapon, gunSpawnPos.position, gunSpawnPos.rotation);
            curWeapon.transform.SetParent(this.transform);
        }
    }

    public void ChangeBuffSkill(Buff newBuff)
    {
        if (curBuff == null || (curBuff.style != newBuff.style))
        {
            Debug.Log("change");
            foreach (Buff buff in GameManager.instance.Buffs)
            {
                if (buff.style == newBuff.style)
                {
                    curBuff = buff;
                    break;
                }
            }
        }
    }

    public void TakeDamge(float damage)
    {
        curHealth -= damage;
    }

    public void Dead()
    {
        if (curHealth <= 0)
        {
            GameManager.instance.EndGame();
        }
    }

    private IEnumerator Undead(float timeDuration, Player player)
    {
        isUndead = true;
        float timeCount = timeDuration;
        while (timeCount > 0)
        {
            Debug.Log(isUndead);
            timeCount -= Time.deltaTime;
            if (isUndead)
            {
                if (player.curHealth <= 1) player.curHealth = 1;
            }
            yield return null;
        }
        isUndead = false;
    }

}
