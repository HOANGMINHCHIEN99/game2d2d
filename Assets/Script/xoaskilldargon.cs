using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xoaskilldargon : MonoBehaviour
{
    public float xoaskill;

    void Start()
    {
        Destroy(gameObject, xoaskill);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
