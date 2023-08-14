using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backend : MonoBehaviour
{
    public static Backend instance;
    public web web;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        web = GetComponent<web>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
