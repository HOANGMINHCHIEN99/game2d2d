using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vungnuoc : MonoBehaviour
{
    public float damage;
    float dameRate = 0.5f;  // 0.5s giay dame len nhan vat 1 lan
    float nextDamage;  // khai bao luot dame tiep theo len nhan vat
    void Start()
    {
        nextDamage = 0f;  // cho vat can gay sat thuong len nhan vat ngay lap tuc
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && nextDamage < Time.time)
        {
            playerHP thePlayerHP = other.gameObject.GetComponent<playerHP>();
            thePlayerHP.addDamage(damage);
            nextDamage = dameRate + Time.time;
        }
    }
}
