using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("水平移動速度")]
    public float SpeedX;

    private Rigidbody2D playerRididbody2D;

    private void Start()
    {
        playerRididbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveLeftOrRight();
    }

    private float LeftOrRight()
    {
        return Input.GetAxis("Horizontal");
    }

    private void moveLeftOrRight()
    {
        playerRididbody2D.velocity = LeftOrRight() * new Vector2(SpeedX, 0);
    }
}