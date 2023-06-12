using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySwin : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float leftLimit = -5f; // Giới hạn di chuyển sang trái
    public float rightLimit = 5f; // Giới hạn di chuyển sang phải

    private Rigidbody2D rb;
    private Animator anim;

    private float moveDirection = -1f;
    private bool facingRight = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        moveDirection = facingRight ? 1f : -1f;
    }

    private void Update()
    {
        if (transform.position.x < leftLimit)
        {
            transform.position = new Vector2(leftLimit, transform.position.y);
            Flip();
        }
        else if (transform.position.x > rightLimit)
        {
            transform.position = new Vector2(rightLimit, transform.position.y);
            Flip();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }

    private void Flip()
    {
        facingRight = !facingRight;
        moveDirection = facingRight ? 1f : -1f;
        Vector3 scale = transform.localScale;
        scale.x *= -1f;
        transform.localScale = scale;
    }
}
