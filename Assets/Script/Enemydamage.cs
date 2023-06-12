using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemydamage : MonoBehaviour
{
    public float damage;
    float dameRate = 0.5f;  // 0.5s giay dame len nhan vat 1 lan
    public float pushBackForce; // khai bao bien ma khi nhan vat bi va cham vao bay se bi bat ra
    float nextDamage;  // khai bao luot dame tiep theo len nhan vat
    void Start()
    {
        //nextDamage = 0f;  // cho vat can gay sat thuong len nhan vat ngay lap tuc
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D other)
{
    if (other.gameObject.tag == "Player" && nextDamage < Time.time)
    {
        playerHP thePlayerHP = other.gameObject.GetComponent<playerHP>();
        thePlayerHP.addDamage(damage);
        nextDamage = dameRate + Time.time;
        pushBack(other.transform);
    }
}


IEnumerator TakeDamage(playerHP player)
{
    float timePassed = 0f; // Khởi tạo biến timePassed là thời gian đã trôi qua từ lần chạm gần nhất
    while(timePassed < 1f) // Trừ HP sau mỗi 1 giây
    {
        player.addDamage(damage * Time.deltaTime);
        timePassed += Time.deltaTime;
        yield return null;
    }
}
    void pushBack(Transform pushedObject)
    {
        Vector2 pushDrirection = new Vector2(0, (pushedObject.position.y - transform.position.y)).normalized; // nomalized tra ngay ve vector cos gia tri binh thuong
        pushDrirection *= pushBackForce; // dien vao luc bat ra khoi vat can
        Rigidbody2D pushRigibody2D = pushedObject.gameObject.GetComponent<Rigidbody2D>();
        pushRigibody2D.velocity = Vector2.zero;  // vector2.zero rs luc ve vi tri vector x0 y0
        pushRigibody2D.AddForce(pushDrirection,ForceMode2D.Impulse); // foecmod.impluse them ngay 1 sung luc lam cho nhan vat bay len
    }
}
