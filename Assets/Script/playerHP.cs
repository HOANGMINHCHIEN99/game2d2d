using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerHP : MonoBehaviour
{
    public GameObject choilai;
    public GameObject choilaimap2;
    public float HPplayer;
    float currentHP;
    public GameObject bloodEffect;
    Animator myAnim;

    // khai bao cac bien cho UI
    public Slider playerHealthSlider;

    void Start()
    {
        currentHP = HPplayer;
        playerHealthSlider.maxValue = HPplayer;
        playerHealthSlider.value = HPplayer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addDamage(float damage)
    {
        if (damage <= 0)
            return;
        currentHP -= damage;
        playerHealthSlider.value = currentHP;

        if (currentHP <= 0)
        {
            makeDead();
        }
    }

    // tao ra chuc nang hoi mau khi dung lo mau
    public void addHeart(float hoihpAmount)
    {
        currentHP += hoihpAmount;   // luong mau hien tai bang luong mau dang co cộng với lượng máu hồi
        if (currentHP > HPplayer)
            currentHP = HPplayer;
        playerHealthSlider.value = currentHP;
    }
    void makeDead()
    {
        Animator myAnim = GetComponent<Animator>();
        if (myAnim != null)
        {
            myAnim.SetTrigger("dungsidie");
        }

        if (choilai != null)
        {
            choilai.SetActive(true);
        }

        if (choilaimap2 != null)
        {
            choilaimap2.SetActive(true);
        }

        gameObject.SetActive(false);
        Destroy(gameObject);
    }

}