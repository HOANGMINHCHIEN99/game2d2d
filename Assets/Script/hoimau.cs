using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoimau : MonoBehaviour
{
    // Start is called before the first frame update
    public float hoihpAmount;  // bien dem tong so mau cua nhan vat
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            playerHP thePlayerHealth = other.gameObject.GetComponent<playerHP> ();
            thePlayerHealth.addHeart (hoihpAmount);
            Destroy(gameObject);
        }
    }
}
