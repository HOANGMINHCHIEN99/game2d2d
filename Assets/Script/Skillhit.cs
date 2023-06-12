using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skillhit : MonoBehaviour
{
    public GameObject dragonfire;
    skilldragon myPC;
    public float skilldamage;

    void Awake()
    {
        myPC = GetComponentInParent<skilldragon>(); // caau lenh truy cap skill vo Skilldragon

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }    
    
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Shoottable")
            {
                myPC.removeForce();
            Instantiate(dragonfire, transform.position, transform.rotation);
                Destroy(gameObject);
            if (other.gameObject.layer == LayerMask.NameToLayer("enemy"))
            {
                HPbaygai hurtHPbaygai = other.gameObject.GetComponent<HPbaygai> ();   // lay chuc nang trong ham HPbaygai
                hurtHPbaygai.addDamage(skilldamage);  // xac dinh khi skill va cham toi doi tuong ten enemy se tao ra 1 bien tu HPbaygai sau do  no se goi bien nhan bien damage nhan sat thuong
            }
            }
        }
        void OnTriggerStay2d (Collider2D other) // ontrigerstay la cho vien dan di xuyen qua nam trong vat the va cham
        {
            if (other.gameObject.tag == "Shoottable")
            {
                myPC.removeForce();
            Instantiate(dragonfire, transform.position, transform.rotation);
            Destroy(gameObject);
            if (other.gameObject.layer == LayerMask.NameToLayer("enemy"))
            {
                HPbaygai hurtHPbaygai = other.gameObject.GetComponent<HPbaygai>();   
                hurtHPbaygai.addDamage(skilldamage);  
            }
        }
        }
}
