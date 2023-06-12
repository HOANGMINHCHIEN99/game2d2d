using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skilldragon : MonoBehaviour
{
    public float Skilldragon;
    Rigidbody2D myBody;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        StartCoroutine(MoveAfterDelay());
    }

IEnumerator MoveAfterDelay()
{
yield return new WaitForSeconds(1f); // chờ 3 giây trước khi di chuyển viên đạn
if (transform.right.x > 0)
{
myBody.AddForce(new Vector2(1, 0) * Skilldragon, ForceMode2D.Impulse); // thay doi huong bay cua skill sang phai
}
else
{
myBody.AddForce(new Vector2(-1, 0) * Skilldragon, ForceMode2D.Impulse); // skill bay sang trai
}
}

    void Update()
    {
        
    }

    public void removeForce()
    {
        myBody.velocity = Vector2.zero;
    }
}