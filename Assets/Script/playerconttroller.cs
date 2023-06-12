using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class playerconttroller : MonoBehaviour
{
    

    public float maxSpeed;
    public float jumpHeight;
    Rigidbody2D myBody;
    Animator myAnim;
    
    bool facingRight;
    bool grounded;

    // khai bao bien skill
    public Transform skill;
    public GameObject Skilldragon;
    float fireRate = 1f; // 5s dung skill 1 lan
    float nextFire = 1; // sau 5s moi dc ban

    bool usingSkill = false;
    float skillTimer = 0f;
    float skillDuration = 1f; // thoi gian hoat dong cua animation skill

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        facingRight = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal"); // biến move lay chữ từ ban phim doi sang so de di chuyen trai phai
        myAnim.SetFloat("walk", Mathf.Abs(move)); // mathf.abs de chuyen gia tri thanh gia tri tuyet doi khong bh bi. -scale
        myAnim.SetFloat("walkskin",Mathf.Abs(move));
        myBody.velocity = new Vector2(move * maxSpeed, myBody.velocity.y); // biến này để thiết lập vận tốc của nhân vật trong game
        // tạo biến move >0 và <0 để tính toaasn và xoay mặt cho nhân vật
        if (move > 0 && !facingRight)
        {
            flip();
        }
        else if (move < 0 && facingRight)
        {
            flip();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (grounded)
            {
                grounded = false; // kiểm tra điều kiênh xem nhân vật có đứng trên đất ko
                myBody.velocity = new Vector2(myBody.velocity.x, jumpHeight); 
            }
        }

        // chuc nang dung skill tu ban phim
        if (!usingSkill && Input.GetAxisRaw("Fire1") > 0)
        {
            fireSkill();
        }

        if (usingSkill)
        {
            myBody.velocity = new Vector2(0f, myBody.velocity.y); // nhân vật dùng kỹ năng thì trục x của nhân vật sẽ = 0 và không thể di chuyển
            skillTimer += Time.deltaTime;   

            if (skillTimer >= skillDuration)  // điều kiện thể skill timer được rs để tiến hành dùng skill tiếp theo
            {
                usingSkill = false;
                myAnim.SetBool("skill", false);
                myAnim.SetBool("skillvip",false);
                skillTimer = 0f;
            }
        }
    }

    void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;       // nhan voi -1 de scale 1 thanh -1 nhan vat quay mat lai
        transform.localScale = theScale;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            grounded = true;
        }
        else if (other.gameObject.tag == "door")
        {
            SceneManager.LoadSceneAsync("game2").completed += LoadSceneComplete;
        }

        if (other.gameObject.tag == "skin")
        {
            myAnim.SetBool("kichhoatskin", true);
            Destroy(other.gameObject);
        }
    }

    void LoadSceneComplete(AsyncOperation operation)
    {
        myAnim.SetBool("kichhoatskin", true);
    }


    // chuc nang skill
    void fireSkill()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate; // dong lenh sau 5s moi dc dung skill 1 phat
            usingSkill = true;
            myAnim.SetBool("skill", true);
            myAnim.SetBool("skillvip",true);

            if (facingRight)
            {
                Instantiate(Skilldragon, skill.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else if (!facingRight)
            {
                Instantiate(Skilldragon, skill.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            }
        }
    }
}
