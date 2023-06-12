using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{

    public float enemySpeed; // xac dinh toc do cua AI
        Rigidbody2D enemyRB;
        Animator enemyAnim;

    // khai bao bien de enemy co the quay mat di nguoc lai

    public GameObject enemyGraphic;
    bool facingRight = true; // dau game quay mat sang ben phai
    float facingTime = 5f; //sau 5s AI se quay mat 1 lan
    float nextFlip = 0f;  // ngay sau khi bat dau game se quay mat
    bool canFlip = true; // co the quay mat lien tuc khi nhan vat chua cham box collider


    void Awake()
    {
        enemyRB = GetComponent<Rigidbody2D> ();
        enemyAnim = GetComponentInChildren<Animator> ();
    }

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFlip)   // thoi gian hien tai lon hon time tro thi co the quay mat
        {
            nextFlip = Time.time + facingTime; // thooi gian hien tai lon hon 5s thi AI co the quay mat
            flip();
        }
    }


      void OnTriggerEnter2D (Collider2D other)
    {
           if (other.tag == "Player")
        {
            if(facingRight && other.transform.position.x < transform.position.x)
            {
                flip();
            }
            else if (!facingRight && other.transform.position.x > transform.position.x)
            {
                flip();
            }
            canFlip = false;
        }
        
    }

    
    void OnTriggerStay2D (Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (!facingRight) 
            
                enemyRB.AddForce(new Vector2(-1, 0) * enemySpeed);
            else
                    enemyRB.AddForce(new Vector2(1, 0) * enemySpeed);
                enemyAnim.SetBool ("Run", true);
            
        }
        if (other.tag == "Player")
        {
            if (!facingRight)
                enemyRB.AddForce(new Vector2(-1, 0) * enemySpeed);
            else
                enemyRB.AddForce(new Vector2(1, 0) * enemySpeed);

            enemyAnim.SetBool("Run", false);
            enemyAnim.SetBool("Attack", true);
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            canFlip = true;
            enemyRB.velocity = new Vector2(0, 0);
            enemyAnim.SetBool("Run", false);
        }
    }

    void flip()
        {
        if (!canFlip)
            return;
            
            facingRight = !facingRight;
            Vector3 theScale = enemyGraphic.transform.localScale;
            theScale.x *= -1;
            enemyGraphic.transform.localScale = theScale;
        }
    
}
