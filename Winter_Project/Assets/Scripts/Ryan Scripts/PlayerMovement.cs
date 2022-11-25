using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool CanMove;

    //Variables for Controls
    private Vector2 MoveInput;
    private Vector2 moveDirection;

    //Speed Variables
    public float moveSpeed = 5f;
    private float currentSpeed;
    public Rigidbody2D rb;
    public GameObject GFX;

    private void Start()
    {
        CanMove = true;
        currentSpeed = moveSpeed;
    }

    private void Update()
    {
        MoveInput.x = Input.GetAxisRaw("Horizontal");
        MoveInput.y = Input.GetAxisRaw("Vertical");

        if (MoveInput.x > 0)
        {
            GFX.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (MoveInput.x < 0)
        {
            GFX.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void FixedUpdate()
    {
        if (CanMove == true)
        {
            moveDirection = MoveInput.normalized;

            rb.MovePosition(rb.position + moveDirection * currentSpeed * Time.fixedDeltaTime);
        }
    }
}
