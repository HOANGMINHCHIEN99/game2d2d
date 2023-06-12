using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbaygai : MonoBehaviour
{

    public float maxHP;
    float currentHP;
    // khai bao bien tao thanh hp cho enemy
    public Slider enemyHealthSliderAI;


    // khai bao bien de cho enemy rot ra lo mau khi chet
    public bool drop;
    public GameObject theDrop;

    void Start()
    {
        currentHP = maxHP;
        enemyHealthSliderAI.maxValue = maxHP;
        enemyHealthSliderAI.value = maxHP;
    }

 
    void Update()
    {

    }
    public void addDamage(float damage)
    {
        enemyHealthSliderAI.gameObject.SetActive(true); // lam an hien thanh mau cua AI
            currentHP = currentHP - damage;
        
        enemyHealthSliderAI.value = currentHP;
            if (currentHP <= 0)
                makeDead();
    }
    
    void makeDead() 
    {
    gameObject.SetActive(false); // lam cho no ẩn enemy

        if(drop)
        {
            Instantiate (theDrop,transform.position,transform.rotation);
        }
     }
}
