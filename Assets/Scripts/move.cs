using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float speed; // скорость кота
    public Animator animator; // для переключения анимации
    public bool isRightSide = true; // для поворота кота в сторону движения
    
    private Rigidbody2D rb;
    private Vector2 moveVelosity;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Spin() // метод поворота
    {
        isRightSide = !isRightSide;
        transform.localScale = new Vector3(transform.localScale.x * -1, 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y); // движение по горизонтали
        moveVelosity = moveInput;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelosity * Time.fixedDeltaTime);

        float moveX = -Input.GetAxis("Horizontal");

        animator.SetFloat("speed", Math.Abs(moveX)); // изменить значение в аниматоре

        if ((moveX > 0f && !isRightSide) || (moveX < 0f && isRightSide))
        { 
            if (moveX != 0f) 
            {
                Spin();
            }
        }
    }
}
