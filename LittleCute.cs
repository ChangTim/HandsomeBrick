using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LittleCute : MonoBehaviour
{
    private Rigidbody2D LittleCuteRigidbody2D;
    public GameObject myBoss;
    public int Boss_Hp = 50;
    private int brick_left = 63;
    public Text TextSquare;
    public Text Congratulation;

    [Header("水平移動速度")]
    public float speedX;

    [Header("垂直移動速度")]
    public float speedY;

    [Header("實際水平速度")]
    public float velocityX;

    [Header("實際垂直速度")]
    public float velocityY;

    private void Start()
    {
        LittleCuteRigidbody2D = GetComponent<Rigidbody2D>();
        LittleCuteRigidbody2D.velocity = new Vector2(speedX, speedY);
        myBoss = GameObject.Find("張元鴻");
        myBoss.gameObject.SetActive(false);
        TextSquare.gameObject.SetActive(false);
        Congratulation.gameObject.SetActive(false);
    }

    private void Update()
    {
        velocityX = LittleCuteRigidbody2D.velocity.x;
        velocityY = LittleCuteRigidbody2D.velocity.y;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        LockSpeed();
        if (other.gameObject.CompareTag("Deadline"))
        {
            speedX = 0;
            speedY = 0;
            TextSquare.gameObject.SetActive(true);
            LittleCuteRigidbody2D.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Brick"))
        {
            other.gameObject.SetActive(false);
            brick_left -= 1;
            if (brick_left == 0)
            {
                myBoss.gameObject.SetActive(true);
            }
        }
        else if (other.gameObject.CompareTag("Boss"))
        {
            Boss_Hp -= 1;
            if (Boss_Hp == 0)
            {
                other.gameObject.SetActive(false);
                speedX = 0;
                speedY = 0;
                Congratulation.gameObject.SetActive(true);
            }
        }
    }

    private void LockSpeed()
    {
        Vector2 LockSpeed = new Vector2(resetSpeedX(), resetSpeedY());
        LittleCuteRigidbody2D.velocity = LockSpeed;
        if (Boss_Hp == 100)
        {
            speedX = 15;
            speedY = 15;
        }
        else if (Boss_Hp == 50)
        {
            speedX = 25;
            speedY = 25;
        }
        else if (Boss_Hp == 15)
        {
            speedX = 30;
            speedY = 30;
        }
    }

    private float resetSpeedX()
    {
        float currentSpeedX = LittleCuteRigidbody2D.velocity.x;
        if (currentSpeedX < 0)
        {
            return -speedX;
        }
        else
        {
            return speedX;
        }
    }

    private float resetSpeedY()
    {
        float currentSpeedY = LittleCuteRigidbody2D.velocity.y;
        if (currentSpeedY < 0)
        {
            return -speedY;
        }
        else
        {
            return speedY;
        }
    }
}