using UnityEngine;

public class Enemywalk : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float leftLimit = -5f; // Giới hạn di chuyển sang trái
    public float rightLimit = 5f; // Giới hạn di chuyển sang phải
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private Animator anim;

    private float moveDirection = -1f;
    private bool facingRight = false;
    private bool onGround = false;
    private bool isColliding = false;

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
        onGround = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, groundLayer);

        if (!onGround)
        {
            Flip();
        }

        if (isColliding)
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
    }

    private void FixedUpdate()
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

        if (!isColliding)
        {
            rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        }

        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }

    private void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Player"))
    {
        isColliding = true;
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 0f));
        anim.SetTrigger("Attack");

        // Kiểm tra vị trí của player so với enemy để quyết định enemy có quay mặt về phía player hay không
        if (collision.transform.position.x < transform.position.x && facingRight)
        {
            Flip();
        }
        else if (collision.transform.position.x > transform.position.x && !facingRight)
        {
            Flip();
        }
    }
}

private void OnCollisionExit2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Player"))
    {
        isColliding = false;
        anim.ResetTrigger("Attack");
    }
}

private void Flip()
{
    facingRight = !facingRight;
    moveDirection *= -1f;
    Vector3 scale = transform.localScale;
    scale.x *= -1f;
    transform.localScale = scale;
}

}
